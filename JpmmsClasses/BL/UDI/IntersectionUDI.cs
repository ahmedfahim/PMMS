using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using JpmmsClasses.BL.DistressEntry;
using System.Diagnostics;
using System.Web;

namespace JpmmsClasses.BL.UDI
{
    public class IntersectionUDI
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private Dates hijri = new Dates();
        private DistressShared shared = new DistressShared();
        private DistressSurvey distSurvey = new DistressSurvey();
        private UdiRecord udi = new UdiRecord();



        #region UDI Calculations

        public bool CalculateMainStreetIntersectionsUDI(int mainStID, string user, bool wholeNetwork)
        {
            bool result = true;
            DataTable dt;
            if (wholeNetwork)
                dt = distSurvey.GetRegionsAndMainStreetSectionIntersections(0, "", "", "", false, false, false, false, mainStID, false, true);
            else
                dt = distSurvey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, false, true);

            foreach (DataRow dr in dt.Rows)
                result &= CalculateMainStreetIntersectionsUDI(mainStID, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        public bool CalculateMainStreetIntersectionsUDI(int mainStID, int surveyNo, string user)
        {
            RemovePreviousCalculations(mainStID, surveyNo);

            int rows = 0;
            decimal DEDUCT_DEN_RAT = 0;
            //decimal de_valu = 0;

            string intersectDistressSQL = ""; //, maxSurveyDate = "";
            DataTable dtIntersectSampleDistresses; //, dtExists; //, dtSurveyDate;

            string sql = string.Format("SELECT intersection_id, Inter_no, inter_SAMP_ID, inter_SAMP_NO, interSEC_samp_AREA FROM GV_INTERSECTION_SAMPLES  WHERE STREET_ID={0} and INTerSEC_samp_AREA<>0  order by Inter_no, inter_SAMP_NO  ", mainStID);
            Shared.LogStatment(sql); // MAIN_STREET_ID
            DataTable dtIntersectSamples = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtIntersectSamples.Rows)
            {
                udi = new UdiRecord();

                string intersection_id = dr["intersection_id"].ToString();
                // STATUS, STATUS_UPD, ENTRY_DATE_UPD 
                intersectDistressSQL = string.Format("SELECT arname, inter_no, INTER_SAMP_NO, inter_SAMP_ID, SURVEY_NO, to_char(MAX(SURVEY_DATE), 'DD/MM/YYYY', 'NLS_CALENDAR=''GREGORIAN''') as Max_SURVEY_DATE, " +
                    " SUM(DEDUCT_DEN_DASH) DEDUCT_DEN_RAT, SUM(DIST_DENSITY) DEN, MAX(DEDUCT_VALUE) DE_VALUE, MAX(DEN_DASH) DEN_D, MAX(DIST_CODE) DIS_CODE " +
                    " FROM GV_inters_SMPL_DISTRESS  WHERE inter_SAMP_ID={0} AND SURVEY_NO={1}    GROUP BY arname, inter_no, INTER_SAMP_NO, inter_SAMP_ID, SURVEY_NO  ",
                    dr["inter_SAMP_ID"].ToString(), surveyNo);

                Shared.LogStatment(intersectDistressSQL);
                dtIntersectSampleDistresses = db.ExecuteQuery(intersectDistressSQL);
                if (dtIntersectSampleDistresses.Rows.Count == 0)
                    continue;
                else
                {
                    #region All Distresses
                    DataRow Ors = dtIntersectSampleDistresses.Rows[0];
                    DEDUCT_DEN_RAT = decimal.Parse(Ors["DEDUCT_DEN_RAT"].ToString());
                    if (DEDUCT_DEN_RAT >= 0 && DEDUCT_DEN_RAT <= 5)
                        udi = UdiShared.GetUDI(DEDUCT_DEN_RAT);
                    else if (DEDUCT_DEN_RAT > 5)
                        udi = UdiShared.GetUDI(decimal.Parse(Ors["DE_VALUE"].ToString()));


                    // INTER_NO='{0}' AND INTER_SAMP_NO='{1}' dr["inter_SAMP_No"].ToString(),                  
                    //sql = string.Format("SELECT INTER_NO, INTER_SAMP_NO, SURVEY_NO FROM UDI_INTERSECTION_SAMPLE WHERE inter_SAMP_ID={0} AND SURVEY_NO={1} ", dr["inter_SAMP_ID"].ToString(), surveyNo);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_INTERSECTION_SAMPLE set INTER_NO='{0}', INTER_SAMP_NO='{1}', INTER_SAMP_AREA={2}, SURVEY_DATE=TO_DATE('{3}','DD/MM/YYYY'), " +
                    //        " UDI_DATE=(select sysdate from dual), UDI_VALUE={4}, UDI_RATE='{5}', STREET_ID={6}, INTER_ID={7} where INTER_SAMP_ID={8} and SURVEY_NO={9} ",
                    //       dr["INTER_NO"].ToString(), dr["inter_SAMP_No"].ToString(), dr["interSEC_samp_AREA"].ToString(), Ors["Max_SURVEY_DATE"].ToString(),
                    //       udi.udiValue.ToString("N0"), udi.udiRate, mainStID, dr["intersection_id"].ToString(), dr["INTER_SAMP_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_INTERSECTION_SAMPLE WHERE inter_SAMP_ID={0} AND SURVEY_NO={1} ", dr["inter_SAMP_ID"].ToString(), surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }


                    sql = string.Format("INSERT INTO UDI_INTERSECTION_SAMPLE(INTER_NO, INTER_SAMP_NO, INTER_SAMP_AREA, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, RECORD_ID, INTER_SAMP_ID, STREET_ID, INTER_ID) " +
                        " VALUES('{0}','{1}', {2}, TO_DATE('{3}','DD/MM/YYYY'), (select sysdate from dual), " +
                        " {4}, '{5}', {6},  SEQ_UDI_INTERSECTION_SAMPLE.nextval, {7}, {8}, {9}) ",
                        dr["INTER_NO"].ToString(), dr["inter_SAMP_No"].ToString(), dr["interSEC_samp_AREA"].ToString(), Ors["Max_SURVEY_DATE"].ToString(),
                        udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, dr["INTER_SAMP_ID"].ToString(), mainStID, dr["intersection_id"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                    #endregion

                    #region Patching Distresses

                    intersectDistressSQL = string.Format("SELECT arname, inter_no, INTER_SAMP_NO, inter_SAMP_ID, SURVEY_NO, to_char(MAX(SURVEY_DATE), 'DD/MM/YYYY', 'NLS_CALENDAR=''GREGORIAN''') as Max_SURVEY_DATE, " +
                        " SUM(DEDUCT_DEN_DASH) DEDUCT_DEN_RAT, SUM(DIST_DENSITY) DEN, MAX(DEDUCT_VALUE) DE_VALUE, MAX(DEN_DASH) DEN_D, MAX(DIST_CODE) DIS_CODE " +
                        " FROM GV_inters_SMPL_DISTRESS  WHERE inter_SAMP_ID={0} AND SURVEY_NO={1}  and DIST_CODE in (12, 13, 14, 15)  " +
                        " GROUP BY arname, inter_no, INTER_SAMP_NO, inter_SAMP_ID, SURVEY_NO  ",
                        dr["inter_SAMP_ID"].ToString(), surveyNo);

                    Shared.LogStatment(intersectDistressSQL);
                    dtIntersectSampleDistresses = db.ExecuteQuery(intersectDistressSQL);
                    if (dtIntersectSampleDistresses.Rows.Count == 0)
                    {
                        //continue;
                        double sampleArea = double.Parse(dr["interSEC_samp_AREA"].ToString());
                        udi = UdiShared.GetUDI(0);
                    }
                    else
                    {
                        Ors = dtIntersectSampleDistresses.Rows[0];
                        DEDUCT_DEN_RAT = decimal.Parse(Ors["DEDUCT_DEN_RAT"].ToString());
                        if (DEDUCT_DEN_RAT >= 0 && DEDUCT_DEN_RAT <= 5)
                            udi = UdiShared.GetUDI(DEDUCT_DEN_RAT);
                        else if (DEDUCT_DEN_RAT > 5)
                            udi = UdiShared.GetUDI(decimal.Parse(Ors["DE_VALUE"].ToString()));
                    }


                    if (udi.udiValue == -1)
                        continue;

                    // INTER_NO='{0}' AND INTER_SAMP_NO='{1}' dr["inter_SAMP_No"].ToString(),                  
                    //sql = string.Format("SELECT INTER_NO, INTER_SAMP_NO, SURVEY_NO FROM UDI_INTERSECT_SAMPLE_PATCHING WHERE inter_SAMP_ID={0} AND SURVEY_NO={1} ", dr["inter_SAMP_ID"].ToString(), surveyNo);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_INTERSECT_SAMPLE_PATCHING set INTER_NO='{0}', INTER_SAMP_NO='{1}', INTER_SAMP_AREA={2}, SURVEY_DATE=TO_DATE('{3}','DD/MM/YYYY'), " +
                    //        " UDI_DATE=(select sysdate from dual), UDI_VALUE={4}, UDI_RATE='{5}', STREET_ID={6}, INTER_ID={7} where INTER_SAMP_ID={8} and SURVEY_NO={9} ",
                    //       dr["INTER_NO"].ToString(), dr["inter_SAMP_No"].ToString(), dr["interSEC_samp_AREA"].ToString(), Ors["Max_SURVEY_DATE"].ToString(),
                    //       udi.udiValue.ToString("N0"), udi.udiRate, mainStID, dr["intersection_id"].ToString(), dr["INTER_SAMP_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_INTERSECT_SAMPLE_PATCHING WHERE inter_SAMP_ID={0} AND SURVEY_NO={1} ", dr["inter_SAMP_ID"].ToString(), surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }

                    sql = string.Format("INSERT INTO UDI_INTERSECT_SAMPLE_PATCHING (INTER_NO, INTER_SAMP_NO, INTER_SAMP_AREA, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, RECORD_ID, INTER_SAMP_ID, STREET_ID, INTER_ID) " +
                           " VALUES('{0}','{1}', {2}, TO_DATE('{3}','DD/MM/YYYY'), (select sysdate from dual), " +
                           " {4}, '{5}', {6},  SEQ_UDI_INTERSECTION_SAMPLE.nextval, {7}, {8}, {9}) ",
                           dr["INTER_NO"].ToString(), dr["inter_SAMP_No"].ToString(), dr["interSEC_samp_AREA"].ToString(), Ors["Max_SURVEY_DATE"].ToString(),
                           udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, dr["INTER_SAMP_ID"].ToString(), mainStID, dr["intersection_id"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                    //}
                    #endregion
                }
            }


            Shared.SaveLogfile("UDI", dtIntersectSamples.Rows.Count.ToString(), "UDI Calculation - Main Street Intersections:" + mainStID.ToString(), user);

            //rows += CalculateIntersectionSamplesUDI(mainStID, surveyNo);
            rows += CalculateIntersectionUDI(mainStID, surveyNo);

            return (rows > 0);
        }

        public int CalculateIntersectionUDI(int mainStID, int surveyNo)
        {
            int rows = 0;
            DataRow drIntersectionRecord;
            DataTable dtIntersectionRecord; //, dtExists;

            string sql = string.Format("SELECT INTERSECTION_ID, INTER_NO, SUM(INTERSEC_SAMP_AREA) AS INTERSECTION_AREA, COUNT(distinct INTER_SAMP_NO) AS NO_OF_SAMPLE  FROM GV_INTERSECTION_SAMPLES " +
                " WHERE STREET_ID={0} and INTERSEC_SAMP_AREA is not null   GROUP BY INTERSECTION_ID, INTER_NO  order by Inter_no ", mainStID);

            Shared.LogStatment(sql);
            DataTable dtIntersections = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtIntersections.Rows)
            {
                udi = new UdiRecord();

                #region All Distresses

                sql = string.Format("SELECT INTER_NO, SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as udidate, ROUND(AVG(udi_value)) udivalue " +
                    " FROM UDI_intersection_sample  WHERE INTER_ID={0}  AND SURVEY_NO={1} GROUP BY INTER_no, SURVEY_NO ", // INTER_NO='{0}'
                    dr["INTERSECTION_ID"].ToString(), surveyNo);

                Shared.LogStatment(sql);
                dtIntersectionRecord = db.ExecuteQuery(sql);
                if (dtIntersectionRecord.Rows.Count > 0)
                {
                    drIntersectionRecord = dtIntersectionRecord.Rows[0];
                    udi = UdiShared.GetUDIRatio(decimal.Parse(drIntersectionRecord["udivalue"].ToString()));
                    if (udi.udiValue == -1)
                        continue;

                    //sql = string.Format("SELECT INTER_NO, SURVEY_NO FROM UDI_INTERSECTION  WHERE INTERSECTION_ID={0} AND SURVEY_NO={1}  ", dr["INTERSECTION_ID"].ToString(), surveyNo);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_INTERSECTION set INTER_NO='{0}', SURVEY_DATE=TO_DATE('{1}','DD/MM/YYYY'), INTERSECTION_AREA={2}, NO_OF_SAMPLES={3}, " +
                    //        " UDI_DATE=to_date('{4}', 'DD/MM/YYYY'), UDI_VALUE={5}, UDI_RATE='{6}', STREET_ID={7} where INTERSECTION_ID={8} and SURVEY_NO={9} ",
                    //    dr["INTER_NO"].ToString(), drIntersectionRecord["MAX_SURVEY_DATE"].ToString(), dr["INTERSECTION_AREA"].ToString(), dr["NO_OF_SAMPLE"].ToString(),
                    //    drIntersectionRecord["udidate"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, mainStID, dr["INTERSECTION_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_INTERSECTION WHERE INTERSECTION_ID={0} AND SURVEY_NO={1} ", dr["INTERSECTION_ID"].ToString(), surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }

                    sql = string.Format("INSERT INTO UDI_INTERSECTION(INTER_NO, SURVEY_DATE, INTERSECTION_AREA, NO_OF_SAMPLES, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, RECORD_ID, STREET_ID, INTERSECTION_ID) " +
                        " VALUES('{0}', TO_DATE('{1}','DD/MM/YYYY'), {2}, {3}, " +
                        " to_date('{4}', 'DD/MM/YYYY'), {5}, '{6}', {7}, SEQ_UDI_INTERSECTION.nextval, {8}, {9}) ",
                        dr["INTER_NO"].ToString(), drIntersectionRecord["MAX_SURVEY_DATE"].ToString(), dr["INTERSECTION_AREA"].ToString(), dr["NO_OF_SAMPLE"].ToString(),
                        drIntersectionRecord["udidate"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, mainStID, dr["INTERSECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                }
                #endregion

                #region Patching Distresses

                sql = string.Format("SELECT INTER_NO, SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as udidate, ROUND(AVG(udi_value)) udivalue " +
                    " FROM UDI_INTERSECT_SAMPLE_PATCHING  WHERE  INTER_ID={0}  AND SURVEY_NO={1} GROUP BY INTER_no, SURVEY_NO ", // INTER_NO='{0}' 
                    dr["INTERSECTION_ID"].ToString(), surveyNo);

                Shared.LogStatment(sql);
                dtIntersectionRecord = db.ExecuteQuery(sql);
                if (dtIntersectionRecord.Rows.Count > 0)
                {
                    drIntersectionRecord = dtIntersectionRecord.Rows[0];
                    udi = UdiShared.GetUDIRatio(decimal.Parse(drIntersectionRecord["udivalue"].ToString()));
                    if (udi.udiValue == -1)
                        continue;

                    //sql = string.Format("SELECT INTER_NO, SURVEY_NO FROM UDI_INTERSECTION_PATCHING  WHERE INTERSECTION_ID={0} AND SURVEY_NO={1}  ", dr["INTERSECTION_ID"].ToString(), surveyNo);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_INTERSECTION_PATCHING set INTER_NO='{0}', SURVEY_DATE=TO_DATE('{1}','DD/MM/YYYY'), INTERSECTION_AREA={2}, NO_OF_SAMPLES={3}, " +
                    //     " UDI_DATE=to_date('{4}', 'DD/MM/YYYY'), UDI_VALUE={5}, UDI_RATE='{6}', STREET_ID={7} where INTERSECTION_ID={8} and SURVEY_NO={9} ",
                    // dr["INTER_NO"].ToString(), drIntersectionRecord["MAX_SURVEY_DATE"].ToString(), dr["INTERSECTION_AREA"].ToString(), dr["NO_OF_SAMPLE"].ToString(),
                    // drIntersectionRecord["udidate"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, mainStID, dr["INTERSECTION_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_INTERSECTION_PATCHING WHERE INTERSECTION_ID={0} AND SURVEY_NO={1} ", dr["INTERSECTION_ID"].ToString(), surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }


                    sql = string.Format("INSERT INTO UDI_INTERSECTION_PATCHING(INTER_NO, SURVEY_DATE, INTERSECTION_AREA, NO_OF_SAMPLES, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, RECORD_ID, STREET_ID, INTERSECTION_ID) " +
                        " VALUES('{0}', TO_DATE('{1}','DD/MM/YYYY'), {2}, {3}, " +
                        " to_date('{4}', 'DD/MM/YYYY'), {5}, '{6}', {7}, SEQ_UDI_INTERSECTION.nextval, {8}, {9}) ",
                        dr["INTER_NO"].ToString(), drIntersectionRecord["MAX_SURVEY_DATE"].ToString(), dr["INTERSECTION_AREA"].ToString(), dr["NO_OF_SAMPLE"].ToString(),
                        drIntersectionRecord["udidate"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, mainStID, dr["INTERSECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                }
                #endregion
            }

            return rows;
        }


        private void RemovePreviousCalculations(int mainStID, int surveyNo)
        {
            string sql = string.Format("delete from UDI_INTERSECTION_SAMPLE where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_INTERSECTION where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_INTERSECT_SAMPLE_PATCHING where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_INTERSECTION_PATCHING where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);
        }


        private void TruncateUdiTables()
        {
            string sql = "truncate table UDI_INTERSECTION_SAMPLE ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_INTERSECTION ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_INTERSECT_SAMPLE_PATCHING ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_INTERSECTION_PATCHING ";
            db.ExecuteNonQuery(sql);
        }

        #endregion


        #region Reporting

        //public DataTable GetIntersectionsUDI(int intersectionID, int survey, bool withDistress, bool allDists)
        //{
        //    if (intersectionID == 0 || survey == 0)
        //        return new DataTable();

        //    string sql = "", tableName = "";
        //    if (withDistress)
        //    {
        //        tableName = allDists ? "VW_INTERSECT_SAMPLE_UDI_DIST" : "VW_INTERSECT_SAMPLE_UDI_P_DIST";
        //        sql = string.Format("SELECT * FROM {2} where INTERSECTION_ID={0} and survey_no={1} order by INTER_NO, INTER_SAMP_NO ", intersectionID, survey, tableName);
        //    }
        //    else
        //    {
        //        tableName = allDists ? "IntSecUDI_Dist" : "INTSECUDI_DIST_patching";
        //        sql = string.Format("SELECT * FROM {2} where INTERSECTION_ID={0} and survey_no={1} order by INTER_NO, INTER_SAMP_NO ", intersectionID, survey, tableName);
        //    }

        //    return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        //}

        //public DataTable GetIntersectionUDI(int mainStID, int surveyNo, bool allDists)
        //{
        //    if (mainStID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDists ? "IntSecUDI_Dist" : "INTSECUDI_DIST_patching";     // MAIN_ST_ID
        //    string sql = string.Format("SELECT * FROM {2} where STREET_ID={0} AND SURVEY_NO={1} ORDER BY INTERSECTION_ORDER, INTER_NO, INTER_samp_NO ", mainStID, surveyNo, tableName);
        //    return db.ExecuteQuery(sql);
        //}

        public DataTable GetMainStreetIntersectionUDI(int mainStID, int surveyNo)
        {
            if (mainStID == 0)
                return new DataTable();

            string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and survey_no={0} ", surveyNo);

            // where INTER_NO in (select INTER_NO from INTERSECTIONS        MAIN_STREET_ID
            string sql = string.Format("select * from INTERSECTION_UDI where STREET_ID={0} {1} ", mainStID, surveyNumPart);
            return db.ExecuteQuery(sql);
        }



        public DataTable GetMainStreetIntersectionUDI(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            //string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and survey_no={0} ", surveyNo); surveyNumPart
            string sql = string.Format("select * from VW_LATEST_UDI_INTERSECTIONS where STREET_ID={0}  ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionsUDI(int intersectionID, bool withDistress, bool allDists, bool samplesLevel)
        {
            if (intersectionID == 0)
                return new DataTable();

            string sql = "", tableName = "", orderbyPart = ""; //, surveyPart = ""; // and survey_no=survey, 
            if (withDistress)
            {
                tableName = allDists ? "VW_LATEST_UD_DIST_INTER_SAMP" : "VW_LATEST_UD_DIST_INTER_SAMP_P";
                string patchDistPart = (!allDists) ? " and dist_code in (0, 12, 13, 14, 15) " : "";
                //surveyPart = string.Format("and survey_no=(select max(survey_no) from {1} where INTERSECTION_ID={0})  ", intersectionID, tableName); surveyPart, 
                sql = string.Format("SELECT * FROM {1} where INTERSECTION_ID={0} {2}  order by INTER_NO, INTER_SAMP_NO ", intersectionID, tableName, patchDistPart);
            }
            else
            {
                if (samplesLevel)
                {
                    orderbyPart = " order by INTER_NO, INTER_SAMP_NO ";
                    tableName = allDists ? "VW_LATEST_UDI_INTER_SAMPLES" : "VW_LATEST_UDI_INTER_SAMPLES_P";
                }
                else
                {
                    orderbyPart = " order by INTER_NO ";
                    tableName = allDists ? "VW_LATEST_UDI_INTERSECTIONS" : "VW_LATEST_UDI_INTERSECTIONS_P";
                }

                //surveyPart = string.Format("and survey_no=(select max(survey_no) from {1} where INTERSECTION_ID={0})  ", intersectionID, tableName); surveyPart, 
                sql = string.Format("SELECT * FROM {1} where INTERSECTION_ID={0} {2}  ", intersectionID, tableName, orderbyPart);
            }

            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }


        public DataTable GetIntersectionUDI(int mainStID, bool allDists, bool samplesLevel)
        {
            if (mainStID == 0)
                return new DataTable();

            string tableName = "";
            if (samplesLevel)
                tableName = allDists ? "VW_LATEST_UDI_INTER_SAMPLES" : "VW_LATEST_UDI_INTER_SAMPLES_P";
            else
                tableName = allDists ? "VW_LATEST_UDI_INTERSECTIONS" : "VW_LATEST_UDI_INTERSECTIONS_P";     // MAIN_ST_ID

            //string surveyPart = string.Format("and survey_no=(select max(survey_no) from {1} where STREET_ID={0})  ", mainStID, tableName);  surveyPart,  INTER_samp_NO
            string sql = string.Format("SELECT * FROM {1} where SURVEY_NO>2 and STREET_ID={0} ORDER BY INTERSECTION_ORDER, INTER_NO ", mainStID, tableName);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetIntersectionUDIByMonth(string MonthYear, bool allDists, bool samplesLevel)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return null;

            string tableName = "";
            if (samplesLevel)
                tableName = allDists ? "VW_LATEST_UDI_INTER_SAMPLES" : "VW_LATEST_UDI_INTER_SAMPLES_P";
            else
                tableName = allDists ? "VW_LATEST_UDI_INTERSECTIONS" : "VW_LATEST_UDI_INTERSECTIONS_P";     // MAIN_ST_ID

            //string surveyPart = string.Format("and survey_no=(select max(survey_no) from {1} where STREET_ID={0})  ", mainStID, tableName);  surveyPart,  INTER_samp_NO
            //            string sql = string.Format(@"SELECT * FROM {2} where SURVEY_NO>2 and INTER_NO in (select INTER_NO from INTERSECTQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}')
            //            ORDER BY INTERSECTION_ORDER, INTER_NO ", SplitMonthYear[0], SplitMonthYear[1], tableName);
            string sql = string.Format(@"SELECT * FROM {2} where SURVEY_NO>2 and INTER_NO in (select d.INTER_NO 
                         from JPMMS.GV_INTERSECTION_DISTRESS d  join   
                         JPMMS.INTERSECTQC Q on d.INTER_NO=Q.INTER_NO and d.SURVEY_NO = Q.SURVEY_NO where 
                         IS_REVIEWREPORT=1 and IS_READY=1 and REPORTSMONTH='{0}' and REPORTSYEAR='{1}'
                         group by d.INTER_NO, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no )
            ORDER BY INTERSECTION_ORDER, INTER_NO ", SplitMonthYear[0], SplitMonthYear[1], tableName);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetIntersectionUDI(string municNo, bool allDists, bool samplesLevel)
        {
            if (municNo == "0" || string.IsNullOrEmpty(municNo))
                return new DataTable();

            string tableName = "";
            if (samplesLevel)
                tableName = allDists ? "VW_LATEST_UDI_INTER_SAMPLES" : "VW_LATEST_UDI_INTER_SAMPLES_P";
            else
                tableName = allDists ? "VW_LATEST_UDI_INTERSECTIONS" : "VW_LATEST_UDI_INTERSECTIONS_P";     // MAIN_ST_ID

            string sql = string.Format("SELECT * FROM {1} where INTER_NO like '{0}%' ORDER BY INTERSECTION_ORDER, INTER_NO ", municNo, tableName);
            return db.ExecuteQuery(sql);
        }

        #endregion

    }
}
