using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Reports_PavementStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            btnCancel_Click(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            //if (radlOldSurveys.SelectedIndex == -1)
            //    throw new Exception(Feedback.NoSurveyNum(lang));


            if (radRegions.Checked)
            { // RegionsUDI
                DataTable dt = new JpmmsClasses.BL.UDI.RegionSecondaryStUDI().GetAllRegionsPavementStatus();
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radRegions");
                    Session.Add("ReportData", dt);
                    string url = "ViewPavementStatusReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSectionIntersects.Checked)
            {
                DataTable dt = new JpmmsClasses.BL.UDI.SectionsUDI().GetAllMainStreetsPavementStatus();
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radSectionIntersects");
                    Session.Add("ReportData", dt);
                    string url = "ViewPavementStatusReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radTotal.Checked)
            {
                Session.Add("option", "radTotal");
                string url = "ViewPavementStatusTotals.aspx";
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
        lblFeedback.Text = "";

        radSectionIntersects.Checked = true;
        radRegions.Checked = false;
    }

    //protected void radlOldSurveys_DataBound(object sender, EventArgs e)
    //{
    //    if (radlOldSurveys.Items.Count > 0)
    //        radlOldSurveys.SelectedIndex = 0;
    //}

}
