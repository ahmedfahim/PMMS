using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_IRI_Report : System.Web.UI.Page
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
            ddlMainStreets.Enabled = true;

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
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

            if (!(radByAllLanes.Checked || radByAllIntersects.Checked) && (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue)))
                throw new Exception(Feedback.NoMainStreetSelected());
            //else
            //    if (radlOldSurveys.SelectedIndex == -1)
            //        throw new Exception(Feedback.NoSurveyDateNum());
            // int.Parse(radlOldSurveys.SelectedValue),

            if (radByMainLanes.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, false, false, false);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByIntersections.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, true, false, false);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByAllLanes.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, false, true, false);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByAllIntersects.Checked)
            {
                DataTable dt = new IriReport().IriReportForMainStreet(ddlMainStreets.SelectedValue, false, false, true);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewIriReport.aspx";
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

            //radlOldSurveys.DataBind();
            //if (radlOldSurveys.Items.Count > 0)
            //    radlOldSurveys.SelectedIndex = 0;
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

            //radlOldSurveys.DataBind();
            //if (radlOldSurveys.Items.Count > 0)
            //    radlOldSurveys.SelectedIndex = 0;

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