using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;

namespace JpmmsClasses.BL.Lookups
{
    public class DistrictSubdistrict
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetSubDistFullInfo(int DIST_ID)
        {
            string sql = string.Format("select ARNAME, ENNAME, DISTRICTNO, nvl(SUBMUNICIP, 0) as SUBMUNICIP, SUBDISTRIC,DISTRICTNO  from SUBDISTRICT where DISTRICTNO={0} ", DIST_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetDistrictFullInfo(int MUNIC_ID)
        {
            string sql = string.Format("select DIST_ID, ARNAME, ENNAME, DIST_NO, nvl(MUNIC_ID, 0) as MUNIC_ID, MUNIC_NAME  from DISTRICT where MUNIC_ID={0} ", MUNIC_ID);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetAllSubdistricts()
        {
            string sql = "select ARNAME, ENNAME, DISTRICTNO, nvl(SUBMUNICIP, 0) as SUBMUNICIP, SUBDISTRIC,ID1  from SUBDISTRICT order by ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllDistricts()
        {
            string sql = "select DIST_ID, ARNAME, ENNAME, DIST_NO, nvl(MUNIC_ID, 0) as MUNIC_ID, MUNIC_NAME from DISTRICT  order by ARNAME ";
            return db.ExecuteQuery(sql);
        }



        public bool UpdateSubdistrict(string ARNAME, string ENNAME, int DISTRICTNO, int? SUBDISTRIC, int ID1)
        {
            if (ID1 == 0 || DISTRICTNO == 0 || string.IsNullOrEmpty(ARNAME))       //|| SUBDISTRIC == null
                return false;

            ARNAME = ARNAME.Replace("'", "''");
            ENNAME = ENNAME.Replace("'", "''");
            string SUBDISTRIC_part = (SUBDISTRIC == null) ? "NULL" : SUBDISTRIC.ToString();

            DataTable dt = GetDistrictFullInfo(DISTRICTNO);
            if (dt.Rows.Count == 0)
                return false;

            DataRow dr = dt.Rows[0];
            string sql = string.Format("update SUBDISTRICT set ARNAME='{0}', ENNAME='{1}', DISTRICTNO={2}, SUBDISTRIC={3}, SUBMUNICIP={4} where ID1={5} ",
                 ARNAME, ENNAME, DISTRICTNO, SUBDISTRIC_part, dr["MUNIC_ID"].ToString(), ID1);

            int rows = db.ExecuteNonQuery(sql);

            sql = string.Format("update regions set ARNAME='{1}', SUBDISTRICT='{1}', ENNAME='{2}', SUBDISTRIC={3} where SUBDISTRICT_ID={0} ", ID1, ARNAME, ENNAME, SUBDISTRIC_part);
            rows += db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool UpdateDistrict(string ARNAME, string ENNAME, string DIST_NO, int MUNIC_ID, int DIST_ID)
        {
            if (DIST_ID == 0 || MUNIC_ID == 0 || string.IsNullOrEmpty(ARNAME) || string.IsNullOrEmpty(DIST_NO))
                return false;

            ARNAME = ARNAME.Replace("'", "''");
            ENNAME = ENNAME.Replace("'", "''");
            DIST_NO = DIST_NO.Replace("'", "''");

            DataTable dtMunic = new Municpiality().GetByID(MUNIC_ID);
            if (dtMunic.Rows.Count == 0)
                return false;

            DataRow dr = dtMunic.Rows[0];
            string sql = string.Format("update DISTRICT set ARNAME='{0}', ENNAME='{1}', DIST_NO='{2}', MUNIC_ID={3}, MUNIC_NAME='{4}' where DIST_ID={5}",
                ARNAME, ENNAME, DIST_NO, MUNIC_ID, dr["ARNAME"].ToString(), DIST_ID);

            int rows = db.ExecuteNonQuery(sql);

            sql = string.Format("update REGIONS set DIST_NAME='{0}', DIST_NO='{1}', DISTRICTNO={2}, DISTRICT_ID={2}  where region_no like '{1}%' ", ARNAME, DIST_NO, DIST_ID);
            rows += db.ExecuteNonQuery(sql);

            return (rows > 0);
        }

    }
}
