using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_FinishedSurveyingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radSection.Checked)
            {
                DataTable dt = new DistressSurvey().GetSurveyedAreas(RoadType.Section);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "section");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersection.Checked)
            {

                DataTable dt = new DistressSurvey().GetSurveyedAreas(RoadType.Intersect);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "intersect");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionSecondary.Checked)
            {
                DataTable dt = new DistressSurvey().GetSurveyedAreas(RoadType.RegionSecondarySt);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "region");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radTrafficCounting.Checked)
            {
                //DataTable dt = new DistressSurvey().GetSurveyedAreas(MachineSurveyType.SectionTrafficCounting);
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.SectionTrafficCounting);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "traffic");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSectionPhotos.Checked)
            {
                DataTable dt = new ImagesGallery().RoadNetworkHavingPhotos(RoadType.MainStreet);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "sectionPhotos");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionPhotos.Checked)
            {
                DataTable dt = new ImagesGallery().RoadNetworkHavingPhotos(RoadType.RegionSecondarySt);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "regionPhotos");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSectionQc.Checked)
            {
                DataTable dt = new QcCheck().GetRoadNetworkHavingQCheck(RoadType.Section);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "sectionQc");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersectQc.Checked)
            {
                DataTable dt = new QcCheck().GetRoadNetworkHavingQCheck(RoadType.Intersect);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "intersectQc");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionQc.Checked)
            {
                DataTable dt = new QcCheck().GetRoadNetworkHavingQCheck(RoadType.RegionSecondarySt);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "regionQc");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radReSurveyIntersect.Checked || radReSurveyRegions.Checked || radReSurveySections.Checked)
            {
                DataTable dt = new DistressSurvey().GetNetworkItemMustReSurvey(radReSurveySections.Checked, radReSurveyIntersect.Checked, radReSurveyRegions.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", (radReSurveySections.Checked ? "radReSurveySections" : (radReSurveyIntersect.Checked ? "radReSurveyIntersect" : (radReSurveyRegions.Checked ? "radReSurveyRegions" : ""))));
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radNonSurveyedSections.Checked || radNonSurveyedIntersects.Checked || radNonSurveyedRegions.Checked || radClosedRegions.Checked)
            {
                DataTable dt = new DistressSurvey().GetNonSurveyedRoadNetwork(radNonSurveyedSections.Checked, radNonSurveyedIntersects.Checked, radNonSurveyedRegions.Checked,
                    radNonCompleteSurveyingRegions.Checked, radClosedRegions.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", (radNonSurveyedSections.Checked ? "radNonSurveyedSections" : (radNonSurveyedIntersects.Checked ? "radNonSurveyedIntersects" : (radNonSurveyedRegions.Checked || radClosedRegions.Checked ? "radNonSurveyedRegions" : ""))));
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radNonCompleteSurveyingRegions.Checked)
            {
                DataTable dt = new DistressSurvey().GetNonSurveyedRoadNetwork(radNonSurveyedSections.Checked, radNonSurveyedIntersects.Checked, radNonSurveyedRegions.Checked,
                    radNonCompleteSurveyingRegions.Checked, radClosedRegions.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radNonSurveyedRegions");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSurveyedSections.Checked || radSurveyedIntersects.Checked)
            {
                DataTable dt = new DistressSurvey().GetSurveyedRoadNetwork(radSurveyedSections.Checked, radSurveyedIntersects.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", (radSurveyedSections.Checked ? "radSurveyedSections" : (radSurveyedIntersects.Checked ? "radSurveyedIntersects" : "")));
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radNonCompleteSections.Checked || radNonCompleteIntersects.Checked)
            {
                DataTable dt = new DistressSurvey().GetNonCompleteSurveyStreets(radNonCompleteIntersects.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "section");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            if (radNonSurveySectionsStreets.Checked || radNonSurveyIntersectStreets.Checked)
            {
                DataTable dt = new DistressSurvey().GetNonSurveyedStreets(radNonSurveyIntersectStreets.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "section");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }

            else if (radSectionNoPhotos.Checked || radIntersectNoPhotos.Checked || radRegionNoPhotos.Checked)
            {
                DataTable dt = new ImagesGallery().RoadNetworkHavingNoPhotos(radSectionNoPhotos.Checked, radIntersectNoPhotos.Checked, radRegionNoPhotos.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", (radSectionNoPhotos.Checked ? "radSectionNoPhotos" : (radIntersectNoPhotos.Checked ? "radIntersectNoPhotos" : (radRegionNoPhotos.Checked ? "radRegionNoPhotos" : ""))));
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }

            else if (radFwd.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.FWD);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radFwd");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIriSections.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.IRI_Sections);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radIriSections");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersectIri.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.IRI_Intersects);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radIntersectIri");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radGprSections.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.GPR_Sections);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radGprSections");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radGprIntersect.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.GPR_Intersects);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radGprIntersect");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSkidSections.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.SKID_Sections);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radSkidSections");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSkidIntersects.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.SKID_Intersects);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radSkidIntersects");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRuttingSections.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.Rutting_Sections);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radRuttingSections");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRuttingIntersects.Checked)
            {
                DataTable dt = new MachineSurveyRoadNetworkReports().GetSurveyedAreas(MachineSurveyType.Rutting_Intersects);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radRuttingIntersects");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnNewSurveyCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinishedSurveyingReport.aspx", false);
    }

}