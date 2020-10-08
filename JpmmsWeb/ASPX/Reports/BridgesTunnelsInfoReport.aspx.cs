using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_BridgesTunnelsInfoReport : System.Web.UI.Page
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
            if (radBridge.Checked)
            {
                DataTable dt = new Bridge().GetMainStreetBridges(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("type", "bridge");
                    Session.Add("ReportData", dt);
                    string url = "ViewBridgesTunnelsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radTunnel.Checked)
            {
                DataTable dt = new Tunnel().GetMainStreetTunnels(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("type", "tunnel");
                    Session.Add("ReportData", dt);
                    string url = "ViewBridgesTunnelsReport.aspx";
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
        Response.Redirect("BridgesTunnelsInfoReport.aspx", false);
    }

}
