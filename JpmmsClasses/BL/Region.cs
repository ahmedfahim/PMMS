using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;
using JpmmsClasses.BL.Lookups;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL
{
    public class Region
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private DistrictSubdistrict distSubdist = new DistrictSubdistrict();



        #region Regions Info
        public DataTable GetAllRegionsErorrs()
        {
            string sql = "select count(REGION_NO)COUNT,REGION_NO from REGIONS group by REGION_NO having count(REGION_NO)>1 ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetNoteStreets()
        {
            string sql = "select DISTINCT NOTES from JPMMS.STREETS where STREET_TYPE=0 order by NOTES";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetNoteRegions()
        {
            string sql = "select DISTINCT NOTES from JPMMS.REGIONS   order by NOTES";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllRegions()
        {
            // region_no, ARNAME,     DIST_NAME || ' ' || SUBDISTRIC
            string sql = "select region_id, region_no, SUBDISTRICT, (region_no|| ' - ' || SUBDISTRICT) as region_title from regions where SUBDISTRICT is not null and region_no is not null  order by region_no ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllRegions(int SUBMUNICIP, int DISTRICTNO)
        {
            // region_no, ARNAME,     DIST_NAME || ' ' || SUBDISTRIC
            string sql = string.Format(@"select region_id, region_no, SUBDISTRICT, (region_no|| ' - ' || SUBDISTRICT) as region_title from REGIONS where SUBDISTRIC in (
                select SUBDISTRIC  from SUBDISTRICT where DISTRICTNO={0}  ) and SUBMUNICIP={1} and DISTRICTNO={0}  order by region_no ", DISTRICTNO, SUBMUNICIP);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionsFullInfo()
        {
            string sql = "select REGION_ID, REGION_NO, SUBDISTRICT, DIST_NAME, DIST_NO, nvl(SUBMUNICIP, 0) as SUBMUNICIP, SUBDISTRIC, ARNAME, ENNAME, " +
                "nvl(DISTRICTNO, 0) as DISTRICTNO, nvl(DISTRICT_ID, 0) as DISTRICT_ID, nvl(SUBDISTRICT_ID, 0) as SUBDISTRICT_ID, MUNIC_NAME, NOTES, SURVEYABLE, " +
                " DECODE(SURVEYABLE, 1, 'قابلة للمسح', 'منطقة مغلقة') AS SURVEYABLE_text from regions    order by region_no ";

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionsFullInfo(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format("select REGION_ID, REGION_NO, SUBDISTRICT, DIST_NAME, DIST_NO, nvl(SUBMUNICIP, 0) as SUBMUNICIP, SUBDISTRIC, ARNAME, ENNAME, " +
                "nvl(DISTRICTNO, 0) as DISTRICTNO, nvl(DISTRICT_ID, 0) as DISTRICT_ID, nvl(SUBDISTRICT_ID, 0) as SUBDISTRICT_ID, MUNIC_NAME, NOTES, SURVEYABLE,  " +
                " DECODE(SURVEYABLE, 1, 'True', 'False') AS SURVEYABLE_text from regions where REGION_ID={0}   order by region_no ", regionID);

            return db.ExecuteQuery(sql);
        }
        public DataTable GET_SURVEYABLE(int SUBMUNICIPID)
        {
            if (SUBMUNICIPID == 0)
                return new DataTable();

            string sql = string.Format(@"select REGION_ID, REGION_NO, SUBDISTRICT,   nvl(SUBMUNICIP, 0) as SUBMUNICIP,  
                nvl(DISTRICTNO, 0) as DISTRICTNO, nvl(DISTRICT_ID, 0) as DISTRICT_ID, nvl(SUBDISTRICT_ID, 0) as SUBDISTRICT_ID, MUNIC_NAME, NOTES,  
                 DECODE(SURVEYABLE, 1, 'True', 'False') AS SURVEYABLE from regions where SUBMUNICIP={0}   order by region_no ", SUBMUNICIPID);

            return db.ExecuteQuery(sql);

        }
        public bool Update_SURVEYABLE(string REGION_NO, int REGION_ID, bool SURVEYABLE, string NOTES)
        {
            if ( REGION_ID == 0 || string.IsNullOrEmpty(REGION_NO) || REGION_NO.Length < 6)
                return false;
            string sql = string.Format("update regions set SURVEYABLE={0} , NOTES='{1}' where REGION_NO={2} and REGION_ID={3}", SURVEYABLE == true ? 1 : 0, NOTES, REGION_NO, REGION_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable GetRegionInfo(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // (DIST_NAME || '/' || SUBDISTRIC)
            string sql = string.Format("select region_no, ARNAME, MUNIC_NAME, subdistrict as region_name from regions where region_id={0} ", regionID);
            return db.ExecuteQuery(sql);
        }
        public bool InsertNewStreetRegion(string SECOND_ST_NO, int REGION_ID, string REGION_NO)
        {
            int value;
            if (REGION_ID == 0 || string.IsNullOrEmpty(REGION_NO) || REGION_NO.Length < 6)
                return false;
            REGION_NO = REGION_NO.Substring(0, 6);
            if (REGION_NO.Length == 6 && int.TryParse(REGION_NO, out value))
            {
                string Exsists = string.Format(" select count(*) from STREETS where SECOND_ST_NO='{0}' and REGION_NO='{1}' and REGION_ID ='{2}'", SECOND_ST_NO, REGION_NO, REGION_ID);
                string rowsExsists = db.ExecuteScalar(Exsists).ToString();
                if (int.Parse(rowsExsists) > 0)
                    return false;
                else
                {
                    string sql = string.Format(" insert INTO STREETS (SECOND_ST_NO,REGION_NO,REGION_ID,IS_R4,STREET_TYPE,DATECREATE,STREET_ID,OBJECTID) values ('{0}','{1}',{2},'N',0,(SELECT SYSDATE FROM dual),(select max(STREET_ID) from STREETS)+1,(select max(OBJECTID) from STREETS)+1)",
                            SECOND_ST_NO, REGION_NO, REGION_ID);

                    int rows = db.ExecuteNonQuery(sql);
                    return (rows > 0);
                }
            }
            else
                return false;
        }

        public bool UpdateRegion(string REGION_NO, int SUBDISTRICT_ID, int REGION_ID, bool SURVEYABLE, string NOTES)
        {
            if (SUBDISTRICT_ID == 0 || REGION_ID == 0 || string.IsNullOrEmpty(REGION_NO) || REGION_NO.Length < 6)
                return false;

            REGION_NO = REGION_NO.Replace("'", "''");
            NOTES = string.IsNullOrEmpty(NOTES) ? "NULL" : string.Format("'{0}'", NOTES.Replace("'", "''"));


            DataTable dt = distSubdist.GetSubDistFullInfo(SUBDISTRICT_ID);
            if (dt.Rows.Count == 0)
                return false;

            DataRow dr = dt.Rows[0];
            DataTable dtDist = distSubdist.GetDistrictFullInfo(int.Parse(dr["DISTRICTNO"].ToString()));
            if (dtDist.Rows.Count == 0)
                return false;

            DataRow drDist = dtDist.Rows[0];
            string sql = string.Format("update REGIONS set REGION_NO='{0}', SUBDISTRICT='{1}', DIST_NAME='{2}', DIST_NO='{3}', SUBMUNICIP={4}, SUBDISTRIC='{5}', " +
                " ARNAME='{6}', ENNAME='{7}', DISTRICTNO={8}, DISTRICT_ID={8}, SUBDISTRICT_ID={9}, MUNIC_NAME='{10}', NOTES={11}, SURVEYABLE={12} " + 
                " where region_id={13}  ",
                REGION_NO, dr["ARNAME"].ToString(), drDist["ARNAME"].ToString(), drDist["DIST_NO"].ToString(), dr["SUBMUNICIP"].ToString(), dr["SUBDISTRIC"].ToString(),
                dr["ARNAME"].ToString(), dr["ENNAME"].ToString(), dr["DISTRICTNO"].ToString(), SUBDISTRICT_ID, drDist["MUNIC_NAME"].ToString(), NOTES, Shared.Bool2Int(SURVEYABLE),
                REGION_ID);

            int rows = db.ExecuteNonQuery(sql);

            sql = string.Format("update SECTIONS set SUBDISTRICT='{0}', district='{1}' where SECTION_NO like '{2}%' ",
                dr["ARNAME"].ToString(), drDist["ARNAME"].ToString(), REGION_NO);

            rows += db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public DataTable GetRegionElements(bool regions, bool subdistrict, bool district, bool munic)
        {
            string sql = "";
            if (regions)
                sql = "select distinct region_id, region_no, (region_no|| ' - ' || SUBDISTRICt) as region_title from GV_SEC_STREET where REGION_NO is not null and SECOND_ST_NO is not null order by region_no ";
            else if (subdistrict)
                sql = "select distinct SUBDISTRICT as region_id, SUBDISTRICT as region_title  from GV_SEC_STREET order by subdistrict ";
            else if (district)
                sql = " select distinct DIST_NAME as region_id, DIST_NAME as region_title  from GV_SEC_STREET order by DIST_NAME ";
            else if (munic)
                sql = " select distinct MUNIC_NAME as region_id, MUNIC_NAME as region_title  from GV_SEC_STREET order by MUNIC_NAME ";
            else
                return new DataTable();

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }


        public DataTable GetAllSubdistrictsHavingRegions()
        {
            string sql = "select distinct SUBDISTRICT from regions order by subdistrict ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllDistrictsHavingRegions()
        {
            string sql = "select distinct dist_name from regions order by dist_name ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllMunicsHavingRegions()
        {
            string sql = "select distinct munic_name from regions order by munic_name ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllRegionsSUBMUNICIPALITY()
        {
            string sql = @"select count(REGION_ID)TOTAL,SUBMUNICIPALITY.ARNAME from regions
                            join SUBMUNICIPALITY on SUBMUNICIPALITY.MUNIC_ID=REGIONS.SUBMUNICIP
                            group by SUBMUNICIPALITY.ARNAME";
            return db.ExecuteQuery(sql);
        }

        public DataTable SearchRegions(bool byNum, string numName)
        {
            if (string.IsNullOrEmpty(numName))
                return new DataTable();

            string sql = "";
            numName = numName.Trim().Replace("'", "''");

            // region_no || ' - ' || 
            if (byNum)
                sql = string.Format("select region_id, region_no, subdistrict as region_title from regions where region_no like '%{0}%' and SUBDISTRICT is not null ", numName);
            else
                sql = string.Format("select region_id, region_no, subdistrict as region_title from regions where SUBDISTRICT like '%{0}%' or SUBDISTRIC like '%{0}%' or DIST_NAME like '%{0}%' and SUBDISTRICT is not null ", numName);

            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Surveyed Regions

        public DataTable GetSurveyedRegions()
        {
            // region_no
            string sql = "SELECT Region_no, (region_no || ' - ' || SUBDISTRICT) as region_title, REGION_ID, MAX(SECOND_ST_NO) SECOND_ST_NO  FROM gv_Sec_ST_distress  GROUP BY REGION_NO, SUBDISTRICT, REGION_ID order by Region_no ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSurveyedRegionsByMonth(string Monthes)
        {
            //DateTime From, TO;
            //new JpmmsClasses.BL.Lookups.SystemUsers().GetMonthlyDate(Monthes, out From, out TO);

            /*string SqlInsert = string.Format(@"insert INTO SECONDARY_STREET_DETAILS(street_id, ARNAME, ENNAME, REGION_NO, SECOND_AR_NAME, SECOND_EN_NAME, 
                                                SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID)
                                                SELECT street_id, ARNAME, ENNAME, REGION_NO, SECOND_ARNAME, SECOND_ENNAME, 
                                                SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID  FROM STREETS WHERE REGION_NO in (select d.region_no 
                       from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and survey_date  between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY')
                      group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id ) and street_id not in (SELECT street_id FROM SECONDARY_STREET_DETAILS)",
                       ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"))*/

            string SqlInsert = string.Format(@"insert INTO SECONDARY_STREET_DETAILS(street_id, ARNAME, ENNAME, REGION_NO, SECOND_AR_NAME, SECOND_EN_NAME, 
                                                SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID)
                                                SELECT street_id, ARNAME, ENNAME, REGION_NO, SECOND_ARNAME, SECOND_ENNAME, 
                                                SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID  FROM STREETS WHERE REGION_NO in (select d.region_no 
                       from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and region_id in (select region_id from REPORTSQC where REPORTSMONTH='{0}')
                      group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id ) and street_id not in (SELECT street_id FROM SECONDARY_STREET_DETAILS)", Monthes);

            db.ExecuteNonQuery(SqlInsert);

            /*string sql = string.Format("SELECT Region_no, (region_no || ' - ' || SUBDISTRICT) as region_title, REGION_ID, MAX(SECOND_ST_NO) SECOND_ST_NO  FROM gv_Sec_ST_distress where REGION_NO in (select d.region_no " +
                      " from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and survey_date  between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY') " +
                      "group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id ) GROUP BY REGION_NO, SUBDISTRICT, REGION_ID order by Region_no "
              , ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"));*/

            string sql = string.Format("SELECT Region_no, (region_no || ' - ' || SUBDISTRICT) as region_title, REGION_ID, MAX(SECOND_ST_NO) SECOND_ST_NO  FROM gv_Sec_ST_distress where REGION_NO in (select d.region_no " +
                     " from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and region_id in (select region_id from REPORTSQC where REPORTSMONTH='{0}') " +
                     "group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id ) GROUP BY REGION_NO, SUBDISTRICT, REGION_ID order by Region_no ", Monthes);

            return db.ExecuteQuery(sql);

        }
        public DataTable GetSurveyedSubdistricts()
        {
            string sql = "SELECT  subdistrict, MAX(SECOND_ST_NO) SECOND_ST_NO FROM gv_Sec_ST_distress WHERE  subdistrict IS NOT NULL GROUP BY subdistrict ORDER BY subdistrict ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyedDistricts()
        {
            string sql = "SELECT DIST_NAME, MAX(SECOND_ST_NO) SECOND_ST_NO FROM gv_Sec_ST_distress WHERE  DIST_NAME IS NOT NULL GROUP BY DIST_NAME ORDER BY DIST_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyedMunicipalities()
        {
            string sql = "SELECT MUNIC_NAME, MAX(SECOND_ST_NO) SECOND_ST_NO FROM gv_Sec_ST_distress WHERE  MUNIC_NAME IS NOT NULL GROUP BY MUNIC_NAME ORDER BY MUNIC_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyedSecondaryStreetRegion()
        {
            //string sql = "SELECT  distinct r.region_id, s.region_no, r.ARNAME, (s.region_no || ' - ' || r.DIST_NAME || ' ' || r.SUBDISTRIC) as region_title FROM SECONDARY_STREETS s, regions r WHERE s.SECOND_ID IN (SELECT SECOND_ID FROM DISTRESS_regions WHERE SURVEY_DATE IS NOT NULL) AND s.REGION_NO IS NOT NULL and s.REGION_ID=r.REGION_ID ORDER BY s.region_no  ";
            string sql = "SELECT  region_id, region_no, (region_no || ' - ' || SUBDISTRICT) as region_title FROM regions WHERE region_id IN (SELECT region_id FROM DISTRESS WHERE SURVEY_DATE IS NOT NULL) AND REGION_NO IS NOT NULL ORDER BY region_no  ";
            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Calculated UDI

        public DataTable GetRegionsHavingCalculatedUdi()
        {
            string sql = "SELECT region_id, SUBDISTRICT, region_no, (region_no || ' - ' || SUBDISTRICT) as region_title, MAX(SECOND_ST_NO) AS SECOND_ID FROM GV_SEC_ST_UDI WHERE UDI_DATE IS NOT NULL GROUP BY region_id, SUBDISTRICT, region_no  ORDER BY REGION_NO ";
            return db.ExecuteQuery(sql);  //SECOND_ID
        }

        public DataTable GetSubdistrictsHavingCalculatedUdi()
        {
            string sql = "select SUBdistRICT, max(region_no) region_no from gv_sec_st_udi WHERE udi_date is not null GROUP BY SUBdistRICT ORDER BY SUBdistRICT ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetDistrictsHavingCalculatedUdi()
        {
            string sql = "select dist_name, max(region_no) region_no from gv_sec_st_udi WHERE udi_date is not null GROUP BY dist_name ORDER BY dist_name ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMunicipalityHavingCalculatedUdi()
        {
            string sql = "select MUNIC_NAME, max(region_no) region_no from gv_sec_st_udi WHERE udi_date is not null GROUP BY MUNIC_NAME ORDER BY MUNIC_NAME ";
            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Maintenance decisions

        public DataTable GetRegionsHavingMaintenanceDecisions()
        {
            string sql = "select r.REGION_ID, r.REGION_NO, (r.REGION_NO || ' - ' || r.SUBDISTRICT) as SUBdistRICT from MAINTENANCE_DECISIONS m, REGIONS r WHERE udi_date is not null and m.region_id=m.region_id GROUP BY r.SUBdistRICT, r.region_no, r.REGION_ID ORDER BY r.REGION_NO ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSubdistrictsHavingMaintenanceDecisions()
        {
            string sql = "select distinct SUBDISTRICT from regions where region_id in (select region_id from MAINTENANCE_DECISIONS where region_id is not null) order by SUBDISTRICT ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetDistrictsHavingMaintenanceDecisions()
        {
            string sql = "select distinct DIST_NAME from regions where region_id in (select region_id from MAINTENANCE_DECISIONS where region_id is not null) order by DIST_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMunicipalitiesHavingMaintenanceDecisions()
        {
            string sql = "select distinct MUNIC_NAME from regions where region_id in (select region_id from MAINTENANCE_DECISIONS where region_id is not null) order by MUNIC_NAME ";
            return db.ExecuteQuery(sql);
        }

        #endregion



        public bool CheckRegionSurveyorNotSaved(int sectionID)
        {
            string sql = string.Format("select * from SURVEYORS_SUBMIT_JOB where REGION_NO=(select REGION_NO from REGIONS where REGION_ID={0}) ", sectionID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? true : false;
        }

        public string GetRegionNum(int regionID)
        {
            string regionSql = string.Format("select region_no from regions where region_id={0} ", regionID);
            string regionNum = db.ExecuteScalar(regionSql).ToString();
            return regionNum;
        }

        public string GetRegionSamplesTotalLength(int regionID)
        {
            if (regionID == 0)
                return null;
            string sql = string.Format("SELECT sum(round(SECOND_ST_LENGTH, 2)) TotalLength FROM STREETS where REGION_ID={0}", regionID);
            return db.ExecuteScalar(sql).ToString();
        }
        public DataTable GetRegionSamplesSurveyThree(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES " +
                " FROM STREETS_SURVEYTHREE where REGION_ID={0}    order by lpad(SECOND_ST_NO,10) ", regionID);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionSamples(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES " + 
                " FROM STREETS where REGION_ID={0}    order by lpad(SECOND_ST_NO,10) ", regionID);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionSamplesREGION_ID(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT REGION_ID,SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES " + 
                " FROM STREETS where REGION_ID={0}    order by lpad(SECOND_ST_NO,10) ", regionID);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionSamplesOLD(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES " +
                " FROM STREETS_SURVEYOLD where REGION_ID={0}    order by lpad(SECOND_ST_NO,10) ", regionID);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionSamplesUDI(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID " +
                " FROM SECONDARY_STREET_DETAILS where REGION_ID={0}    order by lpad(SECOND_ST_NO,10) ", regionID);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionSamplesWithDISTRESS(int regionID,int ServeyNo)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES ,(select count(STREET_ID) TotaDISTRESS from DISTRESS xd where xd.STREET_ID=S.STREET_ID and xd.SURVEY_NO={1} group by REGION_NO ) DISTRESS" +
                " ,(select NOTES from STREETS_SURVEYTHREE where STREET_ID=S.STREET_ID)NOTESOLD FROM STREETS S where REGION_ID={0}    order by lpad(SECOND_ST_NO,10) ", regionID, ServeyNo);

            return db.ExecuteQuery(sql);
        }
        public DataTable DeleteRegionSamplesStreet(int StreetID)
        {
            if (StreetID == 0)
                return new DataTable();
            string SqlDelte = string.Format("update STREETS set REGION_NO=null , REGION_ID=null ,NOTES_SURVEYORS=concat('Deleted: ',(SELECT SYSDATE FROM DUAL)) where STREET_ID={0}", StreetID);
            string SqlDistress = string.Format("Delete DISTRESS where SURVEY_NO>2 and STREET_ID={0}", StreetID);
            if (db.ExecuteNonQuery(SqlDelte) > 0 )
            {
                db.ExecuteNonQuery(SqlDistress);
                string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                     " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES " +
                     " FROM STREETS where REGION_ID=(select REGION_ID from STREETS where STREET_ID={0}) order by lpad(SECOND_ST_NO,10) ", StreetID);

                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }
        public DataTable GetRegionSamplesNewStreets(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID, NOTES FROM SECONDARY_STREETS where REGION_ID={0} order by lpad(SECOND_ST_NO,10) ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ARNAME as SECOND_AR_NAME, round(SECOND_ST_LENGTH, 2) as SECOND_ST_LENGTH, " +
                " round(SECOND_ST_WIDTH, 2) as SECOND_ST_WIDTH, round((SECOND_ST_LENGTH * SECOND_ST_WIDTH), 2) AS AREA,  STREET_ID, NOTES " +
                " FROM STREETS where REGION_ID={0} and DATECREATE>'01/06/2018'   order by lpad(SECOND_ST_NO,10) ", regionID);

            return db.ExecuteQuery(sql);
        }
        public static double GetRegionSampleAreaSum(int regionID)
        {
            if (regionID == 0)
                return 0;

            string sql = string.Format("select nvl(sum(SAMPLE_AREA), 0) as SAMPLE_AREA_sum from GV_SEC_STREET where region_id={0} ", regionID);
            return double.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        }
        public static int GetRegionSampleAreaSumStreets(int regionID)
        {
            if (regionID == 0)
                return 0;

            string sql = string.Format("select nvl(count(STREET_ID), 0) as TotalCount from STREETS where region_id={0} ", regionID);
            return int.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        }
        public bool UpdateSecondaryStreetST_NO(int STREET_ID, string SECOND_ST_NO, int REGION_ID)
        {
            if (SECOND_ST_NO.Length >= 3)
                return false;
            //string Exsists = string.Format(" select count(*) from STREETS where SECOND_ST_NO='{0}' and REGION_ID ='{2}' and STREET_ID <> {1} ", SECOND_ST_NO, STREET_ID, REGION_ID);
            //string rowsExsists = db.ExecuteScalar(Exsists).ToString();
            //if (int.Parse(rowsExsists) > 0)
            //    return false;
            else
            {
                string sql = string.Format("UPDATE STREETS SET SECOND_ST_NO='{0}' WHERE STREET_ID={1} ",
                     SECOND_ST_NO.ToUpper(), STREET_ID);

                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }

        }

        public bool UpdateSecondaryStreetSampleArea(int STREET_ID, string SECOND_AR_NAME, double SECOND_ST_LENGTH, double SECOND_ST_WIDTH, string user, string NOTES)
        {
            string sql = "";

            SECOND_AR_NAME = (string.IsNullOrEmpty(SECOND_AR_NAME)) ? "NULL" : string.Format("'{0}'", SECOND_AR_NAME.Replace("'", "''"));
            NOTES = (string.IsNullOrEmpty(NOTES)) ? "NULL" : string.Format("'{0}'", NOTES.Replace("'", "''"));

            int lastSecondaryStSurveyNum = DistressSurvey.GetLastSecondaryStreetSurveyNumber(STREET_ID);
            if (lastSecondaryStSurveyNum == 0)
            {
                // no surveys have been done over this secondar street, so we can update its length and width directly
                //sql = string.Format("UPDATE SECONDARY_STREETS SET SECOND_ST_WIDTH={0}, SECOND_ST_LENGTH={1}, ARNAME={2}, SECOND_ARNAME={2} WHERE SECOND_ID={3} ",
                sql = string.Format("UPDATE STREETS SET SECOND_ST_WIDTH={0}, SECOND_ST_LENGTH={1}, ARNAME={2}, SECOND_ARNAME={2} WHERE STREET_ID={3} ",
                    SECOND_ST_WIDTH, SECOND_ST_LENGTH, SECOND_AR_NAME, STREET_ID);

                int rows = db.ExecuteNonQuery(sql);


                sql = string.Format("UPDATE SECONDARY_STREET_DETAILS SET SECOND_ST_WIDTH={0}, SECOND_ST_LENGTH={1}, ARNAME={2}, SECOND_AR_NAME={2} WHERE STREET_ID={3} ",
                   SECOND_ST_WIDTH, SECOND_ST_LENGTH, SECOND_AR_NAME, STREET_ID);

                rows += db.ExecuteNonQuery(sql);

                Shared.SaveLogfile("SECONDARY_STREETS", STREET_ID.ToString(), "Update", user);
                return (rows > 0);
            }
            else
            {
                // surveys have been done over this secondar street, so we have to remove them before we can update its length and width directly
                sql = string.Format("UPDATE STREETS SET SECOND_ST_WIDTH={0}, SECOND_ST_LENGTH={1}, ARNAME={2}, SECOND_ARNAME={2}, NOTES={4} WHERE STREET_ID={3} ",
                   SECOND_ST_WIDTH, SECOND_ST_LENGTH, SECOND_AR_NAME, STREET_ID, NOTES);

                int rows = db.ExecuteNonQuery(sql);

                sql = string.Format("UPDATE SECONDARY_STREET_DETAILS SET SECOND_ST_WIDTH={0}, SECOND_ST_LENGTH={1}, ARNAME={2}, SECOND_AR_NAME={2} WHERE STREET_ID={3} ",
                  SECOND_ST_WIDTH, SECOND_ST_LENGTH, SECOND_AR_NAME, STREET_ID);

                rows += db.ExecuteNonQuery(sql);
                rows += new SecondaryStreets().FixDistressesAfterAreaChange(SECOND_ST_LENGTH, SECOND_ST_WIDTH, STREET_ID, user);

                sql = string.Format("DELETE FROM MAINTENANCE_DECISIONS WHERE STREET_ID={0} ", STREET_ID); // second_id
                db.ExecuteNonQuery(sql);


                Shared.SaveLogfile("SECONDARY_STREETS", STREET_ID.ToString(), "Update with nulling UDI", user);
                return (rows > 0);
            }
        }

    }
}
