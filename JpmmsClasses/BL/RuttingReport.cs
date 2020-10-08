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
    public class RuttingReport
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();


        #region Using Survey Number

        public DataTable GetMainStreetIriSurveys(string mainNo, bool allRoads, bool intersect, bool allintersect)
        {
            string sql = "";

            if (allintersect)
                sql = "SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM RUTTING_SECTIONS GROUP BY SURVEY_NO order by SURVEY_DATE desc ";
            else
            {
                if (!allRoads && (string.IsNullOrEmpty(mainNo) || mainNo == "0"))
                    return new DataTable();


                if (intersect)
                    sql = string.Format("SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM RUTTING_INTERSECTIONS WHERE MAIN_NO='{0}' GROUP BY SURVEY_NO order by SURVEY_DATE desc ", mainNo);

                else if (allRoads)
                    sql = "SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM RUTTING_SECTIONS GROUP BY SURVEY_NO order by SURVEY_DATE desc ";
                else
                    sql = string.Format("SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM RUTTING_SECTIONS WHERE MAIN_NO='{0}' GROUP BY SURVEY_NO order by SURVEY_DATE desc ", mainNo);

            }

            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }

        public DataTable GetRuttingReportForMainStreet(string mainNo, int surveyNo, bool allRoads, bool intersects)
        {
            if (!allRoads && (string.IsNullOrEmpty(mainNo) || mainNo == "0" || surveyNo == 0))
                return new DataTable();
            else if (allRoads && surveyNo == 0)
                return new DataTable();

            // MAIN_No='{0}' AND 
            //  sql = string.Format("SELECT * FROM RUTTING_INTERSECTIONS where  SURVEY_NO={0} ORDER BY INTERSECTION_ORDER, INTER_NO, LANE ", surveyNo);
            string sql = "";
            if (intersects)
                sql = string.Format("SELECT * FROM RUTTING_INTERSECTIONS where MAIN_No='{0}' AND SURVEY_NO={1}  ORDER BY INTER_NO, LANE ", mainNo, surveyNo); //SEC_DIRECTION, 
            else if (allRoads)
                sql = string.Format("SELECT * FROM RUTTING_SECTIONS where SURVEY_NO={0}     ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", surveyNo);
            else
                sql = string.Format("SELECT * FROM RUTTING_SECTIONS where MAIN_No='{0}' AND SURVEY_NO={1}   ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", mainNo, surveyNo);


            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }

        public DataTable GetAllIntersectionsRuttingReport(int surveyNo)
        {
            string sql = string.Format("SELECT * FROM RUTTING_INTERSECTIONS where SURVEY_NO={0}    ORDER BY main_no, INTER_NO, LANE ", surveyNo);
            return db.ExecuteQuery(sql);
        }
        #endregion


        #region Without Survey Number

        public DataTable GetAllIntersectionsRuttingReport()
        {
            // where SURVEY_NO=(select max(survey_no) as survey_no from RUTTING_INTERSECTIONS)  INTERSECTION_ORDER
            string sql = "SELECT * FROM VW_LATEST_RUTTING_INTERSECT  ORDER BY main_no, INTER_NO, LANE ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetRuttingReportForMainStreet(string mainNo, bool allSections, bool intersects)
        {
            if (!allSections && (string.IsNullOrEmpty(mainNo) || mainNo == "0"))
                return new DataTable();

            // RUTTING_INTERSECTIONS    RUTTING_SECTIONS    INTERSECTION_ORDER, 
            string query = "";

            if (intersects)
                query = string.Format("SELECT * FROM VW_LATEST_RUTTING_INTERSECT where MAIN_No='{0}'    ORDER BY INTER_NO, LANE ", mainNo);
            else if (allSections)
                query = "SELECT * FROM VW_LATEST_RUTTING_SECTIONS   ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ";
            else
                query = string.Format("SELECT * FROM VW_LATEST_RUTTING_SECTIONS where MAIN_No='{0}'     ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", mainNo);


            return (string.IsNullOrEmpty(query)) ? new DataTable() : db.ExecuteQuery(query);
        }

        #endregion

    }
}
