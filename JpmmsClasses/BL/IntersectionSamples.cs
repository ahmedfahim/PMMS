using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;
//using Oracle.DataAccess.Client;
using System.Web;

namespace JpmmsClasses.BL
{
    public class IntersectionSamples
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        public DataTable GetIntersectionSamples(int intersectionID)
        {
            if (intersectionID == 0)
                return new DataTable();

            string sql = string.Format(@"SELECT INTER_SAMP_ID, INTER_SAMP_NO, INTERSEC_SAMP_AREA, INTER_NO, NOTES,
            (select count(STREET_ID) TotaDISTRESS from jpmms.DISTRESS xd where xd.INTERSECTION_ID=S.INTERSECTION_ID and xd.INTER_SAMP_ID=S.INTER_SAMP_ID and 
            xd.SURVEY_NO=(select max(SURVEY_NO) from jpmms.DISTRESS xd where xd.INTERSECTION_ID=S.INTERSECTION_ID and xd.INTER_SAMP_ID=S.INTER_SAMP_ID) group by INTERSECTION_ID ) 
            DISTRESS FROM INTERSECTION_samples s where INTERSECTION_ID={0} ORDER BY INTER_SAMP_NO  ", intersectionID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionSamplesByMainStreet(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM GV_INTERSECTION_SAMPLES where STREET_ID={0} ORDER BY inter_no, INTER_SAMP_NO  ", mainStID); // MAIN_STREET_ID
            return db.ExecuteQuery(sql);
        }

        public static bool IntersectionSampleReadyForDistressEntry(int intersectSampleID)
        {
            if (intersectSampleID == 0)
                return false;

            string sql = string.Format("SELECT INTER_SAMP_ID, INTER_SAMP_NO, INTERSEC_SAMP_AREA AS AREA FROM INTERSECTION_SAMPLES WHERE INTER_SAMP_ID={0} and INTERSEC_SAMP_AREA is not null ", intersectSampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                return decimal.Parse(dt.Rows[0]["AREA"].ToString()) > 0;
            else
                return false;
            //return (dt.Rows.Count > 0);
        }


        public bool UpdateIntersectionSampleArea(int INTER_SAMP_ID, double INTERSEC_SAMP_AREA, string user, string NOTES)
        {
            string sql = "";
            int lastSurveyNum = DistressSurvey.GetLastIntersectionSurveyNumber(INTER_SAMP_ID);
            if (lastSurveyNum == 0)
            {
                // no surveys have been done over this secondar street, so we can update its length and width directly
                sql = string.Format("UPDATE INTERSECTION_SAMPLES SET INTERSEC_SAMP_AREA={0}, NOTES='{2}' WHERE INTER_SAMP_ID={1} ", INTERSEC_SAMP_AREA, INTER_SAMP_ID, NOTES);

                int rows = db.ExecuteNonQuery(sql);
                Shared.SaveLogfile("INTERSECTION_SAMPLES", INTER_SAMP_ID.ToString(), "Update", user);
                return (rows > 0);
            }
            else
            {
                // surveys have been done over this secondar street, so we have to remove them before we can update its length and width directly
                sql = string.Format("UPDATE INTERSECTION_SAMPLES SET INTERSEC_SAMP_AREA={0}, NOTES='{2}' WHERE INTER_SAMP_ID={1} ", INTERSEC_SAMP_AREA, INTER_SAMP_ID, NOTES);
                int rows = db.ExecuteNonQuery(sql);

                //if (INTERSEC_SAMP_AREA == 0)
                //{
                //    sql = string.Format("delete from DISTRESS WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                //    db.ExecuteNonQuery(sql);
                //}
                //else
                //{
                //    sql = string.Format("UPDATE DISTRESS SET STATUS='N' WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                //    db.ExecuteNonQuery(sql);
                //}

                //sql = string.Format("UPDATE UDI SET UDI_DATE=NULL, UDI_VALUE=NULL, UDI_RATE=NULL, UDI_UP_DATE=NULL, UDI_UPD_VALUE=NULL, UDI_UPD_RATE=NULL, STATUS='N', STATUS_UPD='N'  WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                //db.ExecuteNonQuery(sql);

                //sql = string.Format("DELETE FROM PREVENT_MAINT_DECISIONS WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                //db.ExecuteNonQuery(sql);

                //sql = string.Format("DELETE FROM MAINTENANCE_DECISIONS WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                //db.ExecuteNonQuery(sql);

                rows += FixDistressesAfterAreaChange(INTER_SAMP_ID, INTERSEC_SAMP_AREA, user);


                sql = string.Format("UPDATE UDI_INTERSECTION_SAMPLE SET UDI_DATE=NULL, UDI_VALUE=NULL, UDI_RATE=NULL WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                rows += db.ExecuteNonQuery(sql);


                Shared.SaveLogfile("INTERSECTION_SAMPLES", INTER_SAMP_ID.ToString(), "Update", user);
                return (rows > 0);
            }
        }

        public int FixDistressesAfterAreaChange(int INTER_SAMP_ID, double INTERSEC_SAMP_AREA, string user)
        {
            int rows = 0;
            string sql = "";

            if (INTERSEC_SAMP_AREA == 0)
            {
                sql = string.Format("delete from DISTRESS WHERE INTER_SAMP_ID={0} ", INTER_SAMP_ID);
                rows += db.ExecuteNonQuery(sql);
            }
            else
            {
                int distID = 0;
                int distressCode = 0;
                char DIST_SEVERITY;
                double distressDensity = 0;
                double distArea = 0;
                double deductValue = 0;
                double densityDashValue = 0;
                double deductDashValue = 0;


                sql = string.Format("SELECT STATUS_UPD, dist_code, DIST_SEVERITY, DIST_AREA, DIST_ID FROM DISTRESS WHERE SAMPLE_ID={0} ", INTER_SAMP_ID);
                DataTable dtSecondStDist = db.ExecuteQuery(sql);
                foreach (DataRow dr in dtSecondStDist.Rows)
                {
                    distID = int.Parse(dr["DIST_ID"].ToString());
                    distressCode = int.Parse(dr["dist_code"].ToString());
                    DIST_SEVERITY = dr["DIST_SEVERITY"].ToString()[0];
                    distArea = double.Parse(dr["DIST_AREA"].ToString());
                    distressDensity = (distArea / INTERSEC_SAMP_AREA) * 100.0;
                    distressDensity = (distressDensity > 100) ? 100 : distressDensity;

                    deductValue = DistressShared.CalculateDeductValue(distressCode, DIST_SEVERITY);
                    densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("G2")));
                    deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);

                    sql = string.Format("UPDATE DISTRESS SET STATUS='N', STATUS_UPD='N', DIST_DENSITY={0}, DEDUCT_VALUE={1}, DEN_DASH={2}, DEDUCT_DEN_DASH={3}  WHERE DIST_ID={4} ",
                        distressDensity.ToString("0.00"), deductValue.ToString("0.00"), densityDashValue.ToString("0.00"), deductDashValue.ToString("0.00"), distID);

                    rows += db.ExecuteNonQuery(sql);
                    Shared.SaveLogfile("DISTRESS", distID.ToString(), "Distress Update", user);
                }
            }

            return rows;
        }


        public static double GetIntersectionSampleArea(int intersectSampleID)
        {
            string sql = string.Format("select nvl(INTERSEC_SAMP_AREA, 0) as INTERSEC_SAMP_AREA from INTERSECTION_SAMPLES where INTER_SAMP_ID={0} ", intersectSampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return ((dt.Rows.Count == 0) ? 0 : double.Parse(dt.Rows[0]["INTERSEC_SAMP_AREA"].ToString()));
        }

        public DataTable AdvancedSearch(int mainStID)
        {
            string sql = string.Format("select * from GV_INTERSECTION_SAMPLES where STREET_ID={0} ", mainStID); // MAIN_STREET_ID
            return db.ExecuteQuery(sql);
        }


    }
}
