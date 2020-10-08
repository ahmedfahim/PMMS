using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_SurveyorsLateWorkReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (ddlSurveyor.SelectedValue == "0")
                throw new Exception(Feedback.NoSurveyorSelected());

            if (radSection.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveyorsLateWork(JobType.Section, int.Parse(ddlSurveyor.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = "ViewSurveyorsLateWorkReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersection.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveyorsLateWork(JobType.Intersection, int.Parse(ddlSurveyor.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radIntersection");
                    Session.Add("ReportData", dt);
                    string url = "ViewSurveyorsLateWorkReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionSecondary.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveyorsLateWork(JobType.RegionSecondaryStreets, int.Parse(ddlSurveyor.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radRegionSecondary");
                    Session.Add("ReportData", dt);
                    string url = "ViewSurveyorsLateWorkReport.aspx";
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
        lblFeedback.Text = "";
        ddlSurveyor.SelectedValue = "0";

        radSection.Checked = true;
        radIntersection.Checked = false;
        radRegionSecondary.Checked = false;
    }

}