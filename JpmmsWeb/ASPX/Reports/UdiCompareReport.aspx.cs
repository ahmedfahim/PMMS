using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;
using System.Data;

public partial class ASPX_Reports_UdiCompareReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            radSection_CheckedChanged(sender, e);
    }  


    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlRegions.Visible = false;

        pnlSections.Visible = true;
        pnlIntersect.Visible = false;
        pnlRegions.Visible = false;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void radIntersect_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlRegions.Visible = false;

        pnlSections.Visible = false;
        pnlIntersect.Visible = true;
        pnlRegions.Visible = false;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }
    
    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlRegions.Visible = true;

        pnlSections.Visible = false;
        pnlIntersect.Visible = false;
        pnlRegions.Visible = true;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void btnShowMaintDecUdi_Click(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";
            DataTable dt = new UdiShared().GetRoadNetworkItemUdiReport(radSection.Checked, radIntersect.Checked, radRegion.Checked, radLSampleWise.Checked, radLaneWise.Checked,
                radSectionWise.Checked, radIntersectWise.Checked, radISampleWise.Checked, radRegionWise.Checked, radSecStWise.Checked, int.Parse(ddlMainStreets.SelectedValue),
                int.Parse(ddlRegions.SelectedValue));


            if (dt.Rows.Count > 0)
            {
                string option = "";
                if (radSection.Checked)
                    option = ((radLSampleWise.Checked) ? "radLSampleWise" : ((radLaneWise.Checked) ? "radLaneWise" : ((radSectionWise.Checked) ? "radSectionWise" : "")));
                else if (radIntersect.Checked)
                    option = ((radISampleWise.Checked) ? "radISampleWise" : ((radIntersectWise.Checked) ? "radIntersectWise" : ""));
                else if (radRegion.Checked)
                    option = ((radRegionWise.Checked) ? "radRegionWise" : ((radSecStWise.Checked) ? "radSecStWise" : ""));
                else
                    option = "";

                Session.Add("option", option);
                Session.Add("ReportData", dt);
                string url = "ViewUdiCompareReport.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            }
            else
                lblAddFeedback.Text = Feedback.NoData();
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("UdiCompareReport.aspx", false);
    }   

}