using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maintenance_Decision.DB;

namespace Maintenance_Decision
{
    //public class C_GET_Data
    //{
    //    string SQL = "";
    //    DataSet ds;


    //    public LANE[] GET_Street_Lanes(string MAIN_NO)
    //    {
    //        int rCnt = 0;
    //        LANE[] m_Lanes = new LANE[0];
    //        double AREA = -1;
    //        // 
    //        SQL = string.Format("Select LANE_ID, sum(LANE_LENGTH*LANE_WIDTh) as AREA from GV_LANE where MAIN_NO='{0}' and lane_id in (select lane_id from GV_SAMPLE_DISTRESS where MAIN_NO='{0}') group by LANE_ID ", MAIN_NO);
    //        DBConnection.m_CommStr = SQL;
    //        DataSet ds = DBConnection.ExcuteReaderCommand("GV_LANE");
    //        DataRow dr;
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {

    //                rCnt = ds.Tables[0].Rows.Count;
    //                LANE m_Lane;
    //                if (rCnt > 0)
    //                {
    //                    m_Lanes = new LANE[rCnt];
    //                    for (int i = 0; i < rCnt; i++)
    //                    {
    //                        m_Lane = new LANE();
    //                        dr = ds.Tables[0].Rows[i];
    //                        if (!(dr[0] is DBNull))
    //                            m_Lane.LAN_ID = int.Parse(dr[0].ToString());

    //                        if (!(dr[1] is DBNull))
    //                            m_Lane.LAN_AREA = double.Parse(dr[1].ToString());

    //                        m_Lane.UDI_VAL = GET_LANE_UDI(m_Lane.LAN_ID);
    //                        m_Lane.IRI = GET_LANE_IRI(m_Lane.LAN_ID);
    //                        m_Lane.FWD = GET_LANE_FWD(m_Lane.LAN_ID);
    //                        m_Lane.GPR = GET_LANE_GPR(m_Lane.LAN_ID);
    //                        m_Lanes[i] = m_Lane;

    //                    }

    //                }
    //            }
    //        }



    //        return m_Lanes;


    //    }

    //    public INTERSECTION[] GET_Street_Intersection(string MAIN_NO)
    //    {
    //        int rCnt = 0;
    //        INTERSECTION[] m_Intersections = new INTERSECTION[0];
    //        double AREA = -1;
    //        SQL = "Select INTER_NO,INTERSECTION_ID,sum(INTERSEC_SAMP_AREA) as AREA from GV_INTERSECTION_SAMPLES where " +
    //            "MAIN_NO=\'" + MAIN_NO + "\' group by INTER_NO,INTERSECTION_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("GV_INTERSECTION_SAMPLES");
    //        DataRow dr;
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {

    //                rCnt = ds.Tables[0].Rows.Count;
    //                INTERSECTION m_Intersection;
    //                if (rCnt > 0)
    //                {
    //                    m_Intersections = new INTERSECTION[rCnt];
    //                    for (int i = 0; i < rCnt; i++)
    //                    {
    //                        m_Intersection = new INTERSECTION();
    //                        dr = ds.Tables[0].Rows[i];
    //                        m_Intersection.INT_NO = dr[0].ToString();
    //                        m_Intersection.INT_ID = int.Parse(dr[1].ToString());
    //                        m_Intersection.INT_AREA = double.Parse(dr[2].ToString());
    //                        m_Intersection.UDI_VAL = GET_INTERSECTION_UDI(m_Intersection.INT_NO);
    //                        m_Intersection.IRI = GET_INTERSECTION_IRI(m_Intersection.INT_NO);

    //                        m_Intersections[i] = m_Intersection;

    //                    }

    //                }
    //            }
    //        }



    //        return m_Intersections;


    //    }



    //    //public LANE GET_LANE_DATA(int LANE_ID)
    //    //{
    //    //    LANE m_Lane = new LANE();


    //    //    m_Lane.UDI_VAL = GET_LANE_UDI(LANE_ID);
    //    //    m_Lane.IRI = GET_LANE_IRI(LANE_ID);
    //    //    m_Lane.FWD = GET_LANE_FWD(LANE_ID);
    //    //    m_Lane.GPR = GET_LANE_GPR(LANE_ID);

    //    //    return m_Lane;
    //    //}


    //    //Get AREA
    //    //public double GET_LANE_AREA(int LANE_ID)
    //    //{
    //    //    double AREA = -1;
    //    //    SQL = "Select sum(LANE_LENGTH*LANE_WIDTh) as AREA from GV_LANE where LANE_ID=" + LANE_ID + " group by LANE_ID";
    //    //    DBConnection.m_CommStr = SQL;
    //    //    ds = DBConnection.ExcuteReaderCommand("GV_LANE");
    //    //    if (ds != null)
    //    //    {
    //    //        if (ds.Tables.Count > 0)
    //    //        {
    //    //            if (ds.Tables[0].Rows.Count > 0)
    //    //            {
    //    //                AREA = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //    //            }
    //    //        }
    //    //    }



    //    //    return AREA;


    //    //}

    //    public double GET_INTERSECTION_AREA(int INT_ID)
    //    {
    //        double AREA = -1;
    //        SQL = "Select sum(INTERSEC_SAMP_AREA) as AREA from GV_INTERSECTION_SAMPLES where INTERSECTION_ID=" + INT_ID + " group by INTERSECTION_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("GV_INTERSECTION_SAMPLES");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    AREA = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }

    //        return AREA;
    //    }


    //    //Get Samples Data 
    //    //Note:Create View for this methods
    //    public LANE_SAMPLE[] GET_LANE_SAMPLES_DECISION(int LANE_ID)
    //    {
    //        LANE_SAMPLE[] m_LANE_SAMPLES = new LANE_SAMPLE[0];
    //        int rCnt = 0;
    //        SQL = "Select SAMPLE_ID, UDI_VALUE, DIST_CODE, SAMPLE_AREA, DIST_AREA, DIST_SEVERITY, lane_id "+
    //              "from V_LANE_Sample_Decisions where LANE_ID=\'" + LANE_ID + "\' order by  SAMPLE_ID,UDI_VAlUE";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("V_LANE_Sample_Decisions");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                rCnt = ds.Tables[0].Rows.Count;
    //                if (rCnt > 0)
    //                {
    //                    m_LANE_SAMPLES = new LANE_SAMPLE[rCnt];
    //                    LANE_SAMPLE m_Lane_Sample;
    //                    DataRow dr;

    //                    for (int i = 0; i < rCnt; i++)
    //                    {
    //                        dr = ds.Tables[0].Rows[i];
    //                        m_Lane_Sample = new LANE_SAMPLE();
    //                        m_Lane_Sample.SMP_ID = int.Parse(dr["SAMPLE_ID"].ToString());
    //                        m_Lane_Sample.LAN_ID = int.Parse(dr["lane_id"].ToString());
    //                        m_Lane_Sample.SMP_AREA = double.Parse(dr["SAMPLE_AREA"].ToString());
    //                        m_Lane_Sample.Distress_AREA = double.Parse(dr["DIST_AREA"].ToString());
    //                        m_Lane_Sample.UDI_VAL = double.Parse(dr["UDI_VALUE"].ToString());
    //                        m_Lane_Sample.SEVERITY = dr["DIST_SEVERITY"].ToString();
    //                        m_Lane_Sample.DIST_CODE = int.Parse(dr["DIST_CODE"].ToString());
    //                        m_Lane_Sample.MD_ID = GetDistressDecision(m_Lane_Sample.Distress_AREA, m_Lane_Sample.SMP_AREA,
    //                                        m_Lane_Sample.DIST_CODE, m_Lane_Sample.SEVERITY);
    //                        m_LANE_SAMPLES[i] = m_Lane_Sample;
    //                    }
    //                }
    //            }
    //        }

    //        return m_LANE_SAMPLES;
    //    }


    //    public INTERSECTION_SAMPLE[] GET_Intersection_SAMPLES_DECISION(int INT_ID)
    //    {
    //        INTERSECTION_SAMPLE[] m_Intersection_SAMPLES = new INTERSECTION_SAMPLE[0];
    //        int rCnt = 0;
    //        SQL = "Select INTER_SAMP_ID as SAMPLE_ID,UDI_VALUE,DIST_CODE,INTERSEC_SAMP_AREA as SAMPLE_AREA,DIST_AREA,DIST_SEVERITY "+
    //              "from V_Intersection_Sample_Decisions order by INTER_SAMP_ID,UDI_VALUE" +
    //              " where INTERSECTION_ID=" + INT_ID +" order by INTER_SAMP_ID,UDI_VALUE";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("V_Intersection_Sample_Decisions");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                rCnt = ds.Tables[0].Rows.Count;
    //                if (rCnt > 0)
    //                {
    //                    m_Intersection_SAMPLES = new INTERSECTION_SAMPLE[rCnt];
    //                    INTERSECTION_SAMPLE m_Intersection_Sample;
    //                    DataRow dr;

    //                    for (int i = 0; i < rCnt; i++)
    //                    {
    //                        dr = ds.Tables[0].Rows[i];
    //                        m_Intersection_Sample = new INTERSECTION_SAMPLE();
    //                        m_Intersection_Sample.SMP_ID = int.Parse(dr["SAMPLE_ID"].ToString());
    //                        m_Intersection_Sample.SMP_AREA = double.Parse(dr["SAMPLE_AREA"].ToString());
    //                        m_Intersection_Sample.Distress_AREA = double.Parse(dr["DIST_AREA"].ToString());
    //                        m_Intersection_Sample.UDI_VAL = double.Parse(dr["SAMPLE_ID"].ToString());
    //                        m_Intersection_Sample.SEVERITY = dr["DIST_SEVERITY"].ToString();
    //                        m_Intersection_Sample.DIST_CODE = int.Parse(dr["DIST_CODE"].ToString());
    //                        m_Intersection_Sample.MD_ID = GetDistressDecision(m_Intersection_Sample.Distress_AREA, m_Intersection_Sample.SMP_AREA,
    //                                        m_Intersection_Sample.DIST_CODE, m_Intersection_Sample.SEVERITY);

    //                        m_Intersection_SAMPLES[i] = m_Intersection_Sample;
    //                    }

    //                }
    //            }
    //        }

    //        return m_Intersection_SAMPLES;
    //    }

    //    public sec_street[] GET_Sec_Street_DECISION(string Region_NO)
    //    {
    //        sec_street[] m_SEC_STREETS = new sec_street[0];
    //        int rCnt = 0;

    //        SQL = "Select SECOND_ID as SAMPLE_ID,UDI_VALUE,DIST_CODE,SECOND_AREA as SAMPLE_AREA,DIST_AREA,DIST_SEVERITY from V_SEC_Street_Decisions order by SECOND_ID" +
    //              " where REGION_NO=\'" + Region_NO + "\' order by SECOND_ID,UDI_VALUE";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("V_SEC_Street_Decisions");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                rCnt = ds.Tables[0].Rows.Count;
    //                if (rCnt > 0)
    //                {
    //                    m_SEC_STREETS = new sec_street[rCnt];
    //                    sec_street m_Sec_Street;
    //                    DataRow dr;

    //                    for (int i = 0; i < rCnt; i++)
    //                    {
    //                        dr = ds.Tables[0].Rows[i];
    //                        m_Sec_Street = new sec_street();
    //                        m_Sec_Street.SMP_ID = int.Parse(dr["SAMPLE_ID"].ToString());
    //                        m_Sec_Street.SMP_AREA = double.Parse(dr["SAMPLE_AREA"].ToString());
    //                        m_Sec_Street.Distress_AREA = double.Parse(dr["DIST_AREA"].ToString());
    //                        m_Sec_Street.UDI_VAL = double.Parse(dr["SAMPLE_ID"].ToString());
    //                        m_Sec_Street.SEVERITY = dr["DIST_SEVERITY"].ToString();
    //                        m_Sec_Street.DIST_CODE = int.Parse(dr["DIST_CODE"].ToString());
    //                        m_Sec_Street.MD_ID = GetDistressDecision(m_Sec_Street.Distress_AREA, m_Sec_Street.SMP_AREA,
    //                                        m_Sec_Street.DIST_CODE, m_Sec_Street.SEVERITY);

    //                        m_SEC_STREETS[i] = m_Sec_Street;
    //                    }



    //                }
    //            }
    //        }

    //        return m_SEC_STREETS;
    //    }


    //    private int GetDistressDecision(double DistressArea, double Sample_Area, int Defect_Code, string Severity)
    //    {
    //        int MD_ID = 0;
    //        double density = ((double)DistressArea / Sample_Area) * 100; //Calcultae Percentage of Distress
    //        //density *= 100;
    //        string Defect = Defect_Code + "" + Severity;

    //        if ((Defect == "1L" && density > 10) ||
    //            (Defect == "2M" && density <= 50) ||
    //            (Defect == "3M") ||
    //            (Defect == "12M")
    //            )
    //        {
    //            MD_ID = 2;//Crack Sealing

    //        }

    //        else if ((Defect == "2M") ||
    //            (Defect == "4M") ||
    //            (Defect == "5L") ||
    //            (Defect == "5M") ||
    //            (Defect == "6M") ||
    //            (Defect == "10M") ||
    //            (Defect == "10H") ||
    //            (Defect == "11M") ||
    //            (Defect == "13M") ||
    //            (Defect == "14M") ||
    //            (Defect == "15M") ||
    //            (Defect == "9M" && density <= 50 && density > 10)
    //           )
    //        {
    //            MD_ID = 3;//Surface Patching

    //        }
    //        else if ((Defect == "1H") ||
    //            (Defect == "2H") ||
    //            (Defect == "3H") ||
    //            (Defect == "4H") ||
    //            (Defect == "5H") ||
    //            (Defect == "6H") ||
    //            (Defect == "7H") ||
    //            (Defect == "14H") ||
    //            (Defect == "8H" && density <= 50) ||
    //            (Defect == "12H" && density <= 50) ||
    //            (Defect == "13H" && density <= 10)
    //           )
    //        {
    //            MD_ID = 4;//Deep Patching

    //        }

    //        else if ((Defect == "2H") ||
    //           (Defect == "3H") ||
    //           (Defect == "12H" && density > 50) ||
    //           (Defect == "11H") ||
    //           (Defect == "15H"))
    //        {
    //            MD_ID = 5;//Thin Overlay

    //        }



    //        else if ((Defect == "8M") ||
    //           (Defect == "9H") ||
    //           (Defect == "9M" && density > 50))
    //        {
    //            MD_ID = 6;//Mill and Re-pave 5cm

    //        }
    //        else if ((Defect == "6H") ||
    //           (Defect == "13H" && density > 50))
    //        {
    //            MD_ID = 7;//Mill and Re-pave 10cm

    //        }
    //        else if ((Defect == "1H") ||
    //            (Defect == "7H") ||
    //           (Defect == "8H" && density > 50))
    //        {
    //            MD_ID = 8;//Mill and Re-pave upto 15cm or reconstruction

    //        }
    //        else
    //        {
    //            MD_ID = 1;//Do nothing
    //        }



    //        return MD_ID;
    //    }

    //    public double GET_LANE_IRI(int LANE_ID)
    //    {
    //        double iri = -1;
    //        SQL = "Select avg(IRI) as IRI from IRI_LANE where LANE_ID=\'" + LANE_ID + "\' group by LANE_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("IRI_LANE");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    iri = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }



    //        return iri;
    //    }

    //    public double GET_INTERSECTION_IRI(string INTER_NO)
    //    {
    //        double iri = -1;
    //        SQL = "Select avg(IRI) as IRI from IRI_INTERSECTION where INTER_NO=\'" + INTER_NO + "\' group by INTER_NO";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("IRI_INTERSECTION");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    iri = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }



    //        return iri;
    //    }


    //    //Get FWD Value
    //    public double GET_LANE_FWD(int LANE_ID)
    //    {
    //        double FWD = -1;
    //        return FWD;
    //    }

    //    //Get GPR Value
    //    public double GET_LANE_GPR(int LANE_ID)
    //    {


    //        double GPR = -1;
    //        return GPR;


    //    }


    //    #region Getting UDI
    //    //Get UDI Value
    //    public double GET_LANE_UDI(int LANE_ID)
    //    {
    //        double UDI = 0;
    //        SQL = "Select UDI_VALUE from UDI_LANES where LANE_ID=\'" + LANE_ID + "\' order by LANE_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("UDI_LANES");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    UDI = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }


    //        return UDI;
    //    }

    //    public double GET_LANE_SAMPLES_UDI(int SMP_ID)
    //    {
    //        double UDI = 0;
    //        SQL = "Select UDI_VALUE from GV_SAMPLES_UDI where SAMPLE_ID=" + SMP_ID + " group by SAMPLE_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("GV_SAMPLES_UDI");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    UDI = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }


    //        return UDI;
    //    }

    //    public double GET_INTERSECTION_UDI(string Inter_NO)
    //    {
    //        double UDI = 0;
    //        SQL = "Select UDI_VALUE from UDI_INTERSECTION where INTER_NO=" + Inter_NO + " group by INTER_NO";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("UDI_INTERSECTION");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    UDI = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }


    //        return UDI;
    //    }

    //    public double GET_INTERSECTION_SAMPLES_UDI(int SMP_ID)
    //    {
    //        double UDI = 0;
    //        SQL = "Select UDI_VALUE from GV_INTERSECTION_SMP_UDI where INTER_SAMP_ID=" + SMP_ID + " group by INTER_SAMP_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("GV_INTERSECTION_SMP_UDI");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    UDI = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }


    //        return UDI;
    //    }

    //    public double GET_SEC_ST_UDI(int SEC_ST_ID)
    //    {
    //        double UDI = 0;
    //        SQL = "Select UDI_VALUE from GV_SEC_ST_UDI where SECOND_ID=" + SEC_ST_ID + " group by SECOND_ID";
    //        DBConnection.m_CommStr = SQL;
    //        ds = DBConnection.ExcuteReaderCommand("GV_SEC_ST_UDI");
    //        if (ds != null)
    //        {
    //            if (ds.Tables.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    UDI = double.Parse(ds.Tables[0].Rows[0][0].ToString());
    //                }
    //            }
    //        }


    //        return UDI;
    //    }

    //    #endregion

    //}
}
