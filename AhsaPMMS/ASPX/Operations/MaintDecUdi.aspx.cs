using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Operations_MaintDecUdi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            radSection_CheckedChanged(sender, e);
    }

    private void ClearGridView()
    {
        //gvMaintDecUdi.DataSource = null;
        //gvMaintDecUdi.DataBind();
    }

    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlMainStreetSection.Visible = true;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = false;
        ddlRegionSecondaryStreets.Visible = false;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
        ClearGridView();
    }

    protected void radIntersect_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = true;
        ddlRegions.Visible = false;
        ddlRegionSecondaryStreets.Visible = false;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
        ClearGridView();
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = true;
        ddlRegionSecondaryStreets.Visible = true;

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
        ClearGridView();
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();
            ddlRegionSecondaryStreets.SelectedValue = "0";

            ClearGridView();
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";
            if (radSection.Checked)
            {
                ddlMainStreetSection.Items.Clear();
                ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetSection.DataBind();
                ddlMainStreetSection.SelectedValue = "0";
            }
            else if (radIntersect.Checked)
            {
                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetIntersection.DataBind();
                ddlMainStreetIntersection.SelectedValue = "0";
            }

            ClearGridView();
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnShowMaintDecUdi_Click(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";

            DataTable dt = new DataTable();
            DataTable dtMaintOrders = new MaintenanceOrders().GetMaintenanceOrdersByLocation(radSection.Checked, radIntersect.Checked, radRegion.Checked,
                ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlRegionSecondaryStreets.SelectedValue);

            DataTable dtFeedbacks = new MaintenanceFeedback().Search(radSection.Checked, radIntersect.Checked, radRegion.Checked, ddlMainStreets.SelectedValue,
                ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, "0", ddlRegions.SelectedValue, ddlRegionSecondaryStreets.SelectedValue);


            if (radSection.Checked)
            {
                if (ddlMainStreetSection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetSection.SelectedValue))
                    throw new Exception(Feedback.NoSectionSelected());

                dt = new MaintenanceDecisions().GetMaintDecisionUdi(true, false, false, int.Parse(ddlMainStreetSection.SelectedValue));
            }
            else if (radIntersect.Checked)
            {
                if (ddlMainStreetIntersection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetIntersection.SelectedValue))
                    throw new Exception(Feedback.NoIntersectionSelected());

                dt = new MaintenanceDecisions().GetMaintDecisionUdi(false, true, false, int.Parse(ddlMainStreetIntersection.SelectedValue));
            }
            else if (radRegion.Checked)
            {
                if (ddlRegionSecondaryStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegionSecondaryStreets.SelectedValue))
                    throw new Exception(Feedback.NoSecondaryStreetSelected());

                dt = new MaintenanceDecisions().GetMaintDecisionUdi(false, false, true, int.Parse(ddlRegionSecondaryStreets.SelectedValue));
            }


            gvMaintDecUdi.DataSource = dt;
            gvMaintDecUdi.DataBind();

            gvMaintOrders.DataSource = dtMaintOrders;
            gvMaintOrders.DataBind();

            gvFeedbacks.DataSource = dtFeedbacks;
            gvFeedbacks.DataBind();

        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintDecUdi.aspx", false);
    }

}