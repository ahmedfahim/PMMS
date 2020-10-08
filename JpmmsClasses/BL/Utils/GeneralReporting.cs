using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;

namespace JpmmsClasses.BL.Utils
{
    public class GeneralPmmsReporting
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetIntersectionTypes()
        {
            string sql = "select * from INTERSECT_TYPES order by INTERSECT_TYPE ";
            return db.ExecuteQuery(sql);
        }

    }
}
