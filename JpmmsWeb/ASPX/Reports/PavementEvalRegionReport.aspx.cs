using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Reports_PavementEvalRegionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radByRegion_CheckedChanged(sender, e);
        }
    }

    protected void radByRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        ddlRegionNames.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";

        ddlRegions.Enabled = true;
        ddlDistrict.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlMunic.Enabled = false;

        chkWithDistresses.Enabled = true;
        chkWithDistresses.Checked = false;

        ddlRegionSecondaryStreets.Visible = radByRegion.Checked;
        ddlRegionSecondaryStreets.SelectedValue = "0";
    }

    protected void radByRegionTotal_CheckedChanged(object sender, EventArgs e)
    {
        radByRegion_CheckedChanged(sender, e);

        chkWithDistresses.Enabled = false;
        chkWithDistresses.Checked = false;
    }

    protected void radByRegionName_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegions.Enabled = false;
        ddlRegions.SelectedValue = "0";

        ddlDistrict.Enabled = false;
        ddlDistrict.SelectedValue = "0";

        ddlMunic.Enabled = false;
        ddlMunic.SelectedValue = "0";

        ddlRegionNames.Enabled = true;
        radbyMunicName.Checked = false;

        chkWithDistresses.Enabled = false;
        chkWithDistresses.Checked = false;

        ddlRegionSecondaryStreets.Visible = radByRegion.Checked;
        ddlRegionSecondaryStreets.SelectedValue = "0";
    }

    protected void radByRegionsAreaName_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegions.Enabled = false;
        ddlRegions.SelectedValue = "0";

        ddlDistrict.Enabled = true;
        ddlMunic.Enabled = false;
        ddlRegionNames.Enabled = false;

        ddlDistrict.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";

        chkWithDistresses.Enabled = false;
        chkWithDistresses.Checked = false;

        ddlRegionSecondaryStreets.Visible = radByRegion.Checked;
        ddlRegionSecondaryStreets.SelectedValue = "0";
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radByMonth.Checked)
            {
                if (DrpDwnListMonth.SelectedValue == "-1")
                    lblFeedback.Text = Feedback.NoSearchBeginDate();
                else
                {
                    lblFeedback.Text = "";
                    DataTable dt = new RegionSecondaryStUDI().GetDataBySpecificDate(DrpDwnListMonth.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionName");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
            }
            else if (radByDate.Checked)
            {
                SpecificDate();
            }
            else
                if (radByRegion.Checked)
                {
                    if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyDateNum()); int.Parse(radlOldSurveys.SelectedValue)


                    int secondID = (string.IsNullOrEmpty(ddlRegionSecondaryStreets.SelectedValue) || ddlRegionSecondaryStreets.SelectedValue == "0") ? 0 : int.Parse(ddlRegionSecondaryStreets.SelectedValue);
                    if (chkWithDistresses.Checked)
                    {
                        DataTable dt = new RegionSecondaryStUDI().GetRegionUdiReport(int.Parse(ddlRegions.SelectedValue), true, radAllDists.Checked, secondID);
                        if (dt.Rows.Count > 0)
                        {
                            Session.Add("option", "radByRegionDistress");
                            Session.Add("ReportData", dt);
                            string url = "ViewPavementEvalRegionsReport.aspx";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                        }
                        else
                            lblFeedback.Text = Feedback.NoData();
                    }
                    else
                    { // RegionsUDI  int.Parse(radlOldSurveys.SelectedValue), 
                        DataTable dt = new RegionSecondaryStUDI().GetRegionUdiReport(int.Parse(ddlRegions.SelectedValue), false, radAllDists.Checked, secondID);

                        if (dt.Rows.Count > 0)
                        {
                            Session.Add("option", "radByRegion");
                            Session.Add("ReportData", dt);
                            string url = "ViewPavementEvalRegionsReport.aspx";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                        }
                        else
                            lblFeedback.Text = Feedback.NoData();
                    }

                }
                else if (radByRegionTotal.Checked)
                {
                    if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyNum());      int.Parse(radlOldSurveys.SelectedValue),

                    DataTable dt = new RegionSecondaryStUDI().GetRegionTotalUdiReport(int.Parse(ddlRegions.SelectedValue), radAllDists.Checked);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionTotal");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else if (radByRegionNameTotal.Checked)
                {
                    if (ddlRegionNames.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionNames.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyNum()); int.Parse(radlOldSurveys.SelectedValue), RegionSecondaryStUDI.

                    DataTable dt = new RegionSecondaryStUDI().GetRegionTotalUdiReport(ddlRegionNames.SelectedValue, radAllDists.Checked, RegionReportLevel.Subdistrict);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionTotal");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else if (radByRegionsAreaNameTotal.Checked)
                {
                    if (ddlDistrict.SelectedValue == "0" || string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyNum()); int.Parse(radlOldSurveys.SelectedValue),


                    DataTable dt = new RegionSecondaryStUDI().GetRegionTotalUdiReport(ddlDistrict.SelectedValue, radAllDists.Checked, RegionReportLevel.District);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionTotal");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else if (radbyMunicTotal.Checked)
                {
                    if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                        throw new Exception(Feedback.NoRegionSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyNum()); int.Parse(radlOldSurveys.SelectedValue),

                    DataTable dt = new RegionSecondaryStUDI().GetRegionTotalUdiReport(ddlMunic.SelectedValue, radAllDists.Checked, RegionReportLevel.Municipality);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionTotal");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else if (radByRegionName.Checked)
                {
                    if (ddlRegionNames.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionNames.SelectedValue))
                        throw new Exception(Feedback.NoRegionNameSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyDateNum());

                    DataTable dt = new RegionSecondaryStUDI().getRegionTotalUdiReportBy(ddlRegionNames.SelectedValue, radAllDists.Checked, RegionReportLevel.Subdistrict);
                    //getRegionTotalUdiReportBySubdistrict(ddlRegionNames.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), radAllDists.Checked);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionName");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else if (radByRegionsAreaName.Checked)
                {
                    if (ddlDistrict.SelectedValue == "0" || string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                        throw new Exception(Feedback.NoRegionsAreaNameSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyDateNum());


                    //DataTable dt = new RegionSecondaryStUDI().getRegionTotalUdiReportByDistrict(ddlDistrict.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), radAllDists.Checked);
                    DataTable dt = new RegionSecondaryStUDI().getRegionTotalUdiReportBy(ddlDistrict.SelectedValue, radAllDists.Checked, RegionReportLevel.District);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByRegionsAreaName");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else if (radbyMunicName.Checked)
                {
                    if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                        throw new Exception("الرجاء اختيار البلدية الفرعية");

                    //DataTable dt = new RegionSecondaryStUDI().GetMunicUdiReport(ddlMunic.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), radAllDists.Checked);
                    DataTable dt = new RegionSecondaryStUDI().getRegionTotalUdiReportBy(ddlMunic.SelectedValue, radAllDists.Checked, RegionReportLevel.Municipality);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radbyMunicName");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalRegionsReport.aspx";
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

    protected void SpecificDate()
    {

        if (raddtpFrom.SelectedDate == null)
            throw new Exception(Feedback.NoSearchBeginDate());
        else if (raddtpTo.SelectedDate == null)
            throw new Exception(Feedback.NoSearchEndDate());
        else if (raddtpFrom.SelectedDate > raddtpTo.SelectedDate)
            throw new Exception(Feedback.SearchBeginDateAfterEndDate());

        DataTable dt = new RegionSecondaryStUDI().GetDataBySpecificDate(raddtpFrom.SelectedDate, raddtpTo.SelectedDate.Value.AddDays(1));
        //if (dt.Rows.Count > 0)
        //{
        //    Session.Add("option", "radByRegionDistress");
        //    Session.Add("ReportData", dt);
        //    string url = "ViewPavementEvalRegionsReport.aspx";
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
        //}
        //else
        //    lblFeedback.Text = Feedback.NoData();


        if (dt.Rows.Count > 0)
        {
            Session.Add("option", "radByRegionName");
            Session.Add("ReportData", dt);
            string url = "ViewPavementEvalRegionsReport.aspx";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
        }
        else
            lblFeedback.Text = Feedback.NoData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PavementEvalRegionReport.aspx", false);

        //lblFeedback.Text = "";

        //radByRegion.Checked = true;
        //radByRegionTotal.Checked = false;
        //radByRegionName.Checked = false;
        //radByRegionsAreaName.Checked = false;
        //radbyMunicName.Checked = false;

        //ddlRegions.SelectedValue = "0";
        //ddlRegionNames.SelectedValue = "0";
        //ddlDistrict.SelectedValue = "0";

        //radByRegion_CheckedChanged(sender, e);
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            //radlOldSurveys.DataSource = new DistressSurvey().GetRegionDistrictAvailableSurveys(int.Parse(ddlRegions.SelectedValue), ddlRegionNames.SelectedValue,
            //    ddlDistrict.SelectedValue, ddlMunic.SelectedValue, radByRegion.Checked, (radByRegionName.Checked || radByRegionNameTotal.Checked),
            //    (radByRegionsAreaName.Checked || radByRegionsAreaNameTotal.Checked), (radbyMunicName.Checked || radbyMunicTotal.Checked), radByRegionTotal.Checked);

            //radlOldSurveys.DataTextField = "survey_title";
            //radlOldSurveys.DataValueField = "survey_no";
            //radlOldSurveys.DataBind();
            //radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 0) ? -1 : 0;

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

    protected void radbyMunicName_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegions.Enabled = false;

        ddlRegionNames.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";

        ddlDistrict.Enabled = false;
        ddlRegionNames.Enabled = false;

        ddlMunic.Enabled = true;
        ddlMunic.SelectedValue = "0";

        chkWithDistresses.Enabled = false;
        chkWithDistresses.Checked = false;

        ddlRegionSecondaryStreets.Visible = radByRegion.Checked;
        ddlRegionSecondaryStreets.SelectedValue = "0";
        //radlOldSurveys.Visible = false;
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlRegionNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void radByDate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
         
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = false;
            DrpDwnListMonth.Enabled = false;
            ddlRegionSecondaryStreets.Enabled = false;
            raddtpFrom.Enabled = true;
            raddtpTo.Enabled = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByMonth_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = false;
            ddlRegionSecondaryStreets.Enabled = false;
            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;
            DrpDwnListMonth.Enabled = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
}