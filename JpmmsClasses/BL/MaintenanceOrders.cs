using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace JpmmsClasses.BL
{
    public class MaintenanceOrders
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();

        public DataTable GetMaintOrders(string CONTRACTOR_NO)
        {
            string sql = string.Format("select * from jpmms.VW_GetMaintOrders where CONTRACTOR_ID=(select CONTRACTOR_ID from  jpmms.CONTRACTOR where CONTRACTOR_NO='{0}')", CONTRACTOR_NO);
            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }


        public DataTable GetAll()
        {
            //string sql = "SELECT mo.MAINTAIN_ORDER_ID, mo.CONTRACT_NO, mo.CONTRACT_NAME, mo.CONTRACTOR_ID, mo.CONTRACT_DATE, mo.CONTRACT_BEGIN, mo.CONTRACT_END, c.CONTRACTOR_NAME FROM MAINTENANCE_ORDERS mo, CONTRACTOR c WHERE mo.CONTRACTOR_ID = c.CONTRACTOR_ID ORDER BY mo.CONTRACT_DATE DESC ";
            string sql = "select * from VW_MAINT_ORDERS ";
            return db.ExecuteQuery(sql);
        }


        public bool Insert(string CONTRACT_NO, string CONTRACT_NAME, int CONTRACTOR_ID, DateTime? CONTRACT_DATE, DateTime? CONTRACT_BEGIN, DateTime? CONTRACT_END,
            int WORK_STATUS)
        {
            CONTRACT_NO = CONTRACT_NO.Replace("'", "''");
            CONTRACT_NAME = CONTRACT_NAME.Replace("'", "''");
            bool upWorking = (WORK_STATUS == 1);

            // bool upWorking, bool stopped, bool cancelled
            //CONTRACT_DATE = string.IsNullOrEmpty(CONTRACT_DATE) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(CONTRACT_DATE));
            //CONTRACT_BEGIN = string.IsNullOrEmpty(CONTRACT_BEGIN) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(CONTRACT_BEGIN));
            //CONTRACT_END = string.IsNullOrEmpty(CONTRACT_END) ? "NULL" : string.Format("'{0}'", Shared.FormatDateArEgDMY(CONTRACT_END));

            string contractDatePart = (CONTRACT_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_DATE).ToString("dd/MM/yyyy"));
            string contractBeginPart = (CONTRACT_BEGIN == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_BEGIN).ToString("dd/MM/yyyy"));
            string contractEndPart = (CONTRACT_END == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_END).ToString("dd/MM/yyyy"));

            string sql = string.Format("INSERT INTO MAINTENANCE_ORDERS(MAINTAIN_ORDER_ID, CONTRACT_NO, CONTRACT_NAME, CONTRACTOR_ID, CONTRACT_DATE, CONTRACT_BEGIN, CONTRACT_END, UP_WORKING, WORK_STATUS) " +
                " VALUES (SEQ_MAINTENANCE_ORDERS.nextval, '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, {7}) ",
                CONTRACT_NO, CONTRACT_NAME, CONTRACTOR_ID, contractDatePart, contractBeginPart, contractEndPart, Shared.Bool2Int(upWorking), WORK_STATUS);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(string CONTRACT_NO, string CONTRACT_NAME, int CONTRACTOR_ID, DateTime? CONTRACT_DATE, DateTime? CONTRACT_BEGIN, DateTime? CONTRACT_END,
            int MAINTAIN_ORDER_ID, int WORK_STATUS)
        {
            // bool UP_WORKING, bool STOPPED, bool CANCELLED
            //string CONTRACT_DATE, string CONTRACT_BEGIN, string CONTRACT_END, int MAINTAIN_ORDER_ID)
            CONTRACT_NO = CONTRACT_NO.Replace("'", "''");
            CONTRACT_NAME = CONTRACT_NAME.Replace("'", "''");
            bool upWorking = (WORK_STATUS == 1);

            string contractDatePart = (CONTRACT_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_DATE).ToString("dd/MM/yyyy"));
            string contractBeginPart = (CONTRACT_BEGIN == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_BEGIN).ToString("dd/MM/yyyy"));
            string contractEndPart = (CONTRACT_END == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_END).ToString("dd/MM/yyyy"));

            string sql = string.Format("UPDATE MAINTENANCE_ORDERS SET CONTRACT_NO='{0}', CONTRACT_NAME='{1}', CONTRACTOR_ID={2}, CONTRACT_DATE={3}, CONTRACT_BEGIN={4}, " +
                " CONTRACT_END={5}, UP_WORKING={7}, WORK_STATUS={8} WHERE MAINTAIN_ORDER_ID={6} ",
                CONTRACT_NO, CONTRACT_NAME, CONTRACTOR_ID, contractDatePart, contractBeginPart, contractEndPart, MAINTAIN_ORDER_ID, Shared.Bool2Int(upWorking), 
                WORK_STATUS);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Delete(int MAINTAIN_ORDER_ID)
        {
            int rows = 0;
            DeleteDetailForMaintenanceOrder(MAINTAIN_ORDER_ID);

            string sql = string.Format("delete from MAINTENANCE_ORDERS WHERE MAINTAIN_ORDER_ID={0} ", MAINTAIN_ORDER_ID);
            rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }



        public DataTable GetAllDetails(int MAINTAIN_ORDER_ID)
        {
            if (MAINTAIN_ORDER_ID == 0)
                return new DataTable();

            string sql = string.Format("SELECT RECORD_ID, MAINTAIN_ORDER_ID, DETAILS FROM MAINTAIN_ORDER_DET where MAINTAIN_ORDER_ID={0} ORDER BY DETAILS ", MAINTAIN_ORDER_ID);
            return db.ExecuteQuery(sql);
        }

        public bool InsertDetail(int MAINTAIN_ORDER_ID, string DETAILS)
        {
            DETAILS = DETAILS.Replace("'", "''");

            string sql = string.Format("INSERT INTO MAINTAIN_ORDER_DET(RECORD_ID, MAINTAIN_ORDER_ID, DETAILS) VALUES (SEQ_MAINTENANCE_ORDER_DETS.nextval, {0}, '{1}') ", MAINTAIN_ORDER_ID, DETAILS);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool UpdateDetail(int MAINTAIN_ORDER_ID, string DETAILS, int RECORD_ID)
        {
            DETAILS = DETAILS.Replace("'", "''");

            string sql = string.Format("update MAINTAIN_ORDER_DET set MAINTAIN_ORDER_ID={0}, DETAILS='{1}' where RECORD_ID={2} ", MAINTAIN_ORDER_ID, DETAILS, RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteDetail(int RECORD_ID)
        {
            string sql = string.Format("delete from MAINTAIN_ORDER_DET WHERE RECORD_ID={0} ", RECORD_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        private bool DeleteDetailForMaintenanceOrder(int MAINTAIN_ORDER_ID)
        {
            int rows = 0;
            string sql = string.Format("delete from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID in (select RECORD_ID from  MAINTAIN_ORDER_DET where MAINTAIN_ORDER_ID={0}) ", MAINTAIN_ORDER_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from MAINTAIN_ORDER_DET WHERE MAINTAIN_ORDER_ID={0} ", MAINTAIN_ORDER_ID);
            rows += db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool AddMaintenanceOrdersDetailLocations(int maintenanceOrderDetailID, bool section, bool intersect, bool region, int mainID, int subID, bool district,
            bool munic, string title)
        {
            int rows = 0;
            string sql = "";
            string lang = HttpContext.Current.Session["lang"].ToString();

            if (section)
            {
                if (subID != 0)
                {
                    sql = string.Format("select record_id from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={0} and SECTION_ID={1} and IS_SECTION=1 ", maintenanceOrderDetailID, subID);
                    if (db.ExecuteQuery(sql).Rows.Count > 0)
                        throw new Exception(Feedback.InsertExceptionUnique());

                    //                                                                              0                   1           2         
                    sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, STREET_ID, SECTION_ID, IS_SECTION) " + // MAIN_ST_ID
                        " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, mainID, subID);

                    rows = db.ExecuteNonQuery(sql);
                }
                else
                {
                    //DialogResult r = MessageBox.Show("هل تريد فعلا إضافة كل مقاطع هذا الطريق؟", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //if (r == DialogResult.Yes)
                    //{ MAIN_STREET_ID
                    sql = string.Format("select section_id from sections where STREET_ID={0} and section_id not in (select section_id from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={1} and section_id is not null)  ", mainID, maintenanceOrderDetailID);
                    DataTable dtSections = db.ExecuteQuery(sql);
                    foreach (DataRow dr in dtSections.Rows)
                    {
                        sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, STREET_ID, SECTION_ID, IS_SECTION) " +
                       " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, mainID, dr["section_id"].ToString());

                        rows += db.ExecuteNonQuery(sql);
                    }
                    //}
                }

                return (rows > 0);
            }
            else if (intersect)
            {
                if (subID != 0)
                {
                    sql = string.Format("select record_id from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={0} and INTERSECT_ID={1} and IS_INTERSECT=1 ", maintenanceOrderDetailID, subID);
                    if (db.ExecuteQuery(sql).Rows.Count > 0)
                        throw new Exception(Feedback.InsertExceptionUnique());

                    //                                                                              0                   1           2         
                    sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, STREET_ID, INTERSECT_ID, IS_INTERSECT) " +
                        " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, mainID, subID);

                    rows = db.ExecuteNonQuery(sql);
                }
                else
                {
                    //DialogResult r = MessageBox.Show("هل تريد فعلا إضافة كل تقاطعات هذا الطريق؟", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //if (r == DialogResult.Yes)
                    //{
                    sql = string.Format("select INTERSECTION_ID from INTERSECTIONS where STREET_ID={0} and INTERSECTION_ID not in (select INTERSECT_ID from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={1} and INTERSECT_ID is not null)   ", mainID, maintenanceOrderDetailID);
                    DataTable dtIntersects = db.ExecuteQuery(sql);
                    foreach (DataRow dr in dtIntersects.Rows)
                    {
                        //                                                                              0                   1           2         
                        sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, STREET_ID, INTERSECT_ID, IS_INTERSECT) " +
                            " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, mainID, dr["INTERSECTION_ID"].ToString());

                        rows += db.ExecuteNonQuery(sql);
                    }
                    //}
                }

                return (rows > 0);
            }
            else if (region)
            {
                if (subID != 0)
                {
                    // SECOND_ST_ID
                    sql = string.Format("select record_id from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={0} and STREET_ID={1} and IS_REGION=1 ", maintenanceOrderDetailID, subID);
                    if (db.ExecuteQuery(sql).Rows.Count > 0)
                        throw new Exception(Feedback.InsertExceptionUnique());

                    //                                                                              0                   1           2         
                    sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, REGION_ID, STREET_ID, IS_REGION) " + // SECOND_ST_ID
                        " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, mainID, subID);

                    rows = db.ExecuteNonQuery(sql);
                }
                else
                {
                    //DialogResult r = MessageBox.Show("هل تريد فعلا إضافة كل الشوارع الفرعية بهذه المنطقة؟", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //if (r == DialogResult.Yes)
                    //{
                    //sql = string.Format("select second_id from SECONDARY_STREETS where REGION_ID={0} and second_id not in (select SECOND_ST_ID from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={1} and SECOND_ST_ID is not null) ", mainID, maintenanceOrderDetailID);
                    sql = string.Format("select STREET_ID from STREETS where REGION_ID={0} and STREET_ID not in (select STREET_ID from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={1} and STREET_ID is not null) ", mainID, maintenanceOrderDetailID);
                    DataTable dtSecSt = db.ExecuteQuery(sql);
                    foreach (DataRow dr in dtSecSt.Rows)
                    {
                        //                                                                              0                   1           2         
                        sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, REGION_ID, STREET_ID, IS_REGION) " +
                            " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, mainID, dr["STREET_ID"].ToString());

                        rows += db.ExecuteNonQuery(sql);
                    }
                    //}
                }

                return (rows > 0);
            }
            else if (district)
            {
                //DialogResult r = MessageBox.Show("هل تريد فعلا إضافة كل الشوارع الفرعية بمجموعة المناطق هذه؟", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                //if (r == DialogResult.Yes && !string.IsNullOrEmpty(title))
                //{
                sql = string.Format("select STREET_ID, REGION_ID from GV_SEC_STREET where DIST_NAME='{0}' and STREET_ID not in (select STREET_ID from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={1} and STREET_ID is not null) ", title, maintenanceOrderDetailID);
                DataTable dtSecSt = db.ExecuteQuery(sql);
                foreach (DataRow dr in dtSecSt.Rows)
                {
                    //                                                                              0                   1           2         
                    sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, REGION_ID, STREET_ID, IS_REGION) " +
                        " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, dr["REGION_ID"].ToString(), dr["STREET_ID"].ToString());

                    rows += db.ExecuteNonQuery(sql);
                }
                //}

                return (rows > 0);
            }
            else if (munic)
            {
                sql = string.Format("select STREET_ID, REGION_ID from GV_SEC_STREET where MUNIC_NAME='{0}' and STREET_ID not in (select STREET_ID from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={1} and STREET_ID is not null) ", title, maintenanceOrderDetailID);
                DataTable dtSecSt = db.ExecuteQuery(sql);
                foreach (DataRow dr in dtSecSt.Rows)
                {
                    //                                                                              0                   1           2         
                    sql = string.Format("insert into MAINTAIN_ORDER_DET_LOCS(RECORD_ID, MAINTAIN_ORDER_DETAIL_ID, REGION_ID, STREET_ID, IS_REGION) " +
                        " values(SEQ_MAINTENANCE_ORDERS_LOC.nextval, {0}, {1}, {2}, 1) ", maintenanceOrderDetailID, dr["REGION_ID"].ToString(), dr["STREET_ID"].ToString());

                    rows += db.ExecuteNonQuery(sql); // second_id
                }

                return (rows > 0);
            }
            else
                return false;
        }

        public bool DeleteMaintenanceOrdersDetailLocations(int RECORD_ID)
        {
            string sql = string.Format("delete from MAINTAIN_ORDER_DET_LOCS where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        private bool DeleteMaintenanceOrdersDetailLocationsByDetail(int MAINTAIN_ORDER_DETAIL_ID)
        {
            string sql = string.Format("delete from MAINTAIN_ORDER_DET_LOCS where MAINTAIN_ORDER_DETAIL_ID={0} ", MAINTAIN_ORDER_DETAIL_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable GetMaintenanceOrdersDetailLocations(int maintenanceOrderDetailID)
        {
            string sql = string.Format("select * from  VW_MAINT_ORDERS_LOCS where MAINTAIN_ORDER_DETAIL_ID={0} ", maintenanceOrderDetailID);
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(string detail, int contractorID, DateTime? from, DateTime? to, bool mainSt, int id, bool allRoads)
        {
            string sql = "select * from VW_MAINT_ORDERS_FULL ";
            bool firstArgs = true;

            if (!string.IsNullOrEmpty(detail))
            {
                if (firstArgs)
                {
                    sql = string.Format("{0} where DETAILS like '%{1}%' ", sql, detail.Replace("'", "''"));
                    firstArgs = false;
                }
                else
                    sql = string.Format("{0} and DETAILS like '%{1}%' ", sql, detail.Replace("'", "''"));
            }

            if (contractorID != 0)
            {
                if (firstArgs)
                {
                    sql = string.Format("{0} where CONTRACTOR_ID={1} ", sql, contractorID);
                    firstArgs = false;
                }
                else
                    sql = string.Format("{0} and CONTRACTOR_ID={1} ", sql, contractorID);
            }

            if (from != null && to != null)
            {
                if (firstArgs)
                {
                    sql = string.Format("{0} where CONTRACT_DATE between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY')) ", sql, ((DateTime)from).ToString("dd/MM/yyyy"),
                        ((DateTime)to).ToString("dd/MM/yyyy"));
                    firstArgs = false;
                }
                else
                    sql = string.Format("{0} and CONTRACT_DATE between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY')) ", sql, ((DateTime)from).ToString("dd/MM/yyyy"),
                        ((DateTime)to).ToString("dd/MM/yyyy"));
            }

            if (!allRoads && id != 0)
            {
                string colName = mainSt ? "STREET_ID" : "REGION_ID"; // MAIN_ST_ID
                if (firstArgs)
                {
                    sql = string.Format("{0} where {2}={1} ", sql, id, colName);
                    firstArgs = false;
                }
                else
                    sql = string.Format("{0} and {2}={1} ", sql, id, colName);
            }


            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable GetMaintenanceOrdersByLocation(bool section, bool intersect, bool region, string sectionID, string intersectID, string secStreetID)
        {
            string wherePart = (section ? string.Format(" where SECTION_ID={0} ", sectionID) : (intersect ? string.Format(" where INTERSECT_ID={0} ", intersectID) : string.Format(" where street_id={0} ", secStreetID)));
            string sql = string.Format("select * from VW_MAINT_ORDERS_FULL {0} ", wherePart);
            return db.ExecuteQuery(sql);
        }


    }
}
