using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Maintenance_Decision.DB;

namespace Maintenance_Decision
{

    //public struct MAINT_DECISION
    //{
    //    public int MAINT_ID;
    //    public string MAINT_NAME;
    //    public double UNIT_COST;


    //}

    //public struct LANE
    //{
    //    public int MAIN_ST_ID;
    //    public string MAIN_ST_NAME;
    //    public int SEC_ID;
    //    public string SEC_NO;
    //    public int LAN_ID;
    //    public string LAN_NO;
    //    public double LAN_AREA;
    //    public double DENSITY;
    //    public double UDI_VAL;
    //    public string SEVERITY;
    //    public int MD_ID;
    //    public double M_AREA;
    //    public double LAYER1;
    //    public double LAYER2;
    //    public double Total;
    //    public double FWD;
    //    public double IRI;
    //    public double GPR;


    //}

    //public struct LANE_SAMPLE
    //{
    //    public int MAIN_ST_ID;
    //    public string MAIN_ST_NAME;
    //    public int SEC_ID;
    //    public string SEC_NO;
    //    public int LAN_ID;
    //    public string LAN_NO;
    //    public int SMP_NO;
    //    public int SMP_ID;
    //    public double SMP_AREA;
    //    public double DENSITY;
    //    public double UDI_VAL;
    //    public string SEVERITY;
    //    public int MD_ID;
    //    public double M_AREA;
    //    public double Distress_AREA;
    //    public int DIST_CODE;


    //}

    //public struct INTERSECTION_SAMPLE
    //{
    //    public int MAIN_ST_ID;
    //    public string MAIN_ST_NAME;
    //    public int INT_ID;
    //    public string INT_NO;
    //    public int SMP_NO;
    //    public int SMP_ID;
    //    public double SMP_AREA;
    //    public double DENSITY;
    //    public double UDI_VAL;
    //    public string SEVERITY;
    //    public int MD_ID;
    //    public double M_AREA;
    //    public double Distress_AREA;
    //    public int DIST_CODE;
    //}

    //public struct sec_street
    //{
    //    public int subregion_id;
    //    public string subregion_no;
    //    public int SMP_ID;
    //    public string SEC_ST_NO;
    //    public double SMP_AREA;
    //    public double DENSITY;
    //    public double UDI_VAL;
    //    public string SEVERITY;
    //    public int MD_ID;
    //    public double M_AREA;
    //    public double Distress_AREA;
    //    public int DIST_CODE;
    //}

    //public struct INTERSECTION
    //{
    //    public int MAIN_ST_ID;
    //    public string MAIN_ST_NAME;
    //    public int INT_ID;
    //    public string INT_NO;
    //    public double IRI;
    //    public double UDI_VAL;
    //    public double INT_AREA;
    //    public int MD_ID;
    //    public double M_AREA;
    //}

    //public struct MAINSTREET
    //{
    //    public int MAIN_ST_ID;
    //    public string MAIN_ST_NAME;
    //}

    //public struct SUBREGION
    //{
    //    public int Sub_Reg_ID;
    //    public string Sub_Reg_NO;
    //}



    //public class C_Maint_Decision
    //{

    //    string SQL = "";
    //    DataSet ds;
    //    DataRow dr;
    //    DataRow[] drs;
    //    int rCnt = 0;

    //    static int IRI_Decision = 4;
    //    static int Deflection_Decision = 8;

    //    static int D_GOOD_VAL = 200;
    //    static int D_BAD_VAL = 500;
    //    static int UDI_Good_VAL = 70;
    //    static int IRI_Good_VAL = 4;
    //    static int FWD_Good_VAL = 500;
    //    static int FWD_BAD_VAL = 700;




    //    C_GET_Data m_C_Get_Data = new C_GET_Data();


    //    public C_Maint_Decision()
    //    {
    //        //
    //        // TODO: Add constructor logic here
    //        //
    //    }

    //    //public bool CalculateMaintenance_Decision_4_MainStreet(string m_MAIN_ST_ID, int SRV_ID)
    //    //{
    //    //    bool success = false;
    //    //    success = CalculateMD_4_StreetLanes(m_MAIN_ST_ID, SRV_ID);
    //    //    // success = CalculateMD_4_StreetIntersection(m_MAIN_ST_ID, SRV_ID);
    //    //    return success;
    //    //}


    //    public bool InsertLaneDecision(LANE m_Lane)
    //    {
    //        int res = 0;
    //        SQL = "Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, LANE_ID, MAINT_AREA) Values(SEQ_MAINTENANCE_DECISION.nextval," +
    //                                   m_Lane.MD_ID + "," +
    //                                   m_Lane.LAN_ID + "," +
    //                                    m_Lane.M_AREA + ")";
    //        DBConnection.m_CommStr = SQL;
    //        res = DBConnection.ExcuteNonQueryCommand();
    //        if (res > 0) return true;
    //        return false;
    //    }

    //    public bool InsertLane_SamplesDecision(LANE_SAMPLE m_Lane_Sample)
    //    {
    //        int res = 0;
    //        SQL = "Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, Sample_ID, LANE_ID, MAINT_AREA) Values(SEQ_MAINTENANCE_DECISION.nextval," +
    //                                   m_Lane_Sample.MD_ID + "," +
    //                                   m_Lane_Sample.SMP_ID + "," +
    //                                   m_Lane_Sample.LAN_ID + "," +
    //                                    m_Lane_Sample.M_AREA + ")";

    //        DBConnection.m_CommStr = SQL;
    //        res = DBConnection.ExcuteNonQueryCommand();
    //        if (res > 0) return true;
    //        return false;
    //    }

    //    public bool InsertIntersection_SamplesDecision(INTERSECTION_SAMPLE m_Intersection_Sample)
    //    {
    //        int res = 0;
    //        SQL = "Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, INT_SMP_ID, MAINT_AREA) Values(SEQ_MAINTENANCE_DECISION.nextval," +
    //                                   m_Intersection_Sample.MD_ID + "," +
    //                                   m_Intersection_Sample.SMP_ID + "," +
    //                                    m_Intersection_Sample.M_AREA + ")";
    //        DBConnection.m_CommStr = SQL;
    //        res = DBConnection.ExcuteNonQueryCommand();
    //        if (res > 0) return true;
    //        return false;
    //    }

    //    public bool InsertIntersectionDecision(INTERSECTION m_Intersection)
    //    {
    //        int res = 0;
    //        SQL = "Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, INTERSECTION_ID, MAINT_AREA) Values(SEQ_MAINTENANCE_DECISION.nextval," +
    //                                   m_Intersection.MD_ID + "," +
    //                                   m_Intersection.INT_ID + "," +
    //                                    m_Intersection.M_AREA + ")";
    //        DBConnection.m_CommStr = SQL;
    //        res = DBConnection.ExcuteNonQueryCommand();
    //        if (res > 0) return true;
    //        return false;
    //    }

    //    public bool InsertSEC_StreetDecision(sec_street m_Sec_Street)
    //    {
    //        int res = 0;
    //        SQL = "Insert Into MAINTENANCE_DECISIONS (RECORD_ID, RECOMMENDED_DECISION_ID, SEC_ST_ID, MAINT_AREA) Values(SEQ_MAINTENANCE_DECISION.nextval," +
    //                                   m_Sec_Street.MD_ID + "," +
    //                                   m_Sec_Street.SEC_ST_NO + "," +
    //                                    m_Sec_Street.M_AREA + ")";
    //        DBConnection.m_CommStr = SQL;
    //        res = DBConnection.ExcuteNonQueryCommand();
    //        if (res > 0) return true;
    //        return false;
    //    }



    //    public bool CalculateMD_4_StreetLanes(string MAIN_NO, int SRV_ID)
    //    {
    //        int rCnt = 0;
    //        LANE[] m_Lanes = m_C_Get_Data.GET_Street_Lanes(MAIN_NO);
    //        rCnt = m_Lanes.Length;
    //        if (rCnt > 0)// there is data 
    //        {

    //            for (int il = 0; il < rCnt; il++)
    //            {

    //                if (m_Lanes[il].UDI_VAL >= UDI_Good_VAL)
    //                {


    //                    // Do local maintenance

    //                    CalculateMD_4_Lane_Samples(m_Lanes[il].LAN_ID, m_Lanes[il].LAN_AREA);


    //                }
    //                else
    //                {
    //                    if (m_Lanes[il].IRI >= IRI_Good_VAL && m_Lanes[il].IRI != -1)//
    //                    {
    //                        m_Lanes[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;

    //                        m_Lanes[il].M_AREA = m_Lanes[il].LAN_AREA;
    //                        InsertLaneDecision(m_Lanes[il]);

    //                        continue;//go to another lane
    //                    }
    //                    else
    //                    {

    //                        if (m_Lanes[il].FWD >= FWD_BAD_VAL && m_Lanes[il].FWD != -1)
    //                        {

    //                            m_Lanes[il].MD_ID = 6;//reconstruction for all lane;
    //                            m_Lanes[il].M_AREA = m_Lanes[il].LAN_AREA;
    //                            InsertLaneDecision(m_Lanes[il]);
    //                            continue;//go to another lane
    //                        }
    //                        else
    //                        {
    //                            if (m_Lanes[il].FWD < FWD_BAD_VAL && m_Lanes[il].FWD >= FWD_Good_VAL && m_Lanes[il].FWD != -1)
    //                            {
    //                                if (m_Lanes[il].GPR < 15)
    //                                {
    //                                    m_Lanes[il].MD_ID = 8;//Mill&Re-Pave GPR Thickness for all lane;
    //                                    m_Lanes[il].M_AREA = m_Lanes[il].LAN_AREA;
    //                                    InsertLaneDecision(m_Lanes[il]);
    //                                    continue;//go to another lane
    //                                }
    //                                else
    //                                {
    //                                    m_Lanes[il].MD_ID = 8;//Mill&Re-Pave 15cm for all lane;
    //                                    m_Lanes[il].M_AREA = m_Lanes[il].LAN_AREA;
    //                                    InsertLaneDecision(m_Lanes[il]);
    //                                    continue;//go to another lane
    //                                }



    //                            }
    //                            else
    //                            {
    //                                m_Lanes[il].MD_ID = 8;//Mill&Re-Pave 15cm for all lane;
    //                                m_Lanes[il].M_AREA = m_Lanes[il].LAN_AREA;
    //                                InsertLaneDecision(m_Lanes[il]);
    //                                continue;//go to another lane
    //                            }

    //                        }



    //                    }


    //                }

    //            }

    //        }

    //        return true;
    //    }

    //    public bool CalculateMD_4_Lane_Samples(int m_Lane_ID, double m_Lane_Area)
    //    {

    //        int rCnt = 0;
    //        LANE_SAMPLE[] m_Lane_Samples = m_C_Get_Data.GET_LANE_SAMPLES_DECISION(m_Lane_ID);
    //        rCnt = m_Lane_Samples.Length;
    //        ArrayList m_TotalList = new ArrayList();
    //        ArrayList m_SampleList = new ArrayList();
    //        ArrayList smp_List = new ArrayList();
    //        double m_TotalArea = 0;
    //        double m_SMPArea = 0;
    //        int prev_SMP_ID = 0;
    //        if (rCnt > 0)// there is data 
    //        {

    //            for (int il = 0; il < rCnt; il++)
    //            {

    //                if (!m_SampleList.Contains(m_Lane_Samples[il].SMP_ID))//
    //                {
    //                    if (m_Lane_Samples[il].UDI_VAL <= UDI_Good_VAL)
    //                    {

    //                        m_Lane_Samples[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                        m_Lane_Samples[il].M_AREA = m_Lane_Samples[il].SMP_AREA;
    //                        m_TotalList.Add(m_Lane_Samples[il]);
    //                        m_TotalArea += m_Lane_Samples[il].M_AREA;
    //                        m_SampleList.Add(m_Lane_Samples[il].SMP_ID);
    //                    }
    //                    else
    //                    {
    //                        prev_SMP_ID = m_Lane_Samples[il].SMP_ID;
    //                        m_SMPArea = 0;
    //                        smp_List = new ArrayList();
    //                        while ( il < rCnt)
    //                        {
    //                            if (prev_SMP_ID != m_Lane_Samples[il].SMP_ID) 
    //                                break;

    //                            m_Lane_Samples[il].M_AREA = m_Lane_Samples[il].Distress_AREA;
    //                            m_SMPArea += m_Lane_Samples[il].Distress_AREA;
    //                            smp_List.Add(m_Lane_Samples[il]);
    //                            il++;

    //                        }
    //                        il--;//return step

    //                        if (m_SMPArea >= (double)(0.5 * m_Lane_Samples[il].SMP_AREA))//apply decision for all sample area
    //                        {

    //                            m_Lane_Samples[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                            m_Lane_Samples[il].M_AREA = m_Lane_Samples[il].SMP_AREA;
    //                            m_TotalList.Add(m_Lane_Samples[il]);
    //                            m_TotalArea += m_Lane_Samples[il].M_AREA;
    //                            m_SampleList.Add(m_Lane_Samples[il].SMP_ID);
    //                        }
    //                        else
    //                        {

    //                            m_TotalArea += m_SMPArea;
    //                            for (int x = 0; x < smp_List.Count; x++)
    //                            {
    //                                m_TotalList.Add(smp_List[x]);

    //                            }




    //                        }


    //                    }

    //                }



    //            }


    //            //check total area
    //            if (m_TotalArea >= (double)(0.5 * m_Lane_Area))//Apply decision for all lane
    //            {
    //                LANE m_Lane = new LANE();
    //                m_Lane.LAN_ID = m_Lane_ID;
    //                m_Lane.M_AREA = m_Lane_Area;
    //                m_Lane.MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                InsertLaneDecision(m_Lane);

    //            }
    //            else
    //            {
    //                for (int x = 0; x < m_TotalList.Count; x++)
    //                {
    //                    InsertLane_SamplesDecision((LANE_SAMPLE)m_TotalList[x]);

    //                }

    //            }



    //        }







    //        return true;

    //    }



    //    public bool CalculateMD_4_StreetIntersections(string m_MAIN_ST_ID, int SRV_ID)
    //    {

    //        int rCnt = 0;
    //        INTERSECTION[] m_Intersections = m_C_Get_Data.GET_Street_Intersection(m_MAIN_ST_ID);
    //        rCnt = m_Intersections.Length;
    //        if (rCnt > 0)// there is data 
    //        {

    //            for (int il = 0; il < rCnt; il++)
    //            {

    //                if (m_Intersections[il].UDI_VAL >= UDI_Good_VAL)
    //                {


    //                    // Do local maintenance

    //                    CalculateMD_4_Intersection_Samples(m_Intersections[il].INT_ID, m_Intersections[il].INT_AREA);


    //                }
    //                else
    //                {
    //                    if (m_Intersections[il].IRI >= IRI_Good_VAL && m_Intersections[il].IRI != -1)//
    //                    {
    //                        m_Intersections[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;

    //                        m_Intersections[il].M_AREA = m_Intersections[il].INT_AREA;
    //                        InsertIntersectionDecision(m_Intersections[il]);

    //                        continue;//go to another lane
    //                    }
    //                    else
    //                    {

    //                        m_Intersections[il].MD_ID = 8;//Mill&Re-Pave 15cm for all lane;
    //                        m_Intersections[il].M_AREA = m_Intersections[il].INT_AREA;
    //                        InsertIntersectionDecision(m_Intersections[il]);



    //                    }


    //                }



    //            }



    //        }

    //        return true;

    //    }

    //    public bool CalculateMD_4_Intersection_Samples(int m_INT_ID, double m_INT_Area)
    //    {

    //        int rCnt = 0;
    //        INTERSECTION_SAMPLE[] m_Intersection_Samples = m_C_Get_Data.GET_Intersection_SAMPLES_DECISION(m_INT_ID);
    //        rCnt = m_Intersection_Samples.Length;
    //        ArrayList m_TotalList = new ArrayList();
    //        ArrayList m_SampleList = new ArrayList();
    //        ArrayList smp_List = new ArrayList();
    //        double m_TotalArea = 0;
    //        double m_SMPArea = 0;
    //        int prev_SMP_ID = 0;
    //        if (rCnt > 0)// there is data 
    //        {

    //            for (int il = 0; il < rCnt; il++)
    //            {

    //                if (!m_SampleList.Contains(m_Intersection_Samples[il].SMP_ID))//
    //                {
    //                    if (m_Intersection_Samples[il].UDI_VAL >= UDI_Good_VAL)
    //                    {

    //                        m_Intersection_Samples[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                        m_Intersection_Samples[il].M_AREA = m_Intersection_Samples[il].SMP_AREA;
    //                        m_TotalList.Add(m_Intersection_Samples[il]);
    //                        m_TotalArea += m_Intersection_Samples[il].M_AREA;
    //                        m_SampleList.Add(m_Intersection_Samples[il].SMP_ID);
    //                    }
    //                    else
    //                    {
    //                        prev_SMP_ID = m_Intersection_Samples[il].SMP_ID;
    //                        m_SMPArea = 0;
    //                        smp_List = new ArrayList();
    //                        while (prev_SMP_ID == m_Intersection_Samples[il].SMP_ID && il < rCnt)
    //                        {
    //                            m_Intersection_Samples[il].M_AREA = m_Intersection_Samples[il].Distress_AREA;
    //                            m_SMPArea += m_Intersection_Samples[il].Distress_AREA;
    //                            smp_List.Add(m_Intersection_Samples[il]);
    //                            il++;

    //                        }
    //                        il--;//return step

    //                        if (m_SMPArea >= (double)(0.5 * m_Intersection_Samples[il].SMP_AREA))//apply decision for all sample area
    //                        {

    //                            m_Intersection_Samples[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                            m_Intersection_Samples[il].M_AREA = m_Intersection_Samples[il].SMP_AREA;
    //                            m_TotalList.Add(m_Intersection_Samples[il]);
    //                            m_TotalArea += m_Intersection_Samples[il].M_AREA;
    //                            m_SampleList.Add(m_Intersection_Samples[il].SMP_ID);
    //                        }
    //                        else
    //                        {

    //                            m_TotalArea += m_SMPArea;
    //                            for (int x = 0; x < smp_List.Count; x++)
    //                            {
    //                                m_TotalList.Add(smp_List[x]);

    //                            }

    //                        }

    //                    }

    //                }



    //            }


    //            //check total area
    //            if (m_TotalArea >= (double)(0.5 * m_INT_Area))//Apply decision for all lane
    //            {
    //                INTERSECTION m_Intersection = new INTERSECTION();
    //                m_Intersection.INT_ID = m_INT_ID;
    //                m_Intersection.M_AREA = m_INT_Area;
    //                m_Intersection.MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                InsertIntersectionDecision(m_Intersection);

    //            }
    //            else
    //            {
    //                for (int x = 0; x < m_TotalList.Count; x++)
    //                {
    //                    InsertLane_SamplesDecision((LANE_SAMPLE)m_TotalList[x]);

    //                }

    //            }

    //        }


    //        return true;

    //    }

    //    public bool CalculateMD_4_SEC_Street(string SUB_REG_NO)
    //    {

    //        int rCnt = 0;
    //        sec_street[] m_SEC_STREETS = m_C_Get_Data.GET_Sec_Street_DECISION(SUB_REG_NO);
    //        rCnt = m_SEC_STREETS.Length;
    //        ArrayList m_TotalList = new ArrayList();
    //        ArrayList m_SampleList = new ArrayList();
    //        ArrayList smp_List = new ArrayList();
    //        double m_TotalArea = 0;
    //        double m_SMPArea = 0;
    //        int prev_SMP_ID = 0;
    //        if (rCnt > 0)// there is data 
    //        {

    //            for (int il = 0; il < rCnt; il++)
    //            {

    //                if (!m_SampleList.Contains(m_SEC_STREETS[il].SMP_ID))//
    //                {
    //                    if (m_SEC_STREETS[il].UDI_VAL <= UDI_Good_VAL)
    //                    {

    //                        m_SEC_STREETS[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                        m_SEC_STREETS[il].M_AREA = m_SEC_STREETS[il].SMP_AREA;
    //                        m_TotalList.Add(m_SEC_STREETS[il]);
    //                        m_TotalArea += m_SEC_STREETS[il].M_AREA;
    //                        m_SampleList.Add(m_SEC_STREETS[il].SMP_ID);
    //                    }
    //                    else
    //                    {
    //                        prev_SMP_ID = m_SEC_STREETS[il].SMP_ID;
    //                        m_SMPArea = 0;
    //                        smp_List = new ArrayList();
    //                        while (prev_SMP_ID == m_SEC_STREETS[il].SMP_ID && il < rCnt)
    //                        {
    //                            m_SEC_STREETS[il].M_AREA = m_SEC_STREETS[il].Distress_AREA;
    //                            m_SMPArea += m_SEC_STREETS[il].Distress_AREA;
    //                            smp_List.Add(m_SEC_STREETS[il]);
    //                            il++;

    //                        }
    //                        il--;//return step

    //                        if (m_SMPArea >= (double)(0.5 * m_SEC_STREETS[il].SMP_AREA))//apply decision for all sample area
    //                        {

    //                            m_SEC_STREETS[il].MD_ID = 8;//Mill&Re-Pave 5cm for all lane;
    //                            m_SEC_STREETS[il].M_AREA = m_SEC_STREETS[il].SMP_AREA;
    //                            m_TotalList.Add(m_SEC_STREETS[il]);
    //                            m_TotalArea += m_SEC_STREETS[il].M_AREA;
    //                            m_SampleList.Add(m_SEC_STREETS[il].SMP_ID);
    //                        }
    //                        else
    //                        {

    //                            m_TotalArea += m_SMPArea;
    //                            for (int x = 0; x < smp_List.Count; x++)
    //                            {
    //                                m_TotalList.Add(smp_List[x]);

    //                            }




    //                        }


    //                    }

    //                }


    //            }

    //        }







    //        return true;

    //    }



















    //}

}
