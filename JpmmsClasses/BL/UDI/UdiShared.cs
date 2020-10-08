using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.OracleClient;
using JpmmsClasses.BL;
using Oracle.DataAccess.Client;
using System.Diagnostics;
using System.Configuration;

namespace JpmmsClasses.BL.UDI
{
    public class UdiShared
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();

        public enum UdiFilter
        {
            MainStreetsPoor = 1,
            MainStreetsPoorFair = 3,
            MainStreetsGoodExcellent = 5,
            AxesStreetsPoor = 2,
            AxesStreetsPoorFair = 4,
            AxesStreetsGoodExcellent = 6,
            MainStreetsAll = 7,
            AxesStreetsALL = 8
        }

        public static UdiRecord GetUDI(decimal deductDenRatio)
        {
            decimal udiValue = decimal.Parse((100 - (20 * deductDenRatio)).ToString("N0"));
            return GetUDIRatio(udiValue);
        }

        public static UdiRecord GetUDIRatio(decimal udi)
        {
            string rate = "";
            if (udi <= 39)
                rate = "Poor";
            else if (udi <= 69)
                rate = "Fair";
            else if (udi <= 89)
                rate = "Good";
            else
                rate = "Excellent";

            return new UdiRecord(udi, rate);
        }

        public static DataTable GetDistinctctRates()
        {
            string sql = "select distinct UDI_RATE from udi_section ";
            return new OracleDatabaseClass().ExecuteQuery(sql);
        }


        public PavementStatusReport GetAllPavementStatusTotals()
        {
            //OracleDatabaseClass db = new OracleDatabaseClass();

            string sql = "select sum(TOTAL_AREA) as TOTAL_AREA, sum(MAIN_ST_TOTAL_AREA) as MAIN_ST_TOTAL_AREA, sum(INTERSECT_TOTAL_AREA) as INTERSECT_TOTAL_AREA, sum(EXCELLENT_AREA) as EXCELLENT_AREA, sum(FAIR_AREA) as FAIR_AREA, sum(GOOD_AREA) as GOOD_AREA, sum(POOR_AREA) as POOR_AREA  from VW_MAINST_SURVEYED_TOTAL ";//VW_MAINST_PAVEMNT_STATUS
            DataTable dtMainSt = db.ExecuteQuery(sql);

            sql = "select sum(EXCELLENT_AREA) as EXCELLENT_AREA, sum(FAIR_AREA) as FAIR_AREA, sum(GOOD_AREA) as GOOD_AREA, sum(POOR_AREA) as POOR_AREA, sum(TOTAL_AREA) as TOTAL_AREA from VW_REGION_PAVEMENT_STATUS ";
            DataTable dtRegions = db.ExecuteQuery(sql);

            if (dtMainSt.Rows.Count == 0 || dtRegions.Rows.Count == 0)
                return new PavementStatusReport();
            else
            {
                DataRow drM = dtMainSt.Rows[0];
                DataRow drR = dtRegions.Rows[0];

                return new PavementStatusReport(double.Parse(drM["MAIN_ST_TOTAL_AREA"].ToString()), double.Parse(drM["INTERSECT_TOTAL_AREA"].ToString()),
                    double.Parse(drM["TOTAL_AREA"].ToString()), double.Parse(drR["TOTAL_AREA"].ToString()), 0, double.Parse(drM["EXCELLENT_AREA"].ToString()),
                    double.Parse(drM["FAIR_AREA"].ToString()), double.Parse(drM["GOOD_AREA"].ToString()), double.Parse(drM["POOR_AREA"].ToString()),
                    double.Parse(drR["EXCELLENT_AREA"].ToString()), double.Parse(drR["FAIR_AREA"].ToString()), double.Parse(drR["GOOD_AREA"].ToString()),
                    double.Parse(drR["POOR_AREA"].ToString()));
            }
        }


        public DataTable GetRoadsNetworkUDI(RoadType type, int survey, string municName)
        {
            string sql = "";
            switch (type)
            {
                case RoadType.Section: //MIDLANESECUDI 
                    sql = string.Format("SELECT * FROM VW_SECTION_LANES_UDI where SURVEY_NO={0}  order by main_no, sec_ORDER, lane_type ", survey);
                    break;
                case RoadType.Intersect:
                    sql = string.Format("SELECT * FROM UDI_INTERSECTIONS where survey_no={0} order by main_no, INTER_NO ", survey);
                    break;
                case RoadType.RegionSecondarySt:
                    string municPart = ((municName == "0") || string.IsNullOrEmpty(municName)) ? "" : string.Format(" and MUNIC_NAME='{0}' ", municName);
                    sql = string.Format("SELECT * FROM UDI_REGIONS_sum where SURVEY_NO={0} and UDI_VALUE is not null {1}  ORDER BY region_no ", survey, municPart);
                    break;
                default:
                    return new DataTable();
            }

            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }

        public DataTable GetRoadsNetworkUDI(RoadType type, string municName, int surveyNum)
        {
            string sql = "", surveyPart = "";
            switch (type)
            {
                case RoadType.Section: //MIDLANESECUDI  
                    surveyPart = surveyNum == 0 ? "" : string.Format(" where survey_no={0} ", surveyNum);
                    //surveyPart = "where SURVEY_NO=(select max(survey_no) from VW_SECTION_LANES_UDI) ";    arname 
                    //sql = string.Format("SELECT * FROM VW_LATEST_UDI_LANES {0}  order by main_no, sec_ORDER, lane_type ", surveyPart); 
                    sql = string.Format("select * from VW_SECTION_LANES_UDI  {0}  order by main_name, sec_order, lane_type ", surveyPart);
                    break;
                case RoadType.Intersect:
                    surveyPart = surveyNum == 0 ? "" : string.Format(" where survey_no={0} ", surveyNum);
                    //surveyPart = "where SURVEY_NO=(select max(survey_no) from UDI_INTERSECTIONS) ";  VW_LATEST_UDI_INTERSECTIONS   arname
                    //sql = string.Format("SELECT * FROM UDI_INTERSECTIONS {0} order by main_no, INTER_NO ", surveyPart);
                    sql = string.Format("select * from UDI_INTERSECTIONS {0}  order by main_name, inter_no ", surveyPart);
                    break;
                case RoadType.RegionSecondarySt:
                    surveyPart = surveyNum == 0 ? "" : string.Format(" and survey_no={0} ", surveyNum);
                    //surveyPart = "and SURVEY_NO=(select max(survey_no) from UDI_REGIONS_sum) "; //   VW_LATEST_UDI_REGIONS 
                    string municPart = ((municName == "0") || string.IsNullOrEmpty(municName)) ? "" : string.Format(" and MUNIC_NAME='{0}' ", municName);
                    sql = string.Format("SELECT * FROM UDI_REGIONS_sum   where UDI_VALUE is not null {0} {1}  ORDER BY region_no ", municPart, surveyPart);
                    break;
                default:
                    return new DataTable();
            }

            return (!string.IsNullOrEmpty(sql)) ? db.ExecuteQuery(sql) : new DataTable();
        }



        public static decimal? GetRoadNetworkItemUdi(string sectionID, string interID, string sampleID, string regionID, string secondID)
        {
            //DataTable dt;
            //int lastSurveyNum = 0;

            string sql = "";
            decimal? lastUDI = null;

            if (!string.IsNullOrEmpty(sectionID) && sectionID != "0")
            {
                //if (sectionID == "0")
                //    return null;

                //dt = new DistressSurvey().GetSectionLatestSurvey(int.Parse(sectionID));
                //if (dt.Rows.Count == 0)
                //    return null;
                //else if (int.Parse(dt.Rows[0]["SURVEY_NO"].ToString()) == 0)
                //    return null;
                //else
                //    lastSurveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());

                // UDI_SECTION and SURVEY_NO={1}  , lastSurveyNum

                if (string.IsNullOrEmpty(sampleID) || sampleID == "0")
                {
                    // get section UDI
                    sql = string.Format("select UDI_VALUE from VW_LATEST_UDI_SECTIONS where SECTION_ID={0} ", sectionID);
                    lastUDI = new OracleDatabaseClass().ExecuteScalarNullable(sql);
                }
                else
                {
                    // get section sample UDI
                    sql = string.Format("select UDI_VALUE from VW_LATEST_UDI_SEC_SAMPLES where SAMPLE_ID={0} ", sampleID); // UDI_SECTION_SAMPLE 
                    lastUDI = new OracleDatabaseClass().ExecuteScalarNullable(sql);
                }
            }
            else if (!string.IsNullOrEmpty(interID) && interID != "0")
            {
                //dt = new DistressSurvey().GetIntersectionLatestSurvey(int.Parse(interID));
                //if (dt.Rows.Count == 0)
                //    return null;
                //else if (int.Parse(dt.Rows[0]["SURVEY_NO"].ToString()) == 0)
                //    return null;
                //else
                //    lastSurveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());

                if (string.IsNullOrEmpty(sampleID) || sampleID == "0")
                {
                    // get intersection UDI
                    sql = string.Format("select UDI_VALUE from VW_LATEST_UDI_INTERSECTIONS where INTERSECTION_ID={0} ", interID); // UDI_INTERSECTION
                    lastUDI = new OracleDatabaseClass().ExecuteScalarNullable(sql);
                }
                else
                {
                    // get intersection sample UDI 
                    sql = string.Format("select UDI_VALUE from VW_LATEST_UDI_INTER_SAMPLES where INTER_SAMP_ID={0} ", sampleID); // UDI_INTERSECTION_SAMPLE
                    lastUDI = new OracleDatabaseClass().ExecuteScalarNullable(sql);
                }
            }
            else if (!string.IsNullOrEmpty(regionID) && !string.IsNullOrEmpty(secondID) && regionID != "0" && secondID != "0")
            {
                //dt = new DistressSurvey().GetRegionDistrictLatestSurveys(int.Parse(regionID), "", "", "", true, false, false, false);
                //if (dt.Rows.Count == 0)
                //    return null;
                //else if (int.Parse(dt.Rows[0]["SURVEY_NO"].ToString()) == 0)
                //    return null;
                //else
                //    lastSurveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());

                // get secondary street UDI
                sql = string.Format("select UDI_VALUE from VW_LATEST_UDI_SECONDARY where STREET_ID={0} ", secondID); // UDI_SECONDARY
                lastUDI = new OracleDatabaseClass().ExecuteScalarNullable(sql);
            }
            else
                return null;

            return lastUDI;
        }

        public static DataTable GetRoadNetworkItemUdi(string sectionID, string interID, string regionID, string secStID)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(sectionID) && sectionID != "0")
                sql = string.Format("select SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE from UDI_SECTION where section_id={0} ", sectionID);
            else if (!string.IsNullOrEmpty(interID) && interID != "0")
                sql = string.Format("select SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE from UDI_INTERSECTION where INTERSECTION_ID={0} ", interID);
            else if (!string.IsNullOrEmpty(regionID) && regionID != "0")
            {
                if (!string.IsNullOrEmpty(secStID) && secStID != "0")
                    sql = string.Format("select SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE from UDI_SECONDARY where STREET_ID={0} ", secStID);
                else
                    sql = string.Format("select SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE from UDI_REGION where REGION_ID={0} ", regionID);
            }

            return (string.IsNullOrEmpty(sql) ? new DataTable() : new OracleDatabaseClass().ExecuteQuery(sql));
        }

        public DataTable GetRoadNetworkItemUdiReport(bool section, bool intersect, bool regions, bool sectSampleWise, bool laneWise, bool sectionWise,
            bool intersectWise, bool interSampleWise, bool regionWise, bool secStWise, int streetID, int regionID)
        {
            string sql = "";
            if (section)
            {
                string wherePart = (streetID == 0) ? "" : string.Format(" where STREET_ID={0} ", streetID);

                if (sectSampleWise)
                    sql = string.Format("select ARNAME, SECTION_NO, SECTION_TITLE, SAMPLE_TITLE, SAMPLE_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from GV_SAMPLE_UDI {0} ", wherePart);
                else if (laneWise)
                    sql = string.Format("select ARNAME, SECTION_NO, SECTION_TITLE, LANE_TYPE, LANE_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from VW_LANE_UDI {0} ", wherePart);
                else if (sectionWise)
                    sql = string.Format("select ARNAME, SECTION_NO, SECTION_TITLE, SECTION_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from VW_SECTION_UDI {0} ", wherePart);
                else
                    return new DataTable();
            }
            else if (intersect)
            {
                string wherePart = (streetID == 0) ? "" : string.Format(" where STREET_ID={0} ", streetID);

                if (interSampleWise)
                    sql = string.Format("select ARNAME, INTERSECT_TITLE, INTER_SAMP_NO, INTERSEC_SAMP_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from GV_INTERS_SMPL_UDI {0} ", wherePart);
                else if (intersectWise)
                    sql = string.Format("select ARNAME, INTERSECT_TITLE, INTERSECTION_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from VW_INTERSECT_UDI {0} ", wherePart);
                else
                    return new DataTable();
            }
            else if (regions)
            {
                string wherePart = (regionID == 0) ? "" : string.Format(" where REGION_ID={0} ", regionID);

                if (regionWise)
                    sql = string.Format("select REGION_NO, SUBDISTRICT, REGION_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from UDI_REGIONS_SUM {0} ", wherePart);
                else if (secStWise)
                    sql = string.Format("select REGION_NO, SUBDISTRICT, SECOND_ST_NO, SECOND_ARNAME, notes, SECONDARY_AREA, SURVEY_NO, SURVEY_DATE, UDI_DATE, UDI_RATE, UDI_VALUE from GV_SEC_ST_UDI {0} ", wherePart);
                else
                    return new DataTable();
            }
            else
                return new DataTable();

            return (string.IsNullOrEmpty(sql) ? new DataTable() : new OracleDatabaseClass().ExecuteQuery(sql));
        }



        public static void StartShapeFileAutoCreationProgram()
        {
            if (ConfigurationManager.AppSettings["AutoShapeFileCeation"] == "1")
            {
                Process p = new Process();
                p.StartInfo.FileName = @"C:\Program Files\Gulf Engineering House\Shape File Exporting App\ShapeFileExportingApp.exe";
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.UseShellExecute = false;
                p.EnableRaisingEvents = true;

                p.Start();
            }
        }

    }


    public class UdiRecord
    {
        public decimal udiValue;
        public string udiRate;

        public UdiRecord()
        {
            udiValue = -1;
            udiRate = "";
        }

        public UdiRecord(decimal value, string rate)
        {
            udiValue = value;
            udiRate = rate;
        }
    }

    public class PavementStatusReport
    {
        public double MainStSectionsTotal;
        public double MainStIntersectsTotal;
        public double MainStTotal;
        public double RegionsTotal;
        public double WholeNetworkTotal;

        public double MainStTotalExcellent;
        public double MainStTotalFair;
        public double MainStTotalGood;
        public double MainStTotalPoor;

        public double RegionsTotalExcellent;
        public double RegionsTotalFair;
        public double RegionsTotalGood;
        public double RegionsTotalPoor;


        public PavementStatusReport(double p1, double p2, double p3)
        {
            MainStSectionsTotal = p1;
            MainStIntersectsTotal = p2;
            RegionsTotal = p3;
            WholeNetworkTotal = p1 + p2 + p3;
        }

        public PavementStatusReport(double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8, double p9, double p10, double p11,
            double p12, double p13)
        {
            MainStSectionsTotal = p1;
            MainStIntersectsTotal = p2;
            MainStTotal = p3;
            RegionsTotal = p4;
            WholeNetworkTotal = p3 + p4;

            MainStTotalExcellent = p6;
            MainStTotalFair = p7;
            MainStTotalGood = p8;
            MainStTotalPoor = p9;

            RegionsTotalExcellent = p10;
            RegionsTotalFair = p11;
            RegionsTotalGood = p12;
            RegionsTotalPoor = p13;
        }

        public PavementStatusReport()
        {
            MainStSectionsTotal = 0;
            MainStIntersectsTotal = 0;
            MainStTotal = 0;
            RegionsTotal = 0;
            WholeNetworkTotal = 0;

            MainStTotalExcellent = 0;
            MainStTotalFair = 0;
            MainStTotalGood = 0;
            MainStTotalPoor = 0;

            RegionsTotalExcellent = 0;
            RegionsTotalFair = 0;
            RegionsTotalGood = 0;
            RegionsTotalPoor = 0;
        }
    }   

}
