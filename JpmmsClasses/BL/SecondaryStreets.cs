using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using System.Web;
using JpmmsClasses.BL.DistressEntry;

namespace JpmmsClasses.BL
{
    public class SecondaryStreets
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        public DataTable GetSecondaryStreetsInRegion(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, '' || ' - ' ||  SECONDARY_STREETS   SECOND_ID
            string sql = string.Format("SELECT STREET_ID, (SECOND_ST_NO || ' - ' || nvl(SECOND_ARNAME, '')) second_st_title FROM STREETS " +
                " WHERE REGION_NO IS NOT NULL and region_id={0} ORDER BY REGION_NO, lpad(SECOND_ST_NO,10)  ", regionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSecondaryStreetInfoShorter(int secondaryStreetID)
        {
            if (secondaryStreetID == 0)
                return new DataTable();

            string sql = string.Format("select STREET_ID, MUNIC_NAME, REGION_NO, SUBDISTRICT, SECOND_ST_NO, SECOND_ARNAME from GV_SEC_STREET where STREET_ID={0} ", secondaryStreetID);
            return db.ExecuteQuery(sql);  // SECOND_ID
        }

        public DataTable GetSecondaryStreetInfo(int secondaryStreetID)
        {
            if (secondaryStreetID == 0)
                return new DataTable();

            string sql = string.Format("select * from GV_SEC_STREET WHERE STREET_ID={0} ", secondaryStreetID); //SECOND_ID
            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionSecondaryStreetsFullInfoNEW(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format("select * from GV_SEC_STREET_NEW where region_id={0}  ", regionID);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionSecondaryStreetsFullInfo(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format("select * from GV_SEC_STREET where region_id={0}  ", regionID);
            return db.ExecuteQuery(sql);
        }
         public DataTable GetRegionSecondaryStreetsTable(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format(@"SELECT r.MUNIC_NAME,
            r.DIST_NAME,
            r.SUBDISTRICT,
            s.REGION_NO,
            s.REGION_ID,
            NULL DIRT_LENGTH,
            s.SECOND_ST_NO,
            s.SECOND_ARNAME,
            SECOND_ARNAME SECOND_AR_NAME,
            s.SECOND_ST_LENGTH,
            s.SECOND_ST_WIDTH,
            NULL SURVEY_DATE,
            NULL UDI_DATE,
            NULL UDI_VALUE,
            NULL UDI_RATE,
            3 SURVEY_NO,
            r.DISTRICT_ID,                                     
            s.NOTES,
            s.street_id,
            s.SECOND_ST_LENGTH*s.SECOND_ST_WIDTH SECONDARY_AREA
            FROM jpmms.STREETS s
            INNER JOIN JPMMS.REGIONS r ON s.REGION_ID = r.REGION_ID
            WHERE s.SECOND_ST_NO IS NOT NULL and s.region_id={0} 
            ORDER BY  s.REGION_NO, lpad(s.SECOND_ST_NO,10)", regionID);
            return db.ExecuteQuery(sql);
        }
         public DataTable GetMainStreetsTable()
         {
             string sql = string.Format(@"select  MAIN_NO,ARNAME,nvl(length,0),IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS from jpmms.VW_Equipments");
             return db.ExecuteQuery(sql);
         }
        public int FixDistressesAfterAreaChange(double SECOND_ST_LENGTH, double SECOND_ST_WIDTH, int SECOND_ID, string user)
        {
            int rows = 0;
            string sql = "";

            if (SECOND_ST_LENGTH == 0 || SECOND_ST_WIDTH == 0)
            {
                sql = string.Format("delete from DISTRESS WHERE STREET_ID={0} ", SECOND_ID); // second_id
                rows += db.ExecuteNonQuery(sql);
            }
            else
            {
                int distID = 0;
                int distressCode = 0;
                char DIST_SEVERITY;
                double distressDensity = 0;
                double distArea = 0;
                double deductValue = 0;
                double densityDashValue = 0;
                double deductDashValue = 0;

                double SampleArea = SECOND_ST_LENGTH * SECOND_ST_WIDTH;


                sql = string.Format("SELECT STATUS_UPD, dist_code, DIST_SEVERITY, DIST_AREA, DIST_ID FROM DISTRESS WHERE STREET_ID={0} ", SECOND_ID); // SECOND_ID
                DataTable dtSecondStDist = db.ExecuteQuery(sql);
                foreach (DataRow dr in dtSecondStDist.Rows)
                {
                    distID = int.Parse(dr["DIST_ID"].ToString());
                    distressCode = int.Parse(dr["dist_code"].ToString());
                    DIST_SEVERITY = dr["DIST_SEVERITY"].ToString()[0];
                    distArea = double.Parse(dr["DIST_AREA"].ToString());
                    distressDensity = (distArea / SampleArea) * 100.0;
                    distressDensity = (distressDensity > 100) ? 100 : distressDensity;

                    deductValue = DistressShared.CalculateDeductValue(distressCode, DIST_SEVERITY);
                    densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("G2")));
                    deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);

                    sql = string.Format("UPDATE DISTRESS SET STATUS='N', STATUS_UPD='N', DIST_DENSITY={0}, DEDUCT_VALUE={1}, DEN_DASH={2}, DEDUCT_DEN_DASH={3}  WHERE DIST_ID={4} ",
                        distressDensity.ToString("0.00"), deductValue.ToString("0.00"), densityDashValue.ToString("0.00"), deductDashValue.ToString("0.00"), distID);

                    rows += db.ExecuteNonQuery(sql);
                    Shared.SaveLogfile("DISTRESS", distID.ToString(), "Distress Update", user);
                }
            }

            return rows;
        }


        public bool Update(string SECOND_AR_NAME, string SECOND_ST_LENGTH, string SECOND_ST_WIDTH, string DIRT_LENGTH, bool LIGHTING_TRUE, string LIGHTING_LOC, bool houses,
            bool Commerial, bool publics, bool gardens, bool indisterial, bool rest_house, bool NEW_BUILDINGS, bool SCHOOL, bool HOSPITAL, bool MASJID, bool SPORT_CLUB,
            bool OTHER_UTIL, string otherUtilsDetails, bool drinage_mh_True, string drinage_mh_Count, bool drinage_cb_True, string drinage_cb_Count, bool Sewage_mh_True,
            string Sewage_mh_Count, bool elect_mh_True, string Elect_mh_Count, bool stc_mh_True, string stc_mh_Count, bool water_valve_True, string water_valve_Count,
            bool hasSpeedBumps, bool SpeedBumpLegal, bool SpeedBumpIllegal, string SpeedBumpsCount, int secondaryStreetID, string user, bool concreteBlocks, string concreteBlocksCount,
            bool drilling_stc, bool drilling_elec, bool drilling_water, bool drilling_sewage, string drilling_stc_length, string drilling_elec_length, string drilling_water_length,
            string drilling_sewage_length, string drainCBFair, string drainCbPoor, string drainMhFair, string drainMhPoor, string elecMhFair, string elecMhPoor, string stcMhFair,
            string stcMhPoor, string sewageMhFair, string sewageMhPoor, string waterMhFair, string waterMhPoor, bool midIslandGood, bool midIslandFair, bool midIslandPoor,
            bool sideCurbGood, bool sideCurbFair, bool sideCurbPoor, int speedBumpType, string lightGoodCount, string lightFairCount, string lightPoorCount, string notes,
            bool midIsland, bool sideCurb, DateTime? surveyDate)
        {
            // string lightCount,
            SECOND_ST_LENGTH = string.IsNullOrEmpty(SECOND_ST_LENGTH) ? "NULL" : SECOND_ST_LENGTH;
            SECOND_ST_WIDTH = string.IsNullOrEmpty(SECOND_ST_WIDTH) ? "NULL" : SECOND_ST_WIDTH;
            DIRT_LENGTH = string.IsNullOrEmpty(DIRT_LENGTH) ? "NULL" : DIRT_LENGTH;

            SECOND_AR_NAME = string.IsNullOrEmpty(SECOND_AR_NAME) ? "NULL" : string.Format("'{0}'", SECOND_AR_NAME.Replace("'", "''"));
            LIGHTING_LOC = string.IsNullOrEmpty(LIGHTING_LOC) ? "NULL" : string.Format("'{0}'", LIGHTING_LOC.Replace("'", "''"));
            otherUtilsDetails = string.IsNullOrEmpty(otherUtilsDetails) ? "NULL" : string.Format("'{0}'", otherUtilsDetails.Replace("'", "''"));
            notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));

            string drinageCbCount = drinage_cb_True ? int.Parse(drinage_cb_Count).ToString() : "NULL";
            string drinageMhCount = drinage_mh_True ? int.Parse(drinage_mh_Count).ToString() : "NULL";
            string sewageMhCount = Sewage_mh_True ? int.Parse(Sewage_mh_Count).ToString() : "NULL";
            string ElectMhCount = elect_mh_True ? int.Parse(Elect_mh_Count).ToString() : "NULL";
            string stcMhCcount = stc_mh_True ? int.Parse(stc_mh_Count).ToString() : "NULL";
            string waterValveCount = water_valve_True ? int.Parse(water_valve_Count).ToString() : "NULL";

            string drainageCbFairPart = string.IsNullOrEmpty(drainCBFair) ? "NULL" : int.Parse(drainCBFair).ToString();
            string drainageMhFairPart = string.IsNullOrEmpty(drainMhFair) ? "NULL" : int.Parse(drainMhFair).ToString();
            string sewageMhFairPart = string.IsNullOrEmpty(sewageMhFair) ? "NULL" : int.Parse(sewageMhFair).ToString();
            string ElectMhFairPart = string.IsNullOrEmpty(elecMhFair) ? "NULL" : int.Parse(elecMhFair).ToString();
            string stcMhFairPart = string.IsNullOrEmpty(stcMhFair) ? "NULL" : int.Parse(stcMhFair).ToString();
            string waterValveFairPart = string.IsNullOrEmpty(waterMhFair) ? "NULL" : int.Parse(waterMhFair).ToString();

            string drainageCbPoorPart = string.IsNullOrEmpty(drainCbPoor) ? "NULL" : int.Parse(drainCbPoor).ToString();
            string drainageMhPoorPart = string.IsNullOrEmpty(drainMhPoor) ? "NULL" : int.Parse(drainMhPoor).ToString();
            string sewageMhPoorPart = string.IsNullOrEmpty(sewageMhPoor) ? "NULL" : int.Parse(sewageMhPoor).ToString();
            string ElectMhPoorPart = string.IsNullOrEmpty(elecMhPoor) ? "NULL" : int.Parse(elecMhPoor).ToString();
            string stcMhPoorPart = string.IsNullOrEmpty(stcMhPoor) ? "NULL" : int.Parse(stcMhPoor).ToString();
            string waterValvePoorPart = string.IsNullOrEmpty(waterMhPoor) ? "NULL" : int.Parse(waterMhPoor).ToString();

            //string lightCountPart = string.IsNullOrEmpty(lightCount) ? "NULL" : int.Parse(lightCount).ToString();
            string lightGoodCountPart = string.IsNullOrEmpty(lightGoodCount) ? "NULL" : int.Parse(lightGoodCount).ToString();
            string lightFairCountPart = string.IsNullOrEmpty(lightFairCount) ? "NULL" : int.Parse(lightFairCount).ToString();
            string lightPoorCountPart = string.IsNullOrEmpty(lightPoorCount) ? "NULL" : int.Parse(lightPoorCount).ToString();

            string spBumpsCount = hasSpeedBumps ? int.Parse(SpeedBumpsCount).ToString() : "NULL";
            string concreteBlocksCountPart = concreteBlocks ? int.Parse(concreteBlocksCount).ToString() : "NULL";

            string speedBumpTypePart = (speedBumpType == 0) ? "NULL" : speedBumpType.ToString();

            string drillingStcLen = drilling_stc ? decimal.Parse(drilling_stc_length).ToString("0.00") : "NULL";
            string drillingWaterLen = drilling_water ? decimal.Parse(drilling_water_length).ToString("0.00") : "NULL";
            string drillingElecLen = drilling_elec ? decimal.Parse(drilling_elec_length).ToString("0.00") : "NULL";
            string drillingSewageLen = drilling_sewage ? decimal.Parse(drilling_sewage_length).ToString("0.00") : "NULL";

            string surveyDatePart = surveyDate != null ? string.Format("'{0}'", ((DateTime)surveyDate).ToString("dd/MM/yyyy")) : "NULL";


            // SECOND_AR_NAME
            string sql = string.Format("update SECONDARY_STREET_DETAILS set SECOND_AR_NAME={0}, ARNAME={0}, SECOND_ST_LENGTH={1}, SECOND_ST_WIDTH={2}, DIRT_LENGTH={3}, " +
                " LIGHTING_TRUE='{4}', LIGHTING_LOC={5}, houses='{6}', Commerial='{7}', publics='{8}', gardens='{9}', indisterial='{10}', " +
                " rest_house='{11}', NEW_BUILDINGS='{12}', SCHOOL='{13}', HOSPITAL='{14}', MASJID='{15}', SPORT_CLUB='{16}', " +
                " OTHER_UTIL='{17}', OTHER_UTIL_DETAILS={18}, drinage_mh_True='{19}', drinage_mh_Count={20}, drinage_cb_True='{21}', " +
                " drinage_cb_Count={22}, Sewage_mh_True='{23}', Sewage_mh_Count={24}, elect_mh_True='{25}', Elect_mh_Count={26}, stc_mh_True='{27}', stc_mh_Count={28}, " +
                " water_valve_True='{29}', water_valve_Count={30}, SPEED_BUMPS_TRUE='{31}', SPEED_BUMPS_LEGAL='{32}', SPEED_BUMPS_ILLEGAL='{33}', SPEED_BUMPS_COUNT={34}, " +
                " DRILLINGS_STC='{36}', DRILLINGS_STC_LENGTH={37}, DRILLINGS_ELEC='{38}', DRILLINGS_ELEC_LENGTH={39}, DRILLINGS_WATER='{40}', DRILLINGS_WATER_LENGTH={41}, " +
                " DRILLINGS_SEWAGE='{42}', DRILLINGS_SEWAG_LENGTH={43}, CONCRETE_BLOCKS='{44}', CONCRETE_BLOCKS_COUNT={45}, DRAIN_CB_FAIR={46}, DRAIN_CB_POOR={47}, " +
                " DRAIN_MH_FAIR={48}, DRAIN_MH_POOR={49}, ELEC_MH_FAIR={50}, ELEC_MH_POOR={51}, STC_MH_FAIR={52}, STC_MH_POOR={53}, " +
                " SEWAGE_MH_FAIR={54}, SEWAGE_MH_POOR={55}, WATER_MH_FAIR={56}, WATER_MH_POOR={57}, MID_ISLAND_GOOD='{58}', MID_ISLAND_FAIR='{59}', " +
                " MID_ISLAND_POOR='{60}', SIDE_CURB_GOOD='{61}', SIDE_CURB_FAIR='{62}', SIDE_CURB_POOR='{63}', SPEED_BUMP_TYPE_ID={64}, LIGHT_GOOD_COUNT={65}, " +
                " mid_island_True='{67}', side_Curb_True='{68}', SURVEY_DATE={69}, LIGHT_FAIR_COUNT={70}, LIGHT_POOR_COUNT={71} WHERE STREET_ID={35} ", // second_id
                SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, DIRT_LENGTH,
                Shared.Bool2YN(LIGHTING_TRUE), LIGHTING_LOC, Shared.Bool2YN(houses), Shared.Bool2YN(Commerial), Shared.Bool2YN(publics), Shared.Bool2YN(gardens), Shared.Bool2YN(indisterial),
                Shared.Bool2YN(rest_house), Shared.Bool2YN(NEW_BUILDINGS), Shared.Bool2YN(SCHOOL), Shared.Bool2YN(HOSPITAL), Shared.Bool2YN(MASJID), Shared.Bool2YN(SPORT_CLUB),
                Shared.Bool2YN(OTHER_UTIL), otherUtilsDetails, Shared.Bool2YN(drinage_mh_True), drinageMhCount, Shared.Bool2YN(drinage_cb_True),
                drinageCbCount, Shared.Bool2YN(Sewage_mh_True), sewageMhCount, Shared.Bool2YN(elect_mh_True), ElectMhCount, Shared.Bool2YN(stc_mh_True), stcMhCcount,
                Shared.Bool2YN(water_valve_True), waterValveCount, Shared.Bool2YN(hasSpeedBumps), Shared.Bool2YN(SpeedBumpLegal), Shared.Bool2YN(SpeedBumpIllegal), spBumpsCount,
                secondaryStreetID,
                Shared.Bool2YN(drilling_stc), drillingStcLen, Shared.Bool2YN(drilling_elec), drillingElecLen, Shared.Bool2YN(drilling_water), drillingWaterLen,
                Shared.Bool2YN(drilling_sewage), drillingSewageLen, Shared.Bool2YN(concreteBlocks), concreteBlocksCountPart, drainageCbFairPart, drainageCbPoorPart,
                drainageMhFairPart, drainageCbPoorPart, ElectMhFairPart, ElectMhPoorPart, stcMhFairPart, stcMhPoorPart,
                sewageMhFairPart, sewageMhPoorPart, waterValveFairPart, waterValvePoorPart, Shared.Bool2YN(midIslandGood), Shared.Bool2YN(midIslandFair),
                Shared.Bool2YN(midIslandPoor), Shared.Bool2YN(sideCurbGood), Shared.Bool2YN(sideCurbFair), Shared.Bool2YN(sideCurbPoor), speedBumpTypePart, lightGoodCountPart,
                notes, Shared.Bool2YN(midIsland), Shared.Bool2YN(sideCurb), surveyDatePart, lightFairCountPart, lightPoorCountPart);

            int rows = db.ExecuteNonQuery(sql);


            sql = string.Format("update STREETS set SECOND_ARNAME={0}, SECOND_ST_LENGTH={1}, SECOND_ST_WIDTH={2}, ARNAME={0}, NOTES={5} WHERE STREET_ID={4} ", //second_id  SECONDARY_STREETS 
                SECOND_AR_NAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, SECOND_AR_NAME, secondaryStreetID, notes);

            rows += db.ExecuteNonQuery(sql);
            //rows += new Region().FixDistressesAfterAreaChange(double.Parse(SECOND_ST_LENGTH), double.Parse(SECOND_ST_WIDTH), secondaryStreetID, user);
            rows += FixDistressesAfterAreaChange(double.Parse(SECOND_ST_LENGTH), double.Parse(SECOND_ST_WIDTH), secondaryStreetID, user);


            Shared.SaveLogfile("SECONDARY_STREETS", secondaryStreetID.ToString(), "Update", user);
            return (rows > 0);
        }


        public DataTable GetSecondaryStreetSamplesByRegion(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // ID1, 
            //string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, SECOND_ID FROM SECONDARY_STREETS WHERE REGION_ID={0} ORDER BY secOND_st_no ", regionID);
            string sql = string.Format("SELECT SECOND_ST_NO, SECOND_ARNAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA, STREET_ID FROM STREETS WHERE REGION_ID={0} ORDER BY secOND_st_no ", regionID);
            return db.ExecuteQuery(sql);
        }


        public static bool SecondaryStreetSampleReadyForDistressEntry(int secondaryStID)
        {
            if (secondaryStID == 0)
                return false;

            string sql = string.Format("SELECT STREET_ID, SECOND_ST_NO, SECOND_ARNAME, SECOND_ST_LENGTH, SECOND_ST_WIDTH, (SECOND_ST_LENGTH * SECOND_ST_WIDTH) AS AREA FROM STREETS " +
                " WHERE STREET_ID={0}  AND  SECOND_ST_LENGTH IS NOT NULL AND  SECOND_ST_WIDTH IS NOT NULL ", secondaryStID); // SECOND_ID

            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                return ((decimal.Parse(dt.Rows[0]["AREA"].ToString()) > 0) && !string.IsNullOrEmpty(dt.Rows[0]["SECOND_ST_NO"].ToString()));
            else
                return false;
        }



        public DataTable PrepareRegionSecondaryStreetsInfoReport(bool orderByRegionNo, bool byRegion, string itemID, bool region, bool subdist, bool dist, bool munic)
        {
            string itemPart = "", orderByPart = "";
            if (byRegion)  //if (!string.IsNullOrEmpty(itemID) && itemID != "0")
            {
                if (region)
                    itemPart = string.Format(" and REGION_ID={0} ORDER BY REGION_NO, lpad(SECOND_ST_NO,10)   ", itemID);
                else if (subdist)
                    itemPart = string.Format(" and SUBDISTRICT='{0}' ORDER BY REGION_NO, lpad(SECOND_ST_NO,10)   ", itemID);
                else if (dist)
                    itemPart = string.Format(" and DIST_NAME='{0}' ORDER BY REGION_NO, lpad(SECOND_ST_NO,10)   ", itemID);
                else if (munic)
                    itemPart = string.Format(" and MUNIC_NAME='{0}' ORDER BY REGION_NO, lpad(SECOND_ST_NO,10)   ", itemID);
            }
            else
                orderByPart = orderByRegionNo ? " ORDER BY SUBDISTRICT, REGION_NO, lpad(SECOND_ST_NO,10)  " : " ORDER BY REGION_NO, lpad(SECOND_ST_NO,10)  ";

            string sql = string.Format("SELECT * FROM Gv_Sec_street WHERE REGION_NO is not null and SECOND_ST_NO is not null {0} {1} ", itemPart, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable Search(int regionID, string subdistrict, string district, string munic)
        {
            string sql = "";
            if (regionID != 0)
                sql = string.Format("select * from GV_SEC_STREET where REGION_ID={0} ", regionID);
            else if (!string.IsNullOrEmpty(subdistrict))
                sql = string.Format("select * from GV_SEC_STREET where SUBDISTRICT='{0}' ", subdistrict);
            else if (!string.IsNullOrEmpty(district))
                sql = string.Format("select * from GV_SEC_STREET where DIST_NAME='{0}' ", district);
            else if (!string.IsNullOrEmpty(munic))
                sql = string.Format("select * from GV_SEC_STREET where MUNIC_NAME='{0}' ", munic);
            else
                return new DataTable();

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable GetStatsReport(int regionID, string subdistrict, string district, string munic)
        {
            string sql = "";
            string regionNoPart = " and region_no in (select distinct region_no from distress) ";

            if (regionID != 0)
                sql = string.Format("select * from VW_SECONDARY_ST_STATS where REGION_ID={0} {1}  ", regionID, regionNoPart);
            else if (!string.IsNullOrEmpty(subdistrict))
                sql = string.Format("select * from VW_SECONDARY_ST_STATS where SUBDISTRICT='{0}' {1} ", subdistrict, regionNoPart);
            else if (!string.IsNullOrEmpty(district))
                sql = string.Format("select * from VW_SECONDARY_ST_STATS where DIST_NAME='{0}' {1} ", district, regionNoPart);
            else if (!string.IsNullOrEmpty(munic))
                sql = string.Format("select * from VW_SECONDARY_ST_STATS where MUNIC_NAME='{0}' {1} ", munic, regionNoPart);
            else
                return new DataTable();

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable AdvancedSearch(string munic, int regionID, string stNo, string stName, bool considerUses, bool houses, bool commercial, bool publics, bool industrail,
            bool gardens, bool restHouses, bool newlyBuilt, bool schools, bool masjid, bool sportClub, bool hospital, bool otherUses, bool considerHoles, bool drainCB,
            bool drainMH, bool stcMH, bool elecMH, bool waterMH, bool sewageMH, bool considerDrills, bool stcDrills, bool elecDrills, bool waterDrills, bool sewageDrills,
            bool considerUnpaved, bool hasUnpaved, bool considerLighting, bool hasLighting, bool considerConcreteBars, bool hasConcreteBars, bool considerSpeedBumps,
            bool hasSpeedBumps, bool considerSurveyed, bool isSurveyed)
        {
            bool firstArg = true;
            string sql = "select * from GV_SEC_STREET ";

            if (regionID != 0)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE REGION_ID={1} ", sql, regionID);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND REGION_ID={1} ", sql, regionID);
            }

            if (!string.IsNullOrEmpty(munic) && (munic != "0"))
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE MUNIC_NAME='{1}' ", sql, munic.Replace("'", "''"));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND MUNIC_NAME='{1}' ", sql, munic.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(stNo))
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE SECOND_ST_NO='{1}' ", sql, stNo.Replace("'", "''"));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND SECOND_ST_NO='{1}' ", sql, stNo.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(stName))
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE SECOND_AR_NAME like '%{1}%' ", sql, stName.Replace("'", "''"));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND SECOND_AR_NAME like '%{1}%' ", sql, stName.Replace("'", "''"));
            }

            if (considerUses)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (HOUSES='{1}' and COMMERIAL='{2}' and PUBLICS='{3}' and INDISTERIAL='{4}' and REST_HOUSE='{5}' and GARDENS='{6}' and NEW_BUILDINGS='{7}' and SCHOOL='{8}' and SPORT_CLUB='{9}' and HOSPITAL='{10}' and OTHER_UTIL='{11}') ",
                        sql, houses, commercial, publics, industrail, restHouses, gardens, newlyBuilt, schools, sportClub, hospital, otherUses);

                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (HOUSES='{1}' and COMMERIAL='{2}' and PUBLICS='{3}' and INDISTERIAL='{4}' and REST_HOUSE='{5}' and GARDENS='{6}') ",
                        sql, houses, commercial, publics, industrail, restHouses, gardens, newlyBuilt, schools, sportClub, hospital, otherUses);
            }

            if (considerHoles)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (DRINAGE_CB_TRUE='{1}' and DRINAGE_MH_TRUE='{2}' and ELECT_MH_TRUE='{3}' and WATER_VALVE_TRUE='{4}' and STC_MH_TRUE='{5}' and SEWAGE_MH_TRUE='{6}' ) ",
                        sql, drainCB, drainMH, elecMH, waterMH, stcMH, sewageMH);

                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (DRINAGE_CB_TRUE='{1}' and DRINAGE_MH_TRUE='{2}' and ELECT_MH_TRUE='{3}' and WATER_VALVE_TRUE='{4}' and STC_MH_TRUE='{5}' and SEWAGE_MH_TRUE='{6}') ",
                       sql, drainCB, drainMH, elecMH, waterMH, stcMH, sewageMH);
            }

            if (considerDrills)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (DRILLINGS_ELEC='{1}' and DRILLINGS_SEWAGE='{2}' and DRILLINGS_STC='{3}' and DRILLINGS_WATER='{4}') ",
                        sql, elecDrills, sewageDrills, stcDrills, waterDrills);

                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (DRILLINGS_ELEC='{1}' and DRILLINGS_SEWAGE='{2}' and DRILLINGS_STC='{3}' and DRILLINGS_WATER='{4}') ",
                        sql, elecDrills, sewageDrills, stcDrills, waterDrills);
            }

            if (considerUnpaved)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where UNPAVED_TRUE='{1}' ", sql, hasUnpaved);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and UNPAVED_TRUE='{1}' ", sql, hasUnpaved);
            }

            if (considerLighting)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where LIGHTING_TRUE='{1}' ", sql, hasLighting);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and LIGHTING_TRUE='{1}' ", sql, hasLighting);
            }

            if (considerConcreteBars)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where CONCRETE_BLOCKS='{1}' ", sql, hasConcreteBars);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and CONCRETE_BLOCKS='{1}' ", sql, hasConcreteBars);
            }

            if (considerSpeedBumps)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where SPEED_BUMPS_TRUE='{1}' ", sql, hasSpeedBumps);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and SPEED_BUMPS_TRUE='{1}' ", sql, hasSpeedBumps);
            }

            if (considerSurveyed)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where region_no {1} (select distinct region_no from distress)  ", sql, (isSurveyed ? " in " : " not in "));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and region_no  {1} (select distinct region_no from distress)  ", sql, (isSurveyed ? " in " : " not in "));
            }


            sql = string.Format("{0}   order by region_no, SECOND_ST_NO ", sql);
            return db.ExecuteQuery(sql);
        }

    }
}
