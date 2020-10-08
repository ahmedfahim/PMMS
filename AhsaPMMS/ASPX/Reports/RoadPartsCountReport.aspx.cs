using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_RoadPartsCountReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
        {
            radByMainLanes.Checked = true;
            radByMainLanes_CheckedChanged(sender, e);
        }
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            pnlReportType.Visible = true;
            radServiceMarks.Checked = true;

            ddlMainStreets.Enabled = true;
            ddlMainStreetSection.Enabled = true;
            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetIntersection.Enabled = false;
            ddlMainStreetIntersection.SelectedValue = "0";

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);

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

    protected void radByRegionNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            pnlReportType.Visible = false;
            radServiceMarks.Checked = true;

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlMainStreetSection.Enabled = false;
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetIntersection.Enabled = false;
            ddlMainStreetIntersection.SelectedValue = "0";

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
            pnlReportType.Visible = false;
            radServiceMarks.Checked = true;

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlMainStreetSection.Enabled = false;
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetIntersection.Enabled = false;
            ddlMainStreetIntersection.SelectedValue = "0";

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
            pnlReportType.Visible = false;
            radServiceMarks.Checked = true;

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlMainStreetSection.Enabled = false;
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetIntersection.Enabled = false;
            ddlMainStreetIntersection.SelectedValue = "0";

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
            pnlReportType.Visible = false;
            radServiceMarks.Checked = true;

            ddlMainStreets.Enabled = false;
            ddlMainStreets.SelectedValue = "0";

            ddlMainStreetSection.Enabled = false;
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetIntersection.Enabled = false;
            ddlMainStreetIntersection.SelectedValue = "0";

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

            if (radByMainLanes.Checked || radByIntersections.Checked)
            {
                DataTable dt = new MainStreetSection().GetStatsReport(int.Parse(ddlMainStreets.SelectedValue), radByIntersections.Checked, int.Parse(ddlMainStreetSection.SelectedValue),
                    int.Parse(ddlMainStreetIntersection.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", (radByIntersections.Checked ? "radByIntersections" : "radByMainLanes"));
                    Session.Add("type", (radByIntersections.Checked ? "marks" :
                        (radLenWid.Checked ? "widths" : (radServiceMarks.Checked ? "marks" : (radLandMarks.Checked ? "landMarks" : "")))));

                    string url = "ViewRoadPartsCountReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }

            else if (radByRegionNo.Checked)
            {
                if (ddlRegions.SelectedValue == "0")
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new SecondaryStreets().GetStatsReport(int.Parse(ddlRegions.SelectedValue), "", "", "");
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByRegionNo");
                    Session.Add("type", "widths");

                    string url = "ViewRoadPartsCountReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionName.Checked)
            {
                if (ddlRegionNames.SelectedValue == "0")
                    throw new Exception(Feedback.NoRegionNameSelected());

                DataTable dt = new SecondaryStreets().GetStatsReport(0, ddlRegionNames.SelectedValue, "", "");
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByRegionName");
                    Session.Add("type", "widths");

                    string url = "ViewRoadPartsCountReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionsAreaName.Checked)
            {
                if (ddlDistrict.SelectedValue == "0")
                    throw new Exception(Feedback.NoRegionsAreaNameSelected());

                DataTable dt = new SecondaryStreets().GetStatsReport(0, "", ddlDistrict.SelectedValue, "");
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByRegionsAreaName");
                    Session.Add("type", "widths");

                    string url = "ViewRoadPartsCountReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunicName.Checked)
            {
                if (ddlMunic.SelectedValue == "0")
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new SecondaryStreets().GetStatsReport(0, "", "", ddlMunic.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "radByMunicName");
                    Session.Add("type", "widths");

                    string url = "ViewRoadPartsCountReport.aspx";
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
        Response.Redirect("RoadPartsCountReport.aspx", false);
    }

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            radServiceMarks.Checked = true;
            pnlReportType.Visible = false;

            ddlMainStreets.Enabled = true;
            ddlMainStreetSection.Enabled = false;
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetIntersection.Enabled = true;
            ddlMainStreetIntersection.SelectedValue = "0";

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);

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

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (radByMainLanes.Checked)
            {
                ddlMainStreetSection.Items.Clear();
                ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetSection.DataBind();
                ddlMainStreetSection.SelectedValue = "0";
            }
            else if (radByIntersections.Checked)
            {
                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetIntersection.DataBind();
                ddlMainStreetIntersection.SelectedValue = "0";
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}
