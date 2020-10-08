using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class ASPX_Reports_ViewQcReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null)
            {
                string rptFullPath = "";
                if (Session["option"].ToString() == "radSection" && Session["details"].ToString() == "radSummary")
                    rptFullPath = Server.MapPath(@".\RptFiles\Operations\rptQcSections.rpt");
                else if (Session["option"].ToString() == "radIntersection" && Session["details"].ToString() == "radSummary")
                    rptFullPath = Server.MapPath(@".\RptFiles\Operations\rptQcIntersects.rpt");
                else if (Session["option"].ToString() == "radRegionSecondary" && Session["details"].ToString() == "radSummary")
                    rptFullPath = Server.MapPath(@".\RptFiles\Operations\rptQcRegions.rpt");
                else if (Session["option"].ToString() == "radSection" && Session["details"].ToString() == "radDetails")
                    rptFullPath = Server.MapPath(@".\RptFiles\Operations\rptQcSectionsDetailed.rpt");
                else if (Session["option"].ToString() == "radIntersection" && Session["details"].ToString() == "radDetails")
                    rptFullPath = Server.MapPath(@".\RptFiles\Operations\rptQcIntersectDetailed.rpt");
                else if (Session["option"].ToString() == "radRegionSecondary" && Session["details"].ToString() == "radDetails")
                    rptFullPath = Server.MapPath(@".\RptFiles\Operations\rptQcRegionsDetailed.rpt");
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
                Response.Redirect("QcReports.aspx", false);
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
