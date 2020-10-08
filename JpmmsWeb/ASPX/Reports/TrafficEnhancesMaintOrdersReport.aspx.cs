using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_TrafficEnhancesMaintOrdersReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            //radMainSt_CheckedChanged(sender, e);
            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";

            radAllRoads_CheckedChanged(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            if (radMainSt.Checked && (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue)))
                throw new Exception("الرجاء اختيار الطريق الرئيسي");
            else if (radRegion.Checked && (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue)))
                throw new Exception("الرجاء اختيار المنطقة الفرعية");


            DataTable dt = new DataTable();
            if (radTrafficEnhanceLocations.Checked)
            {
                Session.Add("option", "radTrafficEnhance");
                string id = radAllRoads.Checked ? "0" : (radMainSt.Checked ? ddlMainStreets.SelectedValue : ddlRegions.SelectedValue);
                dt = new TrafficEnhances().SearchTrafficEnahnce(txtDetail.Text, raddtpFrom.SelectedDate, raddtpFrom.SelectedDate, radMainSt.Checked, int.Parse(id),
                    radAllRoads.Checked, radTrafficEnhanceLocations.Checked);
            }
            else if (radMaintOrder.Checked)
            {
                Session.Add("option", "radMaintOrder");
                string id = radMainSt.Checked ? ddlMainStreets.SelectedValue : ddlRegions.SelectedValue;
                dt = new MaintenanceOrders().Search(txtDetail.Text, int.Parse(ddlContractors.SelectedValue), raddtpFrom.SelectedDate, raddtpFrom.SelectedDate,
                   radMainSt.Checked, int.Parse(id), radAllRoads.Checked);
            }
            else if (radTrafficEnhanceDetails.Checked)
            {
                Session.Add("option", "radTrafficEnhanceDetails");
                string id = radAllRoads.Checked ? "0" : (radMainSt.Checked ? ddlMainStreets.SelectedValue : ddlRegions.SelectedValue);
                dt = new TrafficEnhances().SearchTrafficEnahnce(txtDetail.Text, raddtpFrom.SelectedDate, raddtpFrom.SelectedDate, radMainSt.Checked, int.Parse(id),
                    radAllRoads.Checked, radTrafficEnhanceLocations.Checked);
            }


            if (dt.Rows.Count > 0)
            {
                Session.Add("ReportData", dt);
                string url = "ViewTrafficEnhancesMaintOrdersReport.aspx";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrafficEnhancesMaintOrdersReport.aspx", false);
    }

    protected void radMainSt_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
        ddlRegions.Enabled = false;
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlRegions.Enabled = true;
        ddlMainStreets.Enabled = false;
    }

    protected void radAllRoads_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
    }

}
