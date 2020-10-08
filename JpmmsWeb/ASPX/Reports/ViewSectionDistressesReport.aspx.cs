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

public partial class ASPX_Reports_ViewSectionDistressesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null)
            {
                string rptFullPath = "";
                if (Session["option"].ToString() == "radBySection")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\JPMMS_VSEC_DIST.RPT");
                else if (Session["option"].ToString() == "radbyMainStreet")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\JPMMS_MIDSECLANEsam_DIST.RPT");
                else if (Session["option"].ToString() == "radByStreetDistressArea")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\JPMMS_dist_code_distress_Main.RPT");
                else if (Session["option"].ToString() == "radByStreetDistressAreaTotal")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\JPMMS_dist_code_distress_Main_AVG.RPT");
                else if (Session["option"].ToString() == "radByStreetAreaTotal")
                    rptFullPath = Server.MapPath(@".\RptFiles\Distress\JPMMS_dist_code_distress_Main_AVG_All.RPT");
                else
                    throw new Exception("Invalid report option!");


                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);
               
                if (Session["option"].ToString() == "radBySection")
                {
                    if (!string.IsNullOrEmpty(Session["title"].ToString()))
                        rpt.SetParameterValue("Title", Session["title"].ToString());
                    else
                        rpt.SetParameterValue("Title", "");
                }

                Session.Remove("ReportData");
                Session.Remove("title");


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
                Response.Redirect("SectionDistresses.aspx", false);

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