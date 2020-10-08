using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Tests;
using JpmmsClasses.BL.UDI;
using JpmmsClasses.BL.Utils;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Reports_ReportingOthers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            raddtpFrom.SelectedDate = DateTime.Today;
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblTotal.Visible = false;

            if (radAreas.Checked)
            {
                if (raddtpFrom.SelectedDate == null)
                    throw new Exception("الرجاء تحديد التاريخ");

                lblTotal.Text = new JpmmsCharting().GetDailyDataEntryTotalArea(raddtpFrom.SelectedDate).ToString("N2");
                lblTotal.Visible = true;
            }
            else if (radNetworkArea.Checked)
            {
                PavementStatusReport total = new JpmmsCharting().GetWholeNetworkArea();
                lblTotal.Text = string.Format("مقاطع: {0} م2 \n  تقاطعات: {1} م2 \n مناطق فرعية: {2} م2 \n المجموع: {3} م2", total.MainStSectionsTotal.ToString("N2"),
                    total.MainStIntersectsTotal.ToString("N2"), total.RegionsTotal.ToString("N2"), total.WholeNetworkTotal.ToString("N2"));

                lblTotal.Visible = true;
            }
            else if (radIntersectTypes.Checked)
            {
                DataTable dt = new GeneralPmmsReporting().GetIntersectionTypes();
                Session.Add("option", "radIntersectTypes");
                Session.Add("ReportData", dt);
                string url = "ViewOtherReports.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else if (radMaintDeciding.Checked)
            {
                DataTable dt = new MaintDeciding().GetAllMaintDeciding();
                Session.Add("option", "radMaintDeciding");
                Session.Add("ReportData", dt);
                string url = "ViewOtherReports.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else if (radSurveyors.Checked)
            {
                DataTable dt = new Surveyor().GetAllSurveyors();
                Session.Add("option", "radSurveyors");
                Session.Add("ReportData", dt);
                string url = "ViewOtherReports.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else if (radMaintDecisions.Checked)
            {
                DataTable dt = new MaintDecision().GetAllDecisions();
                Session.Add("option", "radMaintDecisions");
                Session.Add("ReportData", dt);
                string url = "ViewOtherReports.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportingOthers.aspx", false);
    }

    protected void radNetworkArea_CheckedChanged(object sender, EventArgs e)
    {
        radAreas_CheckedChanged(sender, e);
    }

    protected void radAreas_CheckedChanged(object sender, EventArgs e)
    {
        raddtpFrom.Enabled = radAreas.Checked;
    }

}