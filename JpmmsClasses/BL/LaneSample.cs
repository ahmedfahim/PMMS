using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL
{
    public class LaneSample
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetLaneSamples(int laneID)
        {
            //if (string.IsNullOrEmpty(laneID))
            if (laneID == 0)
                return new DataTable();

            string sql = string.Format("SELECT SAMPLE_NO, SAMPLE_LENGTH, SAMPLE_WIDTH, (nvl(SAMPLE_LENGTH, 0) * nvl(SAMPLE_WIDTH, 0)) AS AREA, SAMPLE_ID, NOTES FROM  LANE_SAMPLES where lane_id={0} ORDER BY lpad(SAMPLE_NO, 10) ", laneID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetLaneSampleDetails(int laneSampleID)
        {
            if (laneSampleID == 0)
                return new DataTable();

            string sql = string.Format("select * from GV_SAMPLES where SAMPLE_ID={0} ORDER BY SAMPLE_NO ", laneSampleID);
            return db.ExecuteQuery(sql);
        }

        public DataTable AdvancedSearch(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("select * from GV_SAMPLES where STREET_ID={0} ", mainStID); // MAIN_STREET_ID
            return db.ExecuteQuery(sql);
        }

        public bool UpdateLaneInfo(double SAMPLE_LENGTH, double SAMPLE_WIDTH, int SAMPLE_ID, string user, string NOTES)
        {
            string sql = "";
            if (SAMPLE_LENGTH == 0 || SAMPLE_WIDTH == 0)
            {
                sql = string.Format("delete from DISTRESS WHERE SAMPLE_ID={0} ", SAMPLE_ID);
                db.ExecuteNonQuery(sql);
            }

            sql = string.Format("update LANE_SAMPLES set SAMPLE_LENGTH={0}, SAMPLE_WIDTH={1}, NOTES='{3}' where SAMPLE_ID={2} ", SAMPLE_LENGTH, SAMPLE_WIDTH, SAMPLE_ID, NOTES);
            int rows = db.ExecuteNonQuery(sql);

            // SAMPLE_LENGTH={0}, SAMPLE_WIDTH={1},  SAMPLE_LENGTH, SAMPLE_WIDTH, 
            sql = string.Format("update LANE_SAMPLE_DETAILS set NOTES='{0}' where SAMPLE_ID={1} ", NOTES, SAMPLE_ID);
            rows += db.ExecuteNonQuery(sql);

            rows += FixDistressesAfterAreaChange(SAMPLE_LENGTH, SAMPLE_WIDTH, SAMPLE_ID, user);


            Shared.SaveLogfile("LANE_SAMPLES", SAMPLE_ID.ToString(), "Update Area", user);
            return (rows > 0);
        }



        public bool UpdateLaneSampleDetails(string sample_No, string SAMPLE_LENGTH, string SAMPLE_WIDTH, bool hasOpening, string openingWidth, string openingLength,
            bool parking, int parkingMethodID, bool uTurn, string uTurnLength, string uTurnWidth, bool sidewalkPainted, bool sidewalkPaintGood, bool hasHandicappedSlope,
            bool handicappedSlopeGood, bool hasSpeedBumps, bool SpeedBumpLegal, bool SpeedBumpIllegal, string SpeedBumpsCount, bool pedestrian, bool pedestrianGood,
            int SAMPLE_ID, bool concreteBlocks, string concreteBlocksCount, string user, int speedBumpType)
        {
            int sampleNo = int.Parse(sample_No);
            string sampleWidthPart = string.IsNullOrEmpty(SAMPLE_WIDTH) ? "NULL" : decimal.Parse(SAMPLE_WIDTH).ToString("N2");
            string sampleLengthPart = string.IsNullOrEmpty(SAMPLE_LENGTH) ? "NULL" : decimal.Parse(SAMPLE_LENGTH).ToString("N2");

            string openingWidthPart = hasOpening ? decimal.Parse(openingWidth).ToString("N2") : "NULL";
            string openingLengthPart = hasOpening ? decimal.Parse(openingLength).ToString("N2") : "NULL";

            string uTurnWidthPart = uTurn ? decimal.Parse(uTurnWidth).ToString("N2") : "NULL";
            string uTurnLengthPart = uTurn ? decimal.Parse(uTurnLength).ToString("N2") : "NULL";
            string spBumpsCount = hasSpeedBumps ? int.Parse(SpeedBumpsCount).ToString() : "NULL";
            string concreteBlocksCountPart = concreteBlocks ? int.Parse(concreteBlocksCount).ToString() : "NULL";

            string parkingMethodPart = (parkingMethodID == 0) ? "NULL" : parkingMethodID.ToString();
            string speedBumpTypePart = (speedBumpType == 0) ? "NULL" : speedBumpType.ToString();


            string sql = string.Format("update LANE_SAMPLE_DETAILS set MAIN_SRVC_OPENING_TRUE='{0}', MAIN_SRVC_OPENING_WIDTH={1}, MAIN_SRVC_OPENING_LENGTH={2}, " +
                " IS_PARKING='{3}', PARKING_METHOD={4}, U_TURN_TRUE='{5}', U_TURN_LENGTH={6}, U_TURN_WIDTH={7}, SIDEWALK_PAINT_TRUE='{8}', " +
                " SIDEWALK_PAINT_GOOD='{9}', HANDICAPPED_SLOPE_TRUE='{10}', HANDICAPPED_SLOPE_GOOD='{11}', SPEED_BUMPS_TRUE='{12}', " +
                " SPEED_BUMPS_LEGAL='{13}', SPEED_BUMPS_ILLEGAL='{14}', SPEED_BUMPS_COUNT={15}, PEDESTRIAN='{16}', PEDESTRIAN_GOOD='{17}', " +
                " SAMPLE_NO='{19}', CONCRETE_BLOCKS='{20}', CONCRETE_BLOCKS_COUNT={21}, SPEED_BUMP_TYPE_ID={22} where SAMPLE_ID={18} ",
                    Shared.Bool2YN(hasOpening), openingWidthPart, openingLengthPart,
                    Shared.Bool2YN(parking), parkingMethodPart, Shared.Bool2YN(uTurn), uTurnLengthPart, uTurnWidthPart, Shared.Bool2YN(sidewalkPainted),
                    Shared.Bool2YN(sidewalkPaintGood), Shared.Bool2YN(hasHandicappedSlope), Shared.Bool2YN(handicappedSlopeGood), Shared.Bool2YN(hasSpeedBumps),
                    Shared.Bool2YN(SpeedBumpLegal), Shared.Bool2YN(SpeedBumpIllegal), spBumpsCount, Shared.Bool2YN(pedestrian), Shared.Bool2YN(pedestrianGood),
                    SAMPLE_ID, sample_No, Shared.Bool2YN(concreteBlocks), concreteBlocksCountPart, speedBumpTypePart);

            int rows = db.ExecuteNonQuery(sql);


            sql = string.Format("update LANE_SAMPLES set SAMPLE_LENGTH={0}, SAMPLE_WIDTH={1} where SAMPLE_ID={2} ", sampleLengthPart, sampleWidthPart, SAMPLE_ID);
            rows += db.ExecuteNonQuery(sql);

            rows += FixDistressesAfterAreaChange(double.Parse(SAMPLE_LENGTH), double.Parse(SAMPLE_WIDTH), SAMPLE_ID, user);


            Shared.SaveLogfile("LANE_SAMPLES", SAMPLE_ID.ToString(), "Update Info", user);
            return (rows > 0);
        }


        public int FixDistressesAfterAreaChange(double SAMPLE_LENGTH, double SAMPLE_WIDTH, int SAMPLE_ID, string user)
        {
            int rows = 0;
            string sql = "";

            if (SAMPLE_LENGTH == 0 || SAMPLE_WIDTH == 0)
            {
                sql = string.Format("delete from DISTRESS WHERE SAMPLE_ID={0} ", SAMPLE_ID);
                rows += db.ExecuteNonQuery(sql);
            }
            else
            {
                int distID = 0;
                int distressCode = 0;
                char DIST_SEVERITY;
                double distressDensity = 0;
                double distArea = 0;
                double deductValue = 0;
                double densityDashValue = 0;
                double deductDashValue = 0;

                double SampleArea = SAMPLE_LENGTH * SAMPLE_WIDTH;


                sql = string.Format("SELECT STATUS_UPD, dist_code, DIST_SEVERITY, DIST_AREA, DIST_ID FROM DISTRESS WHERE SAMPLE_ID={0} ", SAMPLE_ID);
                DataTable dtSecondStDist = db.ExecuteQuery(sql);
                foreach (DataRow dr in dtSecondStDist.Rows)
                {
                    distID = int.Parse(dr["DIST_ID"].ToString());
                    distressCode = int.Parse(dr["dist_code"].ToString());
                    DIST_SEVERITY = dr["DIST_SEVERITY"].ToString()[0];
                    distArea = double.Parse(dr["DIST_AREA"].ToString());
                    distressDensity = (distArea / SampleArea) * 100.0;
                    distressDensity = (distressDensity > 100) ? 100 : distressDensity;

                    deductValue = DistressShared.CalculateDeductValue(distressCode, DIST_SEVERITY);
                    densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("G2")));
                    deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);

                    sql = string.Format("UPDATE DISTRESS SET STATUS='N', STATUS_UPD='N', DIST_DENSITY={0}, DEDUCT_VALUE={1}, DEN_DASH={2}, DEDUCT_DEN_DASH={3}  WHERE DIST_ID={4} ",
                        distressDensity.ToString("0.00"), deductValue.ToString("0.00"), densityDashValue.ToString("0.00"), deductDashValue.ToString("0.00"), distID);

                    rows += db.ExecuteNonQuery(sql);
                    Shared.SaveLogfile("DISTRESS", distID.ToString(), "Distress Update", user);
                }
            }

            return rows;
        }


        public static bool SampleReadyForDistressEntry(int sampleID)
        {
            if (sampleID == 0)
                return false;

            string sql = string.Format("SELECT SAMPLE_ID, SAMPLE_NO, SAMPLE_LENGTH, SAMPLE_WIDTH, (SAMPLE_LENGTH * SAMPLE_WIDTH) AS AREA FROM LANE_SAMPLES WHERE SAMPLE_ID={0} AND  SAMPLE_LENGTH IS NOT NULL AND SAMPLE_WIDTH IS NOT NULL", sampleID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);

            return (dt.Rows.Count > 0) ? decimal.Parse(dt.Rows[0]["AREA"].ToString()) > 0 : false;
        }

    }
}
