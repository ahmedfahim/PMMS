using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL.Lookups
{
    public class Contractor
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();


        public DataTable GetContractorsList()
        {
            string sql = "select CONTRACTOR_ID, CONTRACTOR_NAME, CONTRACTOR_NO from CONTRACTOR order by CONTRACTOR_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllContractorsList()
        {
            string sql = "select * from CONTRACTOR order by CONTRACTOR_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetContractorsInfo(int contractorID)
        {
            if (contractorID == 0)
                return new DataTable();

            string sql = string.Format("select * from CONTRACTOR where CONTRACTOR_ID={0}", contractorID);
            return db.ExecuteQuery(sql);
        }


        public bool Insert(string CONTRACTOR_NAME, string PHONE, string FAX, string MOBILE, string EMAIL, string CONTRACTOR_NO)
        {
            CONTRACTOR_NAME = CONTRACTOR_NAME.Replace("'", "''");
            PHONE = string.IsNullOrEmpty(PHONE) ? "NULL" : string.Format("'{0}'", PHONE.Replace("'", "''"));
            FAX = string.IsNullOrEmpty(FAX) ? "NULL" : string.Format("'{0}'", FAX.Replace("'", "''"));
            MOBILE = string.IsNullOrEmpty(MOBILE) ? "NULL" : string.Format("'{0}'", MOBILE.Replace("'", "''"));
            EMAIL = string.IsNullOrEmpty(EMAIL) ? "NULL" : string.Format("'{0}'", EMAIL.Replace("'", "''"));
            CONTRACTOR_NO = string.IsNullOrEmpty(CONTRACTOR_NO) ? "NULL" : string.Format("'{0}'", CONTRACTOR_NO.Replace("'", "''"));

            //                                                      0           1               2    3      4       5
            string sql = string.Format("insert into CONTRACTOR(CONTRACTOR_NO, CONTRACTOR_NAME, PHONE, FAX, MOBILE, EMAIL, CONTRACTOR_ID) " +
                "values({0}, '{1}', {2}, {3}, {4}, {5}, SEQ_CONTRACTOR.nextval) ", CONTRACTOR_NO, CONTRACTOR_NAME, PHONE, FAX, MOBILE, EMAIL);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public int InsertNewContractor(string CONTRACTOR_NAME, string PHONE, string FAX, string MOBILE, string EMAIL, string CONTRACTOR_NO)
        {
            CONTRACTOR_NAME = CONTRACTOR_NAME.Replace("'", "''");
            PHONE = string.IsNullOrEmpty(PHONE) ? "NULL" : string.Format("'{0}'", PHONE.Replace("'", "''"));
            FAX = string.IsNullOrEmpty(FAX) ? "NULL" : string.Format("'{0}'", FAX.Replace("'", "''"));
            MOBILE = string.IsNullOrEmpty(MOBILE) ? "NULL" : string.Format("'{0}'", MOBILE.Replace("'", "''"));
            EMAIL = string.IsNullOrEmpty(EMAIL) ? "NULL" : string.Format("'{0}'", EMAIL.Replace("'", "''"));
            CONTRACTOR_NO = string.IsNullOrEmpty(CONTRACTOR_NO) ? "NULL" : string.Format("'{0}'", CONTRACTOR_NO.Replace("'", "''"));

            //                                                      0           1               2    3      4       5
            string sql = string.Format("insert into CONTRACTOR(CONTRACTOR_NO, CONTRACTOR_NAME, PHONE, FAX, MOBILE, EMAIL, CONTRACTOR_ID) " +
                "values({0}, '{1}', {2}, {3}, {4}, {5}, SEQ_CONTRACTOR.nextval) ", CONTRACTOR_NO, CONTRACTOR_NAME, PHONE, FAX, MOBILE, EMAIL);

            return db.ExecuteInsertWithIDReturn(sql, "CONTRACTOR");
        }


        public bool Update(string CONTRACTOR_NAME, string PHONE, string FAX, string MOBILE, string EMAIL, string CONTRACTOR_NO, int CONTRACTOR_ID)
        {
            CONTRACTOR_NAME = CONTRACTOR_NAME.Replace("'", "''");
            PHONE = string.IsNullOrEmpty(PHONE) ? "NULL" : string.Format("'{0}'", PHONE.Replace("'", "''"));
            FAX = string.IsNullOrEmpty(FAX) ? "NULL" : string.Format("'{0}'", FAX.Replace("'", "''"));
            MOBILE = string.IsNullOrEmpty(MOBILE) ? "NULL" : string.Format("'{0}'", MOBILE.Replace("'", "''"));
            EMAIL = string.IsNullOrEmpty(EMAIL) ? "NULL" : string.Format("'{0}'", EMAIL.Replace("'", "''"));
            CONTRACTOR_NO = string.IsNullOrEmpty(CONTRACTOR_NO) ? "NULL" : string.Format("'{0}'", CONTRACTOR_NO.Replace("'", "''"));

            string sql = string.Format("update CONTRACTOR set CONTRACTOR_NO={0}, CONTRACTOR_NAME='{1}', PHONE={2}, FAX={3}, MOBILE={4}, EMAIL={5} where CONTRACTOR_ID={6} ",
                CONTRACTOR_NO, CONTRACTOR_NAME, PHONE, FAX, MOBILE, EMAIL, CONTRACTOR_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool Delete(string CONTRACTOR_ID)
        {
            string sql = string.Format("delete from CONTRACTOR where CONTRACTOR_ID='{0}' ", CONTRACTOR_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


    }
}
