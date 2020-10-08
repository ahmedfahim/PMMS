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
    public class SubMuniciplaity
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetAll()
        {
            string sql = "select MUNIC_ID, ARNAME, MUNIC_NO, (MUNIC_NO || ' ' || ARNAME) as munic_title  from SUBMUNICIPALITY order by MUNIC_NO ";
            return db.ExecuteQuery(sql);
        }


    }
}
