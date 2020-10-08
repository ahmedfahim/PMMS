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

public partial class ASPX_Reports_BudgetMaintDecisions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radByMainLanes.Checked = true;
            radByMainLanes_CheckedChanged(sender, e);
        }
    }


    private void SetControlsForMainSt()
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

        //BindSurveyNumDropDown();
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SetControlsForMainSt();
            //BindSurveyNumDropDown();

            // , int.Parse(ddlOldSurveys.SelectedValue)
            rntxtTotalAmount.Value = new MaintDecisionCosting().GetMainStreetSectionsMaintenanceDecisionsCost(int.Parse(ddlMainStreets.SelectedValue));
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            SetControlsForMainSt();
            //BindSurveyNumDropDown();

            rntxtTotalAmount.Value = new MaintDecisionCosting().GetMainStreetIntersectionsMaintenanceDecisionsCost(int.Parse(ddlMainStreets.SelectedValue));
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionNo_CheckedChanged1(object sender, EventArgs e)
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

            //BindSurveyNumDropDown();

            rntxtTotalAmount.Value = new MaintDecisionCosting().GetRegionSecondaryStreetsMaintenanceDecisionsCost(int.Parse(ddlRegions.SelectedValue));
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionName_CheckedChanged1(object sender, EventArgs e)
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

            //BindSurveyNumDropDown();

            rntxtTotalAmount.Value = new MaintDecisionCosting().GetSubdistrictSecondaryStreetsMaintenanceDecisionsCost(ddlRegionNames.SelectedValue);
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionsAreaName_CheckedChanged1(object sender, EventArgs e)
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

            //BindSurveyNumDropDown();

            rntxtTotalAmount.Value = new MaintDecisionCosting().GetDistrictSecondaryStreetsMaintenanceDecisionsCost(ddlDistrict.SelectedValue);
            rntxtTotalAmount_TextChanged(sender, e); // int.Parse(ddlOldSurveys.SelectedValue)
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

            ddlMunic_SelectedIndexChanged(sender, e);           
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
            if (string.IsNullOrEmpty(rntxtBudget.Text)) // radBudget.Checked &&
            {
                rntxtBudget.Focus();
                throw new Exception("الرجاء تحديد ميزانية الصيانة");
            }


            string rptType = (radDetails.Checked ? "radDetails" : (radTotal.Checked ? "radTotal" : "radMaintLengths"));
            string type = (radByMainLanes.Checked || radMunicSections.Checked ? "radByMainLanes" : (radByIntersections.Checked || radMunicIntersects.Checked ? "radByIntersections" : "regions"));
            //int surveyNo = int.Parse(ddlOldSurveys.SelectedValue); surveyNo, 


            if (radByMainLanes.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetMainStreetSectionsMaintenanceBudget(rntxtBudget.Value, int.Parse(ddlMainStreets.SelectedValue),
                    radUdiDesc.Checked, radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked);

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    Session.Add("title", "");
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByIntersections.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetMainStreetIntersectionsMaintenanceBudget(rntxtBudget.Value, int.Parse(ddlMainStreets.SelectedValue),
                    radUdiDesc.Checked, radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked); // surveyNo, 

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionNo.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetRegionMaintenanceBudget(rntxtBudget.Value, int.Parse(ddlRegions.SelectedValue),
                    radUdiDesc.Checked, radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked); // surveyNo,

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionName.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetSubdistrictMaintenanceBudget(rntxtBudget.Value, ddlRegionNames.SelectedValue,
                    radUdiDesc.Checked, radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked); // surveyNo,

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionsAreaName.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetDistrictMaintenanceBudget(rntxtBudget.Value, ddlDistrict.SelectedValue,
                    radUdiDesc.Checked, radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked); // surveyNo,

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunicName.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetMunicMaintenanceBudget(rntxtBudget.Value, ddlMunic.SelectedValue, radUdiDesc.Checked,
                    radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked);  

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radMunicSections.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetMunicSectionsMaintenanceBudget(rntxtBudget.Value, ddlMunic.SelectedValue, radUdiDesc.Checked,
                    radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked);

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    Session.Add("title", "");
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radMunicIntersects.Checked)
            {
                DataTable dt = new MaintenanceDecisionsBudgeting().GetMunicIntersectsMaintenanceBudget(rntxtBudget.Value, ddlMunic.SelectedValue, radUdiDesc.Checked,
                    radUdiAsc.Checked, radPrio.Checked, radMaintLengths.Checked);

                if (dt.Rows.Count > 0)
                {
                    // prepare to show report
                    Session.Add("ReportData", dt);
                    Session.Add("option", rptType);
                    Session.Add("type", type);
                    string url = "ViewBudgetMaintDecisionsReport.aspx";
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
        Response.Redirect("BudgetMaintDecisions.aspx", false);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (radByMainLanes.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMainStreetSectionsMaintenanceDecisionsCost(int.Parse(ddlMainStreets.SelectedValue));
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radByIntersections.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMainStreetIntersectionsMaintenanceDecisionsCost(int.Parse(ddlMainStreets.SelectedValue));
                rntxtTotalAmount_TextChanged(sender, e);
            }

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
            rntxtTotalAmount.Value = new MaintDecisionCosting().GetRegionSecondaryStreetsMaintenanceDecisionsCost(int.Parse(ddlRegions.SelectedValue));
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegionNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            rntxtTotalAmount.Value = new MaintDecisionCosting().GetSubdistrictSecondaryStreetsMaintenanceDecisionsCost(ddlRegionNames.SelectedValue);
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            rntxtTotalAmount.Value = new MaintDecisionCosting().GetDistrictSecondaryStreetsMaintenanceDecisionsCost(ddlDistrict.SelectedValue);
            rntxtTotalAmount_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (radByMunicName.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMunicipalitySecondaryStreetsMaintenanceDecisionsCost(ddlMunic.SelectedValue);
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radMunicSections.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMunicSectionsMaintenanceCost(ddlMunic.SelectedValue);
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radMunicIntersects.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMunicIntersectsMaintenanceCost(ddlMunic.SelectedValue);
                rntxtTotalAmount_TextChanged(sender, e);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


    protected void rntxtTotalAmount_TextChanged(object sender, EventArgs e)
    {
        if (rntxtTotalAmount.Value != null && rntxtPercent.Value != null)
            rntxtBudget.Value = (rntxtTotalAmount.Value * rntxtPercent.Value) / 100.0;
        else
            rntxtBudget.Text = "";
    }

    protected void rntxtPercent_TextChanged(object sender, EventArgs e)
    {
        rntxtTotalAmount_TextChanged(sender, e);
    }

    protected void ddlOldSurveys_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radByMainLanes.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMainStreetSectionsMaintenanceDecisionsCost(int.Parse(ddlMainStreets.SelectedValue));
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radByIntersections.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMainStreetIntersectionsMaintenanceDecisionsCost(int.Parse(ddlMainStreets.SelectedValue));
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radByRegionNo.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetRegionSecondaryStreetsMaintenanceDecisionsCost(int.Parse(ddlRegions.SelectedValue));
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radByRegionName.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetSubdistrictSecondaryStreetsMaintenanceDecisionsCost(ddlRegionNames.SelectedValue);
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radByRegionsAreaName.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetDistrictSecondaryStreetsMaintenanceDecisionsCost(ddlDistrict.SelectedValue);
                rntxtTotalAmount_TextChanged(sender, e);
            }
            else if (radByMunicName.Checked)
            {
                rntxtTotalAmount.Value = new MaintDecisionCosting().GetMunicipalitySecondaryStreetsMaintenanceDecisionsCost(ddlMunic.SelectedValue);
                rntxtTotalAmount_TextChanged(sender, e);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}