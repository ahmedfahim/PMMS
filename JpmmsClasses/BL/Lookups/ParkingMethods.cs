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
    public class ParkingMethods
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();


        public DataTable GetAll()
        {
            string sql = "select PARKING_METHOD_ID, PARKING_METHOD from PARKING_METHODS order by PARKING_METHOD ";
            return db.ExecuteQuery(sql);
        }

    }
}
