using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JpmmsClasses.BL.AhmedYousif;

namespace JpmmsClasses.BL.Lookups
{
    public class MaintDecision
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();

        public int MaintDecisionID;
        public int Thickness;
        public double MaintArea;
        public int AffectedSampleID;
        public double UDI;
        //public Dictionary<int, int> AffectedSamples;
        //public bool SampleWise;
        //public Dictionary<int, double> AffectedAreas;


        public MaintDecision()
        {
            MaintDecisionID = 0;
            Thickness = 0;
            MaintArea = 0;
            AffectedSampleID = 0;
            UDI = 0;
            //SampleWise = true;
        }

        public MaintDecision(int id, int thickness)
        {
            MaintDecisionID = id;
            Thickness = thickness;
            MaintArea = 0;
            AffectedSampleID = 0;
            UDI = 0;
            //SampleWise = true;
        }

        public MaintDecision(int id, int thickness, double area)
        {
            MaintDecisionID = id;
            Thickness = thickness;
            MaintArea = (id == 1) ? 0 : area;
            AffectedSampleID = 0;
            UDI = 0;
            //SampleWise = true;
        }

        public MaintDecision(int id, int thickness, double area, int iSampleID, int udi)
        {
            MaintDecisionID = id;
            Thickness = thickness;
            MaintArea = (id == 1) ? 0 : area;
            AffectedSampleID = iSampleID;
            UDI = udi;
            //SampleWise = true;
        }

        //public MaintDecision(int id, int thickness, double area, int iSampleID, int udi, bool sampleWise)
        //{
        //    MaintDecisionID = id;
        //    Thickness = thickness;
        //    MaintArea = (id == 1) ? 0 : area;
        //    AffectedSampleID = iSampleID;
        //    UDI = udi;
        //    SampleWise = sampleWise;
        //}



        public bool Insert(string RECOMMENDED_DECISION, int UNIT_ID, double? UNIT_PRICE, int? LIFECYCLE_AGE, double? THICKNESS, int UDI_ENHANCE)
        {
            RECOMMENDED_DECISION = RECOMMENDED_DECISION.Replace("'", "''");

            //                                                                                  0                   1           2           3               4
            string sql = string.Format("insert into MAINT_DECISIONS(RECOMMENDED_DECISION_ID, RECOMMENDED_DECISION, UNIT_ID, UNIT_PRICE, LIFECYCLE_AGE, THICKNESS) values(SEQ_MAINT_DEC.nextval, '{0}', {1}, {2}, {3}, {4}) ",
                RECOMMENDED_DECISION, UNIT_ID, UNIT_PRICE, LIFECYCLE_AGE, THICKNESS);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool Update(int UNIT_ID, double? UNIT_PRICE, int RECOMMENDED_DECISION_ID, int? LIFECYCLE_AGE, double? THICKNESS, int UDI_ENHANCE, string DECISION_TYPE) //, bool PREVENTIVE, bool STRUCTIVE)
        {
            // , PREVENTIVE={6}, STRUCTIVE={7} , Shared.Bool2Int(PREVENTIVE), Shared.Bool2Int(STRUCTIVE)
            string sql = string.Format("update MAINT_DECISIONS set UNIT_ID={0}, UNIT_PRICE={1}, LIFECYCLE_AGE={3}, THICKNESS={4}, UDI_ENHANCE={5} where RECOMMENDED_DECISION_ID={2} ",
                UNIT_ID, UNIT_PRICE, RECOMMENDED_DECISION_ID, LIFECYCLE_AGE, THICKNESS, UDI_ENHANCE);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public string GetAllDecisionsFWD_HAFRIAT()
        {
            //string sql = "select count(*)/3 from FWD_DATA where SURVEY_NO=3 and main_no is not null";
            string sql = "select sum(Points) from (SELECT SUM(FWD_COUNT) Points from JPMMS.EQUIPMENTMAINQC where IS_FWD=1 union SELECT sum(POINTS) Points from  jpmms.HAFRIAT_FWD)";
            return db.ExecuteScalar(sql).ToString();
        } 
        public string GetAllDecisionsIRI()
        {
            //string sql = "select  ROUND(sum(ROUND (LANE_LENGTH,2))/1000,2) from IRI_LANE where SURVEY_NO=3 and main_no is not null ";
            string sql = "SELECT ROUND(SUM(STREET_IRI_LEN),2) from JPMMS.EQUIPMENTMAINQC where IS_IRI=1 and CLEARANCE_IRI is not null";
            return db.ExecuteScalar(sql).ToString();
        }
        public string GetAllDecisionsDDF()
        {
            //string sql = "select  ROUND(sum(ROUND (LANE_LENGTH,2))/1000,2) from IRI_LANE where SURVEY_NO=3 and main_no is not null ";
            string sql = "SELECT ROUND(SUM(STREET_IRI_LEN),2) from JPMMS.EQUIPMENTMAINQC where IS_DDF=1 and CLEARANCE_DDF is not null";
            return db.ExecuteScalar(sql).ToString();
        }
        public string GetAllDecisionsInterSections()
        {
            //string sql = "select  ROUND(sum(ROUND (LANE_LENGTH,2))/1000,2) from IRI_LANE where SURVEY_NO=3 and main_no is not null ";
            string sql = "SELECT ROUND(SUM(INTERSECTIONS_DISTRESS_LEN),2) from JPMMS.EQUIPMENTMAINQC where IS_INTERSECTIONS=1 and CLEARANCE_INTERSECTIONS is not null";
            return db.ExecuteScalar(sql).ToString();
        } 
        public string GetAllDecisionsAssets()
        {
//            string sql = @"select ROUND(sum(ROUND (sdE.sT_length (SHAPE)/1000 *2, 3)),2) from STREETS where MAIN_NO in 
//                            (select distinct MAIN_NO  from ASSETS where MAIN_NO is not null and x  is not null and y is not null and SURVEY_MONTH is not null)";
            string sql = @"SELECT SUM(STREET_ASSETS_LEN) from JPMMS.EQUIPMENTMAINQC where IS_ASSETS=1";
            return db.ExecuteScalar(sql).ToString();
        }
        public string GetAllSURVEYORS_REGIONS()
        {
            string sql = @"SELECT SUM(REGION_AREA)+'14399017.70' FROM jpmms.SURVEYORS_REGIONs_distinct";
            return db.ExecuteScalar(sql).ToString();
        }
        public string GetAllDecisionsSKID()
        {
            string sql = "SELECT ROUND(SUM(nvl(STREET_IRI_LEN,STREET_SHAPE_LEN)),2)  from JPMMS.EQUIPMENTMAINQC where IS_SKID=1 ";
            return db.ExecuteScalar(sql).ToString();
        }
        public string GetAllDecisionsGPR_HAFRIAT()
        {
            string sql = @"select sum(LENKM) from (SELECT ROUND(SUM(nvl(STREET_IRI_LEN,STREET_SHAPE_LEN)),2) LENKM from JPMMS.EQUIPMENTMAINQC where IS_GPR =1 union SELECT ROUND(sum(LENKM)/1000,2) LENKM from  jpmms.HAFRIAT_GPR) ";
            return db.ExecuteScalar(sql).ToString();
        }
         public DataTable GetAllDecisions()
        {
            string sql = "select RECOMMENDED_DECISION_ID, RECOMMENDED_DECISION, RECOMMENDED_DECISION_AR, (RECOMMENDED_DECISION_ID || '- '||RECOMMENDED_DECISION) as decision_title, nvl(UNIT_ID, 0) as unit_id, unit_name, UNIT_PRICE, LIFECYCLE_AGE, THICKNESS, UDI_ENHANCE, PREVENTIVE, STRUCTIVE, DECISION_TYPE from VW_MAINT_DECISION order by RECOMMENDED_DECISION_ID ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllDecisionsNonDoNothing()
        {
            string sql = "select RECOMMENDED_DECISION_ID, RECOMMENDED_DECISION, RECOMMENDED_DECISION_AR, (RECOMMENDED_DECISION_ID || '- '||RECOMMENDED_DECISION) as decision_title, nvl(UNIT_ID, 0) as unit_id, unit_name, UNIT_PRICE, LIFECYCLE_AGE, THICKNESS, UDI_ENHANCE, PREVENTIVE, STRUCTIVE, DECISION_TYPE from VW_MAINT_DECISION where RECOMMENDED_DECISION_ID not in (0, 1) order by RECOMMENDED_DECISION_ID ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByID(int RECOMMENDED_DECISION_ID)
        {
            if (RECOMMENDED_DECISION_ID == 0)
                return new DataTable();

            string sql = string.Format("select RECOMMENDED_DECISION_ID, RECOMMENDED_DECISION, RECOMMENDED_DECISION_AR, nvl(UNIT_ID, 0) as unit_id, UNIT_PRICE, unit_name, LIFECYCLE_AGE, THICKNESS, UDI_ENHANCE, PREVENTIVE, STRUCTIVE, DECISION_TYPE from VW_MAINT_DECISION where RECOMMENDED_DECISION_ID={0} ", RECOMMENDED_DECISION_ID);
            return db.ExecuteQuery(sql);
        }


        public int? GetMaintDecisionNewUDI(int mainDecID, string udiBefore)
        {
            int newUDI = 0;
            int beforeUDI = 0;
            DataTable dt = new MaintDecision().GetByID(mainDecID);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (bool.Parse(dr["STRUCTIVE"].ToString()))
                {
                    newUDI = int.Parse(dr["UDI_ENHANCE"].ToString());
                    if (Shared.IsNumeric(udiBefore))
                    {
                        beforeUDI = int.Parse(udiBefore);
                        newUDI = (newUDI >= beforeUDI) ? newUDI : beforeUDI;
                    }
                }
                else
                {
                    // preventive maintenance decisions
                    if (Shared.IsNumeric(udiBefore))
                    {
                        beforeUDI = int.Parse(udiBefore);
                        newUDI = int.Parse(udiBefore) + int.Parse(dr["UDI_ENHANCE"].ToString());
                        newUDI = (newUDI >= 100) ? 100 : newUDI;
                        newUDI = (newUDI >= beforeUDI) ? newUDI : beforeUDI;
                    }
                    else
                        newUDI = int.Parse(dr["UDI_ENHANCE"].ToString());
                }

                return newUDI;
            }
            else
                return null;
        }


        #region Maintenance Decisions Limits

        public DataTable GetMaintDecisionsLimits()
        {
            string sql = "select * from MAINT_DEC_PARAMETERS where rownum<2 ";
            return db.ExecuteQuery(sql);
        }


        public bool UpdateMaintDecisionParameters(double? IRI_LIMIT_S, double? FWD_LIMIT_S, double? FWD_LIMIT_MED_S, double? GPR_LIMIT_S, double? UDI_LIMIT_S,
            double? SKID_LIMIT_S, double? UDI_LIMIT_SM, double? IRI_LIMIT_I, double? GPR_LIMIT_I, double? UDI_LIMIT_I, double? SKID_LIMIT_I, double? UDI_LIMIT_R,
            double? UDI_LIMIT_SEC_ST, double? UDI_LIMIT_IS)
        {
            string sql = "select count(*) from MAINT_DEC_PARAMETERS ";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count >= 1)
                sql = string.Format("update MAINT_DEC_PARAMETERS set IRI_LIMIT_S={0}, FWD_LIMIT_S={1}, FWD_LIMIT_MED_S={2}, GPR_LIMIT_S={3}, UDI_LIMIT_S={4}, SKID_LIMIT_S={5}, " +
                    " UDI_LIMIT_SM={6}, IRI_LIMIT_I={7}, GPR_LIMIT_I={8}, UDI_LIMIT_I={9}, SKID_LIMIT_I={10}, UDI_LIMIT_R={11}, UDI_LIMIT_SEC_ST={12}, UDI_LIMIT_IS={13} ",
                    IRI_LIMIT_S, FWD_LIMIT_S, FWD_LIMIT_MED_S, GPR_LIMIT_S, UDI_LIMIT_S, SKID_LIMIT_S,
                    UDI_LIMIT_SM, IRI_LIMIT_I, GPR_LIMIT_I, UDI_LIMIT_I, SKID_LIMIT_I, UDI_LIMIT_R, UDI_LIMIT_SEC_ST, UDI_LIMIT_IS);
            else
                //                                                          0           1           2               3           4               5              6            7           8           9           10              11              12          13          14      
                sql = string.Format("insert into MAINT_DEC_PARAMETERS(IRI_LIMIT_S, FWD_LIMIT_S, FWD_LIMIT_MED_S, GPR_LIMIT_S, UDI_LIMIT_S, SKID_LIMIT_S, UDI_LIMIT_SM, IRI_LIMIT_I, GPR_LIMIT_I, UDI_LIMIT_I, SKID_LIMIT_I, UDI_LIMIT_R, UDI_LIMIT_SEC_ST, UDI_LIMIT_IS) " +
                    "values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}) ",
                   IRI_LIMIT_S, FWD_LIMIT_S, FWD_LIMIT_MED_S, GPR_LIMIT_S, UDI_LIMIT_S, SKID_LIMIT_S,
                    UDI_LIMIT_SM, IRI_LIMIT_I, GPR_LIMIT_I, UDI_LIMIT_I, SKID_LIMIT_I, UDI_LIMIT_R, UDI_LIMIT_SEC_ST);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        #endregion

    }

}
