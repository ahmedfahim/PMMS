using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JpmmsClasses.BL;

namespace JpmmsClasses.BL.Lookups
{
    public class MaintPriorityWeights
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();


        public DataTable GetSettings()
        {
            string sql = "SELECT RECORD_ID, MAIN_ST_GOOD_WEIGHT, MAIN_ST_POOR_WEIGHT, SECOND_ST_GOOD_WEIGHT, SECOND_ST_POOR_WEIGHT, HOUSES_SECTIONS, COMMERIAL_SECTIONS, " + 
                " INDISTERIAL_SECTIONS, REST_HOUSE_SECTIONS, GARDENS_SECTIONS, PUBLICS_SECTIONS, HOUSES_REGIONS, COMMERIAL_REGIONS, INDISTERIAL_REGIONS, REST_HOUSE_REGIONS, " + 
                " GARDENS_REGIONS, PUBLICS_REGIONS, SCHOOL_REGIONS, MASJID_REGIONS, HOSPITAL_REGIONS, SPORT_CLUB_REGIONS, NEW_BUILDINGS_REGIONS, OTHER_UTIL_REGIONS, " + 
                " TRAFFIC_LOW_WEIGHT, TRAFFIC_MEDIUM_WEIGHT, TRAFFIC_HIGH_WEIGHT, TRAFFIC_VERY_HIGH_WEIGHT FROM MAINT_PRIO_WEIGHTS ";

            return db.ExecuteQuery(sql);
        }



        public bool Update(double? MAIN_ST_GOOD_WEIGHT, double? MAIN_ST_POOR_WEIGHT, double? SECOND_ST_GOOD_WEIGHT, double? SECOND_ST_POOR_WEIGHT,
            double? HOUSES_SECTIONS, double? COMMERIAL_SECTIONS, double? INDISTERIAL_SECTIONS, double? REST_HOUSE_SECTIONS, double? GARDENS_SECTIONS, double? PUBLICS_SECTIONS,
            double? HOUSES_REGIONS, double? COMMERIAL_REGIONS, double? INDISTERIAL_REGIONS, double? REST_HOUSE_REGIONS, double? GARDENS_REGIONS, double? PUBLICS_REGIONS,
            double? SCHOOL_REGIONS, double? MASJID_REGIONS, double? HOSPITAL_REGIONS, double? SPORT_CLUB_REGIONS, double? NEW_BUILDINGS_REGIONS, double? OTHER_UTIL_REGIONS,
            double? TRAFFIC_LOW_WEIGHT, double? TRAFFIC_MEDIUM_WEIGHT, double? TRAFFIC_HIGH_WEIGHT, double? TRAFFIC_VERY_HIGH_WEIGHT)
        {
            double sumSections = (double)HOUSES_SECTIONS + (double)COMMERIAL_SECTIONS + (double)INDISTERIAL_SECTIONS + (double)REST_HOUSE_SECTIONS + (double)GARDENS_SECTIONS
                + (double)PUBLICS_SECTIONS;

            double sumRegions = (double)HOUSES_REGIONS + (double)COMMERIAL_REGIONS + (double)INDISTERIAL_REGIONS + (double)REST_HOUSE_REGIONS + (double)GARDENS_REGIONS
                + (double)PUBLICS_REGIONS + (double)SCHOOL_REGIONS + (double)MASJID_REGIONS + (double)HOSPITAL_REGIONS + (double)SPORT_CLUB_REGIONS + (double)NEW_BUILDINGS_REGIONS
                + (double)OTHER_UTIL_REGIONS;


            if (sumSections != 100)
                throw new Exception("الرجاء ضبط معاملات أوزان النشاطات الجانبية للطرق الرئيسية بحيث يساوي مجموعها 100 ");
            else if (sumRegions != 100)
                throw new Exception("الرجاء ضبط معاملات أوزان النشاطات الجانبية للمناطق الفرعية بحيث يساوي مجموعها 100 ");


            string sql = "select * from MAINT_PRIO_WEIGHTS ";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count != 0)
            {
                sql = "delete from MAINT_PRIO_WEIGHTS ";
                db.ExecuteNonQuery(sql);
            }

            sql = string.Format("insert into MAINT_PRIO_WEIGHTS (RECORD_ID, MAIN_ST_GOOD_WEIGHT, MAIN_ST_POOR_WEIGHT, SECOND_ST_GOOD_WEIGHT, SECOND_ST_POOR_WEIGHT, HOUSES_SECTIONS, " +
                " COMMERIAL_SECTIONS, INDISTERIAL_SECTIONS, REST_HOUSE_SECTIONS, GARDENS_SECTIONS, PUBLICS_SECTIONS, HOUSES_REGIONS, COMMERIAL_REGIONS, INDISTERIAL_REGIONS, " +
                " REST_HOUSE_REGIONS, GARDENS_REGIONS, PUBLICS_REGIONS, SCHOOL_REGIONS, MASJID_REGIONS, HOSPITAL_REGIONS, SPORT_CLUB_REGIONS, NEW_BUILDINGS_REGIONS, " +
                " OTHER_UTIL_REGIONS, TRAFFIC_LOW_WEIGHT, TRAFFIC_MEDIUM_WEIGHT, TRAFFIC_HIGH_WEIGHT, TRAFFIC_VERY_HIGH_WEIGHT) " +
                " values(1, {0}, {1}, {2}, {3}, " +
                " {4}, {5}, {6},  {7}, {8}, {9}, " +
                " {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, " +
                " {19}, {20}, {21}, " +
                " {22},  {23}, {24}, {25}) ",
                MAIN_ST_GOOD_WEIGHT, MAIN_ST_POOR_WEIGHT, SECOND_ST_GOOD_WEIGHT, SECOND_ST_POOR_WEIGHT,
                HOUSES_SECTIONS, COMMERIAL_SECTIONS, INDISTERIAL_SECTIONS, REST_HOUSE_SECTIONS, GARDENS_SECTIONS, PUBLICS_SECTIONS,
                HOUSES_REGIONS, COMMERIAL_REGIONS, INDISTERIAL_REGIONS, REST_HOUSE_REGIONS, GARDENS_REGIONS, PUBLICS_REGIONS, SCHOOL_REGIONS, MASJID_REGIONS, HOSPITAL_REGIONS,
                SPORT_CLUB_REGIONS, NEW_BUILDINGS_REGIONS, OTHER_UTIL_REGIONS,
                TRAFFIC_LOW_WEIGHT, TRAFFIC_MEDIUM_WEIGHT, TRAFFIC_HIGH_WEIGHT, TRAFFIC_VERY_HIGH_WEIGHT);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

    }
}
