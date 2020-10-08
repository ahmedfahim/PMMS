using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;

namespace JpmmsClasses.BL.Tests
{
    public class JpmmsCharting
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetSectionsRatingChart(int mainStID)
        {
            if (mainStID == 0)
                return new DataTable();

            // MAIN_ST_ID, main_no , order by MAIN_ST_ID
            //string sql = string.Format("SELECT UDI_RATE, count(UDI_RATE) as udi_rate_count FROM UDI_SECTION WHERE (MAIN_ST_ID ={0}) group by UDI_RATE  ", mainStID);
            //string sql = string.Format("SELECT r.u_rating, (select count(section_no) from udi_section s where MAIN_ST_ID={0} and s.udi_rate = r.u_rating) as udi_rate_count from udi_ratings r ", mainStID);

            string sql = string.Format("SELECT r.u_rating, ((select count(section_no) from udi_section s where STREET_ID={0} and s.udi_rate = r.u_rating)+" +
                " (select count(INTER_NO) from UDI_INTERSECTION s where STREET_ID={0} and s.udi_rate = r.u_rating)) as udi_rate_count from udi_ratings r order by u_rating ",
                mainStID);

            return db.ExecuteQuery(sql); // MAIN_ST_ID
        }


        public DataTable GetRegionsRatingChart(int regionID)
        {
            if (regionID == 0)
                return new DataTable();

            string sql = string.Format("SELECT r.u_rating, (select count(SECONDARY_NO) from UDI_SECONDARY s where REGION_ID={0} and s.udi_rate = r.u_rating) as udi_rate_count " +
                " from udi_ratings r order by u_rating ", regionID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetAvailableSurveys(bool mainST, int mainStID, int regionID)
        {
            if (mainST)
                return new DistressSurvey().GetMainStreetAvailableSurveys(mainStID);
            else
                return new DistressSurvey().GetRegionDistrictAvailableSurveys(regionID, "", "", "", true, false, false, false, false);
        }



        public double GetDailyDataEntryTotalArea(DateTime? dtpDate)
        {
            if (dtpDate == null)
                return 0;

            //string sql = string.Format("select (select nvl(sum(sample_length*sample_width), 0) from lane_samples where sample_id in (select distinct sample_id from distress where entry_date>='{0}' and entry_date<'{1}' and sample_id is not null))" +
            //   "+ (select nvl(sum(intersec_samp_area), 0) from intersection_samples where inter_samp_id in (select distinct inter_samp_id from distress where entry_date>='{0}' and entry_date<'{1}' and inter_samp_id is not null)) " +
            //   "+(select nvl(sum(second_st_length*second_st_width), 0) from secondary_streets where second_id in  (select distinct second_id from distress where entry_date>='{0}' and entry_date<'{1}' and second_id is not null)) " +
            //   " as total_entred_areas_distress from dual", ((DateTime)dtpDate).ToString("dd/MM/yyyy"), ((DateTime)dtpDate).AddDays(1).ToString("dd/MM/yyyy"));

            string sql = string.Format("SELECT   (SELECT NVL (SUM (sample_length * sample_width), 0) FROM lane_samples " +
           " WHERE sample_id IN ( SELECT DISTINCT sample_id FROM distress WHERE entry_date >= to_date('{0}', 'DD/MM/YYYY') AND entry_date < to_date('{1}', 'DD/MM/YYYY') AND sample_id IS NOT NULL)) + " +
           " (SELECT NVL (SUM (intersec_samp_area), 0) FROM intersection_samples " +
           " WHERE inter_samp_id IN (SELECT DISTINCT inter_samp_id FROM distress WHERE entry_date >= to_date('{0}', 'DD/MM/YYYY') AND entry_date <to_date('{1}', 'DD/MM/YYYY') AND inter_samp_id IS NOT NULL)) + " +
           " (SELECT NVL (SUM (second_st_length * second_st_width), 0) FROM streets " + // secondary_streets   second_id
           " WHERE STREET_ID IN (SELECT DISTINCT STREET_ID FROM distress WHERE entry_date >= to_date('{0}', 'DD/MM/YYYY') AND entry_date < to_date('{1}', 'DD/MM/YYYY') AND region_no IS NOT NULL))" +
           " AS total_entred_areas_distress FROM DUAL ", ((DateTime)dtpDate).ToString("dd/MM/yyyy"), ((DateTime)dtpDate).AddDays(1).ToString("dd/MM/yyyy"));

            return double.Parse(db.ExecuteScalar(sql).ToString());
        }

        public PavementStatusReport GetWholeNetworkArea()
        {
            //string sql = "select ((select sum(SAMPLE_AREA) from GV_SEC_STREET) +(select sum(INTERSEC_SAMP_AREA) from GV_INTERSECTION_SAMPLES) + " +
            //    " (select sum(AREA) from GV_SAMPLES)) as total_network_area from dual ";
            string sql = "select sum(nvl(AREA, 0)) as sum_area from GV_SAMPLES ";
            double samplesTotal = double.Parse(db.ExecuteScalar(sql).ToString());

            sql = "select sum(nvl(INTERSEC_SAMP_AREA, 0)) as sum_area from GV_INTERSECTION_SAMPLES ";
            double intersectTotal = double.Parse(db.ExecuteScalar(sql).ToString());

            sql = "select round(sum(nvl(SAMPLE_AREA, 0)), 2) as sum_area from GV_SEC_STREET ";
            double regionsTotal = double.Parse(db.ExecuteScalar(sql).ToString());

            return new PavementStatusReport(samplesTotal, intersectTotal, regionsTotal);
        }

    }
}
