using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_SurveyingInfo_SyurveyQty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[5] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            raddtpFrom.SelectedDate = DateTime.Today.AddYears(-1);
            raddtpTo.SelectedDate = DateTime.Today;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        ddlSurveyor.SelectedValue = "0";

        raddtpFrom.SelectedDate = DateTime.Today.AddYears(-1);
        raddtpTo.SelectedDate = DateTime.Today;

        ClearResults();
    }

    private void ClearResults()
    {
        gvSurveyedSections.DataSource = null;
        gvSurveyedIntersects.DataSource = null;
        gvSurveyedRegion.DataSource = null;

        lblSectionsTotal.Text = "";
        lblIntersectsTotal.Text = "";
        lblRegionsTotal.Text = "";

        lblTotal.Text = "";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            ClearResults();

            SurveyorSubmitJob job = new SurveyorSubmitJob();

            DataTable dt = job.GetSurveyorSectionSurveys(int.Parse(ddlSurveyor.SelectedValue), (DateTime)raddtpFrom.SelectedDate, (DateTime)raddtpTo.SelectedDate);
            gvSurveyedSections.DataSource = dt;
            gvSurveyedSections.DataBind();

            DataTable dt2 = job.GetSurveyorIntersectionSurveys(int.Parse(ddlSurveyor.SelectedValue), (DateTime)raddtpFrom.SelectedDate, (DateTime)raddtpTo.SelectedDate);
            gvSurveyedIntersects.DataSource = dt2;
            gvSurveyedIntersects.DataBind();

            DataTable dt3 = job.GetSurveyorRegionSurveys(int.Parse(ddlSurveyor.SelectedValue), (DateTime)raddtpFrom.SelectedDate, (DateTime)raddtpTo.SelectedDate);
            gvSurveyedRegion.DataSource = dt3;
            gvSurveyedRegion.DataBind();

            decimal totalSections = job.GetSurveyorSectionSurveysTotal(int.Parse(ddlSurveyor.SelectedValue), (DateTime)raddtpFrom.SelectedDate, (DateTime)raddtpTo.SelectedDate);
            decimal totalIntersects = job.GetSurveyorIntersectionSurveysTotal(int.Parse(ddlSurveyor.SelectedValue), (DateTime)raddtpFrom.SelectedDate, (DateTime)raddtpTo.SelectedDate);
            decimal totalRegions = job.GetSurveyorRegionSurveysTotal(int.Parse(ddlSurveyor.SelectedValue), (DateTime)raddtpFrom.SelectedDate, (DateTime)raddtpTo.SelectedDate);

            lblSectionsTotal.Text = totalSections.ToString("N2");
            lblIntersectsTotal.Text = totalIntersects.ToString("N2");
            lblRegionsTotal.Text = totalRegions.ToString("N2");

            lblTotal.Text = (totalSections + totalIntersects + totalRegions).ToString("N2");
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}