using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.AhmedYousif;
//using Oracle.DataAccess.Client;
using System.Web;
using System.Diagnostics;

namespace JpmmsClasses.BL
{
    public class MaintenanceDecisions
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private DistressSurvey survey = new DistressSurvey();
        private Region region = new Region();
        private Municpiality munic = new Municpiality();

        //private DataTable dtMaintAffectedArea;
        //private int recordsAffected = 0;



        #region Reporting

        public DataTable GetMaintenanceDecisionsForMainStreetLanes(int mainStID, bool forServiceLanes, int surveyNum)
        {
            if (mainStID == 0) //|| survey == 0)
                return new DataTable();

            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, true, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            // MAINTE_DECI   MAIN_STREET_ID
            string sql = string.Format("SELECT * FROM VW_MAINT_DEC_IRI_LSAMPLES where STREET_ID={0} and SURVEY_NO={1}  ORDER BY SECTION_NO, LANE_TYPE, SAMPLE_NO ", mainStID, surveyNum);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForMainStreetLanes(int mainStID)
        {
            if (mainStID == 0) //|| survey == 0) // , bool forServiceLanes
                return new DataTable();

            string sql = string.Format("SELECT * FROM VW_LATEST_MD_LANE_SAMPLES where STREET_ID={0} ORDER BY SECTION_NO, LANE_TYPE, SAMPLE_NO ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForMainStreetLanes(string municName)
        {
            if (municName == "0" || string.IsNullOrEmpty(municName))
                return new DataTable();

            string municNum = munic.GetMunicNo(municName);
            string sql = string.Format("SELECT * FROM VW_LATEST_MD_LANE_SAMPLES where section_no like '{0}%' ORDER BY arname, SECTION_NO, LANE_TYPE, SAMPLE_NO ", municNum);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForRegionSurroundingSections(int regionID, int surveyNum)
        {
            if (regionID == 0)
                return new DataTable();

            string regionNum = region.GetRegionNum(regionID);   // MAINTE_DECI 
            string sql = string.Format("SELECT * FROM VW_MAINT_DEC_IRI_LSAMPLES where SECTION_NO like '{0}%' and SURVEY_NO={1}  ORDER BY SECTION_NO, LANE_TYPE, SAMPLE_NO ", regionNum, surveyNum);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForRegionSurroundingSections(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string regionNum = region.GetRegionNum(regionID); // bool forServiceLanes,
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from VW_MAINT_DEC_IRI_LSAMPLES where SECTION_NO like '{0}%') ", regionNum); VW_MAINT_DEC_IRI_LSAMPLES
            string sql = string.Format("SELECT * FROM VW_LATEST_MD_LANE_SAMPLES where SECTION_NO like '{0}%'  ORDER BY arname, SECTION_NO, LANE_TYPE, SAMPLE_NO ", regionNum);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetMaintenanceDecisionsForMainStreetIntersections(int mainStID, int surveyNum)
        {
            if (mainStID == 0) //|| survey == 0)
                return new DataTable();

            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, false, true);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            // MIDINT_MAINTE_DECI ,  INTERSECTION_ORDER,        MAIN_STREET_ID
            string sql = string.Format("SELECT * FROM VW_MAINT_DEC_IRI_INTER_SAMPLES where STREET_ID={0} and SURVEY_NO={1} ORDER BY MAIN_NO, INTER_NO, INTER_SAMP_NO ", mainStID, surveyNum);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForMainStreetIntersections(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM VW_LATEST_MD_INTERSAMP where SURVEY_NO>2 and STREET_ID={0} ORDER BY arname, INTER_NO, INTER_SAMP_NO ", mainStID);           
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForMainStreetIntersections(string municName)
        {
            if (municName == "0" || string.IsNullOrEmpty(municName))
                return new DataTable();

            string municNum = munic.GetMunicNo(municName);
            string sql = string.Format("SELECT * FROM VW_LATEST_MD_INTERSAMP where inter_no like '{0}%' ORDER BY arname, INTER_NO, INTER_SAMP_NO ", municNum);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetMaintenanceDecisionsForRegion(int regionID, int surveyNum, bool details, int secondID)
        {
            //if (string.IsNullOrEmpty(regionNo)) //|| survey == 0)
            if (regionID == 0)
                return new DataTable();

            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(regionID, "", "", "", true, false, false, false, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string tableName = details ? "VW_MAINT_DEC_REGIONS_UDI" : "VW_MAINT_DEC_UDI_REGION";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string secondPart = (details && secondID != 0) ? string.Format(" and STREET_ID={0} ", secondID) : ""; // second_id

            string sql = string.Format("SELECT * FROM {2} where region_id={0} and SURVEY_NO={1} and udi_date is not null  {3} {4} ", regionID, surveyNum, tableName,
                secondPart, orderByPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForRegion(int regionID, bool details, int secondID)
        {
            if (regionID == 0)
                return new DataTable();


            string tableName = details ? "VW_LATEST_MD_SEC_ST" : "VW_LATEST_MD_REGIONS";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string secondPart = (details && secondID != 0) ? string.Format(" and STREET_ID={0} ", secondID) : ""; // second_id

            string sql = string.Format("SELECT * FROM {1} where region_id={0} and udi_date is not null  {2} {3} ", regionID, tableName, secondPart, orderByPart);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetMaintenanceDecisionsWithDate(string MonthYear)
        {
           /* DateTime From,TO ;
            new JpmmsClasses.BL.Lookups.SystemUsers().GetMonthlyDate(Monthes,out From,out TO);
            string sql = string.Format(@"select * from VW_LATEST_MD_SEC_ST where udi_date is not null and SURVEY_NO>2 and REGION_NO in (select d.region_no  from 
                        GV_SEC_ST_DISTRESS d  where SURVEY_NO>2 and survey_date between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY') 
                        group by d.region_no) ORDER BY  Second_St_No", 
                        ((DateTime)From).ToString("dd/MM/yyyy"), ((DateTime)TO).ToString("dd/MM/yyyy"));*/
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return null;
            string sql = string.Format(@"select * from VW_LATEST_MD_SEC_ST where udi_date is not null and SURVEY_NO>2 
                                        and region_id in (select d.region_id  from GV_SEC_ST_DISTRESS d  where SURVEY_NO>2  
                                        and region_id in (select region_id from REPORTSQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}')) ORDER BY  Second_St_No",  SplitMonthYear[0], SplitMonthYear[1]);

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }


        public DataTable GetMaintenanceDecisionsForSubdistrict(string subDist, int surveyNum, bool details)
        {
            if (string.IsNullOrEmpty(subDist)) //|| survey == 0)
                return new DataTable();

            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, subDist, "", "", false, true, false, false, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string tableName = details ? "VW_MAINT_DEC_REGIONS_UDI" : "VW_MAINT_DEC_UDI_REGION";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format("SELECT * FROM {2} where SUBDISTRICT='{0}' and SURVEY_NO={1} and udi_date is not null {3} ", subDist, surveyNum, tableName, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForSubdistrict(string subDist, bool details)
        {
            if (string.IsNullOrEmpty(subDist)) //|| survey == 0)
                return new DataTable();

            string tableName = details ? "VW_LATEST_MD_SEC_ST" : "VW_LATEST_MD_REGIONS";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format("SELECT * FROM {1} where SUBDISTRICT='{0}' and udi_date is not null {2} ", subDist, tableName, orderByPart);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetMaintenanceDecisionsForDistrict(string distName, int surveyNum, bool details)
        {
            if (string.IsNullOrEmpty(distName)) //|| survey == 0)
                return new DataTable();

            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", distName, "", false, false, true, false, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string tableName = details ? "VW_MAINT_DEC_REGIONS_UDI" : "VW_MAINT_DEC_UDI_REGION";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format("SELECT * FROM {2} where DIST_NAME='{0}' and SURVEY_NO={1} and udi_date is not null {3} ", distName, surveyNum, tableName, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForDistrict(string distName, bool details)
        {
            if (string.IsNullOrEmpty(distName)) //|| survey == 0)
                return new DataTable();

            string tableName = details ? "VW_LATEST_MD_SEC_ST" : "VW_LATEST_MD_REGIONS";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format("SELECT * FROM {1} where DIST_NAME='{0}' and udi_date is not null {2} ", distName, tableName, orderByPart);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetMaintenanceDecisionsForMunicipality(string municName, int surveyNum, bool details)
        {
            if (string.IsNullOrEmpty(municName)) //|| survey == 0)
                return new DataTable();

            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", "", municName, false, false, false, true, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string tableName = details ? "VW_MAINT_DEC_REGIONS_UDI" : "VW_MAINT_DEC_UDI_REGION";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format("SELECT * FROM {2} where MUNIC_NAME='{0}' and SURVEY_NO={1} and udi_date is not null {3} ", municName, surveyNum, tableName, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenanceDecisionsForMunicipality(string municName, bool details)
        {
            if (string.IsNullOrEmpty(municName)) //|| survey == 0)
                return new DataTable();

            string tableName = details ? "VW_LATEST_MD_SEC_ST" : "VW_LATEST_MD_REGIONS";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format("SELECT * FROM {1} where MUNIC_NAME='{0}' and udi_date is not null {2} ", municName, tableName, orderByPart);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMaintenanceDecisionsForMunicipality(string municName, bool details, DateTime? from, DateTime? to)
        {
            if (string.IsNullOrEmpty(municName) || from == null || to == null) //|| survey == 0)
                return new DataTable();

            string tableName = details ? "VW_LATEST_MD_SEC_ST" : "VW_LATEST_MD_REGIONS";
            string orderByPart = details ? " ORDER BY REGION_NO, Second_St_No " : " ORDER BY REGION_NO ";
            string sql = string.Format(
                "SELECT * FROM {1} where MUNIC_NAME='{0}' and udi_date is not null and SURVEY_DATE BETWEEN TO_DATE('{3}','DD/MM/YYYY') AND TO_DATE('{4}','DD/MM/YYYY') {2} "
                , municName, tableName, orderByPart, from.Value.ToString("dd/MM/yyyy"), to.Value.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintDecisionUdi(bool section, bool intersect, bool region, int itemID)
        {
            //sql = string.Format("SELECT * FROM VW_MAINT_DEC_IRI_INTERSECT where INTERSECTION_ID={0}   ", itemID);
            string sql = "";
            if (section)
                sql = string.Format("SELECT * FROM VW_MAINT_DEC_IRI_SECTIONS where SECTION_ID={0}  ORDER BY survey_no ", itemID);
            else if (intersect)
                sql = string.Format("select survey_no, survey_date, avg(udi) as udi,  DECODE (avg(udi), NULL, ' Not Evaluated', GREATEST (avg(udi), 89.99), 'Excellent', GREATEST (avg(udi), 69.99), 'Good', GREATEST (avg(udi), 39.99), 'Fair', GREATEST (avg(udi), 0), 'Poor') AS udi_rate, RECOMMENDED_DECISION, sum(MAINT_AREA) as maint_area  from VW_MAINT_DEC_IRI_INTER_SAMPLES where INTERSECTION_ID={0}   group by survey_no, survey_date, RECOMMENDED_DECISION ", itemID);
            else if (region)
                sql = string.Format("SELECT * FROM VW_MAINT_DEC_REGIONS_UDI where STREET_ID={0}  ", itemID); // SECOND_ID
            else
                return new DataTable();

            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }

        #endregion


        #region SurveyNumber

        public DataTable GetSurveyNumbersForMainStreetLanesMaintenanceDecisions(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            //string sql1 = string.Format("SELECT  SURVEY_NO, SURVEY_DATE, (SURVEY_NO|| '- '|| to_char(SURVEY_DATE, 'dd/MM/yyyy')) as survey_title  FROM prevent_maint_decisions WHERE lane_id in(select lane_id from GV_LANE where main_street_id={0}) GROUP BY SURVEY_NO, SURVEY_DATE  ", mainStID);
            //string sql2 = string.Format("SELECT  SURVEY_NO, SURVEY_DATE, (SURVEY_NO|| '- '|| to_char(SURVEY_DATE, 'dd/MM/yyyy')) as survey_title  FROM STRUCT_MAINT_DECISION WHERE lane_id in(select lane_id from GV_LANE where main_street_id={0}) GROUP BY SURVEY_NO, SURVEY_DATE ORDER BY SURVEY_DATE desc ", mainStID);
            //string sql = string.Format("{0} union {1} ", sql1, sql2);
            string sql = string.Format("SELECT  SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy')) as survey_title  " +
                " FROM MAINTENANCE_DECISIONS WHERE STREET_ID={0} and section_no is not null GROUP BY SURVEY_NO ", mainStID); // MAIN_ST_ID

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyNumbersForMainStreetIntersectionsMaintenanceDecisions(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("SELECT  SURVEY_NO, to_char(max(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM MAINTENANCE_DECISIONS " +
                " WHERE STREET_ID={0} and inter_no is not null GROUP BY SURVEY_NO ", mainStID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyNumbersForRegionMaintenanceDecisions(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format("SELECT  SURVEY_NO, to_char(max(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM MAINTENANCE_DECISIONS " +
                " WHERE region_id={0}  GROUP BY SURVEY_NO ", regionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSurveyNumbersForRegionMaintenanceDecisions()
        {
            string sql = "SELECT  SURVEY_NO, to_char(max(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(max(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title  FROM MAINTENANCE_DECISIONS " +
                " where region_no is not null   GROUP BY SURVEY_NO ";

            return db.ExecuteQuery(sql);
        }

        #endregion


        private enum MaintenaceDecision
        {
            DoNothing = 0,
            //SlurrySeal = 1,
            CrackSealing = 2,
            ThinOverlay = 3,
            SurfacePatching = 4,
            DeepPatching = 5,
            ReConstruction = 6,
            BaseRepairRePave = 7,
            MillRePave = 8,
            //HotSandSprayRoll = 9,
            RePaveOverlay = 10,
            MillRepave15cm = 11,
            MillRepave5cm = 12,
            MillRepave15cmmax = 13
        }




        private UDI.SectionsUDI secUDI = new UDI.SectionsUDI();
        private UDI.IntersectionUDI intersectUDI = new UDI.IntersectionUDI();
        private UDI.RegionSecondaryStUDI regionSecStUDI = new UDI.RegionSecondaryStUDI();

        private C_Maint_Decision maintD = new C_Maint_Decision();
        private DistressSurvey distSurvey = new DistressSurvey();



        #region Maintenance Decisions For Sections

        public bool PrepareMainStreetSectionsMaintenanceDecisions(int mainStID, string user, bool wholeNetwork)
        {
            bool result = true;
            DataTable dt;
            if (wholeNetwork)
                dt = distSurvey.GetRegionsAndMainStreetSectionIntersections(0, "", "", "", false, false, false, false, mainStID, true, false);
            else
                dt = distSurvey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, true, false);

            foreach (DataRow dr in dt.Rows)
                result &= PrepareMainStreetSectionsMaintenanceDecisions(mainStID, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        /// <summary>
        /// Calcualtes Main Street Sections UDI, then Maintenance Decisions by Main Street ID and Survey Number
        /// </summary>
        /// <param name="mainStID"></param>
        /// <param name="surveyNum"></param>
        /// <returns></returns>
        public bool PrepareMainStreetSectionsMaintenanceDecisions(int mainStID, int surveyNum, string user)
        {
            if (mainStID == 0 || surveyNum == 0)
                return false;

            bool udi_ed = secUDI.CalculateMainStreetSectionsUDI(mainStID, surveyNum, user);
            bool removed = maintD.RemoveSectionsPreviousMaintDecisions(mainStID, surveyNum);
            bool maint_ed = maintD.CalculateMD_4_StreetLanes(mainStID, surveyNum);

            Shared.SaveLogfile("MAINTENANCE_DECISIONS", mainStID.ToString(), "MAINTENANCE DECISIONS - Main Street Sections:" + mainStID.ToString(), user);

            return (udi_ed && removed && maint_ed);
        }

        #endregion

        #region Maintenance Decisions for Intersections

        public bool PrepareMainStreetIntersectionsMaintenanceDecisions(int mainStID, string user, bool wholeNetwork)
        {
            bool result = true;
            DataTable dt;
            if (wholeNetwork)
                dt = distSurvey.GetRegionsAndMainStreetSectionIntersections(0, "", "", "", false, false, false, false, mainStID, false, true);
            else
                dt = distSurvey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, false, true);

            foreach (DataRow dr in dt.Rows)
                result &= PrepareMainStreetIntersectionsMaintenanceDecisions(mainStID, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        /// <summary>
        /// Calcualtes Main Street Intersections UDI, then Maintenance Decisions by Main Street ID and Survey Number
        /// </summary>
        /// <param name="mainStID"></param>
        /// <param name="surveyNum"></param>
        /// <returns></returns>
        public bool PrepareMainStreetIntersectionsMaintenanceDecisions(int mainStID, int surveyNum, string user)
        {
            if (mainStID == 0 || surveyNum == 0)
                return false;

            bool udi_ed = intersectUDI.CalculateMainStreetIntersectionsUDI(mainStID, surveyNum, user);
            bool removed = maintD.RemoveIntersectionsPreviousMaintDecisions(mainStID, surveyNum);
            bool maint_ed = maintD.CalculateMaintenanceDecisionForStreetIntersections(mainStID, surveyNum);

            Shared.SaveLogfile("MAINTENANCE_DECISIONS", mainStID.ToString(), "MAINTENANCE DECISIONS - Main Street Intersections:" + mainStID.ToString(), user);

            return (udi_ed && removed && maint_ed);
        }

        #endregion

        #region Maintenance Decisions For Regions

        public bool PrepareRegionSecondaryStreetsMaintenanceDecisions(int regionID, string user, bool wholeNetwork)
        {
            bool result = true;
            DataTable dt;
            if (wholeNetwork)
                dt = distSurvey.GetRegionsAndMainStreetSectionIntersections(regionID, "", "", "", true, false, false, false, 0, false, false);
            else
                dt = distSurvey.GetLastSurveyForRoadsNetwork(regionID, "", "", "", true, false, false, false, 0, false, false);

            foreach (DataRow dr in dt.Rows)
                result &= PrepareRegionSecondaryStreetsMaintenanceDecisions(regionID, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        /// <summary>
        /// Calculates UDI then Maintenance decisions for Region by Survey
        /// </summary>
        /// <param name="regionID"></param>
        /// <param name="surveyNum"></param>
        /// <returns></returns>
        public bool PrepareRegionSecondaryStreetsMaintenanceDecisions(int regionID, int surveyNum, string user)
        {
            if (regionID == 0 || surveyNum == 0)
                return false;

            bool udi_ed = regionSecStUDI.CalculateRegionSecondaryStreetsUDI(regionID, surveyNum, user);
            bool removed = maintD.RemoveRegionsPreviousMaintDecisions(regionID, surveyNum);
            bool maint_ed = maintD.CalculateMaintenanceDecisionsForSecondaryStreet(regionID, surveyNum);

            Shared.SaveLogfile("MAINTENANCE_DECISIONS", regionID.ToString(), "MAINTENANCE DECISIONS - Region ID:" + regionID.ToString(), user);

            return (udi_ed && removed && maint_ed);
        }



        public bool PrepareSubdistrictSecondaryStreetsMaintenanceDecisions(string subdistrict, string user)
        {
            bool result = true;
            DataTable dt = new DistressSurvey().GetRegionsAndMainStreetSectionIntersections(0, subdistrict, "", "", false, true, false, false, 0, false, false);
            foreach (DataRow dr in dt.Rows)
                result &= PrepareSubdistrictSecondaryStreetsMaintenanceDecisions(subdistrict, user);

            return result;
        }

        public bool PrepareSubdistrictSecondaryStreetsMaintenanceDecisions(string subdistrict, int surveyNum, string user)
        {
            bool done = true;
            string sql = string.Format("select REGION_ID from regions where SUBDISTRICT='{0}' ", subdistrict);
            DataTable dtRegionsSubDistrict = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionsSubDistrict.Rows)
                done &= PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), surveyNum, user);

            return done; // (recordsAffected > 0);
        }

        public bool PrepareDistrictSecondaryStreetsMaintenanceDecisions(string district, string user)
        {
            bool result = true;
            DataTable dt = new DistressSurvey().GetRegionsAndMainStreetSectionIntersections(0, "", district, "", false, false, true, false, 0, false, false);
            foreach (DataRow dr in dt.Rows)
                result &= PrepareDistrictSecondaryStreetsMaintenanceDecisions(district, user);

            return result;
        }

        public bool PrepareDistrictSecondaryStreetsMaintenanceDecisions(string district, int surveyNum, string user)
        {
            bool done = true;
            string sql = string.Format("select REGION_ID from regions where DIST_NAME='{0}' ", district);
            DataTable dtRegionsSubDistrict = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionsSubDistrict.Rows)
                done &= PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), surveyNum, user);

            return done; //(recordsAffected > 0);
        }

        public bool PrepareMunicipalitySecondaryStreetsMaintenanceDecisions(string municName, string user)
        {
            bool result = true;
            DataTable dt = new DistressSurvey().GetRegionsAndMainStreetSectionIntersections(0, "", "", municName, false, false, false, true, 0, false, false);
            foreach (DataRow dr in dt.Rows)
                result &= PrepareMunicipalitySecondaryStreetsMaintenanceDecisions(municName, user);

            return result;
        }

        public bool PrepareMunicipalitySecondaryStreetsMaintenanceDecisions(string municName, int surveyNum, string user)
        {
            bool done = true;
            string sql = string.Format("select REGION_ID from regions where MUNIC_NAME='{0}' ", municName);
            DataTable dtRegionsSubDistrict = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtRegionsSubDistrict.Rows)
                done &= PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), surveyNum, user);

            return done; //(recordsAffected > 0);
        }

        #endregion



        #region Searching

        public DataTable GetMainStreetSectionLaneSamplesMaintenanceDecisions(int mainStID, int survey)
        {
            if (mainStID == 0)
                return new DataTable();

            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey); // MAIN_STREET_ID
            string sql = string.Format("select * from vw_maint_dec_iri_lsamples where STREET_ID={0} {1} order by section_no, lane_type, SAMPLE_NO ", mainStID, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetSectionsMaintenanceDecisions(int mainStID, int survey)
        {
            if (mainStID == 0) //|| survey == 0)   
                return new DataTable();

            // SECTION_NO in (select section_no from sections where MAIN_STREET_ID={0})
            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_IRI_LANES where STREET_ID={0} {1} order by section_no, lane_type ", mainStID, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionSamplesMaintenanceDecisions(int mainStID, int survey)
        {
            if (mainStID == 0) //|| survey == 0)
                return new DataTable();

            // INTER_NO in (select INTER_NO from INTERSECTIONS where MAIN_STREET_ID={0}) 
            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_IRI_INTER_SAMPLES where STREET_ID={0} {1} order by inter_no, INTER_SAMP_NO ", mainStID, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsMaintenanceDecisions(int mainStID, int survey)
        {
            if (mainStID == 0) //|| survey == 0)
                return new DataTable();

            // INTER_NO in (select INTER_NO from INTERSECTIONS where MAIN_STREET_ID={0}) 
            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_IRI_INTERSECT where STREET_ID={0} {1} order by inter_no ", mainStID, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSecondaryStreetsMaintenanceDecisions(int regionID, int survey)
        {
            if (regionID == 0) //|| survey == 0)
                return new DataTable();

            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_REGIONS_UDI where region_id={0} {1} order by region_no, lpad(SECOND_NO ,10) ", regionID, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSubdistrictSecondaryStreetsMaintenanceDecisions(string subDist, int survey)
        {
            if (string.IsNullOrEmpty(subDist)) // || survey == 0)
                return new DataTable();

            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_REGIONS_UDI where region_id IN (select region_id from regions where SUBDISTRICT='{0}') {1} order by region_no,  lpad(SECOND_NO ,10) ", subDist, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetDistrictSecondaryStreetsMaintenanceDecisions(string distName, int survey)
        {
            if (string.IsNullOrEmpty(distName)) //|| survey == 0)
                return new DataTable();

            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_REGIONS_UDI where region_id IN (select region_id from regions where DIST_NAME='{0}') {1} order by region_no,  lpad(SECOND_NO ,10) ", distName, surveyPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMunicipalitySecondaryStreetsMaintenanceDecisions(string municName, int survey)
        {
            if (string.IsNullOrEmpty(municName)) //|| survey == 0)
                return new DataTable();

            string surveyPart = (survey == 0) ? "" : string.Format(" and SURVEY_NO={0} ", survey);
            string sql = string.Format("select * from VW_MAINT_DEC_REGIONS_UDI where region_id IN (select region_id from regions where MUNIC_NAME='{0}') {1} " +
                " order by region_no,  lpad(SECOND_NO ,10) ", municName, surveyPart);

            return db.ExecuteQuery(sql);
        }

        #endregion

        public DataTable GetWholeRoadsNetworkAvailableSurveys(bool sections, bool intersects, bool regions)
        {
            string wherePart = "";
            if (sections)
                wherePart = " where SECTION_ID is not null ";
            else if (intersects)
                wherePart = " where INTERSECTION_ID is not null ";
            else if (regions)
                wherePart = " where REGION_ID is not null ";
            else
                return new DataTable();

            string sql = string.Format("SELECT  SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                " (SURVEY_NO|| '- '|| to_char(MAX(SURVEY_DATE), 'dd/MM/yyyy','NLS_CALENDAR=''GREGORIAN''')) as survey_title FROM MAINTENANCE_DECISIONS {0} " +
                " GROUP BY SURVEY_NO ORDER BY SURVEY_no ", wherePart);

            return db.ExecuteQuery(sql);
        }


    }
}
