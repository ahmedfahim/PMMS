using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL.Lookups
{
    public class BridgeTunnelLookups
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetBridgeTypes()
        {
            string sql = "select BRIDGE_TYPE_ID, BRIDGE_TYPE from BRIDGE_TYPES order by BRIDGE_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetPedestrianBridgeTypes()
        {
            string sql = "select TYPE_ID, PEDESTRIAN_BRIDGE_TYPE from PEDESTRIAN_BRIDGE_TYPE order by PEDESTRIAN_BRIDGE_TYPE ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeBarrierTypes()
        {
            string sql = "select BARRIER_TYPE_ID, BARRIER_TYPES from BRIDGE_BARRIER_TYPES order by BARRIER_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeCammerTypes()
        {
            string sql = "select CAMMER_TYPE_ID, CAMMER_TYPE from BRIDGE_CAMMER_TYPES order by CAMMER_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeTunnelDistressTypes()
        {
            string sql = "select DISTRESS_TYPE_ID, DISTRESS_TYPE,  (DISTRESS_TYPE||' - '||DISTRESS_TYPE_EN) as DISTRESS_TITLE from BRIDGE_DISTRESS_TYPES order by DISTRESS_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeTunnelElements()
        {
            string sql = "select B_ELEMENT_ID, B_ELEMENT_NAME from BRIDGE_DISTRESS_TYPES order by B_ELEMENT_NAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeTunnelElements(int bridgeID, int tunnelID)
        {
            string sql = "";
            if (bridgeID != 0)
                sql = "select B_ELEMENT_ID, B_ELEMENT_NAME from BRIDGE_ELEMENTS where FOR_BRIDGE=1 order by B_ELEMENT_NAME ";
            else
                sql = "select B_ELEMENT_ID, B_ELEMENT_NAME from BRIDGE_ELEMENTS where FOR_TUNNEL=1 order by B_ELEMENT_NAME ";

            if (!string.IsNullOrEmpty(sql))
                return db.ExecuteQuery(sql);
            else
                return new DataTable();
        }

        public DataTable GetBridgeTunnelEvalCriteria()
        {
            string sql = "select CRITERIA_ID, CRITERIA_NAME, DETAILS, (CRITERIA_ID||'-'||CRITERIA_NAME|| ' - ' || DETAILS) as CRITERIA_title from BRIDGE_EVAL_CRITERIA order by CRITERIA_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeSupporterTypes()
        {
            string sql = "select SUPPORTER_TYPE_ID, SUPPORTER_TYPE from BRIDGE_SUPPORTER_TYPES order by SUPPORTER_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetBridgeSurfaceTypes()
        {
            string sql = "select SURFACE_TYPE_ID, SURFACE_TYPE from BRIDGE_SURFACE_TYPES order by SURFACE_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }


        public DataTable GetTunnelTypes()
        {
            string sql = "select TUNNEL_TYPE_ID, TUNNEL_TYPE from TUNNEL_TYPES order by TUNNEL_TYPE_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetCategories()
        {
            string sql = "select MAINST_CATEGORY_ID, MAINST_CATEGORY from MAINST_CATEGORIES order by MAINST_CATEGORY ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSpeedBumpsTypes()
        {
            string sql = "select SPEED_BUMP_TYPE_ID, SPEED_BUMP_TYPE from SPEED_BUMP_TYPES order by SPEED_BUMP_TYPE ";
            return db.ExecuteQuery(sql);
        }

    }
}
