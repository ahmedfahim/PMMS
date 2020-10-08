using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Archive_DefaultTables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            ddlRegions.SelectedValue = "0";

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
            lblFeedback.Text = Feedback.NoRegionSelected();
        else
        {
           
            DataTable dt = new SecondaryStreets().GetRegionSecondaryStreetsTable(int.Parse(ddlRegions.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                Session.Add("option", "SecondaryStreetsTable");
                Session.Add("ReportData", dt);
                string url = "../reports/ViewPavementEvalRegionsReport.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else
                lblFeedback.Text = Feedback.NoData();
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
    }
}