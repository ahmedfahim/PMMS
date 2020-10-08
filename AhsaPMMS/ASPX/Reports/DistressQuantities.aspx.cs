using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL.DistressEntry;

public partial class ASPX_Reports_DistressQuantities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            radSections_CheckedChanged(sender, e);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            //if (ddlDistresses.SelectedValue == "0")
            //    throw new Exception(Feedback.NoDistressSelected());

            string reportType = "";
            DistressQntyReportType type = DistressQntyReportType.None;

            if (radSections.Checked)
            {
                reportType = "radSections";
                type = DistressQntyReportType.MainStreetSections;
            }
            else if (radIntersects.Checked)
            {
                reportType = "radIntersects";
                type = DistressQntyReportType.MainStreetIntersects;
            }
            else if (radRegion.Checked)
            {
                reportType = "radRegion";
                type = DistressQntyReportType.Region;
            }
            else if (radSubdist.Checked)
            {
                reportType = "radRegion";
                type = DistressQntyReportType.Subdistrict;
            }
            else if (radDist.Checked)
            {
                reportType = "radRegion";
                type = DistressQntyReportType.District;
            }
            else if (radMunic.Checked)
            {
                reportType = "radRegion";
                type = DistressQntyReportType.Municipality;
            }
            else if (radMunicSections.Checked)
            {
                reportType = "radSections";
                type = DistressQntyReportType.SectionsInMunicipality;
            }


            DataTable dt = new DistressEntry().GetDistressQnty(type, int.Parse(ddlMainStreets.SelectedValue), int.Parse(ddlRegions.SelectedValue), ddlSubDist.SelectedValue,
                ddlDistrict.SelectedValue, ddlMunic.SelectedValue, int.Parse(ddlDistresses.SelectedValue));

            if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(reportType))
            {
                Session.Add("ReportData", dt);
                Session.Add("option", reportType);
                string url = "ViewDistressQuantitiesReport.aspx";
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
        Response.Redirect("DistressQuantities.aspx", false);
    }

    protected void radSections_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
        ddlMainStreets.SelectedValue = "0";

        ddlRegions.Enabled = false;
        ddlRegions.SelectedValue = "0";

        ddlSubDist.Enabled = false;
        ddlSubDist.SelectedValue = "0";

        ddlDistrict.Enabled = false;
        ddlDistrict.SelectedValue = "0";

        ddlMunic.Enabled = false;
        ddlMunic.SelectedValue = "0";
    }

    protected void radIntersects_CheckedChanged(object sender, EventArgs e)
    {
        radSections_CheckedChanged(sender, e);
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = true;
        ddlRegions.SelectedValue = "0";
        ddlSubDist.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = false;
    }

    protected void radSubdist_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlSubDist.Enabled = true;
        ddlSubDist.SelectedValue = "0";
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = false;
    }

    protected void radDist_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlSubDist.Enabled = false;
        ddlDistrict.Enabled = true;
        ddlDistrict.SelectedValue = "0";
        ddlMunic.Enabled = false;
    }

    protected void radMunic_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlSubDist.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = true;
        ddlMunic.SelectedValue = "0";
    }

    protected void radMunicSections_CheckedChanged(object sender, EventArgs e)
    {
        radMunic_CheckedChanged(sender, e);
    }

}