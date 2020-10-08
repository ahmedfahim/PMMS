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
    public class Bridge
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetSectionBridges(int sectionID)
        {
            if (sectionID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_BRIDGE_FULL_INFO where SECTION_ID={0} ", sectionID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetBridges(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // main_street_id
            string sql = string.Format("select * from VW_BRIDGE_FULL_INFO where section_id in(select section_id from sections where STREET_ID={0}) or intersect_id in (select intersection_id from intersections where STREET_ID={0}) ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeInfo(int BRIDGE_ID)
        {
            if (BRIDGE_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_BRIDGE_FULL_INFO where BRIDGE_ID={0} ", BRIDGE_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionBridges(int intersectID)
        {
            if (intersectID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_BRIDGE_FULL_INFO where INTERSECT_ID={0} ", intersectID);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetBridgeSectionInfo(int bridgeID)
        {
            string sql = string.Format("select SECTION_ID from BRIDGES where BRIDGE_ID={0} ", bridgeID);
            int sectionID = int.Parse(db.ExecuteScalar(sql).ToString());
            return new MainStreetSection().GetSectionInfo(sectionID);
        }

        public DataTable GetBridgeIntersectionInfo(int bridgeID)
        {
            string sql = string.Format("select INTERSECT_ID from BRIDGES where BRIDGE_ID={0} ", bridgeID);
            int intersectID = int.Parse(db.ExecuteScalar(sql).ToString());
            return new Intersection().GetIntersection(intersectID);
        }



        public bool Insert(string bridgeName, int sectionID, int intersectID, string details, bool pededstrians, bool midIsland, bool sideCurb, bool midIslandGood,
            bool sideCurbGood, bool lighting, string lightLoc, string lightCount, bool elecMH, bool stcMH, string elecMhCount, string stcMhCount, bool shoulders, bool shouldersGood,
            bool trafficSigns, bool guideSigns, int contractorID, string num, string user, int bridgeTypeID, int cammerTypeID, double? cammerheight, int supporterTypeID,
            int? supportersCount, int sideBarrierTypeID, int? lanesCount, double? laneWidth, double? tileWidth, double? entranceWidth, double? x, double? y, double? z,
            int? builtYear, bool curved, bool perpend, double? curbHeight, double? curbWidth, double? midIslandWidth, bool drain, int? openingsCount, double? bridgeHeight,
            int surfaceTypeID)
        {
            if (sectionID == 0 && intersectID == 0)
                return false;

            string openingsCountPart = (openingsCount == null) ? "NULL" : ((int)openingsCount).ToString();
            string cammerheightPart = (cammerheight == null) ? "NULL" : ((double)cammerheight).ToString();
            string supportersCountPart = (supportersCount == null) ? "NULL" : ((int)supportersCount).ToString();
            string lanesCountPart = (lanesCount == null) ? "NULL" : ((int)lanesCount).ToString();
            string laneWidthPart = (laneWidth == null) ? "NULL" : ((double)laneWidth).ToString();
            string tileWidthPart = (tileWidth == null) ? "NULL" : ((double)tileWidth).ToString();
            string entranceWidthPart = (entranceWidth == null) ? "NULL" : ((double)entranceWidth).ToString();
            string xPart = (x == null) ? "NULL" : ((double)x).ToString();
            string yPart = (y == null) ? "NULL" : ((double)y).ToString();
            string zPart = (z == null) ? "NULL" : ((double)z).ToString();
            string builtYearPart = (builtYear == null) ? "NULL" : ((int)builtYear).ToString();
            string curbHeightPart = (curbHeight == null) ? "NULL" : ((double)curbHeight).ToString();
            string bridgeHeightPart = (bridgeHeight == null) ? "NULL" : ((double)bridgeHeight).ToString();
            string curbWidthPart = (curbWidth == null) ? "NULL" : ((double)curbWidth).ToString();
            string midIslandWidthPart = (midIslandWidth == null) ? "NULL" : ((double)midIslandWidth).ToString();


            string locationIdPart = (sectionID == 0) ? "INTERSECT_ID " : "SECTION_ID ";
            string locationIDValue = (sectionID == 0) ? intersectID.ToString() : sectionID.ToString();

            lightLoc = string.IsNullOrEmpty(lightLoc) ? "NULL" : string.Format("'{0}'", lightLoc.Replace("'", "''"));
            details = string.IsNullOrEmpty(details) ? "NULL" : string.Format("'{0}'", details.Replace("'", "''"));
            num = string.IsNullOrEmpty(num) ? "NULL" : string.Format("'{0}'", num.Replace("'", "''"));

            string lightCountPart = lighting ? int.Parse(lightCount).ToString() : "NULL";
            string elecMhCountPart = elecMH ? int.Parse(elecMhCount).ToString() : "NULL";
            string stcMhCountPart = stcMH ? int.Parse(stcMhCount).ToString() : "NULL";

            string sql = string.Format("insert into BRIDGES(BRIDGE_ID, BRIDGE_NAME, PEDESTRIAN, {0}, LIGHTING_TRUE, LIGHTING_LOC, LIGHTING_COUNT, MID_ISLAND_TRUE, " +
                " SIDE_CURB_TRUE, MID_ISLAND_GOOD, SIDE_CURB_GOOD, SHOULDERS_TRUE, SHOULDERS_GOOD, " +
                " ELEC_MH_TRUE, ELEC_MH_COUNT, STC_MH_TRUE, STC_MH_COUNT, TRAFFIC_SIGNS_TRUE, GUIDE_SIGNS_TRUE, DETAILS, " +
                " CONTRACTOR_ID, BRIDGE_NO, BRIDGE_TYPE_ID, OPENINGS_COUNT, CAMMERS_TYPE_ID, CAMMERS_HEIGHT, SUPPORTER_TYPE_ID, SUPPORTERS_COUNT, SIDE_BARRIER_TYPE_ID, LANES_COUNT, " +
                " LANE_WIDTH, TILE_WIDTH, ENTRANCE_WIDTH, COORD_X, COORD_Y, COORD_Z, BUILT_YEAR, BRIDGE_HEIGHT, CURVED, ROAD_PERPEND, " +
                " CURB_HEIGHT, CURB_WIDTH, MID_ISLAND_WIDTH, DRAIN_EXISTS, SURFACE_TYPE_ID) " +
                " values(SEQ_BRIDGE.nextval, '{1}', '{2}', {3}, '{4}', {5}, {6}, '{7}', " +
                " '{8}', '{9}', '{10}', '{11}', '{12}', " +
                " '{13}', {14}, '{15}', {16}, '{17}', '{18}', {19}, " +
                " {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, " +
                " {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, '{38}', '{39}', " +
                " {40}, {41}, {42}, '{43}', {44}) ",
                // cammersCountPart, int? cammersCount,
                locationIdPart, bridgeName, Shared.Bool2YN(pededstrians), locationIDValue, Shared.Bool2YN(lighting), lightLoc, lightCountPart, Shared.Bool2YN(midIsland),
                Shared.Bool2YN(sideCurb), Shared.Bool2YN(midIslandGood), Shared.Bool2YN(sideCurbGood), Shared.Bool2YN(shoulders), Shared.Bool2YN(shouldersGood),
                Shared.Bool2YN(elecMH), elecMhCountPart, Shared.Bool2YN(stcMH), stcMhCountPart, Shared.Bool2YN(trafficSigns), Shared.Bool2YN(guideSigns), details,
                contractorID, num, bridgeTypeID, openingsCountPart, cammerTypeID, cammerheightPart, supporterTypeID, supportersCountPart, sideBarrierTypeID, lanesCountPart,
                laneWidthPart, tileWidthPart, entranceWidthPart, xPart, yPart, zPart, builtYearPart, bridgeHeightPart, Shared.Bool2YN(curved), Shared.Bool2YN(perpend),
                curbHeightPart, curbWidthPart, midIslandWidthPart, Shared.Bool2YN(drain), surfaceTypeID);

            //int rows = db.ExecuteNonQuery(sql);
            int newID = db.ExecuteNonQuery(sql); //.ExecuteInsertWithIDReturn(sql, "BRIDGES");
            Shared.SaveLogfile("Bridges", newID.ToString(), "Insert Info", user);
            return (newID > 0);
        }


        public bool Update(string bridgeName, string details, bool pededstrians, bool midIsland, bool sideCurb, bool midIslandGood, bool sideCurbGood, bool lighting,
            string lightLoc, string lightCount, bool elecMH, bool stcMH, string elecMhCount, string stcMhCount, bool shoulders, bool shouldersGood, bool trafficSigns,
            bool guideSigns, int bridgeID, int contractorID, string num, string user, int bridgeTypeID, int cammerTypeID, double? cammerheight, int supporterTypeID, 
            int? supportersCount, int sideBarrierTypeID, int? lanesCount, double? laneWidth, double? tileWidth, double? entranceWidth, double? x, double? y, double? z, 
            int? builtYear, bool curved, bool perpend, double? curbHeight, double? curbWidth, double? midIslandWidth, bool drain, int? openingsCount, double? bridgeHeight, 
            int surfaceTypeID)
        {
            if (bridgeID == 0)
                return false;

            string openingsCountPart = (openingsCount == null) ? "NULL" : ((int)openingsCount).ToString();
            string cammerheightPart = (cammerheight == null) ? "NULL" : ((double)cammerheight).ToString();
            string supportersCountPart = (supportersCount == null) ? "NULL" : ((int)supportersCount).ToString();
            string lanesCountPart = (lanesCount == null) ? "NULL" : ((int)lanesCount).ToString();
            string laneWidthPart = (laneWidth == null) ? "NULL" : ((double)laneWidth).ToString();
            string tileWidthPart = (tileWidth == null) ? "NULL" : ((double)tileWidth).ToString();
            string entranceWidthPart = (entranceWidth == null) ? "NULL" : ((double)entranceWidth).ToString();
            string xPart = (x == null) ? "NULL" : ((double)x).ToString();
            string yPart = (y == null) ? "NULL" : ((double)y).ToString();
            string zPart = (z == null) ? "NULL" : ((double)z).ToString();
            string builtYearPart = (builtYear == null) ? "NULL" : ((int)builtYear).ToString();
            string curbHeightPart = (curbHeight == null) ? "NULL" : ((double)curbHeight).ToString();
            string bridgeHeightPart = (bridgeHeight == null) ? "NULL" : ((double)bridgeHeight).ToString();
            string curbWidthPart = (curbWidth == null) ? "NULL" : ((double)curbWidth).ToString();
            string midIslandWidthPart = (midIslandWidth == null) ? "NULL" : ((double)midIslandWidth).ToString();


            lightLoc = string.IsNullOrEmpty(lightLoc) ? "NULL" : string.Format("'{0}'", lightLoc.Replace("'", "''"));
            details = string.IsNullOrEmpty(details) ? "NULL" : string.Format("'{0}'", details.Replace("'", "''"));
            num = string.IsNullOrEmpty(num) ? "NULL" : string.Format("'{0}'", num.Replace("'", "''"));

            string lightCountPart = lighting ? int.Parse(lightCount).ToString() : "NULL";
            string elecMhCountPart = elecMH ? int.Parse(elecMhCount).ToString() : "NULL";
            string stcMhCountPart = stcMH ? int.Parse(stcMhCount).ToString() : "NULL";

            string sql = string.Format("update BRIDGES set BRIDGE_NAME='{0}', PEDESTRIAN='{1}', LIGHTING_TRUE='{2}', LIGHTING_LOC={3}, LIGHTING_COUNT={4}, MID_ISLAND_TRUE='{5}', " +
                " SIDE_CURB_TRUE='{6}', MID_ISLAND_GOOD='{7}', SIDE_CURB_GOOD='{8}', SHOULDERS_TRUE='{9}', SHOULDERS_GOOD='{10}', ELEC_MH_TRUE='{11}', ELEC_MH_COUNT={12}, " +
                " STC_MH_TRUE='{13}', STC_MH_COUNT={14}, TRAFFIC_SIGNS_TRUE='{15}', GUIDE_SIGNS_TRUE='{16}', DETAILS={17}, " + 
                " CONTRACTOR_ID={19}, BRIDGE_NO={20}, BRIDGE_TYPE_ID={21}, OPENINGS_COUNT={22}, CAMMERS_TYPE_ID={23}, CAMMERS_HEIGHT={24}, SUPPORTER_TYPE_ID={25}, " + 
                " SUPPORTERS_COUNT={26}, SIDE_BARRIER_TYPE_ID={27}, LANES_COUNT={28}, LANE_WIDTH={29}, TILE_WIDTH={30}, ENTRANCE_WIDTH={31}, COORD_X={32}, COORD_Y={33}, " + 
                " COORD_Z={34}, BUILT_YEAR={35}, BRIDGE_HEIGHT={36}, CURVED='{37}', ROAD_PERPEND='{38}', CURB_HEIGHT={39}, CURB_WIDTH={40}, MID_ISLAND_WIDTH={41}, " + 
                " DRAIN_EXISTS='{42}', SURFACE_TYPE_ID={43} where BRIDGE_ID={18} ",
                bridgeName, Shared.Bool2YN(pededstrians), Shared.Bool2YN(lighting), lightLoc, lightCountPart, Shared.Bool2YN(midIsland),
                Shared.Bool2YN(sideCurb), Shared.Bool2YN(midIslandGood), Shared.Bool2YN(sideCurbGood), Shared.Bool2YN(shoulders), Shared.Bool2YN(shouldersGood),
                Shared.Bool2YN(elecMH), elecMhCountPart, Shared.Bool2YN(stcMH), stcMhCountPart, Shared.Bool2YN(trafficSigns), Shared.Bool2YN(guideSigns), details, bridgeID,
                contractorID, num, bridgeTypeID, openingsCountPart, cammerTypeID, cammerheightPart, supporterTypeID, 
                supportersCountPart, sideBarrierTypeID, lanesCountPart, laneWidthPart, tileWidthPart, entranceWidthPart, xPart, yPart, 
                zPart, builtYearPart, bridgeHeightPart,  Shared.Bool2YN(curved), Shared.Bool2YN(perpend), curbHeightPart, curbWidthPart, midIslandWidthPart, 
                Shared.Bool2YN(drain), surfaceTypeID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("Bridges", bridgeID.ToString(), "Update Info", user);
            return (rows > 0);
        }


        public bool Delete(int BRIDGE_ID)
        {
            if (BRIDGE_ID == 0)
                return false;

            string sql = string.Format("delete from BRIDGES where BRIDGE_ID={0} ", BRIDGE_ID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("BRIDGES", BRIDGE_ID.ToString(), "Delete", System.Web.HttpContext.Current.Session["UserName"].ToString());
            return (rows > 0);
        }


    }
}
