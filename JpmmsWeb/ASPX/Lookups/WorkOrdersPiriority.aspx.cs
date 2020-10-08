using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Lookups_WorkOrdersPiriority : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["ViewWorkOrder"].ToString() == false.ToString())
            Response.Redirect("~/ASPX/Security/LoginWorkOrders.aspx", false);
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new MaintenancePriorities().GetMaintenancePrioritiesForRegionsReport(ddlRegions.SelectedValue, false, false, true, RegionReportLevel.Region);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}