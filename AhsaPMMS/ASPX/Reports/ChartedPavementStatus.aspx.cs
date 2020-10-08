using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Reports_ChartedPavementStatus : System.Web.UI.Page
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

    protected void radSectionIntersects_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
        ddlRegions.Enabled = false;
    }

    protected void radRegions_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = true;
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            if (radRegions.Checked)
            {
                string url = string.Format("ViewRegionsChartingTestPage.aspx?id={0}", ddlRegions.SelectedValue);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else if (radSectionIntersects.Checked)
            {
                string url = string.Format("ViewTestChart.aspx?id={0}", ddlMainStreets.SelectedValue);
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

        radRegions.Checked = false;
        radSectionIntersects.Checked = true;
        radSectionIntersects_CheckedChanged(sender, e);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void radlOldSurveys_DataBound(object sender, EventArgs e)
    {

    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

}
