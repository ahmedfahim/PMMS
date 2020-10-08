using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL.DistressEntry
{
    public class DistressShared
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public static double CalculateDeductValue(int distressCode, char severity)
        {
            switch (distressCode)
            {
                case 0:
                    return 0;
                case 1:
                    return ((severity == 'H') ? 4.5 : ((severity == 'M') ? 3.5 : ((severity == 'L') ? 3 : 0)));
                case 2:
                case 3:
                case 11:
                    return ((severity == 'H') ? 4 : ((severity == 'M') ? 2.5 : ((severity == 'L') ? 2 : 0)));
                case 4:
                case 10:
                    return 1;
                case 5:
                    return ((severity == 'H') ? 5 : ((severity == 'M') ? 4.5 : ((severity == 'L') ? 4 : 0)));
                case 6:
                case 8:
                case 12:
                case 13:
                case 15:
                    return ((severity == 'H') ? 4 : ((severity == 'M') ? 3 : ((severity == 'L') ? 2 : 0)));
                case 7:
                    return ((severity == 'H') ? 4.5 : ((severity == 'M') ? 3 : ((severity == 'L') ? 2.5 : 0)));
                case 9:
                    return ((severity == 'H') ? 3.5 : ((severity == 'M') ? 2 : ((severity == 'L') ? 1 : 0)));
                case 14:
                    return ((severity == 'H') ? 4 : ((severity == 'M') ? 3.5 : ((severity == 'L') ? 3 : 0)));
                default:
                    return 0;
            }
        }


        public static double CalculateDensityDashValue(int distressCode, double density)
        {
            switch (distressCode)
            {
                case 1:
                case 2:
                case 3:
                    if (density >= 0 && density <= 2.0)
                        return (12.5 * density);
                    else if (density > 2.0 && density <= 10.0)
                        return (30.0 / 8.0 * (density - 2.0) + 25.0);
                    else if (density > 10.0 && density <= 25.0)
                        return (20.0 / 15.0 * (density - 10.0) + 55.0);
                    else if (density > 25.0 && density <= 50.0)
                        return (10.0 / 25.0 * (density - 25.0) + 75.0);
                    else if (density > 50.0 && density <= 100.0)
                        return (15.0 / 50.0 * (density - 50.0) + 85.0);
                    else
                        return 5.0 * density;

                case 5:
                    if (density >= 0 && density <= 2.0)
                        return (15.0 * density);
                    else if (density > 2.0 && density <= 10.0)
                        return (40.0 / 8.0 * (density - 2.0) + 30.0);
                    else if (density > 10.0 && density <= 25.0)
                        return (10.0 / 15.0 * (density - 10.0) + 70.0);
                    else if (density > 25.0 && density <= 50.0)
                        return (10.0 / 15.0 * (density - 25.0) + 80.0);
                    else if (density > 50.0 && density <= 100.0)
                        return (10.0 / 50.0 * (density - 50.0) + 90.0);
                    else
                        return 5.0 * density;

                case 6:
                case 7:
                case 8:
                    if (density >= 0 && density <= 2.0)
                        return (10.0 * density);
                    else if (density > 2.0 && density <= 10.0)
                        return (30.0 / 8.0 * (density - 2.0) + 20);
                    else if (density > 10.0 && density <= 25.0)
                        return (20.0 / 15.0 * (density - 10.0) + 50.0);
                    else if (density > 25.0 && density <= 50.0)
                        return (10.0 / 25.0 * (density - 25.0) + 70.0);
                    else if (density > 50.0 && density <= 100.0)
                        return (20.0 / 50.0 * (density - 50.0) + 80.0);
                    else
                        return 5.0 * density;

                case 12:
                case 13:
                case 14:
                case 15:
                    if (density >= 0 && density <= 2.0)
                        return (9.0 * density);
                    else if (density > 2.0 && density <= 10.0)
                        return (30.0 / 8.0 * (density - 2.0) + 18.0);
                    else if (density > 10.0 && density <= 25.0)
                        return (20.0 / 15.0 * (density - 10.0) + 48.0);
                    else if (density > 25.0 && density <= 50.0)
                        return (10.0 / 25.0 * (density - 25.0) + 68.0);
                    else if (density > 50.0 && density <= 100.0)
                        return (22.0 / 50.0 * (density - 50.0) + 78.0);
                    else
                        return 5.0 * density;

                case 4:
                case 9:
                case 10:
                case 11:
                    if (density >= 0 && density <= 2.0)
                        return (5.0 * density);
                    else if (density > 2.0 && density <= 10.0)
                        return (20.0 / 8.0 * (density - 2.0) + 20.0);
                    else if (density > 10.0 && density <= 25.0)
                        return (20.0 / 15.0 * (density - 10.0) + 30.0);
                    else if (density > 25.0 && density <= 50.0)
                        return (20.0 / 25.0 * (density - 25.0) + 50.0);
                    else if (density > 50.0 && density <= 100.0)
                        return (30.0 / 50.0 * (density - 50.0) + 70.0);
                    else
                        return 5.0 * density;

                default:
                    return 5.0 * density;
            }
        }


        public static double CalculateDeductDashValue(double deduct, double densityDash)
        {
            return ((deduct * densityDash) / 100.0);
        }



        //public void UpdateNoDistressesSample(int surveyNo)
        //{
        //    if (surveyNo == 0)
        //        return;

        //    string sql = string.Format("UPDATE DISTRESS SET DIST_CODE=0, DIST_SEVERITY='N', dist_area=0 ,DIST_CODE_UPD=0, DIST_SEVERITY_upd='N', dist_area_UPD=0 WHERE DIST_CODE is null AND DIST_SEVERITY is null and STATUS='N' AND SURVEY_NO={0} ", surveyNo);
        //    db.ExecuteNonQuery(sql);
        //}

        public double GetSamplePatchesArea(int ID, JobType jobType)
        {
            string sql = "";
            switch (jobType)
            {
                case JobType.Section:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code=4 and SAMPLE_ID={0} ", ID);
                    break;
                case JobType.Intersection:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code=4 and INTER_SAMP_ID={0} ", ID);
                    break;
                case JobType.RegionSecondaryStreets:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code=4 and STREET_ID={0} ", ID); // SECOND_ID
                    break;
            }

            if (!string.IsNullOrEmpty(sql))
            {
                DataTable dt = db.ExecuteQuery(sql);
                return ((dt.Rows.Count > 0) ? double.Parse(dt.Rows[0]["sum_dist_area"].ToString()) : 0);
            }
            else
                return 0;
        }

        public double GetSampleNonPatchDistressArea(int ID, JobType jobType)
        {
            string sql = "";
            switch (jobType)
            {
                // between 1 and 11
                case JobType.Section:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code in (1, 2, 4, 5, 6, 7, 8, 9, 10, 11) and SAMPLE_ID={0} ", ID);
                    break;
                case JobType.Intersection:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code in (1, 2, 4, 5, 6, 7, 8, 9, 10, 11) and INTER_SAMP_ID={0} ", ID);
                    break;
                case JobType.RegionSecondaryStreets:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code in (1, 2, 4, 5, 6, 7, 8, 9, 10, 11) and STREET_ID={0} ", ID); // SECOND_ID
                    break;
            }

            if (!string.IsNullOrEmpty(sql))
            {
                DataTable dt = db.ExecuteQuery(sql);
                return ((dt.Rows.Count > 0) ? double.Parse(dt.Rows[0]["sum_dist_area"].ToString()) : 0);
            }
            else
                return 0;
        }

        public double GetSampleNonPatchDistressAreaForUpdate(int ID, JobType jobType, int distID)
        {
            string sql = "";
            switch (jobType)
            {
                case JobType.Section:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code between 1 and 11 and SAMPLE_ID={0} and dist_id<>{1} ", ID, distID);
                    break;
                case JobType.Intersection:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code between 1 and 11 and INTER_SAMP_ID={0} and dist_id<>{1} ", ID, distID);
                    break;
                case JobType.RegionSecondaryStreets:
                    sql = string.Format("select nvl(sum(dist_area), 0) as sum_dist_area from distress where dist_code between 1 and 11 and STREET_ID={0} and dist_id<>{1} ", ID, distID); // SECOND_ID
                    break;
            }

            if (!string.IsNullOrEmpty(sql))
            {
                DataTable dt = db.ExecuteQuery(sql);
                return ((dt.Rows.Count > 0) ? double.Parse(dt.Rows[0]["sum_dist_area"].ToString()) : 0);
            }
            else
                return 0;
        }


    }
}
