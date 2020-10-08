using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using JpmmsClasses.BL.Lookups;
using System.Linq;

namespace JpmmsClasses.BL.AhmedYousif
{

    public struct MAINT_DECISION
    {
        public int MAINT_ID;
        public string MAINT_NAME;
        public double UNIT_COST;
    }


    public class C_Maint_Decision
    {
        private static int UDI_LIMIT_SM = 70;
        private static int UDI_LIMIT_S = 70;
        private static int IRI_LIMIT_S = 4;
        private static int FWD_LIMIT_S = 700;
        private static int FWD_LIMIT_MED_S = 500;
        private static int GPR_LIMIT_S = 15;
        private static int SKID_LIMIT_S = 35;

        private static int UDI_LIMIT_I = 70;
        private static int UDI_LIMIT_IS = 70;
        private static int IRI_LIMIT_I = 4;
        private static int GPR_LIMIT_I = 15;
        private static int SKID_LIMIT_I = 35;

        private static int UDI_LIMIT_R = 70;
        private static int UDI_LIMIT_SEC_ST = 70;



        private C_GET_Data m_C_Get_Data = new C_GET_Data();
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private MaintDeciding deciding = new MaintDeciding();


        private enum MaintenanceDecisions
        {
            DoNothing = 1,
            SurfacePatching = 2,
            CrackSealing = 3,
            DeepPatching = 4,
            ThinOverlay = 5,
            Mill_Repave_5cm = 6,
            Mill_Repave_10cm = 7,
            Mill_Repave_UpTo_15cm = 8,
            Reconstruction_Asph15cm_Base20cm = 9
        }


        public C_Maint_Decision()
        {
            //
            // TODO: Add constructor logic here
            //
            DataTable dt = new MaintDecision().GetMaintDecisionsLimits();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                UDI_LIMIT_SM = int.Parse(dr["UDI_LIMIT_SM"].ToString());
                UDI_LIMIT_S = int.Parse(dr["UDI_LIMIT_S"].ToString());
                IRI_LIMIT_S = int.Parse(dr["IRI_LIMIT_S"].ToString());
                FWD_LIMIT_S = int.Parse(dr["FWD_LIMIT_S"].ToString());
                FWD_LIMIT_MED_S = int.Parse(dr["FWD_LIMIT_MED_S"].ToString());
                GPR_LIMIT_S = int.Parse(dr["GPR_LIMIT_S"].ToString());
                SKID_LIMIT_S = int.Parse(dr["SKID_LIMIT_S"].ToString());

                UDI_LIMIT_I = int.Parse(dr["UDI_LIMIT_I"].ToString());
                IRI_LIMIT_I = int.Parse(dr["IRI_LIMIT_I"].ToString());
                GPR_LIMIT_I = int.Parse(dr["GPR_LIMIT_I"].ToString());
                SKID_LIMIT_I = int.Parse(dr["SKID_LIMIT_I"].ToString());

                UDI_LIMIT_IS = int.Parse(dr["UDI_LIMIT_IS"].ToString());

                UDI_LIMIT_R = int.Parse(dr["UDI_LIMIT_R"].ToString());
                UDI_LIMIT_SEC_ST = int.Parse(dr["UDI_LIMIT_SEC_ST"].ToString());
            }
        }


        #region Removing Previously Taken Maintenance Decisions


        public bool RemoveSectionsPreviousMaintDecisions(int m_MAIN_ST_ID, int surveyNum)
        {
            try
            {
                string SQL = string.Format("delete from MAINTENANCE_DECISIONS where SECTION_ID in (select section_id from sections where STREET_ID={0}) and SURVEY_NO={1} ", m_MAIN_ST_ID, surveyNum);
                Shared.LogMdStatment(SQL); // MAIN_STREET_ID
                int res = db.ExecuteNonQuery(SQL);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveIntersectionsPreviousMaintDecisions(int m_MAIN_ST_ID, int surveyNum)
        {
            string SQL = string.Format("delete from MAINTENANCE_DECISIONS where INTERSECTION_ID in (select INTERSECTION_ID from INTERSECTIONS where STREET_ID={0}) and SURVEY_NO={1}  ", m_MAIN_ST_ID, surveyNum);
            Shared.LogMdStatment(SQL);
            int res = db.ExecuteNonQuery(SQL);

            return (res > 0);
        }

        public bool RemoveRegionsPreviousMaintDecisions(int region_id, int surveyNum)
        {
            string SQL = string.Format("delete from MAINTENANCE_DECISIONS where REGION_ID={0} and SURVEY_NO={1}  ", region_id, surveyNum);
            Shared.LogMdStatment(SQL);
            int res = db.ExecuteNonQuery(SQL);

            return (res > 0);
        }

        #endregion


        #region Section Maintenance Decisions

        public bool CalculateMD_4_StreetLanes(int m_MAIN_ST_ID, int SRV_ID)
        {
            int rows = 0;
            int mdID = 0;
            double laneArea = 0;
            double iri, fwd, gpr;


            string section_no, lane_type;
            string iri_value = "", fwd_value = "", gpr_value = "";

            string sql = string.Format("select SECTION_ID, SECTION_NO, LANE_TYPE, LANE_AREA, SURVEY_NO, UDI_VALUE, MAIN_ST_ID, LANE_ID, " +
                " to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, to_char(UDI_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as UDI_DATE " +
                " from UDI_LANES where STREET_ID={0} and SURVEY_NO={1}    order by SECTION_NO, LANE_TYPE ", m_MAIN_ST_ID, SRV_ID); // MAIN_ST_ID

            Shared.LogMdStatment(sql);
            DataTable dtLanesUDI = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtLanesUDI.Rows)
            {
                iri = 0;
                fwd = 0;
                gpr = 0;
                iri_value = "";
                fwd_value = "";
                gpr_value = "";

                section_no = dr["SECTION_NO"].ToString();
                lane_type = dr["LANE_TYPE"].ToString();

                laneArea = double.Parse(dr["LANE_AREA"].ToString());

                fwd = m_C_Get_Data.GET_LANE_FWD(dr["SECTION_NO"].ToString());  //int.Parse(dr["LANE_ID"].ToString())); , dr["LANE_TYPE"].ToString()
                fwd_value = (fwd == -1) ? "NULL" : fwd.ToString("0.00");

                gpr = m_C_Get_Data.GET_LANE_GPR(dr["SECTION_NO"].ToString());
                gpr_value = (gpr == -1) ? "NULL" : gpr.ToString("0.00");

                iri = m_C_Get_Data.GET_LANE_IRI(section_no, lane_type);
                iri_value = (iri == -1) ? "NULL" : iri.ToString("0.00");

                #region FWD

                if (fwd != -1 && fwd >= FWD_LIMIT_S)
                {
                    mdID = (int)MaintenanceDecisions.Reconstruction_Asph15cm_Base20cm;

                    //                                                                              0             1           2           3           4           5                                          6                 7     8    9     10        11
                    sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, USING_FWD, STREET_ID, THICKNESS, UDI, IRI, FWD, SECTION_ID, GPR) " +
                        " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 0, 1, {6}, " +
                        " (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}, {10}, {11}) ",
                        mdID, dr["LANE_ID"].ToString(), laneArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                        dr["UDI_VALUE"].ToString(), iri_value, fwd_value, dr["SECTION_ID"].ToString(), gpr_value);

                    Shared.LogMdStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                }
                else if (fwd != -1 && fwd >= FWD_LIMIT_MED_S)
                {
                    #region GPR

                    if (gpr != -1 && gpr <= GPR_LIMIT_S) // gpr <= 15
                    {
                        mdID = (int)MaintenanceDecisions.Mill_Repave_UpTo_15cm;

                        // iri.ToString("0.00")
                        //                                                                              0             1           2           3           4           5                                                     6           7     8     9    10   11      12  
                        sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, USING_FWD, USING_GPR, STREET_ID, THICKNESS, UDI, IRI, FWD, GPR, SECTION_ID) " +
                            " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 0, 1, 1, {6}, " +
                            " {7}, {8}, {9}, {10}, {11}, {12}) ",
                            mdID, dr["LANE_ID"].ToString(), laneArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                            gpr_value, dr["UDI_VALUE"].ToString(), iri_value, fwd_value, gpr_value, dr["SECTION_ID"].ToString());

                        Shared.LogStatment(sql);
                        rows += db.ExecuteNonQuery(sql);
                    }
                    else if (gpr != -1 && gpr > GPR_LIMIT_S) // gpr > 15
                    {
                        mdID = (int)MaintenanceDecisions.Mill_Repave_10cm;

                        //                                                                              0             1           2           3           4           5                                                     6                 7     8    9   10        11  
                        sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, USING_FWD, USING_GPR, STREET_ID, THICKNESS, UDI, IRI, FWD, GPR, SECTION_ID) " +
                            " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 0, 1, 1, {6}, " +
                            " (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}, {10}, {11}) ",
                            mdID, dr["LANE_ID"].ToString(), laneArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                            dr["UDI_VALUE"].ToString(), iri_value, fwd_value, gpr_value, dr["SECTION_ID"].ToString());

                        Shared.LogStatment(sql);
                        rows += db.ExecuteNonQuery(sql);
                    }
                    else // gpr value does not exists, prepare per samples level
                        rows += GetMaintenanceDecisionsPerSample(dr, SRV_ID, laneArea, m_MAIN_ST_ID, iri_value, fwd_value, gpr_value);
                    //continue;

                    #endregion
                }
                else if ((fwd != -1 && fwd < FWD_LIMIT_MED_S) || fwd == -1)
                {
                    //mdID = (int)MaintenanceDecisions.Mill_Repave_5cm;

                    ////                                                                              0             1           2           3           4           5                                          6                 7     8    9       10      11
                    //sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, USING_FWD, STREET_ID, THICKNESS, UDI, IRI, FWD, SECTION_ID, GPR) " +
                    //    " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 0, 1, {6}, " +
                    //    " (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}, {10}, {11}) ",
                    //    mdID, dr["LANE_ID"].ToString(), laneArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                    //    dr["UDI_VALUE"].ToString(), iri_value, fwd_value, dr["SECTION_ID"].ToString(), gpr_value);

                    //Shared.LogMdStatment(sql);
                    //rows += db.ExecuteNonQuery(sql);

                    #region IRI

                    //(dr[""].ToString(), dr[""].ToString());  //int.Parse(dr["LANE_ID"].ToString()));
                    //if (iri == -1)
                    //    continue; else
                    if ((iri != -1 && iri > IRI_LIMIT_S) || // IRI >4
                        (iri != -1 && iri <= IRI_LIMIT_S && double.Parse(dr["UDI_VALUE"].ToString()) < UDI_LIMIT_S) ||
                        (iri == -1 && double.Parse(dr["UDI_VALUE"].ToString()) < UDI_LIMIT_S)) // IRI<=4 && udi<70
                    {
                        // IRI>4:  mill and repace for the whole lane
                        mdID = (int)MaintenanceDecisions.Mill_Repave_5cm;

                        //                                                                              0              1         2           3           4           5                               6                 7     8      9         10   11
                        sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, STREET_ID, THICKNESS, UDI, IRI, SECTION_ID, GPR, FWD) " +
                            " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 1, {6}, " +
                            " (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}, {10}, {11}) ",
                            mdID, dr["LANE_ID"].ToString(), laneArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                            dr["UDI_VALUE"].ToString(), iri_value, dr["SECTION_ID"].ToString(), gpr_value, fwd_value);

                        Shared.LogMdStatment(sql);
                        rows += db.ExecuteNonQuery(sql);
                    }
                    else if ((iri != -1 && iri <= IRI_LIMIT_S && double.Parse(dr["UDI_VALUE"].ToString()) >= UDI_LIMIT_S)
                        || (iri == -1 && double.Parse(dr["UDI_VALUE"].ToString()) >= UDI_LIMIT_S))
                        rows += GetMaintenanceDecisionsPerSample(dr, SRV_ID, laneArea, m_MAIN_ST_ID, iri_value, fwd_value, gpr_value);

                    #endregion
                }
                //else //  fwd=-1
                //{

                //}

                #endregion

            }

            return (rows > 0);
        }


        #region perSample

        private int GetMaintenanceDecisionsPerSample(DataRow laneInfoDr, int surveyNum, double laneArea, int m_MAIN_ST_ID, string iri_value,
            string fwd_value, string gpr_value)
        {
            int rows = 0;
            double sampleArea = 0;
            string filter = "";

            DataTable dtSmpDist;
            MaintDecision maintD;

            DataTable dtSampMds = new DataTable();
            dtSampMds.Columns.Add(new DataColumn("sample_id", typeof(int)));
            dtSampMds.Columns.Add(new DataColumn("maint_no", typeof(int)));
            dtSampMds.Columns.Add(new DataColumn("udi", typeof(int)));
            dtSampMds.Columns.Add(new DataColumn("maint_area", typeof(double)));


            Double[] laneMaintArea = new Double[10];
            for (int i = 1; i <= 9; i++)
                laneMaintArea[i] = 0;


            //bool doNothing = true;
            string sql = string.Format("select SECTION_ID, SECTION_NO, LANE_TYPE, SAMPLE_NO, SAMPLE_AREA, SURVEY_NO, UDI_VALUE, STREET_ID, LANE_ID, SAMPLE_ID, " +
              " to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, to_char(UDI_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as UDI_DATE " +
              " from UDI_SECTION_SAMPLE where LANE_ID={0} and SURVEY_NO={1} order by SECTION_NO, LANE_TYPE, SAMPLE_NO  ", laneInfoDr["LANE_ID"].ToString(), surveyNum);

            Shared.LogMdStatment(sql);
            DataTable dtSmpUDI = db.ExecuteQuery(sql);
            foreach (DataRow drSmpUDI in dtSmpUDI.Rows)
            {
                //doNothing = true;
                sampleArea = double.Parse(drSmpUDI["SAMPLE_AREA"].ToString());

                if (double.Parse(drSmpUDI["UDI_VALUE"].ToString()) < UDI_LIMIT_SM)
                {
                    // sample UDI < 70: mill and repave the whole sample
                    int mdNum = (int)MaintenanceDecisions.Mill_Repave_5cm;
                    laneMaintArea[mdNum] += sampleArea;

                    dtSampMds.Rows.Add(int.Parse(drSmpUDI["SAMPLE_ID"].ToString()), mdNum, int.Parse(drSmpUDI["UDI_VALUE"].ToString()), sampleArea);
                }
                else
                {
                    // sample UDI >= 70: check maintenance decisions for sample distresses
                    sql = string.Format("select DIST_CODE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY from V_LANE_SAMPLE_DECISIONS where SAMPLE_ID={0} and SURVEY_NO={1} ",
                       drSmpUDI["SAMPLE_ID"].ToString(), surveyNum);

                    Shared.LogMdStatment(sql);
                    dtSmpDist = db.ExecuteQuery(sql);
                    foreach (DataRow drDist in dtSmpDist.Rows)
                    {
                        maintD = deciding.GetMaintDecision(int.Parse(drDist["DIST_CODE"].ToString()), drDist["DIST_SEVERITY"].ToString()[0],
                            double.Parse(drDist["DIST_DENSITY"].ToString()), double.Parse(drDist["DIST_AREA"].ToString()));

                        if (maintD.MaintDecisionID != 0 && maintD.MaintArea >= (sampleArea / 2))
                        {
                            // distress maintenanceArea is greater than half of sample area
                            laneMaintArea[maintD.MaintDecisionID] += sampleArea;

                            filter = string.Format("sample_id={0} and maint_no={1} ", int.Parse(drSmpUDI["SAMPLE_ID"].ToString()), maintD.MaintDecisionID);
                            DataRow[] dr = dtSampMds.Select(filter);
                            if (dr.Length != 0)
                                dr[0]["maint_area"] = sampleArea;
                            else
                                dtSampMds.Rows.Add(int.Parse(drSmpUDI["SAMPLE_ID"].ToString()), maintD.MaintDecisionID, int.Parse(drSmpUDI["UDI_VALUE"].ToString()), sampleArea);
                        }
                        else
                        {
                            // distress maintenanceArea is less than or equal to half of sample area
                            laneMaintArea[maintD.MaintDecisionID] += maintD.MaintArea;

                            filter = string.Format("sample_id={0} and maint_no={1} ", int.Parse(drSmpUDI["SAMPLE_ID"].ToString()), maintD.MaintDecisionID);
                            DataRow[] dr = dtSampMds.Select(filter);
                            if (dr.Length != 0)
                                dr[0]["maint_area"] = double.Parse(dr[0]["maint_area"].ToString()) + maintD.MaintArea;
                            else
                                dtSampMds.Rows.Add(int.Parse(drSmpUDI["SAMPLE_ID"].ToString()), maintD.MaintDecisionID, int.Parse(drSmpUDI["UDI_VALUE"].ToString()),
                                    maintD.MaintArea);
                        }
                    }
                }
            }

            string sectionNum = laneInfoDr["SECTION_NO"].ToString();
            string laneType = laneInfoDr["LANE_TYPE"].ToString();

            // check maintenance Area laneWise            
            for (int i = 9; i >= 1; i--)
            {
                if (i != 1 && laneMaintArea[i] > (laneArea / 2))
                {
                    // save maintenanceDecision for the whole lane
                    sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, STREET_ID, THICKNESS, UDI, SECTION_ID, IRI, FWD, GPR) " +
                         " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, " +
                         " {6}, (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}, {10}, {11}) ",
                         i, laneInfoDr["LANE_ID"].ToString(), laneArea.ToString("0.00"), laneInfoDr["SURVEY_DATE"].ToString(), laneInfoDr["UDI_DATE"].ToString(), surveyNum,
                         m_MAIN_ST_ID, laneInfoDr["UDI_VALUE"].ToString(), laneInfoDr["SECTION_ID"].ToString(), iri_value, fwd_value, gpr_value);

                    Shared.LogMdStatment(sql);
                    rows += db.ExecuteNonQuery(sql);

                    if (i >= 6) //&& i <= 9)
                        break;
                    else
                    {
                        filter = "maint_no=1 ";
                        foreach (DataRow dr in dtSampMds.Select(filter))
                            dtSampMds.Rows.Remove(dr);
                    }

                }
                else
                {
                    // if not maintenance decision of the same type of i, continue and no need to save it
                    filter = string.Format("maint_no={0} ", i);
                    DataRow[] dr = dtSampMds.Select(filter);
                    if (dr.Length == 0)
                        continue;

                    // finally, save maintenance decision into DB
                    foreach (DataRow dd in dr)
                    {
                        sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, STREET_ID, THICKNESS, UDI, SECTION_ID, SAMPLE_ID, IRI, FWD, GPR) " +
                        " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), " +
                        " {5}, 1, {6}, (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}, {10},  {11}, {12}) ", // MAIN_ST_ID
                        i, laneInfoDr["LANE_ID"].ToString(), dd["maint_area"].ToString(), laneInfoDr["SURVEY_DATE"].ToString(), laneInfoDr["UDI_DATE"].ToString(),
                        surveyNum, m_MAIN_ST_ID, dd["udi"].ToString(), laneInfoDr["SECTION_ID"].ToString(), dd["sample_id"].ToString(), iri_value, fwd_value, gpr_value);

                        Shared.LogMdStatment(sql);
                        rows += db.ExecuteNonQuery(sql);
                    }
                }
            }

            return rows;
        }

        #endregion


        #endregion


        #region Intersection Maintenance Decisions

        public bool CalculateMaintenanceDecisionForStreetIntersections(int m_MAIN_ST_ID, int SRV_ID)
        {
            int rows = 0;
            int mdID = 0;
            double intersectArea = 0;
            double sampleArea = 0;
            //double sumMaintDArea = 0;
            //double sampleMaintArea = 0;
            double deepPatchingDistsArea = 0;
            double iri;
            string iri_value = "";

            MaintDecision maintD;
            MaintDecision[] intersectMaintD;
            MaintDecision[,] sampleMaintD;
            DataTable dtSmpDist, dtSmpUDI;
            double[] sampleMaintArea;

            // MAIN_ST_ID
            string sql = string.Format("select STREET_ID, INTERSECTION_ID, INTER_NO, INTERSECTION_AREA, UDI_VALUE, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " to_char(UDI_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as UDI_DATE, SURVEY_NO from UDI_INTERSECTION where STREET_ID={0} and SURVEY_NO={1} ",
                    m_MAIN_ST_ID, SRV_ID);

            Shared.LogMdStatment(sql);
            DataTable dtIntersectUDI = db.ExecuteQuery(sql);
            foreach (DataRow dr in dtIntersectUDI.Rows)
            {
                iri = 0;
                iri = m_C_Get_Data.GET_INTERSECTION_IRI(dr["INTER_NO"].ToString());
                iri_value = (iri == -1) ? "NULL" : iri.ToString("0.00");

                //
                //for (int i = 1; i <= 9; i++)
                //{
                //    intersectMaintD[i] = new MaintDecision();
                //    intersectMaintD[i].AffectedSamples = new Dictionary<int, int>();
                //}


                intersectArea = double.Parse(dr["INTERSECTION_AREA"].ToString());
                if (double.Parse(dr["UDI_VALUE"].ToString()) >= UDI_LIMIT_I) // udi>=70
                {
                    #region IRI

                    //if (iri == -1)
                    //    continue;  else 
                    if (iri != -1 && iri > IRI_LIMIT_I)
                    {
                        // IRI>4:  mill and repace for the whole intersection
                        mdID = (int)MaintenanceDecisions.Mill_Repave_5cm;

                        //                                                                              0                   1         2           3           4           5                               6                     7     8
                        sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, INTERSECTION_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, STREET_ID, THICKNESS, UDI, IRI) " +
                            " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 1, {6}, " +
                            " (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}) ",
                            mdID, dr["INTERSECTION_ID"].ToString(), intersectArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                            dr["UDI_VALUE"].ToString(), iri_value);

                        Shared.LogMdStatment(sql);
                        rows += db.ExecuteNonQuery(sql);
                    }
                    else if ((iri != -1 && iri <= IRI_LIMIT_I) || iri == -1)
                    {
                        #region perSample

                        intersectMaintD = new MaintDecision[10];
                        for (int i = 1; i <= 9; i++)
                        {
                            intersectMaintD[i] = new MaintDecision();
                            //intersectMaintD[i].AffectedSamples = new Dictionary<int, int>();
                        }


                        sql = string.Format("select STREET_ID, INTER_ID, INTER_NO, INTER_SAMP_ID, INTER_SAMP_NO, INTER_SAMP_AREA, UDI_VALUE, UDI_DATE, SURVEY_DATE, SURVEY_NO " +
                            " from UDI_INTERSECTION_SAMPLE where INTER_ID={0} and SURVEY_NO={1} ", dr["INTERSECTION_ID"].ToString(), SRV_ID);

                        Shared.LogMdStatment(sql);
                        dtSmpUDI = db.ExecuteQuery(sql);
                        sampleMaintD = new MaintDecision[10, dtSmpUDI.Rows.Count];
                        for (int i = 1; i <= 9; i++)
                            for (int j = 0; j < dtSmpUDI.Rows.Count; j++)
                                sampleMaintD[i, j] = new MaintDecision();


                        int c = 0;
                        sampleMaintArea = new Double[dtSmpUDI.Rows.Count];

                        foreach (DataRow drSmpUDI in dtSmpUDI.Rows)
                        {
                            //sampleMaintArea = 0;
                            deepPatchingDistsArea = 0;
                            sampleArea = double.Parse(drSmpUDI["INTER_SAMP_AREA"].ToString());

                            if (double.Parse(drSmpUDI["UDI_VALUE"].ToString()) < UDI_LIMIT_IS)
                            {
                                // sample UDI < 70: mill and repave the whole sample
                                sampleMaintArea[c] = sampleArea;

                                mdID = (int)MaintenanceDecisions.Mill_Repave_5cm;
                                intersectMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm].MaintArea += sampleArea;

                                sampleMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm, c].MaintArea = sampleArea;
                                sampleMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm, c].UDI = int.Parse(drSmpUDI["UDI_VALUE"].ToString());
                                sampleMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm, c].AffectedSampleID = int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString());
                            }
                            else
                            {
                                // sample UDI >= 70: check maintenance decisions for sample distresses
                                sql = string.Format("select DIST_CODE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY from V_INTERSECT_SAMPLE_DECISIONS " +
                                    " where INTER_SAMP_ID={0} and SURVEY_NO={1} ", drSmpUDI["INTER_SAMP_ID"].ToString(), SRV_ID);

                                Shared.LogMdStatment(sql);
                                dtSmpDist = db.ExecuteQuery(sql);
                                foreach (DataRow drDist in dtSmpDist.Rows)
                                {
                                    maintD = deciding.GetMaintDecision(int.Parse(drDist["DIST_CODE"].ToString()), drDist["DIST_SEVERITY"].ToString()[0],
                                        double.Parse(drDist["DIST_DENSITY"].ToString()), double.Parse(drDist["DIST_AREA"].ToString()));

                                    if (maintD.MaintDecisionID != 0 && maintD.MaintArea < (sampleArea / 2))
                                    {
                                        sampleMaintArea[c] += maintD.MaintArea;
                                        intersectMaintD[maintD.MaintDecisionID].MaintArea += maintD.MaintArea;

                                        sampleMaintD[maintD.MaintDecisionID, c].MaintArea += maintD.MaintArea;
                                        sampleMaintD[maintD.MaintDecisionID, c].UDI = int.Parse(drSmpUDI["UDI_VALUE"].ToString());
                                        sampleMaintD[maintD.MaintDecisionID, c].AffectedSampleID = int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString());

                                        //intersectMaintD[maintD.MaintDecisionID].MaintArea += maintD.MaintArea;
                                        //intersectMaintD[maintD.MaintDecisionID].AffectedSamples.Remove(int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString()));
                                        //intersectMaintD[maintD.MaintDecisionID].AffectedSamples.Add(int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString()), int.Parse(drSmpUDI["UDI_VALUE"].ToString()));

                                        //if (maintD.MaintDecisionID != 1)
                                        //    intersectMaintD[(int)MaintenanceDecisions.DoNothing].AffectedSamples.Remove(int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString()));
                                    }
                                    else
                                    {
                                        // remove all previously decisions taken on sample and take "Deep Patching" and "Mill-repave" decisions
                                        for (int i = 1; i <= 9; i++)
                                        {
                                            sampleMaintD[i, c].AffectedSampleID = 0;
                                            sampleMaintD[i, c].MaintArea = 0;
                                            sampleMaintD[i, c].UDI = int.Parse(drSmpUDI["UDI_VALUE"].ToString());
                                        }


                                        sampleMaintArea[c] += sampleArea;

                                        sql = string.Format("select nvl(sum(DIST_AREA), 0) as sum_dist_area from V_INTERSECT_SAMPLE_DECISIONS where INTER_SAMP_ID= {0} and survey_no={1} " +
                                           " and ((dist_code in (6, 7, 8, 13) and DIST_SEVERITY='H') or (dist_code=1 and DIST_SEVERITY='M'))  ",
                                           drSmpUDI["INTER_SAMP_ID"].ToString(), SRV_ID);

                                        Shared.LogMdStatment(sql);
                                        deepPatchingDistsArea = double.Parse(db.ExecuteScalar(sql).ToString());

                                        intersectMaintD[(int)MaintenanceDecisions.DeepPatching].MaintArea += deepPatchingDistsArea;
                                        intersectMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm].MaintArea += sampleArea;


                                        sampleMaintD[(int)MaintenanceDecisions.DeepPatching, c].MaintArea = deepPatchingDistsArea;
                                        sampleMaintD[(int)MaintenanceDecisions.DeepPatching, c].UDI = int.Parse(drSmpUDI["UDI_VALUE"].ToString());
                                        sampleMaintD[(int)MaintenanceDecisions.DeepPatching, c].AffectedSampleID = int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString());

                                        sampleMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm, c].MaintArea = sampleArea;
                                        sampleMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm, c].UDI = int.Parse(drSmpUDI["UDI_VALUE"].ToString());
                                        sampleMaintD[(int)MaintenanceDecisions.Mill_Repave_5cm, c].AffectedSampleID = int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString());

                                        break;
                                    }
                                }
                            }


                            if (sampleMaintArea[c] == 0)
                            {
                                sampleMaintD[(int)MaintenanceDecisions.DoNothing, c].AffectedSampleID = int.Parse(drSmpUDI["INTER_SAMP_ID"].ToString());
                                sampleMaintD[(int)MaintenanceDecisions.DoNothing, c].UDI = int.Parse(drSmpUDI["UDI_VALUE"].ToString());
                                sampleMaintD[(int)MaintenanceDecisions.DoNothing, c].MaintArea = 0;
                            }
                            else
                                sampleMaintD[(int)MaintenanceDecisions.DoNothing, c].AffectedSampleID = 0;

                            c += 1;
                        }

                        // check maintenance area not exceeding 50% of intersection area
                        for (int md = 1; md <= 9; md++)
                        {
                            if (intersectMaintD[md].MaintArea > intersectArea / 2)
                            {
                                intersectMaintD[md].MaintArea = intersectArea;
                                for (c = 0; c < dtSmpUDI.Rows.Count; c++)
                                {
                                    sampleMaintD[(int)MaintenanceDecisions.DoNothing, c].AffectedSampleID = 0;
                                    sampleMaintD[md, c].AffectedSampleID = int.Parse(dtSmpUDI.Rows[c]["INTER_SAMP_ID"].ToString());
                                    sampleMaintD[md, c].UDI = int.Parse(dtSmpUDI.Rows[c]["UDI_VALUE"].ToString());
                                    sampleMaintD[md, c].MaintArea = double.Parse(dtSmpUDI.Rows[c]["INTER_SAMP_AREA"].ToString());
                                }

                                //foreach (DataRow drSample in dtSmpUDI.Rows)
                                //{
                                //    intersectMaintD[i].AffectedSamples.Remove(int.Parse(drSample["INTER_SAMP_ID"].ToString()));
                                //    intersectMaintD[i].AffectedSamples.Add(int.Parse(drSample["INTER_SAMP_ID"].ToString()), int.Parse(drSample["UDI_VALUE"].ToString()));
                                //}
                            }


                            // save lane maintenance decision to DB
                            if ((md != 1 && intersectMaintD[md].MaintArea == 0))
                                continue;
                            else
                            {
                                for (c = 0; c < dtSmpUDI.Rows.Count; c++)
                                {
                                    if (sampleMaintD[md, c].AffectedSampleID != 0)
                                    {
                                        //                                                                              0                   1         2           3           4           5                                 6                     7       8        9
                                        sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, INTERSECTION_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, STREET_ID, THICKNESS, UDI, INT_SMP_ID, IRI) " +
                                            " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), " +
                                            " {5}, 1, 1, {6}, (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}, {9}) ",
                                            md, dr["INTERSECTION_ID"].ToString(), sampleMaintD[md, c].MaintArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(),
                                            SRV_ID, m_MAIN_ST_ID, sampleMaintD[md, c].UDI, sampleMaintD[md, c].AffectedSampleID, iri_value);

                                        Shared.LogMdStatment(sql);
                                        rows += db.ExecuteNonQuery(sql);
                                    }
                                    else
                                        continue;
                                }
                            }
                        }

                        #endregion
                    }

                    #endregion
                }
                else  // udi <70
                {
                    mdID = (int)MaintenanceDecisions.Mill_Repave_5cm;

                    //                                                                              0              1                2           3           4           5                               6                   7    8
                    sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, INTERSECTION_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, USING_IRI, STREET_ID, THICKNESS, UDI, IRI) " +
                        " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, 1, 1, {6}, " +
                        " (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}, {8}) ",
                        mdID, dr["INTERSECTION_ID"].ToString(), intersectArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), SRV_ID, m_MAIN_ST_ID,
                        dr["UDI_VALUE"].ToString(), iri_value);

                    Shared.LogMdStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                }
            }

            return (rows > 0);
        }

        #endregion


        #region Secondary Street Regions Maintenance Decisions

        public bool CalculateMaintenanceDecisionsForSecondaryStreet(int regionID, int surveyNum)
        {
            int rows = 0;
            int mdID = 0;
            double secondStArea = 0;
            double sumMaintDArea = 0;
            Double[] sampleMaintD;

            DataTable dtSmpDist;
            MaintDecision maintD;

            string sql = string.Format("select REGION_NO, SECONDARY_NO, SECONDARY_AREA, SURVEY_NO, to_char(SURVEY_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as SURVEY_DATE, " +
                    " to_char(UDI_DATE,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as UDI_DATE, UDI_VALUE, REGION_ID, STREET_ID from UDI_SECONDARY where REGION_ID={0} and SURVEY_NO={1} ",
                    regionID, surveyNum);

            Shared.LogMdStatment(sql);
            DataTable dt = db.ExecuteQuery(sql);
            foreach (DataRow dr in dt.Rows)
            {
                sumMaintDArea = 0;
                secondStArea = double.Parse(dr["SECONDARY_AREA"].ToString());
                sampleMaintD = new Double[10];
                for (int i = 1; i <= 9; i++)
                    sampleMaintD[i] = 0;

                if (int.Parse(dr["UDI_VALUE"].ToString()) >= UDI_LIMIT_SEC_ST) // udi>=70
                {
                    // SECOND_ID
                    sql = string.Format("select DIST_CODE, DIST_SEVERITY, DIST_AREA, DIST_DENSITY from V_SEC_STREET_DECISIONS where STREET_ID={0} and SURVEY_NO={1} ", dr["STREET_ID"].ToString(), surveyNum);
                    Shared.LogMdStatment(sql);
                    dtSmpDist = db.ExecuteQuery(sql);
                    foreach (DataRow drDist in dtSmpDist.Rows)
                    {
                        maintD = deciding.GetMaintDecision(int.Parse(drDist["DIST_CODE"].ToString()), drDist["DIST_SEVERITY"].ToString()[0],
                            double.Parse(drDist["DIST_DENSITY"].ToString()), double.Parse(drDist["DIST_AREA"].ToString()));

                        sumMaintDArea += maintD.MaintArea;
                        if (maintD.MaintDecisionID != 0)
                            sampleMaintD[maintD.MaintDecisionID] += maintD.MaintArea;
                    }

                    //foreach (KeyValuePair<int, double> i in sampleMaintD)
                    for (int i = 1; i <= 9; i++)
                    {
                        if (sampleMaintD[i] > secondStArea / 2)
                            sampleMaintD[i] = secondStArea;

                        if ((i == 1 && sumMaintDArea > 0) || (i != 1 && sampleMaintD[i] == 0))    //j.Key != 1 && j.Value == 0) //intersectMaintD.Remove(j.Key);
                            continue;
                        else
                        {
                            //                                                                              0             1               2           3           4           5                 6                 7
                            sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, REGION_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, STREET_ID, THICKNESS, UDI) " +
                                " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, " +
                                " 1, {6}, (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}) ",
                                i, dr["REGION_ID"].ToString(), sampleMaintD[i].ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), dr["SURVEY_NO"].ToString(),
                                dr["STREET_ID"].ToString(), dr["UDI_VALUE"].ToString());

                            Shared.LogMdStatment(sql);
                            rows += db.ExecuteNonQuery(sql);
                        }
                    }
                }
                else
                {
                    // mill and repace for the whole intersection
                    mdID = (int)MaintenanceDecisions.Mill_Repave_5cm;

                    //                                                                              0             1               2           3           4           5                 6                  7  
                    sql = string.Format("Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, REGION_ID, MAINT_AREA, SURVEY_DATE, UDI_DATE, SURVEY_NO, USING_UDI, STREET_ID, THICKNESS, UDI) " +
                        " Values(SEQ_MAINTENANCE_DECISION.nextval, {0}, {1}, {2}, To_date('{3}', 'DD/MM/YYYY'), To_date('{4}', 'DD/MM/YYYY'), {5}, " +
                        " 1, {6}, (select THICKNESS from MAINT_DECISIONS where RECOMMENDED_DECISION_ID={0}), {7}) ",
                        mdID, dr["REGION_ID"].ToString(), secondStArea.ToString("0.00"), dr["SURVEY_DATE"].ToString(), dr["UDI_DATE"].ToString(), dr["SURVEY_NO"].ToString(),
                        dr["STREET_ID"].ToString(), dr["UDI_VALUE"].ToString());

                    Shared.LogMdStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                }
            }

            return (rows > 0);
        }

        #endregion


    }
}
