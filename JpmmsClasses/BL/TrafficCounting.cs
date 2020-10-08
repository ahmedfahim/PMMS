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
    public class TrafficCounting
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        //public DataTable GetTrafficCountingForMainStreet()
        //{
        //    string sql = "SELECT * FROM traffic_counting_street  ORDER BY arname, SEC_DIRECTION, SEC_ORDER, SECTION_NO ";
        //    return db.ExecuteQuery(sql);
        //}

        public DataTable GetTrafficCountingForMainStreet(int mainStreetID)
        {
            //if (mainStreetID == 0)
            //    return new DataTable();
            string streetPart = (mainStreetID == 0) ? "" : string.Format(" where STREET_ID={0} ", mainStreetID);

            string sql = string.Format("SELECT * FROM traffic_counting_street {0}   ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO ", streetPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetTrafficCountingForSectionsSurroundingRegion(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string regionNum = new Region().GetRegionNum(regionID);
            string sql = string.Format("SELECT * FROM traffic_counting_street where section_no like '{0}%'  ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO ", regionNum);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetTrafficCountingForMainStreet(DateTime? from, DateTime? to)
        {
            if (from == null || to == null)
                return new DataTable();

            // MAIN_STREET_ID={0} and  int mainStreetID,  mainStreetID, 
            string sql = string.Format("SELECT * FROM traffic_counting_street where END_TIME between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY')  ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO ",
                ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"));

            return db.ExecuteQuery(sql);
        }


    }
}
