using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Operations_Feedbacks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddContract_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            bool saved = new MaintenanceFeedback().Insert(CONTRACT_NOTextBox.Text, int.Parse(ddlContractors.SelectedValue), txtJobOrderNo.Text,
                rdtpJobOrder.SelectedDate, rdtpFinishDate.SelectedDate);

            if (saved)
            {
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvFeedbacks.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        Response.Redirect("Feedbacks.aspx", false);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            if (gvFeedbacks.SelectedValue == null)
                throw new Exception("الرجاء اختيار عملية صيانة لشبكة الطرق");

            bool saved = new MaintenanceFeedback().InsertFeedbackLocation(radSection.Checked, radIntersect.Checked, radRegion.Checked, ddlMainStreets.SelectedValue,
                          ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlSamples.SelectedValue, ddlRegions.SelectedValue,
                          ddlRegionSecondaryStreets.SelectedValue, int.Parse(ddlMaintDecisions.SelectedValue), rdtpMaintDate.SelectedDate, lblUdiBefore.Text,
                          int.Parse(lblUdiAfter.Text), int.Parse(gvFeedbacks.SelectedValue.ToString()));

            if (saved)
            {
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvFeedbackDetails.DataBind();

                btnCancelLocation_Click(sender, e);
            }
            else
                lblFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelLocation_Click(object sender, EventArgs e)
    {
        rdtpMaintDate.SelectedDate = DateTime.Today;

        radIntersect.Checked = false;
        radRegion.Checked = false;
        radSection.Checked = true;
        radSection_CheckedChanged(sender, e);

        ddlMaintDecisions.SelectedValue = "0";
        ddlMaintDecisions_SelectedIndexChanged(sender, e);
    }


    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        pnlMainSt.Visible = true;
        lblFeedback.Text = "";
        lblUdiAfter.Text = "";

        ddlMainStreetIntersection.SelectedValue = "0";
        ddlMainStreetIntersection.Visible = false;
        ddlMainStreetSection.Visible = true;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        ddlRegions.Enabled = false;
        ddlRegionSecondaryStreets.Enabled = false;
    }

    protected void radIntersect_CheckedChanged(object sender, EventArgs e)
    {
        pnlMainSt.Visible = true;
        lblFeedback.Text = "";
        lblUdiAfter.Text = "";

        ddlMainStreetSection.SelectedValue = "0";
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = true;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        ddlRegions.Enabled = false;
        ddlRegionSecondaryStreets.Enabled = false;
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        pnlMainSt.Visible = false;
        lblFeedback.Text = "";
        lblUdiAfter.Text = "";

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        ddlRegions.Enabled = true;
        ddlRegionSecondaryStreets.Enabled = true;
    }


    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblUdiAfter.Text = "";

            if (radSection.Checked)
            {
                ddlMainStreetSection.Items.Clear();
                ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetSection.DataBind();
                ddlMainStreetSection.SelectedValue = "0";
                ddlMainStreetSection_SelectedIndexChanged(sender, e);
            }
            else if (radIntersect.Checked)
            {
                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetIntersection.DataBind();
                ddlMainStreetIntersection.SelectedValue = "0";
                ddlMainStreetIntersection_SelectedIndexChanged(sender, e);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblUdiAfter.Text = "";

            ddlSamples.Items.Clear();
            ddlSamples.Items.Add(new ListItem("كل العينات", "0"));
            ddlSamples.DataBind();
            ddlSamples.SelectedValue = "0";

            // get UDI
            decimal? udi = UdiShared.GetRoadNetworkItemUdi(ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlSamples.SelectedValue,
                  ddlRegions.SelectedValue, ddlRegionSecondaryStreets.SelectedValue);

            lblUdiBefore.Text = (udi == null) ? "" : udi.ToString();
            ddlMaintDecisions_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreetSection_SelectedIndexChanged(sender, e);
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();
            ddlRegionSecondaryStreets.SelectedValue = "0";
            ddlRegionSecondaryStreets_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
        // get sample UDI
        try
        {
            lblFeedback.Text = "";
            lblUdiAfter.Text = "";

            decimal? udi = UdiShared.GetRoadNetworkItemUdi(ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlSamples.SelectedValue,
                 ddlRegions.SelectedValue, ddlRegionSecondaryStreets.SelectedValue);

            lblUdiBefore.Text = (udi == null) ? "" : udi.ToString();
            ddlMaintDecisions_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegionSecondaryStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblUdiAfter.Text = "";

            decimal? udi = UdiShared.GetRoadNetworkItemUdi(ddlMainStreetSection.SelectedValue, ddlMainStreetIntersection.SelectedValue, ddlSamples.SelectedValue,
                   ddlRegions.SelectedValue, ddlRegionSecondaryStreets.SelectedValue);

            lblUdiBefore.Text = (udi == null) ? "" : udi.ToString();
            ddlMaintDecisions_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMaintDecisions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int? udiAfter = new MaintDecision().GetMaintDecisionNewUDI(int.Parse(ddlMaintDecisions.SelectedValue), lblUdiBefore.Text);
            lblUdiAfter.Text = (udiAfter == null) ? "" : udiAfter.ToString();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsFeedbacks_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.DeleteSuccessfull();
            gvFeedbacks.SelectedIndex = -1;
            gvFeedbacks_SelectedIndexChanged(sender, e);
        }
    }

    protected void odsFeedbacks_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void gvFeedbacks_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDetails.Visible = (gvFeedbacks.SelectedValue != null);
       
        btnCancelLocation_Click(sender, e);
    }

    protected void odsMaintFeedbackDetails_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.DeleteSuccessfull();
    }

    protected void odsMaintFeedbackDetails_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void ddlMainStreets_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(o, (EventArgs)e);
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlMainStreetSection_SelectedIndexChanged(o, (EventArgs)e);
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlMainStreetIntersection_SelectedIndexChanged(o, (EventArgs)e);
    }

    protected void ddlRegions_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlRegions_SelectedIndexChanged(o, (EventArgs)e);
    }

    protected void ddlRegionSecondaryStreets_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlRegionSecondaryStreets_SelectedIndexChanged(o, (EventArgs)e);
    }

}