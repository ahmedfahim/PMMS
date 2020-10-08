using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_MonitoringRoundsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radByMainLanes_CheckedChanged(sender, e);
        }
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = true;

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();
            ddlMainStreets.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";
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

    protected void radByRegionNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlRegions.Enabled = true;
            ddlRegions.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlRegionNames.Enabled = true;
            ddlRegionNames.SelectedValue = "0";

            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionsAreaName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlDistrict.Enabled = true;
            ddlDistrict.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByMunicName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlMunic.Enabled = true;
            ddlMunic.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
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

                DataTable dt = new MainStreetSection().GetAllSectionsReport(false, false, true, int.Parse(ddlMainStreets.SelectedValue), false, 0);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByMainLanes");
                    string url = "ViewMonitoringRoundsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByIntersections.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new IntersectionSamples().GetIntersectionSamplesByMainStreet(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByIntersections");
                    string url = "ViewMonitoringRoundsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionNo.Checked)
            {
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new SecondaryStreets().Search(int.Parse(ddlRegions.SelectedValue), "", "", "");
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByRegionNo");
                    string url = "ViewMonitoringRoundsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionName.Checked)
            {
                if (ddlRegionNames.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionNames.SelectedValue))
                    throw new Exception(Feedback.NoRegionNameSelected());

                DataTable dt = new SecondaryStreets().Search(0, ddlRegionNames.SelectedValue, "", "");
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByRegionName");
                    string url = "ViewMonitoringRoundsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionsAreaName.Checked)
            {
                if (ddlDistrict.SelectedValue == "0" || string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                    throw new Exception(Feedback.NoRegionsAreaNameSelected());

                DataTable dt = new SecondaryStreets().Search(0, "", ddlDistrict.SelectedValue, "");
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByRegionsAreaName");
                    string url = "ViewMonitoringRoundsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunicName.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new SecondaryStreets().Search(0, "", "", ddlMunic.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByMunicName");
                    string url = "ViewMonitoringRoundsReport.aspx";
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
        Response.Redirect("MonitoringRoundsReport.aspx", false);
    }

}
