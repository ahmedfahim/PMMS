using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_TrafficCountingOnSectionsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            //raddtpFrom.SelectedDate = DateTime.Today.AddMonths(-1);
            //raddtpTo.SelectedDate = DateTime.Today;
            if (!IsPostBack)
                radMainSt_CheckedChanged(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            DataTable dt = new DataTable();
            if (radMainSt.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                dt = new TrafficCounting().GetTrafficCountingForMainStreet(int.Parse(ddlMainStreets.SelectedValue));
            }
            else if (chkDates.Checked)
            {
                // int.Parse(ddlMainStreets.SelectedValue), 
                dt = new TrafficCounting().GetTrafficCountingForMainStreet(raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
            }
            else if (radSectionsSurroundingRegion.Checked)
            {
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                dt = new TrafficCounting().GetTrafficCountingForSectionsSurroundingRegion(int.Parse(ddlRegions.SelectedValue));
            }
            else if (radAll.Checked)
                dt = new TrafficCounting().GetTrafficCountingForMainStreet(0);


            if (dt.Rows.Count > 0)
            {
                Session.Add("ReportData", dt);
                string url = "ViewTrafficCountingReport.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else
                lblFeedback.Text = Feedback.NoData();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrafficCountingOnSectionsReport.aspx", false);       
    }

    protected void chkDates_CheckedChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        ddlMainStreets.Enabled = !(chkDates.Checked || radSectionsSurroundingRegion.Checked || radAll.Checked);
        ddlRegions.Enabled = radSectionsSurroundingRegion.Checked;
        raddtpFrom.Enabled = chkDates.Checked;
        raddtpTo.Enabled = chkDates.Checked;
    }

    protected void radMainSt_CheckedChanged(object sender, EventArgs e)
    {
        chkDates_CheckedChanged(sender, e);
    }

    protected void radSectionsSurroundingRegion_CheckedChanged(object sender, EventArgs e)
    {
        chkDates_CheckedChanged(sender, e);
    }

    protected void radAll_CheckedChanged(object sender, EventArgs e)
    {
        chkDates_CheckedChanged(sender, e);
    }

}