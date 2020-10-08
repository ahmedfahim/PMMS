using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL.Lookups
{

    public class Projects
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();


        public DataTable GetProjectssList()
        {
            string sql = "select Projects_ID, Projects_NAME, Projects_NO from Projects order by Projects_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllProjectssList()
        {
            string sql = "select * from Projects order by Projects_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetProjectssInfo(string Projects_No)
        {
            if (string.IsNullOrEmpty(Projects_No))
                return new DataTable();

            string sql = string.Format("select * from Projects where Projects_No={0}", Projects_No);
            return db.ExecuteQuery(sql);
        }


        public bool Insert(string Projects_NAME, string Projects_NO)
        {
            Projects_NAME = Projects_NAME.Replace("'", "''");
           
            Projects_NO = string.IsNullOrEmpty(Projects_NO) ? "NULL" : string.Format("'{0}'", Projects_NO.Replace("'", "''"));

           
            string sql = string.Format("insert into Projects(Projects_NO, Projects_NAME,  Projects_ID) " +
                "values({0}, '{1}', SEQ_Projects.nextval) ", Projects_NO, Projects_NAME);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

      

        public bool Update(string Projects_NAME, string Projects_NO, int Projects_ID)
        {
            Projects_NAME = Projects_NAME.Replace("'", "''");
            Projects_NO = string.IsNullOrEmpty(Projects_NO) ? "NULL" : string.Format("'{0}'", Projects_NO.Replace("'", "''"));

            string sql = string.Format("update Projects set Projects_NO={0}, Projects_NAME='{1}' where Projects_ID={2} ",
                Projects_NO, Projects_NAME, Projects_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool Delete(string Projects_ID)
        {
            string sql = string.Format("delete from Projects where Projects_ID='{0}' ", Projects_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


    }
}
