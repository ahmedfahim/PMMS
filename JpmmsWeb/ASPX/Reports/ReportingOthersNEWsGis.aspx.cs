using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_ReportingOthersNEWsGis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            if (DrpDwnListMonth.SelectedValue == "-1")
                lblFeedback.Text = Feedback.NoSearchBeginDate();
            else
            {
                DataTable dt;
                lblFeedback.Text = "";
                if (DrpDwnListMonth.SelectedValue == "0")
                    dt = new DistressSurvey().GetSurveyedAreasWithDateALLGIS(null);
                else
                    dt = new DistressSurvey().GetSurveyedAreasWithDateALLGIS(DrpDwnListMonth.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", "region");
                    string url = "ViewFinishedSurveyingReport.aspx";
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
}