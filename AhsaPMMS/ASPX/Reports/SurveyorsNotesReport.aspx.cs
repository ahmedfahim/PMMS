using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_SurveyorsNotesReport : System.Web.UI.Page
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

            if (radSection.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveysWithNotes(JobType.Section);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radSection");
                    Session.Add("ReportData", dt);
                    string url = " ViewSurveyorsNotesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersection.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveysWithNotes(JobType.Intersection);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radIntersection");
                    Session.Add("ReportData", dt);
                    string url = " ViewSurveyorsNotesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionSecondary.Checked)
            {
                DataTable dt = new SurveyorSubmitJob().GetSurveysWithNotes(JobType.RegionSecondaryStreets);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radRegionSecondary");
                    Session.Add("ReportData", dt);
                    string url = " ViewSurveyorsNotesReport.aspx";
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

        radSection.Checked = true;
        radIntersection.Checked = false;
        radRegionSecondary.Checked = false;
    }

}