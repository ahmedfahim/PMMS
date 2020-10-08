using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_SurveyingFormsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radSectionIntersects_CheckedChanged(sender, e);
        }
    }

    protected void radIntersects_CheckedChanged(object sender, EventArgs e)
    {
        radSectionIntersects_CheckedChanged(sender, e);

        radSectionMap.Enabled = false;
        radSectionMap.Checked = false;
        radDetailsForm.Checked = true;
    }

    protected void radSectionIntersects_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
        ddlMainStreets.SelectedValue = "0";
        ddlRegions.Enabled = false;

        radSectionMap.Enabled = true;
        radSectionMap.Checked = false;
        radDetailsForm.Checked = true;
    }

    protected void radRegions_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegions.Enabled = true;
        ddlRegions.SelectedValue = "0";
        ddlMainStreets.Enabled = false;

        radSectionMap.Enabled = false;
        radSectionMap.Checked = false;
        radDetailsForm.Checked = true;
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            string formType = radDetailsForm.Checked ? "Details" : (radSurveyForm.Checked ? "Survey" : "Map");
            DataTable dt = new DataTable();

            if ((radSection.Checked || radIntersects.Checked) && (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue)))
                throw new Exception(Feedback.NoMainStreetSelected());
            else if (radRegions.Checked && (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue)))
                throw new Exception(Feedback.NoRegionSelected());


            if (radSection.Checked)
            {
                if (radSurveyForm.Checked)
                    dt = new LaneSample().AdvancedSearch(int.Parse(ddlMainStreets.SelectedValue));
                else if (radDetailsForm.Checked)
                    dt = new MainStreetSection().GetMainStSectionsFullInfo(int.Parse(ddlMainStreets.SelectedValue));
                else if (radSectionMap.Checked)
                    dt = new MainStreetSection().GetMainStreetSections(int.Parse(ddlMainStreets.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radSection");
                    Session.Add("type", formType);
                    string url = "ViewSurveyingFormsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radIntersects.Checked)
            {
                if (radSurveyForm.Checked)
                    dt = new IntersectionSamples().GetIntersectionSamplesByMainStreet(int.Parse(ddlMainStreets.SelectedValue));
                else if (radDetailsForm.Checked)
                    dt = new Intersection().GetMainStIntersectionsFullInfo(int.Parse(ddlMainStreets.SelectedValue));


                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radIntersects");
                    Session.Add("type", formType);
                    string url = "ViewSurveyingFormsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegions.Checked)
            {
                dt = new SecondaryStreets().GetRegionSecondaryStreetsFullInfo(int.Parse(ddlRegions.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radRegions");
                    Session.Add("type", formType);
                    string url = "ViewSurveyingFormsReport.aspx";
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
        Response.Redirect("SurveyingFormsReport.aspx", false);
    }

}
