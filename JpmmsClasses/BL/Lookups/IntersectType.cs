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
    public class IntersectType
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetAll()
        {
            string sql = "select INTERSECT_TYPE_ID, INTERSECT_TYPE from INTERSECT_TYPES order by INTERSECT_TYPE ";
            return db.ExecuteQuery(sql);
        }

        public byte[] LoadPhoto(int typeID)
        {
            if (typeID == 0)
                return null;

            string sql = string.Format("select TYPE_PHOTO from INTERSECT_TYPES where INTERSECT_TYPE_ID={0}  ", typeID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 1) ? (byte[])dt.Rows[0]["TYPE_PHOTO"] : null;
        }

    }
}
