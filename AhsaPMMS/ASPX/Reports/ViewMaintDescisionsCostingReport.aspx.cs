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

public partial class ASPX_Reports_ViewMaintDescisionsCostingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null)
            {
                string rptFullPath = "";
                if (Session["option"].ToString() == "radByMainLanes" && Session["details"].ToString() == "details")
                    rptFullPath = Server.MapPath(@".\RptFiles\MD_Prio_cost\rptMaintDecisionsCostingSections.rpt");
                else if (Session["option"].ToString() == "radByMainLanes" && Session["details"].ToString() == "summary")
                    rptFullPath = Server.MapPath(@".\RptFiles\MD_Prio_cost\rptSectionMainDecisionCostingSummary.rpt");
                else if (Session["option"].ToString() == "radByIntersections" && Session["details"].ToString() == "details")
                    rptFullPath = Server.MapPath(@".\RptFiles\MD_Prio_cost\rptMaintDecisionsCostingIntersects.rpt");
                else if (Session["option"].ToString() == "radByIntersections" && Session["details"].ToString() == "summary")
                    rptFullPath = Server.MapPath(@".\RptFiles\MD_Prio_cost\rptIntersectMainDecisionCostingSummary.rpt");
                else if (Session["option"].ToString() == "radByRegionNo" && Session["details"].ToString() == "details")
                    rptFullPath = Server.MapPath(@".\RptFiles\MD_Prio_cost\rptMaintDecisionsCostingRegions.rpt");
                else if (Session["option"].ToString() == "radByRegionNo" && Session["details"].ToString() == "summary")
                    rptFullPath = Server.MapPath(@".\RptFiles\MD_Prio_cost\rptRegionMainDecisionCostingSummary.rpt");
                else
                    throw new Exception("Invalid report option!");


                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);
                
                if (Session["option"].ToString() == "radByMainLanes")
                {
                    if (!string.IsNullOrEmpty(Session["title"].ToString()))
                        rpt.SetParameterValue("Title", Session["title"].ToString());
                    else
                        rpt.SetParameterValue("Title", "");
                }

                Session.Remove("ReportData");
                Session.Remove("title");


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
                Response.Redirect("MaintDecisionsCostingReport.aspx", false);

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
