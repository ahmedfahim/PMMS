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
            if (radByMonth.Checked)
            {
                if (DrpDwnListMonth.SelectedValue == "-1" || RadioButtonList1.SelectedValue==string.Empty)
                    lblFeedback.Text = Feedback.NoSearchBeginDate();
                else
                {
                    DataTable dt;
                    lblFeedback.Text = "";
                   
                    if (DrpDwnListMonth.SelectedValue == "0")
                    {
                        if (RadioButtonList1.SelectedValue.StartsWith("0") && RadioButtonList1.SelectedValue.Length == 2)
                            dt = new DistressSurvey().GetSurveyedAreasWithDateInterSetions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "00" ? null : int.Parse(RadioButtonList1.SelectedValue).ToString(), true, true, true);
                        else
                            dt = new DistressSurvey().GetSurveyedAreasWithDateRegions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "0" ? null : RadioButtonList1.SelectedValue, true, true);
                        //dt.Merge(dt0, true);
                    }
                    else
                    {
                        if (RadioButtonList1.SelectedValue.StartsWith("0") && RadioButtonList1.SelectedValue.Length == 2)
                            dt = new DistressSurvey().GetSurveyedAreasWithDateInterSetions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "00" ? null : int.Parse(RadioButtonList1.SelectedValue).ToString(), false, true, true);
                        else
                            dt = new DistressSurvey().GetSurveyedAreasWithDateRegions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "0" ? null : RadioButtonList1.SelectedValue, false, true);
                        //dt.Merge(dt0, true);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("ReportData", dt);
                        Session.Add("option", RadioButtonList1.SelectedValue.StartsWith("0") && RadioButtonList1.SelectedValue.Length == 2 ? "intersectregion" : "region");
                        string url = "ViewFinishedSurveyingReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
            }
            else if (radSection.Checked)
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
            else if (radByDate.Checked)
            {
                SpecificDate();
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
                    Session.Add("option", (radNonSurveyedSections.Checked ? "radNonSurveyedSections" : (radNonSurveyedIntersects.Checked ? "radNonSurveyedIntersects" : (radNonSurveyedRegions.Checked ? "radNonSurveyedRegions" : (radClosedRegions.Checked ? "radClosedRegions" : "")))));
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
                    Session.Add("option", (radClosedRegions.Checked ? "radClosedRegions" : "radNonCompleteSurveyingRegions"));
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
                    Session.Add("option", radNonCompleteSections.Checked ? "radNonCompleteSections" : (radNonCompleteIntersects.Checked ? "radNonCompleteIntersects" : ""));
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
                    Session.Add("option", radNonSurveySectionsStreets.Checked ? "radNonSurveySectionsStreets" : (radNonSurveyIntersectStreets.Checked ? "radNonSurveyIntersectStreets" : ""));
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

            else if (radSectionSurveyedNoPhotos.Checked || radIntersectSurveyedNoPhotos.Checked || radRegionSurveyedNoPhotos.Checked)
            {
                DataTable dt = new ImagesGallery().RoadNetworkSurveyedHavingNoPhotos(radSectionSurveyedNoPhotos.Checked, radIntersectSurveyedNoPhotos.Checked, radRegionSurveyedNoPhotos.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", (radSectionSurveyedNoPhotos.Checked ? "radSectionNoPhotos" : (radIntersectSurveyedNoPhotos.Checked ? "radIntersectNoPhotos" : (radRegionSurveyedNoPhotos.Checked ? "radRegionNoPhotos" : ""))));
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
    protected void SpecificDate()
    {

        if (raddtpFrom.SelectedDate == null)
            throw new Exception(Feedback.NoSearchBeginDate());
        else if (raddtpTo.SelectedDate == null)
            throw new Exception(Feedback.NoSearchEndDate());
        else if (raddtpFrom.SelectedDate > raddtpTo.SelectedDate)
            throw new Exception(Feedback.SearchBeginDateAfterEndDate());

        DataTable dt = new DistressSurvey().GetSurveyedAreasWithDate(raddtpFrom.SelectedDate, raddtpTo.SelectedDate.Value.AddDays(1));
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
    protected void radByDate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            DrpDwnListMonth.SelectedValue = "-1";
            DrpDwnListMonth.Enabled = false;
         
            raddtpFrom.Enabled = true;
            raddtpTo.Enabled = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void radByMonth_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            raddtpFrom.SelectedDate = null;
            raddtpTo.SelectedDate = null;
            DrpDwnListMonth.Enabled = true;
            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;
            RadioButtonList1.Enabled = true;
        
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
}