using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_SurveyorsProductionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ViewSurveyorsProductionReport
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            raddtpFrom.SelectedDate = DateTime.Today.AddYears(-1);
            raddtpTo.SelectedDate = DateTime.Today;
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblTotal.Visible = false;

            //if (ddlSurveyor.SelectedValue == "0")
            //    throw new Exception(Feedback.NoSurveyorSelected(lang));
            //else
            if (raddtpFrom.SelectedDate == null)
                throw new Exception(Feedback.NoSearchBeginDate());
            else if (raddtpTo.SelectedDate == null)
                throw new Exception(Feedback.NoSearchEndDate());
            else if (raddtpFrom.SelectedDate > raddtpTo.SelectedDate)
                throw new Exception(Feedback.SearchBeginDateAfterEndDate());


            if (radSection.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveyorProductivity(JobType.Section, int.Parse(ddlSurveyor.SelectedValue), raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = " ViewSurveyorsProductionReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersection.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveyorProductivity(JobType.Intersection, int.Parse(ddlSurveyor.SelectedValue), raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radIntersection");
                    Session.Add("ReportData", dt);
                    string url = " ViewSurveyorsProductionReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionSecondary.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveyorProductivity(JobType.RegionSecondaryStreets, int.Parse(ddlSurveyor.SelectedValue), raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radRegionSecondary");
                    Session.Add("ReportData", dt);
                    string url = " ViewSurveyorsProductionReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radTotal.Checked)
            {
                lblTotal.Visible = true;

                SurveyorsDeliveryTotal total = new SurveyorSubmitJob().GetSurveyorsDeliveryTotals();
                lblTotal.Text = string.Format("مقاطع: {0} م2 \n  تقاطعات: {1} م2 \n مناطق فرعية: {2} م2 \n المجموع: {3} م2", total.SectionsTotal.ToString("N2"),
                    total.IntersectsTotal.ToString("N2"), total.RegionsTotal.ToString("N2"), total.Total.ToString("N2"));
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SurveyorsProductionReport.aspx", false);

        //lblFeedback.Text = "";
        //ddlSurveyor.SelectedValue = "0";
        //raddtpFrom.SelectedDate = DateTime.Today.AddYears(-1);
        //raddtpTo.SelectedDate = DateTime.Today;

        //radSection.Checked = true;
        //radIntersection.Checked = false;
        //radRegionSecondary.Checked = false;
    }

}