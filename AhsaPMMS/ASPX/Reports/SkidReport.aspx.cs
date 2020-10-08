using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;


public partial class ASPX_Reports_SkidReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radByMainLanes.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new SkidReport().SkidReportForMainStreet(ddlMainStreets.SelectedValue, false, false, false);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewSkidReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByIntersections.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new SkidReport().SkidReportForMainStreet(ddlMainStreets.SelectedValue, true, false, false);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewSkidReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByAllLanes.Checked)
            {
                DataTable dt = new SkidReport().SkidReportForMainStreet("0", false, true, false);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewSkidReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByAllIntersections.Checked)
            {
                DataTable dt = new SkidReport().SkidReportForMainStreet("0", false, false, true);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewSkidReport.aspx";
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

        ddlMainStreets.Enabled = true;
        ddlMainStreets.SelectedValue = "0";

        radByMainLanes.Checked = true;
        radByIntersections.Checked = false;
    }

    protected void radByAllLanes_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
    }

    protected void radByAllIntersections_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
    }

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
    }

}