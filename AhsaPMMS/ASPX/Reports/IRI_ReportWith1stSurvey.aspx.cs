using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_IRI_ReportWith1stSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            string select = Session["lang"].ToString().Contains("ar") ? "اختيار" : "select";

            ddlMainStreets.Enabled = true;

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new ListItem(select, "0"));
            ddlMainStreets.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        radByMainLanes_CheckedChanged(sender, e);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            //string lang = Session["lang"].ToString();

            if (!(radByAllLanes.Checked || radByAllIntersects.Checked) && ddlMainStreets.SelectedValue == "0")
                throw new Exception(Feedback.NoMainStreetSelected());
            else
                if (radlOldSurveys.SelectedIndex == -1)
                    throw new Exception(Feedback.NoSurveyDateNum());

            if (radByMainLanes.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), false, false, false);
                if (dt.Rows.Count == 0)
                    lblFeedback.Text = Feedback.NoData();
                else
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
            }
            else if (radByIntersections.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), true, false, false);
                if (dt.Rows.Count == 0)
                    lblFeedback.Text = Feedback.NoData();
                else
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
            }
            else if (radByAllLanes.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), false, true, false);
                if (dt.Rows.Count == 0)
                    lblFeedback.Text = Feedback.NoData();
                else
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
            }
            else if (radByAllIntersects.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), false, false, true);
                if (dt.Rows.Count == 0)
                    lblFeedback.Text = Feedback.NoData();
                else
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        radByMainLanes.Checked = true;
        radByIntersections.Checked = false;

        radByMainLanes_CheckedChanged(sender, e);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            radlOldSurveys.DataBind();
            if (radlOldSurveys.Items.Count > 0)
                radlOldSurveys.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByAllLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = false;

            radlOldSurveys.DataBind();
            if (radlOldSurveys.Items.Count > 0)
                radlOldSurveys.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByAllIntersects_CheckedChanged(object sender, EventArgs e)
    {
        radByAllLanes_CheckedChanged(sender, e);
    }

}