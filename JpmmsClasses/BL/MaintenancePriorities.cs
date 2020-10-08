using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using JpmmsClasses.BL.UDI;

namespace JpmmsClasses.BL
{
    public class MaintenancePriorities
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private DistressSurvey survey = new DistressSurvey();
        private Region region = new Region();
        private Municpiality munic = new Municpiality();




        private string GetOrderByPriorityPart(bool udiDesc, bool udiAsc, bool priority)
        {
            string orderByPart = "";
            if (udiAsc)
                orderByPart = " order by UDI, maint_prio desc ";
            else if (udiDesc)
                orderByPart = " order by UDI desc, maint_prio desc ";
            else if (priority)
                orderByPart = " order by MAINT_PRIO desc  ";
            else
                orderByPart = "";

            return orderByPart;
        }


        #region Search for Regions

        public DataTable GetMaintenancePrioritiesForRegionsReport(string unitNo, bool udiDesc, bool udiAsc, bool priority, RegionReportLevel level)
        {
            string wherePart = "";
            switch (level)
            {
                case RegionReportLevel.Region:
                    wherePart = (int.Parse(unitNo) == 0) ? "" : string.Format(" where REGION_ID={0} ", unitNo);
                    break;
                case RegionReportLevel.Subdistrict:
                    wherePart = (string.IsNullOrEmpty(unitNo) || unitNo == "0") ? "" : string.Format(" where SUBDISTRICT='{0}' ", unitNo);
                    break;
                case RegionReportLevel.District:
                    wherePart = (string.IsNullOrEmpty(unitNo) || unitNo == "0") ? "" : string.Format(" where DIST_NAME='{0}' ", unitNo);
                    break;
                case RegionReportLevel.Municipality:
                    wherePart = (string.IsNullOrEmpty(unitNo) || unitNo == "0") ? "" : string.Format(" where MUNIC_NAME='{0}' ", unitNo);
                    break;
                case RegionReportLevel.None:
                default:
                    return new DataTable();
            }


            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);
            string sql = string.Format("select * from VW_LATEST_PRIO_REGIONS   {0} {1}  ", wherePart, orderByPart);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMaintenancePrioritiesForRegionsReport(string unitNo, bool udiDesc, bool udiAsc, bool priority, RegionReportLevel level, DateTime? from, DateTime? to)
        {
            string wherePart = "";
            switch (level)
            {
                case RegionReportLevel.Region:
                    wherePart = (int.Parse(unitNo) == 0) ? "" : string.Format(" where REGION_ID={0} ", unitNo);
                    break;
                case RegionReportLevel.Subdistrict:
                    wherePart = (string.IsNullOrEmpty(unitNo) || unitNo == "0") ? "" : string.Format(" where SUBDISTRICT='{0}' ", unitNo);
                    break;
                case RegionReportLevel.District:
                    wherePart = (string.IsNullOrEmpty(unitNo) || unitNo == "0") ? "" : string.Format(" where DIST_NAME='{0}' ", unitNo);
                    break;
                case RegionReportLevel.Municipality:
                    wherePart = (string.IsNullOrEmpty(unitNo) || unitNo == "0") ? "" : string.Format(" where MUNIC_NAME='{0}' ", unitNo);
                    break;
                case RegionReportLevel.None:
                default:
                    return new DataTable();
            }

            if (from == null || to == null) //|| survey == 0)
                return new DataTable();
            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);
            string sql = string.Format("select * from VW_LATEST_PRIO_REGIONS   {0} and  SURVEY_DATE BETWEEN TO_DATE('{1}','DD/MM/YYYY') AND TO_DATE('{2}','DD/MM/YYYY') {3} ", wherePart, from.Value.ToString("dd/MM/yyyy"), to.Value.ToString("dd/MM/yyyy"), orderByPart);
            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Search for Sections

        public DataTable GetMaintenancePrioritiesForMainStreetReport(int mainStID, bool udiDesc, bool udiAsc, bool priority)
        {
            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);
            string mainStPart = (mainStID == 0) ? "" : string.Format(" and STREET_ID={0}  ", mainStID); // MAIN_STREET_ID
            string sql = string.Format("select * from VW_LATEST_PRIO_LANES where SECTION_ID is not null {0} {1} ", mainStPart, orderByPart);
            return db.ExecuteQuery(sql);
        }




        public DataTable GetMaintenancePrioritiesForSectionSurroundingRegionReport(int regionID, bool udiDesc, bool udiAsc, bool priority)
        {
            string regionNum = region.GetRegionNum(regionID);
            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);
            //string surveypart = string.Format("and SURVEY_NO=(select max(survey_no) from VW_MAINT_PRIO_LANES where section_no like '{0}%') ", regionNum);

            string sql = string.Format("select * from VW_LATEST_PRIO_LANES where SECTION_ID is not null and section_no like '{0}%' {1} ", regionNum, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenancePrioritiesForMunicSectionReport(string municName, bool udiDesc, bool udiAsc, bool priority)
        {
            string municNum = munic.GetMunicNo(municName);
            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);

            string sql = string.Format("select * from VW_LATEST_PRIO_LANES where section_no like '{0}%' {1} ", municNum, orderByPart);
            return db.ExecuteQuery(sql);
        }

        #endregion


        #region Search for Intersects

        public DataTable GetMaintenancePrioritiesForMainStreetIntersectReport(int mainStID, bool udiDesc, bool udiAsc, bool priority)
        {
            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);
            string mainStPart = (mainStID == 0) ? "" : string.Format(" and STREET_ID={0}  ", mainStID); // MAIN_STREET_ID
            string sql = string.Format("select * from VW_LATEST_PRIO_INTERSECTIONS where SURVEY_NO>2 and INTERSECTION_ID is not null {0} {1} ", mainStPart, orderByPart);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMaintenancePrioritiesForMainStreetIntersectReport(string municName, bool udiDesc, bool udiAsc, bool priority)
        {
            string orderByPart = GetOrderByPriorityPart(udiDesc, udiAsc, priority);
            string municNum = new Municpiality().GetMunicNo(municName);

            string sql = string.Format("select * from VW_LATEST_PRIO_INTERSECTIONS where SURVEY_NO>2 and inter_no like '{0}%' {1} ", municNum, orderByPart);
            return db.ExecuteQuery(sql);
        }

        #endregion

    }
}
