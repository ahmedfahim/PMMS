using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Reports_MaintenancePrioritiesReport : System.Web.UI.Page
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

            ddlMainStreets_SelectedIndexChanged(sender, e);
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

            ddlMainStreets_SelectedIndexChanged(sender, e);           
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

            ddlMainStreets_SelectedIndexChanged(sender, e);
      
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

            ddlMainStreets_SelectedIndexChanged(sender, e);       
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

            //ddlOldSurveys.DataBind();
            ddlMainStreets_SelectedIndexChanged(sender, e);

            //ddlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;
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
            lblFeedback.Text = "";

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

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void ddlRegionNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            //int surveyNo = int.Parse(ddlOldSurveys.SelectedValue);


            if (radByMainLanes.Checked)
            {
                //if (ddlMainStreets.SelectedValue == "0")
                //    throw new Exception(Feedback.NoMainStreetSelected(lang));

                int mainStID = int.Parse(ddlMainStreets.SelectedValue);
                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMainStreetReport(mainStID, false, false, true);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("title", "");
                    Session.Add("ReportData", dt);
                    string url = "../Sections/ViewSectionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByIntersections.Checked)
            {
                //if (ddlMainStreets.SelectedValue == "0")
                //    throw new Exception(Feedback.NoMainStreetSelected(lang)); surveyNo

                int mainStID = int.Parse(ddlMainStreets.SelectedValue);
                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMainStreetIntersectReport(mainStID, false, false, true);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    string url = "../Intersections/ViewIntersectionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionNo.Checked)
            {
                //if (ddlRegions.SelectedValue == "0")
                //    throw new Exception(Feedback.NoRegionSelected(lang));

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(ddlRegions.SelectedValue, false, false, true, RegionReportLevel.Region);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = "../Regions/ViewRegionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByRegionName.Checked)
            {
                //if (ddlRegionNames.SelectedValue == "0")
                //    throw new Exception(Feedback.NoRegionNameSelected(lang));

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(ddlRegionNames.SelectedValue, false, false, true, RegionReportLevel.Subdistrict);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = "../Regions/ViewRegionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByRegionsAreaName.Checked)
            {
                //if (ddlDistrict.SelectedValue == "0")
                //    throw new Exception(Feedback.NoRegionsAreaNameSelected(lang));

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(ddlDistrict.SelectedValue, false, false, true, RegionReportLevel.District);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = "../Regions/ViewRegionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByMunicName.Checked)
            {
                //if (ddlMunic.SelectedValue == "0")
                //    throw new Exception(Feedback.NoMuniciplaitySelected(lang));

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(ddlMunic.SelectedValue, false, false, true, RegionReportLevel.Municipality);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = "../Regions/ViewRegionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSectionsSurroundingRegion.Checked)
            {
                int regionID = int.Parse(ddlRegions.SelectedValue);
                //surveyNo = int.Parse(radlRegionSectionsSurveys.SelectedValue);        surveyNo

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForSectionSurroundingRegionReport(regionID, false, false, true);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("المحيطة بالمنطقة {0}", ddlRegions.SelectedItem.Text));
                    string url = "../Sections/ViewSectionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radMunicSections.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMunicSectionReport(ddlMunic.SelectedValue, false, false, true);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    string url = "../Sections/ViewSectionMaintenancePrioritiesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radMunicIntersects.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForMainStreetIntersectReport(ddlMunic.SelectedValue, false, false, true);
                if (dt.Rows.Count > 0)
                {
                    //Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    string url = "../Sections/ViewSectionMaintenancePrioritiesReport.aspx";
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
        Response.Redirect("MaintenancePrioritiesReport.aspx", false);

        //lblFeedback.Text = "";

        //radByMunicName.Checked = false;
        //radByRegionName.Checked = false;
        //radByRegionsAreaName.Checked = false;
        //radByRegionNo.Checked = false;
        //radByIntersections.Checked = false;
        //radByMainLanes.Checked = true;
        //radByMainLanes_CheckedChanged(sender, e);
    }

    protected void radSectionsSurroundingRegion_CheckedChanged(object sender, EventArgs e)
    {
        radByRegionNo_CheckedChanged(sender, e);

        //ddlOldSurveys.Visible = false;
        //radlRegionSectionsSurveys.Visible = true;
    }

}
