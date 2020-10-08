using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using JpmmsClasses.BL.DistressEntry;
using System.Diagnostics;
using System.Web;

namespace JpmmsClasses.BL.UDI
{
    public class RegionSecondaryStUDI
    {
        //private int recordsAffected = 0;

        private OracleDatabaseClass db = new OracleDatabaseClass();
        private Dates hijri = new Dates();
        private DistressShared shared = new DistressShared();
        private DistressSurvey distSurvey = new DistressSurvey();
        private UdiRecord udi = new UdiRecord();



        #region UDI Calculations

        public bool CalculateRegionSecondaryStreetsUDI(int regionID, string user, bool wholeNetwork)
        {
            bool result = true;
            DataTable dt;
            if (wholeNetwork)
                dt = distSurvey.GetRegionsAndMainStreetSectionIntersections(regionID, "", "", "", true, false, false, false, 0, false, false);
            else
                dt = distSurvey.GetLastSurveyForRoadsNetwork(regionID, "", "", "", true, false, false, false, 0, false, false);

            foreach (DataRow dr in dt.Rows)
                result &= CalculateRegionSecondaryStreetsUDI(regionID, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }


        public bool CalculateRegionSecondaryStreetsUDI(int regionID, int surveyNo, string user)
        {
            RemovePreviousCalculations(regionID, surveyNo);

            int rows = 0;
            decimal DEDUCT_DEN_RAT = 0;
            DataTable dtSampleDistresses; //, dtExists;
            DataRow drDist;
            //string maxSurveyDate = ""; , dtSurveyDate
            // decimal de_valu = 0;         SECOND_ID

            string sql = string.Format("SELECT REGION_NO, SUBDISTRICT, DIST_NAME, MUNIC_NAME, SECOND_ST_NO, STREET_ID, REGION_ID, SECOND_ST_LENGTH, SECOND_ST_WIDTH, " +
                " round((SECOND_ST_LENGTH*SECOND_ST_WIDTH), 2) as SECONDARY_AREA  FROM GV_SEC_STREET WHERE REGION_ID={0}  and SECOND_ST_LENGTH<>0 and SECOND_ST_WIDTH<>0 " +
                " order by lpad(SECOND_ST_NO,10) ", regionID);

            Shared.LogStatment(sql);
            DataTable dtRegionSecStreets = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionSecStreets.Rows)
            {
                udi = new UdiRecord();

                sql = string.Format("SELECT STREET_ID, SECOND_ST_NO, SURVEY_NO, region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, " +  // SECOND_ID
                    " to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, SUM(DEDUCT_DEN_DASH) DEDUCT_DEN_RAT, SUM(DIST_DENSITY) DEN, " +
                    " MAX(DEDUCT_VALUE) DE_VALUE, MAX(DEN_DASH) DEN_D, MAX(DIST_CODE) DIS_CODE  " +
                    " FROM GV_SEC_ST_DISTRESS  WHERE STREET_ID={0}  AND SURVEY_NO={1}  " +      // SECOND_ID
                    " GROUP BY STREET_ID, SECOND_ST_NO, SURVEY_NO, region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME  ",
                    dr["STREET_ID"].ToString(), surveyNo);

                Shared.LogStatment(sql);
                dtSampleDistresses = db.ExecuteQuery(sql);
                if (dtSampleDistresses.Rows.Count == 0)
                    continue;

                #region UDI For Each Secondary Street for all distresses

                drDist = dtSampleDistresses.Rows[0];
                DEDUCT_DEN_RAT = decimal.Parse(drDist["DEDUCT_DEN_RAT"].ToString());
                if (DEDUCT_DEN_RAT >= 0 && DEDUCT_DEN_RAT <= 5)
                    udi = UdiShared.GetUDI(DEDUCT_DEN_RAT);
                else if (DEDUCT_DEN_RAT > 5)
                    udi = UdiShared.GetUDI(decimal.Parse(drDist["DE_VALUE"].ToString()));

                if (udi.udiValue == -1)
                    continue;


                //sql = string.Format("SELECT REGION_NO, SECONDARY_NO, SURVEY_NO FROM UDI_SECONDARY  WHERE STREET_ID={0} AND SURVEY_NO={1} ", dr["STREET_ID"].ToString(), surveyNo);
                //dtExists = db.ExecuteQuery(sql);
                //if (dtExists.Rows.Count == 1)
                //{
                //    sql = string.Format("update UDI_SECONDARY set SURVEY_DATE=TO_DATE('{0}','DD/MM/YYYY'), SECONDARY_NO='{1}', SECONDARY_LENGTH={2}, SECONDARY_WIDTH={3}, " +
                //        " SECONDARY_AREA={4}, UDI_DATE=(select sysdate from dual), UDI_VALUE={5}, UDI_RATE='{6}', SUBDISTRICT='{7}', DIST_NAME='{8}', MUNIC_NAME='{9}' " +
                //        " where STREET_ID={10} and SURVEY_NO={11} ",    // SECOND_ID
                //        drDist["MAX_SURVEY_DATE"].ToString(), dr["SECOND_ST_NO"].ToString(), dr["SECOND_ST_LENGTH"].ToString(), dr["SECOND_ST_WIDTH"].ToString(),
                //        dr["SECONDARY_AREA"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, dr["SUBDISTRICT"].ToString(),
                //        dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString(), dr["STREET_ID"].ToString(), surveyNo);

                //    Shared.LogStatment(sql);
                //    rows += db.ExecuteNonQuery(sql);
                //}
                //else
                //{
                //    if (dtExists.Rows.Count > 1)
                //    {
                //        sql = string.Format("DELETE FROM UDI_SECONDARY WHERE STREET_ID={0} AND SURVEY_NO={1} ", dr["STREET_ID"].ToString(), surveyNo);
                //        Shared.LogStatment(sql);
                //        db.ExecuteNonQuery(sql);
                //    }

                // ready to insert secondary street UDI
                sql = string.Format("INSERT INTO UDI_SECONDARY(REGION_NO, SURVEY_DATE, SECONDARY_NO, SECONDARY_LENGTH, SECONDARY_WIDTH, SECONDARY_AREA, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, SUBDISTRICT, RECORD_ID, REGION_ID, STREET_ID, DIST_NAME, MUNIC_NAME) " +
                " VALUES('{0}', TO_DATE('{1}','DD/MM/YYYY'), '{2}', {3}, " + 
                " {4}, {5}, (select sysdate from dual), {6}, '{7}', {8}, '{9}', SEQ_UDI_SECONDARY.nextval, " + 
                " {10}, {11}, '{12}', '{13}') ",
                dr["Region_no"].ToString(), drDist["MAX_SURVEY_DATE"].ToString(), dr["SECOND_ST_NO"].ToString(), dr["SECOND_ST_LENGTH"].ToString(),
                dr["SECOND_ST_WIDTH"].ToString(), dr["SECONDARY_AREA"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, dr["SUBDISTRICT"].ToString(),
                regionID, dr["STREET_ID"].ToString(), dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString()); //  SECOND_ID

                Shared.LogStatment(sql);
                rows += db.ExecuteNonQuery(sql);
                //}
                #endregion

                #region UDI For Each Secondary Street for patching distresses

                sql = string.Format("SELECT STREET_ID, SECOND_ST_NO, SURVEY_NO, region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, " +
                 " to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, SUM(DEDUCT_DEN_DASH) DEDUCT_DEN_RAT, SUM(DIST_DENSITY) DEN, " +
                 " MAX(DEDUCT_VALUE) DE_VALUE, MAX(DEN_DASH) DEN_D, MAX(DIST_CODE) DIS_CODE  " +
                 " FROM GV_SEC_ST_DISTRESS  WHERE STREET_ID={0}  AND SURVEY_NO={1} and DIST_CODE in (12, 13, 14, 15)  " +   //SECOND_ID
                 " GROUP BY STREET_ID, SECOND_ST_NO, SURVEY_NO, region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME  ",
                 dr["STREET_ID"].ToString(), surveyNo);

                Shared.LogStatment(sql);
                dtSampleDistresses = db.ExecuteQuery(sql);
                if (dtSampleDistresses.Rows.Count == 0)
                {
                    //continue;
                    double sampleArea = double.Parse(dr["SECONDARY_AREA"].ToString());
                    udi = UdiShared.GetUDI(0);
                }
                else
                {
                    drDist = dtSampleDistresses.Rows[0];

                    DEDUCT_DEN_RAT = decimal.Parse(drDist["DEDUCT_DEN_RAT"].ToString());
                    if (DEDUCT_DEN_RAT >= 0 && DEDUCT_DEN_RAT <= 5)
                        udi = UdiShared.GetUDI(DEDUCT_DEN_RAT);
                    else if (DEDUCT_DEN_RAT > 5)
                        udi = UdiShared.GetUDI(decimal.Parse(drDist["DE_VALUE"].ToString()));
                }


                if (udi.udiValue == -1)
                    continue;

                //sql = string.Format("SELECT REGION_NO, SECONDARY_NO, SURVEY_NO FROM UDI_SECONDARY_PATCHING  WHERE STREET_ID={0} AND SURVEY_NO={1} ", dr["STREET_ID"].ToString(), surveyNo);
                //dtExists = db.ExecuteQuery(sql);    //SECOND_ID
                //if (dtExists.Rows.Count == 1)
                //{
                //    // update
                //    sql = string.Format("update UDI_SECONDARY_PATCHING set SURVEY_DATE=TO_DATE('{0}','DD/MM/YYYY'), SECONDARY_NO='{1}', SECONDARY_LENGTH={2}, SECONDARY_WIDTH={3}, " +
                //   " SECONDARY_AREA={4}, UDI_DATE=(select sysdate from dual), UDI_VALUE={5}, UDI_RATE='{6}', SUBDISTRICT='{7}', DIST_NAME='{8}', MUNIC_NAME='{9}' " +
                //   " where STREET_ID={10} and SURVEY_NO={11} ",
                //   drDist["MAX_SURVEY_DATE"].ToString(), dr["SECOND_ST_NO"].ToString(), dr["SECOND_ST_LENGTH"].ToString(), dr["SECOND_ST_WIDTH"].ToString(),
                //   dr["SECONDARY_AREA"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, dr["SUBDISTRICT"].ToString(),
                //   dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString(), dr["STREET_ID"].ToString(), surveyNo);

                //    Shared.LogStatment(sql);
                //    rows += db.ExecuteNonQuery(sql);
                //}
                //else
                //{
                //    if (dtExists.Rows.Count > 1)
                //    {
                //        sql = string.Format("DELETE FROM UDI_SECONDARY_PATCHING WHERE STREET_ID={0} AND SURVEY_NO={1} ", dr["STREET_ID"].ToString(), surveyNo);
                //        Shared.LogStatment(sql);
                //        db.ExecuteNonQuery(sql);
                //    }

                // ready to insert secondary street UDI
                sql = string.Format("INSERT INTO UDI_SECONDARY_PATCHING (REGION_NO, SURVEY_DATE, SECONDARY_NO, SECONDARY_LENGTH, SECONDARY_WIDTH, SECONDARY_AREA, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, SUBDISTRICT, RECORD_ID, REGION_ID, STREET_ID, DIST_NAME, MUNIC_NAME) " +
               " VALUES('{0}', TO_DATE('{1}','DD/MM/YYYY'), '{2}', {3}, {4}, " + 
               " {5}, (select sysdate from dual), {6}, '{7}', {8}, '{9}', SEQ_UDI_SECONDARY.nextval, {10}, {11}, " + 
               " '{12}', '{13}') ",
                dr["Region_no"].ToString(), drDist["MAX_SURVEY_DATE"].ToString(), dr["SECOND_ST_NO"].ToString(), dr["SECOND_ST_LENGTH"].ToString(), dr["SECOND_ST_WIDTH"].ToString(),
                dr["SECONDARY_AREA"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, dr["SUBDISTRICT"].ToString(), regionID, dr["STREET_ID"].ToString(),
                dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString());

                Shared.LogStatment(sql);
                rows += db.ExecuteNonQuery(sql);
                //}
                //}

                #endregion

            }


            rows += CalculateRegionUDI(regionID, surveyNo);
            Shared.SaveLogfile("UDI", dtRegionSecStreets.Rows.Count.ToString(), "UDI Calculation - Region ID:" + regionID.ToString(), user);
            return (rows > 0);
        }

        public int CalculateRegionUDI(int regionID, int surveyNo)
        {
            int rows = 0;
            //DataTable dtExists;
            udi = new UdiRecord();

            # region For all distresses

            string sql = string.Format("SELECT REGION_NO, SUBDISTRICT, DIST_NAME, MUNIC_NAME, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                " count(SECONDARY_NO) AS NO_OF_SECONDARY, SUM(SECONDARY_AREA) AS REGION_AREA, ROUND(sum(udi_value*SECONDARY_AREA)/sum(SECONDARY_AREA))  AS udivalue, to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') AS udidate " +
                " FROM UDI_SECONDARY WHERE REGION_ID={0} and SURVEY_NO={1} GROUP BY REGION_NO, SUBDISTRICT, DIST_NAME, MUNIC_NAME ",
                regionID, surveyNo);

            Shared.LogStatment(sql);
            DataTable dtRegion = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegion.Rows)
            {
                udi = UdiShared.GetUDIRatio(decimal.Parse(dr["udivalue"].ToString()));

                //sql = string.Format("SELECT REGION_NO FROM UDI_REGION WHERE REGION_ID={0} And SURVEY_NO={1} ", regionID, surveyNo);
                //dtExists = db.ExecuteQuery(sql);
                //if (dtExists.Rows.Count == 1)
                //{
                //    sql = string.Format("update UDI_REGION set SURVEY_DATE=TO_DATE('{0}','DD/MM/YYYY'), NO_OF_SECONDARY={1}, REGION_AREA={2}, UDI_DATE=to_date('{3}','DD/MM/YYYY'), " +
                //        " UDI_VALUE={4}, UDI_RATE='{5}', SUBDISTRICT='{6}', DIST_NAME='{7}', MUNIC_NAME='{8}' where REGION_ID={9} and SURVEY_NO={10} ",
                //        dr["MAX_SURVEY_DATE"].ToString(), dr["NO_OF_SECONDARY"].ToString(), dr["REGION_AREA"].ToString(), dr["udidate"].ToString(),
                //        udi.udiValue.ToString("N0"), udi.udiRate, dr["SUBDISTRICT"].ToString(), dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString(), regionID, surveyNo);

                //    Shared.LogStatment(sql);
                //    rows += db.ExecuteNonQuery(sql);
                //}
                //else
                //{
                //    if (dtExists.Rows.Count > 1)
                //    {
                //        // delete
                //        sql = string.Format("DELETE FROM UDI_REGION WHERE REGION_ID={0} AND SURVEY_NO={1} ", regionID, surveyNo);
                //        Shared.LogStatment(sql);
                //        db.ExecuteNonQuery(sql);
                //    }


                sql = string.Format("INSERT INTO UDI_REGION(SURVEY_DATE, REGION_NO, NO_OF_SECONDARY, REGION_AREA, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, SUBDISTRICT, RECORD_ID, REGION_ID, DIST_NAME, MUNIC_NAME) " +
                    " VALUES(TO_DATE('{0}','DD/MM/YYYY'), '{1}', {2}, {3}, to_date('{4}','DD/MM/YYYY'), " +
                    " {5}, '{6}', {7}, '{8}', SEQ_UDI_REGION.nextval, {9}, '{10}', '{11}') ",
                    dr["MAX_SURVEY_DATE"].ToString(), dr["REGION_NO"].ToString(), dr["NO_OF_SECONDARY"].ToString(), dr["REGION_AREA"].ToString(), dr["udidate"].ToString(),
                    udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, dr["SUBDISTRICT"].ToString(), regionID, dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString());

                Shared.LogStatment(sql);
                rows += db.ExecuteNonQuery(sql);
                //}
            }

            #endregion

            # region Patching distresses

            sql = string.Format("SELECT REGION_NO, SUBDISTRICT, DIST_NAME, MUNIC_NAME, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
               " count(SECONDARY_NO) AS NO_OF_SECONDARY, SUM(SECONDARY_AREA) AS REGION_AREA, ROUND(AVG(udi_value)) AS udivalue, to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') AS udidate " +
               " FROM UDI_SECONDARY_PATCHING WHERE REGION_ID={0} and SURVEY_NO={1} GROUP BY REGION_NO, SUBDISTRICT, DIST_NAME, MUNIC_NAME ",
               regionID, surveyNo);

            Shared.LogStatment(sql);
            dtRegion = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegion.Rows)
            {
                udi = UdiShared.GetUDIRatio(decimal.Parse(dr["udivalue"].ToString()));

                //sql = string.Format("SELECT REGION_NO FROM UDI_REGION_PATCHING WHERE REGION_ID={0} And SURVEY_NO={1} ", regionID, surveyNo);
                //dtExists = db.ExecuteQuery(sql);
                //if (dtExists.Rows.Count == 1)
                //{
                //    sql = string.Format("update UDI_REGION_PATCHING set SURVEY_DATE=TO_DATE('{0}','DD/MM/YYYY'), NO_OF_SECONDARY={1}, REGION_AREA={2}, UDI_DATE=to_date('{3}','DD/MM/YYYY'), " +
                //       " UDI_VALUE={4}, UDI_RATE='{5}', SUBDISTRICT='{6}', DIST_NAME='{7}', MUNIC_NAME='{8}' where REGION_ID={9} and SURVEY_NO={10} ",
                //       dr["MAX_SURVEY_DATE"].ToString(), dr["NO_OF_SECONDARY"].ToString(), dr["REGION_AREA"].ToString(), dr["udidate"].ToString(),
                //       udi.udiValue.ToString("N0"), udi.udiRate, dr["SUBDISTRICT"].ToString(), dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString(), regionID, surveyNo);

                //    Shared.LogStatment(sql);
                //    rows += db.ExecuteNonQuery(sql);
                //}
                //else
                //{
                //    if (dtExists.Rows.Count > 1)
                //    {
                //        // delete
                //        sql = string.Format("DELETE FROM UDI_REGION_PATCHING WHERE REGION_ID={0} AND SURVEY_NO={1} ", regionID, surveyNo);
                //        Shared.LogStatment(sql);
                //        db.ExecuteNonQuery(sql);
                //    }


                sql = string.Format("INSERT INTO UDI_REGION_PATCHING(SURVEY_DATE, REGION_NO, NO_OF_SECONDARY, REGION_AREA, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, SUBDISTRICT, RECORD_ID, REGION_ID, DIST_NAME, MUNIC_NAME) " +
                    " VALUES(TO_DATE('{0}','DD/MM/YYYY'), '{1}', {2}, {3}, to_date('{4}','DD/MM/YYYY'), " + 
                    " {5}, '{6}', {7}, '{8}', SEQ_UDI_REGION.nextval, {9}, '{10}', '{11}') ",
                    dr["MAX_SURVEY_DATE"].ToString(), dr["REGION_NO"].ToString(), dr["NO_OF_SECONDARY"].ToString(), dr["REGION_AREA"].ToString(), dr["udidate"].ToString(),
                    udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, dr["SUBDISTRICT"].ToString(), regionID, dr["DIST_NAME"].ToString(), dr["MUNIC_NAME"].ToString());

                Shared.LogStatment(sql);
                rows += db.ExecuteNonQuery(sql);
                //}
            }

            #endregion

            return rows;
        }


        private void RemovePreviousCalculations(int regionID, int surveyNo)
        {
            string sql = string.Format("delete from UDI_SECONDARY where REGION_ID={0} and SURVEY_NO={1} ", regionID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_REGION where REGION_ID={0} and SURVEY_NO={1} ", regionID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_SECONDARY_PATCHING where REGION_ID={0} and SURVEY_NO={1} ", regionID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_REGION_PATCHING where REGION_ID={0} and SURVEY_NO={1} ", regionID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);
        }


        private void TruncateUdiTables()
        {
            string sql = "truncate table UDI_SECONDARY ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_REGION ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_SECONDARY_PATCHING ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_REGION_PATCHING ";
            db.ExecuteNonQuery(sql);
        }

        #endregion


        #region BySubdistrict

        public bool CalculateRegionSecondaryStreetsUDI_BySubdistrict(string subdistrict, string user)
        {
            bool result = true;
            DataTable dt = new DistressSurvey().GetRegionsAndMainStreetSectionIntersections(0, subdistrict, "", "", false, true, false, false, 0, false, false);
            foreach (DataRow dr in dt.Rows)
                result &= CalculateRegionSecondaryStreetsUDI_BySubdistrict(subdistrict, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        public bool CalculateRegionSecondaryStreetsUDI_BySubdistrict(string subdistrict, int surveyNo, string user)
        {
            bool result = true;
            string sql = string.Format("select REGION_ID from regions where SUBDISTRICT='{0}' ", subdistrict);
            DataTable dtRegionsSubDistrict = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionsSubDistrict.Rows)
                result &= CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), surveyNo, user);

            return result;
        }

        #endregion

        #region ByDistrictName

        public bool CalculateRegionSecondaryStreetsUDI_ByDistrict(string district, string user)
        {
            bool result = true;
            DataTable dt = new DistressSurvey().GetRegionsAndMainStreetSectionIntersections(0, "", district, "", false, false, true, false, 0, false, false);
            foreach (DataRow dr in dt.Rows)
                result &= CalculateRegionSecondaryStreetsUDI_ByDistrict(district, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        public bool CalculateRegionSecondaryStreetsUDI_ByDistrict(string district, int surveyNo, string user)
        {
            bool result = true;
            string sql = string.Format("select REGION_ID from regions where DIST_NAME='{0}' ", district);
            DataTable dtRegionsSubDistrict = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionsSubDistrict.Rows)
                result &= CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), surveyNo, user);

            return result;
        }

        #endregion

        #region ByMunicipality

        public bool CalculateRegionSecondaryStreetsUDI_ByMunicipality(string municName, string user)
        {
            bool result = true;
            DataTable dt = new DistressSurvey().GetRegionsAndMainStreetSectionIntersections(0, "", "", municName, false, false, false, true, 0, false, false);
            foreach (DataRow dr in dt.Rows)
                result &= CalculateRegionSecondaryStreetsUDI_ByMunicipality(municName, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        public bool CalculateRegionSecondaryStreetsUDI_ByMunicipality(string municName, int surveyNo, string user)
        {
            bool result = true;
            string sql = string.Format("select REGION_ID from regions where MUNIC_NAME='{0}' ", municName);
            DataTable dtRegionsSubDistrict = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionsSubDistrict.Rows)
                result &= CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), surveyNo, user);

            return result;
        }

        #endregion


        #region Search and Reporting

        public DataTable GetSecondaryStreetsUdiByRegion(int regionID, int surveyNo)
        {
            if (regionID == 0)
                return new DataTable();

            string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" SURVEY_NO={0} ", surveyNo);
            string and = (regionID != 0 && surveyNo != 0) ? " and " : " ";
            string regionIDPart = (regionID == 0) ? "" : string.Format(" REGION_ID={0} ", regionID);
            string sql = string.Format("SELECT * FROM UDI_SECONDARY where {0} {1} {2}  order by lpad(SECONDARY_NO ,10) ", regionIDPart, and, surveyNumPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSecondaryStreetsUdiByRegion(string subdistrictName, int surveyNo)
        {
            if (string.IsNullOrEmpty(subdistrictName))
                return new DataTable();

            string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and SURVEY_NO={0} ", surveyNo);
            string sql = string.Format("SELECT * FROM UDI_SECONDARY where REGION_ID IN (select region_id from regions where SUBDISTRICT='{0}') {1}  order by SUBDISTRICT, region_no, lpad(SECONDARY_NO ,10) ", subdistrictName, surveyNumPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSecondaryStreetsUdiByDistrict(string districtName, int surveyNo)
        {
            if (string.IsNullOrEmpty(districtName))
                return new DataTable();

            string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and SURVEY_NO={0} ", surveyNo);
            string sql = string.Format("SELECT * FROM UDI_SECONDARY where REGION_ID IN (select region_id from regions where DIST_NAME='{0}') {1}  order by SUBDISTRICT, region_no, lpad(SECONDARY_NO ,10) ", districtName, surveyNumPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSecondaryStreetsUdiByMuniciplaity(string municName, int surveyNo)
        {
            if (string.IsNullOrEmpty(municName))
                return new DataTable();

            string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and SURVEY_NO={0} ", surveyNo);
            string sql = string.Format("SELECT * FROM UDI_SECONDARY where REGION_ID IN (select region_id from regions where MUNIC_NAME='{0}') {1}  order by SUBDISTRICT, region_no, lpad(SECONDARY_NO ,10) ", municName, surveyNumPart);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataBySpecificDateWithErorrs(DateTime? From, DateTime? TO)
        {
            //if (From == null || TO == null)
            //    return null;
            //else if (From > TO)
            //    throw new Exception(Feedback.SearchBeginDateAfterEndDate());
            //else
            //{
 
            //}
            string sql = string.Format(@"SELECT d.dist_code,
          d.dist_severity,
          d.dist_area,
          dc.distress_ar_type,
          su.munic_name,
          su.subdistrict,
          su.dist_name,
          su.region_no,
          su.region_id,
          su.district_id,
          su.second_st_no,
          su.second_arname,
          su.second_arname AS second_ar_name,
          su.second_st_length,
          su.second_st_width,
          su.survey_date,
          su.survey_no,
          su.udi_date,
          su.udi_value,
          su.udi_rate,
          su.notes,
          su.street_id
          FROM distress d, distress_code dc, gv_sec_st_udi su
          WHERE d.street_id = su.street_id AND d.dist_code = dc.dist_code AND su.survey_no=3 and d.ENTRY_DATE  between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY') "
                , ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataBySpecificDate(string MonthYear)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return null;
//            DateTime From, TO;
//            new JpmmsClasses.BL.Lookups.SystemUsers().GetMonthlyDate(Monthes, out From, out TO);
//            string sql = string.Format(@"
//            SELECT MUNIC_NAME,
//            DIST_NAME,
//            SUBDISTRICT,
//            REGION_NO,
//            REGION_ID,
//            null DIRT_LENGTH ,
//            SECOND_ST_NO,
//            SECOND_ARNAME,
//            SECOND_AR_NAME,
//            SECOND_ST_LENGTH,
//            SECOND_ST_WIDTH,
//            SURVEY_DATE,
//            UDI_DATE,
//            UDI_VALUE,
//            UDI_RATE,
//            SURVEY_NO,
//            --r.DISTRICT_ID,
//            NOTES,
//            street_id,
//            SECONDARY_AREA FROM VW_LATEST_UDI_SECONDARY where SURVEY_NO>2 and REGION_ID in (
//            select d.REGION_ID from GV_SEC_ST_DISTRESS d where SURVEY_NO>2 and survey_date  between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY') 
//            group by d.region_no, subdistrict, survey_no, region_id ) ORDER BY region_no, SECOND_ST_NO ", ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"));
            string sql = string.Format(@"SELECT MUNIC_NAME,
            DIST_NAME,
            SUBDISTRICT,
            REGION_NO,
            REGION_ID,
            null DIRT_LENGTH ,
            SECOND_ST_NO,
            SECOND_ARNAME,
            SECOND_AR_NAME,
            SECOND_ST_LENGTH,
            SECOND_ST_WIDTH,
            SURVEY_DATE,
            UDI_DATE,
            UDI_VALUE,
            UDI_RATE,
            SURVEY_NO,
            NOTES,
            street_id,
            SECONDARY_AREA FROM VW_LATEST_UDI_SECONDARY where (SURVEY_NO>2 or SURVEY_NO is null ) and REGION_ID in (
            select d.REGION_ID from GV_SEC_ST_DISTRESS d where SURVEY_NO>2 and REGION_ID in (select REGION_ID from REPORTSQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}')
            group by d.region_no, subdistrict, survey_no, region_id ) ORDER BY region_no, SECOND_ST_NO ", SplitMonthYear[0], SplitMonthYear[1]);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataBySpecificDate(DateTime? from, DateTime? to)
        {
            if (from == null || to == null) //|| survey == 0)
                return new DataTable();

            string sql = string.Format(
                @"SELECT MUNIC_NAME,
            DIST_NAME,
            SUBDISTRICT,
            REGION_NO,
            REGION_ID,
            null DIRT_LENGTH ,
            SECOND_ST_NO,
            SECOND_ARNAME,
            SECOND_AR_NAME,
            SECOND_ST_LENGTH,
            SECOND_ST_WIDTH,
            SURVEY_DATE,
            UDI_DATE,
            UDI_VALUE,
            UDI_RATE,
            SURVEY_NO,
            NOTES,
            street_id,
            SECONDARY_AREA FROM jpmms.VW_LATEST_UDI_SECONDARY where (SURVEY_NO>2 or SURVEY_NO is null ) 
           and REGION_ID in (select distinct d.REGION_ID from jpmms.GV_SEC_ST_DISTRESS d where SURVEY_NO>2) 
           and SURVEY_DATE BETWEEN TO_DATE('{0}','DD/MM/YYYY') AND TO_DATE('{1}','DD/MM/YYYY')
           ORDER BY region_no, SECOND_ST_NO "
                , from.Value.ToString("dd/MM/yyyy"), to.Value.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionUdiReport(int regionID, bool withDistress, bool allDistress, int secondID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = "", tableName = "";
            string secondPart = (secondID == 0) ? "" : string.Format(" and STREET_ID={0} ", secondID); // second_id
            if (withDistress)
            {
                //tableName = allDistress ? "VW_REGION_SECST_UDI_DISTS" : "VW_REGION_SECST_UDI_P_DISTS ";
                tableName = allDistress ? "VW_LATEST_UD_DIST_SECONDARY" : "VW_LATEST_UD_DIST_SECONDARY_P ";
                string patchDistPart = (!allDistress) ? " and dist_code in (0, 12, 13, 14, 15) " : "";

                //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where REGION_ID={1}) ", tableName, regionID); surveyPart, 
                sql = string.Format("SELECT * FROM {1} where REGION_ID={0}  {2} {3}  ORDER BY region_no, SECOND_ST_NO ", regionID, tableName, secondPart, patchDistPart);
            }
            else
            {
                //tableName = allDistress ? "GV_SEC_ST_UDI" : "GV_SEC_ST_UDI_PATCHING";
                tableName = allDistress ? "VW_LATEST_UDI_SECONDARY" : "GV_SEC_ST_UDI_PATCHING";
                //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where REGION_ID={1}) ", tableName, regionID);  surveyPart, 
                sql = string.Format("SELECT * FROM {1} where REGION_ID={0} {2} ORDER BY region_no, SECOND_ST_NO ", regionID, tableName, secondPart);
            }

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        //public DataTable GetRegionTotalUdiReport(int regionID, int surveyNo, bool allDistress)
        //{
        //    if (regionID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDistress ? "GV_REGION_UDI" : "GV_REGION_UDI_PATCHING";
        //    string sql = string.Format("SELECT * FROM {2} where REGION_ID={0} AND SURVEY_NO={1} ORDER BY region_no ", regionID, surveyNo, tableName);
        //    return db.ExecuteQuery(sql);
        //}
        //public DataTable GetRegionTotalUdiReport(string unitName, int surveyNo, bool allDistress, RegionReportLevel level)
        //{
        //    if (string.IsNullOrEmpty(unitName) || surveyNo == 0 || level == RegionReportLevel.None)
        //        return new DataTable();

        //    string columnName = "";
        //    string tableName = allDistress ? "GV_REGION_UDI" : "GV_REGION_UDI_PATCHING";
        //    unitName = unitName.Replace("'", "''");

        //    switch (level)
        //    {
        //        case RegionReportLevel.Region:
        //            columnName = "REGION_ID";
        //            break;
        //        case RegionReportLevel.Subdistrict:
        //            columnName = "SUBDISTRICT";
        //            break;
        //        case RegionReportLevel.District:
        //            columnName = "DIST_NAME";
        //            break;
        //        case RegionReportLevel.Municipality:
        //            columnName = "MUNIC_NAME";
        //            break;
        //        default:
        //            return new DataTable();
        //    }

        //    string sql = string.Format("SELECT * FROM {2} where {3}='{0}' AND SURVEY_NO={1} ORDER BY region_no ", unitName, surveyNo, tableName, columnName);
        //    return db.ExecuteQuery(sql);
        //}

        public DataTable GetRegionTotalUdiReport(int regionID, bool allDistress)
        {
            if (regionID == 0)
                return new DataTable();

            string tableName = allDistress ? "VW_LATEST_UDI_REGIONS" : "VW_LATEST_UDI_REGIONS_P";
            //string tableName = allDistress ? "GV_REGION_UDI" : "GV_REGION_UDI_PATCHING";
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where REGION_ID={1}) ", tableName, regionID); surveyPart,   AND SURVEY_NO={1} 
            string sql = string.Format("SELECT * FROM {1} where REGION_ID={0} ORDER BY region_no ", regionID, tableName);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionTotalUdiReport(string unitName, bool allDistress, RegionReportLevel level)
        {
            if (string.IsNullOrEmpty(unitName) || level == RegionReportLevel.None)
                return new DataTable();
            string columnName = "";
            //string tableName = allDistress ? "GV_REGION_UDI" : "GV_REGION_UDI_PATCHING"; // int surveyNo, surveyNo == 0 || 
            string tableName = allDistress ? "VW_LATEST_UDI_REGIONS" : "VW_LATEST_UDI_REGIONS_P";
            unitName = unitName.Replace("'", "''");
            switch (level)
            {
                case RegionReportLevel.Region:
                    columnName = "REGION_ID";
                    break;
                case RegionReportLevel.Subdistrict:
                    columnName = "SUBDISTRICT";
                    break;
                case RegionReportLevel.District:
                    columnName = "DIST_NAME";
                    break;
                case RegionReportLevel.Municipality:
                    columnName = "MUNIC_NAME";
                    break;
                default:
                    return new DataTable();
            }
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where {1}='{2}') ", tableName, columnName, unitName); {1}  surveyPart,
            string sql = string.Format("SELECT * FROM {1} where {2}='{0}'  ORDER BY region_no ", unitName, tableName, columnName);
            return db.ExecuteQuery(sql);
        }

        public DataTable getRegionTotalUdiReportBy(string unitName, bool allDistress, RegionReportLevel level)
        {
            if (string.IsNullOrEmpty(unitName) || level == RegionReportLevel.None)
                return new DataTable();

            string columnName = "";
            //string tableName = allDistress ? "GV_REGION_UDI" : "GV_REGION_UDI_PATCHING"; // int surveyNo, surveyNo == 0 || 
            string tableName = allDistress ? "VW_LATEST_UDI_SECONDARY" : "VW_LATEST_UDI_SECONDARY_P";
            unitName = unitName.Replace("'", "''");

            switch (level)
            {
                case RegionReportLevel.Region:
                    columnName = "REGION_ID";
                    break;
                case RegionReportLevel.Subdistrict:
                    columnName = "SUBDISTRICT";
                    break;
                case RegionReportLevel.District:
                    columnName = "DIST_NAME";
                    break;
                case RegionReportLevel.Municipality:
                    columnName = "MUNIC_NAME";
                    break;
                default:
                    return new DataTable();
            }

            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where {1}='{2}') ", tableName, columnName, unitName); surveyPart,  {1}
            string sql = string.Format("SELECT * FROM {1} where {2}='{0}' and udi_date is not null " +
                " ORDER BY subdistrict, region_no, second_st_no ", unitName, tableName, columnName);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetAllRegionsPavementStatus()
        {
            string sql = "select * from VW_REGION_PAVEMENT_STATUS order by region_no ";
            return db.ExecuteQuery(sql);
        }

        #endregion


    }
}
