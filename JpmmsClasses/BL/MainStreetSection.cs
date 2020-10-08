using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using System.Web;

namespace JpmmsClasses.BL
{
    public class MainStreetSection
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetMainStreetSections(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            // section_no -- SECTIONS '' || ' -: ' ||
            //select ( s.FROM_STREET || ' --> ' || s.TO_STREET)  section_from_to, s.section_id, s.section_no from SECTIONS s, SECTION_DETAILS sd 
            //     where s.STREET_ID={0} and sd.OWNED_BY_MUNIC='Y' and sd.section_id=s.section_id order by s.SEC_DIRECTION, s.sec_order
            string sql = string.Format("select ( s.FROM_STREET || ' --> ' || s.TO_STREET)  section_from_to, s.section_id, s.section_no from SECTIONS s " + 
                " where s.STREET_ID={0}  order by s.SEC_DIRECTION, s.sec_order ", mainStreetID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetSectionsNonR4R3(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            // '' || ' -: ' || MAIN_STREET_ID
            string sql = string.Format("select ( s.FROM_STREET || ' --> ' || s.TO_STREET)  section_from_to, s.section_id from SECTIONS s, SECTION_DETAILS sd " +
                " where s.STREET_ID={0} and sd.IS_R4='N' and sd.IS_R3='N' and sd.OWNED_BY_MUNIC='Y' and sd.section_id=s.section_id  " +
                " order by s.SEC_DIRECTION, s.sec_order ", mainStreetID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllSectionsList()
        {
            string sql = "select section_id, (arname||': '||from_street||'--'|| to_street) as section_title from VW_SECTIONS_FULL_INFO   order by arname, section_no ";
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(string numName, bool byNumber, int mainStID)
        {
            if (mainStID == 0 || string.IsNullOrEmpty(numName))
                return new DataTable();

            string sql = "";
            numName = numName.Trim().Replace("'", "''");

            if (byNumber)
                sql = string.Format("select (' -: ' || FROM_STREET || ' --> ' || TO_STREET)  section_from_to, section_no, section_id from SECTIONS where STREET_ID={0} and section_no like '%{1}%' order by SEC_DIRECTION, sec_order ", mainStID, numName.ToUpper());
            else
                sql = string.Format("select (' -: ' || FROM_STREET || ' --> ' || TO_STREET)  section_from_to, section_no, section_id from SECTIONS where STREET_ID={0} and (FROM_STREET like '%{1}%'  or TO_STREET like '%{1}%') order by SEC_DIRECTION, sec_order ", mainStID, numName);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStSectionsFullInfo(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // MAIN_STREET_ID
            string sql = string.Format("select * from vw_sections_full_info where STREET_ID={0}  ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public bool InvalidMultilevelSection(int sectionID)
        {
            if (sectionID == 0)
                return false;

            string sql = string.Format("select BRIDGE_ID from BRIDGES where SECTION_ID={0} union select TUNNEL_ID from TUNNELS where SECTION_ID={0} ", sectionID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 0);
        }

        public bool CheckSectionSurveyorNotSaved(int sectionID)
        {
            string sql = string.Format("select * from SURVEYORS_SUBMIT_JOB where section_NO=(select section_no from sections where section_id={0}) ", sectionID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? true : false;
        }


        public DataTable GetSectionInfo(int sectionID)
        {
            if (sectionID == 0)
                return new DataTable();

            string sql = string.Format("select * from vw_sections_full_info where section_id={0} ", sectionID);
            return db.ExecuteQuery(sql);
        }

        public static double GetSectionSampleAreaSum(int sectionID)
        {
            if (sectionID == 0)
                return 0;

            string sql = string.Format("select nvl(sum(AREA), 0) as AREA_sum from GV_SAMPLES where SECTION_ID={0} ", sectionID);
            return double.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        }



        public bool UpdateSectionInfo(string SEC_DIRECTION, decimal SEC_WIDTH, decimal SEC_LENGTH, bool houses, bool publics, bool commerial, bool gardens, bool indisterial,
            bool rest_house, bool unpaved_True, string unpaved_length, string unpaved_Width, bool mid_island_True, string mid_island_width, bool sideisland_True,
            string sideisland_width, bool side_Curb_True, string side_Curb_width, bool LIGHTING_True, string LIGHTING_LOC, bool brdg_TUNEL_true, string brdg_tunel_type,
            bool ag_mid_island_True, bool ag_sid_island_True, bool ag_sec_island_true, bool drinage_mh_true, string drinage_mh_count, bool drinage_cb_true,
            string drinage_cb_count, bool sewage_mh_true, string sewage_mh_count, bool Elect_mh_true, string Elect_mh_count, bool stc_mh_true, string stc_mh_count,
            bool water_valve_true, string waterMhCount, bool intersectOpenIsland, bool intersectTrafficLight, int SEC_order, int sectionID, bool drilling_stc,
            bool drilling_elec, bool drilling_water, bool drilling_sewage, string drilling_stc_length, string drilling_elec_length, string drilling_water_length,
            string drilling_sewage_length, bool is_r4, bool is_r3, DateTime? r4Date, DateTime? r3Date, string drainCBFair, string drainCbPoor, string drainMhFair,
            string drainMhPoor, string elecMhFair, string elecMhPoor, string stcMhFair, string stcMhPoor, string sewageMhFair, string sewageMhPoor, string waterMhFair,
            string waterMhPoor, bool midIslandGood, bool midIslandFair, bool midIslandPoor, bool sideCurbGood, bool sideCurbFair, bool sideCurbPoor, bool propertyConflict,
            string megacomCount, string mobyCount, string uniPoleCount, string lightingControlsCount, bool multilevel, bool sideIslandGood, bool sideIslandFair, bool sideIslandPoor,
            bool markers, bool paints, bool ceramics, bool pavedbyMunic, string pavedbyMunicDetails, bool ownedByMunic, string ownedByMunicDetails, bool hasPedestrainBridges,
            int pedestBridgeType, string pedestBridgesCount, bool sectionBorderOther, string sectionBorderDetails, DateTime? surveyDate, string lightGoodCount,
            string lightFairCount, string lightPoorCount, string guideSignsCount, int userID, string user)
        {
            // string lightCount, bool lightingIsGood, bool lightFair, bool lightPoor, string user,
            if (multilevel)
            {
                string sqlBridgeTunnels = string.Format("select bridge_id from bridges where section_id={0} union select tunnel_id from tunnels where section_id={0} ", sectionID);
                DataTable dt = db.ExecuteQuery(sqlBridgeTunnels);
                if (dt.Rows.Count == 0)
                    throw new Exception("هذا المقطع متعدد المستويات، يرجى إدخال بيانات الجسور أو بيانات الأنفاق الموجودة فيه");
            }


            SEC_DIRECTION = (SEC_DIRECTION == "0") ? "NULL" : string.Format("'{0}'", SEC_DIRECTION);

            LIGHTING_LOC = string.IsNullOrEmpty(LIGHTING_LOC) ? "NULL" : string.Format("'{0}'", LIGHTING_LOC.Replace("'", "''"));
            brdg_tunel_type = string.IsNullOrEmpty(brdg_tunel_type) ? "NULL" : string.Format("'{0}'", brdg_tunel_type.Replace("'", "''"));
            pavedbyMunicDetails = string.IsNullOrEmpty(pavedbyMunicDetails) ? "NULL" : string.Format("'{0}'", pavedbyMunicDetails.Replace("'", "''"));
            ownedByMunicDetails = string.IsNullOrEmpty(ownedByMunicDetails) ? "NULL" : string.Format("'{0}'", ownedByMunicDetails.Replace("'", "''"));
            sectionBorderDetails = string.IsNullOrEmpty(sectionBorderDetails) ? "NULL" : string.Format("'{0}'", sectionBorderDetails.Replace("'", "''"));


            string unpavedLengthPart = unpaved_True ? decimal.Parse(unpaved_length).ToString("0.00") : "NULL";
            string unpavedWidthPart = unpaved_True ? decimal.Parse(unpaved_Width).ToString("0.00") : "NULL";

            string drainageCbCount = drinage_cb_true ? int.Parse(drinage_cb_count).ToString() : "NULL";
            string drainageMhCount = drinage_mh_true ? int.Parse(drinage_mh_count).ToString() : "NULL";
            string sewageMhCount = sewage_mh_true ? int.Parse(sewage_mh_count).ToString() : "NULL";
            string ElectMhCount = Elect_mh_true ? int.Parse(Elect_mh_count).ToString() : "NULL";
            string stcMhCcount = stc_mh_true ? int.Parse(stc_mh_count).ToString() : "NULL";
            string waterValveCount = water_valve_true ? int.Parse(waterMhCount).ToString() : "NULL";


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


            string midIslandWidth = mid_island_True ? decimal.Parse(mid_island_width).ToString("0.00") : "NULL";
            string sidIslandWidth = sideisland_True ? decimal.Parse(sideisland_width).ToString("0.00") : "NULL";
            string sideCurbWidth = side_Curb_True ? decimal.Parse(side_Curb_width).ToString("0.00") : "NULL";

            string drillingStcLen = drilling_stc ? decimal.Parse(drilling_stc_length).ToString("0.00") : "NULL";
            string drillingWaterLen = drilling_water ? decimal.Parse(drilling_water_length).ToString("0.00") : "NULL";
            string drillingElecLen = drilling_elec ? decimal.Parse(drilling_elec_length).ToString("0.00") : "NULL";
            string drillingSewageLen = drilling_sewage ? decimal.Parse(drilling_sewage_length).ToString("0.00") : "NULL";

            //string R4datePart = is_r4 ? string.Format("'{0}'", Shared.FormatDateArEgDMY(r4Date)) : "NULL";
            string R4datePart = is_r4 ? string.Format("'{0}'", ((DateTime)r4Date).ToString("dd/MM/yyyy")) : "NULL";
            string R3datePart = is_r3 ? string.Format("'{0}'", ((DateTime)r3Date).ToString("dd/MM/yyyy")) : "NULL";
            string surveyDatePart = surveyDate != null ? string.Format("'{0}'", ((DateTime)surveyDate).ToString("dd/MM/yyyy")) : "NULL";
            //string noPermitsTillDatePart = is_r3 ? string.Format("'{0}'", ((DateTime)r3Date).AddMonths(6).ToString("dd/MM/yyyy")) : "NULL";

            string noPermitsTillDatePart = "";
            if (is_r3 && is_r4)
            {
                DateTime? date = (r3Date > r4Date) ? r3Date : r4Date;
                noPermitsTillDatePart = string.Format("'{0}'", ((DateTime)date).AddMonths(6).ToString("dd/MM/yyyy"));
            }

            if (is_r3)
                noPermitsTillDatePart = string.Format("'{0}'", ((DateTime)r3Date).AddMonths(6).ToString("dd/MM/yyyy"));
            else if (is_r4)
                noPermitsTillDatePart = string.Format("'{0}'", ((DateTime)r4Date).AddMonths(6).ToString("dd/MM/yyyy"));
            else
                noPermitsTillDatePart = "NULL";


            //string lightCountPart = string.IsNullOrEmpty(lightCount) ? "NULL" : int.Parse(lightCount).ToString();
            string lightGoodCountPart = string.IsNullOrEmpty(lightGoodCount) ? "NULL" : int.Parse(lightGoodCount).ToString();
            string lightFairCountPart = string.IsNullOrEmpty(lightFairCount) ? "NULL" : int.Parse(lightFairCount).ToString();
            string lightPoorCountPart = string.IsNullOrEmpty(lightPoorCount) ? "NULL" : int.Parse(lightPoorCount).ToString();

            string megacomPart = string.IsNullOrEmpty(megacomCount) ? "NULL" : int.Parse(megacomCount).ToString();
            string mobyPart = string.IsNullOrEmpty(mobyCount) ? "NULL" : int.Parse(mobyCount).ToString();
            string unipolePart = string.IsNullOrEmpty(uniPoleCount) ? "NULL" : int.Parse(uniPoleCount).ToString();
            string lightControlsPart = string.IsNullOrEmpty(lightingControlsCount) ? "NULL" : int.Parse(lightingControlsCount).ToString();

            string bridgeTypePart = (pedestBridgeType == 0) ? "NULL" : pedestBridgeType.ToString();
            string bridgesCountPart = string.IsNullOrEmpty(pedestBridgesCount) ? "NULL" : pedestBridgesCount.ToString();
            string guideSignsCountPart = string.IsNullOrEmpty(guideSignsCount) ? "NULL" : int.Parse(guideSignsCount).ToString();

            // LIGHTING_COUNT={72}, lightCountPart , LIGHTING_GOOD='{73}', LIGHT_FAIR='{87}', LIGHT_POOR='{88}', Shared.Bool2YN(lightingIsGood), Shared.Bool2YN(lightFair), Shared.Bool2YN(lightPoor), 
            string sql = string.Format("UPDATE SECTION_DETAILS SET SEC_DIRECTION={0}, SEC_order={1}, SEC_LENGTH={2}, SEC_WIDTH={3}, houses='{4}', publics='{5}', commerial='{6}', " +
                " gardens='{7}', indisterial='{8}', rest_house='{9}', unpaved_true='{10}', unpaved_length={11}, unpaved_width={12}, MID_island_true='{13}', " +
                " MID_island_WIDTH={14}, SIDEisland_true='{15}', SIDEisland_WIDTH={16}, side_curb_true='{17}', SIDE_curb_WIDTH={18}, LIGHTING_true='{19}', LIGHTING_LOC={20}, " +
                "  brdg_TUNEL_true='{21}', brdg_tunel_type={22}, ag_mid_island_true='{23}', ag_sid_island_true='{24}', ag_sec_island_true='{25}', " +
                " drinage_mh_true='{26}', drinage_mh_count={27}, drinage_cb_true='{28}', drinage_cb_count={29}, sewage_mh_true='{30}', sewage_mh_count={31}, " +
                " Elect_mh_true='{32}', Elect_mh_count={33}, stc_mh_true='{34}', stc_mh_count={35}, water_valve_true='{36}', water_valve_count={37}, " +
                " INTERSECTION_OPEN_ISLAND='{38}', INTERSECTION_TRAFFIC_LIGHT='{39}', DRILLINGS_STC='{41}', DRILLINGS_STC_LENGTH={42}, DRILLINGS_ELEC='{43}', " +
                " DRILLINGS_ELEC_LENGTH={44}, DRILLINGS_WATER='{45}', DRILLINGS_WATER_LENGTH={46}, DRILLINGS_SEWAGE='{47}', DRILLINGS_SEWAG_LENGTH={48}, IS_R4='{49}', IS_R3='{50}', " +
                " R4_DATE={51}, R3_DATE={52}, NO_PERMIT_TILL_DATE={53},  DRAIN_CB_FAIR={54}, DRAIN_CB_POOR={55}, DRAIN_MH_FAIR={56}, DRAIN_MH_POOR={57}, " +
                " ELEC_MH_FAIR={58}, ELEC_MH_POOR={59}, STC_MH_FAIR={60}, STC_MH_POOR={61}, SEWAGE_MH_FAIR={62}, SEWAGE_MH_POOR={63}, WATER_MH_FAIR={64}, WATER_MH_POOR={65}, " +
                " MID_ISLAND_GOOD='{66}', MID_ISLAND_FAIR='{67}', MID_ISLAND_POOR='{68}', SIDE_CURB_GOOD='{69}', SIDE_CURB_FAIR='{70}', " +
                " SIDE_CURB_POOR='{71}',  LIGHTING_PROPERTY_CONFLICT='{72}', MEGACOM_COUNT={73}, MOBY_COUNT={74}, UNIPOLE_COUNT={75}, LIGHTING_CONTROLS_COUNT={76}, MULTILEVEL='{77}', " +
                " SID_ISLAND_GOOD='{78}', SID_ISLAND_FAIR='{79}', SID_ISLAND_POOR='{80}', PAVED_BY_MUNIC='{81}', NOT_PAVED_BY_DETAILS={82}, " +
                " OWNED_BY_MUNIC='{83}', OWNED_DETAILS={84},  PAV_MARKERS_TRUE='{85}', MARKER_CERAMIC='{86}', MARKER_PAINT='{87}', PEDESTRIAN='{88}', " +
                " PEDESTRIAN_BRIDGE_TYPE={89}, PEDESTRIAN_COUNT={90}, SECTION_BORDER_OTHER='{91}', OTHER_BORDER_DETAILS={92}, SURVEY_DATE={93}, GUIDE_SIGNS_COUNT={94}, " +
                " DONE_BY={95}, LIGHT_GOOD_COUNT={96}, LIGHT_FAIR_COUNT={97}, LIGHT_POOR_COUNT={98}  WHERE SECTION_ID={40} ",
                SEC_DIRECTION, SEC_order, SEC_LENGTH, SEC_WIDTH, Shared.Bool2YN(houses), Shared.Bool2YN(publics), Shared.Bool2YN(commerial),
                Shared.Bool2YN(gardens), Shared.Bool2YN(indisterial), Shared.Bool2YN(rest_house), Shared.Bool2YN(unpaved_True), unpaved_length, unpaved_Width, Shared.Bool2YN(mid_island_True),
                midIslandWidth, Shared.Bool2YN(sideisland_True), sidIslandWidth, Shared.Bool2YN(side_Curb_True), sideCurbWidth, Shared.Bool2YN(LIGHTING_True), LIGHTING_LOC,
                Shared.Bool2YN(brdg_TUNEL_true), brdg_tunel_type, Shared.Bool2YN(ag_mid_island_True), Shared.Bool2YN(ag_sid_island_True), Shared.Bool2YN(ag_sec_island_true),
                Shared.Bool2YN(drinage_mh_true), drainageMhCount, Shared.Bool2YN(drinage_cb_true), drainageCbCount, Shared.Bool2YN(sewage_mh_true), sewageMhCount,
                Shared.Bool2YN(Elect_mh_true), ElectMhCount, Shared.Bool2YN(stc_mh_true), stcMhCcount, Shared.Bool2YN(water_valve_true), waterValveCount,
                Shared.Bool2YN(intersectOpenIsland), Shared.Bool2YN(intersectTrafficLight), sectionID, Shared.Bool2YN(drilling_stc), drillingStcLen, Shared.Bool2YN(drilling_elec),
                drillingElecLen, Shared.Bool2YN(drilling_water), drillingWaterLen, Shared.Bool2YN(drilling_sewage), drillingSewageLen, Shared.Bool2YN(is_r4), Shared.Bool2YN(is_r3),
                R4datePart, R3datePart, noPermitsTillDatePart, drainageCbFairPart, drainageCbPoorPart, drainageMhFairPart, drainageCbPoorPart,
                ElectMhFairPart, ElectMhPoorPart, stcMhFairPart, stcMhPoorPart, sewageMhFairPart, sewageMhPoorPart, waterValveFairPart, waterValvePoorPart,
                Shared.Bool2YN(midIslandGood), Shared.Bool2YN(midIslandFair), Shared.Bool2YN(midIslandPoor), Shared.Bool2YN(sideCurbGood), Shared.Bool2YN(sideCurbFair),
                Shared.Bool2YN(sideCurbPoor), Shared.Bool2YN(propertyConflict), megacomPart, mobyPart, unipolePart, lightControlsPart, Shared.Bool2YN(multilevel),
                Shared.Bool2YN(sideIslandGood), Shared.Bool2YN(sideIslandFair), Shared.Bool2YN(sideIslandPoor), Shared.Bool2YN(pavedbyMunic), pavedbyMunicDetails,
                Shared.Bool2YN(ownedByMunic), ownedByMunicDetails, Shared.Bool2YN(markers), Shared.Bool2YN(ceramics), Shared.Bool2YN(paints), Shared.Bool2YN(hasPedestrainBridges),
                bridgeTypePart, bridgesCountPart, Shared.Bool2YN(sectionBorderOther), sectionBorderDetails, surveyDatePart, guideSignsCountPart,
                userID, lightGoodCountPart, lightFairCountPart, lightPoorCountPart);

            int rows = db.ExecuteNonQuery(sql);

            sql = string.Format("update SECTIONS set SEC_DIRECTION={0}, SEC_ORDER={1}, SEC_LENGTH={2}, SEC_WIDTH={3} WHERE SECTION_ID={4} ",
                SEC_DIRECTION, SEC_order, SEC_LENGTH, SEC_WIDTH, sectionID);

            rows += db.ExecuteNonQuery(sql);


            Shared.SaveLogfile("SECTIONs", sectionID.ToString(), "Update Info", user);
            return (rows > 0);
        }



        public DataTable GetAllSectionsReport(bool orderBySectionNo, bool orderByStreetName, bool forStreet, int streetID, bool surroundingRegion, int regionID)
        {
            string sql = "SELECT * FROM gv_SECTIONS ", orderByPart = "";

            if (orderBySectionNo)
                orderByPart = " WHERE SECTION_NO IS NOT NULL ORDER BY SECTION_NO ";
            else if (orderByStreetName)
                orderByPart = " where SECTION_NO is not null ORDER BY arname, SECTION_NO "; // Main_no, arname,    MAIN_STREET_ID
            else if (forStreet)
                orderByPart = string.Format(" where STREET_ID={0} and SECTION_NO is not null  order by arname, section_no, sec_direction, sec_order ", streetID);
            else if (surroundingRegion)
            {
                string regionNum = new Region().GetRegionNum(regionID);
                orderByPart = string.Format(" where section_no like '{0}%' ORDER BY arname, SECTION_NO ", regionNum);
            }
            else
                return new DataTable();

            sql = string.Format("{0} {1} ", sql, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetStatsReport(int mainStID, bool intersects, int sectionID, int intersectID)
        {
            // MAIN_ST_ID
            string sql = "";
            if (intersects)
            {
                if (mainStID == 0)
                    sql = "select * from VW_INTERSECT_FULL_INFO where inter_no is not null and inter_no in (select distinct inter_no from distress) order by main_no, inter_no "; // VW_MAIN_STREET_STATISTICS
                else
                {
                    string intersectPart = (intersectID == 0) ? "" : string.Format(" and INTERSECTION_ID={0}", intersectID);
                    sql = string.Format("select * from VW_INTERSECT_FULL_INFO where STREET_ID={0} {1} and inter_no in (select distinct inter_no from distress) order by inter_no ", mainStID, intersectPart);
                }
            }
            else
            {
                if (mainStID == 0)
                    sql = "select * from VW_SECTIONS_FULL_INFO where section_no is not null and section_no in (select distinct section_no from distress) order by main_no, section_no "; // VW_MAIN_STREET_STATISTICS
                else
                {
                    string sectionpart = (sectionID == 0) ? "" : string.Format(" and SECTION_ID={0}", sectionID);
                    sql = string.Format("select * from VW_SECTIONS_FULL_INFO where STREET_ID={0} {1} and section_no in (select distinct section_no from distress) order by section_no ", mainStID, sectionpart);
                }
            }

            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }

        // bool midIsland, bool sideIsland, string sectionNo, 


        public DataTable AdvancedSearch(int mainStID, string sectionTitle, string direction, bool considerSidewalks, bool hasSidewalk, bool considerTrees, bool inMidIsland,
            bool inSideIsland, bool inSidewalk, bool considerUses, bool houses, bool commercial, bool publics, bool industrail, bool gardens, bool restHouses, bool considerHoles,
            bool drainCB, bool drainMH, bool stcMH, bool elecMH, bool waterMH, bool sewageMH, bool considerDrills, bool stcDrills, bool elecDrills, bool waterDrills,
            bool sewageDrills, bool considerUnpaved, bool hasUnpaved, bool considerLighting, bool hasLighting, bool considerBridges, bool hasBridges, bool considerTunnels,
            bool hasTunnels, bool considerR4, bool R4, bool considerR3, bool R3, DateTime? r4From, DateTime? r4To, DateTime? r3From, DateTime? r3To, bool considerPedestrian,
            bool pedestrian, bool considerSurveyed, bool isSurveyed, bool considerMidIsland, bool hasMidIsland, bool considerSideIsland, bool hasSideIsland, string regionID)
        {
            bool firstArg = true;
            string sql = "select * from VW_SECTIONS_FULL_INFO "; // "; VW_SECTIONS_LANES_FULL_INFO  MAIN_STREET_ID

            if (mainStID != 0)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE STREET_ID={1} ", sql, mainStID);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND STREET_ID={1} ", sql, mainStID);
            }

            if (!string.IsNullOrEmpty(direction) && (direction != "0"))
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE SEC_DIRECTION='{1}' ", sql, direction);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND SEC_DIRECTION='{1}' ", sql, direction);
            }

            if (!string.IsNullOrEmpty(sectionTitle))
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (FROM_STREET like'%{1}%' or TO_STREET like '%{1}%') ", sql, sectionTitle.Replace("'", "''"));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (FROM_STREET like'%{1}%' or TO_STREET like '%{1}%') ", sql, sectionTitle.Replace("'", "''"));
            }


            // ='{1}' and ='{2}' and  midIsland, sideIsland,
            if (considerSidewalks)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (SIDE_CURB_TRUE='{1}') ", sql, hasSidewalk);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (SIDE_CURB_TRUE='{1}') ", sql, hasSidewalk);
            }

            if (considerMidIsland)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (MID_ISLAND_TRUE='{1}') ", sql, hasMidIsland);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (MID_ISLAND_TRUE='{1}') ", sql, hasMidIsland);
            }

            if (considerSideIsland)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (SIDEISLAND_TRUE='{1}') ", sql, hasSideIsland);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (SIDEISLAND_TRUE='{1}') ", sql, hasSideIsland);
            }


            if (considerTrees)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (AG_MID_ISLAND_TRUE='{1}' and AG_SEC_ISLAND_TRUE='{2}' and AG_SID_ISLAND_TRUE='{3}') ", sql, inMidIsland, inSideIsland, inSidewalk);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (AG_MID_ISLAND_TRUE='{1}' and AG_SEC_ISLAND_TRUE='{2}' and AG_SID_ISLAND_TRUE='{3}') ", sql, inMidIsland, inSideIsland, inSidewalk);
            }

            if (considerUses)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (HOUSES='{1}' and COMMERIAL='{2}' and PUBLICS='{3}' and INDISTERIAL='{4}' and REST_HOUSE='{5}' and GARDENS='{6}') ",
                        sql, houses, commercial, publics, industrail, restHouses, gardens);

                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (HOUSES='{1}' and COMMERIAL='{2}' and PUBLICS='{3}' and INDISTERIAL='{4}' and REST_HOUSE='{5}' and GARDENS='{6}') ",
                        sql, houses, commercial, publics, industrail, restHouses, gardens);
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

            if (considerBridges || considerTunnels)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where BRDG_TUNEL_TRUE='{1}' ", sql, (hasBridges | hasTunnels));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and BRDG_TUNEL_TRUE='{1}' ", sql, (hasBridges | hasTunnels));
            }

            if (considerR4)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where IS_R4='{1}' ", sql, R4);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and IS_R4='{1}' ", sql, R4);

                if (r4From != null && r4To != null)
                    sql = string.Format("{0} and (R4_DATE between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY')) ", sql, ((DateTime)r4From).ToString("dd/MM/yyyy"), ((DateTime)r4To).ToString("dd/MM/yyyy"));
            }

            if (considerR3)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where IS_R3='{1}' ", sql, R3);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and IS_R3='{1}' ", sql, R3);

                if (r4From != null && r4To != null)
                    sql = string.Format("{0} and (R3_DATE between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY')) ", sql, ((DateTime)r3From).ToString("dd/MM/yyyy"), ((DateTime)r3To).ToString("dd/MM/yyyy"));
            }


            if (considerPedestrian)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where PEDESTRIAN='{1}' ", sql, pedestrian);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and PEDESTRIAN='{1}' ", sql, pedestrian);
            }

            if (considerSurveyed)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (street_id {1} (select distinct street_id from distress) or section_no in (select distinct section_no from distress)) ", sql, (isSurveyed ? " in " : " not in "));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (street_id {1} (select distinct street_id from distress) or section_no in (select distinct section_no from distress))  ", sql, (isSurveyed ? " in " : " not in "));
            }

            if (!string.IsNullOrEmpty(regionID) && regionID != "0")
            {
                string regionNum = new Region().GetRegionNum(int.Parse(regionID));
                if (firstArg)
                {
                    sql = string.Format("{0} where section_no like '{1}%' ", sql, regionNum);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and section_no like '{1}%' ", sql, regionNum);
            }


            sql = string.Format("{0} order by section_no ", sql);
            return db.ExecuteQuery(sql);
        }



        public string GetSectionNoPermitTillDate(int sectionID)
        {
            if (sectionID == 0)
                return "";

            string sql = string.Format("select IS_R4, IS_R3, NO_PERMIT_TILL_DATE from VW_SECTIONS_FULL_INFO where section_id={0} ", sectionID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return (bool.Parse(dr["IS_R4"].ToString()) || bool.Parse(dr["IS_R3"].ToString())) ? DateTime.Parse(dr["NO_PERMIT_TILL_DATE"].ToString()).ToString("dd/MM/yyyy") : "";
            }
            else
                return "";
        }



        public DataTable LoadSurveyedSections(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            // MAIN_STREET_ID
            string sql = string.Format("SELECT  '' as SECTION_NO, ('' || ' - من: ' || FROM_STREET || ', إلى: ' || TO_STREET)  section_from_to, section_id FROM SECTIONS " + 
                " WHERE SECTION_NO IN (SELECT SECTION_NO FROM DISTRESS WHERE SURVEY_DATE IS NOT NULL) and STREET_ID={0} ORDER BY SECTION_NO, SEC_ORDER ", mainStreetID);

            return db.ExecuteQuery(sql);
        }

        public DataTable LoadUdiCalculatedSections(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            // section_no ''
            string sql = string.Format("SELECT  '' as SECTION_NO, ('' || ' - من: ' || FROM_STREET || ', إلى: ' || TO_STREET)  section_from_to, section_id FROM GV_SECTIONS  " + 
                " WHERE STREET_ID={0} and SECTION_NO IN (SELECT SECTION_NO FROM GV_SAMPLE_UDI WHERE UDI_DATE IS NOT NULL)  ORDER BY SECTION_NO, SEC_ORDER ", mainStreetID);

            return db.ExecuteQuery(sql);
        }


    }
}
