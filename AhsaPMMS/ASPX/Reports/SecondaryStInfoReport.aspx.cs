using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_SecondaryStInfoReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            ddlRegions.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            DataTable dt = new SecondaryStreets().AdvancedSearch(ddlMunic.SelectedValue, int.Parse(ddlRegions.SelectedValue), txtStNo.Text, txtStName.Text, radUsesConsider.Checked,
                ChkHousing.Checked, ChkCommercial.Checked, ChkPublics.Checked, ChkIndisterial.Checked, ChkGarden.Checked, ChkRest_House.Checked, chkNewlyBuilt.Checked,
                chkSchools.Checked, chkMasjid.Checked, chkSport.Checked, chkHospital.Checked, chkOtherUtils.Checked, radHolesConsider.Checked, ChkDrinage_CBs.Checked,
                ChkDrinage_MH.Checked, ChkSTC_MH.Checked, ChkElect_MH.Checked, ChkWater_MH.Checked, ChkSewage_MH.Checked, radDrillingsConsider.Checked, chkDrillingSTC.Checked,
                chkDrillingElec.Checked, chkDrillingWater.Checked, ChkSewage_MH.Checked, !radSoilBoth.Checked, radSoilExists.Checked, !radLightBoth.Checked, radLightingExists.Checked,
                !radConcreteBlocksBoth.Checked, radConcreteBlocksExists.Checked, !radBumpsBoth.Checked, radBumpsExists.Checked, !radSurveyedBoth.Checked, radSurveyed.Checked);

            if (dt.Rows.Count > 0)
            {
                // prepare to show report
                Session.Add("ReportData", dt);
                string url = "ViewSecondaryStInfoReport.aspx";
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
        Response.Redirect("SecondaryStInfoReport.aspx", false);
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlRegions.Items.Clear();
            ddlRegions.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegions.DataBind();
            ddlRegions.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}
