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
    public class FwdReport
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetFwdReport(string mainNo, bool all , string SURVEYNO)
        {
            string sql = "";
            mainNo = mainNo.Replace("'", "''");

            if (all) //(string.IsNullOrEmpty(mainNo) || mainNo == "0")  main_no
                sql = string.Format("SELECT * FROM FWD_SECTION_DETIALS  where SURVEY_NO={0}  ORDER by arname, SEC_DIRECTION, sec_order, SECTION_NO, STATION_ID, DROP_ID ", SURVEYNO);
            else
                sql = string.Format("SELECT * FROM FWD_SECTION_DETIALS where MAIN_No='{0}' AND SURVEY_NO={1} ORDER  by SEC_DIRECTION, sec_order, SECTION_NO, STATION_ID, DROP_ID ", mainNo, SURVEYNO);

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }
      

    }
}
