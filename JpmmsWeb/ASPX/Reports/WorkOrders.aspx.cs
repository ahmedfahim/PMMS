using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

public partial class ASPX_Archive_WorkOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
        //    Response.Redirect("~/ASPX/Default.aspx", false);

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        DataTable dt = new MaintenanceOrders().GetMaintOrders(ddlContractors.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            Session.Add("ReportData", dt);
            Session.Add("option", "WorkOrders");
            string url = "ViewWorkOrders.aspx";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
        }
        else
            lblFeedback.Text = Feedback.NoData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dt = new MaintenanceOrders().GetMaintOrders(ddlContractors.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            lblFeedback.Text = "";
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
            lblFeedback.Text = Feedback.NoData();

    }
}