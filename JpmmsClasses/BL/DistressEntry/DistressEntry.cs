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

namespace JpmmsClasses.BL.DistressEntry
{
    public class DistressEntry
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private Dates hijri = new Dates();
        private Region region = new Region();




        #region DistressInsert

        public bool InsertSectionDistress(int sampleID, string surveyDate, int surveyNo, string distressNameCode, char severity, double? distArea,
            double? SampleArea, string sectioNo, string notes, string user, int sectionID, int userID, int streetID)
        {
            //OracleDatabaseClass db = new OracleDatabaseClass();
            //string lang = HttpContext.Current.Session["lang"].ToString();

            // string imageFileName,
            string sql = "";
            string[] distress = distressNameCode.Split('-');
            if (distress.Length == 0)
                throw new Exception(Feedback.NoDistressSelected());
            else if (surveyNo == 0 || string.IsNullOrEmpty(surveyDate))
                throw new Exception(Feedback.NoSurveyDateNum());
            else if (sampleID == 0)
                throw new Exception(Feedback.NoSectionSampleSelected());
            else if (distressNameCode.Length > 0 && severity == 'N')
                throw new Exception(Feedback.NoDistressSeveritySelected());


            int distressCode = int.Parse(distress[0].Trim());
            string distressName = distress[1].Trim();

            string searchExistSql = string.Format("SELECT Count(*) AS x FROM DISTRESS WHERE SAMPLE_ID={0} AND SURVEY_DATE=TO_DATE('{1}','DD/MM/YYYY') AND DIST_CODE={2} AND SURVEY_NO={3} AND  DIST_SEVERITY='{4}' ",
                sampleID, Shared.FormatDateArEgDMY(surveyDate), distressCode, surveyNo, severity);

            int count = int.Parse(db.ExecuteScalar(searchExistSql).ToString());
            if (count != 0)
                throw new Exception(Feedback.InsertExceptionUnique());
            else
            {
                double sampleArea = (SampleArea == null) ? 0 : (double)SampleArea;
                double area = (distArea == null) ? 0 : (double)distArea;

                //if (distressCode >= 1 && distressCode <= 11)
                //{
                if (area > sampleArea)
                    throw new Exception(Feedback.DistressAreaLargerThanSampleArea());
                //}
                //else if (distressCode >= 13 && distressCode <= 15)
                //{
                //    double patchArea = DistressShared.GetSamplePatchesArea(sampleID, JobType.Section);
                //    if (area > patchArea)
                //        throw new Exception(Feedback.PatchDistressAreaLargerThanPatchArea(lang));
                //}

                //double enteredAreas = DistressShared.GetSampleNonPatchDistressArea(sampleID, JobType.Section);
                //enteredAreas += area;
                //if (enteredAreas > sampleArea)
                //    throw new Exception("مجموع مساحات العيوب المدخلة يتجاوز مساحة العينة");


                double distressDensity = (area / sampleArea) * 100.0;
                distressDensity = (distressDensity > 100) ? 100 : distressDensity;
                notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));

                double deductValue = DistressShared.CalculateDeductValue(distressCode, severity);
                double densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("0.00")));
                double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);
                string hijriDate = hijri.GregToHijri(Convert.ToDateTime(surveyDate).AddDays(1).ToShortDateString(), "dd/MM/yyyy");

                // distress_ar_type, distressName, '{5}', '{5}',
                //                                          0               1       2           3           4           5               6           7                                                   8                 9                    10              11          12          10            11             12              13          14         15
                sql = string.Format("INSERT INTO DISTRESS(SAMPLE_ID, SECTION_NO, SURVEY_NO, SURVEY_DATE, DIST_CODE, Dist_AREA, DIST_DENSITY, DIST_SEVERITY, STATUS, STATUS_UPD, ENTRY_DATE, DIST_ID, DEDUCT_VALUE_UPD, DEN_DASH_UPD, DEDUCT_DEN_DASH_UPD, DEDUCT_VALUE, DEN_DASH, DEDUCT_DEN_DASH, SURVEY_DATE_H, DISTRESS_NOTES, SECTION_ID, DONE_BY, STREET_ID) " +
                    "values({0}, '{1}', {2}, To_date('{3}','DD/MM/YYYY'), {4},  {5}, {6}, '{7}', " +
                    " 'N', 'N', (select sysdate from dual), SEQ_DISTRESS.nextval, {8}, {9}, {10}, {8}, {9}, {10}, To_date('{11}','DD/MM/YYYY'), {12}, {13}, {14}, {15}) ",
                    sampleID, sectioNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate), distressCode, area.ToString("0.00"), distressDensity.ToString("0.00"), severity,
                    deductValue.ToString("0.00"), densityDashValue.ToString("0.00"), deductDashValue.ToString("0.00"), hijriDate, notes, sectionID, userID, streetID);

                // DISTRESS_IMAGE, imageFileName,
                int rows = db.ExecuteNonQuery(sql);
                if (rows > 0 && distressCode != 0)
                {
                    sql = string.Format("delete from DISTRESS where SAMPLE_ID={0} and SURVEY_NO={1} and DIST_CODE=0 ", sampleID, surveyNo);
                    db.ExecuteNonQuery(sql);
                }


                Shared.SaveLogfile("DISTRESS", (sectioNo + " " + sampleID.ToString()), "Distress Entry on Section", user);
                return (rows > 0);
            }
        }



        public bool InsertIntersectionDistress(int intersectSampleID, string surveyDate, int surveyNo, string distressNameCode, char severity, double? distArea,
          double? SampleArea, string intersectNo, string notes, string user, int intersectID, int userID, int streetID)
        {
            // string imageFileName, 
            //OracleDatabaseClass db = new OracleDatabaseClass();
            string lang = HttpContext.Current.Session["lang"].ToString();

            string sql = "";
            string[] distress = distressNameCode.Split('-');
            int distressCode = int.Parse(distress[0].Trim());
            string distressName = distress[1].Trim();

            if (distress.Length == 0)
                throw new Exception(Feedback.NoDistressSelected());
            else if (surveyNo == 0 || string.IsNullOrEmpty(surveyDate))
                throw new Exception(Feedback.NoSurveyDateNum());
            else if (intersectSampleID == 0)
                throw new Exception(Feedback.NoIntersectSampleSelected());
            else if (distressCode > 0 && severity == 'N')
                throw new Exception(Feedback.NoDistressSeveritySelected());


            string searchExistSql = string.Format("SELECT Count(*) AS x FROM DISTRESS WHERE INTER_SAMP_ID={0} AND SURVEY_DATE =TO_DATE('{1}','DD/MM/YYYY') AND DIST_CODE={2} AND SURVEY_NO={3} AND  DIST_SEVERITY='{4}' ",
                intersectSampleID, Shared.FormatDateArEgDMY(surveyDate), distressCode, surveyNo, severity);

            int count = int.Parse(db.ExecuteScalar(searchExistSql).ToString());
            if (count != 0)
                throw new Exception(Feedback.InsertExceptionUnique());
            else
            {
                double sampleArea = (SampleArea == null) ? 0 : (double)SampleArea;
                double area = (distArea == null) ? 0 : (double)distArea;

                //if (distressCode >= 1 && distressCode <= 11)
                //{
                if (area > SampleArea)
                    throw new Exception(Feedback.DistressAreaLargerThanSampleArea());
                //}
                //else if (distressCode >= 13 && distressCode <= 15)
                //{
                //    double patchArea = DistressShared.GetSamplePatchesArea(intersectSampleID, JobType.Intersection);
                //    if (area > patchArea)
                //        throw new Exception(Feedback.PatchDistressAreaLargerThanPatchArea(lang));
                //}

                //double enteredAreas = DistressShared.GetSampleNonPatchDistressArea(intersectSampleID, JobType.Intersection);
                //enteredAreas += area;
                //if (enteredAreas > SampleArea)
                //    throw new Exception("مجموع مساحات العيوب المدخلة يتجاوز مساحة العينة");


                double distressDensity = (area / sampleArea) * 100.0;
                distressDensity = (distressDensity > 100) ? 100 : distressDensity;
                notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));

                double deductValue = DistressShared.CalculateDeductValue(distressCode, severity);
                double densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("0.00")));
                double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);
                string hijriDate = hijri.GregToHijri(Convert.ToDateTime(surveyDate).AddDays(1).ToShortDateString(), "dd/MM/yyyy");

                // distress_ar_type, distressName, 
                //                                          0               1       2           3           4           5               6           7                                                       8                 9               10              11              12              10              11          12              13            14         15
                sql = string.Format("INSERT INTO DISTRESS(INTER_SAMP_ID, INTER_NO, SURVEY_NO, SURVEY_DATE, DIST_CODE, Dist_AREA, DIST_DENSITY, DIST_SEVERITY, STATUS, STATUS_UPD, ENTRY_DATE, DIST_ID, DEDUCT_VALUE_UPD, DEN_DASH_UPD, DEDUCT_DEN_DASH_UPD, DEDUCT_VALUE, DEN_DASH, DEDUCT_DEN_DASH, SURVEY_DATE_H, DISTRESS_NOTES, INTERSECTION_ID, DONE_BY, STREET_ID) " +
                    "values({0}, '{1}', {2}, To_date('{3}','DD/MM/YYYY'), {4}, {5}, {6}, " +
                    " '{7}', 'N', 'N', (select sysdate from dual), SEQ_DISTRESS.nextval, {8}, {9}, {10}, {8}, {9}, {10}, To_date('{11}','DD/MM/YYYY'), {12}, {13}, " +
                    " {14}, {15}) ",
                    intersectSampleID, intersectNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate), distressCode, area.ToString("0.00"), distressDensity.ToString("0.00"),
                    severity, deductValue.ToString("0.00"), densityDashValue.ToString("0.00"), deductDashValue.ToString("0.00"), hijriDate, notes, intersectID,
                    userID, streetID);

                // DISTRESS_IMAGE, imageFileName, 
                int rows = db.ExecuteNonQuery(sql);
                if (rows > 0 && distressCode != 0)
                {
                    sql = string.Format("delete from DISTRESS where INTER_SAMP_ID={0} and SURVEY_NO={1} and DIST_CODE=0 ", intersectSampleID, surveyNo);
                    db.ExecuteNonQuery(sql);
                }

                Shared.SaveLogfile("DISTRESS", (intersectNo + " " + intersectSampleID.ToString()), "Distress Entry on Intersection", user);
                return (rows > 0);
            }
        }



        public bool InsertRegionSecondaryStreetDistress(int streetID, string surveyDate, int surveyNo, string distressNameCode, char severity, double? distArea,
          double? SampleArea, string regionNo, string notes, string user, int regionID, int userID)
        {
            //OracleDatabaseClass db = new OracleDatabaseClass();
            string lang = HttpContext.Current.Session["lang"].ToString();

            string sql = "";
            string[] distress = distressNameCode.Split('-');
            int distressCode = int.Parse(distress[0].Trim());
            string distressName = distress[1].Trim();

            if (distress.Length == 0)
                throw new Exception(Feedback.NoDistressSelected());
            else if (surveyNo == 0 || string.IsNullOrEmpty(surveyDate))
                throw new Exception(Feedback.NoSurveyDateNum());
            else if (streetID == 0)
                throw new Exception(Feedback.NoRegionSecStreetSampleSelected());
            else if (distressCode > 0 && severity == 'N')
                throw new Exception(Feedback.NoDistressSeveritySelected());


            string searchExistSql = string.Format("SELECT Count(*) AS X FROM DISTRESS WHERE REGION_NO='{0}' AND STREET_ID={1}  AND SURVEY_NO={2} AND SURVEY_DATE=TO_DATE('{3}','DD/MM/YYYY') AND DIST_CODE={4} AND  DIST_SEVERITY='{5}' ",
                regionNo, streetID, surveyNo, Shared.FormatDateArEgDMY(surveyDate), distressCode, severity);

            int count = int.Parse(db.ExecuteScalar(searchExistSql).ToString());
            if (count != 0)
                throw new Exception(Feedback.InsertExceptionUnique());
            else
            {
                double sampleArea = (SampleArea == null) ? 0 : (double)SampleArea;
                double area = (distArea == null) ? 0 : (double)distArea;

                //if (distressCode >= 1 && distressCode <= 11)
                //{
                if (area > sampleArea)
                    throw new Exception(Feedback.DistressAreaLargerThanSampleArea());
                //}
                //else if (distressCode >= 13 && distressCode <= 15)
                //{
                //    double patchArea = DistressShared.GetSamplePatchesArea(secondarystID, JobType.RegionSecondaryStreets);
                //    if (area > patchArea)
                //        throw new Exception(Feedback.PatchDistressAreaLargerThanPatchArea(lang));
                //}

                //double enteredAreas = DistressShared.GetSampleNonPatchDistressArea(secondarystID, JobType.RegionSecondaryStreets);
                //enteredAreas += area;
                //if (enteredAreas > sampleArea)
                //    throw new Exception("مجموع مساحات العيوب المدخلة يتجاوز مساحة العينة");


                double distressDensity = (area / sampleArea) * 100.0;
                distressDensity = (distressDensity > 100) ? 100 : distressDensity;
                notes = string.IsNullOrEmpty(notes) ? "NULL" : string.Format("'{0}'", notes.Replace("'", "''"));

                double deductValue = DistressShared.CalculateDeductValue(distressCode, severity);
                double densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("0.00")));
                double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);
                string hijriDate = hijri.GregToHijri(Convert.ToDateTime(surveyDate).AddDays(1).ToShortDateString(), "dd/MM/yyyy");

                // distress_ar_type, distressName, '{5}', SECOND_ID
                //                                            0         1           2           3           4          5               6           7                                                         8               9                  10              11        9              10              11              12            13     14  
                sql = string.Format("INSERT INTO DISTRESS(STREET_ID, REGION_NO, SURVEY_NO, SURVEY_DATE, DIST_CODE, DIST_AREA, DIST_DENSITY, DIST_SEVERITY, ENTRY_DATE, STATUS, STATUS_UPD, DIST_ID, DEDUCT_VALUE_UPD, DEN_DASH_UPD, DEDUCT_DEN_DASH_UPD, DEDUCT_VALUE, DEN_DASH, DEDUCT_DEN_DASH, SURVEY_DATE_H, DISTRESS_NOTES, REGION_ID, DONE_BY) " +
                    " VALUES ({0}, '{1}', {2}, To_date('{3}','DD/MM/YYYY'), {4}, {5}, {6}, '{7}', " +
                    " (select sysdate from dual), 'N','N', SEQ_DISTRESS.nextval, {8}, {9}, {10}, {8}, {9}, {10}, To_date('{11}','DD/MM/YYYY'), {12}, {13}, {14}) ",
                    streetID, regionNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate), distressCode, area.ToString("0.00"), distressDensity.ToString("0.00"), severity,
                    deductValue.ToString("0.00"), densityDashValue.ToString("0.00"), deductDashValue.ToString("0.00"), hijriDate, notes, regionID, userID);

                // string imageFileName, imageFileName, DISTRESS_IMAGE, 
                int rows = db.ExecuteNonQuery(sql);
                if (rows > 0 && distressCode != 0)
                {
                    sql = string.Format("delete from DISTRESS where STREET_ID={0} and SURVEY_NO={1} and DIST_CODE=0 ", streetID, surveyNo); // SECOND_ID 
                    db.ExecuteNonQuery(sql);
                }


                sql = string.Format("select * from REGION_SURVEYS where region_no='{0}' and SURVEY_NO={1} ", regionNo, surveyNo);
                DataTable dt = db.ExecuteQuery(sql);
                if (dt.Rows.Count == 0)
                {
                    sql = string.Format("insert into REGION_SURVEYS(region_no, SURVEY_NO, SURVEY_DATE) values('{0}', {1}, To_date('{2}','DD/MM/YYYY')) ",
                        regionNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate));

                    rows += db.ExecuteNonQuery(sql);
                }

                Shared.SaveLogfile("DISTRESS", (regionNo + " " + streetID.ToString()), "Distress Entry on Secondary St.", user);
                return (rows > 0);
            }
        }

        #endregion

        #region InsertionNewSurveyDistressAsClean

        public bool InsertNewSectionSampleSurvey(int sampleID, int sectionID, int surveyNo, string surveyDate, string user, int userID, int streetID)
        {
            int rows = 0;
            string sql = string.Format("select section_no from sections where section_id={0} ", sectionID);
            string sectionNo = db.ExecuteScalar(sql).ToString();

            if (!string.IsNullOrEmpty(sectionNo))
            {
                sql = string.Format("select * from SURVEYORS_SUBMIT_JOB where section_no='{0}' and SURVEY_NO={1} ", sectionNo, surveyNo);
                DataTable dtexist = db.ExecuteQuery(sql);
                if (dtexist.Rows.Count == 0)
                    throw new Exception("الرجاء ربط هذا المسح مع المساح الذي قام بتنفيذه ضمن البيانات الوصفية ليتسنى حفظ هذا المسح");

                double deductValue = DistressShared.CalculateDeductValue(0, 'N');
                double densityDashValue = DistressShared.CalculateDensityDashValue('N', 0);
                double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);
                string hijriDate = hijri.GregToHijri(Convert.ToDateTime(surveyDate).AddDays(1).ToShortDateString(), "dd/MM/yyyy");

                // , DISTRESS_AR_TYPE , 'نظيف'
                //                                                      0          1        2           3                                                                                                   4               5               6                   4               5           6             7         8          9            10
                sql = string.Format("INSERT INTO DISTRESS(DIST_ID, SAMPLE_ID, SECTION_NO, SURVEY_NO, SURVEY_DATE, STATUS, STATUS_UPD, ENTRY_DATE, DIST_CODE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY, DEDUCT_VALUE_UPD, DEN_DASH_UPD, DEDUCT_DEN_DASH_UPD, DEDUCT_VALUE, DEN_DASH, DEDUCT_DEN_DASH, SURVEY_DATE_H, DONE_BY, SECTION_ID, STREET_ID) " +
                    " VALUES (SEQ_DISTRESS.nextval, {0}, '{1}', {2}, To_date('{3}','DD/MM/YYYY'), 'N', 'N', (select sysdate from dual), 0, 'N', 0, 0, {4}, {5}, {6}, {4}, {5}, {6}, " +
                    " To_date('{7}','DD/MM/YYYY'), {8}, {9}, {10}) ",
                    sampleID, sectionNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate), deductValue.ToString("N2"), densityDashValue.ToString("N2"), deductDashValue.ToString("N2"),
                    hijriDate, userID, sectionID, streetID);

                rows += db.ExecuteNonQuery(sql);

                sql = string.Format("update SECTION_DETAILS set SURVEY_DATE=To_date('{0}','DD/MM/YYYY') where SECTION_ID={1} ", surveyDate, sectionID);
                rows += db.ExecuteNonQuery(sql);


                Shared.SaveLogfile("DISTRESS", (sectionNo + " " + sampleID.ToString()), "New Survey Distress on Section", user);
                return (rows > 0);
            }
            else
                return false;
        }

        public bool InsertNewIntersectionSampleSurvey(int intersectSampleID, int intersectID, int surveyNo, string surveyDate, string user, int userID, int streetID)
        {
            int rows = 0;
            string sql = string.Format("select inter_no from intersections where INTERSECTION_ID={0} ", intersectID);
            string intersectNo = db.ExecuteScalar(sql).ToString();

            if (!string.IsNullOrEmpty(intersectNo))
            {
                sql = string.Format("select * from SURVEYORS_SUBMIT_JOB where inter_no='{0}' and SURVEY_NO={1} ", intersectNo, surveyNo);
                DataTable dtexist = db.ExecuteQuery(sql);
                if (dtexist.Rows.Count == 0)
                    throw new Exception("الرجاء ربط هذا المسح مع المساح الذي قام بتنفيذه ضمن البيانات الوصفية ليتسنى حفظ هذا المسح");


                double deductValue = DistressShared.CalculateDeductValue(0, 'N');
                double densityDashValue = DistressShared.CalculateDensityDashValue('N', 0);
                double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);
                string hijriDate = hijri.GregToHijri(Convert.ToDateTime(surveyDate).AddDays(1).ToShortDateString(), "dd/MM/yyyy");

                // , DISTRESS_AR_TYPE , 'نظيف'
                //                                                      0          1        2           3                                                                                                   4               5               6                    4              5           6                 7        8            9           10
                sql = string.Format("INSERT INTO DISTRESS(DIST_ID, INTER_SAMP_ID, INTER_NO, SURVEY_NO, SURVEY_DATE, STATUS, STATUS_UPD, ENTRY_DATE, DIST_CODE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY, DEDUCT_VALUE_UPD, DEN_DASH_UPD, DEDUCT_DEN_DASH_UPD, DEDUCT_VALUE, DEN_DASH, DEDUCT_DEN_DASH, SURVEY_DATE_H, DONE_BY, INTERSECTION_ID, STREET_ID) " +
                    " VALUES (SEQ_DISTRESS.nextval, {0}, '{1}', {2}, To_date('{3}','DD/MM/YYYY'), 'N', 'N', (select sysdate from dual), 0, 'N', 0, 0, {4}, {5}, " +
                    " {6}, {4}, {5}, {6}, To_date('{7}','DD/MM/YYYY'), {8}, {9}, {10}) ",
                    intersectSampleID, intersectNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate), deductValue.ToString("N2"), densityDashValue.ToString("N2"),
                    deductDashValue.ToString("N2"), hijriDate, userID, intersectID, streetID);

                rows += db.ExecuteNonQuery(sql);

                sql = string.Format("update INTERSECTION_DETAILS set SURVEY_DATE=To_date('{0}','DD/MM/YYYY') where INTERSECTION_ID={1} ", surveyDate, intersectID);
                rows += db.ExecuteNonQuery(sql);


                Shared.SaveLogfile("DISTRESS", (intersectNo + " " + intersectSampleID.ToString()), "New Survey Distress on Intersection", user);
                return (rows > 0);
            }
            else
                return false;
        }

        public bool InsertNewSecondaryStreetSampleSurvey(int streetID, string regionNo, int surveyNo, string surveyDate, string user, int userID, int regionID)
        {
            int rows = 0;
            string sql = "";
            if (!string.IsNullOrEmpty(regionNo))
            {
                sql = string.Format("select * from SURVEYORS_SUBMIT_JOB where REGION_NO='{0}' and SURVEY_NO={1} ", regionNo, surveyNo);
                DataTable dtexist = db.ExecuteQuery(sql);
                if (dtexist.Rows.Count == 0)
                    throw new Exception("الرجاء ربط هذا المسح مع المساح الذي قام بتنفيذه ضمن البيانات الوصفية ليتسنى حفظ هذا المسح");

                double deductValue = DistressShared.CalculateDeductValue(0, 'N');
                double densityDashValue = DistressShared.CalculateDensityDashValue('N', 0);
                double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);
                string hijriDate = hijri.GregToHijri(Convert.ToDateTime(surveyDate).AddDays(1).ToShortDateString(), "dd/MM/yyyy");

                //                                                      0          1        2           3                                                                                                   4               5               6                    4         5           6             7              8          9    
                sql = string.Format("INSERT INTO DISTRESS(DIST_ID, STREET_ID, REGION_NO, SURVEY_NO, SURVEY_DATE, STATUS, STATUS_UPD, ENTRY_DATE, DIST_CODE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY, DEDUCT_VALUE_UPD, DEN_DASH_UPD, DEDUCT_DEN_DASH_UPD, DEDUCT_VALUE, DEN_DASH, DEDUCT_DEN_DASH, SURVEY_DATE_H, DONE_BY, REGION_ID) " +
                    " VALUES (SEQ_DISTRESS.nextval, {0}, '{1}', {2}, To_date('{3}','DD/MM/YYYY'), 'Y', 'N', (select sysdate from dual), 0, 'N', 0, 0, {4}, {5}, {6}, " +
                    " {4}, {5}, {6}, To_date('{7}','DD/MM/YYYY'), {8}, {9}) ",
                    streetID, regionNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate), deductValue.ToString("N2"), densityDashValue.ToString("N2"), deductDashValue.ToString("N2"),
                    hijriDate, userID, regionID);

                rows += db.ExecuteNonQuery(sql);

                //sql = string.Format("update SECONDARY_STREET_DETAILS set SURVEY_DATE=To_date('{0}','DD/MM/YYYY') where REGION_ID={1} ", surveyDate, regionID);
                sql = string.Format("update SECONDARY_STREET_DETAILS set SURVEY_DATE=To_date('{0}','DD/MM/YYYY') where STREET_ID={1} ", surveyDate, streetID);
                rows += db.ExecuteNonQuery(sql);

                sql = string.Format("select * from REGION_SURVEYS where region_no='{0}' and SURVEY_NO={1} ", regionNo, surveyNo);
                DataTable dt = db.ExecuteQuery(sql);
                if (dt.Rows.Count == 0)
                {
                    sql = string.Format("insert into REGION_SURVEYS(region_no, SURVEY_NO, SURVEY_DATE) values('{0}', {1}, To_date('{2}','DD/MM/YYYY')) ",
                        regionNo, surveyNo, Shared.FormatDateArEgDMY(surveyDate));

                    rows += db.ExecuteNonQuery(sql);
                }


                Shared.SaveLogfile("DISTRESS", (regionNo + " " + streetID.ToString()), "New Survey Distress on SecondaryStreet", user);
                return (rows > 0);
            }
            else
                return false;
        }

        #endregion


        #region DistressUpdate

        public bool UpdateSectionDistress(int sampleID, double? DIST_AREA, int DIST_ID, string user)
        {
            // char DIST_SEVERITY, 
            string lang = HttpContext.Current.Session["lang"].ToString();
            if (sampleID == 0)
                throw new Exception(Feedback.NoSectionSampleSelected());

            string sql = string.Format("SELECT STATUS_UPD, dist_code, DIST_SEVERITY FROM DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
                return false;

            DataRow dr = dt.Rows[0];
            int distressCode = int.Parse(dr["dist_code"].ToString());
            char DIST_SEVERITY = dr["DIST_SEVERITY"].ToString()[0];
            string statusUpd = dr["STATUS_UPD"].ToString(); //db.ExecuteScalar(sql).ToString();

            if (statusUpd.ToUpper() == "Y")
                throw new Exception(Feedback.NonUpdateableDistress());

            if (distressCode > 0 && DIST_AREA == 0)
                throw new Exception("الرجاء إدخال المساحة");

            //string[] distress = distressNameCode.Split('-');
            //if (DIST_CODE.Length == 0)
            //    throw new Exception(Feedback.NoDistressSelected(lang));
            //else 
            //else if (int.Parse(DIST_CODE) != 0 && DIST_SEVERITY == 'N')
            //    throw new Exception(Feedback.NoDistressSeveritySelected(lang));


            sql = string.Format("select nvl(DISTRESS_AR_TYPE, '') from DISTRESS_CODE where DIST_CODE={0} ", distressCode);
            string distressArName = db.ExecuteScalar(sql).ToString();

            sql = string.Format("select (SAMPLE_LENGTH * SAMPLE_WIDTH) from LANE_SAMPLES where SAMPLE_ID={0} ", sampleID);
            double SampleArea = double.Parse(db.ExecuteScalar(sql).ToString());

            //if (DIST_AREA > SampleArea)
            //    throw new Exception(Feedback.DistressAreaLargerThanSampleArea());

            double area = (DIST_AREA == null) ? 0 : (double)DIST_AREA;
            //if (distressCode >= 1 && distressCode <= 11)
            //{
            if (area > SampleArea)
                throw new Exception(Feedback.DistressAreaLargerThanSampleArea());
            //}
            //else if (distressCode >= 13 && distressCode <= 15)
            //{
            //    double patchArea = DistressShared.GetSamplePatchesArea(sampleID, JobType.Section);
            //    if (area > patchArea)
            //        throw new Exception(Feedback.PatchDistressAreaLargerThanPatchArea(lang));
            //}

            //double enteredAreas = DistressShared.GetSampleNonPatchDistressAreaForUpdate(sampleID, JobType.Section, DIST_ID);
            //enteredAreas += area;
            //if (enteredAreas > SampleArea)
            //    throw new Exception("مجموع مساحات العيوب المدخلة يتجاوز مساحة العينة، لذا لم يتم الحفظ");



            double distressDensity = (area / SampleArea) * 100.0;
            distressDensity = (distressDensity > 100) ? 100 : distressDensity;

            double deductValue = DistressShared.CalculateDeductValue(distressCode, DIST_SEVERITY);
            double densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("G2")));
            double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);

            //DIST_CODE={0}, , DISTRESS_AR_TYPE='{8}' , distressArName
            sql = string.Format("UPDATE DISTRESS SET STATUS='N', STATUS_UPD='N', DIST_SEVERITY='{1}', DIST_AREA={2}, DIST_DENSITY={3}, DEDUCT_VALUE={4}, DEN_DASH={5}, DEDUCT_DEN_DASH={6}  WHERE DIST_ID={7} ",
                distressCode, DIST_SEVERITY, area.ToString("0.00"), distressDensity.ToString("0.00"), deductValue.ToString("0.00"), densityDashValue.ToString("0.00"),
                deductDashValue.ToString("0.00"), DIST_ID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("DISTRESS", DIST_ID.ToString(), "Distress Update", user);
            return (rows > 0);
        }

        public bool UpdateIntersectionDistress(int intersectSampleID, double? DIST_AREA, int DIST_ID, string user)
        {
            // string DIST_CODE, char DIST_SEVERITY,
            string lang = HttpContext.Current.Session["lang"].ToString();

            string sql = string.Format("SELECT STATUS_UPD, dist_code, DIST_SEVERITY FROM DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
                return false;

            DataRow dr = dt.Rows[0];
            int distressCode = int.Parse(dr["dist_code"].ToString());
            char severity = dr["DIST_SEVERITY"].ToString()[0];
            string statusUpd = dr["STATUS_UPD"].ToString(); //db.ExecuteScalar(sql).ToString();

            if (statusUpd.ToUpper() == "Y")
                throw new Exception(Feedback.NonUpdateableDistress());

            if (distressCode > 0 && DIST_AREA == 0)
                throw new Exception("الرجاء إدخال المساحة");

            //sql = string.Format("select nvl(DISTRESS_AR_TYPE, '') from DISTRESS_CODE where DIST_CODE={0} ", DIST_CODE);
            //string distressArName = db.ExecuteScalar(sql).ToString();

            //if (distressCode.Length == 0)
            //    throw new Exception(Feedback.NoDistressSelected(lang));
            //else if (int.Parse(distressCode) != 0 && DIST_SEVERITY == 'N')
            //    throw new Exception(Feedback.NoDistressSeveritySelected(lang));


            sql = string.Format("select INTERSEC_SAMP_AREA from INTERSECTION_SAMPLES where INTER_SAMP_ID={0} ", intersectSampleID);
            double SampleArea = double.Parse(db.ExecuteScalar(sql).ToString());

            //if (DIST_AREA > SampleArea)
            //    throw new Exception(Feedback.DistressAreaLargerThanSampleArea());

            double area = (DIST_AREA == null) ? 0 : (double)DIST_AREA;
            //if (distressCode >= 1 && distressCode <= 11)
            //{
            if (area > SampleArea)
                throw new Exception(Feedback.DistressAreaLargerThanSampleArea());
            //}
            //else if (distressCode >= 13 && distressCode <= 15)
            //{
            //    double patchArea = DistressShared.GetSamplePatchesArea(intersectSampleID, JobType.Intersection);
            //    if (area > patchArea)
            //        throw new Exception(Feedback.PatchDistressAreaLargerThanPatchArea(lang));
            //}

            //double enteredAreas = DistressShared.GetSampleNonPatchDistressAreaForUpdate(intersectSampleID, JobType.Intersection, DIST_ID);
            //enteredAreas += area;
            //if (enteredAreas > SampleArea)
            //    throw new Exception("مجموع مساحات العيوب المدخلة يتجاوز مساحة العينة، لذا لم يتم الحفظ");



            double distressDensity = (area / SampleArea) * 100.0;
            distressDensity = (distressDensity > 100) ? 100 : distressDensity;

            double deductValue = DistressShared.CalculateDeductValue(distressCode, severity);
            double densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("G2")));
            double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);


            //DIST_CODE={0}, , DISTRESS_AR_TYPE='{8}' , distressArName
            sql = string.Format("UPDATE DISTRESS SET STATUS='N', STATUS_UPD='N', DIST_SEVERITY='{1}', DIST_AREA={2}, DIST_DENSITY={3}, DEDUCT_VALUE={4}, DEN_DASH={5}, DEDUCT_DEN_DASH={6}  WHERE DIST_ID={7} ",
                distressCode, severity, area.ToString("0.00"), distressDensity.ToString("0.00"), deductValue.ToString("0.00"), densityDashValue.ToString("0.00"),
                deductDashValue.ToString("0.00"), DIST_ID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("DISTRESS", DIST_ID.ToString(), "Distress Update", user);
            return (rows > 0);
        }

        public bool UpdateRegionSecondaryStreetDistress(int secondaryStID, double? DIST_AREA, int DIST_ID, string user)
        {
            // string DIST_CODE, char DIST_SEVERITY,
            string lang = HttpContext.Current.Session["lang"].ToString();

            //int distressCode = int.Parse(DIST_CODE);
            int distressCode = -1;
            string sql = string.Format("SELECT STATUS_UPD, dist_code, DIST_SEVERITY FROM DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
                return false;

            DataRow dr = dt.Rows[0];
            string statusUpd = dr["STATUS_UPD"].ToString();  //db.ExecuteScalar(sql).ToString();
            distressCode = int.Parse(dr["dist_code"].ToString());
            char severity = dr["DIST_SEVERITY"].ToString()[0];
            if (statusUpd.ToUpper() == "Y")
                throw new Exception(Feedback.NonUpdateableDistress());

            if (distressCode > 0 && DIST_AREA == 0)
                throw new Exception("الرجاء إدخال المساحة");

            //sql = string.Format("select nvl(DISTRESS_AR_TYPE, '') from DISTRESS_CODE where DIST_CODE={0} ", DIST_CODE);
            //string distressArName = db.ExecuteScalar(sql).ToString();

            //if (DIST_CODE.Length == 0)
            //    throw new Exception(Feedback.NoDistressSelected(lang));
            //else if (int.Parse(DIST_CODE) != 0 && DIST_SEVERITY == 'N')
            //    throw new Exception(Feedback.NoDistressSeveritySelected(lang));


            //sql = string.Format("select (SECOND_ST_LENGTH*SECOND_ST_WIDTH) from SECONDARY_STREETS where SECOND_ID={0} ", secondaryStID);
            sql = string.Format("select (SECOND_ST_LENGTH*SECOND_ST_WIDTH) from STREETS where STREET_ID={0} ", secondaryStID);
            double SampleArea = double.Parse(db.ExecuteScalar(sql).ToString());

            //if (DIST_AREA > SampleArea)
            //    throw new Exception(Feedback.DistressAreaLargerThanSampleArea());

            double area = (DIST_AREA == null) ? 0 : (double)DIST_AREA;
            //if (distressCode >= 1 && distressCode <= 11)
            //{
            if (area > SampleArea)
                throw new Exception(Feedback.DistressAreaLargerThanSampleArea());
            //}
            //else if (distressCode >= 13 && distressCode <= 15)
            //{
            //    double patchArea = DistressShared.GetSamplePatchesArea(secondaryStID, JobType.RegionSecondaryStreets);
            //    if (area > patchArea)
            //        throw new Exception(Feedback.PatchDistressAreaLargerThanPatchArea(lang));
            //}

            //double enteredAreas = DistressShared.GetSampleNonPatchDistressAreaForUpdate(secondaryStID, JobType.RegionSecondaryStreets, DIST_ID);
            //enteredAreas += area;
            //if (enteredAreas > SampleArea)
            //    throw new Exception("مجموع مساحات العيوب المدخلة يتجاوز مساحة العينة، لذا لم يتم الحفظ");



            double distressDensity = (area / SampleArea) * 100.0;
            distressDensity = (distressDensity > 100) ? 100 : distressDensity;

            double deductValue = DistressShared.CalculateDeductValue(distressCode, severity);
            double densityDashValue = DistressShared.CalculateDensityDashValue(distressCode, double.Parse(distressDensity.ToString("N2")));
            double deductDashValue = DistressShared.CalculateDeductDashValue(deductValue, densityDashValue);

            // , DISTRESS_AR_TYPE='{8}', distressArName
            sql = string.Format("UPDATE DISTRESS SET STATUS='N', STATUS_UPD='N', DIST_CODE={0}, DIST_SEVERITY='{1}', DIST_AREA={2}, DIST_DENSITY={3}, DEDUCT_VALUE={4}, DEN_DASH={5}, DEDUCT_DEN_DASH={6}  WHERE DIST_ID={7} ",
                distressCode, severity, area.ToString("0.00"), distressDensity.ToString("0.00"), deductValue.ToString("0.00"), densityDashValue.ToString("0.00"),
                deductDashValue.ToString("0.00"), DIST_ID);

            int rows = db.ExecuteNonQuery(sql);
            Shared.SaveLogfile("DISTRESS", DIST_ID.ToString(), "Distress Update", user);
            return (rows > 0);
        }



        public bool EditDistressImage(string imageFileName, int DIST_ID)
        {
            if (DIST_ID == 0)
                return false;

            string sql = string.Format("update DISTRESS set DISTRESS_IMAGE='{0}' where DIST_ID={1} ", imageFileName, DIST_ID);
            int rows = new OracleDatabaseClass().ExecuteNonQuery(sql);
            return (rows > 0);
        }

        #endregion


        #region DistressDelete

        public bool DeleteSectionDistress(int DIST_ID, string user)
        {
            if (DIST_ID == 0)
                return false;

            string lang = HttpContext.Current.Session["lang"].ToString();
            //string sql = string.Format("SELECT STATUS_UPD, SAMPLE_ID, SURVEY_NO, SURVEY_Date, SECTION_ID FROM DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            //DataTable dt = db.ExecuteQuery(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    DataRow dr = dt.Rows[0];

            string sql = string.Format("delete from DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
            //}
            //else
            //    return false;
        }

        public bool DeleteIntersectionDistress(int DIST_ID, string user)
        {
            if (DIST_ID == 0)
                return false;

            string lang = HttpContext.Current.Session["lang"].ToString();


            //string sql = string.Format("SELECT STATUS_UPD, INTER_SAMP_ID, SURVEY_NO, SURVEY_Date, INTERSECTION_ID FROM DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            //DataTable dt = db.ExecuteQuery(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    DataRow dr = dt.Rows[0];

            string sql = string.Format("delete from DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
            //}
            //else
            //    return false;
        }

        public bool DeleteSecondaryStreetRegionDistress(int DIST_ID, string user)
        {
            if (DIST_ID == 0)
                return false;

            string lang = HttpContext.Current.Session["lang"].ToString();


            int rows = 0; // SECOND_ID, 
            string sql = string.Format("SELECT region_no, STATUS_UPD, STREET_ID, SURVEY_NO, SURVEY_Date, region_no FROM DISTRESS WHERE DIST_ID={0} ", DIST_ID);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                sql = string.Format("delete from DISTRESS WHERE DIST_ID={0} ", DIST_ID);
                rows = db.ExecuteNonQuery(sql);
                if (rows > 0)
                {
                    sql = string.Format("select dist_id from DISTRESS where region_no='{0}' and SURVEY_NO={1} ", dr["region_no"].ToString(), dr["SURVEY_NO"].ToString());
                    DataTable dtRemaining = db.ExecuteQuery(sql);
                    if (dtRemaining.Rows.Count == 0)
                    {
                        sql = string.Format("delete from REGION_SURVEYS where region_no='{0}' and survey_no={1} ", dr["region_no"].ToString(), dr["SURVEY_NO"].ToString());
                        db.ExecuteNonQuery(sql);
                    }


                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion


        #region GettingSurveyDistresses

        public DataTable GetSectionSampleSurveyDistresses(int sampleID, int surveyNo)
        {
            if (sampleID == 0 || surveyNo == 0)
                return new DataTable();

            string sql = string.Format("SELECT d.DIST_ID, d.DIST_CODE, d.SAMPLE_ID, to_char(d.SURVEY_DATE ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, d.DIST_AREA, " +
                " d.DIST_DENSITY, d.DIST_SEVERITY, d.DEDUCT_VALUE, d.DEN_DASH, d.DEDUCT_DEN_DASH, d.SURVEY_DATE_H, (d.DIST_CODE || '-' || dc.DISTRESS_AR_TYPE) AS DISTRESS_TITLE " +
                " FROM DISTRESS d INNER JOIN DISTRESS_CODE dc ON d.DIST_CODE = dc.DIST_CODE WHERE d.SAMPLE_ID={0} AND d.SURVEY_NO={1}  " +
                " order by d.DIST_CODE, d.DIST_SEVERITY ", sampleID, surveyNo);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetIntersectionSampleSurveyDistresses(int intersectionSampleID, int surveyNo)
        {
            if (intersectionSampleID == 0 || surveyNo == 0)
                return new DataTable();

            string sql = string.Format("SELECT d.DIST_ID, d.DIST_CODE, to_char(d.SURVEY_DATE ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, d.DIST_AREA, d.DIST_DENSITY, " +
                " d.DIST_SEVERITY, d.DEDUCT_VALUE, d.DEN_DASH, d.DEDUCT_DEN_DASH, d.SURVEY_DATE_H, (d.DIST_CODE || '-' || dc.DISTRESS_AR_TYPE) AS DISTRESS_TITLE " +
                " FROM DISTRESS d INNER JOIN DISTRESS_CODE dc ON d.DIST_CODE = dc.DIST_CODE WHERE d.INTER_SAMP_ID={0} AND d.SURVEY_NO={1}  " +
                " order by d.DIST_CODE, d.DIST_SEVERITY ", intersectionSampleID, surveyNo);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetRegionSecondaryStreetSurveyDistresses(int secondStID, int surveyNo)
        {
            if (secondStID == 0 || surveyNo == 0)
                return new DataTable();

            // SECOND_ID
            string sql = string.Format("SELECT d.DIST_ID, d.DIST_CODE, to_char(d.SURVEY_DATE ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, d.DIST_AREA, d.DIST_DENSITY, " +
                " d.DIST_SEVERITY, d.DEDUCT_VALUE, d.DEN_DASH, d.DEDUCT_DEN_DASH, d.SURVEY_DATE_H, (d.DIST_CODE || '-' || dc.DISTRESS_AR_TYPE) as DISTRESS_TITLE " +
                " FROM  DISTRESS d INNER JOIN  DISTRESS_CODE dc ON d.DIST_CODE = dc.DIST_CODE WHERE d.STREET_ID={0} AND d.SURVEY_NO={1}  " +
                " order by d.DIST_CODE, d.DIST_SEVERITY ", secondStID, surveyNo);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetSectionDistresses(int sectionID, int surveyNo)
        {
            if (sectionID == 0 || surveyNo == 0)
                return new DataTable();

            // group by dist_code, dist_severity  DISTRESS_SEC 
            string sql = string.Format("SELECT * FROM gv_sample_DISTRESS where SECTION_ID={0} AND SURVEY_NO={1}  ORDER BY LANE_TYPE, sample_no, DIST_CODE, DIST_SEVERITY ", sectionID, surveyNo);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetSectionDistresses(int sectionID)
        {
            if (sectionID == 0)
                return new DataTable();

            // group by dist_code, dist_severity  DISTRESS_SEC 
            // AND SURVEY_NO=(SELECT max(survey_no) FROM gv_sample_DISTRESS where SECTION_ID={0}) 
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SECT_SAMPS where SECTION_ID={0}  ORDER BY LANE_TYPE, sample_no, DIST_CODE, DIST_SEVERITY ", sectionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetSectionSurroundingRegionDistresses(int regionID, int surveyNo)
        {
            if (regionID == 0 || surveyNo == 0)
                return new DataTable();

            string regionNum = region.GetRegionNum(regionID);
            string sql = string.Format("SELECT * FROM gv_sample_DISTRESS where SECTION_no like '{0}%' AND SURVEY_NO={1}  ORDER BY section_no, LANE_TYPE, sample_no, DIST_CODE, DIST_SEVERITY ", regionNum, surveyNo);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSectionSurroundingRegionDistresses(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // AND SURVEY_NO=(SELECT max(survey_no) FROM gv_sample_DISTRESS where SECTION_no like '{0}%') 
            string regionNum = region.GetRegionNum(regionID);
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SECT_SAMPS where SECTION_no like '{0}%'  " +
                " ORDER BY section_no, LANE_TYPE, sample_no, DIST_CODE, DIST_SEVERITY ", regionNum);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMunicSectionsDistresses(string municNum)
        {
            if (municNum == "0" || string.IsNullOrEmpty(municNum))
                return new DataTable();

            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SECT_SAMPS where SECTION_no like '{0}%'  " +
                " ORDER BY section_no, LANE_TYPE, sample_no, DIST_CODE, DIST_SEVERITY ", municNum);

            return db.ExecuteQuery(sql);
        }

        #endregion


        public string GetDistressImage(int DIST_ID)
        {
            if (DIST_ID == 0)
                return "";

            string sql = string.Format("select nvl(DISTRESS_IMAGE, '')  as DISTRESS_IMAGE from DISTRESS where DIST_ID={0} ", DIST_ID);
            return db.ExecuteScalar(sql).ToString();
        }


        #region MainStreetSectionsDistressesReport

        public DataTable GetMainStreetDistresses(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // MAIN_ST_ID
            string sql = string.Format("SELECT * FROM gv_sample_DISTRESS where STREET_ID={0} and survey_no=(SELECT max(survey_no) FROM gv_sample_DISTRESS where STREET_ID={0}) " +
                " ORDER BY sec_order, sec_direction, section_no, lane_type, sample_no, DIST_CODE, dist_severity ", mainStID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetDistresses(int mainStID, DateTime? from, DateTime? to)
        {
            //if (mainStID == 0)
            //    return new DataTable();

            string mainStPart = (mainStID == 0) ? "" : string.Format(" STREET_ID={0} AND ", mainStID);

            string sql = string.Format("SELECT * FROM gv_sample_DISTRESS where {0} survey_date between TO_DATE('{1}','DD/MM/YYYY') and TO_DATE('{2}','DD/MM/YYYY') " +
                " ORDER BY sec_order, sec_direction, section_no, lane_type, sample_no, DIST_CODE, dist_severity ",
                mainStPart, ((DateTime)from).ToString("dd/MM/yyyy"), ((DateTime)to).ToString("dd/MM/yyyy"));

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetDistressAreaTotal(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM dist_code_distress_main_AVG where STREET_ID={0} ORDER BY dist_code,dist_severity ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetDistressesTotalBydistress(int distressCode)
        {
            if (distressCode < 0 || distressCode > 15)
                return new DataTable();

            // and section_id is not null 
            string sql = string.Format("SELECT * FROM dist_code_distress_AVG_All where dist_code={0}  ORDER BY dist_code ", distressCode);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetDistressArea(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM dist_code_distress_main where STREET_ID={0} ORDER BY section_no, sec_direction, sec_order, lane_type, dist_code, dist_severity ", mainStID);
            return db.ExecuteQuery(sql);
        }

        #endregion

        #region IntersectionDistressesReport

        public DataTable GetIntersectionDistressesReport(int intersectionID, int surveyNo)
        {
            if (intersectionID == 0 || surveyNo == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM GV_INTERSECTION_DISTRESS where INTERSECTION_ID={0}  order by inter_NO, INTER_SAMP_NO, dist_code ", intersectionID, surveyNo);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionDistressesReport(int intersectionID)
        {
            if (intersectionID == 0)
                return new DataTable();

            //" and survey_no=(SELECT max(survey_no) FROM GV_INTERSECTION_DISTRESS where INTERSECTION_ID={0})  " + 
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_INTERSECT where INTERSECTION_ID={0}  order by inter_NO, INTER_SAMP_NO, dist_code ", intersectionID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetIntersectionDistressesReport(string municNum)
        {
            if (municNum == "0" || string.IsNullOrEmpty(municNum))
                return new DataTable();

            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_INTERSECT where inter_no like '{0}%'  order by arname, inter_NO, INTER_SAMP_NO, dist_code ", municNum);
            return db.ExecuteQuery(sql);
        }


        public DataTable GetIntersectionDistresses(int intersectionID, int surveyNo)
        {
            if (intersectionID == 0 || surveyNo == 0)
                return new DataTable();

            // group by dist_code, dist_severity
            string sql = string.Format("SELECT * FROM DISTRESS_SEC where SECTION_ID={0} AND SURVEY_NO={1}  ORDER BY sample_no, LANE_TYPE, DIST_CODE, DIST_SEVERITY ", intersectionID, surveyNo);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetInersectionsDistressesReport(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // and survey_no=(select max(survey_no) FROM jpmms.DISTRESS_INTERSECT where street_id={0}) 
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_INTERSECT where STREET_ID={0}  order by inteR_NO, INTER_samp_NO, dist_code ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsDistressArea(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // MAIN_STREET_ID
            string sql = string.Format("SELECT * FROM dist_code_distress_INTER_main where STREET_ID={0}  ORDER BY INTERSECTION_Order, INTER_NO, INTER_SAMP_NO, dist_code, dist_severity ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionsDistressAreaTotal(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // MAIN_STREET_ID
            string sql = string.Format("SELECT * FROM dist_code_distress_inter_AVG where STREET_ID={0}  ORDER BY dist_code, dist_severity ", mainStID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetIntersectionDistressesTotalBydistress(int distressCode)
        {
            if (distressCode < 0 || distressCode > 15)
                return new DataTable();

            // and intersection_id is not null
            string sql = string.Format("SELECT * FROM dist_code_distress_AVG_All where dist_code={0}   ORDER BY dist_code ", distressCode);
            return db.ExecuteQuery(sql);
        }

        #endregion

        #region RegionDistressesReport

        public DataTable GetRegionDistressesReport(int regionID, int surveyNo, bool patchDists, int secondID)
        {
            if (regionID == 0 || surveyNo == 0)
                return new DataTable();

            string secondIdPart = (secondID == 0) ? "" : string.Format(" and STREET_ID={0} ", secondID); // second_id
            string patchDistPart = patchDists ? " and DIST_CODE in (12, 13, 14, 15) " : "";

            string sql = string.Format("SELECT * FROM gv_sec_st_distress where region_id={0} AND SURVEY_NO={1} {2} {3} ORDER BY region_no, SECOND_ST_NO, dist_code ",
                regionID, surveyNo, patchDistPart, secondIdPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionDistressesReport(int regionID, bool patchDists, int secondID)
        {
            if (regionID == 0)
                return new DataTable();

            string secondIdPart = (secondID == 0) ? "" : string.Format(" and STREET_ID={0} ", secondID); // second_id
            string patchDistPart = patchDists ? " and DIST_CODE in (12, 13, 14, 15) " : "";

            // AND SURVEY_NO=(SELECT max(survey_no) FROM gv_sec_st_distress where region_id={0})
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SEC_ST where region_id={0} {1} {2} ORDER BY region_no, SECOND_ST_NO, dist_code ",
                regionID, patchDistPart, secondIdPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionDistressesReport(string municName, bool patchDists)
        {
            if (string.IsNullOrEmpty(municName) || municName == "0")
                return new DataTable();

            string patchDistPart = patchDists ? " and DIST_CODE in (12, 13, 14, 15) " : "";
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SEC_ST where MUNIC_NAME='{0}' {1}  ORDER BY region_no, SECOND_ST_NO, dist_code ",
                municName, patchDistPart);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetRegionDistressesReport(int regionID, int surveyNo, DateTime? dateFrom, DateTime? dateTo)
        {
            if (surveyNo == 0) // regionID == 0 ||
                return new DataTable();

            string regionPart = (regionID == 0) ? "" : string.Format(" region_id={0} AND ", regionID);

            string sql = string.Format("SELECT * FROM DISTRESS_regions where {0} SURVEY_NO={1} and survey_DATE between TO_DATE('{2}','DD/MM/YYYY') and TO_DATE('{3}','DD/MM/YYYY')  ORDER BY survey_date, region_no, SECOND_ST_NO, dist_code ",
                regionPart, surveyNo, ((DateTime)dateFrom).ToString("dd/MM/yyyy"), ((DateTime)dateTo).ToString("dd/MM/yyyy"));

            return db.ExecuteQuery(sql);
        }

        public DataTable GetRegionDistressesReport(DateTime? dateFrom, DateTime? dateTo)
        {
            string sql = string.Format("SELECT * FROM DISTRESS_regions where survey_DATE between TO_DATE('{0}','DD/MM/YYYY') and TO_DATE('{1}','DD/MM/YYYY')  ORDER BY survey_date, region_no, SECOND_ST_NO, dist_code ",
                 ((DateTime)dateFrom).ToString("dd/MM/yyyy"), ((DateTime)dateTo).ToString("dd/MM/yyyy"));

            return db.ExecuteQuery(sql);
        }


        public DataTable GetByRegionDistressArea(int regionID, int survey)
        {
            if (regionID == 0 || survey == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM dist_code_distresS_subdist where REGION_ID={0} AND SURVEY_NO={1}  ORDER BY region_no, dist_code, dist_severity ", regionID, survey);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByRegionDistressArea(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // dist_code_distresS_subdist  AND SURVEY_NO=(seelct max(survey_no) from dist_code_distresS_subdist where REGION_ID={0})
            //string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SUBDIST where REGION_ID={0}  ORDER BY region_no, dist_code, dist_severity ", regionID);
            string sql = string.Format("select region_no, subdistrict, region_id, dist_code, DISTRESS_AR_TYPE, dist_severity, sum(dist_area) as sum_dist_area " +
                            "from VW_LATEST_DISTRESS_SEC_ST where region_id={0} " +
                            "group by region_no, subdistrict, region_id, dist_code, DISTRESS_AR_TYPE, dist_severity   order by region_no, dist_code, dist_severity ", regionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetByRegionDistressAreaTotal(int regionID, int survey, bool allDists)
        {
            if (regionID == 0 || survey == 0)
                return new DataTable();

            string distPart = allDists ? "" : " and dist_code in (12, 13, 14, 15) ";
            string sql = string.Format("SELECT * FROM DIST_CODE_DISTRESS_SUBDIST_AVG where REGION_ID={0} AND SURVEY_NO={1} {2} ORDER BY region_no, dist_code ",
                regionID, survey, distPart);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetByRegionDistressAreaTotal(int regionID, bool allDists)
        {
            if (regionID == 0)
                return new DataTable();

            // AND SURVEY_NO=(SELECT max(survey_no) FROM DIST_CODE_DISTRESS_SUBDIST_AVG where REGION_ID={0}) 
            string distPart = allDists ? "" : " and dist_code in (12, 13, 14, 15) ";
            string sql = string.Format("SELECT * FROM VW_LATEST_DISTRESS_SUBDIST_AVG where REGION_ID={0} {1} ORDER BY region_no, dist_code ", regionID, distPart);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetByRegionDistressAreaSeverity(int regionID, int survey)
        {
            if (regionID == 0 || survey == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM DISTRESS_SUBDIST_SEVERITY where REGION_ID={0} AND SURVEY_NO={1}  ORDER BY region_no, dist_code, dist_severity ", regionID, survey);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByRegionDistressAreaSeverity(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // DISTRESS_SUBDIST_SEVERITY  AND SURVEY_NO=(SELECT max(survey_no) FROM DISTRESS_SUBDIST_SEVERITY where REGION_ID={0}) 
            string sql = string.Format("SELECT * FROM vw_latest_dist_subdist_sev where REGION_ID={0}  ORDER BY region_no, dist_code, dist_severity ", regionID);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetByRegionDistressAreaSeverityTotal(int regionID, int survey)
        {
            if (regionID == 0 || survey == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM DISTRESS_SUBDIST_AVG where REGION_ID={0} AND SURVEY_NO={1} ORDER BY dist_code, dist_severity ", regionID, survey);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByRegionDistressAreaSeverityTotal(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            // DISTRESS_SUBDIST_AVG AND SURVEY_NO=(SELECT max(survey_no) FROM DISTRESS_SUBDIST_AVG where REGION_ID={0}) 
            string sql = string.Format("SELECT * FROM vw_latest_dist_region_sum where REGION_ID={0}  ORDER BY dist_code, dist_severity ", regionID);

            return db.ExecuteQuery(sql);
        }


        public DataTable GetAllRegionsDistressArea(int survey)
        {
            if (survey == 0)
                return new DataTable();

            string sql = string.Format("SELECT * FROM dist_code_distresS_subdist where survey_no={0}  ORDER BY Subdistrict, region_no, dist_code, dist_severity ", survey);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllRegionsDistressArea()
        {
            // dist_code_distresS_subdist  where survey_no=(SELECT max(survey_no)  FROM dist_code_distresS_subdist) 
            string sql = "SELECT * FROM VW_LATEST_DIST_SUBDIST_sev  ORDER BY Subdistrict, region_no, dist_code, dist_severity ";
            return db.ExecuteQuery(sql);
        }


        public DataTable GetByRegionAreaTotal(int distressID, int survey, int regionID)
        {
            if (survey == 0) // distressID == 0 || 
                return new DataTable();

            string distCodePart = "";
            string regionPart = (regionID == 0) ? "" : string.Format(" and region_id={0} ", regionID);

            if (distressID == 0)
                distCodePart = "";
            else if (distressID == -1)
                distCodePart = " and DIST_CODE in (12, 13, 14, 15) ";
            else
                distCodePart = string.Format(" and DIST_CODE={0} ", distressID);


            string sql = string.Format("SELECT * FROM distresS_ST_AVG_all where survey_no={1} {0} {2}  ORDER BY dist_code ", distCodePart, survey, regionPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByRegionAreaTotal(int distressID, int regionID)
        {
            //if (survey == 0) // distressID == 0 || 
            //    return new DataTable();
            //string whereRegionPart = (regionID == 0) ? "" : string.Format(" where region_id={0} ", regionID);

            bool firstArgs = true;
            string distCodePart = "", regionPart = "";

            if (regionID != 0)
            {
                if (firstArgs)
                {
                    regionPart = string.Format(" where region_id={0} ", regionID);
                    firstArgs = false;
                }
                else
                    regionPart = string.Format(" and region_id={0} ", regionID);
            }
            else
                regionPart = "";


            if (distressID != 0)
            {
                if (firstArgs)
                {
                    if (distressID == -1)
                        distCodePart = " where DIST_CODE in (12, 13, 14, 15) ";
                    else
                        distCodePart = string.Format(" where DIST_CODE={0} ", distressID);
                }
                else
                {
                    if (distressID == -1)
                        distCodePart = " and DIST_CODE in (12, 13, 14, 15) ";
                    else
                        distCodePart = string.Format(" and DIST_CODE={0} ", distressID);
                }
            }
            else
                distCodePart = "";


            // where survey_no=(SELECT max(survey_no) FROM distresS_ST_AVG_all {2}) whereRegionPart
            string sql = string.Format("SELECT * FROM distresS_ST_AVG_all  {0} {1}  ORDER BY dist_code ", distCodePart, regionPart);
            return db.ExecuteQuery(sql);
        }

        #endregion

        #region GettingDistressInfo

        public DataTable GetIntersectDistressInfo(int distID)
        {
            if (distID == 0)
                return new DataTable();

            string sql = string.Format("SELECT MAIN_NO, MAIN_NAME, INTER_NO, INTEREC_STREET1, INTEREC_STREET2, INTER_SAMP_NO, SURVEY_NO, SURVEY_DATE, DIST_CODE, DISTRESS_AR_TYPE, DIST_SEVERITY, DIST_AREA, INTERSEC_SAMP_AREA, DIST_DENSITY FROM GV_INTERSECTION_DISTRESS where dist_id={0} ", distID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSecondaryStreetDistressInfo(int distID)
        {
            if (distID == 0)
                return new DataTable();

            string sql = string.Format("SELECT MUNIC_NAME, DIST_NAME, SUBDISTRICT, REGION_NO, SECOND_ST_NO, SECOND_AR_NAME, SECOND_ST_AREA, survey_no, SURVEY_DATE, DIST_CODE, DISTRESS_AR_TYPE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY FROM GV_SEC_ST_DISTRESS where dist_id={0} ", distID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSectionSampleDistressInfo(int distID)
        {
            if (distID == 0)
                return new DataTable();

            string sql = string.Format("SELECT MAIN_NO, MAIN_NAME, section_NO, FROM_STREET, TO_STREET, lane_type, sample_no, SAMPLE_AREA, survey_no, SURVEY_DATE, DIST_CODE, DISTRESS_AR_TYPE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY FROM GV_SAMPLE_DISTRESS where dist_id={0} ", distID);
            return db.ExecuteQuery(sql);
        }

        #endregion

        #region Distress Quantities

        public DataTable GetDistressQnty(DistressQntyReportType type, int streetID, int regionID, string subDistName, string distName, string municName, int distressCode, string SURVEYNO)
        {
            string sql = "";
            string distCodePart = (distressCode == -1) ? "and dist_code in (0, 12, 13, 14, 15) " : ((distressCode != 0) ? string.Format(" and dist_code={0} ", distressCode) : "");

            switch (type)
            {
                case DistressQntyReportType.MainStreetSections:
                    if (streetID == 0)
                        return new DataTable();

                    sql = string.Format(@"select main_no, arname, main_name, section_no, from_street, to_street, lane_type, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_SECT_SAMPS where SURVEY_NO={2} and street_id={0} {1}
                            group by main_no, arname, main_name, section_no, from_street, to_street, lane_type, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by main_name, section_no, lane_type, dist_code ", streetID, distCodePart, SURVEYNO);
                    break;
                case DistressQntyReportType.MainStreetIntersects:
                    if (streetID == 0)
                        return new DataTable();

                    sql = string.Format(@"select main_no, arname, main_name, inter_no, INTEREC_STREET1, INTEREC_STREET2, INTER_SAMP_NO, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_INTERSECT where SURVEY_NO={2} and  street_id={0} {1}
                            group by main_no, arname, main_name, inter_no, INTEREC_STREET1, INTEREC_STREET2, INTER_SAMP_NO, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by main_name, inter_no, INTER_SAMP_NO, dist_code ", streetID, distCodePart, SURVEYNO);
                    break;
                case DistressQntyReportType.SectionsInMunicipality:
                    if (string.IsNullOrEmpty(municName) || municName == "0")
                        return new DataTable();

                    sql = string.Format(@"select main_no, arname, main_name, section_no, from_street, to_street, lane_type, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_SECT_SAMPS where SURVEY_NO={2} and section_no like '{0}%' {1}
                            group by main_no, arname, main_name, section_no, from_street, to_street, lane_type, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by main_name, section_no, lane_type, dist_code ", municName, distCodePart, SURVEYNO);
                    break;
                case DistressQntyReportType.Region:
                    if (regionID == 0)
                        return new DataTable();

                    sql = string.Format(@"select  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_SEC_ST where SURVEY_NO={2} and region_id={0} {1}
                            group by  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by region_no, second_st_no, dist_code ", regionID, distCodePart, SURVEYNO);
                    break;
                case DistressQntyReportType.Subdistrict:
                    if (string.IsNullOrEmpty(subDistName) || subDistName == "0")
                        return new DataTable();

                    sql = string.Format(@"select  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_SEC_ST where SURVEY_NO={2} and SUBDISTRICT='{0}' {1}
                            group by  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by region_no, second_st_no, dist_code ", subDistName, distCodePart, SURVEYNO);
                    break;
                case DistressQntyReportType.District:
                    if (string.IsNullOrEmpty(distName) || distName == "0")
                        return new DataTable();

                    sql = string.Format(@"select  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_SEC_ST where SURVEY_NO={2} and DIST_NAME='{0}' {1}
                            group by  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by region_no, second_st_no, dist_code ", distName, distCodePart, SURVEYNO);
                    break;
                case DistressQntyReportType.Municipality:
                    if (string.IsNullOrEmpty(municName) || municName == "0")
                        return new DataTable();

                    sql = string.Format(@"select  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, max(survey_date) as survey_date, 
                            dist_code, DISTRESS_AR_TYPE, sum(dist_area) as dist_area from VW_LATEST_DISTRESS_SEC_ST where SURVEY_NO={2} and region_no like '{0}%' {1}
                            group by  region_no, SUBDISTRICT, DIST_NAME, MUNIC_NAME, second_st_no, SECOND_ARNAME, survey_no, dist_code, DISTRESS_AR_TYPE
                            order by region_no, second_st_no, dist_code ", municName, distCodePart, SURVEYNO);
                    break;
            }

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }

        #endregion

    }
}
