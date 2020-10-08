using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_SectionsInfoReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            // ChkMidIsland.Checked, ChkSideIsland.Checked, ChkSideWalk.Checked, radIslandConside.Checked, txtSectionNo.Text,

            DataTable dt = new MainStreetSection().AdvancedSearch(int.Parse(ddlMainStreets.SelectedValue), txtSectionTitle.Text, ddlDirection.SelectedValue,
                !radSideCurbBoth.Checked, radHasSideCurb.Checked, radTreesConsider.Checked, ChkAg_MID.Checked, ChkAg_SID.Checked, ChkAg_SEC.Checked, radUsesConsider.Checked,
                ChkHousing.Checked, ChkCommercial.Checked, ChkPublics.Checked, ChkIndisterial.Checked, ChkGarden.Checked, ChkRest_House.Checked, radHolesConsider.Checked,
                ChkDrinage_CBs.Checked, ChkDrinage_MH.Checked, ChkSTC_MH.Checked, ChkElect_MH.Checked, ChkWater_MH.Checked, ChkSewage_MH.Checked, radDrillingsConsider.Checked,
                chkDrillingSTC.Checked, chkDrillingElec.Checked, chkDrillingWater.Checked, chkDrillingSewage.Checked, !radSoilBoth.Checked, radSoilExists.Checked,
                !radLightBoth.Checked, radLightingExists.Checked, !radBridgesBoth.Checked, radBridgesExists.Checked, !radTunnelBoth.Checked, radTunnelExists.Checked,
                !radR4Both.Checked, radR4Is.Checked, !radR3Both.Checked, radIsR3.Checked, rdtpFrom.SelectedDate, rdtpTo.SelectedDate, rdtpR3From.SelectedDate, rdtpR3To.SelectedDate,
                !radPedestBridgeBoth.Checked, radPedestBridgeExists.Checked, !radSurveyedBoth.Checked, radSurveyed.Checked, !radMidIslandBoth.Checked, radHasMidIsland.Checked,
                !radSideIslandBoth.Checked, radHasSideIsland.Checked, ddlRegions.SelectedValue);


            if (dt.Rows.Count > 0)
            {
                // prepare to show Intersections Info report
                Session.Add("ReportData", dt);
                string url = "ViewSectionInfoReport.aspx";
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
        Response.Redirect("SectionsInfoReport.aspx", false);
    }

  
}
