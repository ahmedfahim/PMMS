using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Operations_CreateWorkOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["ViewWorkOrder"].ToString() == false.ToString())
            Response.Redirect("~/ASPX/Security/LoginWorkOrders.aspx", false);
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
          

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        //Response.Redirect("RegionQC.aspx", false);
        try
        {
            DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(DropDownddlRegions.SelectedValue, false, false, true, RegionReportLevel.Region);
            if (dt.Rows.Count > 0)
            {
                //Session.Add("option", "radSection");
                Session.Add("ReportData", dt);
                string url = "../Regions/ViewRegionMaintenancePrioritiesReport.aspx";
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
}