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
    public class IntersectControlType
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();


        public DataTable GetAll()
        {
            string sql = "select INTERSECT_CTRL_TYPE_ID, INTERSECT_CTRL_TYPE from INTERSECT_CTRL_TYPES order by INTERSECT_CTRL_TYPE ";
            return db.ExecuteQuery(sql);
        }

    }
}
