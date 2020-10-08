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
    public class Municpiality
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetAllMunic()
        {
            string sql = "select MUNIC_ID, MUNIC_NO, ARNAME, ENNAME, ARNAME as munic_name, (MUNIC_NO || ' ' || ARNAME) as munic_title from SUBMUNICIPALITY   order by MUNIC_NO  ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByID(int municID)
        {
            string sql = string.Format("select MUNIC_ID, MUNIC_NO, ARNAME, ENNAME, ARNAME as munic_name, (MUNIC_NO || ' ' || ARNAME) as munic_title from SUBMUNICIPALITY  where MUNIC_ID={0} ", municID);
            return db.ExecuteQuery(sql);
        }


        public bool Update(string MUNIC_NO, string ARNAME, string ENNAME, int MUNIC_ID)
        {
            if (MUNIC_ID == 0 || string.IsNullOrEmpty(MUNIC_NO) || string.IsNullOrEmpty(ARNAME))
                return false;

            MUNIC_NO = MUNIC_NO.Replace("'", "''");
            ARNAME = ARNAME.Replace("'", "''");
            ENNAME = ENNAME.Replace("'", "''");

            string sql = string.Format("update SUBMUNICIPALITY set MUNIC_NO='{0}', ARNAME='{1}', ENNAME='{2}' where MUNIC_ID={3} ", MUNIC_NO, ARNAME, ENNAME, MUNIC_ID);
            int rows = db.ExecuteNonQuery(sql);

            sql = string.Format("update DISTRICT set MUNIC_NAME='{0}', SUBMUNICIP={1} where MUNIC_ID={1} ", ARNAME, MUNIC_ID);
            rows += db.ExecuteNonQuery(sql);

            //sql = string.Format("update SUBDISTRICT set MUNIC_NAME='{0}' where SUBMUNICIP={1} ", ARNAME, MUNIC_ID);
            //rows += db.ExecuteNonQuery(sql);

            sql = string.Format("update REGIONS set MUNIC_NAME='{0}', SUBMUNICIP={1} where region_no like '{2}%' ", ARNAME, MUNIC_ID, MUNIC_NO);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("update SECTIONS set MUNICIPALITY='{0}' where SECTION_NO like '{1}%' ", ARNAME, MUNIC_NO);
            rows += db.ExecuteNonQuery(sql);
            return (rows > 0);
        }



        public DataTable GetMunicDetails(string munic)
        {
            string sql = string.Format("select MUNIC_NO, ARNAME, ARNAME as munic_name from SUBMUNICIPALITY where ARNAME='{0}' or MUNIC_NO='{0}'  ", munic);
            return db.ExecuteQuery(sql);
        }

        public string GetMunicNo(string munic)
        {
            string sql = string.Format("select MUNIC_NO, ARNAME, ARNAME as munic_name from SUBMUNICIPALITY where ARNAME='{0}'  ", munic);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 0 ? "" : dt.Rows[0]["MUNIC_NO"].ToString());
        }

        public DataTable GetAllMunicRegions(string munic)
        {
            string municPart = (munic == "0" || string.IsNullOrEmpty(munic)) ? "" : string.Format(" where munic_name='{0}' ", munic);

            string sql = string.Format("select region_id, SUBDISTRICT, region_no, (region_no || ' - ' || SUBDISTRICT) as region_title from REGIONS {0}  order by region_no ", municPart);
            return db.ExecuteQuery(sql);
        }


    }
}
