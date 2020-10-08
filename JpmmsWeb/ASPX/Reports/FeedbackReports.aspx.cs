using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_FeedbackReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
        {
            radSection_CheckedChanged(sender, e);

            rdtpFinishDateTo.SelectedDate = DateTime.Today;
            rdtpFinishDate.SelectedDate = DateTime.Today.AddYears(-1);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";
            if (rdtpFinishDateTo.SelectedDate < rdtpFinishDate.SelectedDate)
                throw new Exception("الرجاء إدخال مدى تواريخ البحث بصورة صحيحة ");

            DataTable dt = new MaintenanceFeedback().Search(radSection.Checked, radIntersect.Checked, radRegion.Checked, ddlMainStreets.SelectedValue,
                ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlSamples.SelectedValue, ddlRegions.SelectedValue,
                ddlRegionSecondaryStreets.SelectedValue, rdtpFinishDate.SelectedDate, rdtpFinishDateTo.SelectedDate, int.Parse(ddlMaintDecisions.SelectedValue),
                int.Parse(ddlContractors.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                // prepare to show report
                string type = (radSection.Checked ? "radSection" : (radIntersect.Checked ? "radIntersect" : (radRegion.Checked ? "radRegion" : "")));
                Session.Add("type", type);
                Session.Add("ReportData", dt);
                string url = "ViewFeedbackReports.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else
                lblAddFeedback.Text = Feedback.NoData();

        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("FeedbackReports.aspx", false);
    }

    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        lblAddFeedback.Text = "";

        pnlMainSt.Visible = (radSection.Checked || radIntersect.Checked);
        ddlMainStreetSection.Visible = radSection.Checked;
        ddlMainStreetIntersection.Visible = radIntersect.Checked;

        ddlRegions.Enabled = radRegion.Checked;
        ddlRegionSecondaryStreets.Enabled = radRegion.Checked;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlMainStreetSection.SelectedValue = "0";
        ddlMainStreetSection_SelectedIndexChanged(sender, e);

        ddlMainStreetIntersection.SelectedValue = "0";
        ddlMainStreetIntersection_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void radIntersect_CheckedChanged(object sender, EventArgs e)
    {
        radSection_CheckedChanged(sender, e);
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        radSection_CheckedChanged(sender, e);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";
            if (radSection.Checked)
            {
                ddlMainStreetSection.Items.Clear();
                ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetSection.DataBind();
                ddlMainStreetSection.SelectedValue = "0";
            }
            else if (radIntersect.Checked)
            {
                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetIntersection.DataBind();
                ddlMainStreetIntersection.SelectedValue = "0";
            }

            ddlMainStreetSection_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";

            ddlSamples.Items.Clear();
            ddlSamples.Items.Add(new ListItem("اختيار", "0"));
            ddlSamples.DataBind();
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreetSection_SelectedIndexChanged(sender, e);
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();
            ddlRegionSecondaryStreets.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

}