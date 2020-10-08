using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Lookups;

namespace JpmmsClasses.BL
{
    public class Feedbacks
    {
        public OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetAll()
        {
            string sql = "select * from VW_FEEDBACKS ";
            return db.ExecuteQuery(sql);
        }

        public bool Insert()
        {
            return false;
        }

        public bool Update()
        {
            return false;
        }

        public bool Delete()
        {
            return false;
        }

    }
}
