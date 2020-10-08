using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Lookups;
using System.Web;

namespace JpmmsClasses.BL
{
    public class MaintenanceFeedback
    {
        public OracleDatabaseClass db = new OracleDatabaseClass();




        public bool Insert(string CONTRACT_NO, int CONTRACTOR_ID, string JOB_ORDER_NO, DateTime? JOB_ORDER_DATE, DateTime? FINISH_DATE)
        {
            CONTRACT_NO = CONTRACT_NO.Replace("'", "''");
            JOB_ORDER_NO = JOB_ORDER_NO.Replace("'", "''");
            string jobOrderDate = ((DateTime)JOB_ORDER_DATE).ToString("dd/MM/yyyy");
            string finishDate = ((DateTime)FINISH_DATE).ToString("dd/MM/yyyy");

            string sql = string.Format("insert into FEEDBACKS(FEEDBACK_ID, CONTRACTOR_ID, CONTRACT_NO, JOB_ORDER_NO, JOB_ORDER_DATE, FINISH_DATE, ENTRY_DATE) " +
                " values(SEQ_FEEDBACKS.nextval, {0}, '{1}', '{2}', To_date('{3}','DD/MM/YYYY'), To_date('{4}','DD/MM/YYYY'), (select sysdate from dual)) ",
                CONTRACTOR_ID, CONTRACT_NO, JOB_ORDER_NO, jobOrderDate, finishDate);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(int FEEDBACK_ID, string CONTRACT_NO, int CONTRACTOR_ID, string JOB_ORDER_NO, DateTime? JOB_ORDER_DATE, DateTime? FINISH_DATE)
        {
            CONTRACT_NO = CONTRACT_NO.Replace("'", "''");
            JOB_ORDER_NO = JOB_ORDER_NO.Replace("'", "''");
            string jobOrderDate = ((DateTime)JOB_ORDER_DATE).ToString("dd/MM/yyyy");
            string finishDate = ((DateTime)FINISH_DATE).ToString("dd/MM/yyyy");

            string sql = string.Format("update FEEDBACKS CONTRACTOR_ID={0}, CONTRACT_NO='{1}', JOB_ORDER_NO='{2}', JOB_ORDER_DATE=To_date('{3}','DD/MM/YYYY'), " +
                " FINISH_DATE=To_date('{4}','DD/MM/YYYY') where FEEDBACK_ID={5} ",
                CONTRACT_NO, CONTRACTOR_ID, JOB_ORDER_NO, jobOrderDate, finishDate, FEEDBACK_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Delete(int FEEDBACK_ID)
        {
            if (FEEDBACK_ID == 0)
                return false;

            string sql = string.Format("delete from FEEDBACKS where FEEDBACK_ID={0} ", FEEDBACK_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool InsertFeedbackLocation(bool section, bool intersect, bool region, string mainSt, string sectionID, string interID, string sampleID, string regionID,
            string secondID, int maintDecID, DateTime? maintDate, string udiBefore, int udiAfter, int feedbackID)
        {
            string sql = "";
            string udiBeforePart = (string.IsNullOrEmpty(udiBefore) ? "NULL" : int.Parse(udiBefore).ToString());
            string samplePart = "", sampleValuePart = "";
            //int udiAfter=0;
            int rows = 0;
            DateTime dtMaintDate = (DateTime)maintDate;

            if (section)
            {
                samplePart = (sampleID == "0") ? "" : " SAMPLE_ID, ";
                sampleValuePart = (sampleID == "0") ? "" : string.Format(" {0}, ", int.Parse(sampleID)); // MAIN_ST_ID
                sql = string.Format("insert into FEEDBACK_DETAILS(RECORD_ID, STREET_ID, SECTION_ID, {7} UDI_BEFORE, UDI_AFTER, MAINT_DEC_ID, FEEDBACK_ID, ENTRY_DATE, MAINT_DATE, IS_SECTION) " +
                    " values(SEQ_FEEDBACKS.nextval, {0}, {1}, {2} {3}, {4}, {5}, {6}, (select sysdate from dual), To_date('{8}','DD/MM/YYYY'), 1) ",
                    int.Parse(mainSt), int.Parse(sectionID), sampleValuePart, udiBeforePart, udiAfter.ToString("N0"), maintDecID, feedbackID, samplePart, dtMaintDate.ToString("dd/MM/yyyy"));

                rows = db.ExecuteNonQuery(sql);


                // update R3 and no permits dates in section details table, to prevent issuing drilling permits
                sql = string.Format("update SECTION_DETAILS set IS_R3='Y', R3_DATE=To_date('{0}','DD/MM/YYYY'), NO_PERMIT_TILL_DATE=To_date('{1}','DD/MM/YYYY') where section_id={2} ",
                    dtMaintDate.ToString("dd/MM/yyyy"), dtMaintDate.AddMonths(6).ToString("dd/MM/yyyy"), sectionID);

                rows += db.ExecuteNonQuery(sql);
            }
            else if (intersect)
            {
                samplePart = (sampleID == "0") ? "" : " INTER_SAMP_ID, ";
                sampleValuePart = (sampleID == "0") ? "" : string.Format(" {0}, ", int.Parse(sampleID)); // MAIN_ST_ID
                sql = string.Format("insert into FEEDBACK_DETAILS(RECORD_ID, STREET_ID, INTER_ID, {8} UDI_BEFORE, UDI_AFTER, MAINT_DATE, MAINT_DEC_ID, FEEDBACK_ID, ENTRY_DATE, IS_INTERSECT) " +
                    " values(SEQ_FEEDBACKS.nextval, {0}, {1}, {2} {3}, {4}, To_date('{5}','DD/MM/YYYY'), {6}, {7}, (select sysdate from dual), 1) ",
                    int.Parse(mainSt), int.Parse(interID), sampleValuePart, udiBeforePart, udiAfter.ToString("N0"), dtMaintDate.ToString("dd/MM/yyyy"), maintDecID, feedbackID, samplePart);

                rows = db.ExecuteNonQuery(sql);


                // update R3 and no permits dates in intersection details table, to prevent issuing drilling permits
                sql = string.Format("update INTERSECTION_DETAILS set R3_DATE=To_date('{0}','DD/MM/YYYY'), NO_PERMIT_TILL_DATE=To_date('{1}','DD/MM/YYYY') where INTERSECTION_ID={2} ",
                    dtMaintDate.ToString("dd/MM/yyyy"), dtMaintDate.AddMonths(6).ToString("dd/MM/yyyy"), interID);

                rows += db.ExecuteNonQuery(sql);
            }
            else if (region)
            {
                sql = string.Format("insert into FEEDBACK_DETAILS(RECORD_ID, REGION_ID, STREET_ID, UDI_BEFORE, UDI_AFTER, MAINT_DATE, MAINT_DEC_ID, FEEDBACK_ID, ENTRY_DATE, IS_REGION) " +
                    " values(SEQ_FEEDBACKS.nextval, {0}, {1}, {2}, {3}, To_date('{4}','DD/MM/YYYY'), {5}, {6}, (select sysdate from dual), 1) ", // SECOND_ID
                    int.Parse(regionID), int.Parse(secondID), udiBeforePart, udiAfter.ToString("N0"), dtMaintDate.ToString("dd/MM/yyyy"), maintDecID, feedbackID);

                rows = db.ExecuteNonQuery(sql);


                // update R3 and no permits dates in intersection details table, to prevent issuing drilling permits
                sql = string.Format("update SECONDARY_STREET_DETAILS set R3_DATE=To_date('{0}','DD/MM/YYYY'), NO_PERMIT_TILL_DATE=To_date('{1}','DD/MM/YYYY') where STREET_ID={2} ",
                    dtMaintDate.ToString("dd/MM/yyyy"), dtMaintDate.AddMonths(6).ToString("dd/MM/yyyy"), secondID);

                rows += db.ExecuteNonQuery(sql);
            }
            else
                return false;


            return (rows > 0);
        }



        public bool UpdateFeedbackLocation(int RECORD_ID, int MAINT_DEC_ID, DateTime? MAINT_DATE)
        {
            if (RECORD_ID == 0)
                return false;

            int rows = 0;
            DateTime dtFinishDate = (MAINT_DATE != null) ? (DateTime)MAINT_DATE : DateTime.Today;


            string udiBeforeSql = string.Format("select nvl(SECTION_ID, 0) as SECTION_ID, nvl(INTER_ID, 0) as INTER_ID, nvl(STREET_ID, 0) as STREET_ID, UDI_BEFORE " +
                " from FEEDBACK_DETAILS where RECORD_ID={0} ", RECORD_ID);

            DataTable dtUdibefore = db.ExecuteQuery(udiBeforeSql);
            if (dtUdibefore.Rows.Count > 0)
            {
                //string udiBefore = db.ExecuteScalar(udiBeforeSql).ToString();
                DataRow dr = dtUdibefore.Rows[0];
                string udiBefore = dr["UDI_BEFORE"].ToString();
                int sectionID = int.Parse(dr["SECTION_ID"].ToString());
                int intersectID = int.Parse(dr["INTER_ID"].ToString());
                int streetID = int.Parse(dr["STREET_ID"].ToString());


                int udiAfter = (int)new MaintDecision().GetMaintDecisionNewUDI(MAINT_DEC_ID, udiBefore);
                string sql = string.Format("update FEEDBACK_DETAILS set UDI_AFTER={0}, MAINT_DATE=To_date('{1}','DD/MM/YYYY'), MAINT_DEC_ID={2}  where RECORD_ID={3} ",
                       udiAfter.ToString("N0"), ((DateTime)MAINT_DATE).ToString("dd/MM/yyyy"), MAINT_DEC_ID, RECORD_ID);

                rows = db.ExecuteNonQuery(sql);
                if (rows > 0)
                {
                    if (sectionID != 0)
                    {
                        // update R3 and no permits dates in section details table, to prevent issuing drilling permits
                        sql = string.Format("update SECTION_DETAILS set IS_R3='Y', R3_DATE=To_date('{0}','DD/MM/YYYY'), NO_PERMIT_TILL_DATE=To_date('{1}','DD/MM/YYYY') where section_id={2} ",
                            dtFinishDate.ToString("dd/MM/yyyy"), dtFinishDate.AddMonths(6).ToString("dd/MM/yyyy"), sectionID);

                        rows += db.ExecuteNonQuery(sql);
                    }
                    else if (intersectID != 0)
                    {
                        // update R3 and no permits dates in intersection details table, to prevent issuing drilling permits
                        sql = string.Format("update INTERSECTION_DETAILS set R3_DATE=To_date('{0}','DD/MM/YYYY'), NO_PERMIT_TILL_DATE=To_date('{1}','DD/MM/YYYY') where INTERSECTION_ID={2} ",
                            dtFinishDate.ToString("dd/MM/yyyy"), dtFinishDate.AddMonths(6).ToString("dd/MM/yyyy"), intersectID);

                        rows += db.ExecuteNonQuery(sql);
                    }
                    else if (streetID != 0)
                    {
                        // update R3 and no permits dates in intersection details table, to prevent issuing drilling permits
                        sql = string.Format("update SECONDARY_STREET_DETAILS set R3_DATE=To_date('{0}','DD/MM/YYYY'), NO_PERMIT_TILL_DATE=To_date('{1}','DD/MM/YYYY') where STREET_ID={2} ",
                            dtFinishDate.ToString("dd/MM/yyyy"), dtFinishDate.AddMonths(6).ToString("dd/MM/yyyy"), streetID);

                        rows += db.ExecuteNonQuery(sql);
                    }
                }
            }

            return (rows > 0);
        }

        public bool DeleteFeedbackLocation(int RECORD_ID)
        {
            if (RECORD_ID == 0)
                return false;

            string sql = string.Format("delete from FEEDBACK_DETAILS where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }



        public DataTable GetAllFeedbackLocations(bool section, bool intersect, bool region, string mainSt, string sectionID, string interID, string sampleID,
            string regionID, string secondID)
        {
            string sql = "";
            string orderPart = " order by FINISH_DATE desc ";

            if (section)
            {
                sql = "select record_id, SECTION_TITLE as big_element, SAMPLE_TITLE as sample_element, MAINT_DEC_ID, RECOMMENDED_DECISION, RECOMMENDED_DECISION_AR, FINISH_DATE, UDI_BEFORE, UDI_AFTER, CONTRACTOR_ID, CONTRACTOR_NAME from VW_FEEDBACKS_LOCATIONS  ";
                string sectionPart = (string.IsNullOrEmpty(sectionID) || sectionID == "0") ? "" : string.Format(" and section_id={0} ", sectionID);
                string samplePart = (string.IsNullOrEmpty(sampleID) || sampleID == "0") ? "" : string.Format(" and SAMPLE_ID={0} ", sampleID);

                sql = string.Format("{0} where STREET_ID={1} and section_id is not null {2} {3} {4} ", sql, mainSt, sectionPart, samplePart, orderPart); // MAIN_ST_ID

            }
            else if (intersect)
            {
                sql = "select record_id, INTERSECT_TITLE as big_element, INTER_SAMP_NO as sample_element, MAINT_DEC_ID, RECOMMENDED_DECISION, RECOMMENDED_DECISION_AR, FINISH_DATE, UDI_BEFORE, UDI_AFTER, CONTRACTOR_ID, CONTRACTOR_NAME from VW_FEEDBACKS_LOCATIONS  ";
                string intersectPart = (string.IsNullOrEmpty(interID) || interID == "0") ? "" : string.Format(" and INTER_ID={0} ", interID);
                string samplePart = (string.IsNullOrEmpty(sampleID) || sampleID == "0") ? "" : string.Format(" and INTER_SAMP_ID={0} ", sampleID);

                sql = string.Format("{0} where STREET_ID={1} and INTER_ID is not null {2} {3} {4} ", sql, mainSt, intersectPart, samplePart, orderPart);
            }
            else if (region)
            {
                sql = "select record_id, (REGION_NO || '-' || SUBDISTRICT) as big_element, (SECOND_ST_NO || '-' || SECOND_AR_NAME)  as sample_element, MAINT_DEC_ID, RECOMMENDED_DECISION, RECOMMENDED_DECISION_AR, FINISH_DATE, UDI_BEFORE, UDI_AFTER, CONTRACTOR_ID, CONTRACTOR_NAME from VW_FEEDBACKS_LOCATIONS ";
                string samplePart = (string.IsNullOrEmpty(secondID) || secondID == "0") ? "" : string.Format(" and STREET_ID={0} ", secondID); // SECOND_ID

                sql = string.Format("{0} where REGION_ID={1}  {2} {3} ", sql, regionID, samplePart, orderPart);
            }
            else
                return new DataTable();


            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable GetAllFeedbackLocations(int feedbackID)
        {
            string orderPart = " order by maint_date desc ";
            string wherePart = string.Format(" where FEEDBACK_ID={0} ", feedbackID);


            string sql = string.Format("select record_id, nvl(nvl(SECTION_TITLE, INTERSECT_TITLE), (REGION_NO || '-' || SUBDISTRICT)) as big_element, " +
                " nvl(nvl(SAMPLE_TITLE, INTER_SAMP_NO), (SECOND_ST_NO || '-' || SECOND_AR_NAME))  as sample_element, MAINT_DEC_ID, RECOMMENDED_DECISION, " +
                " RECOMMENDED_DECISION_AR, FINISH_DATE, UDI_BEFORE, UDI_AFTER, CONTRACTOR_ID, CONTRACTOR_NAME, maint_date, HEADING from VW_FEEDBACKS_LOCATIONS  {0} {1} ",
                wherePart, orderPart);

            return db.ExecuteQuery(sql);
        }



        public DataTable GetAll()
        {
            string sql = "select * from VW_FEEDBACKS  order by entry_date desc ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetFeedbackByID(int id)
        {
            if (id == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_FEEDBACKS  where FEEDBACK_ID={0} order by entry_date desc ", id);
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(bool section, bool intersect, bool region, string mainSt, string sectionID, string interID, string sampleID, string regionID,
            string secondID, DateTime? fromDate, DateTime? toDate, int maintD, int contractorID)
        {
            string wherePart = "", streetPart="";
            string sql = "select * from VW_FEEDBACKS_LOCATIONS ";
            string orderPart = " order by MAINT_DATE desc"; // FINISH_DATE 


            string contractorPart = (contractorID == 0) ? "" : string.Format("and CONTRACTOR_ID={0} ", contractorID);

            string sectionPart = (string.IsNullOrEmpty(sectionID) || sectionID == "0") ? "" : string.Format(" and section_id={0}", sectionID);
            string samplePart = (string.IsNullOrEmpty(sampleID) || sampleID == "0") ? "" : string.Format(" and SAMPLE_ID={0}", sampleID);
            string intersectPart = (string.IsNullOrEmpty(interID) || interID == "0") ? "" : string.Format(" and INTER_ID={0}", interID);
            string interSamplePart = (string.IsNullOrEmpty(sampleID) || sampleID == "0") ? "" : string.Format(" and INTER_SAMP_ID={0}", sampleID);
            string regionPart = (string.IsNullOrEmpty(regionID) || regionID == "0") ? "" : string.Format(" and REGION_ID={0}", regionID);
            //string secondStPart = 

            string MaintDecPart = (maintD == 0) ? "" : string.Format(" and MAINT_DEC_ID={0}", maintD); 
            string fromPart = (fromDate == null) ? "" : string.Format("and MAINT_DATE >= to_date('{0}', 'DD/MM/YYYY') ", ((DateTime)fromDate).ToString("dd/MM/yyyy"));
            string toPart = (toDate == null) ? "" : string.Format("and MAINT_DATE <= to_date('{0}', 'DD/MM/YYYY') ", ((DateTime)toDate).ToString("dd/MM/yyyy"));

            if (section)
            {
                streetPart = (string.IsNullOrEmpty(mainSt) || mainSt == "0") ? "" : string.Format(" and STREET_ID={0}", mainSt); // MAIN_ST_ID   mainStPart
                wherePart = string.Format(" where section_id is not null {0} {1} {2} ", streetPart, sectionPart, samplePart); // mainStPart
            }
            else if (intersect)
            {
                streetPart = (string.IsNullOrEmpty(mainSt) || mainSt == "0") ? "" : string.Format(" and STREET_ID={0}", mainSt); // MAIN_ST_ID   mainStPart
                wherePart = string.Format(" where INTER_ID is not null {0} {1} {2} ", streetPart, intersectPart, interSamplePart);
            }
            else if (region)
            {
                streetPart = (string.IsNullOrEmpty(secondID) || secondID == "0") ? "" : string.Format(" and STREET_ID={0}", secondID);
                wherePart = string.Format(" where REGION_ID is not null {0} {1} ", regionPart, streetPart); // secondStPart
            }
            else
                return new DataTable();


            sql = string.Format("{0} {1} {2} {3} {4} {5} {6} ", sql, wherePart, MaintDecPart, fromPart, toPart, contractorPart, orderPart);
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(bool section, bool intersect, bool region, string mainSt, string sectionID, string interID, string sampleID, string regionID,
            string secondID)
        {
            string wherePart = "";
            string sql = "select * from VW_FEEDBACKS_LOCATIONS ";
            string orderPart = " order by FINISH_DATE desc";

            string streetPart = "";
            string sectionPart = (string.IsNullOrEmpty(sectionID) || sectionID == "0") ? "" : string.Format(" and section_id={0}", sectionID);
            string samplePart = (string.IsNullOrEmpty(sampleID) || sampleID == "0") ? "" : string.Format(" and SAMPLE_ID={0}", sampleID);
            string intersectPart = (string.IsNullOrEmpty(interID) || interID == "0") ? "" : string.Format(" and INTER_ID={0}", interID);
            string interSamplePart = (string.IsNullOrEmpty(sampleID) || sampleID == "0") ? "" : string.Format(" and INTER_SAMP_ID={0}", sampleID);


            if (section)
            {
                if (string.IsNullOrEmpty(mainSt) || mainSt == "0")
                    return new DataTable();

                streetPart = string.Format(" and STREET_ID={0}", mainSt);
                wherePart = string.Format(" where section_id is not null {0} {1} {2} ", streetPart, sectionPart, samplePart); // mainStPart
            }
            else if (intersect)
            {
                if (string.IsNullOrEmpty(mainSt) || mainSt == "0")
                    return new DataTable();

                streetPart = string.Format(" and STREET_ID={0}", mainSt);
                wherePart = string.Format(" where INTER_ID is not null {0} {1} {2} ", streetPart, intersectPart, interSamplePart);
            }
            else if (region)
            {
                if (string.IsNullOrEmpty(regionID) || regionID == "0")
                    return new DataTable();

                string regionPart = string.Format(" and REGION_ID={0}", regionID);
                streetPart = (string.IsNullOrEmpty(secondID) || secondID == "0") ? "" : string.Format(" and STREET_ID={0}", secondID);
                wherePart = string.Format(" where REGION_ID is not null {0} {1} ", regionPart, streetPart); // secondStPart
            }
            else
                return new DataTable();


            sql = string.Format("{0} {1} {2} ", sql, wherePart, orderPart);
            return db.ExecuteQuery(sql);
        }



        public string GetFeedbackImage(int id)
        {
            if (id == 0)
                return "";

            string sql = string.Format("select nvl(JOB_ORDER_FILE, '')  as JOB_ORDER_FILE from FEEDBACKS  where FEEDBACK_ID={0} ", id);
            return db.ExecuteScalar(sql).ToString();
        }

        public bool EditFeedbackJobOrderImage(string imageFileName, int id)
        {
            if (id == 0)
                return false;

            string sql = string.Format("update FEEDBACKS set JOB_ORDER_FILE='{0}' where FEEDBACK_ID={1} ", imageFileName, id);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteFeedbackJobOrderImage(int id)
        {
            if (id == 0)
                return false;

            string sql = string.Format("select JOB_ORDER_FILE from FEEDBACKS where FEEDBACK_ID={0} ", id);
            string fileName = db.ExecuteScalar(sql).ToString();
            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/uploads/") + fileName);

            sql = string.Format("update FEEDBACKS set JOB_ORDER_FILE=null where FEEDBACK_ID={0} ", id);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


    }
}
