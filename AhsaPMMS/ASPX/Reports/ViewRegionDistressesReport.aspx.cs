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

public partial class ASPX_Reports_ViewRegionDistressesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null)
            {
                string rptFullPath = ""; // .\RptFiles

                if (Session["option"].ToString() == "radbyRegion")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_region_distress.RPT");
                else if (Session["option"].ToString() == "radByRegionDistressArea")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_dist_code_distress_subdist.RPT");
                else if (Session["option"].ToString() == "radByRegionDistressAreaTotal")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_dist_code_distress_subdist_AVG.RPT");
                else if (Session["option"].ToString() == "radByRegionDistressAreaSeverity")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_dist_code_distress_subdist_severity.RPT");
                else if (Session["option"].ToString() == "radByRegionDistressAreaSeverityTotal")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_distress_subdist_AVG.RPT");
                else if (Session["option"].ToString() == "radAllRegionsDistressArea")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_dist_code_distress_subdist.RPT");
                else if (Session["option"].ToString() == "radByRegionAreaTotal")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\jpmms_distress_AVG_All.RPT");
                else
                    throw new Exception("Invalid report option!");


                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath, OpenReportMethod.OpenReportByTempCopy);
                rpt.SetDataSource(dt);
                rpt.Refresh();

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
                Response.Redirect("RegionDistressesReport.aspx", false);

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