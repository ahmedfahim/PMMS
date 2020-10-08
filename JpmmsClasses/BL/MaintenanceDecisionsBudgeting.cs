using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JpmmsClasses.BL.Lookups;
using JpmmsClasses.BL.UDI;

namespace JpmmsClasses.BL
{
    public class MaintenanceDecisionsBudgeting
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private DistressSurvey survey = new DistressSurvey();
        private MaintDecision maintD = new MaintDecision();





        public DataTable GetMainStreetSectionsMaintenanceBudget(double? budget, int mainStID, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            if (budget == null)
                return new DataTable();

            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMainStreetReport(mainStID, udiDesc, udiAsc, priority);
            return PrepareSectionsMaintenanceBudget(budget, dt, areasOnly);
        }

        public DataTable GetMunicSectionsMaintenanceBudget(double? budget, string municName, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            if (budget == null)
                return new DataTable();

            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMunicSectionReport(municName, udiDesc, udiAsc, priority);
            return PrepareSectionsMaintenanceBudget(budget, dt, areasOnly);
        }


        public DataTable GetMainStreetIntersectionsMaintenanceBudget(double? budget, int mainStID, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            if (budget == null)
                return new DataTable();

            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMainStreetIntersectReport(mainStID, udiDesc, udiAsc, priority);
            return PrepareIntersectionsMaintenanceBudget(budget, dt, areasOnly);
        }

        public DataTable GetMunicIntersectsMaintenanceBudget(double? budget, string municName, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            if (budget == null)
                return new DataTable();

            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMainStreetIntersectReport(municName, udiDesc, udiAsc, priority);
            return PrepareIntersectionsMaintenanceBudget(budget, dt, areasOnly);
        }



        private DataTable PrepareSectionsMaintenanceBudget(double? budget, DataTable dt, bool areasOnly)
        {
            DataTable dtBudget = new DataTable();
            double amount = 0;
            double maxAmount = ((double)budget) + 1000;
            double[] MaintAreas = new double[10];
            double[] MaintCost = new double[10];

            if (areasOnly)
            {
                dtBudget.Columns.Add(new DataColumn("RECOMMENDED_DECISION", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_AREA", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MAINT_COST", typeof(double)));

                foreach (DataRow dr in dt.Rows)
                {
                    amount += double.Parse(dr["MAINT_COST"].ToString());
                    if (amount > maxAmount)
                        break;
                    else
                    {
                        MaintAreas[int.Parse(dr["RECOMMENDED_DECISION_ID"].ToString())] += double.Parse(dr["MAINT_AREA"].ToString());
                        MaintCost[int.Parse(dr["RECOMMENDED_DECISION_ID"].ToString())] += double.Parse(dr["MAINT_COST"].ToString());
                    }
                }

                for (int i = 2; i <= 9; i++)
                {
                    if (MaintAreas[i] != 0 && MaintCost[i] != 0)
                        dtBudget.Rows.Add(maintD.GetByID(i).Rows[0]["RECOMMENDED_DECISION"].ToString(), MaintAreas[i], MaintCost[i]);
                }
            }
            else
            {
                dtBudget.Columns.Add(new DataColumn("RECORD_ID", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("MAIN_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAIN_NAME", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SECTION_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAIN_STREET_ID", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("IRI", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI_DATE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SURVEY_NO", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("LANE_ID", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("LANE_TYPE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SAMPLE_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("RECOMMENDED_DECISION", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_AREA", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("SURVEY_DATE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SECTION_TITLE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_COST", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI_ENHANCED", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("CF", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("LAND_USE_FACTOR", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MCEF", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("TRAFFIC_WEIGHT", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("MAINT_PRIO", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("FWD", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("GPR", typeof(double)));


                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    amount += double.Parse(dr["MAINT_COST"].ToString());
                    if (amount > maxAmount)
                        break;
                    else
                    {
                        // TODO: add values to recently added priority columns
                        // MAIN_STREET_ID
                        dtBudget.Rows.Add(i, dr["MAIN_NO"].ToString(), dr["MAIN_NAME"].ToString(), dr["SECTION_NO"].ToString(), dr["STREET_ID"].ToString(),
                            (dr["IRI"] == DBNull.Value ? null : dr["IRI"].ToString()), dr["UDI"].ToString(), dr["UDI_DATE"].ToString(), dr["SURVEY_NO"].ToString(),
                            dr["LANE_ID"].ToString(), dr["LANE_TYPE"].ToString(), (dr["SAMPLE_NO"] == DBNull.Value ? null : dr["SAMPLE_NO"].ToString()),
                            dr["RECOMMENDED_DECISION"].ToString(), dr["MAINT_AREA"].ToString(), dr["SURVEY_DATE"].ToString(), dr["SECTION_TITLE"].ToString(),
                            dr["MAINT_COST"].ToString(), dr["UDI_ENHANCED"].ToString(), dr["CF"].ToString(), dr["LAND_USE_FACTOR"].ToString(), dr["MCEF"].ToString(),
                            dr["TRAFFIC_WEIGHT"].ToString(), dr["MAINT_PRIO"].ToString(), (dr["FWD"] == DBNull.Value ? null : dr["FWD"].ToString()),
                            (dr["GPR"] == DBNull.Value ? null : dr["GPR"].ToString()));
                    }

                    i += 1;
                }
            }

            return dtBudget;
        }

        private DataTable PrepareIntersectionsMaintenanceBudget(double? budget, DataTable dt, bool areasOnly)
        {
            double amount = 0;
            double maxAmount = ((double)budget) + 1000;
            double[] MaintAreas = new double[10];
            double[] MaintCost = new double[10];

            DataTable dtBudget = new DataTable();
            if (areasOnly)
            {
                dtBudget.Columns.Add(new DataColumn("RECOMMENDED_DECISION", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_AREA", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MAINT_COST", typeof(double)));

                foreach (DataRow dr in dt.Rows)
                {
                    amount += double.Parse(dr["MAINT_COST"].ToString());
                    if (amount > maxAmount)
                        break;
                    else
                    {
                        MaintAreas[int.Parse(dr["RECOMMENDED_DECISION_ID"].ToString())] += double.Parse(dr["MAINT_AREA"].ToString());
                        MaintCost[int.Parse(dr["RECOMMENDED_DECISION_ID"].ToString())] += double.Parse(dr["MAINT_COST"].ToString());
                    }
                }


                for (int i = 2; i <= 9; i++)
                {
                    if (MaintAreas[i] != 0 && MaintCost[i] != 0)
                        dtBudget.Rows.Add(maintD.GetByID(i).Rows[0]["RECOMMENDED_DECISION"].ToString(), MaintAreas[i], MaintCost[i]);
                }
            }
            else
            {
                dtBudget.Columns.Add(new DataColumn("RECORD_ID", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("MAIN_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAIN_NAME", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("INTER_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAIN_STREET_ID", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("INTER_SAMP_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("IRI", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI_DATE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SURVEY_NO", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("MAINT_DECISION", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_AREA", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("SURVEY_DATE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("INTERSECT_TITLE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_COST", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI_ENHANCED", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("CF", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("LAND_USE_FACTOR", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MCEF", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MAINT_PRIO", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("GPR", typeof(double)));

                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    amount += double.Parse(dr["MAINT_COST"].ToString());
                    if (amount > maxAmount)
                        break;
                    else
                    {
                        // int.Parse(dr["RECORD_ID"].ToString()),
                        dtBudget.Rows.Add(i, dr["MAIN_NO"].ToString(), dr["MAIN_NAME"].ToString(), dr["INTER_NO"].ToString(), dr["STREET_ID"].ToString(),
                            (dr["INTER_SAMP_NO"] == DBNull.Value ? null : dr["INTER_SAMP_NO"].ToString()), (dr["IRI"] == DBNull.Value ? null : dr["IRI"].ToString()),
                            dr["UDI"].ToString(), dr["UDI_DATE"].ToString(), dr["SURVEY_NO"].ToString(), dr["MAINT_DECISION"].ToString(), dr["MAINT_AREA"].ToString(),
                            dr["SURVEY_DATE"].ToString(), dr["INTERSECT_TITLE"].ToString(), dr["MAINT_COST"].ToString(), dr["UDI_ENHANCED"].ToString(), dr["CF"].ToString(),
                            dr["LAND_USE_FACTOR"].ToString(), dr["MCEF"].ToString(), dr["MAINT_PRIO"].ToString(), (dr["GPR"] == DBNull.Value ? null : dr["GPR"].ToString()));
                    }

                    i += 1;
                }
            }

            return dtBudget;
        }

        private DataTable PrepareSecondaryStreetsRegionsMaintenceBudget(double? budget, DataTable dt, bool areasOnly)
        {
            if (budget == null)
                return new DataTable();

            double amount = 0;
            double maxAmount = ((double)budget) + 1000;
            double[] MaintAreas = new double[10];
            double[] MaintCost = new double[10];

            DataTable dtBudget = new DataTable();
            if (areasOnly)
            {
                dtBudget.Columns.Add(new DataColumn("RECOMMENDED_DECISION", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_AREA", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MAINT_COST", typeof(double)));

                foreach (DataRow dr in dt.Rows)
                {
                    amount += double.Parse(dr["MAINT_COST"].ToString());
                    if (amount > maxAmount)
                        break;
                    else
                    {
                        MaintAreas[int.Parse(dr["RECOMMENDED_DECISION_ID"].ToString())] += double.Parse(dr["MAINT_AREA"].ToString());
                        MaintCost[int.Parse(dr["RECOMMENDED_DECISION_ID"].ToString())] += double.Parse(dr["MAINT_COST"].ToString());
                    }
                }

                for (int i = 2; i <= 9; i++)
                {
                    if (MaintAreas[i] != 0 && MaintCost[i] != 0)
                        dtBudget.Rows.Add(maintD.GetByID(i).Rows[0]["RECOMMENDED_DECISION"].ToString(), MaintAreas[i], MaintCost[i]);
                }
            }
            else
            {
                dtBudget.Columns.Add(new DataColumn("RECORD_ID", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("REGION_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SECOND_ST_NO", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SECOND_ID", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("UDI", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI_DATE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SURVEY_NO", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("SURVEY_DATE", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("RECOMMENDED_DECISION", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_AREA", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("SECOND_AR_NAME", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("SUBDISTRICT", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MUNIC_NAME", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("DIST_NAME", typeof(string)));
                dtBudget.Columns.Add(new DataColumn("MAINT_COST", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("UDI_ENHANCED", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("CF", typeof(int)));
                dtBudget.Columns.Add(new DataColumn("LAND_USE_FACTOR", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MCEF", typeof(double)));
                dtBudget.Columns.Add(new DataColumn("MAINT_PRIO", typeof(double)));

                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    amount += double.Parse(dr["MAINT_COST"].ToString());
                    if (amount > maxAmount)
                        break;
                    else
                    {
                        // SECOND_ID
                        dtBudget.Rows.Add(i, dr["REGION_NO"].ToString(), dr["SECOND_NO"].ToString(), dr["STREET_ID"].ToString(), dr["UDI"].ToString(), dr["UDI_DATE"].ToString(),
                            dr["SURVEY_NO"].ToString(), dr["SURVEY_DATE"].ToString(), dr["RECOMMENDED_DECISION"].ToString(), dr["MAINT_AREA"].ToString(), dr["SECOND_AR_NAME"].ToString(),
                            dr["SUBDISTRICT"].ToString(), dr["MUNIC_NAME"].ToString(), dr["DIST_NAME"].ToString(), dr["MAINT_COST"].ToString(), dr["UDI_ENHANCED"].ToString(),
                            dr["CF"].ToString(), dr["LAND_USE_FACTOR"].ToString(), dr["MCEF"].ToString(), dr["MAINT_PRIO"].ToString());
                    }

                    i += 1;
                }
            }

            return dtBudget;
        }



        public DataTable GetRegionMaintenanceBudget(double? budget, int regionID, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            //  int surveyNum,  surveyNum, 
            //DataTable dt;
            //if (surveyNum == 0)
            //{
            //    dt = survey.GetLastSurveyForRoadsNetwork(regionID, "", "", "", true, false, false, false, 0, false, false);
            //    if (dt.Rows.Count == 0)
            //        return new DataTable();

            //    surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            //}

            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(regionID.ToString(), udiDesc, udiAsc, priority, RegionReportLevel.Region);
            return PrepareSecondaryStreetsRegionsMaintenceBudget(budget, dt, areasOnly);
        }

        public DataTable GetSubdistrictMaintenanceBudget(double? budget, string subdistrict, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            // int surveyNum,  surveyNum, 
            //DataTable dt;
            //if (surveyNum == 0)
            //{
            //    dt = survey.GetLastSurveyForRoadsNetwork(0, subdistrict, "", "", false, true, false, false, 0, false, false);
            //    if (dt.Rows.Count == 0)
            //        return new DataTable();

            //    surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            //}

            //DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionNameReport(subdistrict, udiDesc, udiAsc, priority);
            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(subdistrict, udiDesc, udiAsc, priority, RegionReportLevel.Subdistrict);
            return PrepareSecondaryStreetsRegionsMaintenceBudget(budget, dt, areasOnly);
        }

        public DataTable GetDistrictMaintenanceBudget(double? budget, string distName, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            //DataTable dt; int surveyNum,
            //if (surveyNum == 0)
            //{
            //    dt = survey.GetLastSurveyForRoadsNetwork(0, "", distName, "", false, false, true, false, 0, false, false);
            //    if (dt.Rows.Count == 0)
            //        return new DataTable();
            //    else
            //        surveyNum = int.Parse(dt.Rows[0]["SURVEY_NO"].ToString());
            //}

            //dt = new MaintenancePriorities().GetMaintenancePrioritiesForDistrictReport(distName, surveyNum, udiDesc, udiAsc, priority);
            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(distName, udiDesc, udiAsc, priority, RegionReportLevel.District);
            return PrepareSecondaryStreetsRegionsMaintenceBudget(budget, dt, areasOnly);
        }

        public DataTable GetMunicMaintenanceBudget(double? budget, string municName, bool udiDesc, bool udiAsc, bool priority, bool areasOnly)
        {
            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(municName, udiDesc, udiAsc, priority, RegionReportLevel.Municipality);
            return PrepareSecondaryStreetsRegionsMaintenceBudget(budget, dt, areasOnly);
        }


    }
}
