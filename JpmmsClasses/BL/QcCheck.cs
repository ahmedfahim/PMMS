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
    public class QcCheck
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        #region QC_MasterDataInsert

        public bool InsertRegionQcCheckRecord(DateTime? qcDate, DateTime? surveyDate, int surveyorID, int checkerID, int regionID, int secondID, double? areaSurveyor,
            double? areaChecker, string user, int userID)
        {
            int rows = 0;
            string areaSurveyorPart = (areaSurveyor == null) ? "NULL" : ((double)areaSurveyor).ToString("0.00");
            string areaCheckerPart = (areaChecker == null) ? "NULL" : ((double)areaChecker).ToString("0.00");

            string sql = string.Format("select nvl(count(*), 0)  from distress where region_id={0} ", regionID);
            rows = int.Parse(db.ExecuteScalar(sql).ToString());
            if (rows > 0)
            {
                sql = string.Format("select nvl(count(*), 0) from QC_CHECK where STREET_ID={0} ", secondID); // SECOND_ID
                rows = int.Parse(db.ExecuteScalar(sql).ToString());
                if (rows > 0)
                    throw new Exception(Feedback.InsertExceptionUnique());

                //                                                              0           1           2           3               4             5          6              7                                                                8
                sql = string.Format("insert into QC_CHECK(QC_CHECK_ID, QC_DATE, SURVEY_DATE, SURVEYOR_ID, QC_CHECKER_ID, REGION_ID, STREET_ID, SURVEYOR_AREA, CHECKER_AREA, SURV_SUM_POINTS, SURV_SUM_MAX_POINTS, SURV_RATE, ENTRY_DATE, DONY_BY) " +
                    " values(SEQ_QC_CHECK.nextval, '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, {7}, 0, 0, 0, (select sysdate from dual), {8}) ",
                    ((DateTime)qcDate).ToString("dd/MM/yyyy"), ((DateTime)surveyDate).ToString("dd/MM/yyyy"), surveyorID, checkerID, regionID, secondID, areaSurveyorPart,
                    areaCheckerPart, userID); // SECOND_ID

                rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                throw new Exception("لم يتم مسح هذه المنطقة بعد");
        }

        public bool InsertSectionQcCheckRecord(DateTime? qcDate, DateTime? surveyDate, int surveyorID, int checkerID, int sectionID, int sampleID, string laneType, int userID)
        {
            int rows = 0;

            string sql = string.Format("select nvl(count(*), 0)  from distress where SECTION_ID={0} ", sectionID);
            rows = int.Parse(db.ExecuteScalar(sql).ToString());
            if (rows > 0)
            {
                sql = string.Format("select nvl(count(*), 0) from QC_CHECK where SAMPLE_ID={0} ", sampleID);
                rows = int.Parse(db.ExecuteScalar(sql).ToString());
                if (rows > 0)
                    throw new Exception(Feedback.InsertExceptionUnique());

                //                                                                0           1                  2           3           4          5             6                                                         7
                sql = string.Format("insert into QC_CHECK(QC_CHECK_ID, QC_DATE, SURVEY_DATE, SURVEYOR_ID, QC_CHECKER_ID, SECTION_ID, SAMPLE_ID, LANE_TYPE, SURV_SUM_POINTS, SURV_SUM_MAX_POINTS, SURV_RATE, ENTRY_DATE, DONY_BY) " +
                   " values(SEQ_QC_CHECK.nextval, '{0}', '{1}', {2}, {3}, {4}, {5}, '{6}',  0, 0, 0, (select sysdate from dual), {7}) ",
                   ((DateTime)qcDate).ToString("dd/MM/yyyy"), ((DateTime)surveyDate).ToString("dd/MM/yyyy"), surveyorID, checkerID, sectionID, sampleID, laneType, userID);

                rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                throw new Exception("لم يتم مسح هذا المقطع بعد");
        }

        public bool InsertIntersectQcCheckRecord(DateTime? qcDate, DateTime? surveyDate, int surveyorID, int checkerID, int intersectID, int intersectSampleID, int userID)
        {
            int rows = 0;

            string sql = string.Format("select nvl(count(*), 0)  from distress where INTERSECTION_ID={0} ", intersectID);
            rows = int.Parse(db.ExecuteScalar(sql).ToString());
            if (rows > 0)
            {
                sql = string.Format("select nvl(count(*), 0) from QC_CHECK where INTERSECT_SAMPLE_ID={0} ", intersectSampleID);
                rows = int.Parse(db.ExecuteScalar(sql).ToString());
                if (rows > 0)
                    throw new Exception(Feedback.InsertExceptionUnique());

                //                                                              0           1           2           3               4           5                                                                           6
                sql = string.Format("insert into QC_CHECK(QC_CHECK_ID, QC_DATE, SURVEY_DATE, SURVEYOR_ID, QC_CHECKER_ID, INTERSECT_ID, INTERSECT_SAMPLE_ID, SURV_SUM_POINTS, SURV_SUM_MAX_POINTS, SURV_RATE, ENTRY_DATE, DONY_BY) " +
                   " values(SEQ_QC_CHECK.nextval, '{0}', '{1}', {2}, {3}, {4}, {5},  0, 0, 0, (select sysdate from dual), {6}) ",
                   ((DateTime)qcDate).ToString("dd/MM/yyyy"), ((DateTime)surveyDate).ToString("dd/MM/yyyy"), surveyorID, checkerID, intersectID, intersectSampleID, userID);

                rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                throw new Exception("لم يتم مسح هذا التقاطع بعد");
        }

        public bool Delete(int QC_CHECK_ID)
        {
            int rows = 0;
            string sql = string.Format("delete from QC_CHECK_DETAILS where QC_CHECK_ID={0} ", QC_CHECK_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from QC_DISTRESS where QC_CHECK_ID={0} ", QC_CHECK_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from QC_CHECK where QC_CHECK_ID={0} ", QC_CHECK_ID);
            rows += db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        #endregion

        #region QC_MasterDataEdit

        public bool UpdateRegionQcCheckRecord(DateTime? QC_DATE, DateTime? SURVEY_DATE, int SURVEYOR_ID, int QC_CHECKER_ID, double? SURVEYOR_AREA, double? CHECKER_AREA,
            int QC_CHECK_ID, bool IS_CORRECTED)
        {
            if (SURVEYOR_ID == QC_CHECKER_ID)
                throw new Exception("مساح المنطقة لايمكن ان يكون هو نفس المراقب");

            int rows = 0;
            string areaSurveyorPart = (SURVEYOR_AREA == null) ? "NULL" : ((double)SURVEYOR_AREA).ToString("0.00");
            string areaCheckerPart = (CHECKER_AREA == null) ? "NULL" : ((double)CHECKER_AREA).ToString("0.00");

            string sql = string.Format("update QC_CHECK set QC_DATE='{0}', SURVEY_DATE='{1}', SURVEYOR_ID={2}, QC_CHECKER_ID={3}, SURVEYOR_AREA={4}, CHECKER_AREA={5}, " +
                " IS_CORRECTED={6} where QC_CHECK_ID={7} ",
                ((DateTime)QC_DATE).ToString("dd/MM/yyyy"), ((DateTime)SURVEY_DATE).ToString("dd/MM/yyyy"), SURVEYOR_ID, QC_CHECKER_ID, SURVEYOR_AREA, CHECKER_AREA,
                Shared.Bool2Int(IS_CORRECTED), QC_CHECK_ID);

            rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool UpdateSectionQcCheckRecord(DateTime? QC_DATE, DateTime? SURVEY_DATE, int SURVEYOR_ID, int QC_CHECKER_ID, int QC_CHECK_ID, bool IS_CORRECTED)
        {
            if (SURVEYOR_ID == QC_CHECKER_ID)
                throw new Exception("مساح المنطقة لايمكن ان يكون هو نفس المراقب");

            int rows = 0;
            string sql = string.Format("update QC_CHECK set QC_DATE='{0}', SURVEY_DATE='{1}', SURVEYOR_ID={2}, QC_CHECKER_ID={3}, IS_CORRECTED={5} where QC_CHECK_ID={4} ",
                ((DateTime)QC_DATE).ToString("dd/MM/yyyy"), ((DateTime)SURVEY_DATE).ToString("dd/MM/yyyy"), SURVEYOR_ID, QC_CHECKER_ID, QC_CHECK_ID, Shared.Bool2Int(IS_CORRECTED));

            rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool UpdateIntersectQcCheckRecord(DateTime? QC_DATE, DateTime? SURVEY_DATE, int SURVEYOR_ID, int QC_CHECKER_ID, int QC_CHECK_ID, bool IS_CORRECTED)
        {
            if (SURVEYOR_ID == QC_CHECKER_ID)
                throw new Exception("مساح المنطقة لايمكن ان يكون هو نفس المراقب");

            int rows = 0;
            string sql = string.Format("update QC_CHECK set QC_DATE='{0}', SURVEY_DATE='{1}', SURVEYOR_ID={2}, QC_CHECKER_ID={3}, IS_CORRECTED={5} where QC_CHECK_ID={4} ",
                ((DateTime)QC_DATE).ToString("dd/MM/yyyy"), ((DateTime)SURVEY_DATE).ToString("dd/MM/yyyy"), SURVEYOR_ID, QC_CHECKER_ID, QC_CHECK_ID, Shared.Bool2Int(IS_CORRECTED));

            rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        #endregion


        #region QC_Details

        public DataTable GetQcDetails(int qcID)
        {
            if (qcID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_QCHECK_DETAILS where QC_CHECK_ID={0} order by DIST_CODE ", qcID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetQcDistress(int qcID)
        {
            if (qcID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_QC_DISTRESS where QC_CHECK_ID={0} order by DIST_CODE ", qcID);
            return db.ExecuteQuery(sql);
        }


        public bool AddQCheckDistressRecord(int QC_CHECK_ID, int DIST_CODE, char DIST_SEVERITY, double SURV_DIST_AREA, double QC_DIST_AREA)
        {
            int rows = 0;
            double difference = CalculateAreaDifference(SURV_DIST_AREA, QC_DIST_AREA);
            double qcDistWeight = SeverityWeight(DIST_SEVERITY);
            double surveyorDistWeight = Convert.ToDouble(difference) * qcDistWeight;

            //                                                            0         1         2                 3               4           5           6               7           
            string sql = string.Format("insert into QC_DISTRESS(RECORD_ID, QC_CHECK_ID, DIST_CODE, DIST_SEVERITY, SURV_DIST_AREA, QC_DIST_AREA, DIFFERENCE, SURV_WEIGHT_SEV, CHECKER_WEIGHT_SEV) " +
                " values(SEQ_QC_CHECK_DETAILS.nextval, {0}, {1}, '{2}', {3}, {4}, {5}, {6}, {7}) ",
                QC_CHECK_ID, DIST_CODE, DIST_SEVERITY, SURV_DIST_AREA.ToString("0.00"), QC_DIST_AREA.ToString("0.00"), difference.ToString("0.00"), surveyorDistWeight.ToString("0.00"),
                qcDistWeight.ToString("0.00"));

            rows += db.ExecuteNonQuery(sql);

            bool processed = ProcessQcTotalsRating(QC_CHECK_ID, DIST_CODE, SURV_DIST_AREA, QC_DIST_AREA, false);
            return (rows > 0) & processed;
        }

        private bool ProcessQcTotalsRating(int qcID, int DIST_CODE, double SURV_DIST_AREA, double QC_DIST_AREA, bool deleted)
        {
            int rows = 0;

            double surveyorWeightSeverSum = 0;
            double surveyorSumArea = 0;
            double qcSumArea = 0;
            double qty_difference = 0;
            double qcWeightTotal = SeverityWeight('S');
            double distWeight = DistressWeight(DIST_CODE);


            string sql = string.Format("select SURV_DIST_AREA, QC_DIST_AREA, DIFFERENCE, SURV_WEIGHT_SEV, CHECKER_WEIGHT_SEV from QC_DISTRESS where QC_CHECK_ID={0} and DIST_CODE={1} ", qcID, DIST_CODE);
            DataTable dt = db.ExecuteQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                surveyorSumArea += double.Parse(dr["SURV_DIST_AREA"].ToString());
                qcSumArea += double.Parse(dr["QC_DIST_AREA"].ToString());
                qty_difference = CalculateAreaDifference(surveyorSumArea, qcSumArea);
                surveyorWeightSeverSum += double.Parse(dr["SURV_WEIGHT_SEV"].ToString());
            }

            surveyorWeightSeverSum = ((surveyorSumArea == 0 || qcSumArea == 0) ? 0 : surveyorWeightSeverSum + (qty_difference * qcWeightTotal));

            sql = string.Format("select DSEV_CODE from DISTRESS_SEVERITY where DSEV_CODE not in (select DIST_SEVERITY from QC_DISTRESS where DIST_CODE={0} and QC_CHECK_ID={1}) and DSEV_CODE<>'N' ", DIST_CODE, qcID);
            DataTable dtOtherSeverity = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtOtherSeverity.Rows)
            {
                surveyorWeightSeverSum += (surveyorSumArea == 0 || qcSumArea == 0) ? 0 : SeverityWeight(dr["DSEV_CODE"].ToString()[0]);
            }


            double surveyorPoints = surveyorWeightSeverSum * distWeight;
            double surveyorMaxPoints = CalculateSurveyorMaxPoints(surveyorWeightSeverSum, surveyorSumArea, qcSumArea, distWeight);


            sql = string.Format("select nvl(count(RECORD_ID), 0) as count_rows from QC_CHECK_DETAILS where QC_CHECK_ID={0} and DIST_CODE={1} ", qcID, DIST_CODE);
            int rowsCount = int.Parse(db.ExecuteScalar(sql).ToString());
            if (rowsCount > 0)
            {
                if (SURV_DIST_AREA == 0 && QC_DIST_AREA == 0 && deleted)
                {
                    sql = string.Format("delete from QC_CHECK_DETAILS where DIST_CODE={0} and QC_CHECK_ID={1} ", DIST_CODE, qcID);
                    rows += db.ExecuteNonQuery(sql);

                }
                else
                {
                    // update QC_CHECK_DETAILS
                    sql = string.Format("update QC_CHECK_DETAILS set SURV_AREA_SUM={0}, QC_AREA_SUM={1}, DIFFERENCE={2}, SURV_DIST_WEIGHT={3}, DIST_WEIGHT={4}, SURV_DIST_POINTS={5}, " +
                     " DIST_MAX_POINTS={6} where DIST_CODE={7} and QC_CHECK_ID={8} ",
                     surveyorSumArea.ToString("0.00"), qcSumArea.ToString("0.00"), qty_difference.ToString("0.00"), surveyorWeightSeverSum.ToString("0.00"),
                     distWeight.ToString("0.00"), surveyorPoints.ToString("0.00"), surveyorMaxPoints.ToString("0.00"), DIST_CODE, qcID);

                    rows += db.ExecuteNonQuery(sql);
                }
            }
            else
            {
                // insert QC_CHECK_DETAILS
                //                                                              0           1               2           3              4        5                   6           7               8
                sql = string.Format("insert into QC_CHECK_DETAILS(RECORD_ID, QC_CHECK_ID, DIST_CODE, SURV_AREA_SUM, QC_AREA_SUM, DIFFERENCE, SURV_DIST_WEIGHT, DIST_WEIGHT, SURV_DIST_POINTS, DIST_MAX_POINTS) " +
                  " values(SEQ_QC_CHECK_DETAILS.nextval, {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}) ",
                  qcID, DIST_CODE, SURV_DIST_AREA.ToString("0.00"), QC_DIST_AREA.ToString("0.00"), qty_difference.ToString("0.00"), surveyorWeightSeverSum.ToString("0.00"),
                  distWeight.ToString("0.00"), surveyorPoints.ToString("0.00"), surveyorMaxPoints.ToString("0.00"));

                rows += db.ExecuteNonQuery(sql);
            }
            //}


            // update surveyor rating in QC_CHECK
            sql = string.Format("select nvl(sum(SURV_DIST_POINTS), 0) as SURV_DIST_POINTS_sum, nvl(sum(DIST_MAX_POINTS), 0) as DIST_MAX_POINTS from QC_CHECK_DETAILS where QC_CHECK_ID={0} ", qcID);
            dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                double grade = 0;
                double pointSum = double.Parse(dr["SURV_DIST_POINTS_sum"].ToString());
                double maxPointsSum = double.Parse(dr["DIST_MAX_POINTS"].ToString());
                grade = (pointSum == 0 || maxPointsSum == 0) ? 0 : (((pointSum / maxPointsSum) * 100) + 10);

                sql = string.Format("update QC_CHECK set SURV_SUM_POINTS={1}, SURV_SUM_MAX_POINTS={2}, SURV_RATE={3} where QC_CHECK_ID={0} ",
                    qcID, pointSum.ToString("0.00"), maxPointsSum.ToString("0.00"), grade.ToString("0.00"));

                rows += db.ExecuteNonQuery(sql);
            }

            return (rows > 0);
        }


        public bool DeleteQCheckDistress(int RECORD_ID)
        {
            if (RECORD_ID == 0)
                return false;

            int rows = 0;
            string sql = string.Format("select QC_CHECK_ID, DIST_CODE, DIST_SEVERITY from QC_DISTRESS where RECORD_ID={0} ", RECORD_ID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                char DIST_SEVERITY = dr["DIST_SEVERITY"].ToString()[0];
                int DIST_CODE = int.Parse(dr["DIST_CODE"].ToString());
                int QC_CHECK_ID = int.Parse(dr["QC_CHECK_ID"].ToString());

                double difference = CalculateAreaDifference(0, 0);
                double qcDistWeight = SeverityWeight(DIST_SEVERITY);
                double surveyorDistWeight = Convert.ToDouble(difference) * qcDistWeight;


                sql = string.Format("delete from QC_DISTRESS where RECORD_ID={0}", RECORD_ID);
                rows += db.ExecuteNonQuery(sql);

                bool processed = ProcessQcTotalsRating(QC_CHECK_ID, DIST_CODE, 0, 0, true);
                return (rows > 0) & processed;
            }
            else
                return false;
        }

        public bool UpdateQCheckDistress(int RECORD_ID, double SURV_DIST_AREA, double QC_DIST_AREA)
        {
            if (RECORD_ID == 0)
                return false;
            else if (SURV_DIST_AREA == 0 && QC_DIST_AREA == 0)
                throw new Exception("الرجاء إدخال قيمتي مساحة المساح ومساحة المراقب بصورة صحيحة");

            int rows = 0;
            string sql = string.Format("select QC_CHECK_ID, DIST_CODE, DIST_SEVERITY from QC_DISTRESS where RECORD_ID={0} ", RECORD_ID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                char DIST_SEVERITY = dr["DIST_SEVERITY"].ToString()[0];
                int DIST_CODE = int.Parse(dr["DIST_CODE"].ToString());
                int QC_CHECK_ID = int.Parse(dr["QC_CHECK_ID"].ToString());

                double difference = CalculateAreaDifference(SURV_DIST_AREA, QC_DIST_AREA);
                double qcDistWeight = SeverityWeight(DIST_SEVERITY);
                double surveyorDistWeight = Convert.ToDouble(difference) * qcDistWeight;


                sql = string.Format("update QC_DISTRESS set SURV_DIST_AREA={1}, QC_DIST_AREA={2}, DIFFERENCE={3}, SURV_WEIGHT_SEV={4}, CHECKER_WEIGHT_SEV={5} where RECORD_ID={0}",
                   RECORD_ID, SURV_DIST_AREA.ToString("0.00"), QC_DIST_AREA.ToString("0.00"), difference.ToString("0.00"), surveyorDistWeight.ToString("0.00"),
                   qcDistWeight.ToString("0.00"));

                rows += db.ExecuteNonQuery(sql);

                bool processed = ProcessQcTotalsRating(QC_CHECK_ID, DIST_CODE, SURV_DIST_AREA, QC_DIST_AREA, false);
                return (rows > 0) & processed;
            }
            else
                return false;
        }

        #endregion


        #region Calculations

        private double CalculateAreaDifference(double surveyorArea, double qcArea)
        {
            double difference = 0;
            if (qcArea > surveyorArea)
            {
                if (qcArea != 0)
                    difference = Math.Abs(1 - (Math.Abs((qcArea - surveyorArea)) / qcArea));
                else
                    difference = (surveyorArea == 0) ? 1 : 0;
            }
            else
            {
                if (surveyorArea > 2 * qcArea)
                    return 0;
                else
                {
                    if (surveyorArea == 0)
                        difference = 1;
                    else
                        difference = Math.Abs(1 - (Math.Abs((qcArea - surveyorArea)) / qcArea));
                }
            }

            return difference;
        }

        //private double CalculateSurveyorDistWeightSum(double surveyorSumArea, double qcSumArea, double sumWeightsSeverity, double sumWeightQty)
        //{
        //    if (surveyorSumArea == 0)
        //        return ((qcSumArea == 0) ? 0 : 0);
        //    else
        //        return (sumWeightsSeverity + sumWeightQty);
        //}

        private double CalculateSurveyorMaxPoints(double surveyorWeightSum, double surveyorAreaSum, double qcAreaSum, double distWeight)
        {
            if (surveyorWeightSum != 0)
                return (distWeight * 10.0);
            else
            {
                if (surveyorAreaSum != 0)
                    return (distWeight * 10.0);
                else
                    return ((qcAreaSum != 0) ? (distWeight * 10.0) : 0);
            }
        }

        public double SeverityWeight(char s)
        {
            switch (s)
            {
                case 'L':
                    return 0.5;
                case 'M':
                    return 1.0;
                case 'H':
                    return (double)1.5;
                default:
                    return 7.0;
            }
        }

        public double DistressWeight(int distCode)
        {
            switch (distCode)
            {
                case 1:
                case 2:
                case 3:
                case 16:
                    return 5.0;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 12:
                case 13:
                case 14:
                case 15:
                    return 2.0;
                case 9:
                case 10:
                case 11:
                    return 0.5;
                default:
                    return 0;
            }
        }

        #endregion

        #region Search

        public DataTable GetAllQChecks()
        {
            string sql = "select * from VW_QCHECK_REGIONS order by ENTRY_DATE desc, QC_DATE desc ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllRegionsQChecks(int regionID, int surveyorID)
        {
            string regionPart = (regionID == 0) ? "" : string.Format(" and REGION_ID={0} ", regionID);
            string surveyorPart = (surveyorID == 0) ? "" : string.Format(" and SURVEYOR_ID={0} ", surveyorID);

            string sql = string.Format("select * from VW_QCHECK_REGIONS where REGION_ID is not null {0} {1} and CORRECTED<>1 order by ENTRY_DATE desc, QC_DATE desc ", regionPart, surveyorPart);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllRegionsQChecksOLD(int regionID, int surveyorID)
        {
            string regionPart = (regionID == 0) ? "" : string.Format(" and REGION_ID={0} ", regionID);
            string surveyorPart = (surveyorID == 0) ? "" : string.Format(" and SURVEYOR_ID={0} ", surveyorID);

            string sql = string.Format("select * from VW_QCHECK_REGIONS_OLD where REGION_ID is not null {0} {1} and CORRECTED<>1 order by ENTRY_DATE desc, QC_DATE desc ", regionPart, surveyorPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllSectionsQChecks(int sectionID, int surveyorID, int mainStID)
        {
            string mainStPart = (mainStID == 0) ? "" : string.Format(" and STREET_ID={0} ", mainStID); // MAIN_ST_ID
            string sectionPart = (sectionID == 0) ? "" : string.Format(" and SECTION_ID={0} ", sectionID);
            string surveyorPart = (surveyorID == 0) ? "" : string.Format(" and SURVEYOR_ID={0} ", surveyorID);

            string sql = string.Format("select * from VW_QCHECK_Sections where SECTION_ID is not null {0} {1} {2} and CORRECTED<>1 order by ENTRY_DATE desc, QC_DATE desc ", mainStPart, sectionPart, surveyorPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllIntersectionsQChecks(int intersectID, int surveyorID, int mainStID)
        {
            string mainStPart = (mainStID == 0) ? "" : string.Format(" and STREET_ID={0} ", mainStID); // MAIN_ST_ID
            string intersectPart = (intersectID == 0) ? "" : string.Format(" and INTERSECT_ID={0} ", intersectID);
            string surveyorPart = (surveyorID == 0) ? "" : string.Format(" and SURVEYOR_ID={0} ", surveyorID);

            string sql = string.Format("select * from VW_QCHECK_Intersect where INTERSECT_ID is not null {0} {1} {2} and CORRECTED<>1 order by ENTRY_DATE desc, QC_DATE desc ", mainStPart, intersectPart, surveyorPart);
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(bool sections, bool intersect, bool regions, bool detailed, int surveyorID, int qCheckerID, DateTime? from, DateTime? to, bool successIgnore,
            bool passed)
        {
            bool firstArgs = true;
            string sql = "";
            if (sections)
                sql = detailed ? "select * from VW_QCHECK_SECTIONS_FULL " : "select * from VW_QCHECK_SECTIONS ";
            else if (intersect)
                sql = detailed ? "select * from VW_QCHECK_INTERSECT_FULL " : "select * from VW_QCHECK_INTERSECT ";
            else if (regions)
                sql = detailed ? "select * from VW_QCHECK_REGIONS_FULL " : "select * from VW_QCHECK_REGIONS ";
            else
                return new DataTable();

            if (!string.IsNullOrEmpty(sql))
            {
                if (surveyorID != 0)
                {
                    if (firstArgs)
                    {
                        sql = string.Format("{0} where SURVEYOR_ID={1} ", sql, surveyorID);
                        firstArgs = false;
                    }
                    else
                        sql = string.Format("{0} and SURVEYOR_ID={1} ", sql, surveyorID);
                }

                if (qCheckerID != 0)
                {
                    if (firstArgs)
                    {
                        sql = string.Format("{0} where QC_CHECKER_ID={1} ", sql, qCheckerID);
                        firstArgs = false;
                    }
                    else
                        sql = string.Format("{0} and QC_CHECKER_ID={1} ", sql, qCheckerID);
                }

                if (from != null)
                {
                    if (firstArgs)
                    {
                        sql = string.Format("{0} where QC_DATE>='{1}' ", sql, ((DateTime)from).ToString("dd/MM/yyyy"));
                        firstArgs = false;
                    }
                    else
                        sql = string.Format("{0} and QC_DATE>='{1}' ", sql, ((DateTime)from).ToString("dd/MM/yyyy"));
                }

                if (to != null)
                {
                    if (firstArgs)
                    {
                        sql = string.Format("{0} where QC_DATE<='{1}' ", sql, ((DateTime)to).ToString("dd/MM/yyyy"));
                        firstArgs = false;
                    }
                    else
                        sql = string.Format("{0} and QC_DATE<='{1}' ", sql, ((DateTime)to).ToString("dd/MM/yyyy"));
                }

                if (!successIgnore)
                {
                    string passedCleanPart = passed ? " or (surv_rate = 0 AND surv_sum_max_points = 0) " : " and (surv_rate = 0 OR surv_sum_max_points <> 0) ";
                    string passedSign = passed ? ">=" : "<";
                    string inCaseNotPassed = passed ? "" : "and surv_sum_max_points <> 0";

                    if (firstArgs)
                    {

                        sql = string.Format("{0} where ((SURV_RATE{1}80 {3}) {2}) and CORRECTED<>1 ", sql, passedSign, passedCleanPart, inCaseNotPassed);
                        firstArgs = false;
                    }
                    else
                        sql = string.Format("{0} and ((SURV_RATE{1}80 {3}) {2}) and CORRECTED<>1 ", sql, passedSign, passedCleanPart, inCaseNotPassed);
                }

                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }

        #endregion


        public DataTable GetSurveyorRatingForQC(int qcID)
        {
            if (qcID == 0)
                return new DataTable();


            string sql = string.Format("select QC_CHECK_ID, SURV_RATE, SURV_SUM_POINTS, SURV_SUM_MAX_POINTS, SURV_RATING from VW_QCHECK_REGIONS where QC_CHECK_ID={0} union " +
                " select QC_CHECK_ID, SURV_RATE, SURV_SUM_POINTS, SURV_SUM_MAX_POINTS, SURV_RATING from VW_QCHECK_INTERSECT where QC_CHECK_ID={0} union " +
                " select QC_CHECK_ID, SURV_RATE, SURV_SUM_POINTS, SURV_SUM_MAX_POINTS, SURV_RATING from VW_QCHECK_SECTIONS where QC_CHECK_ID={0} ", qcID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRoadNetworkHavingQCheck(RoadType type)
        {
            string sql = "";
            switch (type)
            {
                case RoadType.Section:
                    sql = "select distinct main_no, arname as main_name from sections where section_no in (select section_no from distress where section_no is not null) and section_id in(select section_ID from qc_check where section_ID is not null) order by main_no ";
                    break;
                case RoadType.Intersect:
                    sql = "select distinct main_no, arname as main_name from intersections where inter_no in (select inter_no from distress where inter_no is not null) and intersection_id in(select INTERSECT_ID from qc_check where INTERSECT_ID is not null) order by arname ";
                    break;
                case RoadType.RegionSecondarySt:
                    sql = "select region_no, subdistrict, REGION_AREA from VW_REGIONS_AREA where region_no in (select region_no from distress where region_no is not null) and region_id in(select region_id from qc_check where region_id is not null) order by region_no ";
                    break;
                default:
                    return new DataTable();
            }

            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }


        #region Failed QC - Remove Distresses

        public bool RemoveFailedQcSectionDistress(int qcID)
        {
            if (qcID == 0)
                return false;
            else
                return true;

            //string sql = string.Format("delete from distress where sample_id in " + 
            //    " (select sample_id from lane_samples where lane_id=(select lane_id from VW_QCHECK_SECTIONS where QC_CHECK_ID={0}))", qcID);
            //int rows = db.ExecuteNonQuery(sql);

            //return (rows > 0);
        }

        public bool RemoveFailedQcIntersectDistress(int qcID)
        {
            if (qcID == 0)
                return false;
            else
                return true;

            //string sql = string.Format("delete from distress where INTER_SAMP_ID in " + 
            //    "(select INTER_SAMP_ID from INTERSECTION_SAMPLES where INTERSECTION_ID=(select INTERSECT_ID from VW_QCHECK_INTERSECT where QC_CHECK_ID={0})) ", qcID);
            //int rows = db.ExecuteNonQuery(sql);

            //return (rows > 0);
        }

        public bool RemoveFailedQcRegionDistress(int qcID)
        {
            if (qcID == 0)
                return false;
            else
                return true;

            //string sql = string.Format("select * from distress where second_id in "+
            //    " (select second_id from secondary_streets where REGION_ID=(select REGION_ID from VW_QCHECK_REGIONS where QC_CHECK_ID={0})) ", qcID);
            //int rows = db.ExecuteNonQuery(sql);

            //return (rows > 0);
        }

        #endregion


    }
}
