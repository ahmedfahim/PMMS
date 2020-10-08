using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_ReportIntersectionInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            radSectionsbyStreet_CheckedChanged(sender, e);
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radAllSectionsOrderBySectionNo.Checked || radAllSectionsOrderByStreet.Checked || radSectionsbyStreet.Checked || radSectionsSurroundingRegion.Checked)
            {
                DataTable dt = new MainStreetSection().GetAllSectionsReport(radAllSectionsOrderBySectionNo.Checked, radAllSectionsOrderByStreet.Checked,
                    radSectionsbyStreet.Checked, int.Parse(ddlMainStreets.SelectedValue), radSectionsSurroundingRegion.Checked, int.Parse(ddlRegionSurrounding.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    Session.Add("type", "section");
                    Session.Add("ReportData", dt);
                    string url = "ViewNetworkInfoReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radAllIntersectionsOrderBySectionNo.Checked || radAllIntersectionsOrderByStreet.Checked || radMainstIntersects.Checked)
            {

                DataTable dt = new Intersection().PrepareIntersectionsInfoReport(radAllIntersectionsOrderBySectionNo.Checked, int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("type", "intersect");
                    Session.Add("ReportData", dt);
                    string url = "ViewNetworkInfoReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radAllOrderByDistrict.Checked || radAllOrderByRegion.Checked || radByRegionDistMunic.Checked)
            {
                DataTable dt = new SecondaryStreets().PrepareRegionSecondaryStreetsInfoReport(radAllOrderByRegion.Checked, radByRegionDistMunic.Checked, ddlRegionWise.SelectedValue,
                    radRegion.Checked, radSubdist.Checked, radDist.Checked, radMunic.Checked);

                if (dt.Rows.Count > 0)
                {
                    Session.Add("Type", ((radAllOrderByRegion.Checked) ? "Region" : "District"));
                    Session.Add("ReportData", dt);
                    string url = "ViewNetworkInfoReport.aspx";
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

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportIntersectionInfo.aspx", false);
        //lblFeedback.Text = "";

        //radAllIntersectionsOrderBySectionNo.Checked = true;
        //radAllIntersectionsOrderByStreet.Checked = false;
    }

    protected void radAllSectionsOrderBySectionNo_CheckedChanged(object sender, EventArgs e)
    {
        //ddlMainStreets.Enabled = false;
        radSectionsbyStreet_CheckedChanged(sender, e);
    }

    protected void radSectionsbyStreet_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = (radSectionsbyStreet.Checked || radMainstIntersects.Checked);
        pnlRegions.Visible = radByRegionDistMunic.Checked ;
        ddlRegionSurrounding.Visible = radSectionsSurroundingRegion.Checked;

        ddlMainStreets.SelectedValue = "0";
        ddlRegionSurrounding.SelectedValue = "0";
        ddlRegionWise.SelectedValue = "0";
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegionWise.Items.Clear();
            ddlRegionWise.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionWise.DataBind();
            ddlRegionWise.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radSectionsSurroundignRegion_CheckedChanged(object sender, EventArgs e)
    {
        radSectionsbyStreet_CheckedChanged(sender, e);
    }

}