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

public partial class ASPX_Reports_ViewTrafficCountingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null)
            {
                string rptFullPath = Server.MapPath(@".\RptFiles\MachineSurveys\jpmms_traffic_counting.RPT");

                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);

                Session.Remove("ReportData");

                Stream memStream;
                Response.Buffer = false;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                if (Request.QueryString["type"] == "x")
                {
                    ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                    excelOptions.ExcelUseConstantColumnWidth = false;
                    rpt.ExportOptions.FormatOptions = excelOptions;

                    memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                    Response.ContentType = "application/vnd.ms-excel";
                }
                else if (Request.QueryString["type"] == "w")
                {
                    memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                    Response.ContentType = "application/doc";
                }
                else
                {
                    memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.ContentType = "application/pdf";
                    //memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                    //Response.ContentType = "application/msword"; 
                }



                byte[] ArryStream = new byte[memStream.Length + 1];
                memStream.Read(ArryStream, 0, System.Convert.ToInt32(memStream.Length));
                Response.BinaryWrite(ArryStream);
                Response.End();

                memStream.Flush();
                memStream.Close();
                memStream.Dispose();
                rpt.Close();
                rpt.Dispose();
                GC.Collect();
            }
            else
                Response.Redirect("TrafficCountingOnSectionsReport.aspx", false);

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