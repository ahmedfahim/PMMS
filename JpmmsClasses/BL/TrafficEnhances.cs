using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JpmmsClasses.BL;
using System.Web;

namespace JpmmsClasses.BL
{
    public class TrafficEnhances
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        public DataTable GetAll()
        {
            string sql = "select RECORD_ID, PROPOSE_TITLE, APPROVE_DATE, LETTER_FROM, LETTER_DATE, LETTER_NO, COMMITTE_HEAD_NAME, NOTES, MUNIC_NAME, APPROVE_DATE_H, LETTER_DATE_H from TRAFF_ENHANCES order by APPROVE_DATE desc ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByID(int trafficEnhanceID)
        {
            if (trafficEnhanceID == 0)
                return new DataTable();

            string sql = string.Format("select RECORD_ID, PROPOSE_TITLE, APPROVE_DATE, LETTER_FROM, LETTER_DATE, LETTER_NO, COMMITTE_HEAD_NAME, NOTES, MUNIC_NAME, APPROVE_DATE_H, LETTER_DATE_H from TRAFF_ENHANCES where RECORD_ID={0} ", trafficEnhanceID);
            return db.ExecuteQuery(sql);
        }


        public bool Insert(string PROPOSE_TITLE, string APPROVE_DATE, string LETTER_FROM, string LETTER_DATE, string LETTER_NO, string COMMITTE_HEAD_NAME, string NOTES,
            string MUNIC_NAME, string APPROVE_DATE_H, string LETTER_DATE_H)
        {
            string approveDatePart = (APPROVE_DATE == null) ? "NULL" : string.Format("'{0}'", DateTime.Parse(APPROVE_DATE).ToString("dd/MM/yyyy"));
            string letterDatePart = (LETTER_DATE == null) ? "NULL" : string.Format("'{0}'", DateTime.Parse(LETTER_DATE).ToString("dd/MM/yyyy"));

            PROPOSE_TITLE = PROPOSE_TITLE.Replace("'", "''");
            LETTER_FROM = LETTER_FROM.Replace("'", "''");
            COMMITTE_HEAD_NAME = COMMITTE_HEAD_NAME.Replace("'", "''");

            LETTER_NO = string.IsNullOrEmpty(LETTER_NO) ? "NULL" : string.Format("'{0}'", LETTER_NO.Replace("'", "''"));
            NOTES = string.IsNullOrEmpty(NOTES) ? "NULL" : string.Format("'{0}'", NOTES.Replace("'", "''"));
            APPROVE_DATE_H = string.IsNullOrEmpty(APPROVE_DATE_H) ? "NULL" : string.Format("'{0}'", APPROVE_DATE_H.Replace("'", "''"));
            LETTER_DATE_H = string.IsNullOrEmpty(LETTER_DATE_H) ? "NULL" : string.Format("'{0}'", LETTER_DATE_H.Replace("'", "''"));

            //                                                                       0            1           2             3           4               5             6         7           8               9   
            string sql = string.Format("insert into TRAFF_ENHANCES(RECORD_ID, PROPOSE_TITLE, APPROVE_DATE, LETTER_FROM, LETTER_DATE, LETTER_NO, COMMITTE_HEAD_NAME, NOTES, MUNIC_NAME, APPROVE_DATE_H, LETTER_DATE_H) " +
                " values(SEQ_TRAFFIC_ENHANCES.nextval, '{0}', {1}, '{2}', {3}, {4}, '{5}', {6}, '{7}', {8}, {9}) ",
                PROPOSE_TITLE, approveDatePart, LETTER_FROM, letterDatePart, LETTER_NO, COMMITTE_HEAD_NAME, NOTES, MUNIC_NAME, APPROVE_DATE_H, LETTER_DATE_H);

            int rows = db.ExecuteNonQuery(sql);
            if (rows > 0)
            {
                // TODO: Add job order for newly added traffic enhancement entry

            }

            return (rows > 0);
        }

        public bool Update(string PROPOSE_TITLE, string APPROVE_DATE, string LETTER_FROM, string LETTER_DATE, string LETTER_NO, string COMMITTE_HEAD_NAME, string NOTES,
            string MUNIC_NAME, string APPROVE_DATE_H, string LETTER_DATE_H, int trafficEnhanceID)
        {
            string approveDatePart = (APPROVE_DATE == null) ? "NULL" : string.Format("'{0}'", DateTime.Parse(APPROVE_DATE).ToString("dd/MM/yyyy"));
            string letterDatePart = (LETTER_DATE == null) ? "NULL" : string.Format("'{0}'", DateTime.Parse(LETTER_DATE).ToString("dd/MM/yyyy"));

            PROPOSE_TITLE = PROPOSE_TITLE.Replace("'", "''");
            LETTER_FROM = LETTER_FROM.Replace("'", "''");
            COMMITTE_HEAD_NAME = COMMITTE_HEAD_NAME.Replace("'", "''");

            LETTER_NO = string.IsNullOrEmpty(LETTER_NO) ? "NULL" : string.Format("'{0}'", LETTER_NO.Replace("'", "''"));
            NOTES = string.IsNullOrEmpty(NOTES) ? "NULL" : string.Format("'{0}'", NOTES.Replace("'", "''"));
            APPROVE_DATE_H = string.IsNullOrEmpty(APPROVE_DATE_H) ? "NULL" : string.Format("'{0}'", APPROVE_DATE_H.Replace("'", "''"));
            LETTER_DATE_H = string.IsNullOrEmpty(LETTER_DATE_H) ? "NULL" : string.Format("'{0}'", LETTER_DATE_H.Replace("'", "''"));


            string sql = string.Format("update TRAFF_ENHANCES set PROPOSE_TITLE='{0}', APPROVE_DATE={1}, LETTER_FROM='{2}', LETTER_DATE={3}, LETTER_NO={4}, " +
                " COMMITTE_HEAD_NAME='{5}', NOTES={6}, MUNIC_NAME='{7}', APPROVE_DATE_H={8}, LETTER_DATE_H={9} where RECORD_ID={10} ",
                PROPOSE_TITLE, approveDatePart, LETTER_FROM, letterDatePart, LETTER_NO,
                COMMITTE_HEAD_NAME, NOTES, MUNIC_NAME, APPROVE_DATE_H, LETTER_DATE_H, trafficEnhanceID);

            int rows = db.ExecuteNonQuery(sql);
            if (rows > 0)
            {
                // TODO: update job order of update traffic enhancement
            }

            return (rows > 0);
        }


        public DataTable SearchTrafficEnahnce(string detail, DateTime? from, DateTime? to, bool mainSt, int id, bool allRoads, bool locations)
        {
            string sql = locations ? "select * from VW_TRAFFIC_ENHANCE_LOCS " : "select * from VW_TRAFFIC_ENHANCES_FULL ";
            bool firstArgs = true;

            if (!string.IsNullOrEmpty(detail))
            {
                if (firstArgs)
                {
                    sql = string.Format("{0} where RECORD_ID in (select TRAFFIC_ENHANCE_ID from TRAFF_ENHANCES_DETAILS  where DETAILS like '%{1}%') ", sql, detail.Replace("'", "''"));
                    firstArgs = false;
                }
                else
                    sql = string.Format("{0} and RECORD_ID in (select TRAFFIC_ENHANCE_ID from TRAFF_ENHANCES_DETAILS  where DETAILS like '%{1}%') ", sql, detail.Replace("'", "''"));
            }

            if (from != null && to != null)
            {
                if (firstArgs)
                {
                    sql = string.Format("{0} where APPROVE_DATE between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY')) ", sql, ((DateTime)from).ToString("dd/MM/yyyy"),
                        ((DateTime)to).ToString("dd/MM/yyyy"));
                    firstArgs = false;
                }
                else
                    sql = string.Format("{0} and APPROVE_DATE between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY')) ", sql, ((DateTime)from).ToString("dd/MM/yyyy"),
                        ((DateTime)to).ToString("dd/MM/yyyy"));
            }

            if (!allRoads && id != 0)
            {
                string colName = mainSt ? "STREET_ID" : "REGION_ID"; // MAIN_ST_ID
                if (firstArgs)
                {
                    sql = string.Format("{0} where RECORD_ID in (select TRAFFIC_ENHANCE_ID from VW_TRAFFIC_ENHANCE_LOCS where {2}={1}) ", sql, id, colName);
                    firstArgs = false; // TRAFFENHANCE_DETAIL_LOCATIONS 
                }
                else
                    sql = string.Format("{0} and RECORD_ID in (select TRAFFIC_ENHANCE_ID from VW_TRAFFIC_ENHANCE_LOCS where {2}={1}) ", sql, id, colName);
            }


            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }


        #region TrafficEnhanceDetailsLocations

        public DataTable GetAllDetails(int trafficEnhanceID)
        {
            if (trafficEnhanceID == 0)
                return new DataTable();

            string sql = string.Format("SELECT RECORD_ID, TRAFFIC_ENHANCE_ID, DETAILS FROM TRAFF_ENHANCES_DETAILS where TRAFFIC_ENHANCE_ID={0} ORDER BY DETAILS ", trafficEnhanceID);
            return db.ExecuteQuery(sql);
        }

        public bool InsertDetail(int TRAFFIC_ENHANCE_ID, string DETAILS)
        {
            DETAILS = DETAILS.Replace("'", "''");

            string sql = string.Format("INSERT INTO TRAFF_ENHANCES_DETAILS(RECORD_ID, TRAFFIC_ENHANCE_ID, DETAILS) VALUES (SEQ_MAINTENANCE_ORDER_DETS.nextval, {0}, '{1}') ", TRAFFIC_ENHANCE_ID, DETAILS);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool UpdateDetail(int TRAFFIC_ENHANCE_ID, string DETAILS, int RECORD_ID)
        {
            DETAILS = DETAILS.Replace("'", "''");

            string sql = string.Format("update TRAFF_ENHANCES_DETAILS set TRAFFIC_ENHANCE_ID={0}, DETAILS='{1}' where RECORD_ID={2} ", TRAFFIC_ENHANCE_ID, DETAILS, RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteDetail(int RECORD_ID)
        {
            string sql = string.Format("delete from TRAFF_ENHANCES_DETAILS WHERE RECORD_ID={0} ", RECORD_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteTrafficEnhance(int RECORD_ID)
        {
            int rows = 0;
            string sql = string.Format("delete from TRAFF_ENHANCES_DETAILS where TRAFFIC_ENHANCE_ID={0} ", RECORD_ID); //in (select RECORD_ID from  TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={0}) ", );
            rows += db.ExecuteNonQuery(sql);

            DeleteTrafficEnhanceLocations(RECORD_ID);


            sql = string.Format("select PHOTO_NAME from TRAFF_ENHANCES_FILES where TRAFFIC_ENHANCE_ID={0} ", RECORD_ID); // RECORD_ID
            DataTable dt = db.ExecuteQuery(sql);
            foreach (DataRow dr in dt.Rows)
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/uploads/") + dr["PHOTO_NAME"].ToString());


            sql = string.Format("delete from TRAFF_ENHANCES_FILES WHERE TRAFFIC_ENHANCE_ID={0} ", RECORD_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from TRAFF_ENHANCES WHERE RECORD_ID={0} ", RECORD_ID);
            rows += db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool AddTrafficEnhanceLocationsForMainStreets(int trafficEnhanceID, bool section, bool intersect, int mainID, int subID)
        {
            int rows = 0;
            string sql = "";
            string lang = HttpContext.Current.Session["lang"].ToString();

            if (section)
            {
                if (subID != 0)
                {
                    sql = string.Format("select record_id from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={0} and SECTION_ID={1} and IS_SECTION=1 ", trafficEnhanceID, subID);
                    if (db.ExecuteQuery(sql).Rows.Count > 0)
                        throw new Exception(Feedback.InsertExceptionUnique());

                    //                                                                              0                   1           2         
                    sql = string.Format("insert into TRAFFENHANCE_DETAIL_LOCATIONS(RECORD_ID, TRAFFENHANCE_DET_ID, STREET_ID, SECTION_ID, IS_SECTION) " + // MAIN_ST_ID
                        " values(SEQ_TRAFFENHANCE_LOC.nextval, {0}, {1}, {2}, 1) ", trafficEnhanceID, mainID, subID);

                    rows = db.ExecuteNonQuery(sql);
                }
                else
                {
                    sql = string.Format("select section_id from sections where STREET_ID={0} and section_id not in (select section_id from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={1} and section_id is not null)  ", mainID, trafficEnhanceID);
                    DataTable dtSections = db.ExecuteQuery(sql);  // MAIN_STREET_ID
                    foreach (DataRow dr in dtSections.Rows)
                    {
                        sql = string.Format("insert into TRAFFENHANCE_DETAIL_LOCATIONS(RECORD_ID, TRAFFENHANCE_DET_ID, STREET_ID, SECTION_ID, IS_SECTION) " +
                       " values(SEQ_TRAFFENHANCE_LOC.nextval, {0}, {1}, {2}, 1) ", trafficEnhanceID, mainID, dr["section_id"].ToString());

                        rows += db.ExecuteNonQuery(sql);
                    }
                }

                return (rows > 0);
            }
            else if (intersect)
            {
                if (subID != 0)
                {
                    sql = string.Format("select record_id from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={0} and INTERSECT_ID={1} and IS_INTERSECT=1 ", trafficEnhanceID, subID);
                    if (db.ExecuteQuery(sql).Rows.Count > 0)
                        throw new Exception(Feedback.InsertExceptionUnique());

                    //                                                                              0                   1           2         
                    sql = string.Format("insert into TRAFFENHANCE_DETAIL_LOCATIONS(RECORD_ID, TRAFFENHANCE_DET_ID, STREET_ID, INTERSECT_ID, IS_INTERSECT) " +
                        " values(SEQ_TRAFFENHANCE_LOC.nextval, {0}, {1}, {2}, 1) ", trafficEnhanceID, mainID, subID);

                    rows = db.ExecuteNonQuery(sql);
                }
                else
                {
                    sql = string.Format("select INTERSECTION_ID from INTERSECTIONS where STREET_ID={0} and INTERSECTION_ID not in (select INTERSECT_ID from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={1} and INTERSECT_ID is not null)   ", mainID, trafficEnhanceID);
                    DataTable dtIntersects = db.ExecuteQuery(sql); // MAIN_STREET_ID
                    foreach (DataRow dr in dtIntersects.Rows)
                    {
                        //                                                                              0                   1           2         
                        sql = string.Format("insert into TRAFFENHANCE_DETAIL_LOCATIONS(RECORD_ID, TRAFFENHANCE_DET_ID, STREET_ID, INTERSECT_ID, IS_INTERSECT) " +
                            " values(SEQ_TRAFFENHANCE_LOC.nextval, {0}, {1}, {2}, 1) ", trafficEnhanceID, mainID, dr["INTERSECTION_ID"].ToString()); // MAIN_ST_ID

                        rows += db.ExecuteNonQuery(sql);
                    }
                }

                return (rows > 0);
            }
            else
                return false;
        }

        public bool AddTrafficEnhanceLocationsforRegions(int trafficEnhanceID, int mainID, int subID, bool landUse, string landUseDetails)
        {
            int rows = 0;
            string sql = "";
            //string lang = HttpContext.Current.Session["lang"].ToString();
            landUseDetails = string.IsNullOrEmpty(landUseDetails) ? "NULL" : string.Format("'{0}'", landUseDetails.Replace("'", "''"));

            if (subID != 0)
            {
                sql = string.Format("select record_id from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={0} and SECOND_ST_ID={1} and IS_REGION=1 ", trafficEnhanceID, subID);
                if (db.ExecuteQuery(sql).Rows.Count > 0)
                    throw new Exception(Feedback.InsertExceptionUnique());

                //                                                                              0                   1           2                       3           4
                sql = string.Format("insert into TRAFFENHANCE_DETAIL_LOCATIONS(RECORD_ID, TRAFFENHANCE_DET_ID, REGION_ID, STREET_ID, IS_REGION, IS_LAND_USE, LANDUSE_DETAILS) " +
                    " values(SEQ_TRAFFENHANCE_LOC.nextval, {0}, {1}, {2}, 1, {3}, {4}) ", // SECOND_ST_ID
                    trafficEnhanceID, mainID, subID, Shared.Bool2Int(landUse), landUseDetails);

                rows = db.ExecuteNonQuery(sql);
            }
            else
            {
                // SECOND_ST_ID   second_id 
                //sql = string.Format("select STREET_ID from SECONDARY_STREETS where REGION_ID={0} and second_id not in (select STREET_ID from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={1} and REGION_ID is not null) ", mainID, trafficEnhanceID);
                sql = string.Format("select STREET_ID from STREETS where REGION_ID={0} and STREET_ID not in (select STREET_ID from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={1} and REGION_ID is not null) ", mainID, trafficEnhanceID);
                DataTable dtSecSt = db.ExecuteQuery(sql);
                foreach (DataRow dr in dtSecSt.Rows)
                {
                    //                                                                              0                   1           2                       3           4
                    sql = string.Format("insert into TRAFFENHANCE_DETAIL_LOCATIONS(RECORD_ID, TRAFFENHANCE_DET_ID, REGION_ID, STREET_ID, IS_REGION, IS_LAND_USE, LANDUSE_DETAILS) " +
                        " values(SEQ_TRAFFENHANCE_LOC.nextval, {0}, {1}, {2}, 1, {3}, {4}) ",
                        trafficEnhanceID, mainID, dr["STREET_ID"].ToString(), Shared.Bool2Int(landUse), landUseDetails); // second_id

                    rows += db.ExecuteNonQuery(sql);
                }
            }

            return (rows > 0);
        }



        public bool DeleteTrafficEnhanceLocations(int RECORD_ID)
        {
            if (RECORD_ID == 0)
                return false;

            string sql = string.Format("delete from TRAFFENHANCE_DETAIL_LOCATIONS where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        private bool DeleteTrafficEnhanceLocationsByDetail(int TRAFFENHANCE_DET_ID)
        {
            if (TRAFFENHANCE_DET_ID == 0)
                return false;

            string sql = string.Format("delete from TRAFFENHANCE_DETAIL_LOCATIONS where TRAFFENHANCE_DET_ID={0} ", TRAFFENHANCE_DET_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable GeTrafficEnhanceLocations(int TRAFF_ENHANCES_id)
        {
            if (TRAFF_ENHANCES_id == 0)
                return new DataTable();

            // VW_MAINT_ORDERS_LOCS
            string sql = string.Format("select * from VW_TRAFFIC_ENHANCE_LOCS where TRAFFENHANCE_DET_ID={0} ", TRAFF_ENHANCES_id);
            return db.ExecuteQuery(sql);
        }

        #endregion

        #region TrafficEnahnceFiles

        public bool AddImage(int ID, string imageName, string details)
        {
            if (ID == 0 || string.IsNullOrEmpty(imageName))
                return false;

            imageName = imageName.Replace("'", "''");
            string detailsPart = string.IsNullOrEmpty(details) ? "NULL" : string.Format("'{0}'", details.Replace("'", "''"));

            string sql = string.Format("insert into TRAFF_ENHANCES_FILES(RECORD_ID, TRAFFIC_ENHANCE_ID, PHOTO_NAME, DETAILS) values (SEQ_PHOTOS.nextval, {0}, '{1}', {2}) ", ID, imageName, detailsPart);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public DataTable GetImages(int ID)
        {
            if (ID == 0)
                return new DataTable();

            string sql = string.Format("SELECT RECORD_ID, PHOTO_NAME, DETAILS FROM TRAFF_ENHANCES_FILES where TRAFFIC_ENHANCE_ID={0} ", ID);
            return db.ExecuteQuery(sql);
        }

        public bool UpdateImageDetails(int RECORD_ID, string DETAILS)
        {
            if (RECORD_ID == 0)
                return false;

            string detailsPart = string.IsNullOrEmpty(DETAILS) ? "NULL" : string.Format("'{0}'", DETAILS.Replace("'", "''"));

            string sql = string.Format("update TRAFF_ENHANCES_FILES set DETAILS={0} where RECORD_ID={1} ", detailsPart, RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteImage(int RECORD_ID)
        {
            if (RECORD_ID == 0)
                return false;

            string sql = string.Format("select PHOTO_NAME from TRAFF_ENHANCES_FILES where RECORD_ID={0} ", RECORD_ID);
            string fileName = db.ExecuteScalar(sql).ToString();
            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/uploads/") + fileName);

            sql = string.Format("delete from TRAFF_ENHANCES_FILES where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        #endregion

    }
}
