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
    public class Tunnel
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetTunnelInfo(int TUNNEL_ID)
        {
            if (TUNNEL_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_TUNNEL_FULL_INFO where TUNNEL_ID={0} ", TUNNEL_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetTunnels(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable(); // main_street_id

            string sql = string.Format("select * from VW_TUNNEL_FULL_INFO where section_id in(select section_id from sections where STREET_ID={0}) or intersect_id in (select intersection_id from intersections where STREET_ID={0}) ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSectionTunnels(int sectionID)
        {
            if (sectionID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_TUNNEL_FULL_INFO where SECTION_ID={0} ", sectionID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionTunnels(int intersectID)
        {
            if (intersectID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_TUNNEL_FULL_INFO where INTERSECT_ID={0} ", intersectID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetTunnelSectionInfo(int tunnelID)
        {
            string sql = string.Format("select SECTION_ID from TUNNELS where TUNNEL_ID={0} ", tunnelID);
            int sectionID = int.Parse(db.ExecuteScalar(sql).ToString());
            return new MainStreetSection().GetSectionInfo(sectionID);
        }

        public DataTable GetTunnelIntersectionInfo(int tunnelID)
        {
            string sql = string.Format("select INTERSECT_ID from TUNNELS where TUNNEL_ID={0} ", tunnelID);
            int intersectID = int.Parse(db.ExecuteScalar(sql).ToString());
            return new Intersection().GetIntersection(intersectID);
        }


        public bool Insert(string tunnelName, int sectionID, int intersectID, string details, bool midIsland, bool sideCurb, bool midIslandGood, bool sideCurbGood, bool lighting,
            string lightLoc, string lightCount, bool elecMH, bool stcMH, string elecMhCount, string stcMhCount, bool paint, bool paintGood, bool trafficSigns, bool guideSigns,
            bool drainCB, bool drainCbGood, int contractorID, string num, string user, int tunnelTypeID, int cammerTypeID, double? cammerheight, int supporterTypeID,
            int? supportersCount, int sideBarrierTypeID, int? lanesCount, double? laneWidth, double? tileWidth, double? entranceWidth, double? x, double? y, double? z,
            int? builtYear, bool curved, bool perpend, double? curbHeight, double? curbWidth, double? midIslandWidth, int? openingsCount, int surfaceTypeID) //, double? bridgeHeight)
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
            //string bridgeHeightPart = (bridgeHeight == null) ? "NULL" : ((double)bridgeHeight).ToString();
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

            string sql = string.Format("insert into TUNNELS(TUNNEL_ID, TUNNEL_NAME, {0}, LIGHTING_TRUE, LIGHTING_LOC, LIGHTING_COUNT, MID_ISLAND_TRUE, SIDE_CURB_TRUE, " +
                " MID_ISLAND_GOOD, SIDE_CURB_GOOD, PAINT_TRUE, PAINT_GOOD, ELEC_MH_TRUE, ELEC_MH_COUNT, STC_MH_TRUE, STC_MH_COUNT, TRAFFIC_SIGNS_TRUE, DRAIN_CB_TRUE, " +
                " DRAIN_CB_GOOD, DETAILS, GUIDE_SIGNS_TRUE, CONTRACTOR_ID, TUNNEL_NO, TUNNEL_TYPE_ID, OPENINGS_COUNT, CAMMERS_TYPE_ID, CAMMERS_HEIGHT, SUPPORTER_TYPE_ID, " +
                " SUPPORTERS_COUNT, SIDE_BARRIER_TYPE_ID, LANES_COUNT, LANE_WIDTH, TILE_WIDTH, ENTRANCE_WIDTH, COORD_X, COORD_Y, COORD_Z, BUILT_YEAR, CURVED, " +
                " ROAD_PERPEND, CURB_HEIGHT, CURB_WIDTH, MID_ISLAND_WIDTH, SURFACE_TYPE_ID) " +
                " values(SEQ_TUNNELs.nextval, '{1}', {2}, '{3}', {4}, {5}, '{6}', '{7}', " +
                " '{8}', '{9}', '{10}', '{11}', '{12}', {13}, '{14}', {15}, '{16}', '{17}', " +
                " '{18}', {19}, '{20}', {21}, {22}, {23}, {24}, {25}, {26}, {27}, " +
                " {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, '{38}', " +
                " '{39}', {40}, {41}, {42}, {43}) ",
                locationIdPart, tunnelName, locationIDValue, Shared.Bool2YN(lighting), lightLoc, lightCountPart, Shared.Bool2YN(midIsland), Shared.Bool2YN(sideCurb),
                Shared.Bool2YN(midIslandGood), Shared.Bool2YN(sideCurbGood), Shared.Bool2YN(paint), Shared.Bool2YN(paintGood), Shared.Bool2YN(elecMH), elecMhCountPart,
                Shared.Bool2YN(stcMH), stcMhCountPart, Shared.Bool2YN(trafficSigns), Shared.Bool2YN(drainCB), 
                Shared.Bool2YN(drainCbGood), details, Shared.Bool2YN(guideSigns), contractorID, num, tunnelTypeID, openingsCountPart, cammerTypeID, cammerheightPart, supporterTypeID, 
                supportersCountPart, sideBarrierTypeID, lanesCountPart, laneWidthPart, tileWidthPart, entranceWidthPart, xPart, yPart, zPart, builtYearPart, Shared.Bool2YN(curved),
                Shared.Bool2YN(perpend), curbHeightPart, curbWidthPart, midIslandWidthPart, surfaceTypeID);

            //int rows = db.ExecuteNonQuery(sql); BRIDGE_HEIGHT, {38},
            //return (rows > 0);
            int newID = db.ExecuteNonQuery(sql); //.ExecuteInsertWithIDReturn(sql, "TUNNELS");
            Shared.SaveLogfile("TUNNELS", newID.ToString(), "Insert Info", user);
            return (newID > 0);
        }


        public bool Update(string tunnelName, string details, bool midIsland, bool sideCurb, bool midIslandGood, bool sideCurbGood, bool lighting, string lightLoc,
            string lightCount, bool elecMH, bool stcMH, string elecMhCount, string stcMhCount, bool paint, bool paintGood, bool trafficSigns, bool guideSigns, bool drainCB,
            bool drainCbGood, int tunnelID, int contractorID, string num, string user, int tunnelTypeID, int cammerTypeID, double? cammerheight, int supporterTypeID,
            int? supportersCount, int sideBarrierTypeID, int? lanesCount, double? laneWidth, double? tileWidth, double? entranceWidth, double? x, double? y, double? z,
            int? builtYear, bool curved, bool perpend, double? curbHeight, double? curbWidth, double? midIslandWidth, int? openingsCount, int surfaceTypeID) //, double? bridgeHeight)
        {
            if (tunnelID == 0)
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
            //string bridgeHeightPart = (bridgeHeight == null) ? "NULL" : ((double)bridgeHeight).ToString();
            string curbWidthPart = (curbWidth == null) ? "NULL" : ((double)curbWidth).ToString();
            string midIslandWidthPart = (midIslandWidth == null) ? "NULL" : ((double)midIslandWidth).ToString();


            lightLoc = string.IsNullOrEmpty(lightLoc) ? "NULL" : string.Format("'{0}'", lightLoc.Replace("'", "''"));
            details = string.IsNullOrEmpty(details) ? "NULL" : string.Format("'{0}'", details.Replace("'", "''"));
            num = string.IsNullOrEmpty(num) ? "NULL" : string.Format("'{0}'", num.Replace("'", "''"));

            string lightCountPart = lighting ? int.Parse(lightCount).ToString() : "NULL";
            string elecMhCountPart = elecMH ? int.Parse(elecMhCount).ToString() : "NULL";
            string stcMhCountPart = stcMH ? int.Parse(stcMhCount).ToString() : "NULL";

            string sql = string.Format("update TUNNELS set TUNNEL_NAME='{0}', LIGHTING_TRUE='{1}', LIGHTING_LOC={2}, LIGHTING_COUNT={3}, MID_ISLAND_TRUE='{4}', " +
                " SIDE_CURB_TRUE='{5}', MID_ISLAND_GOOD='{6}', SIDE_CURB_GOOD='{7}', PAINT_TRUE='{8}', PAINT_GOOD='{9}', " +
                " ELEC_MH_TRUE='{10}', ELEC_MH_COUNT={11}, STC_MH_TRUE='{12}', STC_MH_COUNT={13}, TRAFFIC_SIGNS_TRUE='{14}', DRAIN_CB_TRUE='{15}',  DRAIN_CB_GOOD='{16}', " +
                " DETAILS={17}, GUIDE_SIGNS_TRUE='{19}', CONTRACTOR_ID={20}, TUNNEL_NO={21}, TUNNEL_TYPE_ID={22}, OPENINGS_COUNT={23}, CAMMERS_TYPE_ID={24}, " +
                " CAMMERS_HEIGHT={25}, SUPPORTER_TYPE_ID={26}, SUPPORTERS_COUNT={27}, SIDE_BARRIER_TYPE_ID={28}, LANES_COUNT={29}, LANE_WIDTH={30}, TILE_WIDTH={31}, " +
                " ENTRANCE_WIDTH={32}, COORD_X={33}, COORD_Y={34}, COORD_Z={35}, BUILT_YEAR={36}, CURVED='{37}', ROAD_PERPEND='{38}', CURB_HEIGHT={39}, CURB_WIDTH={40}, " +
                " MID_ISLAND_WIDTH={41}, SURFACE_TYPE_ID={42}  where TUNNEL_ID={18} ",
                tunnelName, Shared.Bool2YN(lighting), lightLoc, lightCountPart, Shared.Bool2YN(midIsland),
                Shared.Bool2YN(sideCurb), Shared.Bool2YN(midIslandGood), Shared.Bool2YN(sideCurbGood), Shared.Bool2YN(paint), Shared.Bool2YN(paintGood),
                Shared.Bool2YN(elecMH), elecMhCountPart, Shared.Bool2YN(stcMH), stcMhCountPart, Shared.Bool2YN(trafficSigns), Shared.Bool2YN(drainCB), Shared.Bool2YN(drainCbGood),
                details, tunnelID, Shared.Bool2YN(guideSigns), contractorID, num, tunnelTypeID, openingsCountPart, cammerTypeID,
                cammerheightPart, supporterTypeID, supportersCountPart, sideBarrierTypeID, lanesCountPart, laneWidthPart, tileWidthPart,
                entranceWidthPart, xPart, yPart, zPart, builtYearPart, Shared.Bool2YN(curved), Shared.Bool2YN(perpend), curbHeightPart, curbWidthPart,
                midIslandWidthPart, surfaceTypeID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("TUNNELS", tunnelID.ToString(), "Update Info", user);
            return (rows > 0);
        }

        

        public bool Delete(int TUNNEL_ID)
        {
            if (TUNNEL_ID == 0)
                return false;

            string sql = string.Format("delete from TUNNELS where TUNNEL_ID={0} ", TUNNEL_ID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("TUNNELS", TUNNEL_ID.ToString(), "Delete Info", System.Web.HttpContext.Current.Session["UserName"].ToString());
            return (rows > 0);
        }

    }
}
