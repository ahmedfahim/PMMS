﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class ASPX_Reports_ViewUdiCompareReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null)
            {
                string rptFullPath = "";
                if (Session["option"].ToString() == "radLSampleWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareSecSamples.rpt");
                else if (Session["option"].ToString() == "radLaneWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareLanes.rpt");
                else if (Session["option"].ToString() == "radSectionWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareSections.rpt");
                else if (Session["option"].ToString() == "radISampleWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareIntersectSamples.rpt");
                else if (Session["option"].ToString() == "radIntersectWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareIntersects.rpt");
                else if (Session["option"].ToString() == "radRegionWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareRegions.rpt");
                else if (Session["option"].ToString() == "radSecStWise")
                    rptFullPath = Server.MapPath(@".\RptFiles\udi\rptUdiCompareSecSt.rpt");
                else
                    throw new Exception("Invalid report option!");


                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);

                Session.Remove("ReportData");

                MemoryStream memStream;
                Response.Buffer = false;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                if (Request.QueryString["type"] == "x")
                {
                    ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                    excelOptions.ExcelUseConstantColumnWidth = false;
                    rpt.ExportOptions.FormatOptions = excelOptions;

                    memStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                    Response.ContentType = "application/vnd.ms-excel";
                }
                else
                {
                    memStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.ContentType = "application/pdf";
                    //memStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                    //Response.ContentType = "application/msword"; 
                }



                Response.BinaryWrite(memStream.ToArray());
                Response.End();

                memStream.Flush();
                memStream.Close();
                memStream.Dispose();
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
            }
            else
                Response.Redirect("UdiCompareReport.aspx", false);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            Session["ReportData"] = null;
        }
    }
}