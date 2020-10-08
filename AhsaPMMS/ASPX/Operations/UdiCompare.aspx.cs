using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Operations_UdiCompare : System.Web.UI.Page
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
        gvUdi.DataSource = null;
        gvUdi.DataBind();
    }

    private void BindSections()
    {
        ddlMainStreetSection.Items.Clear();
        ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
        ddlMainStreetSection.DataBind();
        ddlMainStreetSection.SelectedValue = "0";
    }

    private void BindIntersects()
    {
        ddlMainStreetIntersection.Items.Clear();
        ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
        ddlMainStreetIntersection.DataBind();
        ddlMainStreetIntersection.SelectedValue = "0";
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

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

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

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        ClearGridView();
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = true;
        ddlRegionSecondaryStreets.Visible = true;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
        ClearGridView();
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";
            if (radSection.Checked)
                BindSections();
            else if (radIntersect.Checked)
                BindIntersects();
            else
            {
                BindSections();
                BindIntersects();
            }

            ClearGridView();
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearGridView();
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    protected void ddlRegionSecondaryStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearGridView();
    }

    protected void btnShowMaintDecUdi_Click(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";

            if (radSection.Checked && (ddlMainStreetSection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetSection.SelectedValue)))
                throw new Exception(Feedback.NoSectionSelected());
            else if (radIntersect.Checked && (ddlMainStreetIntersection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetIntersection.SelectedValue)))
                throw new Exception(Feedback.NoIntersectionSelected());
            else if (radRegion.Checked && (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue)))
                throw new Exception(Feedback.NoRegionSelected());


            DataTable dt = UdiShared.GetRoadNetworkItemUdi(ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlRegions.SelectedValue,
                ddlRegionSecondaryStreets.SelectedValue);

            if (dt.Rows.Count > 0)
            {
                gvUdi.DataSource = dt;
                gvUdi.DataBind();
            }
            else
            {
                gvUdi.DataSource = null;
                gvUdi.DataBind();
                throw new Exception("غير ممسوح");
            }

        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("UdiCompare.aspx", false);
    }

}