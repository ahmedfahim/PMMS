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
    public class Lane
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetSectionLanes(int sectionID)
        {
            if (sectionID == 0)
                return new DataTable();

            // SAMPLE_count,  (select count(SAMPLE_NO) from LANE_SAMPLES where LANE_SAMPLES.lane_id=LANE.LANE_id) as SAMPLE_count, (lane_length*LANE_WIDTH) as SAMPLE_area
            string sql = string.Format("SELECT LANE_ID, LANE_TYPE, lane_length, LANE_WIDTH, SAMPLE_COUNT, SAMPLE_AREA FROM LANE WHERE SECTION_ID={0}  ORDER BY LANE_TYPE ", sectionID);
            return db.ExecuteQuery(sql);
        }

        public bool UpdateLaneInfo(double? LANE_LENGTH, double? LANE_WIDTH, int? SAMPLE_COUNT, double? SAMPLE_AREA, int LANE_ID)
        {
            string laneLengthpart = (LANE_LENGTH == null) ? "NULL" : ((double)LANE_LENGTH).ToString("0.00");
            string laneWidthpart = (LANE_WIDTH == null) ? "NULL" : ((double)LANE_WIDTH).ToString("0.00");
            string samplesCountPart = (SAMPLE_COUNT == null) ? "NULL" : SAMPLE_COUNT.ToString();
            string samplesAreapart = (SAMPLE_AREA == null) ? "NULL" : ((double)SAMPLE_AREA).ToString("0.00");

            string sql = string.Format("update LANE set LANE_LENGTH={0}, LANE_WIDTH={1}, SAMPLE_COUNT={2}, SAMPLE_AREA={3} where LANE_ID='{4}' ",
                laneLengthpart, laneWidthpart, samplesCountPart, samplesAreapart, LANE_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public static bool LaneSurveyIsComplete(int laneID)
        {
            string sql = string.Format(" select (nvl(lane_length, 0) * nvl(LANE_WIDTH, 0)) as lane_area from LANE where LANE_ID='{0}' ", laneID);
            decimal laneArea = decimal.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
            return (laneArea == 0) ? false : true;
        }


    }
}
