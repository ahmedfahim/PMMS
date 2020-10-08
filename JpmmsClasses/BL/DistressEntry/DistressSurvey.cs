using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using JpmmsClasses.BL.DistressEntry;

namespace JpmmsClasses.BL
{
    public class DistressSurvey
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private Region region = new Region();




        #region Getting Available Surveys

       

        public DataTable GetAvailableSurveys(int sampleID)
        {
            if (sampleID == 0)
                return new DataTable();

            string sql = string.Format("SELECT  SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  FROM DISTRESS WHERE SAMPLE_ID={0} " +
                " GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", sampleID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetAvailableIntersectionSurveys(int intersectionSampleID)
        {
            if (intersectionSampleID == 0)
                return new DataTable();

            // , SURVEY_DATE
            string sql = string.Format("SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title FROM DISTRESS WHERE INTER_SAMP_ID={0} " +
                " GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", intersectionSampleID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSecondaryStreetAvailableSurveys(int secondStID)
        {
            if (secondStID == 0)
                return new DataTable();

            string sql = string.Format("SELECT  SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  FROM DISTRESS WHERE STREET_ID={0} " +
                " GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", secondStID);

            return db.ExecuteQuery(sql);  // SECOND_ID
        }

        public DataTable GetMainStreetSectionAvailableSurveys(int sectionID)
        {
            if (sectionID == 0)
                return new DataTable();

            // SURVEY_DATE desc
            string sql = string.Format("SELECT  SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  FROM DISTRESS WHERE SECTION_ID={0} " +
                " GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", sectionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSurroundingSectionsAvailableSurveys(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // SURVEY_DATE desc SECTION_ID={0}
            string regionNum = region.GetRegionNum(regionID);
            string sql = string.Format("SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  FROM DISTRESS WHERE section_no like '{0}%' " +
                " GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", regionNum);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetSectionAvailableSurveys(int mainSt, int sectionID)
        {
            if (mainSt == 0) //|| (mainSt != 0 && sectionID == 0)) //|| (forSection && sectionID == 0)) SURVEY_no 
                return new DataTable();

            string sql = "";
            if (sectionID != 0)
                sql = string.Format("SELECT  SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  FROM DISTRESS WHERE SECTION_ID={0} " +
                    " GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", sectionID);
            else
                sql = string.Format("SELECT  SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  FROM DISTRESS " +
                    " WHERE SECTION_ID in (select section_id from SECTIONS where STREET_ID={0}) GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", mainSt);

            // MAIN_STREET_ID
            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }

        public DataTable GetMainStreetAvailableSurveys(int mainStID)
        {
            //if (mainStID == 0)
            //    return new DataTable();
            string mainStPart = (mainStID == 0) ? "" : string.Format(" WHERE  STREET_ID={0} ", mainStID); // MAIN_STREET_ID
            string sql = string.Format("SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy')) survey_title FROM GV_SAMPLE_DISTRESS {0} GROUP BY SURVEY_No order by SURVEY_No ", mainStPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsAvailableSurveys(int mainStID)
        {
            string mainStPart = (mainStID == 0) ? "" : string.Format(" WHERE  STREET_ID={0} ", mainStID);
            string sql = string.Format("SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) survey_title FROM GV_interS_SMPL_DISTRESS {0} " +
                " GROUP BY SURVEY_No order by SURVEY_No ", mainStPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable Get_AvailableIntersectionSurveys(int intersectionID)
        {
            if (intersectionID == 0)
                return new DataTable();

            //string sql = string.Format("SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO|| '- '|| to_char(SURVEY_DATE, 'dd/MM/yyyy')) as survey_title FROM DISTRESS WHERE INTERSECTION_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE ORDER BY SURVEY_NO ", intersectionID);
            string sql = string.Format("SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title " +
                " FROM DISTRESS WHERE INTERSECTION_ID={0} GROUP BY SURVEY_NO ORDER BY SURVEY_DATE desc ", intersectionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable Get_AvailableIntersectionSurveysForUdi(int mainStID, bool forIntersect, int intersectID)
        {
            if (mainStID == 0)
                return new DataTable();
            else if (forIntersect && (intersectID == 0))
                return new DataTable();

            string sql = "";        // MAIN_ST_ID
            if (forIntersect)
            {
                sql = string.Format("SELECT SURVEY_NO, to_char(MAX(MAX_SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(max (MAX_SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title " +
                    " FROM MID_INTERSECTION_SAMPLES_UDI WHERE STREET_ID={0} and INTERSECTION_ID={1} GROUP BY SURVEY_NO ORDER BY MAX_SURVEY_DATE desc ", mainStID, intersectID);

                return db.ExecuteQuery(sql);
            }
            else
            {
                //string sql = string.Format("SELECT SURVEY_NO FROM MID_INTERSECTION_SAMPLES_UDI WHERE MAIN_ST_ID={0} GROUP BY SURVEY_NO ORDER BY SURVEY_NO ", mainStID);
                sql = string.Format("SELECT SURVEY_NO, to_char(MAX(MAX_SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(max(MAX_SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title " +
                    " FROM MID_INTERSECTION_SAMPLES_UDI WHERE STREET_ID={0} GROUP BY SURVEY_NO ORDER BY MAX_SURVEY_DATE desc ", mainStID);

                return db.ExecuteQuery(sql);
            }
        }

        public DataTable GetAvailableRegionSurveys(int regionID, bool isTotal, bool forDistresses, bool inDates)
        {
            string sql = "";
            if (regionID == 0 && (isTotal || forDistresses || inDates))
            {
                // DISTRESS_REGIONS 
                sql = "SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM DISTRESS " +
                    " GROUP BY SURVEY_NO order by SURVEY_DATE desc ";

                return db.ExecuteQuery(sql);
            }
            else if (regionID != 0)
            {
                // DISTRESS_REGIONS
                sql = string.Format("SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM DISTRESS WHERE REGION_ID={0} " +
                    " GROUP BY SURVEY_NO order by SURVEY_DATE desc ", regionID);

                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }

        public DataTable GetAvailableRegionSurveysForUdiReport(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format("SELECT SURVEY_NO FROM GV_SEC_ST_UDI where REGION_ID={0}  ORDER BY region_no, SECOND_ST_NO ", regionID);
            return db.ExecuteQuery(sql);
        }



        public DataTable GetRegionDistrictAvailableSurveys(int regionID, string subdistrict, string districtName, string municName, bool forRegion, bool forSubdist,
            bool forDist, bool forMunic, bool isRegionTotal)
        {
            string sql = "";

            if (forRegion || isRegionTotal)
            {
                //if (regionID == 0)
                //    return new DataTable();

                string regionIdPart = (regionID == 0) ? "" : string.Format(" WHERE REGION_ID={0} ", regionID);
                sql = string.Format("SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM GV_SEC_ST_DISTRESS {0} " +
                    " GROUP BY SURVEY_NO order by SURVEY_NO ", regionIdPart);
            }
            else if (forSubdist)
            {
                //if (string.IsNullOrEmpty(subdistrict) || subdistrict == "0")
                //    return new DataTable();

                string subdistrictPart = (string.IsNullOrEmpty(subdistrict) || subdistrict == "0") ? "" : string.Format(" WHERE subdistrict='{0}' ", subdistrict);
                sql = string.Format("SELECT SURVEY_NO,  to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM GV_SEC_ST_DISTRESS  {0} " +
                    " GROUP BY SURVEY_NO order by SURVEY_NO ", subdistrictPart);
            }
            else if (forDist)
            {
                //if (string.IsNullOrEmpty(districtName) || districtName == "0")
                //    return new DataTable();

                string districtNamePart = (string.IsNullOrEmpty(districtName) || districtName == "0") ? "" : string.Format(" WHERE DIST_NAME='{0}' ", districtName);
                sql = string.Format("SELECT SURVEY_NO,  to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM GV_SEC_ST_DISTRESS  {0} " +
                    " GROUP BY SURVEY_NO order by SURVEY_NO ", districtNamePart);
            }
            else if (forMunic)
            {
                //if (string.IsNullOrEmpty(municName) || municName == "0")
                //    return new DataTable();

                string municNamePart = (string.IsNullOrEmpty(municName) || municName == "0") ? "" : string.Format(" WHERE MUNIC_NAME='{0}' ", municName);
                sql = string.Format("SELECT SURVEY_NO,  to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM GV_SEC_ST_DISTRESS  {0} " +
                    " GROUP BY SURVEY_NO order by SURVEY_NO ", municNamePart);
            }

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable GetRegionsAndMainStreetSectionIntersections(int regionID, string subdistrict, string districtName, string municName, bool forRegion, bool forSubdist,
            bool forDist, bool forMunic, int mainStID, bool lane, bool serviceLane, bool intersect)
        {
            if (forRegion || forSubdist || forDist || forMunic)
                return GetRegionDistrictAvailableSurveys(regionID, subdistrict, districtName, municName, forRegion, forSubdist, forDist, forMunic, false);
            else
            {
                if (lane || serviceLane)
                    return GetMainStreetAvailableSurveys(mainStID);
                else if (intersect)
                    return GetMainStreetIntersectionsAvailableSurveys(mainStID);
                else
                    return new DataTable();
            }
        }

        public DataTable GetRegionsAndMainStreetSectionIntersections(int regionID, string subdistrict, string districtName, string municName, bool forRegion, bool forSubdist,
          bool forDist, bool forMunic, int mainStID, bool lane, bool intersect)
        {
            if (forRegion || forSubdist || forDist || forMunic)
                return GetRegionDistrictAvailableSurveys(regionID, subdistrict, districtName, municName, forRegion, forSubdist, forDist, forMunic, false);
            else
            {
                if (lane)
                    return GetMainStreetAvailableSurveys(mainStID);
                else if (intersect)
                    return GetMainStreetIntersectionsAvailableSurveys(mainStID);
                else
                    return new DataTable();
            }
        }

        public DataTable GetRegionsAndMainStreetSectionIntersections(bool regions, bool sections, bool intersects)
        {
            string sql = "";
            if (sections)
                sql = "SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
               " (SURVEY_NO || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy')) survey_title FROM GV_SAMPLE_DISTRESS  GROUP BY SURVEY_No order by SURVEY_No ";
            else if (intersects)
                sql = "SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) survey_title FROM GV_interS_SMPL_DISTRESS " +
                " GROUP BY SURVEY_No order by SURVEY_No ";
            else if (regions)
                sql = "SELECT SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (SURVEY_NO|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM GV_SEC_ST_DISTRESS " +
                    " GROUP BY SURVEY_NO order by SURVEY_NO ";

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }






        public DataTable GetWholeRoadsNetworkAvailableSurveys()
        {
            string sql = "SELECT  SURVEY_NO FROM DISTRESS GROUP BY SURVEY_NO ORDER BY SURVEY_no ";
            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Getting Latest Survey Automatically

        public DataTable GetLastSurveyForRoadsNetwork(int regionID, string subdistrict, string districtName, string municName, bool forRegion, bool forSubdist,
          bool forDist, bool forMunic, int mainStID, bool lane, bool intersect)
        {
            if (forRegion || forSubdist || forDist || forMunic)
                return GetRegionDistrictLatestSurveys(regionID, subdistrict, districtName, municName, forRegion, forSubdist, forDist, forMunic);
            else
            {
                if (lane)
                    return GetMainStreetLatestSurveys(mainStID);
                else if (intersect)
                    return GetMainStreetIntersectionsLatestSurveys(mainStID);
                else
                    return new DataTable();
            }
        }

        public DataTable GetRegionDistrictLatestSurveys(int regionID, string subdistrict, string districtName, string municName, bool forRegion, bool forSubdist,
          bool forDist, bool forMunic) //, bool isRegionTotal)
        {
            string sql = "";

            if (forRegion) //|| isRegionTotal)
            {
                //GROUP BY SURVEY_NO 
                string regionIdPart = (regionID == 0) ? "" : string.Format(" WHERE REGION_ID={0} ", regionID);
                sql = string.Format("SELECT nvl(max(SURVEY_NO), 0) as SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (max(SURVEY_NO)|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM GV_SEC_ST_DISTRESS {0} " +
                    " order by SURVEY_NO ", regionIdPart);
            }
            else if (forSubdist)
            {
                string subdistrictPart = (string.IsNullOrEmpty(subdistrict) || subdistrict == "0") ? "" : string.Format(" WHERE subdistrict='{0}' ", subdistrict);
                sql = string.Format("SELECT nvl(max(SURVEY_NO), 0) as SURVEY_NO,  to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (max(SURVEY_NO)|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM GV_SEC_ST_DISTRESS  {0} " +
                    " order by SURVEY_NO ", subdistrictPart);
            }
            else if (forDist)
            {
                string districtNamePart = (string.IsNullOrEmpty(districtName) || districtName == "0") ? "" : string.Format(" WHERE DIST_NAME='{0}' ", districtName);
                sql = string.Format("SELECT nvl(max(SURVEY_NO), 0) as SURVEY_NO,  to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (max(SURVEY_NO)|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM GV_SEC_ST_DISTRESS  {0} " +
                    " order by SURVEY_NO ", districtNamePart);
            }
            else if (forMunic)
            {
                string municNamePart = (string.IsNullOrEmpty(municName) || municName == "0") ? "" : string.Format(" WHERE MUNIC_NAME='{0}' ", municName);
                sql = string.Format("SELECT nvl(max(SURVEY_NO), 0) as SURVEY_NO,  to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " (max(SURVEY_NO)|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM GV_SEC_ST_DISTRESS  {0} " +
                    " order by SURVEY_NO ", municNamePart);
            }

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable GetMainStreetLatestSurveys(int mainStID)
        {
            // MAIN_STREET_ID
            string mainStPart = (mainStID == 0) ? "" : string.Format(" WHERE  STREET_ID={0} ", mainStID);
            string sql = string.Format("SELECT max(SURVEY_NO) as SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (max(SURVEY_NO) || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy')) survey_title FROM GV_SAMPLE_DISTRESS {0} order by SURVEY_No ", mainStPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsLatestSurveys(int mainStID)
        {
            string mainStPart = (mainStID == 0) ? "" : string.Format(" WHERE  STREET_ID={0} ", mainStID);
            string sql = string.Format("SELECT max(SURVEY_NO) as SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (max(SURVEY_NO) || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) survey_title FROM GV_interS_SMPL_DISTRESS {0} " +
                " order by SURVEY_No ", mainStPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSectionLatestSurvey(int sectionID)
        {
            string mainStPart = (sectionID == 0) ? "" : string.Format(" WHERE  SECTION_ID={0} ", sectionID);
            string sql = string.Format("SELECT nvl(max(SURVEY_NO), 0) as SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (max(SURVEY_NO) || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy')) survey_title FROM GV_SAMPLE_DISTRESS {0} order by SURVEY_No desc ", mainStPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionLatestSurvey(int interID)
        {
            string mainStPart = (interID == 0) ? "" : string.Format(" WHERE  INTERSECTION_ID={0} ", interID);
            string sql = string.Format("SELECT nvl(max(SURVEY_NO), 0) as SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (max(SURVEY_NO) || '- ' || to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) survey_title FROM GV_interS_SMPL_DISTRESS {0} " +
                " order by SURVEY_No desc ", mainStPart);

            return db.ExecuteQuery(sql);
        }

        #endregion


        #region GettingNextSurveyNumber

        public static int GetNextSecondaryRegionSurveyNumber(int RegionId)
        {
            if (RegionId == 0)
                return 0;

            string sql = string.Format("SELECT  max(nvl(SURVEY_NO, 0))+1 FROM DISTRESS WHERE region_id={0} ", RegionId); // SECOND_ID
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
                return 1;
            else if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 1;
            else 
                return int.Parse(dt.Rows[0][0].ToString());

            //return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0][0].ToString());

        }
        public static int GetNextSectionSurveyNumber(int sampleID)
        {
            if (sampleID == 0)
                return 0;

            //OracleDatabaseClass db = new OracleDatabaseClass();

            string sql = string.Format("SELECT  (nvl(max(SURVEY_NO), 0)+1) as new_survey_num FROM DISTRESS WHERE SAMPLE_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE order by survey_no desc  ", sampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0][0].ToString());
            //if (dt.Rows.Count == 0)
            //    return 1;
            //else
            //    return int.Parse(dt.Rows[0]["new_survey_num"].ToString());
            //return int.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        }

        public static int GetNextIntersectionSurveyNumber(int intersectionSampleID)
        {
            if (intersectionSampleID == 0)
                return 0;

            //OracleDatabaseClass db = new OracleDatabaseClass();
            //return int.Parse(db.ExecuteScalar(sql).ToString());

            string sql = string.Format("SELECT  max(nvl(SURVEY_NO, 0))+1 FROM DISTRESS WHERE INTER_SAMP_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE order by survey_no desc  ", intersectionSampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0][0].ToString());
        }

        public static int GetNextSecondaryStreetSurveyNumber(int secondaryStreetID)
        {
            if (secondaryStreetID == 0)
                return 0;

            //OracleDatabaseClass db = new OracleDatabaseClass();
            //return int.Parse(db.ExecuteScalar(sql).ToString());

            string sql = string.Format("SELECT  max(nvl(SURVEY_NO, 0))+1 FROM DISTRESS WHERE STREET_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE order by survey_no desc  ", secondaryStreetID); // SECOND_ID
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0][0].ToString());
        }


        public static string GetRegionCurrentSurveyDate(int regionID, int survey)
        {
            if (regionID == 0 || survey == 0)
                return "";

            string sql = string.Format("SELECT  nvl(to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN'''), '') as SURVEY_date FROM DISTRESS WHERE region_id={0} " +
                " and SURVEY_NO={1} GROUP BY SURVEY_NO, SURVEY_DATE order by survey_no desc ", regionID, survey);

            return new OracleDatabaseClass().ExecuteScalar(sql).ToString();
        }

        public static string GetIntersectCurrentSurveyDate(int intersectID, int survey)
        {
            if (intersectID == 0 || survey == 0)
                return "";

            string sql = string.Format("SELECT  nvl(to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN'''), '') as SURVEY_date FROM DISTRESS " +
                " WHERE INTERSECTION_ID={0} and SURVEY_NO={1} GROUP BY SURVEY_NO, SURVEY_DATE order by survey_no desc ", intersectID, survey);

            return new OracleDatabaseClass().ExecuteScalar(sql).ToString();
        }

        public static string GetSectionCurrentSurveyDate(int sectionID, int survey)
        {
            if (sectionID == 0 || survey == 0)
                return "";

            string sql = string.Format("SELECT  nvl(to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN'''), '') as SURVEY_date FROM DISTRESS WHERE " +
                " SECTION_ID={0} and SURVEY_NO={1} GROUP BY SURVEY_NO, SURVEY_DATE order by survey_no desc ", sectionID, survey);

            return new OracleDatabaseClass().ExecuteScalar(sql).ToString();
        }

        #endregion


        #region GettingLastSurveyNumber

        public static int GetLastSectionSurveyNumber(int sampleID)
        {
            if (sampleID == 0)
                return 0;

            string sql = string.Format("SELECT  (nvl(max(SURVEY_NO), 0)) as last_survey_num FROM DISTRESS WHERE SAMPLE_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE order by SURVEY_DATE desc ", sampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0]["last_survey_num"].ToString());
        }

        public static int GetLastIntersectionSurveyNumber(int intersectSampleID)
        {
            if (intersectSampleID == 0)
                return 0;

            string sql = string.Format("SELECT  (nvl(max(SURVEY_NO), 0)) as last_survey_num FROM DISTRESS WHERE INTER_SAMP_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE order by SURVEY_DATE desc  ", intersectSampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0]["last_survey_num"].ToString());
            //if (dt.Rows.Count == 0)
            //    return 1;
            //else
            //    return int.Parse(dt.Rows[0]["last_survey_num"].ToString());
        }

        public static int GetLastSecondaryStreetSurveyNumber(int secondaryStID)
        {
            if (secondaryStID == 0)
                return 0;

            string sql = string.Format("SELECT  nvl(max(SURVEY_NO), 0) as last_survey_num FROM DISTRESS WHERE STREET_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE order by SURVEY_DATE desc  ", secondaryStID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql); // SECOND_ID
            return (dt.Rows.Count == 0) ? 1 : int.Parse(dt.Rows[0]["last_survey_num"].ToString());
        }

        #endregion



        #region SampleHasSurveyOn

        public bool SampleHasSurveys(int sampleID)
        {
            if (sampleID == 0)
                return false;

            string sql = string.Format("SELECT  SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE FROM DISTRESS  WHERE SAMPLE_ID={0} GROUP BY SURVEY_NO,SURVEY_DATE ORDER BY SURVEY_NO", sampleID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count != 0);
        }

        public bool IntersectionSampleHasSurveys(int intersectSampleID)
        {
            if (intersectSampleID == 0)
                return false;

            string sql = string.Format("SELECT SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE FROM DISTRESS WHERE INTER_SAMP_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE ORDER BY SURVEY_NO ", intersectSampleID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count > 0);
        }

        public bool SecondaryStreetSampleHasSurveys(int secondaryStID)
        {
            if (secondaryStID == 0)
                return false;

            string sql = string.Format("SELECT DISTINCT SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE FROM DISTRESS WHERE STREET_ID={0} GROUP BY SURVEY_NO, SURVEY_DATE ORDER BY SURVEY_NO ", secondaryStID);
            DataTable dt = db.ExecuteQuery(sql); // SECOND_ID
            return (dt.Rows.Count > 0);
        }

        #endregion



        public static DataTable GetSectionSampleSurveyNumDate(int sampleID, int surveyNo)
        {
            if (sampleID == 0 || surveyNo == 0)
                return new DataTable();

            string sql = string.Format("SELECT distinct SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE FROM DISTRESS WHERE SAMPLE_ID={0} and SURVEY_NO={1} order by SURVEY_DATE desc ", sampleID, surveyNo);
            return new OracleDatabaseClass().ExecuteQuery(sql);
        }

        public static DataTable GetIntersectSampleSurveyNumDate(int sampleID, int surveyNo)
        {
            if (sampleID == 0 || surveyNo == 0)
                return new DataTable();

            string sql = string.Format("SELECT distinct SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE FROM DISTRESS WHERE INTER_SAMP_ID={0} and SURVEY_NO={1} order by SURVEY_DATE desc ", sampleID, surveyNo);
            return new OracleDatabaseClass().ExecuteQuery(sql);
        }

        public static DataTable GetRegionSeondaryStreetSampleSurveyNumDate(int secondaryStID, int surveyNo)
        {
            if (secondaryStID == 0 || surveyNo == 0)
                return new DataTable();

            string sql = string.Format("SELECT distinct SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE FROM DISTRESS WHERE STREET_ID={0} and SURVEY_NO={1} order by SURVEY_DATE desc ", secondaryStID, surveyNo);
            return new OracleDatabaseClass().ExecuteQuery(sql);
        }

        public DataTable GetSurveyedAreas(RoadType type)
        {
            int survey_no = 3;
            string sql = "";
            switch (type)
            {
                case RoadType.Section:
                    sql = "select main_no, main_name, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date from GV_SAMPLE_DISTRESS where survey_no="
                        + survey_no.ToString() + " group by main_no, main_name, survey_no order by arname "; // main_no 
                    break;

                case RoadType.Intersect:
                    sql = "select main_no, main_name, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date " +
                        " from GV_INTERSECTION_DISTRESS where survey_no=" + survey_no.ToString() + " group by main_no, main_name, survey_no order by arname ";
                    break;

                case RoadType.RegionSecondarySt:
                    sql = "select d.region_no, subdistrict, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date, " +
                        " (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area  " +
                        " from GV_SEC_ST_DISTRESS d where survey_no= " + survey_no.ToString() + "group by d.region_no, subdistrict, survey_no, region_id order by d.region_no ";
                    break; // secondary_streets 

                default:
                    break;
            }

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable GetSurveyedAreasWithDateRegions(string MonthYear,string SURVEY_NO, bool IsAll = false, bool IsReport = true)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (!IsAll && (SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;

            string sql = null;
            if (IsAll)
            {
                if (string.IsNullOrEmpty(SURVEY_NO))
                    sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area  
                         from jpmms.GV_SEC_ST_DISTRESS d  join   
                         jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where  
                         IS_REVIEWREPORT={0} and  d.SURVEY_NO>2
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id ", (IsReport == true ? 1 : 0));
                else
                    sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area  
                         from jpmms.GV_SEC_ST_DISTRESS d  join   
                         jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where  
                         IS_REVIEWREPORT={0} and  d.SURVEY_NO='{1}'
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id ", (IsReport == true ? 1 : 0), SURVEY_NO);
            }
            else
            {
                if (string.IsNullOrEmpty(SURVEY_NO))
                    sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area  
                         from jpmms.GV_SEC_ST_DISTRESS d  join   
                         jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where  
                         IS_REVIEWREPORT={0} and REPORTSMONTH='{1}' and REPORTSYEAR='{2}' and  d.SURVEY_NO>2
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id ", (IsReport == true ? 1 : 0), SplitMonthYear[0], SplitMonthYear[1]);
                else
                    sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area  
                         from jpmms.GV_SEC_ST_DISTRESS d  join   
                         jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where  
                         IS_REVIEWREPORT={0} and REPORTSMONTH='{1}' and REPORTSYEAR='{2}' and  d.SURVEY_NO='{3}'
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id ", (IsReport == true ? 1 : 0), SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);
            }
            //DateTime From, TO;
            //new JpmmsClasses.BL.Lookups.SystemUsers().GetMonthlyDate(Monthes, out From, out TO);
            //string sql = string.Format("select d.region_no, MUNIC_NAME, subdistrict, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date, " +
            //            " (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area  " +
            //            " from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and survey_date  between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY') " +
            //            "group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id order by d.region_no "
            //    , ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"));

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable GetSurveyedAreasWithDateInterSetions(string MonthYear, string SURVEY_NO, bool IsAll = false, bool IsReport = true, bool IS_READY = false)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (!IsAll && (SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;

            string sql = null;
            if (IsAll)
            {
                if (string.IsNullOrEmpty(SURVEY_NO))
                    sql = string.Format(@"select d.INTER_NO REGION_NO, MAIN_NAME DIST_NAME, INTEREC_STREET1 MUNIC_NAME ,INTEREC_STREET2 subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(INTERSECTION_AREA/3700, 3) from jpmms.INTERSECTIONS_AREA s where s.INTER_NO=d.INTER_NO) as region_area 
                         from JPMMS.GV_INTERSECTION_DISTRESS d  join   
                         JPMMS.INTERSECTQC Q on d.INTER_NO=Q.INTER_NO and d.SURVEY_NO = Q.SURVEY_NO where  
                         IS_REVIEWREPORT={0} and IS_READY={1} and d.SURVEY_NO>2
                         group by d.INTER_NO, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no order by MAIN_NAME asc", (IsReport == true ? 1 : 0), (IS_READY == true ? 1 : 0));
                else
                    sql = string.Format(@"select d.INTER_NO REGION_NO, MAIN_NAME DIST_NAME, INTEREC_STREET1 MUNIC_NAME ,INTEREC_STREET2 subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(INTERSECTION_AREA/3700, 3) from jpmms.INTERSECTIONS_AREA s where s.INTER_NO=d.INTER_NO) as region_area 
                         from JPMMS.GV_INTERSECTION_DISTRESS d  join   
                         JPMMS.INTERSECTQC Q on d.INTER_NO=Q.INTER_NO and d.SURVEY_NO = Q.SURVEY_NO where   
                         IS_REVIEWREPORT={0} and IS_READY={2} and  d.SURVEY_NO='{1}'
                         group by d.INTER_NO, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no order by MAIN_NAME asc", (IsReport == true ? 1 : 0), SURVEY_NO, (IS_READY == true ? 1 : 0));
            }
            else
            {
                if (string.IsNullOrEmpty(SURVEY_NO))
                    sql = string.Format(@"select d.INTER_NO REGION_NO, MAIN_NAME DIST_NAME, INTEREC_STREET1 MUNIC_NAME ,INTEREC_STREET2 subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(INTERSECTION_AREA/3700, 3) from jpmms.INTERSECTIONS_AREA s where s.INTER_NO=d.INTER_NO) as region_area 
                         from JPMMS.GV_INTERSECTION_DISTRESS d  join   
                         JPMMS.INTERSECTQC Q on d.INTER_NO=Q.INTER_NO and d.SURVEY_NO = Q.SURVEY_NO where  
                         IS_REVIEWREPORT={0} and IS_READY={3} and REPORTSMONTH='{1}' and REPORTSYEAR='{2}' and  d.SURVEY_NO>2
                         group by d.INTER_NO, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no order by MAIN_NAME asc", (IsReport == true ? 1 : 0), SplitMonthYear[0], SplitMonthYear[1], (IS_READY == true ? 1 : 0));
                else
                    sql = string.Format(@"select d.INTER_NO REGION_NO, MAIN_NAME DIST_NAME, INTEREC_STREET1 MUNIC_NAME ,INTEREC_STREET2 subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(INTERSECTION_AREA/3700, 3) from jpmms.INTERSECTIONS_AREA s where s.INTER_NO=d.INTER_NO) as region_area 
                         from JPMMS.GV_INTERSECTION_DISTRESS d  join   
                         JPMMS.INTERSECTQC Q on d.INTER_NO=Q.INTER_NO and d.SURVEY_NO = Q.SURVEY_NO where 
                         IS_REVIEWREPORT={0} and IS_READY={4} and REPORTSMONTH='{1}' and REPORTSYEAR='{2}' and  d.SURVEY_NO='{3}'
                         group by d.INTER_NO, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no order by MAIN_NAME asc", (IsReport == true ? 1 : 0), SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO, (IS_READY == true ? 1 : 0));
            }


            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable GetSurveyedAreasWithDateALL(string MonthYear, string SURVEY_NO, bool Old = false)
        {
            string sql = null;
            if (Old)
                sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS_SURVEYTHREE s where s.region_id=d.region_id) as region_area  
                         from GV_SEC_ST_DISTRESS d  where SURVEY_NO='3' and region_id in 
                         (select region_id from REPORTSQC where IS_REVIEWREPORT=1) group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id order by d.region_no", SURVEY_NO);

            else
            {
                if (string.IsNullOrEmpty(MonthYear))
                {
                    if (string.IsNullOrEmpty(SURVEY_NO))
                        sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area
                         from jpmms.GV_SEC_ST_DISTRESS d join jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where d.SURVEY_NO>2
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id");
                    else
                        sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area
                         from jpmms.GV_SEC_ST_DISTRESS d join jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where d.SURVEY_NO='{0}'
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id", SURVEY_NO);
                }
                else
                {
                    string[] SplitMonthYear = MonthYear.Split('|');
                    if (string.IsNullOrEmpty(SURVEY_NO))
                        sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area  
                         from jpmms.GV_SEC_ST_DISTRESS d  join jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where  
                         REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and  d.SURVEY_NO>2
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id ", SplitMonthYear[0], SplitMonthYear[1]);
                    else
                        sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as region_area  
                         from jpmms.GV_SEC_ST_DISTRESS d  join jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where  
                         REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and  d.SURVEY_NO='{2}'
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id ", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);
                }
            }
            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable GetSurveyedAreasWithDateALLGIS(string MonthYear)
        {

            string sql = null;
            if (string.IsNullOrEmpty(MonthYear))
                sql = @"select d.region_no, MUNIC_NAME, subdistrict, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area  
                         from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and region_id in 
                         (select region_id from REPORTSQC) and REGION_NO not in (select REGION_NO from STREETS
                          where REGION_NO is not null and region_id is not null group by REGION_NO,SECOND_ST_NO
                          having count(SECOND_ST_NO)>1 ) group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id order by d.region_no";
            else
            {
                string[] SplitMonthYear = MonthYear.Split('|');
                sql = string.Format(@"select d.region_no, MUNIC_NAME, subdistrict, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,
                         (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area  
                         from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and region_id in 
                         (select region_id from REPORTSQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}'  and REGION_NO not in (select REGION_NO from STREETS
                          where REGION_NO is not null and region_id is not null group by REGION_NO,SECOND_ST_NO
                          having count(SECOND_ST_NO)>1 )) group by d.region_no, MUNIC_NAME, subdistrict, survey_no, region_id order by d.region_no", SplitMonthYear[0], SplitMonthYear[1]);
            }
            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable GetSurveyedAreasWithDate(DateTime? From, DateTime? TO)
        {
            string sql = string.Format("select d.region_no, subdistrict, survey_no, to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date, " +
                        " (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area  " +
                        " from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and survey_date  between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY') " +
                        "group by d.region_no, subdistrict, survey_no, region_id order by d.region_no "
                , ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"));
            ;
            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable GetDailySurveyAreas(DateTime? from)
        {
            if (from == null)
                return new DataTable();

            string sql = string.Format(" SELECT ENTRY_DATE, sum(nvl(SECTION_SAMPLE_AREA, 0)) as SECTION_SAMPLE_AREA, sum(nvl(INTERSECT_SAMPLE_AREA, 0)) as INTERSECT_SAMPLE_AREA, " +
                " sum(nvl(SECOND_ST_AREA, 0)) as SECOND_ST_AREA, REGION_NO, SECTION_NO, INTER_NO FROM VW_DAILY_ENTRY_DISTRESS_AREAS " +
                " where entry_date between '{0}' and '{0}' group by entry_date, REGION_NO, SECTION_NO, INTER_NO ", ((DateTime)from).ToString("dd/MM/yyyy"));

            return db.ExecuteQuery(sql);
        }


        #region Must re-Survey

        public DataTable GetNetworkItemMustReSurvey(bool sections, bool intersects, bool region)
        {
            string sql = "";
            if (sections)
                sql = "select * from VW_RE_SURVEY_SECTIONS ";
            else if (intersects)
                sql = "select * from VW_RE_SURVEY_INTERSECT ";
            else if (region)
                sql = "select * from VW_RE_SURVEY_REGIONS ";

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public static bool SectionMustReSurvey(int sectionID)
        {
            string sql = string.Format("select * from VW_RE_SURVEY_SECTIONS where section_id={0} ", sectionID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count > 0);
        }

        public static bool IntersectionMustReSurvey(int intersectID)
        {
            string sql = string.Format("select * from VW_RE_SURVEY_INTERSECT where section_id={0} ", intersectID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count > 0);
        }

        public static bool RegionMustReSurvey(int regionID)
        {
            string sql = string.Format("select * from VW_RE_SURVEY_REGIONS where section_id={0} ", regionID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            return (dt.Rows.Count > 0);
        }

        public DataTable GetNonSurveyedRoadNetwork(bool sections, bool intersects, bool region, bool nonCompleteRegions, bool closedRegions)
        {
            string sql = "";
            if (sections)
                sql = "select section_no, section_title, arname from gv_sections where section_no not in (select distinct section_no from distress where section_no is not null)   order by arname, section_no ";
            else if (intersects)
                sql = "select inter_no, intersect_title, arname from gv_intersection where inter_no not in (select distinct inter_no from distress where inter_no is not null)   order by arname, inter_no ";
            else if (region)
                sql = "select region_no, subdistrict, dist_name, munic_name, NOTES from regions where region_no not in (select distinct region_no from distress where region_no is not null) and SURVEYABLE=1   order by region_no ";
            else if (nonCompleteRegions)
                sql = "select distinct region_no, subdistrict, dist_name, munic_name, '' as NOTES from gv_sec_street s  where region_no in (select region_no from udi_region)  " + 
                    " and street_id not in (select street_id from udi_secondary) and notes is null   order by region_no  ";
            else if (closedRegions)
                sql = "select region_no, subdistrict, dist_name, munic_name, NOTES from regions where SURVEYABLE=0   order by region_no ";

            else
                return new DataTable();


            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable GetSurveyedRoadNetwork(bool sections, bool intersects)
        {
            string sql = "";
            if (sections)
                sql = "select section_no, section_title, arname from gv_sections where section_no in (select distinct section_no from distress where section_no is not null)  order by arname, section_no ";
            else if (intersects)
                sql = "select inter_no, intersect_title, arname from gv_intersection where inter_no in (select distinct inter_no from distress where inter_no is not null)  order by arname, inter_no ";
            else
                return new DataTable();


            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable GetNonCompleteSurveyStreets(bool intersects)
        {
            string sql = "";
            if (intersects)
                sql = @"select distinct main_no, arname, arname as main_name from intersections where intersection_id in (select intersection_id from udi_intersection)
                    and street_id in (select street_id from intersections where intersection_id not in (select intersection_id from udi_intersection))
                    order by arname";
            else
                sql = @"select distinct main_no, arname, arname as main_name from sections where section_id in (select section_id from udi_section)
                        and street_id in (select street_id from sections where section_id not in (select section_id from jpmms.udi_section))
                        order by arname ";

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable GetNonSurveyedStreets(bool intersects)
        {
            string sql = "";
            if (intersects)
                sql = @"select distinct main_no, arname, arname as main_name from jpmms.streets 
                        where street_id not in(select distinct street_id from jpmms.UDI_INTERSECTION)
                        and street_id in (select distinct street_id from jpmms.intersections) 
                        and street_type=1   order by arname";
            else
                sql = @"select distinct main_no, arname, arname as main_name from jpmms.streets 
                        where street_id not in(select distinct street_id from jpmms.UDI_sections)
                        and street_id in (select distinct street_id from jpmms.sections)
                        and street_type=1     order by arname";

            //            if (intersects)
            //                sql = @"select distinct main_no, arname, arname as main_name from gv_intersection 
            //                        where intersection_id not in(select distinct intersection_id from GV_INTERSECTION_DISTRESS)    order by arname";
            //            else
            //                sql = @"select distinct main_no, arname, arname as main_name from gv_sections
            //                        where section_id not in(select distinct section_id from GV_SAMPLE_DISTRESS)      order by arname";

            //            if (intersects)
            //                sql = @"select maiN_no, arname, arname as main_name  from streets where street_type=1 
            //                    and STREET_ID not in (select distinct STREET_ID from GV_INTERSECTION_DISTRESS) order by arname";
            //            else
            //                sql = @"select maiN_no, arname, arname as main_name  from streets where street_type=1 
            //                        and STREET_ID not in (select distinct STREET_ID from GV_SAMPLE_DISTRESS) order by arname";

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        #endregion


    }
}
