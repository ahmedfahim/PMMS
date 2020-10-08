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

public partial class ASPX_Reports_ViewFinishedSurveyingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ReportData"] != null && Session["option"] != null)
            {
                string rptFullPath = "";
                if (Session["option"].ToString() == "section" || Session["option"].ToString() == "intersect" || Session["option"].ToString() == "sectionPhotos"
                    || Session["option"].ToString() == "sectionQc" || Session["option"].ToString() == "intersectQc" || Session["option"].ToString() == "radFwd" 
                    || Session["option"].ToString() == "radIriSections" || Session["option"].ToString() == "radIntersectIri" || Session["option"].ToString() == "radGprSections" 
                    || Session["option"].ToString() == "radGprIntersect" || Session["option"].ToString() == "radSkidSections" || Session["option"].ToString() == "radSkidIntersects" 
                    || Session["option"].ToString() == "radRuttingIntersects" || Session["option"].ToString() == "radRuttingSections" || Session["option"].ToString() == "radNonCompleteSections" 
                    || Session["option"].ToString() == "radNonCompleteIntersects" || Session["option"].ToString() == "radNonSurveySectionsStreets" || Session["option"].ToString() == "radNonSurveyIntersectStreets")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptFinishedSurveyingStreets.rpt");

                else if (Session["option"].ToString() == "regionQc" || Session["option"].ToString() == "regionPhotos")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptFinishedSurveyRegions.rpt");
                else if (Session["option"].ToString() == "region")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptSurveyedRegions.rpt");
                else if (Session["option"].ToString() == "intersectregion")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptSurveyedIntersetions.rpt");
                else if (Session["option"].ToString() == "regionOne")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptSurveyedRegionsOne.rpt");
                else if (Session["option"].ToString() == "traffic")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptTrafficCountMaxDate.rpt");
                else if (Session["option"].ToString() == "radReSurveySections")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptReSurveySections.rpt");
                else if (Session["option"].ToString() == "radReSurveyIntersect")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptReSurveyIntersects.rpt");
                else if (Session["option"].ToString() == "radReSurveyRegions")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptReSurveyRegions.rpt");

                else if (Session["option"].ToString() == "radNonSurveyedSections" || Session["option"].ToString() == "radSurveyedSections"
                    || Session["option"].ToString() == "radSectionNoPhotos")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rpNonSurveyedSections.rpt");
                else if (Session["option"].ToString() == "radNonSurveyedIntersects" || Session["option"].ToString() == "radSurveyedIntersects"
                    || Session["option"].ToString() == "radIntersectNoPhotos")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptNonSurveyedIntersects.rpt");
                else if (Session["option"].ToString() == "radNonSurveyedRegions" || Session["option"].ToString() == "radRegionNoPhotos" ||
                    Session["option"].ToString() == "radClosedRegions" || Session["option"].ToString() == "radNonCompleteSurveyingRegions")
                    rptFullPath = Server.MapPath(@".\RptFiles\FinishedSurveying\rptNonSurveyedRegions.rpt");
                else
                    throw new Exception("Invalid report option!");


                DataTable dt = (DataTable)Session["ReportData"];
                ReportDocument rpt = new ReportDocument();

                rpt.Load(rptFullPath);
                rpt.SetDataSource(dt);
                Session.Remove("ReportData");

                if (Session["option"].ToString() == "section")
                    rpt.SetParameterValue("Title", "الشوارع ذات المقاطع الممسوحة بصريا");
                else if (Session["option"].ToString() == "intersect")
                    rpt.SetParameterValue("Title", "الشوارع ذات التقاطعات الممسوحة بصريا");
                else if (Session["option"].ToString() == "intersect")
                    rpt.SetParameterValue("Title", "الشوارع ذات التقاطعات الممسوحة بصريا");
                //else if (Session["option"].ToString() == "region")
                //    rpt.SetParameterValue("Title", "مناطق الشوارع الفرعية الممسوحة بصريا");

                else if (Session["option"].ToString() == "sectionPhotos")
                    rpt.SetParameterValue("Title", "الشوارع ذات المقاطع والتقاطعات التي لها صور ضمن معرض الصور");
                else if (Session["option"].ToString() == "regionPhotos")
                    rpt.SetParameterValue("Title", "مناطق الشوارع الفرعية التي لها صور ضمن معرض الصور");

                else if (Session["option"].ToString() == "radSectionNoPhotos")
                    rpt.SetParameterValue("Title", "المقاطع التي ليست لها صور ضمن معرض الصور");
                else if (Session["option"].ToString() == "radIntersectNoPhotos")
                    rpt.SetParameterValue("Title", "التقاطعات التي ليست لها صور ضمن معرض الصور");
                else if (Session["option"].ToString() == "radRegionNoPhotos")
                    rpt.SetParameterValue("Title", "مناطق الشوارع الفرعية التي ليست لها صور ضمن معرض الصور");

                else if (Session["option"].ToString() == "sectionQc")
                    rpt.SetParameterValue("Title", "الشوارع ذات المقاطع التي أجري لها مسح ضبط جودة");
                else if (Session["option"].ToString() == "intersectQc")
                    rpt.SetParameterValue("Title", "الشوارع ذات التقاطعات التي أجري لها مسح ضبط جودة");
                else if (Session["option"].ToString() == "regionQc")
                    rpt.SetParameterValue("Title", "مناطق الشوارع الفرعية التي أجري لها مسح ضبط جودة");

                else if (Session["option"].ToString() == "radNonSurveyedSections")
                    rpt.SetParameterValue("Title", "المقاطع غير الممسوحة بصريا");
                else if (Session["option"].ToString() == "radNonSurveyedIntersects")
                    rpt.SetParameterValue("Title", "التقاطعات غير الممسوحة بصريا");
                else if (Session["option"].ToString() == "radNonSurveyedRegions")
                    rpt.SetParameterValue("Title", "مناطق الشوارع الفرعية غير الممسوحة بصريا"); // 
                else if (Session["option"].ToString() == "radClosedRegions")
                    rpt.SetParameterValue("Title", "مناطق لايمكن مسحها - مغلقة أو لاتحوي شوارع");

                else if (Session["option"].ToString() == "radSurveyedSections")
                    rpt.SetParameterValue("Title", "مقاطع الطرق الرئيسية الممسوحة بصريا");
                else if (Session["option"].ToString() == "radSurveyedIntersects")
                    rpt.SetParameterValue("Title", "تقاطعات الطرق الرئيسية الممسوحة بصريا");

                else if (Session["option"].ToString() == "radNonSurveySectionsStreets")
                    rpt.SetParameterValue("Title", "الطرق الرئيسية غير ممسوحة المقاطع");
                else if (Session["option"].ToString() == "radNonSurveyIntersectStreets")
                    rpt.SetParameterValue("Title", "الطرق الرئيسية غير ممسوحة التقاطعات");

                else if (Session["option"].ToString() == "radNonCompleteSections")
                    rpt.SetParameterValue("Title", "الطرق الرئيسية غير مكتملة المسح للمقاطع");
                else if (Session["option"].ToString() == "radNonCompleteIntersects")
                    rpt.SetParameterValue("Title", "الطرق الرئيسية غير مكتملة المسح للتقاطعات");
                else if (Session["option"].ToString() == "radNonCompleteSurveyingRegions")
                    rpt.SetParameterValue("Title", "مناطق الشوارع الفرعية غير مكتملة المسح بصريا"); 


                else if (Session["option"].ToString() == "radFwd")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم تنفيذ اختبار الحمل الساقط FWD لمقاطعها");
                else if (Session["option"].ToString() == "radIriSections")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس الوعورة IRI لمقاطعها");
                else if (Session["option"].ToString() == "radIntersectIri")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس الوعورة IRI لتقاطعاتها");
                else if (Session["option"].ToString() == "radGprSections")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس سماكة طبقات الرصف GPR لمقاطعها");
                else if (Session["option"].ToString() == "radGprIntersect")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس سماكة طبقات الرصف GPR لتقاطعاتها");
                else if (Session["option"].ToString() == "radSkidSections")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس مقاومة الانزلاق SKID لمقاطعها");
                else if (Session["option"].ToString() == "radSkidIntersects")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس مقاومة الانزلاق SKID لتقاطعاتها");
                else if (Session["option"].ToString() == "radRuttingSections")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس التخدد Rutting لمقاطعها");
                else if (Session["option"].ToString() == "radRuttingIntersects")
                    rpt.SetParameterValue("Title", "طرق رئيسية تم قياس التخدد Rutting لتقاطعاتها");
                //else
                //    rpt.SetParameterValue("Title", "");


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
                Response.Redirect("FinishedSurveyingReport.aspx", false);

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