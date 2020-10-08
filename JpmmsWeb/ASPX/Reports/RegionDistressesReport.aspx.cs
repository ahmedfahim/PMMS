using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class ASPX_Reports_RegionDistressesReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radbyRegion_CheckedChanged(sender, e);
            raddtpTo.SelectedDate = DateTime.Now;
            raddtpFrom.SelectedDate = DateTime.Now.AddMonths(-1);
        }
    }

    protected void radbyRegion_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegions.Enabled = true;
            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = false;
            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;

            pnlDists.Visible = radbyRegion.Checked;
            ddlRegions.Visible = true;
            ddlRegionSecondaryStreets.Visible = true;
            //radlOldSurveys.SelectedIndex = -1;
            //radlOldSurveys.Visible = true;

            //radlOldSurveys.Visible = true;
            //radlOldSurveys.DataBind();
            //radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 1) ? 0 : -1;
            ddlRegionSecondaryStreets.Visible = radbyRegion.Checked;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radAllRegionsDistressArea_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDistresses.Enabled = false;

            ddlRegions.SelectedValue = "0";
            ddlRegions.Enabled = false;
            ddlMunic.Enabled = false;

            pnlDists.Visible = radbyRegion.Checked;
            ddlRegionSecondaryStreets.Visible = radbyRegion.Checked;

            //radlOldSurveys.Visible = true;
            //radlOldSurveys.DataBind();
            //radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 1) ? 0 : -1;
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

            Session.Remove("ReportData");
            if (radbyRegion.Checked)
            {
                //survey = int.Parse(radlOldSurveys.SelectedValue); survey
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());


                int secStID = (ddlRegionSecondaryStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionSecondaryStreets.SelectedValue)) ? 0 : int.Parse(ddlRegionSecondaryStreets.SelectedValue);
                DataTable dt = new DistressEntry().GetRegionDistressesReport(int.Parse(ddlRegions.SelectedValue), radPatchDistsOnly.Checked, secStID);
                if (dt.Rows.Count > 0)
                {
                    //CrystalReportPartsViewer1.ReportSource = GenerateReport(dt);
                    //CrystalReportPartsViewer1.DataBind();
                    //lblFeedback.Text = "Finished";
                    Session.Add("option", "radbyRegion");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMuncipality.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new DistressEntry().GetRegionDistressesReport(ddlMunic.SelectedValue, radPatchDistsOnly.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyRegion");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionDistressArea.Checked)
            {
                //survey = int.Parse(radlOldSurveys.SelectedValue);
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new DistressEntry().GetByRegionDistressArea(int.Parse(ddlRegions.SelectedValue)); // survey
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionDistressArea");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionDistressAreaTotal.Checked)
            {
                //survey = int.Parse(radlOldSurveys.SelectedValue);   survey, 
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new DistressEntry().GetByRegionDistressAreaTotal(int.Parse(ddlRegions.SelectedValue), radAllDistress.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionDistressAreaTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionDistressAreaSeverity.Checked)
            {
                //survey = int.Parse(radlOldSurveys.SelectedValue);
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new DistressEntry().GetByRegionDistressAreaSeverity(int.Parse(ddlRegions.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionDistressAreaSeverity");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByRegionDistressAreaSeverityTotal.Checked)
            {
                //survey = int.Parse(radlOldSurveys.SelectedValue);
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());

                DataTable dt = new DistressEntry().GetByRegionDistressAreaSeverityTotal(int.Parse(ddlRegions.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionDistressAreaSeverityTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radAllRegionsDistressArea.Checked)
            {
                //survey = int.Parse(radlOldSurveys.SelectedValue);
                DataTable dt = new DistressEntry().GetAllRegionsDistressArea();
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radAllRegionsDistressArea");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByRegionAreaTotal.Checked)
            {
                //if (ddlDistresses.SelectedValue == "0")
                //    throw new Exception(Feedback.NoDistressSelected(lang));

                //survey = int.Parse(radlOldSurveys.SelectedValue);
                DataTable dt = new DistressEntry().GetByRegionAreaTotal(int.Parse(ddlDistresses.SelectedValue), int.Parse(ddlRegions.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegionAreaTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByDate.Checked)
            {
                //if (ddlRegions.SelectedValue == "0")
                //    throw new Exception(Feedback.NoRegionSelected(lang));
                //else
                if (raddtpFrom.SelectedDate == null)
                    throw new Exception(Feedback.NoSearchBeginDate());
                else if (raddtpTo.SelectedDate == null)
                    throw new Exception(Feedback.NoSearchEndDate());
                else if (raddtpFrom.SelectedDate > raddtpTo.SelectedDate)
                    throw new Exception(Feedback.SearchBeginDateAfterEndDate());


                DataTable dt = new DistressEntry().GetRegionDistressesReport(raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyRegion");
                    Session.Add("ReportData", dt);
                    string url = "ViewRegionDistressesReport.aspx";
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
        Response.Redirect("RegionDistressesReport.aspx", false);
    }

    protected void radByRegionDistressArea_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDistresses.SelectedValue = "0";
            ddlDistresses.Enabled = false;
            ddlRegions.Enabled = true;
            ddlMunic.Enabled = false;

            pnlDists.Visible = radbyRegion.Checked;
            ddlRegions.Visible = true;
            ddlRegionSecondaryStreets.Visible = false;

            ddlRegionSecondaryStreets.Visible = radbyRegion.Checked;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionDistressAreaSeverity_CheckedChanged(object sender, EventArgs e)
    {
        radByRegionDistressArea_CheckedChanged(sender, e);
    }

    protected void radByRegionDistressAreaSeverityTotal_CheckedChanged(object sender, EventArgs e)
    {
        radByRegionDistressArea_CheckedChanged(sender, e);
    }

    protected void radByRegionAreaTotal_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDistresses.Enabled = true;

            ddlRegions.SelectedValue = "0";
            ddlRegions.Enabled = true;
            ddlMunic.Enabled = false;

            pnlDists.Visible = radbyRegion.Checked;
            ddlRegions.Visible = true;
            ddlRegionSecondaryStreets.Visible = false;

            ddlRegionSecondaryStreets.Visible = radbyRegion.Checked;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionDistressAreaTotal_CheckedChanged(object sender, EventArgs e)
    {
        radByRegionDistressArea_CheckedChanged(sender, e);
        pnlDists.Visible = true;
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

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

    protected void ddlDistresses_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void radByDate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegions.Enabled = true;
            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = false;

            raddtpFrom.Enabled = true;
            raddtpTo.Enabled = true;

            pnlDists.Visible = false; 
            ddlRegions.Visible = false;
            ddlRegionSecondaryStreets.Visible = false;          
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByMuncipality_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegions.Enabled = false;
            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = true;

            raddtpFrom.Enabled = true;
            raddtpTo.Enabled = true;

            pnlDists.Visible = false; //radbyRegion.Checked;
            ddlRegions.Visible = false;
            ddlRegionSecondaryStreets.Visible = false; //radbyRegion.Checked;          
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}