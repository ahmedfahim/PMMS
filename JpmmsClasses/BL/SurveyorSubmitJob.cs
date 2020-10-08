using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL
{
    public class SurveyorSubmitJob
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        #region InsertingWork

        public bool Insert(int surveyorID, DateTime? issueDate, DateTime? recieveDate, int surveyNo, string notes, string ID, JobType jobType)
        {
            // sectionNo, interNo, regionNo,  string surveyorName,
            string sql = "";
            int rows = 0;
            int x = 0;
            if (string.IsNullOrEmpty(ID))
                throw new Exception("الرجاء اختيار العنصر الممسوح - مقطع أو تقاطع أو منطقة فرعية");

            string surveyorName = Surveyor.GetSurveyorByID(surveyorID).Rows[0]["SURVEYOR_NAME"].ToString();
            string issueDatePart = (issueDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)issueDate).ToString("dd/MM/yyyy"));
            string recieveDatePart = (recieveDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)recieveDate).ToString("dd/MM/yyyy"));

            notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));

            switch (jobType)
            {
                case JobType.Section:
                    sql = string.Format("SELECT Count(*) as X FROM SURVEYORS_SUBMIT_JOB where section_NO=(select section_no from sections where section_id={0}) and SURVEY_NO={1} and SURVEYOR_ID={2} ", ID, surveyNo, surveyorID);
                    x = int.Parse(db.ExecuteScalar(sql).ToString());
                    if (x >= 1)
                        throw new Exception("هذا المسح مدخل من قبل");

                    //                                                      0               1       2           3           4           5           6
                    sql = string.Format("insert into SURVEYORS_SUBMIT_JOB(ISSUE_DATE, SURVEY_NO, NOTES, RECEIVE_DATE, SURVEYOR_NAME, SURVEYOR_ID, SECTION_NO, RECORD_ID, IS_SECTION)  " +
                        " values({0}, {1}, {2}, {3}, '{4}', {5}, (select SECTION_NO from SECTIONS where SECTION_ID={6}), SEQ_SURVEYORS_SUBMIT.nextval, 1) ",
                        issueDatePart, surveyNo, notes, recieveDatePart, surveyorName, surveyorID, ID);

                    rows += db.ExecuteNonQuery(sql);
                    break;

                case JobType.Intersection:
                    sql = string.Format("SELECT Count(*) as X FROM SURVEYORS_SUBMIT_JOB where inter_no=(select inter_no from INTERSECTIONS where INTERSECTION_ID={0}) and SURVEY_NO={1} and SURVEYOR_ID={2} ", ID, surveyNo, surveyorID);
                    x = int.Parse(db.ExecuteScalar(sql).ToString());
                    if (x >= 1)
                        throw new Exception("هذا المسح مدخل من قبل");

                    //                                                      0               1       2           3           4           5           6
                    sql = string.Format("insert into SURVEYORS_SUBMIT_JOB(ISSUE_DATE, SURVEY_NO, NOTES, RECEIVE_DATE, SURVEYOR_NAME, SURVEYOR_ID, INTER_NO, RECORD_ID, IS_INTERSECT)  " +
                        " values({0}, {1}, {2}, {3}, '{4}', {5}, (select INTER_NO from INTERSECTIONS where INTERSECTION_ID={6}), SEQ_SURVEYORS_SUBMIT.nextval, 1) ",
                        issueDatePart, surveyNo, notes, recieveDatePart, surveyorName, surveyorID, ID);

                    rows += db.ExecuteNonQuery(sql);
                    break;

                case JobType.RegionSecondaryStreets:
                    sql = string.Format("SELECT Count(*) as X FROM SURVEYORS_SUBMIT_JOB where REGION_NO=(select REGION_NO from REGIONS where REGION_ID={0}) and SURVEY_NO={1} and SURVEYOR_ID={2} ", ID, surveyNo, surveyorID);
                    x = int.Parse(db.ExecuteScalar(sql).ToString());
                    if (x >= 1)
                        throw new Exception("هذا المسح مدخل من قبل");

                    //                                                      0               1       2           3           4           5           6
                    sql = string.Format("insert into SURVEYORS_SUBMIT_JOB(ISSUE_DATE, SURVEY_NO, NOTES, RECEIVE_DATE, SURVEYOR_NAME, SURVEYOR_ID, REGION_NO, RECORD_ID, IS_REGION)  " +
                        " values({0}, {1}, {2}, {3}, '{4}', {5}, (select REGION_NO from REGIONS where REGION_ID={6}), SEQ_SURVEYORS_SUBMIT.nextval, 1) ",
                        issueDatePart, surveyNo, notes, recieveDatePart, surveyorName, surveyorID, ID);

                    rows += db.ExecuteNonQuery(sql);
                    break;

                default:
                    return false;
            }

            return (rows > 0);
        }

        public bool Delete(int RECORD_ID)
        {
            string sql = string.Format("delete from SURVEYORS_SUBMIT_JOB where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(int RECORD_ID, int SURVEYOR_ID, string ISSUE_DATE, string RECEIVE_DATE, string ACCEPT_DATE, string SURVEY_NO, string MUSTUKHLAS_ID, string notes)
        {
            //string sql = string.Format("select SURVEYOR_NAME from SURVEYORS where SURVEYOR_NO={0} ", SURVEYOR_ID);
            string surveyorName = Surveyor.GetSurveyorNameByID(SURVEYOR_ID); //db.ExecuteScalar(sql).ToString();

            ISSUE_DATE = (string.IsNullOrEmpty(ISSUE_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(ISSUE_DATE)));
            RECEIVE_DATE = (string.IsNullOrEmpty(RECEIVE_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(RECEIVE_DATE)));
            ACCEPT_DATE = (string.IsNullOrEmpty(ACCEPT_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(ACCEPT_DATE)));
            notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));
            MUSTUKHLAS_ID = string.IsNullOrEmpty(MUSTUKHLAS_ID) ? "NULL" : int.Parse(MUSTUKHLAS_ID).ToString();

            string sql = string.Format("update SURVEYORS_SUBMIT_JOB set SURVEYOR_ID={0}, SURVEYOR_NAME='{1}', ISSUE_DATE={2}, RECEIVE_DATE={3}, ACCEPT_DATE={4}, SURVEY_NO={5}, MUSTUKHLAS_ID={6}, notes={8}  where RECORD_ID={7} ",
                SURVEYOR_ID, surveyorName, ISSUE_DATE, RECEIVE_DATE, ACCEPT_DATE, SURVEY_NO, MUSTUKHLAS_ID, RECORD_ID, notes);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(int RECORD_ID, int SURVEYOR_ID, string ISSUE_DATE, string RECEIVE_DATE, string SURVEY_NO, string notes)
        {
            //string sql = string.Format("select SURVEYOR_NAME from SURVEYORS where SURVEYOR_NO={0} ", SURVEYOR_ID);
            string surveyorName = Surveyor.GetSurveyorNameByID(SURVEYOR_ID); //db.ExecuteScalar(sql).ToString();

            ISSUE_DATE = (string.IsNullOrEmpty(ISSUE_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(ISSUE_DATE)));
            RECEIVE_DATE = (string.IsNullOrEmpty(RECEIVE_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(RECEIVE_DATE)));
            //ACCEPT_DATE = (string.IsNullOrEmpty(ACCEPT_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(ACCEPT_DATE)));
            notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));
            //MUSTUKHLAS_ID = string.IsNullOrEmpty(MUSTUKHLAS_ID) ? "NULL" : int.Parse(MUSTUKHLAS_ID).ToString();

            // ACCEPT_DATE={4},  MUSTUKHLAS_ID={6}, ACCEPT_DATE, MUSTUKHLAS_ID, 
            string sql = string.Format("update SURVEYORS_SUBMIT_JOB set SURVEYOR_ID={0}, SURVEYOR_NAME='{1}', ISSUE_DATE={2}, RECEIVE_DATE={3}, SURVEY_NO={4}, notes={5}  where RECORD_ID={6} ",
                SURVEYOR_ID, surveyorName, ISSUE_DATE, RECEIVE_DATE, SURVEY_NO, notes, RECORD_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        #endregion

        public DataTable GetAll(int id, bool section, bool intersect, bool region)
        {
            if (id == 0)
                return new DataTable();

            if (section)
            {
                string unionPart = string.Format("select section_no from sections where SECTION_ID={0}  ", id);
                string sql = string.Format("select decode(is_section, 1, 'مقطع', decode(is_intersect, 1, 'تقاطع', decode(is_region, 1, 'منطقة فرعية', '') )) as title,  nvl(nvl(SECTION_NO, inter_no), region_no) as num, surveyor_name, surveyor_id,  survey_no, ISSUE_DATE, RECEIVE_DATE, ACCEPT_DATE, MUSTUKHLAS_ID, notes, record_id from   SURVEYORS_SUBMIT_JOB where section_no in ({0})  order by num ", unionPart);

                return db.ExecuteQuery(sql);
            }
            else if (intersect)
            {
                //union 
                string unionPart = string.Format("select inter_no from intersections where INTERSECTION_ID={0}  ", id);
                string sql = string.Format("select decode(is_section, 1, 'مقطع', decode(is_intersect, 1, 'تقاطع', decode(is_region, 1, 'منطقة فرعية', '') )) as title,  nvl(nvl(SECTION_NO, inter_no), region_no) as num, surveyor_name, surveyor_id,  survey_no, ISSUE_DATE, RECEIVE_DATE, ACCEPT_DATE, MUSTUKHLAS_ID, notes, record_id from   SURVEYORS_SUBMIT_JOB where inter_no in({0}) order by num ", unionPart);

                return db.ExecuteQuery(sql);
            }
            else if (region)
            {
                string sql = string.Format("select decode(is_section, 1, 'مقطع', decode(is_intersect, 1, 'تقاطع', decode(is_region, 1, 'منطقة فرعية', '') )) as title, nvl(nvl(SECTION_NO, inter_no), region_no) as num, surveyor_name, surveyor_id,  survey_no, ISSUE_DATE, RECEIVE_DATE, ACCEPT_DATE, MUSTUKHLAS_ID, notes, record_id from   SURVEYORS_SUBMIT_JOB where region_no in (select region_no from regions where region_id={0}) order by num ", id);
                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }

        public DataTable GetSectionSurveyingWork(int id)
        {
            return GetAll(id, true, false, false);
        }

        public DataTable GetIntersectionSurveyingWork(int id)
        {
            return GetAll(id, false, true, false);
        }

        public DataTable GetRegionSurveyingWork(int id)
        {
            return GetAll(id, false, false, true);
        }

       


        #region Reporting

        public DataTable GetSurveyorsLateWork(JobType jobType, int surveyorID)
        {
            if (surveyorID == 0 || jobType == JobType.None)
                return new DataTable();

            string sql = "";
            switch (jobType)
            {
                case JobType.Section:
                    sql = string.Format("SELECT * FROM SURVEYORS_SECTIONS WHERE SURVEYOR_ID={0} AND RECEIVE_DATE IS NULL ", surveyorID);
                    return db.ExecuteQuery(sql);
                case JobType.Intersection:
                    sql = string.Format("SELECT *  FROM SURVEYORS_INTERSECTION WHERE SURVEYOR_ID={0} AND RECEIVE_DATE IS NULL ", surveyorID);
                    return db.ExecuteQuery(sql);
                case JobType.RegionSecondaryStreets:
                    sql = string.Format("SELECT * FROM SURVEYORS_REGIONS WHERE SURVEYOR_ID={0} AND RECEIVE_DATE IS NULL ", surveyorID);
                    return db.ExecuteQuery(sql);
                default:
                    return new DataTable();
            }
        }

        public DataTable GetSurveyorProductivity(JobType jobType, int surveyorID, DateTime? from, DateTime? to)
        {
            if (jobType == JobType.None || from == null || to == null) // surveyorID == 0 || Issue_DATE 
                return new DataTable();

            string sql = "";
            string surveyorIDPart = (surveyorID != 0) ? string.Format(" and SURVEYOR_ID={0} ", surveyorID) : "";

            switch (jobType)
            {
                case JobType.Section:
                    sql = string.Format("SELECT * FROM SURVEYORS_SECTION WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} ORDER BY RECEIVE_DATE ",
                         ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);

                    break;

                case JobType.Intersection:
                    sql = string.Format("SELECT * FROM SURVEYORS_INTERSECTIONs WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} ORDER BY RECEIVE_DATE ",
                         ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);

                    break;

                case JobType.RegionSecondaryStreets:
                    {
                        if (surveyorID != 0)
                            sql = string.Format("SELECT * FROM SURVEYORS_REGIONs WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} ORDER BY RECEIVE_DATE ",
                                 ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);
                        else
                            sql = string.Format(@"SELECT * FROM SURVEYORS_REGIONs WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} 
                                    union SELECT NULL,NULL,NULL,'  الكل  ',NULL,SUM (REGION_AREA),NULL,'  كل المساحين  ',NULL ,NULL,NULL,NULL,NULL,NULL,NULL  FROM jpmms.SURVEYORS_REGIONs_distinct  WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} ",
                             ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);
                    }

                    break;

                default:
                    return new DataTable();
            }


            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }

        public SurveyorsDeliveryTotal GetSurveyorsDeliveryTotals()
        {
            string sql = "SELECT round(sum(nvl(SECTION_AREA, 0)), 2) FROM SURVEYORS_SECTION ";
            double sectionSum = double.Parse(db.ExecuteScalar(sql).ToString());

            sql = "SELECT round(sum(nvl(INTERSECTION_AREA, 0)), 2) FROM SURVEYORS_INTERSECTION ";
            double intersectSum = double.Parse(db.ExecuteScalar(sql).ToString());

            sql = "SELECT round(sum(nvl(REGION_AREA, 0)), 2) FROM SURVEYORS_REGIONS ";
            double regionSum = double.Parse(db.ExecuteScalar(sql).ToString());

            return new SurveyorsDeliveryTotal(sectionSum, intersectSum, regionSum);
        }


        public DataTable GetSurveysWithNotes(JobType jobType)
        {
            if (jobType == JobType.None)
                return new DataTable();

            string sql = "";
            switch (jobType)
            {
                case JobType.Section:
                    sql = "SELECT * FROM  SURVEYORS_SECTION WHERE NOTES IS NOT NULL ORDER BY section_no ";
                    return db.ExecuteQuery(sql);

                case JobType.Intersection:
                    sql = "SELECT * FROM  SURVEYORS_INTERSECTION WHERE NOTES IS NOT NULL ORDER BY inter_no ";
                    return db.ExecuteQuery(sql);

                case JobType.RegionSecondaryStreets:
                    sql = "SELECT * FROM  SURVEYORS_REGIONS WHERE NOTES IS NOT NULL ORDER BY region_no ";
                    return db.ExecuteQuery(sql);

                default:
                    return new DataTable();
            }
        }

        public DataTable GetSurveyorProductivityByQtyDelivery(JobType jobType, int surveyorID, DateTime? from, DateTime? to)
        {
            if (jobType == JobType.None || from == null || to == null) //surveyorID == 0 || 
                return new DataTable();

            string sql = "";
            string surveyorIDPart = (surveyorID != 0) ? string.Format(" and SURVEYOR_ID={0} ", surveyorID) : "";

            switch (jobType)
            {
                case JobType.Section:
                    sql = string.Format("SELECT * FROM  SURVEYORS_SECTIONS WHERE  RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} ORDER BY RECEIVE_DATE ",
                         ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);
                    return db.ExecuteQuery(sql);

                case JobType.Intersection:
                    sql = string.Format("SELECT * FROM  SURVEYORS_INTERSECTIONS WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD-MM-YYYY') {2} ORDER BY RECEIVE_DATE ",
                         ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);
                    return db.ExecuteQuery(sql);

                case JobType.RegionSecondaryStreets:
                    sql = string.Format("SELECT * FROM  SURVEYORS_REGION WHERE RECEIVE_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY') {2} ORDER BY RECEIVE_DATE ",
                         ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"), surveyorIDPart);
                    return db.ExecuteQuery(sql);

                default:
                    return new DataTable();
            }
        }

        #endregion

        #region Quantities

        public DataTable GetSurveyorSectionSurveys(int surveyorID, DateTime from, DateTime to)
        {
            if (surveyorID == 0 || from == null || to == null)
                return new DataTable();

            string sql = string.Format("SELECT SECTION_NO, SECTION_AREA, RECEIVE_DATE FROM SURVEYORS_SECTION WHERE SURVEYOR_ID={0} AND RECEIVE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy') ORDER BY RECEIVE_DATE ", surveyorID, from.ToString("dd/MM/yyyy"), to.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyorIntersectionSurveys(int surveyorID, DateTime from, DateTime to)
        {
            if (surveyorID == 0 || from == null || to == null)
                return new DataTable();

            string sql = string.Format("SELECT INTER_NO, INTERSECTION_AREA, RECEIVE_DATE FROM SURVEYORS_INTERSECTION WHERE SURVEYOR_ID={0} AND RECEIVE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy') ORDER BY RECEIVE_DATE ", surveyorID, from.ToString("dd/MM/yyyy"), to.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyorRegionSurveys(int surveyorID, DateTime from, DateTime to)
        {
            if (surveyorID == 0 || from == null || to == null)
                return new DataTable();

            string sql = string.Format("SELECT SUBDISTRICT, REGION_NO, REGION_AREA, RECEIVE_DATE FROM SURVEYORS_REGION WHERE SURVEYOR_ID={0} AND RECEIVE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy') ORDER BY RECEIVE_DATE ", surveyorID, from.ToString("dd/MM/yyyy"), to.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }



        public decimal GetSurveyorSectionSurveysTotal(int surveyorID, DateTime from, DateTime to)
        {
            string sql = string.Format("SELECT  nvl(Sum(SECTION_AREA), 0) SECTION_AREA FROM SURVEYORS_SECTION WHERE SURVEYOR_ID={0}  AND RECEIVE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy') ", surveyorID, from.ToString("dd/MM/yyyy"), to.ToString("dd/MM/yyyy"));
            DataTable dt = db.ExecuteQuery(sql);
            return ((dt.Rows.Count == 0) ? 0 : decimal.Parse(dt.Rows[0]["SECTION_AREA"].ToString()));
        }

        public decimal GetSurveyorIntersectionSurveysTotal(int surveyorID, DateTime from, DateTime to)
        {
            string sql = string.Format("SELECT  nvl(Sum(INTERSECTION_AREA), 0) INTERSECTION_AREA FROM SURVEYORS_INTERSECTION WHERE SURVEYOR_ID={0}  AND RECEIVE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy') ", surveyorID, from.ToString("dd/MM/yyyy"), to.ToString("dd/MM/yyyy"));
            DataTable dt = db.ExecuteQuery(sql);
            return ((dt.Rows.Count == 0) ? 0 : decimal.Parse(dt.Rows[0]["INTERSECTION_AREA"].ToString()));
        }

        public decimal GetSurveyorRegionSurveysTotal(int surveyorID, DateTime from, DateTime to)
        {
            string sql = string.Format("SELECT  nvl(Sum(REGION_AREA), 0) REGION_AREA FROM SURVEYORS_REGION WHERE SURVEYOR_ID={0}  AND RECEIVE_DATE BETWEEN TO_DATE('{1}','dd/mm/yyyy') AND TO_DATE('{2}','dd/mm/yyyy') ", surveyorID, from.ToString("dd/MM/yyyy"), to.ToString("dd/MM/yyyy"));
            DataTable dt = db.ExecuteQuery(sql);
            return ((dt.Rows.Count == 0) ? 0 : decimal.Parse(dt.Rows[0]["REGION_AREA"].ToString()));
        }    

        #endregion

    }



    public enum JobType
    {
        None = 0,
        Section = 1,
        Intersection = 2,
        RegionSecondaryStreets = 3
    };

    public struct SurveyorsDeliveryTotal
    {
        public double SectionsTotal;
        public double IntersectsTotal;
        public double RegionsTotal;
        public double Total;

        public SurveyorsDeliveryTotal(double sTotal, double iTotal, double rTotal)
        {
            SectionsTotal = sTotal;
            IntersectsTotal = iTotal;
            RegionsTotal = rTotal;
            Total = sTotal + iTotal + rTotal;
        }
    }


}
