using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;


public partial class ASPX_Reports_LaneSamplesInfoReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            ddlMainStreets.SelectedValue = "0";
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            if (string.IsNullOrEmpty(ddlMainStreets.SelectedValue) || ddlMainStreets.SelectedValue == "0")
                throw new Exception(Feedback.NoMainStreetSelected());


            if (radLaneSamples.Checked)
            {
                DataTable dt = new LaneSample().AdvancedSearch(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("type", "radLaneSamples");
                    Session.Add("ReportData", dt);
                    string url = "ViewSamplesInfoReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radIntersectSamples.Checked)
            {
                DataTable dt = new IntersectionSamples().AdvancedSearch(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("type", "radIntersectSamples");
                    Session.Add("ReportData", dt);
                    string url = "ViewSamplesInfoReport.aspx";
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
        Response.Redirect("LaneSamplesInfoReport.aspx", false);
    }

}
