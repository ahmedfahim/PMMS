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
    public class MaintDecisionCosting
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private DistressSurvey survey = new DistressSurvey();
        private Region region = new Region();
        private Municpiality munic = new Municpiality();




        #region Searching

        public DataTable GetMainStreetSectionsMaintenanceDecisions(int mainStID, int surveyNum, bool details, bool notMaintOrders)
        {
            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, true, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }


            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and section_id not in (select SECTION_ID from MAINTAIN_ORDER_DET_LOCS where SECTION_ID is not null)  " : "";

            if (details)
            {
                if (mainStID == 0)
                    return new DataTable();
                else //MAIN_STREET_ID
                    sql = string.Format("select * from VW_SECTIONS_MAINT_COST where STREET_ID={0} and SURVEY_NO={1} {2} order by arname, section_no, lane_type ",
                        mainStID, surveyNum, notInMaintOrdersPart);
            }
            else
            {
                string mainStPart = (mainStID == 0) ? "" : string.Format(" and STREET_ID={0}  ", mainStID);
                sql = string.Format("select * from VW_SECTIONS_MAINT_COST_SUMMARY where survey_no={0} {1} {2} order by arname ", surveyNum, mainStPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetSectionsMaintenanceDecisions(int mainStID, bool details, bool notMaintOrders)
        {
            string sql = ""; // MAINTAIN_ORDER_DET_LOCS 
            string notInMaintOrdersPart = notMaintOrders ? @" and section_id not in (select SECTION_ID from VW_MAINT_ORDERS_FULL where SECTION_ID is not null and WORK_STATUS=1)  
                                                            and section_id not in (select section_id from FEEDBACK_DETAILS where SECTION_ID is not null) "
                : "";

            if (details)
            {
                if (mainStID == 0)
                    return new DataTable();
                else //MAIN_STREET_ID
                    sql = string.Format("select * from VW_LATEST_MD_LANE_SAMPLES where STREET_ID={0} {1}  order by arname, section_no, lane_type ", mainStID, notInMaintOrdersPart);
            }
            else
            {

                string mainStPart = (mainStID != 0) ? string.Format(" where STREET_ID={0}  ", mainStID) : " where STREET_ID is not null ";
                sql = string.Format("select * from VW_LATEST_MDCOST_SUM_SECTION  {0} {1} order by arname ", mainStPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }


        public DataTable GetRegionSurroundingSectionsMaintenanceDecisions(int regionID, int surveyNum, bool details, bool notMaintOrders)
        {
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and section_id not in (select SECTION_ID from MAINTAIN_ORDER_DET_LOCS where SECTION_ID is not null)  " : "";
            string regionNum = region.GetRegionNum(regionID);

            if (details)
            {
                if (regionID == 0)
                    return new DataTable();

                sql = string.Format("select * from VW_SECTIONS_MAINT_COST where section_no like '{0}%' and SURVEY_NO={1} {2} order by arname, section_no, lane_type ",
                    regionNum, surveyNum, notInMaintOrdersPart);
            }
            else
                sql = string.Format("select * from VW_SECTIONS_MAINT_COST_SUMMARY where survey_no={0} and section_no like '{1}%' {2} order by arname ",
                    surveyNum, regionNum, notInMaintOrdersPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSurroundingSectionsMaintenanceDecisions(int regionID, bool details, bool notMaintOrders)
        {
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and section_id not in (select SECTION_ID from MAINTAIN_ORDER_DET_LOCS where SECTION_ID is not null)  " : "";
            string regionNum = region.GetRegionNum(regionID);

            if (details)
            {
                if (regionID == 0)
                    return new DataTable();

                //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from VW_SECTIONS_MAINT_COST where section_no like '{0}%') ", regionNum); surveyPart, 
                sql = string.Format("select * from VW_LATEST_MD_LANE_SAMPLES where section_no like '{0}%' {1}   order by arname, section_no, lane_type ",
                    regionNum, notInMaintOrdersPart);
            }
            else
            {
                //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from VW_SECTIONS_MAINT_COST_SUMMARY where section_no like '{0}%') ", regionNum); surveyPart, 
                sql = string.Format("select * from VW_LATEST_MDCOST_SUM_SECTION where section_no like '{0}%'  {1} order by arname ",
                    regionNum, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSurroundingSectionsInMunic(string municName, bool details, bool notMaintOrders)
        {
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and section_id not in (select SECTION_ID from MAINTAIN_ORDER_DET_LOCS where SECTION_ID is not null)  " : "";
            string municNum = munic.GetMunicNo(municName);

            if (details)
            {
                if (string.IsNullOrEmpty(municName) || municName == "0")
                    return new DataTable();

                sql = string.Format("select * from VW_LATEST_MD_LANE_SAMPLES where section_no like '{0}%' {1}   order by arname, section_no, lane_type ",
                    municNum, notInMaintOrdersPart);
            }
            else
            {
                sql = string.Format("select * from VW_LATEST_MDCOST_SUM_SECTION where section_no like '{0}%'  {1} order by arname ",
                    municNum, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }



        public DataTable GetMainStreetIntersectionsMaintenanceDecisions(int mainStID, int surveyNum, bool details, bool notMaintOrders)
        {
            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, false, true);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            // MAINTENANCE_DECISIONS in (select INTER_NO from INTERSECTIONS where MAIN_STREET_ID={0})
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and INTERSECTION_ID not in (select INTERSECT_ID from MAINTAIN_ORDER_DET_LOCS where INTERSECT_ID is not null)  " : "";

            if (details)
            {
                if (mainStID == 0)
                    return new DataTable(); // MAIN_STREET_ID

                sql = string.Format("select * from VW_INTERSECTS_MAINT_COST where STREET_ID={0} and INTER_NO is not null and SURVEY_NO={1} {2} order by arname, INTER_NO ",
                    mainStID, surveyNum, notInMaintOrdersPart);
            }
            else
            {
                string mainStPart = (mainStID == 0) ? "" : string.Format(" and STREET_ID={0}  ", mainStID);
                sql = string.Format("select * from VW_INTER_MAINT_COST_SUMMARY where survey_no={0} {1} {2} order by arname ", surveyNum, mainStPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsMaintenanceDecisions(int mainStID, bool details, bool notMaintOrders)
        {
            string sql = ""; // MAINTAIN_ORDER_DET_LOCS 
            string notInMaintOrdersPart = notMaintOrders ? @" and INTERSECTION_ID not in (select INTERSECT_ID from VW_MAINT_ORDERS_FULL where INTERSECT_ID is not null and WORK_STATUS=1)  
                                                              and INTERSECTION_ID not in (select INTER_ID from FEEDBACK_DETAILS where INTER_ID is not null) "
                : "";

            if (details)
            {
                if (mainStID == 0)
                    return new DataTable(); // MAIN_STREET_ID

                sql = string.Format("select * from VW_LATEST_MD_INTERSAMP where STREET_ID={0} and INTER_NO is not null {1} order by arname, INTER_NO ",
                    mainStID, notInMaintOrdersPart);
            }
            else
            {
                string mainStPart = (mainStID == 0) ? " where STREET_ID is not null " : string.Format(" where STREET_ID={0}  ", mainStID);
                sql = string.Format("select * from VW_LATEST_MDCOST_SUM_INTER  {0} {1} order by arname ", mainStPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsMaintenanceDecisions(string municName, bool details, bool notMaintOrders)
        {
            string sql = ""; // MAINTAIN_ORDER_DET_LOCS 
            string notInMaintOrdersPart = notMaintOrders ? @" and INTERSECTION_ID not in (select INTERSECT_ID from VW_MAINT_ORDERS_FULL where INTERSECT_ID is not null and WORK_STATUS=1)  
                                                              and INTERSECTION_ID not in (select INTER_ID from FEEDBACK_DETAILS where INTER_ID is not null) "
                : "";

            string municNum = new Municpiality().GetMunicNo(municName);
            if (details)
            {
                if (municName == "0" || string.IsNullOrEmpty(municName))
                    return new DataTable();

                sql = string.Format("select * from VW_LATEST_MD_INTERSAMP where inter_no like '{0}%' and INTER_NO is not null {1}  order by arname, INTER_NO ",
                    municNum, notInMaintOrdersPart);
            }
            else
            {
                sql = string.Format("select * from VW_LATEST_MDCOST_SUM_INTER  where inter_no like '{0}%' {1}  order by arname ", municNum, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }


        public DataTable GetRegionSecondaryStreetsMaintenanceDecisions(int regionID, int surveyNum, bool details, bool notMaintOrders, int secondID)
        {
            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(regionID, "", "", "", true, false, false, false, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string sql = "";
            string secondPart = (secondID == 0) ? "" : string.Format(" and STREET_ID={0} ", secondID); // second_id
            string notInMaintOrdersPart = notMaintOrders ? " and REGION_ID not in (select REGION_ID from MAINTAIN_ORDER_DET_LOCS where REGION_ID is not null)  " : "";

            if (details)
            {
                if (regionID == 0)
                    return new DataTable();

                sql = string.Format("select * from VW_REGION_MAINT_COST where region_id={0} and SURVEY_NO={1} {2} {3} order by region_no, SECOND_NO ", regionID, surveyNum,
                    notInMaintOrdersPart, secondPart);
            }
            else
            {
                string regionPart = (regionID == 0) ? "" : string.Format(" and REGION_ID={0} ", regionID);

                sql = string.Format("select region_no, arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                    "from VW_REGIONS_MAINT_COST_SUMMARY where survey_no={0} {1} {2} " +
                    " group by region_no, arname, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no order by region_no, RECOMMENDED_DECISION_id  ",
                    surveyNum, regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSecondaryStreetsMaintenanceDecisions(int regionID, bool details, bool notMaintOrders, int secondID)
        {
            string sql = "";
            string secondPart = (secondID == 0) ? "" : string.Format(" and STREET_ID={0} ", secondID); // second_id  MAINTAIN_ORDER_DET_LOCS 
            string notInMaintOrdersPart = notMaintOrders ? @" and REGION_ID not in (select REGION_ID from VW_MAINT_ORDERS_FULL where REGION_ID is not null and WORK_STATUS=1)  
                                                              and REGION_ID not in (select REGION_ID from FEEDBACK_DETAILS where REGION_ID is not null)  "
                : "";

            if (details)
            {
                if (regionID == 0)
                    return new DataTable();

                sql = string.Format("select * from VW_LATEST_MD_SEC_ST where region_id={0} {1} {2} order by region_no, SECOND_NO ", regionID, notInMaintOrdersPart, secondPart);
            }
            else
            {
                string regionPart = "";
                if (regionID == 0)
                {
                    regionPart = "";
                    notInMaintOrdersPart = notMaintOrders ? " where REGION_ID not in (select REGION_ID from MAINTAIN_ORDER_DET_LOCS where REGION_ID is not null)  " : "";
                }
                else
                    regionPart = string.Format(" where REGION_ID={0} ", regionID);


                sql = string.Format("select region_no, arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                    "from VW_LATEST_MDCOST_SUM_REGIONS {0} {1} " +
                    " group by region_no, arname, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no order by region_no, RECOMMENDED_DECISION_id  ",
                    regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }


        public DataTable GetSubdistrictSecondaryStreetsMaintenanceDecisions(string subDist, int surveyNum, bool details, bool notMaintOrders)
        {
            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, subDist, "", "", false, true, false, false, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and REGION_ID not in (select REGION_ID from MAINTAIN_ORDER_DET_LOCS where REGION_ID is not null)  " : "";

            if (details)
            {
                if (string.IsNullOrEmpty(subDist))
                    return new DataTable();

                sql = string.Format("select * from VW_REGION_MAINT_COST where region_id IN (select region_id from regions where SUBDISTRICT='{0}') and SURVEY_NO={1} order by region_no, SECOND_NO ",
                    subDist, surveyNum);
            }
            else
            {
                string regionPart = (subDist == "0" || string.IsNullOrEmpty(subDist)) ? "" : string.Format(" and subdistrict='{0}' ", subDist);

                sql = string.Format("select '' as region_no, subdistrict as arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                  "from VW_REGIONS_MAINT_COST_SUMMARY where survey_no={0} {1} {2} " +
                  " group by subdistrict, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no  order by subdistrict, RECOMMENDED_DECISION_id ",
                  surveyNum, regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSubdistrictSecondaryStreetsMaintenanceDecisions(string subDist, bool details, bool notMaintOrders)
        {// subdistrict
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? @" and REGION_ID not in (select REGION_ID from VW_MAINT_ORDERS_FULL where REGION_ID is not null)  
                                                              and REGION_ID not in (select REGION_ID from FEEDBACK_DETAILS where REGION_ID is not null) " : "";

            if (details)
            {
                if (string.IsNullOrEmpty(subDist))
                    return new DataTable();

                sql = string.Format("select * from VW_LATEST_MD_SEC_ST where region_id IN (select region_id from regions where SUBDISTRICT='{0}') " +
                    " order by region_no, SECOND_NO ", subDist);
            }
            else
            {
                string regionPart = (subDist == "0" || string.IsNullOrEmpty(subDist)) ? "" : string.Format(" where subdistrict='{0}' ", subDist);

                sql = string.Format("select region_no, arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                   "from VW_LATEST_MDCOST_SUM_REGIONS {0} {1} " +
                   " group by region_no, arname, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no  order by region_no, RECOMMENDED_DECISION_id  ",
                   regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }


        public DataTable GetDistrictSecondaryStreetsMaintenanceDecisions(string distName, int surveyNum, bool details, bool notMaintOrders)
        {
            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", distName, "", false, false, true, false, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and REGION_ID not in (select REGION_ID from MAINTAIN_ORDER_DET_LOCS where REGION_ID is not null)  " : "";

            if (details)
            {
                if (string.IsNullOrEmpty(distName))
                    return new DataTable();

                sql = string.Format("select * from VW_REGION_MAINT_COST where region_id IN (select region_id from regions where DIST_NAME='{0}') and SURVEY_NO={1} order by region_no, SECOND_NO ",
                    distName, surveyNum);
            }
            else
            {
                string regionPart = (distName == "0" || string.IsNullOrEmpty(distName)) ? "" : string.Format(" and dist_name='{0}' ", distName);

                sql = string.Format("select '' as region_no, dist_name as arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                 "from VW_REGIONS_MAINT_COST_SUMMARY where survey_no={0} {1} {2} group by dist_name, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no " +
                 " order by dist_name, RECOMMENDED_DECISION_id  ", surveyNum, regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetDistrictSecondaryStreetsMaintenanceDecisions(string distName, bool details, bool notMaintOrders)
        {
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? @" and REGION_ID not in (select REGION_ID from VW_MAINT_ORDERS_FULL where REGION_ID is not null)  
                                                              and REGION_ID not in (select REGION_ID from FEEDBACK_DETAILS where REGION_ID is not null) " : "";

            if (details)
            {
                if (string.IsNullOrEmpty(distName))
                    return new DataTable();

                sql = string.Format("select * from VW_LATEST_MD_SEC_ST where region_id IN (select region_id from regions where DIST_NAME='{0}')  " +
                    " order by region_no, SECOND_NO ", distName);
            }
            else
            {
                string regionPart = (distName == "0" || string.IsNullOrEmpty(distName)) ? "" : string.Format(" where dist_name='{0}' ", distName);

                sql = string.Format("select '' as region_no, dist_name as arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                 "from VW_LATEST_MDCOST_SUM_REGIONS  {0} {1} " +
                 " group by dist_name, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no  order by dist_name, RECOMMENDED_DECISION_id  ",
                 regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }


        public DataTable GetMunicipalitySecondaryStreetsMaintenanceDecisions(string municName, int surveyNum, bool details, bool notMaintOrders)
        {
            if (surveyNum == 0)
            {
                DataTable dt = survey.GetLastSurveyForRoadsNetwork(0, "", "", municName, false, false, false, true, 0, false, false);
                if (dt.Rows.Count == 0)
                    return new DataTable();

                surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            }

            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? " and REGION_ID not in (select REGION_ID from MAINTAIN_ORDER_DET_LOCS where REGION_ID is not null)  " : "";

            if (details)
            {
                if (string.IsNullOrEmpty(municName))
                    return new DataTable();

                sql = string.Format("select * from VW_REGION_MAINT_COST where region_id IN (select region_id from regions where MUNIC_NAME='{0}') and SURVEY_NO={1} order by region_no, SECOND_NO ",
                    municName, surveyNum);
            }
            else
            {
                string regionPart = (municName == "0" || string.IsNullOrEmpty(municName)) ? "" : string.Format(" and munic_name='{0}' ", municName);

                sql = string.Format("select '' as region_no, munic_name as arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                  "from VW_REGIONS_MAINT_COST_SUMMARY where survey_no={0} {1} {2} " +
                  " group by munic_name, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no order by munic_name, RECOMMENDED_DECISION_id  ",
                  surveyNum, regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMunicipalitySecondaryStreetsMaintenanceDecisions(string municName, bool details, bool notMaintOrders)
        {
            string sql = "";
            string notInMaintOrdersPart = notMaintOrders ? @" and REGION_ID not in (select REGION_ID from VW_MAINT_ORDERS_FULL where REGION_ID is not null)  
                                                              and REGION_ID not in (select REGION_ID from FEEDBACK_DETAILS where REGION_ID is not null) " : "";

            if (details)
            {
                if (string.IsNullOrEmpty(municName))
                    return new DataTable();

                sql = string.Format("select * from VW_LATEST_MD_SEC_ST where region_id IN (select region_id from regions where MUNIC_NAME='{0}')" +
                    "  order by region_no, SECOND_NO ", municName);
            }
            else
            {
                string regionPart = (municName == "0" || string.IsNullOrEmpty(municName)) ? "" : string.Format(" where munic_name='{0}' ", municName);

                sql = string.Format("select '' as region_no, munic_name as arname, RECOMMENDED_DECISION, survey_no, sum(MAINT_AREA_SUM) as MAINT_AREA_SUM, sum(MAINT_COST_SUM) as MAINT_COST_SUM  " +
                  "from VW_LATEST_MDCOST_SUM_REGIONS {0} {1} " +
                  " group by munic_name, RECOMMENDED_DECISION, RECOMMENDED_DECISION_id, survey_no order by munic_name, RECOMMENDED_DECISION_id  ",
                  regionPart, notInMaintOrdersPart);
            }

            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Getting Maintenance Cost

        public double GetMainStreetSectionsMaintenanceDecisionsCost(int mainStID)
        {
            string mainStPart = (mainStID == 0) ? "" : string.Format(" where STREET_ID={0} ", mainStID);
            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_SECTIONS {0} ", mainStPart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        public double GetMunicSectionsMaintenanceCost(string municName)
        {
            string municNum = munic.GetMunicNo(municName);
            string wherePart = (municName == "0" || string.IsNullOrEmpty(municName)) ? "" : string.Format(" where section_no like '{0}%' ", municNum);

            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_SECTIONS {0}  ", wherePart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }


        public double GetMainStreetIntersectionsMaintenanceDecisionsCost(int mainStID)
        {
            string mainStPart = (mainStID == 0) ? "" : string.Format(" where STREET_ID={0} ", mainStID);
            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_INTERSECT {0} ", mainStPart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        public double GetMunicIntersectsMaintenanceCost(string municName)
        {
            string municNum = munic.GetMunicNo(municName);
            string wherePart = (municName == "0" || string.IsNullOrEmpty(municName)) ? "" : string.Format(" where inter_no like '{0}%' ", municNum);

            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_INTERSECT {0} ", wherePart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }


        public double GetRegionSecondaryStreetsMaintenanceDecisionsCost(int regionID)
        {
            string regionPart = (regionID == 0) ? "" : string.Format(" where REGION_ID={0} ", regionID);
            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_SEC_ST_REGIONS {0} ", regionPart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        public double GetSubdistrictSecondaryStreetsMaintenanceDecisionsCost(string subDist)
        {
            string regionPart = (subDist == "0" || string.IsNullOrEmpty(subDist)) ? "" : string.Format(" where subdistrict='{0}' ", subDist);
            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_SEC_ST_REGIONS {0} ", regionPart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        public double GetDistrictSecondaryStreetsMaintenanceDecisionsCost(string distName)
        {
            string regionPart = (distName == "0" || string.IsNullOrEmpty(distName)) ? "" : string.Format(" where dist_name='{0}' ", distName);
            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_SEC_ST_REGIONS {0} ", regionPart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        public double GetMunicipalitySecondaryStreetsMaintenanceDecisionsCost(string municName)
        {
            string regionPart = (municName == "0" || string.IsNullOrEmpty(municName)) ? "" : string.Format(" where MUNIC_NAME='{0}' ", municName);
            string sql = string.Format("select nvl(sum(MAINT_COST), 0) from VW_LATEST_COST_SEC_ST_REGIONS {0} ", regionPart);
            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        #endregion

    }
}
