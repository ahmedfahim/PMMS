
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
    public class Intersection
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetMainStreetByIntersectionID(int INTERSECTION_ID)
        {
            if (INTERSECTION_ID == 0)
                return new DataTable();

            // '' || ' - ' || MAIN_STREET_ID
            string sql = string.Format("select INTERSECTION_ID, (INTEREC_STREET1 || ' + ' || INTEREC_STREET2) as intersection_title from INTERSECTIONS where INTERSECTION_ID={0} order by INTERSECTION_ORDER ", INTERSECTION_ID);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetMainStreetIntersections(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            // '' || ' - ' || MAIN_STREET_ID
            string sql = string.Format("select INTERSECTION_ID, (INTEREC_STREET1 || ' + ' || INTEREC_STREET2) as intersection_title from INTERSECTIONS where STREET_ID={0} order by INTERSECTION_ORDER ", mainStreetID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllIntersectionsList()
        {
            string sql = "select INTERSECTION_ID, (arname||': '||INTEREC_STREET1||'+'|| INTEREC_STREET2) as intersection_title from vw_intersect_full_info   order by arname, inter_no ";
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(string numName, bool byNumber, int mainStID)
        {
            if (mainStID == 0 || string.IsNullOrEmpty(numName))
                return new DataTable();

            string sql = "";
            numName = numName.Trim().Replace("'", "''");
            if (byNumber)
                sql = string.Format("select INTER_NO, (' ' || INTEREC_STREET1 || ' + ' || INTEREC_STREET2)  intersection_title, INTERSECTION_ID from INTERSECTIONS where STREET_ID={0} and INTER_NO like '%{1}%' order by INTERSECTION_ORDER ", mainStID, numName);
            else
                sql = string.Format("select INTER_NO, (' ' || INTEREC_STREET1 || ' + ' || INTEREC_STREET2)  intersection_title, INTERSECTION_ID from INTERSECTIONS where STREET_ID={0} and (INTEREC_STREET1 like '%{1}%'  or INTEREC_STREET2 like '%{1}%') order by INTERSECTION_ORDER ", mainStID, numName);

            return db.ExecuteQuery(sql);
        }

        public DataTable SearchByNumber(string numName)
        {
            string sql = string.Format("select INTER_NO, (' ' || INTEREC_STREET1 || ' + ' || INTEREC_STREET2)  intersection_title, INTERSECTION_ID,MAIN_NO from INTERSECTIONS where INTER_NO like '%{0}%' order by INTERSECTION_ORDER ", numName);
            return db.ExecuteQuery(sql);
        }
        public static double GetIntersectionSampleAreaSum(int intersectID)
        {
            if (intersectID == 0)
                return 0;

            string sql = string.Format("select nvl(sum(INTERSEC_SAMP_AREA), 0) as AREA_sum from GV_INTERSECTION_SAMPLES where INTERSECTION_ID={0} ", intersectID);
            return double.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        } 
        //public static double GetIntersectionSampleAreaSum()
        //{
        //    string sql = string.Format("select nvl(round(sum(INTERSEC_SAMP_AREA)/3700,3), 0) as AREA_sum from GV_INTERSECTION_SAMPLES where INTERSECTION_ID in (select INTERSECTION_ID from INTERSECTQC)");
        //    return double.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        //}
        public DataTable GetIntersectionSampleAreaSum()
        {
            string sql = string.Format(@"select 
                     case when (IS_READY='False' and IS_REVIEWREPORT='False' and IS_REVIEWDATAENTRY='False' and IS_REVIEWGIS='False' and IS_DATAENTRYFINSH='True') then 'المراجعة'  
                     when (IS_READY='False' and IS_REVIEWREPORT='False' and IS_REVIEWDATAENTRY='False' and IS_REVIEWGIS='False' and IS_DATAENTRYFINSH='False') then 'الإدخال' 
                     when (IS_READY='False' and IS_REVIEWREPORT='False' and IS_REVIEWDATAENTRY='False' and IS_REVIEWGIS='True' and IS_DATAENTRYFINSH='False' )then  'الرسم'  
                     when (IS_READY='False' and IS_REVIEWREPORT='False' and IS_REVIEWDATAENTRY='True' and IS_REVIEWGIS='False' and IS_DATAENTRYFINSH='True') then 'التقارير'  
                     when (IS_READY='False' and IS_REVIEWREPORT='True' and IS_REVIEWDATAENTRY='True' and IS_REVIEWGIS='False' and IS_DATAENTRYFINSH='True') then 'جاهز'  
                     when (IS_READY='True' and IS_REVIEWREPORT='True' and IS_REVIEWDATAENTRY='False' and IS_REVIEWGIS='False' and IS_DATAENTRYFINSH='True') then 'المستخلص'
                     when (IS_READY='MISS' and IS_REVIEWREPORT='MISS' and IS_REVIEWDATAENTRY='MISS' and IS_REVIEWGIS='MISS' and IS_DATAENTRYFINSH='MISS') then 'استلام'
                     when (IS_READY='SUM' and IS_REVIEWREPORT='SUM' and IS_REVIEWDATAENTRY='SUM' and IS_REVIEWGIS='SUM' and IS_DATAENTRYFINSH='SUM') then 'المجموع'
                     when (IS_READY='ALL' and IS_REVIEWREPORT='ALL' and IS_REVIEWDATAENTRY='ALL' and IS_REVIEWGIS='ALL' and IS_DATAENTRYFINSH='ALL') then 'الكل'
                     when (IS_READY='SUERVEY' and IS_REVIEWREPORT='SUERVEY' and IS_REVIEWDATAENTRY='SUERVEY' and IS_REVIEWGIS='SUERVEY' and IS_DATAENTRYFINSH='SUERVEY') then 'المساحين'
                     else null end Notes,round(AREA_sum/3700,3)AREA_sum,TCOUNT,
                     case when( IS_READY='SUM' or IS_READY='MISS' or IS_READY='ALL' or IS_READY='SUERVEY') then null else IS_READY end IS_READY,
                     case when( IS_REVIEWREPORT='SUM' or IS_REVIEWREPORT='MISS' or IS_REVIEWREPORT='ALL' or IS_REVIEWREPORT='SUERVEY') then null else IS_REVIEWREPORT end IS_REVIEWREPORT,
                     case when( IS_REVIEWDATAENTRY='SUM' or IS_REVIEWDATAENTRY='MISS' or IS_REVIEWDATAENTRY='ALL' or IS_REVIEWDATAENTRY='SUERVEY') then null else IS_REVIEWDATAENTRY end IS_REVIEWDATAENTRY,
                     case when( IS_REVIEWGIS='SUM' or IS_REVIEWGIS='MISS' or IS_REVIEWGIS='ALL' or IS_REVIEWGIS='SUERVEY') then null else IS_REVIEWGIS end IS_REVIEWGIS,
                     case when( IS_DATAENTRYFINSH='SUM' or IS_DATAENTRYFINSH='MISS' or IS_DATAENTRYFINSH='ALL' or IS_DATAENTRYFINSH='SUERVEY') then null else IS_DATAENTRYFINSH end IS_DATAENTRYFINSH from  jpmms.interstionsumery ");
            return db.ExecuteQuery(sql);
        }
        public bool UpdateInterSectionsArname()
        {
            try
            {
                string sql = string.Format(@"update  JPMMS.INTERSECTIONS s set ARNAME=(select distinct ARNAME from JPMMS.EQUIPMENTMAINQC where main_no=s.MAIN_NO), STREET_ID=(select distinct STREET_ID from JPMMS.EQUIPMENTMAINQC where main_no=s.MAIN_NO)");
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetMainStIntersectionsFullInfo(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("select * from vw_intersect_full_info  WHERE  STREET_ID={0} ", mainStID); // MAIN_STREET_ID
            return db.ExecuteQuery(sql);
        }


        public DataTable GetIntersection(int intersectionID)
        {
            if (intersectionID == 0)
                return new DataTable();

            string sql = string.Format("select * from vw_intersect_full_info  WHERE  intersection_id={0} ", intersectionID);
            return db.ExecuteQuery(sql);
        }

        public bool InvalidMultilevelIntersect(int intersectID)
        {
            if (intersectID == 0)
                return false;

            string sql = string.Format("select BRIDGE_ID from BRIDGES where INTERSECT_ID={0} union select TUNNEL_ID from TUNNELS where INTERSECT_ID={0} ", intersectID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 0);
        }

        public bool CheckIntersectionSurveyorNotSaved(int sectionID)
        {
            string sql = string.Format("select * from SURVEYORS_SUBMIT_JOB where inter_no=(select inter_no from INTERSECTIONS where INTERSECTION_ID={0}) ", sectionID);
            DataTable dt = db.ExecuteQuery(sql);
            return (dt.Rows.Count == 0) ? true : false;
        }



        public bool UpdateIntersectionInfo(bool houses, bool publics, bool commerial, bool gardens, bool indisterial, bool rest_house,
            bool unpaved_true, string UNPAVED_LENGTH, string UNPAVED_WIDTH,
            bool MID_island_true, string MID_ISLAND_WIDTH,
            bool SIDEisland_true, string SIDEisland_WIDTH,
            bool side_curb_true, string SIDE_CURB_WIDTH,
            bool LIGHTING_true, string LIGHTING_LOC,
            bool tunnel_true, bool has_bridges, string brdg_tunel_type,
            bool drinage_mh_true, string drinage_mh_count,
            bool drinage_cb_true, string drinage_cb_count,
            bool sewage_mh_true, string sewage_mh_count,
            bool Elect_mh_true, string Elect_mh_count,
            bool stc_mh_true, string stc_mh_count,
            bool water_valve_true, string water_valve_count,
            int intersectionID, int INTERSECT_TYPE_ID, int INTERSECT_CTRL_TYPE_ID,
            bool unpaved_true_intersect, string UNPAVED_LENGTH_intersect, string UNPAVED_WIDTH_intersect,
            bool MID_island_true_intersect, string MID_ISLAND_WIDTH_intersect,
            bool SIDEisland_true_intersect, string SIDEisland_WIDTH_intersect,
            bool side_curb_true_intersect, string SIDE_CURB_WIDTH_intersect,
            bool LIGHTING_true_intersect, string LIGHTING_LOC_intersect,
            bool has_tunnel_intersect, bool has_bridges_intersect, string brdg_tunel_type_intersect,
            bool drinage_mh_true_intersect, string drinage_mh_count_intersect,
            bool drinage_cb_true_intersect, string drinage_cb_count_intersect,
            bool sewage_mh_true_intersect, string sewage_mh_count_intersect,
            bool Elect_mh_true_intersect, string Elect_mh_count_intersect,
            bool stc_mh_true_intersect, string stc_mh_count_intersect,
            bool water_valve_true_intersect, string water_valve_count_intersect,
            bool ag_mid_island_True, bool ag_sid_island_True, bool ag_sec_island_true,
            bool ag_mid_island_intersect_True, bool ag_sid_island_intersect_True, bool ag_sec_island_intersect_true,
            //string user,
            bool drilling_stc, bool drilling_elec, bool drilling_water, bool drilling_sewage,
            string drilling_stc_length, string drilling_elec_length, string drilling_water_length, string drilling_sewage_length,
            bool drilling_stc_intersect, bool drilling_elec_intersect, bool drilling_water_intersect, bool drilling_sewage_intersect,
            string drilling_stc_length_intersect, string drilling_elec_length_intersect, string drilling_water_length_intersect, string drilling_sewage_length_intersect,
            bool concreteBlocks, string concreteBlocksCount,
            bool concreteBlocksIntersect, string concreteBlocksCountIntersect,
            string drainCBFair, string drainCbPoor,
            string drainMhFair, string drainMhPoor,
            string elecMhFair, string elecMhPoor,
            string stcMhFair, string stcMhPoor,
            string sewageMhFair, string sewageMhPoor,
            string waterMhFair, string waterMhPoor,
            bool midIslandGood, bool midIslandFair, bool midIslandPoor,
            bool sideCurbGood, bool sideCurbFair, bool sideCurbPoor,
            string drainCBFairIntersect, string drainCbPoorIntersect,
            string drainMhFairIntersect, string drainMhPoorIntersect,
            string elecMhFairIntersect, string elecMhPoorIntersect,
            string stcMhFairIntersect, string stcMhPoorIntersect,
            string sewageMhFairIntersect, string sewageMhPoorIntersect,
            string waterMhFairIntersect, string waterMhPoorIntersect,
            bool midIslandGoodIntersect, bool midIslandFairIntersect, bool midIslandPoorIntersect,
            bool sideCurbGoodIntersect, bool sideCurbFairIntersect, bool sideCurbPoorIntersect,
            bool Service_Lane, bool Service_Lane_Intersect,
            bool Opening_Service, bool Opening_Service_Intersect,
            bool Slope_Intersect, bool Slope_Main,
            bool Uturn_Intersect, bool Uturn_Main, bool multilevel,
            string lightGoodCount, string lightFairCount, string lightPoorCount,
            string lightGoodIntersectCount, string lightFairIntersectCount, string lightPoorIntersectCount,
            //string lightsCount, string lightsCountIntersect,
            bool sideLGood, bool sideLFair, bool sideLPoor,
            bool sideLGoodIntersect, bool sideLFairIntersect, bool sideLPoorIntersect,
            bool housesIntersect, bool publicsIntersect, bool commerialIntersect, bool gardensIntersect, bool indisterialIntersect, bool rest_houseIntersect,
            string megacomCount, string mobyCount, string uniPoleCount,
            string megacomCountIntersect, string mobyCountIntersect, string uniPoleCountIntersect,
            bool paveMarkers, bool paints, bool ceramics,
            bool paveMarkersIntersect, bool paintsIntersect, bool ceramicsIntersect, int speedBumpType, int speedBumpTypeIntersect,
            bool hasPedestrainBridges, int pedestBridgeType, string pedestBridgesCount,
            bool hasIntersectPedestrainBridges, int pedestBridgeTypeIntersect, string pedestBridgesCountIntersect,
            DateTime? surveyDate,
            string guideSignsCount, string guideSignsIntersectCount, int userID, string user)
        {
            if (multilevel)
            {
                string sqlBridgeTunnels = string.Format("select bridge_id from bridges where INTERSECT_ID={0} union select tunnel_id from tunnels where INTERSECT_ID={0} ", intersectionID);
                DataTable dt = db.ExecuteQuery(sqlBridgeTunnels);
                if (dt.Rows.Count == 0)
                    throw new Exception("هذا التقاطع متعدد المستويات، يرجى إدخال بيانات الجسور أو بيانات الأنفاق الموجودة فيه");
            }

            LIGHTING_LOC = string.IsNullOrEmpty(LIGHTING_LOC) ? "NULL" : string.Format("'{0}'", LIGHTING_LOC.Replace("'", "''"));
            brdg_tunel_type = string.IsNullOrEmpty(brdg_tunel_type) ? "NULL" : string.Format("'{0}'", brdg_tunel_type.Replace("'", "''"));

            LIGHTING_LOC_intersect = string.IsNullOrEmpty(LIGHTING_LOC_intersect) ? "NULL" : string.Format("'{0}'", LIGHTING_LOC_intersect.Replace("'", "''"));
            brdg_tunel_type_intersect = string.IsNullOrEmpty(brdg_tunel_type_intersect) ? "NULL" : string.Format("'{0}'", brdg_tunel_type_intersect.Replace("'", "''"));


            string unpavedLengthPart = unpaved_true ? decimal.Parse(UNPAVED_LENGTH).ToString("0.00") : "NULL";
            string unpavedWidthPart = unpaved_true ? decimal.Parse(UNPAVED_WIDTH).ToString("0.00") : "NULL";

            string unpavedLengthPartIntersect = unpaved_true_intersect ? decimal.Parse(UNPAVED_LENGTH_intersect).ToString("0.00") : "NULL";
            string unpavedWidthPartIntersect = unpaved_true_intersect ? decimal.Parse(UNPAVED_WIDTH_intersect).ToString("0.00") : "NULL";


            string drainageCbCount = drinage_cb_true ? int.Parse(drinage_cb_count).ToString() : "NULL";
            string drainageMhCount = drinage_mh_true ? int.Parse(drinage_mh_count).ToString() : "NULL";
            string sewageMhCount = sewage_mh_true ? int.Parse(sewage_mh_count).ToString() : "NULL";
            string ElectMhCount = Elect_mh_true ? int.Parse(Elect_mh_count).ToString() : "NULL";
            string stcMhCount = stc_mh_true ? int.Parse(stc_mh_count).ToString() : "NULL";
            string waterValveCount = water_valve_true ? int.Parse(water_valve_count).ToString() : "NULL";

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

            string speedBumpTypePart = (speedBumpType == 0) ? "NULL" : speedBumpType.ToString();
            string speedBumpTypeIntersectPart = (speedBumpTypeIntersect == 0) ? "NULL" : speedBumpTypeIntersect.ToString();

            string surveyDatePart = surveyDate != null ? string.Format("'{0}'", ((DateTime)surveyDate).ToString("dd/MM/yyyy")) : "NULL";


            string drainageCbFairIntersectPart = string.IsNullOrEmpty(drainCBFairIntersect) ? "NULL" : int.Parse(drainCBFairIntersect).ToString();
            string drainageMhFairIntersectPart = string.IsNullOrEmpty(drainMhFairIntersect) ? "NULL" : int.Parse(drainMhFairIntersect).ToString();
            string sewageMhFairIntersectPart = string.IsNullOrEmpty(sewageMhFairIntersect) ? "NULL" : int.Parse(sewageMhFairIntersect).ToString();
            string ElectMhFairIntersectPart = string.IsNullOrEmpty(elecMhFairIntersect) ? "NULL" : int.Parse(elecMhFairIntersect).ToString();
            string stcMhFairIntersectPart = string.IsNullOrEmpty(stcMhFairIntersect) ? "NULL" : int.Parse(stcMhFairIntersect).ToString();
            string waterValveFairIntersectPart = string.IsNullOrEmpty(waterMhFairIntersect) ? "NULL" : int.Parse(waterMhFairIntersect).ToString();

            string drainageCbPoorIntersectPart = string.IsNullOrEmpty(drainCbPoorIntersect) ? "NULL" : int.Parse(drainCbPoorIntersect).ToString();
            string drainageMhPoorIntersectPart = string.IsNullOrEmpty(drainMhPoorIntersect) ? "NULL" : int.Parse(drainMhPoorIntersect).ToString();
            string sewageMhPoorIntersectPart = string.IsNullOrEmpty(sewageMhPoorIntersect) ? "NULL" : int.Parse(sewageMhPoorIntersect).ToString();
            string ElectMhPoorIntersectPart = string.IsNullOrEmpty(elecMhPoorIntersect) ? "NULL" : int.Parse(elecMhPoorIntersect).ToString();
            string stcMhPoorIntersectPart = string.IsNullOrEmpty(stcMhPoorIntersect) ? "NULL" : int.Parse(stcMhPoorIntersect).ToString();
            string waterValvePoorIntersectPart = string.IsNullOrEmpty(waterMhPoorIntersect) ? "NULL" : int.Parse(waterMhPoorIntersect).ToString();


            //string lightsCountPart = string.IsNullOrEmpty(lightsCount) ? "NULL" : int.Parse(lightsCount).ToString();
            //string lightsCountIntersectPart = string.IsNullOrEmpty(lightsCountIntersect) ? "NULL" : int.Parse(lightsCountIntersect).ToString();


            string drainageCbCountIntersect = drinage_cb_true_intersect ? int.Parse(drinage_cb_count_intersect).ToString() : "NULL";
            string drainageMhCountIntersect = drinage_mh_true_intersect ? int.Parse(drinage_mh_count_intersect).ToString() : "NULL";
            string sewageMhCountIntersect = sewage_mh_true_intersect ? int.Parse(sewage_mh_count_intersect).ToString() : "NULL";
            string ElectMhCountIntersect = Elect_mh_true_intersect ? int.Parse(Elect_mh_count_intersect).ToString() : "NULL";
            string stcMhCountIntersect = stc_mh_true_intersect ? int.Parse(stc_mh_count_intersect).ToString() : "NULL";
            string waterValveCountIntersect = water_valve_true_intersect ? int.Parse(water_valve_count_intersect).ToString() : "NULL";

            string midIslandWidth = MID_island_true ? decimal.Parse(MID_ISLAND_WIDTH).ToString("0.00") : "NULL";
            string sidIslandWidth = SIDEisland_true ? decimal.Parse(SIDEisland_WIDTH).ToString("0.00") : "NULL";
            string sideCurbWidth = side_curb_true ? decimal.Parse(SIDE_CURB_WIDTH).ToString("0.00") : "NULL";


            string megacomCountPart = string.IsNullOrEmpty(megacomCount) ? "NULL" : int.Parse(megacomCount).ToString();
            string MobyCountPart = string.IsNullOrEmpty(mobyCount) ? "NULL" : int.Parse(mobyCount).ToString();
            string unipoleCountPart = string.IsNullOrEmpty(uniPoleCount) ? "NULL" : int.Parse(uniPoleCount).ToString();

            string megacomCountIntersectPart = string.IsNullOrEmpty(megacomCountIntersect) ? "NULL" : int.Parse(megacomCountIntersect).ToString();
            string mobyCountIntersectPart = string.IsNullOrEmpty(mobyCountIntersect) ? "NULL" : int.Parse(mobyCountIntersect).ToString();
            string unipoleIntersectPart = string.IsNullOrEmpty(uniPoleCountIntersect) ? "NULL" : int.Parse(uniPoleCountIntersect).ToString();


            string midIslandWidthIntersect = MID_island_true_intersect ? decimal.Parse(MID_ISLAND_WIDTH_intersect).ToString("0.00") : "NULL";
            string sidIslandWidthIntersect = SIDEisland_true_intersect ? decimal.Parse(SIDEisland_WIDTH_intersect).ToString("0.00") : "NULL";
            string sideCurbWidthIntersect = side_curb_true_intersect ? decimal.Parse(SIDE_CURB_WIDTH_intersect).ToString("0.00") : "NULL";

            string intersectTypeID = (INTERSECT_TYPE_ID == 0) ? "NULL" : INTERSECT_TYPE_ID.ToString();
            string intersectCtrlTypeID = (INTERSECT_CTRL_TYPE_ID == 0) ? "NULL" : INTERSECT_CTRL_TYPE_ID.ToString();

            string drillingSTCLen = (drilling_stc || !string.IsNullOrEmpty(drilling_stc_length)) ? decimal.Parse(drilling_stc_length).ToString("0.00") : "NULL";
            string drillingElecLen = (drilling_elec || !string.IsNullOrEmpty(drilling_elec_length)) ? decimal.Parse(drilling_elec_length).ToString("0.00") : "NULL";
            string drillingWaterLen = (drilling_water || !string.IsNullOrEmpty(drilling_water_length)) ? decimal.Parse(drilling_water_length).ToString("0.00") : "NULL";
            string drillingSewageLen = (drilling_sewage || !string.IsNullOrEmpty(drilling_sewage_length)) ? decimal.Parse(drilling_sewage_length).ToString("0.00") : "NULL";
            string concreteBlocksCountPart = (concreteBlocks || !string.IsNullOrEmpty(concreteBlocksCount)) ? int.Parse(concreteBlocksCount).ToString() : "NULL";

            string drillingSTCLenIntersect = (drilling_stc_intersect || !string.IsNullOrEmpty(drilling_stc_length_intersect)) ? decimal.Parse(drilling_stc_length_intersect).ToString("0.00") : "NULL";
            string drillingElecLenIntersect = (drilling_elec_intersect || !string.IsNullOrEmpty(drilling_elec_length_intersect)) ? decimal.Parse(drilling_elec_length_intersect).ToString("0.00") : "NULL";
            string drillingWaterLenIntersect = (drilling_water_intersect || !string.IsNullOrEmpty(drilling_water_length_intersect)) ? decimal.Parse(drilling_water_length_intersect).ToString("0.00") : "NULL";
            string drillingSewageLenIntersect = (drilling_sewage_intersect || !string.IsNullOrEmpty(drilling_sewage_length_intersect)) ? decimal.Parse(drilling_sewage_length_intersect).ToString("0.00") : "NULL";
            string concreteBlocksCountIntersectPart = (concreteBlocksIntersect || !string.IsNullOrEmpty(concreteBlocksCountIntersect)) ? int.Parse(concreteBlocksCountIntersect).ToString() : "NULL";

            string bridgeTypePart = (pedestBridgeType == 0) ? "NULL" : pedestBridgeType.ToString();
            string bridgesCountPart = string.IsNullOrEmpty(pedestBridgesCount) ? "NULL" : pedestBridgesCount.ToString();

            string bridgeTypeIntersectPart = (pedestBridgeTypeIntersect == 0) ? "NULL" : pedestBridgeTypeIntersect.ToString();
            string bridgesCountIntersectPart = string.IsNullOrEmpty(pedestBridgesCountIntersect) ? "NULL" : pedestBridgesCountIntersect.ToString();

            string lightGoodCountPart = string.IsNullOrEmpty(lightGoodCount) ? "NULL" : int.Parse(lightGoodCount).ToString();
            string lightFairCountPart = string.IsNullOrEmpty(lightFairCount) ? "NULL" : int.Parse(lightFairCount).ToString();
            string lightPoorCountPart = string.IsNullOrEmpty(lightPoorCount) ? "NULL" : int.Parse(lightPoorCount).ToString();

            string lightGoodIntersectCountPart = string.IsNullOrEmpty(lightGoodIntersectCount) ? "NULL" : int.Parse(lightGoodIntersectCount).ToString();
            string lightFairIntersectCountPart = string.IsNullOrEmpty(lightFairIntersectCount) ? "NULL" : int.Parse(lightFairIntersectCount).ToString();
            string lightPoorIntersectCountPart = string.IsNullOrEmpty(lightPoorIntersectCount) ? "NULL" : int.Parse(lightPoorIntersectCount).ToString();

            string guideSignsCountPart = string.IsNullOrEmpty(guideSignsCount) ? "NULL" : int.Parse(guideSignsCount).ToString();
            string guideSignsIntersectCountPart = string.IsNullOrEmpty(guideSignsIntersectCount) ? "NULL" : int.Parse(guideSignsIntersectCount).ToString();

            int rows = 0;

            #region sqlIntersectInfo
            string sqlIntersectInfo = string.Format("UPDATE INTERSECTION_DETAILS SET INTERSECT_CTRL_TYPE_ID={0}, INTERSECT_TYPE_ID={1},  unpaved_true='{2}', unpaved_length={3}, " +
                " unpaved_width={4}, UNPAVED_INTERSECT_TRUE='{5}', UNPAVED_INTERSECT_LENGTH={6}, UNPAVED_INTERSECT_WIDTH={7}, MULTILEVEL='{8}' WHERE intersection_id={9} ",
                intersectCtrlTypeID, intersectTypeID, Shared.Bool2YN(unpaved_true), unpavedLengthPart, unpavedWidthPart, Shared.Bool2YN(unpaved_true_intersect), unpavedLengthPartIntersect,
                unpavedWidthPartIntersect, Shared.Bool2YN(multilevel), intersectionID);

            rows += db.ExecuteNonQuery(sqlIntersectInfo);
            #endregion

            #region sqlUsages
            string sqlUsages = string.Format("UPDATE INTERSECTION_DETAILS SET houses='{0}', publics='{1}', commerial='{2}', gardens='{3}', indisterial='{4}', rest_house='{5}', " +
                " HOUSES_INTERSECT='{6}', COMMERIAL_INTERSECT='{7}', GARDENS_INTERSECT='{8}', INDISTERIAL_INTERSECT='{9}', PUBLICS_INTERSECT='{10}', REST_HOUSE_INTERSECT='{11}' " +
                " WHERE intersection_id={12} ",
                Shared.Bool2YN(houses), Shared.Bool2YN(publics), Shared.Bool2YN(commerial), Shared.Bool2YN(gardens), Shared.Bool2YN(indisterial), Shared.Bool2YN(rest_house),
                Shared.Bool2YN(housesIntersect), Shared.Bool2YN(commerialIntersect), Shared.Bool2YN(gardensIntersect), Shared.Bool2YN(indisterialIntersect),
                Shared.Bool2YN(publicsIntersect), Shared.Bool2YN(rest_houseIntersect), intersectionID);

            rows += db.ExecuteNonQuery(sqlUsages);
            #endregion

            #region sqlIslandInfo
            string sqlIslandInfo = string.Format("UPDATE INTERSECTION_DETAILS SET MID_island_true='{0}', MID_island_WIDTH={1}, SIDEisland_true='{2}', SIDEisland_WIDTH={3}, " +
                " side_curb_true='{4}', SIDE_curb_WIDTH={5}, MID_ISLAND_INTERSECT_TRUE='{6}', MID_ISLAND_WIDTH_INTERSECT={7}, SIDEISLAND_INTERSECT_TRUE='{8}', " +
                " SIDEISLAND_WIDTH_INTERSECT={9}, SIDE_CURB_INTERSECT_TRUE='{10}', SIDE_CURB_WIDTH_INTERSECT={11},  MID_ISLAND_GOOD='{12}', MID_ISLAND_GOOD_INTERSECT='{13}', " +
                " MID_ISLAND_FAIR='{14}', MID_ISLAND_FAIR_INTERSECT='{15}', MID_ISLAND_POOR='{16}', MID_ISLAND_POOR_INTERSECT='{17}', SIDE_CURB_GOOD='{18}', " +
                " SIDE_CURB_GOOD_INTERSECT='{19}', SIDE_CURB_FAIR='{20}', SIDE_CURB_FAIR_INTERSECT='{21}', SIDE_CURB_POOR='{22}', SIDE_CURB_POOR_INTERSECT='{23}', " +
                " SID_ISLAND_GOOD='{24}', SID_ISLAND_FAIR='{25}', SID_ISLAND_POOR='{26}', SID_ISLAND_GOOD_INTERSECT='{27}', SID_ISLAND_FAIR_INTERSECT='{28}', " +
                " SID_ISLAND_POOR_INTERSECT='{29}' WHERE intersection_id={30} ",
                 Shared.Bool2YN(MID_island_true), midIslandWidth, Shared.Bool2YN(SIDEisland_true), sidIslandWidth,
                 Shared.Bool2YN(side_curb_true), sideCurbWidth, Shared.Bool2YN(MID_island_true_intersect), midIslandWidthIntersect, Shared.Bool2YN(SIDEisland_true_intersect),
                 sidIslandWidthIntersect, Shared.Bool2YN(side_curb_true_intersect), sideCurbWidthIntersect, Shared.Bool2YN(midIslandGood), Shared.Bool2YN(midIslandGoodIntersect),
                 Shared.Bool2YN(midIslandFair), Shared.Bool2YN(midIslandFairIntersect), Shared.Bool2YN(midIslandPoor), Shared.Bool2YN(midIslandPoorIntersect), Shared.Bool2YN(sideCurbGood),
                 Shared.Bool2YN(sideCurbGoodIntersect), Shared.Bool2YN(sideCurbFair), Shared.Bool2YN(sideCurbFairIntersect), Shared.Bool2YN(sideCurbPoor), Shared.Bool2YN(sideCurbPoorIntersect),
                 Shared.Bool2YN(sideLGood), Shared.Bool2YN(sideLFair), Shared.Bool2YN(sideLPoor), Shared.Bool2YN(sideLGoodIntersect), Shared.Bool2YN(sideLFairIntersect),
                Shared.Bool2YN(sideLPoorIntersect), intersectionID);

            rows += db.ExecuteNonQuery(sqlIslandInfo);
            #endregion

            #region sqlLightingInfo

            // LIGHT_COUNT={10}, lightsCountPart, LIGHT_COUNT_INTERSECT={10}, lightsCountIntersectPart, 
            string sqlLightingInfo = string.Format("UPDATE INTERSECTION_DETAILS SET LIGHTING_true='{0}', LIGHTING_INTERSECT_TRUE='{1}', LIGHTING_LOC={2}, LIGHTING_LOC_INTERSECT={3}, " +
                " LIGHT_GOOD_COUNT={4}, LIGHT_FAIR_COUNT={5}, LIGHT_POOR_COUNT={6}, LIGHT_GOOD_INTER_COUNT='{7}', LIGHT_FAIR_INTER_COUNT={8}, LIGHT_POOR_INTER_COUNT={9}, " +
                " MEGACOM_COUNT={10}, MOBY_COUNT={11}, UNIPOLE_COUNT={12}, MEGACOM_COUNT_INTERSECT={13}, MOBY_COUNT_INTERSECT={14}, UNIPOLE_COUNT_INTERSECT={15}, " +
                " GUIDE_SIGNS_COUNT={17}, GUIDE_SIGNS_INTER_COUNT={18} WHERE intersection_id={16} ",
                Shared.Bool2YN(LIGHTING_true), Shared.Bool2YN(LIGHTING_true_intersect), LIGHTING_LOC, LIGHTING_LOC_intersect,
                lightGoodCountPart, lightFairCountPart, lightPoorCountPart, lightGoodIntersectCountPart, lightFairIntersectCountPart, lightPoorIntersectCountPart,
                megacomCountPart, MobyCountPart, unipoleCountPart, megacomCountIntersectPart, mobyCountIntersectPart, unipoleIntersectPart,
                intersectionID, guideSignsCountPart, guideSignsIntersectCountPart);

            rows += db.ExecuteNonQuery(sqlLightingInfo);
            #endregion

            #region sqlTunnelBridgeInfo
            string sqlTunnelBridgeInfo = string.Format("UPDATE INTERSECTION_DETAILS SET brdg_TUNEL_true='{0}', brdg_tunel_type={1}, HAS_BRIDGES='{2}', TUNNEL_INTERSECT_TRUE='{3}', " +
                " BRDG_TUNEL_TYPE_INTERSECT={4}, HAS_BRIDGES_INTERSECT='{5}', PEDESTRIAN='{7}', PEDESTRIAN_COUNT={8}, PEDESTRIAN_BRIDGE_TYPE={9}, " +
                " PEDESTRIAN_INTERSECT='{10}', PEDESTRIAN_INTERSECT_COUNT={11}, PEDESTRIAN_INTER_BRIDGE_TYPE={12} WHERE intersection_id={6} ",
                Shared.Bool2YN(tunnel_true), brdg_tunel_type, Shared.Bool2YN(has_bridges), Shared.Bool2YN(has_tunnel_intersect),
                brdg_tunel_type_intersect, Shared.Bool2YN(has_bridges_intersect), intersectionID, Shared.Bool2YN(hasPedestrainBridges), bridgesCountPart, bridgeTypePart,
                Shared.Bool2YN(hasIntersectPedestrainBridges), bridgeTypeIntersectPart, bridgesCountIntersectPart);

            rows += db.ExecuteNonQuery(sqlTunnelBridgeInfo);
            #endregion

            #region sqlCbMh
            string sqlCbMh = string.Format("UPDATE INTERSECTION_DETAILS SET drinage_mh_true='{0}', drinage_mh_count={1}, drinage_cb_true='{2}', drinage_cb_count={3}, sewage_mh_true='{4}', " +
                " sewage_mh_count={5}, Elect_mh_true='{6}', Elect_mh_count={7}, stc_mh_true='{8}', stc_mh_count={9}, water_valve_true='{10}', water_valve_count={11}, " +
                " DRINAGE_MH_INTERSECT_TRUE='{12}', DRINAGE_MH_INTERSECT_COUNT={13}, DRINAGE_CB_INTERSECT_TRUE='{14}', DRINAGE_CB_INTERSECT_COUNT={15}, " +
                " SEWAGE_MH_INTERSECT_TRUE='{16}', SEWAGE_MH_INTERSECT_COUNT={17},  STC_MH_INTERSECT_TRUE='{18}', STC_MH_INTERSECT_COUNT={19}, WATER_VALVE_INTERSECT_TRUE='{20}', " +
                " WATER_VALVE_INTERSECT_COUNT={21}, DRAIN_CB_FAIR={22},  DRAIN_CB_FAIR_INTERSECT={23}, DRAIN_CB_POOR={24}, DRAIN_CB_POOR_INTERSECT={25}, DRAIN_MH_FAIR={26}, " +
                " DRAIN_MH_FAIR_INTERSECT={27}, DRAIN_MH_POOR={28}, DRAIN_MH_POOR_INTERSECT={29}, ELEC_MH_FAIR={30}, ELEC_MH_FAIR_INTERSECT={31}, ELEC_MH_POOR={32}, " +
                " ELEC_MH_POOR_INTERSECT={33}, STC_MH_FAIR={34}, STC_MH_FAIR_INTERSECT={35}, STC_MH_POOR={36}, STC_MH_POOR_INTERSECT={37}, SEWAGE_MH_FAIR={38}, " +
                " SEWAGE_MH_FAIR_INTERSECT={39}, SEWAGE_MH_POOR={40}, SEWAGE_MH_POOR_INTERSECT={41}, WATER_MH_FAIR={42}, WATER_MH_FAIR_INTERSECT={43}, WATER_MH_POOR={44}, " +
                " WATER_MH_POOR_INTERSECT={45} WHERE intersection_id={46} ",
                Shared.Bool2YN(drinage_mh_true), drainageMhCount, Shared.Bool2YN(drinage_cb_true), drainageCbCount, Shared.Bool2YN(sewage_mh_true),
                sewageMhCount, Shared.Bool2YN(Elect_mh_true), ElectMhCount, Shared.Bool2YN(stc_mh_true), stcMhCount, Shared.Bool2YN(water_valve_true), waterValveCount,
                Shared.Bool2YN(drinage_mh_true_intersect), drainageMhCountIntersect, Shared.Bool2YN(drinage_cb_true_intersect), drainageCbCountIntersect,
                Shared.Bool2YN(sewage_mh_true_intersect), sewageMhCountIntersect, Shared.Bool2YN(stc_mh_true_intersect), stcMhCountIntersect, Shared.Bool2YN(water_valve_true_intersect),
                waterValveCountIntersect, drainageCbFairPart, drainageCbFairIntersectPart, drainageCbPoorPart, drainageCbPoorIntersectPart, drainageMhFairPart,
                drainageMhFairIntersectPart, drainageMhPoorPart, drainageMhPoorIntersectPart, ElectMhFairPart, ElectMhPoorIntersectPart, ElectMhPoorPart,
                ElectMhPoorIntersectPart, stcMhFairPart, stcMhFairIntersectPart, stcMhPoorPart, stcMhPoorIntersectPart, sewageMhFairPart,
                sewageMhFairIntersectPart, sewageMhPoorPart, sewageMhPoorIntersectPart, waterValveFairPart, waterValveFairIntersectPart, waterValvePoorPart,
                waterValvePoorIntersectPart, intersectionID);

            rows += db.ExecuteNonQuery(sqlCbMh);
            #endregion

            #region sqlPlants
            string sqlPlants = string.Format("UPDATE INTERSECTION_DETAILS SET ag_mid_island_True='{0}', ag_sid_island_True='{1}', ag_sec_SIDE_True='{2}', AG_MID_ISLAND_INTERSECT_TRUE='{3}', " +
                " AG_SID_ISLAND_INTERSECT_TRUE='{4}', AG_SEC_ISLAND_INTERSECT_TRUE='{5}' WHERE intersection_id={6} ",
                  Shared.Bool2YN(ag_mid_island_True), Shared.Bool2YN(ag_sid_island_True), Shared.Bool2YN(ag_sec_island_true), Shared.Bool2YN(ag_mid_island_intersect_True),
                Shared.Bool2YN(ag_sid_island_intersect_True), Shared.Bool2YN(ag_sec_island_intersect_true), intersectionID);

            rows += db.ExecuteNonQuery(sqlPlants);
            #endregion

            #region sqlDrillings
            string sqlDillings = string.Format("UPDATE INTERSECTION_DETAILS SET DRILLINGS_STC='{0}', DRILLINGS_ELEC='{1}', DRILLINGS_WATER='{2}', DRILLINGS_SEWAGE='{3}', " +
                " DRILLINGS_STC_INTERSECT='{4}', DRILLINGS_ELEC_INTERSECT='{5}', DRILLINGS_WATER_INTERSECT='{6}', DRILLINGS_SEWAGE_INTERSECT='{7}', " +
                " DRILLINGS_STC_LEN={8}, DRILLINGS_ELEC_LEN={9}, DRILLINGS_WATER_LEN={10}, DRILLINGS_SEWAG_LEN={11}, DRILLINGS_STC_LEN_INTERSECT={12}, " +
                " DRILLINGS_ELEC_LEN_INTERSECT={13}, DRILLINGS_WATER_LEN_INTERSECT={14}, DRILLINGS_SEWAG_LEN_INTERSECT={15} WHERE intersection_id={16} ",
                 Shared.Bool2YN(drilling_stc), Shared.Bool2YN(drilling_elec), Shared.Bool2YN(drilling_water), Shared.Bool2YN(drilling_sewage),
                 Shared.Bool2YN(drilling_stc_intersect), Shared.Bool2YN(drilling_elec_intersect), Shared.Bool2YN(drilling_water_intersect), Shared.Bool2YN(drilling_sewage_intersect),
                 drillingSTCLen, drillingWaterLen, drillingElecLen, drillingSewageLen, drillingSTCLenIntersect, drillingElecLenIntersect,
                 drillingWaterLenIntersect, drillingSewageLenIntersect, intersectionID);

            rows += db.ExecuteNonQuery(sqlDillings);
            #endregion

            #region sqlLookings
            string sqlLookings = string.Format("UPDATE INTERSECTION_DETAILS SET CONCRETE_BLOCKS='{0}', CONCRETE_BLOCKS_INTERSECT='{1}', CONCRETE_BLOCKS_COUNT={2}, CONCRETE_BLOCKS_COUNT_INTERSEC={3}, " +
                " Service_Lane='{4}', Service_Lane_Intersect='{5}', Opening_Service='{6}', Opening_Service_Intersect='{7}', " +
                " Slope_Intersect='{8}', Slope_Main='{9}', Uturn_Intersect='{10}', Uturn_Main='{11}', PAV_MARKERS_TRUE='{12}', " +
                " PAVE_MARK_PAINT='{13}', PAVE_MARK_CERAMICS='{14}', PAV_MARKERS_INTERSECT_TRUE='{15}', PAVE_MARK_PAINT_INTERSECT='{16}', PAVE_MARK_CERAMICS_INTERSECT='{17}', " +
                " SPEED_BUMP_TYPE_ID={19}, SPEED_BUMP_TYPE_INTERSECT_ID={20}, SURVEY_DATE={21}, DONE_BY={22} WHERE intersection_id={18} ",
                Shared.Bool2YN(concreteBlocks), Shared.Bool2YN(concreteBlocksIntersect), concreteBlocksCountPart, concreteBlocksCountIntersectPart,
                Shared.Bool2YN(Service_Lane), Shared.Bool2YN(Service_Lane_Intersect), Shared.Bool2YN(Opening_Service), Shared.Bool2YN(Opening_Service_Intersect),
                Shared.Bool2YN(Slope_Intersect), Shared.Bool2YN(Slope_Main), Shared.Bool2YN(Uturn_Intersect), Shared.Bool2YN(Uturn_Main), Shared.Bool2YN(paveMarkers),
                Shared.Bool2YN(paints), Shared.Bool2YN(ceramics), Shared.Bool2YN(paveMarkersIntersect), Shared.Bool2YN(paintsIntersect), Shared.Bool2YN(ceramicsIntersect),
                intersectionID, speedBumpTypePart, speedBumpTypeIntersectPart, surveyDatePart, userID);

            rows += db.ExecuteNonQuery(sqlLookings);
            #endregion

            Shared.SaveLogfile("INTERSECTIONs", intersectionID.ToString(), "Update", user);
            return (rows > 0);
        }



        public DataTable PrepareIntersectionsInfoReport(bool orderByInterNo, int itemID)
        {
            string orderPart = "";
            string itemPart = (itemID != 0) ? string.Format(" and street_id={0} ", itemID) : ""; // MAIN_STREET_ID
            string sql = string.Format("SELECT * FROM gv_intersection WHERE inter_no IS NOT NULL {0} ", itemPart);

            orderPart = (orderByInterNo) ? " ORDER BY inter_NO " : " ORDER BY arname, INTERSECTION_ORDER, inter_NO ";
            sql = string.Format("{0} {1} ", sql, orderPart);

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
            //if (!string.IsNullOrEmpty(sql))
            //    return db.ExecuteQuery(sql);
            //else
            //    return new DataTable();
        }


        // bool considerSidewalks, bool midIsland, bool sideIsland, bool sidewalk, string intersectNo,

        public DataTable AdvancedSearch(int mainStID, string intersectTitle, bool considerSidewalks, bool hasSidewalk, bool considerTrees, bool inMidIsland,
            bool inSideIsland, bool inSidewalk, bool considerUses, bool houses, bool commercial, bool publics, bool industrail, bool gardens, bool restHouses,
            bool considerHoles, bool drainCB, bool drainMH, bool stcMH, bool elecMH, bool waterMH, bool sewageMH, bool considerDrills, bool stcDrills, bool elecDrills,
            bool waterDrills, bool sewageDrills, bool considerUnpaved, bool hasUnpaved, bool considerLighting, bool hasLighting, bool considerBridges, bool hasBridges,
            bool considerTunnels, bool hasTunnels, bool considerConcreteBars, bool hasConcreteBars, bool considerZebra, bool hasZebra, bool considerPedestBridges,
            bool hasPedestBridges, bool considerSurveyed, bool isSurveyed, bool considerMidIsland, bool hasMidIsland, bool considerSideIsland, bool hasSideIsland)
        {
            bool firstArg = true;
            string sql = "select * from VW_INTERSECT_FULL_INFO ";

            if (mainStID != 0)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE street_id={1} ", sql, mainStID); // MAIN_STREET_ID
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND street_id={1} ", sql, mainStID);
            }

            if (!string.IsNullOrEmpty(intersectTitle))
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (INTEREC_STREET1 like'%{1}%' or INTEREC_STREET2 like '%{1}%') ", sql, intersectTitle.Replace("'", "''"));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (INTEREC_STREET1 like'%{1}%' or INTEREC_STREET2 like '%{1}%') ", sql, intersectTitle.Replace("'", "''"));
            }

            if (considerSidewalks)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (SIDE_CURB_TRUE='{1}' or SIDE_CURB_INTERSECT_TRUE='{1}') ", sql, hasSidewalk);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (SIDE_CURB_TRUE='{1}' or SIDE_CURB_INTERSECT_TRUE='{1}') ", sql, hasSidewalk);
            }

            if (considerMidIsland)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (MID_ISLAND_TRUE='{1}' or MID_ISLAND_INTERSECT_TRUE='{1}')  ", sql, hasMidIsland);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (MID_ISLAND_TRUE='{1}' or MID_ISLAND_INTERSECT_TRUE='{1}')  ", sql, hasMidIsland);
            }

            if (considerSideIsland)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE (SIDEISLAND_TRUE='{1}' or SIDEISLAND_INTERSECT_TRUE='{1}')  ", sql, hasSideIsland);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND (SIDEISLAND_TRUE='{1}' or SIDEISLAND_INTERSECT_TRUE='{1}')  ", sql, hasSideIsland);
            }


            if (considerTrees)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} WHERE ((AG_MID_ISLAND_TRUE='{1}' or AG_MID_ISLAND_INTERSECT_TRUE='{1}') and (AG_SEC_ISLAND_TRUE='{2}' or AG_SEC_ISLAND_INTERSECT_TRUE='{2}') and (AG_SID_ISLAND_TRUE='{3}' or AG_SID_ISLAND_INTERSECT_TRUE='{3}') ", sql, inMidIsland, inSideIsland, inSidewalk);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} AND ((AG_MID_ISLAND_TRUE='{1}' or AG_MID_ISLAND_INTERSECT_TRUE='{1}') and (AG_SEC_ISLAND_TRUE='{2}' or AG_SEC_ISLAND_INTERSECT_TRUE='{2}') and (AG_SID_ISLAND_TRUE='{3}' or AG_SID_ISLAND_INTERSECT_TRUE='{3}') ", sql, inMidIsland, inSideIsland, inSidewalk);
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
                    sql = string.Format("{0} where ((DRINAGE_CB_TRUE='{1}' or DRINAGE_CB_INTERSECT_TRUE='{1}') and (DRINAGE_MH_TRUE='{2}' or DRINAGE_MH_INTERSECT_TRUE='{2}') and (ELECT_MH_TRUE='{3}' or ELECT_MH_INTERSECT_TRUE='{3}') and (WATER_VALVE_TRUE='{4}' or WATER_VALVE_INTERSECT_TRUE='{4}') and (STC_MH_TRUE='{5}' or STC_MH_INTERSECT_TRUE='{5}') and (SEWAGE_MH_TRUE='{6}' or SEWAGE_MH_INTERSECT_TRUE='{6}')) ",
                        sql, drainCB, drainMH, elecMH, waterMH, stcMH, sewageMH);

                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and ((DRINAGE_CB_TRUE='{1}' or DRINAGE_CB_INTERSECT_TRUE='{1}') and (DRINAGE_MH_TRUE='{2}' or DRINAGE_MH_INTERSECT_TRUE='{2}') and (ELECT_MH_TRUE='{3}' or ELECT_MH_INTERSECT_TRUE='{3}') and (WATER_VALVE_TRUE='{4}' or WATER_VALVE_INTERSECT_TRUE='{4}') and (STC_MH_TRUE='{5}' or STC_MH_INTERSECT_TRUE='{5}') and (SEWAGE_MH_TRUE='{6}' or SEWAGE_MH_INTERSECT_TRUE='{6}')) ",
                       sql, drainCB, drainMH, elecMH, waterMH, stcMH, sewageMH);
            }

            if (considerDrills)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where ((DRILLINGS_ELEC='{1}' or DRILLINGS_STC_INTERSECT='{1}') and (DRILLINGS_SEWAGE='{2}' or DRILLINGS_SEWAGE_INTERSECT='{2}') and (DRILLINGS_STC='{3}' or DRILLINGS_STC_INTERSECT='{3}') (and DRILLINGS_WATER='{4}' or DRILLINGS_WATER_INTERSECT='{4}')) ",
                        sql, elecDrills, sewageDrills, stcDrills, waterDrills);

                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and ((DRILLINGS_ELEC='{1}' or DRILLINGS_STC_INTERSECT='{1}') and (DRILLINGS_SEWAGE='{2}' or DRILLINGS_SEWAGE_INTERSECT='{2}') and (DRILLINGS_STC='{3}' or DRILLINGS_STC_INTERSECT='{3}') (and DRILLINGS_WATER='{4}' or DRILLINGS_WATER_INTERSECT='{4}')) ",
                        sql, elecDrills, sewageDrills, stcDrills, waterDrills);
            }

            if (considerUnpaved)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (UNPAVED_TRUE='{1}' or UNPAVED_INTERSECT_TRUE='{1}') ", sql, hasUnpaved);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (UNPAVED_TRUE='{1}' or UNPAVED_INTERSECT_TRUE='{1}') ", sql, hasUnpaved);
            }

            if (considerLighting)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (LIGHTING_TRUE='{1}' or LIGHTING_INTERSECT_TRUE='{1}') ", sql, hasLighting);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (LIGHTING_TRUE='{1}' or LIGHTING_INTERSECT_TRUE='{1}') ", sql, hasLighting);
            }

            if (considerTunnels)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (HAS_BRIDGES='{1}' or HAS_BRIDGES_INTERSECT='{1}') ", sql, hasTunnels);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (HAS_BRIDGES='{1}' or HAS_BRIDGES_INTERSECT='{1}') ", sql, hasTunnels);
            }

            if (considerBridges)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (BRDG_TUNEL_TRUE='{1}' or BRDG_TUNEL_TYPE_INTERSECT='{1}') ", sql, hasBridges);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (BRDG_TUNEL_TRUE='{1}' or BRDG_TUNEL_TYPE_INTERSECT='{1}') ", sql, hasBridges);
            }

            if (considerConcreteBars)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (CONCRETE_BLOCKS='{1}' or CONCRETE_BLOCKS_INTERSECT='{1}') ", sql, hasConcreteBars);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (CONCRETE_BLOCKS='{1}' or CONCRETE_BLOCKS_INTERSECT='{1}') ", sql, hasConcreteBars);
            }

            if (considerZebra)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (PAVE_MARK_PAINT='{1}' or PAVE_MARK_PAINT_INTERSECT='{1}') ", sql, hasZebra);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (PAVE_MARK_PAINT='{1}' or PAVE_MARK_PAINT_INTERSECT='{1}') ", sql, hasZebra);
            }

            if (considerPedestBridges)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where (PEDESTRIAN='{1}') ", sql, hasPedestBridges);
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and (PEDESTRIAN='{1}') ", sql, hasPedestBridges);
            }

            if (considerSurveyed)
            {
                if (firstArg)
                {
                    sql = string.Format("{0} where inter_no {1} (select distinct inter_no from distress)  ", sql, (isSurveyed ? " in " : " not in "));
                    firstArg = false;
                }
                else
                    sql = string.Format("{0} and inter_no {1} (select distinct inter_no from distress)  ", sql, (isSurveyed ? " in " : " not in "));
            }

            sql = string.Format("{0} order by inter_no ", sql);
            return db.ExecuteQuery(sql);
        }


        public DataTable LoadSurveyedIntersections(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            string sql = string.Format("SELECT INTER_NO, INTERSECTION_ID, ('' || ' - ' || INTEREC_STREET1 || ' مع ' || INTEREC_STREET2) as intersection_title FROM INTERSECTIONS WHERE INTER_NO IN (SELECT INTER_NO FROM GV_INTERSECTION_DISTRESS WHERE SURVEY_DATE IS NOT NULL) and STREET_ID={0} ORDER BY INTER_NO ", mainStreetID); // MAIN_STREET_ID
            return db.ExecuteQuery(sql);
        }

        public DataTable GetUdiCalculatedIntersectionForMainStreet(int mainStreetID)
        {
            if (mainStreetID == 0)
                return new DataTable();

            string sql = string.Format("select INTER_NO, INTERSECTION_ID, ('' || ' - ' || INTEREC_STREET1 || ' مع ' || INTEREC_STREET2) as intersection_title  FROM INTERSECTIONS   WHERE inter_no IN (SELECT inter_no FROM GV_INTERS_SMPL_UDI  WHERE UDI_DATE IS NOT NULL) and STREET_ID={0} ", mainStreetID); // main_street_id
            return db.ExecuteQuery(sql);
        }


    }
}
