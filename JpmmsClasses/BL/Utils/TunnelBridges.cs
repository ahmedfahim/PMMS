using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using System.Web;

namespace JpmmsClasses.BL.Utils
{
    public class TunnelBridges
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetTunnelSectionInfo(int tunnelID, int bridgeID)
        {
            string tablename = (tunnelID == 0) ? "Bridges" : "Tunnels";
            string idCol = (tunnelID == 0) ? "BRIDGE_ID" : "TUNNEL_ID";
            string value = (tunnelID == 0) ? bridgeID.ToString() : tunnelID.ToString();

            string sql = string.Format("select SECTION_ID from {0} where {1}={2} ", tablename, idCol, value);
            string s = db.ExecuteScalar(sql).ToString();
            int sectionID = string.IsNullOrEmpty(s) ? 0 : int.Parse(s);
            return new MainStreetSection().GetSectionInfo(sectionID);
        }

        public DataTable GetTunnelIntersectionInfo(int tunnelID, int bridgeID)
        {
            string tablename = (tunnelID == 0) ? "Bridges" : "Tunnels";
            string idCol = (tunnelID == 0) ? "BRIDGE_ID" : "TUNNEL_ID";
            string value = (tunnelID == 0) ? bridgeID.ToString() : tunnelID.ToString();

            string sql = string.Format("select INTERSECT_ID from {0} where {1}={2} ", tablename, idCol, value);
            string s = db.ExecuteScalar(sql).ToString();
            int intersectID = string.IsNullOrEmpty(s) ? 0 : int.Parse(s);
            return new Intersection().GetIntersection(intersectID);
        }

        public DataTable GetBridgeTunnelFiles(int tunnelID, int bridgeID)
        {
            string tablename = (tunnelID == 0) ? "Bridges" : "Tunnels";
            string idCol = (tunnelID == 0) ? "BRIDGE_ID" : "TUNNEL_ID";
            string value = (tunnelID == 0) ? bridgeID.ToString() : tunnelID.ToString();

            string sql = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where {1}={0} ", value, idCol);
            return db.ExecuteQuery(sql);
        }


        public bool UpdateImageDetails(int RECORD_ID, string DETAILS)
        {
            if (RECORD_ID == 0)
                return false;

            string detailsPart = string.IsNullOrEmpty(DETAILS) ? "NULL" : string.Format("'{0}'", DETAILS.Replace("'", "''"));
            string sql = string.Format("update PHOTOS set DETAILS={0} where RECORD_ID={1} ", detailsPart, RECORD_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteImage(int RECORD_ID)
        {
            if (RECORD_ID == 0)
                return false;

            string sql = string.Format("select PHOTO_NAME from PHOTOS where RECORD_ID={0} ", RECORD_ID);
            string fileName = db.ExecuteScalar(sql).ToString();
            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/uploads/") + fileName);

            sql = string.Format("delete from PHOTOS where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool AddImage(int tunnelID, int bridgeID, string imageName, string details)
        {
            if ((tunnelID == 0 && bridgeID == 0) || string.IsNullOrEmpty(imageName))
                return false;

            imageName = imageName.Replace("'", "''");
            string detailsPart = string.IsNullOrEmpty(details) ? "NULL" : string.Format("'{0}'", details.Replace("'", "''"));
            string idCol = (tunnelID == 0) ? "BRIDGE_ID" : "TUNNEL_ID";
            string value = (tunnelID == 0) ? bridgeID.ToString() : tunnelID.ToString();


            string sql = string.Format("insert into PHOTOS(RECORD_ID, {3}, PHOTO_NAME, DETAILS) values (SEQ_PHOTOS.nextval, {0}, '{1}', {2}) ", value, imageName, detailsPart, idCol);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

    }
}
