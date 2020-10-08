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
    public class Unit
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public bool Insert(string UNIT_NAME)
        {
            UNIT_NAME = UNIT_NAME.Replace("'", "''");
            string sql = string.Format("insert into  UNITS(UNIT_ID, UNIT_NAME) values(SEQ_UNITS.nextval, '{0}') ", UNIT_NAME);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(string UNIT_NAME, int UNIT_ID)
        {
            UNIT_NAME = UNIT_NAME.Replace("'", "''");
            string sql = string.Format("update UNITS set UNIT_NAME='{0}' where UNIT_ID={1} ", UNIT_NAME, UNIT_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Delete(int UNIT_ID)
        {
            string sql = string.Format("delete from UNITS where UNIT_ID={0} ", UNIT_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable GetAll()
        {
            string sql = "select UNIT_ID, UNIT_NAME from units order by UNIT_NAME";
            return db.ExecuteQuery(sql);
        }


    }
}
