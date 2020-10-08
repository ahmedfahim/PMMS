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
    public class GprReport
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        public DataTable GetGprReportForMainStreet(bool isIntersection, string SURVEYNO)
        {
            string sql = "";
            // where MAIN_No='{0}' mainNo       intersectION_ORDER
            if (isIntersection)
                sql = string.Format("SELECT * FROM GPR_INTERSECTIONS where SURVEY_NO='{0}'  order by arname, direction, INTERSECTION_NO, lane ", SURVEYNO);
            else
                sql = string.Format("SELECT * FROM GPR_LANE where SURVEY_NO='{0}'  order by SEC_DIRECTION, SEC_ORDER, section_no, lane ", SURVEYNO);

            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }

        public DataTable GetGprReportForMainStreet(string mainNo, bool isIntersection, string SURVEYNO)
        {
            if (string.IsNullOrEmpty(mainNo))
                return new DataTable();

            string sql = "";
            if (isIntersection) // intersectION_ORDER
                sql = string.Format("SELECT * FROM GPR_INTERSECTIONS where MAIN_No='{0}' and SURVEY_NO='{1}'    order by arname, direction, INTERSECTION_NO, lane ", mainNo, SURVEYNO);
            else
                sql = string.Format("SELECT * FROM GPR_LANE where MAIN_No='{0}'  and SURVEY_NO='{1}'   order by SEC_DIRECTION, SEC_ORDER, section_no, lane ", mainNo, SURVEYNO);

            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }


    }
}
