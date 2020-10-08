using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_MaintenanceDecisionsSectionsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radByMainLanes.Checked = true;
            radByMainLanes_CheckedChanged(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            //int surveyNum = int.Parse(ddlOldSurveys.SelectedValue);
            //if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
            //if (ddlOldSurveys.SelectedIndex == -1)
            //    throw new Exception(Feedback.NoSurveyDateNum(lang)); 
            if (radByMonth.Checked)
            {
                if (DrpDwnListMonth.SelectedValue == "-1")
                    lblFeedback.Text = Feedback.NoSearchBeginDate();
                else
                {
                    DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsWithDate(DrpDwnListMonth.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionNo");
                        Session.Add("details", (radDetails.Checked ? "details" : "region"));
                        Session.Add("ReportData", dt);
                        string url = "ViewMaintenanceDescisionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }

            }
            else if (radByMainLanes.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForMainStreetLanes(int.Parse(ddlMainStreets.SelectedValue)); // surveyNum  , false
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    Session.Add("title", "");
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByIntersections.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoIntersectionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForMainStreetIntersections(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionNo.Checked)
            {
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());


                int secondID = (string.IsNullOrEmpty(ddlRegionSecondaryStreets.SelectedValue) || ddlRegionSecondaryStreets.SelectedValue == "0") ? 0 : int.Parse(ddlRegionSecondaryStreets.SelectedValue);
                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForRegion(int.Parse(ddlRegions.SelectedValue), radDetails.Checked, secondID);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", (radDetails.Checked ? "details" : "region"));
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionName.Checked)
            {
                if (ddlRegionNames.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionNames.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForSubdistrict(ddlRegionNames.SelectedValue, radDetails.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", (radDetails.Checked ? "details" : "region"));
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionsAreaName.Checked)
            {
                if (ddlDistrict.SelectedValue == "0" || string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForDistrict(ddlDistrict.SelectedValue, radDetails.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", (radDetails.Checked ? "details" : "region"));
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunicName.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForMunicipality(ddlMunic.SelectedValue, radDetails.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", (radDetails.Checked ? "details" : "region"));
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunicNameFT.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForMunicipality(ddlMunic.SelectedValue, radDetails.Checked ,raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", (radDetails.Checked ? "details" : "region"));
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radSectionsSurroundingRegion.Checked)
            {
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());
                //else if (string.IsNullOrEmpty(radlRegionSectionsSurveys.SelectedValue))
                //    throw new Exception(Feedback.NoSurveyDateNum());


                //surveyNum = int.Parse(radlRegionSectionsSurveys.SelectedValue); surveyNum
                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForRegionSurroundingSections(int.Parse(ddlRegions.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("المحيطة بالمنطقة {0}", ddlRegions.SelectedItem.Text));
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radMunicSections.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForMainStreetLanes(ddlMunic.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    string url = "ViewMaintenanceDescisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radMunicIntersects.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new MaintenanceDecisions().GetMaintenanceDecisionsForMainStreetIntersections(ddlMunic.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintenanceDescisionsReport.aspx";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintenanceDecisionsReport.aspx", false);

        //lblFeedback.Text = "";
        //ddlMainStreets.SelectedValue = "0";

        //radByMainLanes.Checked = true;
        //radByMainLanes_CheckedChanged(sender, e);

        ////radByServiceLanes.Checked = false;
        //radByIntersections.Checked = false;
        //radByRegionNo.Checked = false;
        //radByRegionName.Checked = false;
        //radByRegionsAreaName.Checked = false;
        //radByMunicName.Checked = false;
    }


    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();

            DrpDwnListMonth.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";

            ddlMainStreets.Enabled = true;
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);

            ddlRegions_SelectedIndexChanged(sender, e);
            ShowHideRegionLevelOptions();

            //ddlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }    

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        radByMainLanes_CheckedChanged(sender, e);
        ShowHideRegionLevelOptions();
    }

    private void ShowHideRegionLevelOptions()
    {
        pnlRegionOptions.Visible = (radByRegionNo.Checked || radByRegionName.Checked || radByRegionsAreaName.Checked || radByMunicName.Checked);
        ddlRegionSecondaryStreets.Visible = radDetails.Checked && radByRegionNo.Checked;
        ddlRegionSecondaryStreets.SelectedValue = "0";
    }

    protected void radByRegionNo_CheckedChanged(object sender, EventArgs e)
    {
        raddtpFrom.Enabled = false;
        raddtpTo.Enabled = false;
        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets.Enabled = false;
        DrpDwnListMonth.Enabled = false;
        ddlRegions.Enabled = true;
        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        ddlRegionNames.SelectedValue = "0";
        ddlRegionNames.Enabled = false;

        ddlDistrict.SelectedValue = "0";
        ddlDistrict.Enabled = false;

        ddlMunic.SelectedValue = "0";
        ddlMunic.Enabled = false;

        ShowHideRegionLevelOptions();

        //ddlOldSurveys.Visible = true;
        //radlRegionSectionsSurveys.Visible = false;
    }

    protected void radByRegionName_CheckedChanged(object sender, EventArgs e)
    {
        raddtpFrom.Enabled = false;
        raddtpTo.Enabled = false;
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlRegionNames.Enabled = true;
        ddlMunic.Enabled = false;
        ddlDistrict.Enabled = false;
        DrpDwnListMonth.Enabled = false;
        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlRegionNames_SelectedIndexChanged(sender, e);

        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";

        ShowHideRegionLevelOptions();

        //ddlOldSurveys.Visible = true;
        //radlRegionSectionsSurveys.Visible = false;
    }

    protected void radByMunicName_CheckedChanged(object sender, EventArgs e)
    {
        raddtpFrom.Enabled = false;
        raddtpTo.Enabled = false;
        ddlMainStreets.Enabled = false;
        DrpDwnListMonth.Enabled = false;
        ddlRegions.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlMunic.Enabled = true;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlMunic_SelectedIndexChanged(sender, e);
        ddlDistrict.SelectedValue = "0";

        ShowHideRegionLevelOptions();

        //ddlOldSurveys.Visible = true;
        //radlRegionSectionsSurveys.Visible = false;
    }


    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (radSectionsSurroundingRegion.Checked)
            {
                //radlRegionSectionsSurveys.DataBind();
                //radlRegionSectionsSurveys.SelectedIndex = (radlRegionSectionsSurveys.Items.Count == 0) ? -1 : 0;
            }
            else
            {
                //ddlOldSurveys.Items.Clear();
                //ddlOldSurveys.Items.Add(new ListItem("المسح الأخير", "0"));
                //ddlOldSurveys.DataBind();
            }

            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();

            //lblFeedback.Text = "";

            //radlOldSurveys.DataBind();
            //if (radlOldSurveys.Items.Count == 0)
            //    radlOldSurveys.SelectedIndex = -1;
            //else
            //    radlOldSurveys.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlRegionNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void radByRegionsAreaName_CheckedChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        DrpDwnListMonth.Enabled = false;
        ddlDistrict.Enabled = true;
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlMunic.Enabled = false;
        raddtpFrom.Enabled = false;
        raddtpTo.Enabled = false;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";
        ddlDistrict_SelectedIndexChanged(sender, e);

        ShowHideRegionLevelOptions();

        //radlRegionSectionsSurveys.Visible = false;
        //ddlOldSurveys.Visible = true;
    }

    protected void radDetails_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegionSecondaryStreets.Visible = radDetails.Checked && radByRegionNo.Checked;
    }

    protected void radTotal_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegionSecondaryStreets.Visible = false;
    }

    protected void radSectionsSurroundingRegion_CheckedChanged(object sender, EventArgs e)
    {
        radByRegionNo_CheckedChanged(sender, e);

        //radlRegionSectionsSurveys.Visible = true;
        //ddlOldSurveys.Visible = false;
    }

    protected void radByMonth_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            lblFeedback.Text = "";
            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlMunic.Enabled = false;
            DrpDwnListMonth.Enabled = true;
            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            DrpDwnListMonth.Enabled = true;
            //ShowHideRegionLevelOptions();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void radByMunicNameFT_CheckedChanged(object sender, EventArgs e)
    {

        ddlMainStreets.Enabled = false;
        DrpDwnListMonth.Enabled = false;
        ddlRegions.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlMunic.Enabled = true;
        raddtpFrom.Enabled = true;
        raddtpTo.Enabled = true;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlMunic_SelectedIndexChanged(sender, e);
        ddlDistrict.SelectedValue = "0";

        ShowHideRegionLevelOptions();

        //ddlOldSurveys.Visible = true;
        //radlRegionSectionsSurveys.Visible = false;

    }
}