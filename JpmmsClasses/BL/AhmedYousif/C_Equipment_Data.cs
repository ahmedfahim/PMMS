using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using JpmmsClasses.BL.Lookups;

namespace JpmmsClasses.BL.AhmedYousif
{
    public class C_GET_Data
    {
        //string SQL = "";
        //DataSet ds;
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private MaintDeciding deciding = new MaintDeciding();



        public double GET_INTERSECTION_AREA(int INT_ID)
        {
            //double AREA = -1;
            string SQL = string.Format("Select sum(INTERSEC_SAMP_AREA) as AREA from GV_INTERSECTION_SAMPLES where INTERSECTION_ID={0} ", INT_ID);
            Shared.LogMdStatment(SQL);
            DataTable dt = db.ExecuteQuery(SQL);

            return ((dt.Rows.Count > 0) ? double.Parse(dt.Rows[0][0].ToString()) : 0);
        }

        public double GetSampleArea(int sampleID)
        {
            DataTable dt = new LaneSample().GetLaneSampleDetails(sampleID);
            return ((dt.Rows.Count > 0) ? double.Parse(dt.Rows[0]["area"].ToString()) : 0);
        }


        private MaintDecision GetDistressDecision(double DistressArea, double Sample_Area, int Defect_Code, string Severity)
        {
            //int MD_ID = 0;
            double density = (DistressArea / Sample_Area) * 100; //Calcultae Percentage of Distress
            //MD_ID = deciding.GetMaintDecision(Defect_Code, Severity[0], density);
            return deciding.GetMaintDecision(Defect_Code, Severity[0], density, DistressArea); //MD_ID;
        }


        public double GET_LANE_IRI(string sectionNo, string laneType)
        {
            double iri = -1;

            //string SQL = string.Format("Select round(nvl(avg(IRI), -1), 2) as IRI from IRI_LANE where section_no='{0}' and LANE='{1}' ", sectionNo, laneType);
            string SQL = string.Format("Select round(nvl(avg(IRI), -1), 2)  from IRI_LANE where section_no='{0}' and LANE='{1}' " +
               " and survey_no=(select max(survey_no) from IRI_LANE where section_no='{0}' and LANE='{1}') ", sectionNo, laneType);

            Shared.LogMdStatment(SQL);
            DataTable dt = db.ExecuteQuery(SQL);
            if (dt.Rows.Count > 0)
                iri = double.Parse(dt.Rows[0][0].ToString());

            //else
            if (iri == -1 || dt.Rows.Count == 0)
            {
                //SQL = string.Format("Select round(nvl(avg(IRI), -1), 2) as IRI from IRI_LANE where section_no='{0}' ", sectionNo);
                SQL = string.Format("Select round(nvl(avg(IRI), -1), 2)  from IRI_LANE where section_no='{0}' " +
               " and survey_no=(select max(survey_no) from IRI_LANE where section_no='{0}') ", sectionNo);

                Shared.LogMdStatment(SQL);
                dt = db.ExecuteQuery(SQL);
                if (dt.Rows.Count > 0)
                    iri = double.Parse(dt.Rows[0][0].ToString());
            }

            return iri;
        }

        public double GET_INTERSECTION_IRI(string INTER_NO)
        {
            double iri = -1;

            //string SQL = string.Format("Select round(avg(IRI), 2) as IRI from IRI_INTERSECTION where INTER_NO='{0}' group by INTER_NO ", INTER_NO);
            string SQL = string.Format("Select round(nvl(avg(IRI), -1), 2)  from IRI_INTERSECTION where inter_no='{0}' " + 
                " and survey_no=(select max(survey_no) from IRI_INTERSECTION where inter_no='{0}') ", INTER_NO);

            Shared.LogMdStatment(SQL);
            DataTable dt = db.ExecuteQuery(SQL);
            if (dt.Rows.Count > 0)
                iri = double.Parse(dt.Rows[0][0].ToString());

            return iri;
        }


        //Get FWD Value
        public double GET_LANE_FWD(string sectionNo) //int LANE_ID) , string laneType
        {
            double FWD = -1;
            //string SQL = string.Format("select d1 from FWD_LANES where section_no='{0}' ", sectionNo, laneType); //lane_id={0} ", LANE_ID); and lane_type='{1}' 

            string sql = string.Format("select section_no, main_no, round(avg(d1), 2) as d1 from fwd_data " +
                " where section_no='{0}' and mod(drop_id, 3)=0   group by section_no, main_no ", sectionNo);

            Shared.LogMdStatment(sql);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
                FWD = double.Parse(dt.Rows[0]["d1"].ToString());

            return FWD;
        }

        //Get GPR Value
        public double GET_LANE_GPR(string sectionNo) //int LANE_ID)
        {
            double GPR = -1;

            string SQL = string.Format("select (LAYER1+LAYER2+LAYER3) as gpr_layers from GPR where SECTION_NO='{0}' ", sectionNo); //lane_id={0} ", LANE_ID);
            Shared.LogMdStatment(SQL);
            DataTable dt = db.ExecuteQuery(SQL);
            if (dt.Rows.Count > 0)
                GPR = double.Parse(dt.Rows[0][0].ToString());

            return GPR;
        }

        public double GET_Intersection_GPR(string intersectNo)
        {
            double GPR = -1;

            string SQL = string.Format("select (LAYER1+LAYER2+LAYER3) as gpr_layers from GPR where INTER_NO='{0}' ", intersectNo); //lane_id={0} ", LANE_ID);
            Shared.LogMdStatment(SQL);
            DataTable dt = db.ExecuteQuery(SQL);
            if (dt.Rows.Count > 0)
                GPR = double.Parse(dt.Rows[0][0].ToString());

            return GPR;
        }
        

    }
}
