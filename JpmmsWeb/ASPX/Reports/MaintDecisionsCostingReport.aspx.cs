using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_MaintDecisionsCostingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                    Response.Redirect("~/ASPX/Default.aspx", false);

                radByMainLanes.Checked = true;
                radByMainLanes_CheckedChanged(sender, e);

                if (Request.QueryString["doing"] != null)
                    chkNotDoing.Visible = (int.Parse(Request.QueryString["doing"]) == 1);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();


            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";

            ddlMainStreets.Enabled = true;
            ddlMainStreets.SelectedValue = "0";

            ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
            ddlRegionSecondaryStreets.SelectedValue = "0";

            ddlRegions_SelectedIndexChanged(sender, e);
            pnlInDetails.Visible = true;          
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        //radByMainLanes_CheckedChanged(sender, e);
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();


            ddlDistrict.Enabled = false;
            ddlDistrict.SelectedValue = "0";

            ddlRegionNames.Enabled = false;
            ddlRegionNames.SelectedValue = "0";

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";

            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";

            ddlMainStreets.Enabled = true;
            ddlMainStreets.SelectedValue = "0";

            ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
            ddlRegionSecondaryStreets.SelectedValue = "0";

            ddlRegions_SelectedIndexChanged(sender, e);          
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

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";

            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = true;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = false;

            //pnlInDetails.Visible = false;
            ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
            ddlRegionSecondaryStreets.SelectedValue = "0";
            ddlRegionSecondaryStreets.Enabled = true;         
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
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = true;
            ddlMunic.Enabled = false;
            ddlDistrict.Enabled = false;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
            ddlRegionSecondaryStreets.SelectedValue = "0";
            ddlRegionSecondaryStreets.Enabled = false;        
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

            ddlDistrict.Enabled = true;
            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlMunic.Enabled = false;

            //pnlInDetails.Visible = false;
            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
            ddlRegionSecondaryStreets.SelectedValue = "0";
            ddlRegionSecondaryStreets.Enabled = false;
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

            ddlRegions.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlMunic.Enabled = true;

            //pnlInDetails.Visible = false;
            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
            ddlRegionSecondaryStreets.SelectedValue = "0";
            ddlRegionSecondaryStreets.Enabled = false;

            //ddlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            //radlOldSurveys.DataBind();
            //if (radlOldSurveys.Items.Count == 0)
            //    radlOldSurveys.SelectedIndex = -1;
            //else
            //    radlOldSurveys.SelectedIndex = 0;

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

            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();
            ddlRegionSecondaryStreets.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegionNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }


    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radByMainLanes.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                        throw new Exception(Feedback.NoMainStreetSelected());
                    //else if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
                    //    throw new Exception(Feedback.NoSurveyDateNum(lang)); surveyNum, 
                }


                DataTable dt = new MaintDecisionCosting().GetMainStreetSectionsMaintenanceDecisions(int.Parse(ddlMainStreets.SelectedValue), radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("title", "");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByIntersections.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                        throw new Exception(Feedback.NoMainStreetSelected());
                    //else if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
                    //    throw new Exception(Feedback.NoSurveyDateNum(lang));
                }

                DataTable dt = new MaintDecisionCosting().GetMainStreetIntersectionsMaintenanceDecisions(int.Parse(ddlMainStreets.SelectedValue), radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionNo.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
                    //    throw new Exception(Feedback.NoSurveyDateNum(lang));
                }


                int secondID = (string.IsNullOrEmpty(ddlRegionSecondaryStreets.SelectedValue) || ddlRegionSecondaryStreets.SelectedValue == "0") ? 0 : int.Parse(ddlRegionSecondaryStreets.SelectedValue);
                DataTable dt = new MaintDecisionCosting().GetRegionSecondaryStreetsMaintenanceDecisions(int.Parse(ddlRegions.SelectedValue), radDetails.Checked,
                    chkNotDoing.Checked, secondID);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionName.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlRegionNames.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionNames.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
                    //    throw new Exception(Feedback.NoSurveyDateNum(lang));  surveyNum, 
                }

                DataTable dt = new MaintDecisionCosting().GetSubdistrictSecondaryStreetsMaintenanceDecisions(ddlRegionNames.SelectedValue, radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionsAreaName.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlDistrict.SelectedValue == "0" || string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
                    //    throw new Exception(Feedback.NoSurveyDateNum(lang)); surveyNum, 
                }

                DataTable dt = new MaintDecisionCosting().GetDistrictSecondaryStreetsMaintenanceDecisions(ddlDistrict.SelectedValue, radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunicName.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (string.IsNullOrEmpty(radlOldSurveys.SelectedValue))
                    //    throw new Exception(Feedback.NoSurveyDateNum(lang));  surveyNum, 
                }

                DataTable dt = new MaintDecisionCosting().GetMunicipalitySecondaryStreetsMaintenanceDecisions(ddlMunic.SelectedValue, radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionNo");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radSectionsSurroundingRegion.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                }

                //if (string.IsNullOrEmpty(radlRegionSectionsSurveys.SelectedValue))
                //    throw new Exception(Feedback.NoSurveyDateNum());


                //surveyNum = int.Parse(radlRegionSectionsSurveys.SelectedValue); //  surveyNum, 
                DataTable dt = new MaintDecisionCosting().GetRegionSurroundingSectionsMaintenanceDecisions(int.Parse(ddlRegions.SelectedValue), radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("المحيطة بالمنطقة {0}", ddlRegions.SelectedItem.Text));
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radMunicSections.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                }

                DataTable dt = new MaintDecisionCosting().GetRegionSurroundingSectionsInMunic(ddlMunic.SelectedValue, radDetails.Checked, chkNotDoing.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    string url = "ViewMaintDescisionsCostingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radMunicIntersects.Checked)
            {
                if (!radTotal.Checked)
                {
                    if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                }

                DataTable dt = new MaintDecisionCosting().GetMainStreetIntersectionsMaintenanceDecisions(ddlMunic.SelectedValue, radDetails.Checked,
                    chkNotDoing.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("details", radDetails.Checked ? "details" : "summary");
                    Session.Add("ReportData", dt);
                    //Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    string url = "ViewMaintDescisionsCostingReport.aspx";
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
        try
        {
            string url = (Request.QueryString["doing"] != null) ? string.Format("MaintDecisionsCostingReport.aspx?doing={0}", int.Parse(Request.QueryString["doing"])) : "MaintDecisionsCostingReport.aspx";
            Response.Redirect(url, false);

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }

        //lblFeedback.Text = "";
        //ddlMainStreets.SelectedValue = "0";
        ////ddlContracts.SelectedValue = "0";

        //radByMainLanes.Checked = true;
        //radByMainLanes_CheckedChanged(sender, e);

        //radByIntersections.Checked = false;
        //radByRegionNo.Checked = false;
        //radByRegionName.Checked = false;
        //radByRegionsAreaName.Checked = false;
        //radByMunicName.Checked = false;
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void radDetails_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
    }

    protected void radTotal_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegionSecondaryStreets.Visible = (radDetails.Checked && radByRegionNo.Checked);
    }

    protected void radSectionsSurroundingRegion_CheckedChanged(object sender, EventArgs e)
    {
        radByRegionNo_CheckedChanged(sender, e);

        ddlRegionSecondaryStreets.Enabled = false;
        //ddlOldSurveys.Visible = false;
        //radlRegionSectionsSurveys.Visible = true;
    }

}
