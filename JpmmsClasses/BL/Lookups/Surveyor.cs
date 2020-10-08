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
    public class Surveyor
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetSurveyorsInterSections()
        {
            string sql = @"SELECT SURVEYOR_NO, SURVEYOR_NAME, SURVEYOR_WORK_ENDDATE, SURVEYOR_WORK_STARTDATE, SURVEYOR_PHONE_NO, SUSPENDED, SUSPENDED_AR 
                                    FROM VW_SURVEYORS where SURVEYOR_NO in (11,12,44) order by SURVEYOR_NAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllSurveyors()
        {
            string sql = "SELECT SURVEYOR_NO, SURVEYOR_NAME, SURVEYOR_WORK_ENDDATE, SURVEYOR_WORK_STARTDATE, SURVEYOR_PHONE_NO, SUSPENDED, SUSPENDED_AR FROM VW_SURVEYORS where SURVEYOR_NAME is not null order by SURVEYOR_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllActiveSurveyors()
        {
            string sql = "SELECT SURVEYOR_NO, SURVEYOR_NAME, SURVEYOR_WORK_ENDDATE, SURVEYOR_WORK_STARTDATE, SURVEYOR_PHONE_NO, SUSPENDED, SUSPENDED_AR FROM VW_SURVEYORS where SURVEYOR_NAME is not null and SUSPENDED=0 order by SURVEYOR_NAME ";
            return db.ExecuteQuery(sql);
        }

        public static DataTable GetSurveyorByID(int ID)
        {
            if (ID == 0)
                return new DataTable();

            string sql = string.Format("SELECT SURVEYOR_NO, SURVEYOR_NAME, SURVEYOR_WORK_ENDDATE, SURVEYOR_WORK_STARTDATE, SURVEYOR_PHONE_NO, SUSPENDED, SUSPENDED_AR FROM VW_SURVEYORS where SURVEYOR_NO={0} order by SURVEYOR_NAME ", ID);
            return new OracleDatabaseClass().ExecuteQuery(sql);
        }

        public static string GetSurveyorNameByID(int ID)
        {
            if (ID == 0)
                return "";

            string sql = string.Format("select SURVEYOR_NAME from SURVEYORS where SURVEYOR_NO={0} ", ID);
            string surveyorName = new OracleDatabaseClass().ExecuteScalar(sql).ToString();
            return surveyorName;
        }


        public bool Insert(string SURVEYOR_NAME, DateTime? SURVEYOR_WORK_STARTDATE, DateTime? SURVEYOR_WORK_ENDDATE, string SURVEYOR_PHONE_NO, bool SUSPENDED)
        {
            SURVEYOR_NAME = SURVEYOR_NAME.Replace("'", "''");
            SURVEYOR_PHONE_NO = string.IsNullOrEmpty(SURVEYOR_PHONE_NO) ? "NULL" : string.Format("'{0}'", SURVEYOR_PHONE_NO.Replace("'", "''"));
            string workEndDate = (SURVEYOR_WORK_ENDDATE == null) ?
                (SUSPENDED ? string.Format("to_date('{0}', 'DD/MM/YYYY')", DateTime.Today.ToString("dd/MM/yyyy")) : "NULL") :
                string.Format("to_date('{0}', 'DD/MM/YYYY')", ((DateTime)SURVEYOR_WORK_ENDDATE).ToString("dd/MM/yyyy"));


            string sql = string.Format("INSERT INTO SURVEYORS (SURVEYOR_NO, SURVEYOR_NAME, SURVEYOR_WORK_STARTDATE, SURVEYOR_WORK_ENDDATE, SURVEYOR_PHONE_NO, SUSPENDED) " +
                " VALUES (SEQ_SURVEYORS.nextval, '{0}', to_date('{1}', 'DD/MM/YYYY'), {2}, {3}, {4}) ",
                 SURVEYOR_NAME, ((DateTime)SURVEYOR_WORK_STARTDATE).ToString("dd/MM/yyyy"), workEndDate, SURVEYOR_PHONE_NO, Shared.Bool2Int(SUSPENDED));

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool Update(string SURVEYOR_NAME, DateTime? SURVEYOR_WORK_STARTDATE, DateTime? SURVEYOR_WORK_ENDDATE, string SURVEYOR_PHONE_NO, int SURVEYOR_NO,
            bool SUSPENDED)
        {
            SURVEYOR_NAME = SURVEYOR_NAME.Replace("'", "''");
            SURVEYOR_PHONE_NO = string.IsNullOrEmpty(SURVEYOR_PHONE_NO) ? "NULL" : string.Format("'{0}'", SURVEYOR_PHONE_NO.Replace("'", "''"));

            //string workEndDate = (SURVEYOR_WORK_ENDDATE == null) ? "NULL" : string.Format("to_date('{0}', 'DD/MM/YYYY')", ((DateTime)SURVEYOR_WORK_ENDDATE).ToString("dd/MM/yyyy"));
            string workEndDate = (SURVEYOR_WORK_ENDDATE == null) ? 
                (SUSPENDED ? string.Format("to_date('{0}', 'DD/MM/YYYY')" , DateTime.Today.ToString("dd/MM/yyyy")) : "NULL") : 
                string.Format("to_date('{0}', 'DD/MM/YYYY')", ((DateTime)SURVEYOR_WORK_ENDDATE).ToString("dd/MM/yyyy"));


            string sql = string.Format("UPDATE SURVEYORS SET SURVEYOR_NAME='{0}', SURVEYOR_WORK_STARTDATE=to_date('{1}', 'DD/MM/YYYY'), SURVEYOR_WORK_ENDDATE={2}, " +
                " SURVEYOR_PHONE_NO={3}, SUSPENDED={5} WHERE SURVEYOR_NO={4} ",
                SURVEYOR_NAME, ((DateTime)SURVEYOR_WORK_STARTDATE).ToString("dd/MM/yyyy"), workEndDate, SURVEYOR_PHONE_NO, SURVEYOR_NO, Shared.Bool2Int(SUSPENDED));

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool Delete(int SURVEYOR_NO)
        {
            string sql = string.Format("delete from SURVEYORS WHERE SURVEYOR_NO={0} ", SURVEYOR_NO);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


    }
}
