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
    public class SkidReport
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable SkidReportForMainStreet(string mainNo, bool isIntersection, bool allSections, bool allIntersects, string SURVEYNO)
        {
            if (!(allSections || allIntersects) && (string.IsNullOrEmpty(mainNo) || mainNo == "0"))
                return new DataTable();

            string sql = "";
            mainNo = mainNo.Replace("'", "''");

            if (isIntersection) //intersection_order, 
                sql = string.Format("SELECT * FROM SKID_JEDDAH_int_TEST where SURVEY_NO={1} and MAIN_No='{0}' AND INTERSECTION_NO IS NOT NULL     order by intersection_no, direction ", mainNo, SURVEYNO);
            else if (allSections)
                sql = string.Format("SELECT * FROM  SKID_JEDDAH where SURVEY_NO={0} and SECTION_NO IS NOT NULL  order by main_no, sec_direction, sec_order, section_no, distance ", SURVEYNO); //, mainNo); MAIN_No='{0}' AND 
            else if (allIntersects)
                sql = string.Format("SELECT * FROM SKID_JEDDAH_int_TEST where SURVEY_NO={0} and INTERSECTION_NO IS NOT NULL     order by arname, intersection_no, direction ", SURVEYNO); //, mainNo); // MAIN_No='{0}' AND  intersection_order
            else
                sql = string.Format("SELECT * FROM SKID_JEDDAH  where SURVEY_NO={1} and MAIN_No='{0}' AND SECTION_NO IS NOT NULL      order by sec_direction, sec_order, section_no, distance ", mainNo, SURVEYNO);

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

    }
}
