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
    public class Distress
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public bool Insert(int DIST_CODE, string DISTRESS_AR_TYPE, string DISTRESS_EN_TYPE, bool DISTRESS_SEVERITY, double DISTRESS_DENSITY_L, double DISTRESS_DENSITY_M,
            double DISTRESS_DENSITY_H)
        {
            DISTRESS_AR_TYPE = string.IsNullOrEmpty(DISTRESS_AR_TYPE) ? "NULL" : string.Format("'{0}'", DISTRESS_AR_TYPE.Replace("'", "''"));
            DISTRESS_EN_TYPE = string.IsNullOrEmpty(DISTRESS_EN_TYPE) ? "NULL" : string.Format("'{0}'", DISTRESS_EN_TYPE.Replace("'", "''"));

            //                                                          0           1               2                   3                   4                   5               6
            string sql = string.Format("insert into  DISTRESS_CODE(DIST_CODE, DISTRESS_AR_TYPE, DISTRESS_EN_TYPE, DISTRESS_SEVERITY, DISTRESS_DENSITY_L, DISTRESS_DENSITY_M, DISTRESS_DENSITY_H) " +
                " values({0}, {1}, {2}, '{3}', {4}, {5}, {6}) ", DIST_CODE, DISTRESS_AR_TYPE, DISTRESS_EN_TYPE, Shared.Bool2YN(DISTRESS_SEVERITY), DISTRESS_DENSITY_L,
                DISTRESS_DENSITY_M, DISTRESS_DENSITY_H);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool Update(int DIST_CODE, string DISTRESS_AR_TYPE, string DISTRESS_EN_TYPE, bool DISTRESS_SEVERITY, double DISTRESS_DENSITY_L, double DISTRESS_DENSITY_M,
            double DISTRESS_DENSITY_H)
        {
            DISTRESS_AR_TYPE = string.IsNullOrEmpty(DISTRESS_AR_TYPE) ? "NULL" : string.Format("'{0}'", DISTRESS_AR_TYPE.Replace("'", "''"));
            DISTRESS_EN_TYPE = string.IsNullOrEmpty(DISTRESS_EN_TYPE) ? "NULL" : string.Format("'{0}'", DISTRESS_EN_TYPE.Replace("'", "''"));

            string sql = string.Format("update DISTRESS_CODE set DISTRESS_AR_TYPE={1}, DISTRESS_EN_TYPE={2}, DISTRESS_SEVERITY='{3}', DISTRESS_DENSITY_L={4}, DISTRESS_DENSITY_M={5}, DISTRESS_DENSITY_H={6} where DIST_CODE={0} ",
                DIST_CODE, DISTRESS_AR_TYPE, DISTRESS_EN_TYPE, Shared.Bool2YN(DISTRESS_SEVERITY), DISTRESS_DENSITY_L, DISTRESS_DENSITY_M, DISTRESS_DENSITY_H);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public DataTable GetAllDistresses()
        {
            string sql = "SELECT DIST_CODE, DISTRESS_AR_TYPE, (DIST_CODE ||'- ' || DISTRESS_AR_TYPE) as distress_title, DISTRESS_EN_TYPE, decode(DISTRESS_SEVERITY, 'Y', 'True', 'False') as DISTRESS_SEVERITY, DISTRESS_DENSITY_L, DISTRESS_DENSITY_M, DISTRESS_DENSITY_H FROM DISTRESS_CODE where DIST_CODE<>0 order by DIST_CODE ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllDistressesWithCleanOne()
        {
            string sql = "SELECT DIST_CODE, DISTRESS_AR_TYPE, (DIST_CODE ||'- ' || DISTRESS_AR_TYPE) as distress_title, DISTRESS_EN_TYPE, decode(DISTRESS_SEVERITY, 'Y', 'True', 'False') as DISTRESS_SEVERITY, DISTRESS_DENSITY_L, DISTRESS_DENSITY_M, DISTRESS_DENSITY_H FROM DISTRESS_CODE order by DIST_CODE ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllDistressesSecoundry()
        {
            string sql = "SELECT DIST_CODE, DISTRESS_AR_TYPE, (DIST_CODE ||'- ' || DISTRESS_AR_TYPE) as distress_title, DISTRESS_EN_TYPE, decode(DISTRESS_SEVERITY, 'Y', 'True', 'False') as DISTRESS_SEVERITY, DISTRESS_DENSITY_L, DISTRESS_DENSITY_M, DISTRESS_DENSITY_H FROM DISTRESS_CODE where DIST_CODE in (0,2,3,4,5,6,11) order by DIST_CODE ";
            return db.ExecuteQuery(sql);
        }
    }
}
