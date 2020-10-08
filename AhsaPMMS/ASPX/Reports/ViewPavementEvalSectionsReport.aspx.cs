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

public partial class ASPX_Reports_ViewPavementEvalSectionsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null) 
            {
                string rptFullPath = "";
                if (Session["option"].ToString() == "radbySamples4Sections")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\JPMMS_VSamSec_UDI.RPT");
                else if (Session["option"].ToString() == "radbySamples4MainSt")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\JPMMS_VMIDSAMSEC_UDI.RPT");
                else if (Session["option"].ToString() == "radbyLane4Sections")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\jpmms_VLaneSecUDI.RPT");
                else if (Session["option"].ToString() == "radbyLane4MainSt")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\JPMMS_VMIDLaneSecUDI.RPT");
                else if (Session["option"].ToString() == "radbySections4MainSt")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\JPMMS_VMIDSEC_UDI1.RPT");
                else if (Session["option"].ToString() == "radbySamples4MainStWithDist")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\rptSamplesUdiWithDistress.rpt");
                else if (Session["option"].ToString() == "radbySamples4SectionsWithDist")
                    rptFullPath = Server.MapPath(@".\RptFiles\UDI\rptSamplesUdiWithDistress.rpt");
                else
                    throw new Exception("Invalid report option!");


                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);

                if (Session["option"].ToString() == "radbyLane4MainSt")
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
                Response.Redirect("PavementEvalSectionsReport.aspx", false);

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