using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_QcReports : System.Web.UI.Page
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
            DataTable dt = new QcCheck().Search(radSection.Checked, radIntersection.Checked, radRegionSecondary.Checked, radDetails.Checked, int.Parse(ddlSurveyor.SelectedValue),
                int.Parse(ddlQcSurveyor.SelectedValue), raddtpFrom.SelectedDate, raddtpTo.SelectedDate, radSuccessAll.Checked, radSuccess.Checked);

            if (dt.Rows.Count > 0)
            {
                // prepare to show report
                if (radSection.Checked)
                    Session.Add("option", "radSection");
                else if (radIntersection.Checked)
                    Session.Add("option", "radIntersection");
                else if (radRegionSecondary.Checked)
                    Session.Add("option", "radRegionSecondary");

                if (radSummary.Checked)
                    Session.Add("details", "radSummary");
                else if (radDetails.Checked)
                    Session.Add("details", "radDetails");


                Session.Add("ReportData", dt);
                string url = "ViewQcReports.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else
                lblFeedback.Text = Feedback.NoData();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnNewSurveyCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("QcReports.aspx", false);
    }

}
