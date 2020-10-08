using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL
{
    public class ImagesGallery
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public bool AddImage(int ID, string imageName, string details, RoadType type)
        {
            if (ID == 0 || string.IsNullOrEmpty(imageName))
                return false;

            string sql = "";
            imageName = imageName.Replace("'", "''");
            string detailsPart = string.IsNullOrEmpty(details) ? "NULL" : string.Format("'{0}'", details.Replace("'", "''"));

            switch (type)
            {
                case RoadType.Section:
                    sql = string.Format("insert into PHOTOS(RECORD_ID, SECTION_ID, PHOTO_NAME, DETAILS, entry_date) values (SEQ_PHOTOS.nextval, {0}, '{1}', {2}, (select sysdate from dual)) ", ID, imageName, detailsPart);
                    break;
                case RoadType.Intersect:
                    sql = string.Format("insert into PHOTOS(RECORD_ID, INTER_ID, PHOTO_NAME, DETAILS, entry_date) values (SEQ_PHOTOS.nextval, {0}, '{1}', {2}, (select sysdate from dual)) ", ID, imageName, detailsPart);
                    break;
                case RoadType.RegionSecondarySt:
                    sql = string.Format("insert into PHOTOS(RECORD_ID, STREET_ID, PHOTO_NAME, DETAILS, entry_date) values (SEQ_PHOTOS.nextval, {0}, '{1}', {2}, (select sysdate from dual)) ", ID, imageName, detailsPart);
                    break; // SECOND_ID
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(sql))
            {
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                return false;
        }


        public DataTable GetImages(int ID, bool isMainSt)
        {
            if (isMainSt)
                return GetImages(ID, RoadType.MainStreet);
            else
                return GetImages(ID, RoadType.RegionSecondarySt);
        }

        public DataTable GetImages(int ID, RoadType type)
        {
            if (ID == 0)
                return new DataTable();

            string sql1 = "";
            string sql2 = "";
            string sql = "";

            switch (type)
            {
                case RoadType.Section:
                    sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where SECTION_ID={0} ", ID);
                    sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc where d.dist_code=dc.dist_code and SECTION_ID={0} and DISTRESS_IMAGE is not null ", ID);
                    break;
                case RoadType.Intersect:
                    sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where INTER_ID={0} ", ID);
                    sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc where d.dist_code=dc.dist_code and INTERSECTION_ID={0} and DISTRESS_IMAGE is not null ", ID);

                    break;
                case RoadType.RegionSecondarySt:
                    sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where STREET_ID in (select STREET_ID from STREETS where REGION_ID={0}) ", ID);
                    sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc where d.dist_code=dc.dist_code and REGION_ID={0} and DISTRESS_IMAGE is not null ", ID);

                    //sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where SECOND_ID in (select SECOND_ID from SECONDARY_STREETS where REGION_ID={0}) ", ID);
                    //sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc where d.dist_code=dc.dist_code and REGION_ID={0} and DISTRESS_IMAGE is not null ", ID);
                    break;

                case RoadType.MainStreet:
                    sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where SECTION_ID in (select section_id from sections where STREET_ID={0}) or INTER_ID in (select INTERSECTION_ID from INTERSECTIONS where STREET_ID={0}) ", ID); // MAIN_STREET_ID
                    sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc " +
                        " where d.dist_code=dc.dist_code and (SECTION_NO in (select section_no from sections where STREET_ID={0}) " +
                        " or INTER_NO in (select inter_no from INTERSECTIONS where STREET_ID={0})) and DISTRESS_IMAGE is not null ", ID); // MAIN_STREET_ID
                    break;

                default:
                    break;
            }

            if (!string.IsNullOrEmpty(sql1) && !string.IsNullOrEmpty(sql2))
            {
                sql = string.Format("{0} union {1} ", sql1, sql2);
                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }


        public DataTable GetImages(int ID, bool mainSt, bool secST, int RegionID)
        {
            string sql1 = "", sql2 = "", sql = "";
            if (secST)
            {
                sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where STREET_ID in (select STREET_ID from STREETS where REGION_ID={0}) ", RegionID);
                sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc where d.dist_code=dc.dist_code and REGION_ID={0} and DISTRESS_IMAGE is not null ", RegionID);

                sql = string.Format("{0} union {1} ", sql1, sql2);
            }
            else
            {
                sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where SECTION_ID in (select section_id from sections where STREET_ID={0}) or INTER_ID in (select INTERSECTION_ID from INTERSECTIONS where STREET_ID={0}) ", ID); // MAIN_STREET_ID
                sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc " +
                    " where d.dist_code=dc.dist_code and (SECTION_NO in (select section_no from sections where STREET_ID={0}) " +
                    " or INTER_NO in (select inter_no from INTERSECTIONS where STREET_ID={0})) and DISTRESS_IMAGE is not null ", ID); // MAIN_STREET_ID

                sql = string.Format("{0} union {1} ", sql1, sql2);
            }


            return db.ExecuteQuery(sql);
        }

        public DataTable GetImages(int ID, int RegionID)
        {
            string sql1 = "", sql2 = "", sql = "";
            if (RegionID != 0)
            {
                sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where STREET_ID in (select STREET_ID from STREETS where REGION_ID={0}) ", RegionID);
                sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc where d.dist_code=dc.dist_code and REGION_ID={0} and DISTRESS_IMAGE is not null ", RegionID);

                sql = string.Format("{0} union {1} ", sql1, sql2);
            }
            else
            {
                sql1 = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where SECTION_ID in (select section_id from sections where STREET_ID={0}) or INTER_ID in (select INTERSECTION_ID from INTERSECTIONS where STREET_ID={0}) ", ID); // MAIN_STREET_ID
                sql2 = string.Format("select d.DIST_ID as RECORD_ID, d.DISTRESS_IMAGE as PHOTO_NAME, dc.DISTRESS_AR_TYPE as DETAILS from DISTRESS d, distress_code dc " +
                    " where d.dist_code=dc.dist_code and (SECTION_NO in (select section_no from sections where STREET_ID={0}) " +
                    " or INTER_NO in (select inter_no from INTERSECTIONS where STREET_ID={0})) and DISTRESS_IMAGE is not null ", ID); // MAIN_STREET_ID

                sql = string.Format("{0} union {1} ", sql1, sql2);
            }


            return db.ExecuteQuery(sql);
        }



        public DataTable GetIntersectImages(int ID)
        {
            if (ID == 0)
                return new DataTable();

            string sql = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where INTER_ID={0} ORDER BY RECORD_ID", ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSectionImages(int ID)
        {
            if (ID == 0)
                return new DataTable();

            string sql = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where SECTION_ID={0} ORDER BY RECORD_ID", ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSecondaryStImages(int ID)
        {
            if (ID == 0)
                return new DataTable();

            string sql = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM PHOTOS where STREET_ID={0} ORDER BY RECORD_ID", ID); // SECOND_ID
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

        public bool DeleteDistressImage(int distID)
        {
            if (distID == 0)
                return false;

            string sql = string.Format("select DISTRESS_IMAGE from DISTRESS where DIST_ID={0} ", distID);
            string fileName = db.ExecuteScalar(sql).ToString();
            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/uploads/") + fileName);

            sql = string.Format("update DISTRESS set DISTRESS_IMAGE=null where DIST_ID={0} ", distID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable RoadNetworkHavingPhotos(RoadType type)
        {
            string sql = "";
            switch (type)
            {
                case RoadType.Section:
                case RoadType.Intersect:
                case RoadType.MainStreet:
                    sql = "select distinct main_no, main_name from GV_SECTIONS where section_id in (select section_id from photos where section_id is not null) union " +
                        " select distinct main_no, main_name from GV_INTERSECTION where intersection_id in (select inter_id from photos where INTER_ID is not null) order by main_name ";
                    break;
                case RoadType.RegionSecondarySt:
                    sql = "select distinct region_no, subdistrict from GV_sec_street where STREET_ID in (select STREET_ID from photos where STREET_ID is not null) "; // SECOND_ID 
                    break;
                default:
                    return new DataTable();
            }

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable RoadNetworkHavingNoPhotos(bool sections, bool intersects, bool region)
        {
            string sql = "";
            if (sections)
                sql = "select section_no, section_title, arname from gv_sections where section_id not in (select section_id from photos where section_id is not null)  order by arname, section_no ";
            else if (intersects)
                sql = "select inter_no, intersect_title, arname from gv_intersection where INTERSECTION_ID not in (select inter_id from photos where INTER_ID is not null)  order by arname, inter_no ";
            else if (region)
                sql = "select region_no, subdistrict, dist_name, munic_name from regions where REGION_ID not in (select REGION_ID from photos where REGION_ID is not null) order by region_no ";
            else
                return new DataTable();


            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable RoadNetworkSurveyedHavingNoPhotos(bool sections, bool intersects, bool region)
        {
            string sql = "";
            if (sections)
                sql = "select section_no, section_title, arname from gv_sections where section_id in (select section_id from UDI_SECTION) and section_id not in (select section_id from photos where section_id is not null)  order by arname, section_no ";
            else if (intersects)
                sql = "select inter_no, intersect_title, arname from gv_intersection where INTERSECTION_ID in(select INTERSECTION_ID from UDI_INTERSECTION) and INTERSECTION_ID not in (select inter_id from photos where INTER_ID is not null)  order by arname, inter_no ";
            else if (region)
                sql = "select region_no, subdistrict, dist_name, munic_name from regions where REGION_ID in(select REGION_ID from UDI_REGION) and REGION_ID not in (select REGION_ID from photos where REGION_ID is not null) order by region_no ";
            else
                return new DataTable();


            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }


    }
}
