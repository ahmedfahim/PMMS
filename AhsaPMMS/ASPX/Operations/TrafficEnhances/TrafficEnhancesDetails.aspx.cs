using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Operations_TrafficEnhances_TrafficEnhancesDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                Response.Redirect("SearchTrafficEnhances.aspx", false);

            btnCancelLocation_Click(sender, e);
        }
    }

    protected void btnAddLocation_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblAddFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = false;
            //int maintOrderDetailID = int.Parse(gvMaintainOrdersDetails.SelectedValue.ToString());
            int trafficEnhanceID = int.Parse(Request.QueryString["ID"]);
            int sectionID = int.Parse(ddlMainStreetSection.SelectedValue);
            int mainStID = int.Parse(ddlMainStreets.SelectedValue);
            int intersectID = int.Parse(ddlMainStreetIntersection.SelectedValue);

            if (radSection.Checked)
                saved = new TrafficEnhances().AddTrafficEnhanceLocationsForMainStreets(trafficEnhanceID, radSection.Checked, radIntersect.Checked, mainStID, sectionID);
            else if (radIntersect.Checked)
                saved = new TrafficEnhances().AddTrafficEnhanceLocationsForMainStreets(trafficEnhanceID, radSection.Checked, radIntersect.Checked, mainStID, intersectID);
            else if (radRegion.Checked)
                saved = new TrafficEnhances().AddTrafficEnhanceLocationsforRegions(trafficEnhanceID, int.Parse(ddlRegions.SelectedValue), int.Parse(ddlSecST.SelectedValue),
                    chkLandUse.Checked, txtLandUseDetails.Text);

            if (saved)
            {
                lblAddFeedback.Text = Feedback.InsertSuccessfull();
                gvLocations.DataBind();
                btnCancelLocation_Click(sectionID, e);
            }
            else
                lblAddFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelLocation_Click(object sender, EventArgs e)
    {
        lblAddFeedback.Text = "";
        pnlLandUse.Visible = false;
        chkLandUse.Checked = false;
        txtLandUseDetails.Text = "";

        radIntersect.Checked = false;
        radRegion.Checked = false;
        radSection.Checked = true;
        radSection_CheckedChanged(sender, e);
    }

    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlMainStreetSection.Visible = true;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = false;
        ddlSecST.Visible = false;
        pnlLandUse.Visible = false;
        //ddlRegionNames.Visible = false;
        //ddlMunic.Visible = false;
        chkLandUse.Checked = false;
        txtLandUseDetails.Text = "";

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radIntersect_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = true;
        ddlRegions.Visible = false;
        ddlSecST.Visible = false;
        //ddlRegionNames.Visible = false;
        //ddlMunic.Visible = false;
        pnlLandUse.Visible = false;
        chkLandUse.Checked = false;
        txtLandUseDetails.Text = "";

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = true;
        ddlSecST.Visible = true;
        //ddlRegionNames.Visible = false;
        //ddlMunic.Visible = false;
        pnlLandUse.Visible = true;
        txtLandUseDetails.Text = "";

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }    

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radSection.Checked)
            {
                ddlMainStreetSection.Items.Clear();
                ddlMainStreetSection.Items.Add(new ListItem("اختيار", "0"));
                ddlMainStreetSection.DataBind();
            }
            else if (radIntersect.Checked)
            {
                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.Items.Add(new ListItem("اختيار", "0"));
                ddlMainStreetIntersection.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsTrafficEnhanceDetails_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.DeleteSuccessfull();
    }

    protected void odsTrafficEnhanceDetails_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.InsertSuccessfull();
            gvTrafficEnhanceDetails.SelectedIndex = -1;
            //pnlLocations.Visible = false;
        }
    }

    protected void odsTrafficEnhanceDetails_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void gvTrafficEnhanceDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvTrafficEnhanceDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlSecST.Items.Clear();
            ddlSecST.Items.Add(new ListItem("اختيار", "0"));
            ddlSecST.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsTrafficEnhanceLocations_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblAddFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblAddFeedback.Text = Feedback.DeleteSuccessfull();
            gvLocations.DataBind();
        }
    }

    protected void gvLocations_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void FormView2_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void chkLandUse_CheckedChanged(object sender, EventArgs e)
    {

    }

}