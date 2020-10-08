using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_QC_SectionsQC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            int userID = int.Parse(Session["UserID"].ToString());

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = new QcCheck().InsertSectionQcCheckRecord(rdtpQcDate.SelectedDate, rdtpSurveyDate.SelectedDate, int.Parse(ddlSurveyor.SelectedValue),
                int.Parse(ddlQcSurveyor.SelectedValue), int.Parse(ddlSections.SelectedValue), int.Parse(ddlSamples.SelectedValue), ddlLanes.SelectedItem.Text, userID);

            if (saved)
            {
                ClearQcData(sender, e);
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvQChecks.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    private void ClearQcData(object sender, EventArgs e)
    {
        rdtpQcDate.SelectedDate = null;
        rdtpSurveyDate.SelectedDate = null;
        ddlSurveyor.SelectedValue = "0";
        ddlQcSurveyor.SelectedValue = "0";
        ddlMainSt.SelectedValue = "0";
        ddlMainSt_SelectedIndexChanged(sender, e);
        ddlSections_SelectedIndexChanged(sender, e);
        ddlLanes_SelectedIndexChanged(sender, e);

        lblFeedback.Text = "";
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        try
        {
            ClearQcData(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlSections.Items.Clear();
            ddlSections.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlSections.DataBind();
            ddlSections.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlLanes.Items.Clear();
            ddlLanes.Items.Add(new ListItem("اختيار", "0"));
            ddlLanes.DataBind();

            lblSectionAreaSum.Text = MainStreetSection.GetSectionSampleAreaSum(int.Parse(ddlSections.SelectedValue)).ToString("N2");
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlLanes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlSamples.Items.Clear();
            ddlSamples.Items.Add(new ListItem("اختيار", "0"));
            ddlSamples.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsQChecks_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.DeleteSuccessfull();
            gvQChecks_SelectedIndexChanged(sender, e);
        }
    }

    protected void gvQChecks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvQChecks.SelectedValue != null)
        {
            gvQcDetails.Visible = true;
            gvQcDistress.Visible = true;
            pnlDists.Visible = true;
            frvRating.Visible = true;
            pnlData.Visible = true;

            ddlDistresses.SelectedValue = "-1";
            ddlDistresses_SelectedIndexChanged(sender, e);
        }
        else
        {
            gvQcDetails.Visible = false;
            gvQcDistress.Visible = false;
            pnlDists.Visible = false;
            frvRating.Visible = false;
            pnlData.Visible = false;
        }
    }

    protected void ddlDistresses_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDistressSeverity.Items.Clear();
            ddlDistressSeverity.DataBind();

            if (ddlDistresses.SelectedValue == "0")
            {
                // نوع العيب المختار نظيف فلاداعي لإدخال المساحة والشدة
                ddlDistressSeverity.SelectedValue = "N";
                ddlDistressSeverity.Enabled = false;
            }
            else
            {
                ddlDistressSeverity.Enabled = true;
                //ddlDistressSeverity.SelectedValue = "N";
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


    private bool ValidateDistressInfo()
    {
        if (ddlDistresses.SelectedValue == "0")
        {
            ddlDistresses.Focus();
            throw new Exception("الرجاء اختيار العيب");
        }
        else if (ddlDistressSeverity.SelectedValue == "N")
        {
            ddlDistressSeverity.Focus();
            throw new Exception("الرجاء اختيار الشدة");
        }
        else if (string.IsNullOrEmpty(rntxtDistSurvArea.Text))
        {
            rntxtDistSurvArea.Focus();
            throw new Exception("الرجاء إدخال كمية المساح");
        }
        else if (string.IsNullOrEmpty(rntxtDistQcArea.Text))
        {
            rntxtDistQcArea.Focus();
            throw new Exception("الرجاء إدخال كمية المراقب");
        }
        else
            return true;
    }

    protected void btnSaveDist_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (!ValidateDistressInfo())
                return;


            bool saved = new QcCheck().AddQCheckDistressRecord(int.Parse(gvQChecks.SelectedValue.ToString()), int.Parse(ddlDistresses.SelectedValue),
                ddlDistressSeverity.SelectedValue[0], double.Parse(rntxtDistSurvArea.Text), double.Parse(rntxtDistQcArea.Text));

            if (saved)
            {
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvQcDistress.DataBind();
                gvQcDetails.DataBind();
                frvRating.DataBind();

                btnCancelDist_Click(sender, e);
                // rating update
            }
            else
                lblFeedback.Text = Feedback.InsertException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelDist_Click(object sender, EventArgs e)
    {
        try
        {
            ddlDistresses.SelectedValue = "-1";
            //ddlDistressSeverity.SelectedValue = "N";

            rntxtDistSurvArea.Enabled = true;
            rntxtDistQcArea.Enabled = true;
            ddlDistressSeverity.Enabled = true;

            ddlDistressSeverity.Items.Clear();
            ddlDistressSeverity.DataBind();

            rntxtDistSurvArea.Text = "0";
            rntxtDistQcArea.Text = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsQCheckDists_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            try
            {
                lblFeedback.Text = Feedback.DeleteSuccessfull();
                gvQcDistress.DataBind();
                gvQcDetails.DataBind();
                frvRating.DataBind();
            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }
    }

    protected void odsQCheckDists_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            try
            {
                lblFeedback.Text = Feedback.UpdateSuccessfull();
                gvQcDistress.DataBind();
                gvQcDetails.DataBind();
                frvRating.DataBind();
            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }
    }

    protected void gvQChecks_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvQChecks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvQcDistress_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvQcDistress_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        SearchMainSt1.Visible = true;
    }

    protected void lbtnSearchSection_Click(object sender, EventArgs e)
    {
        if (ddlMainSt.SelectedValue != "0")
        {
            Session["MainStreetID"] = ddlMainSt.SelectedValue;
            SearchSection1.Visible = true;
        }
        else
            SearchSection1.Visible = false;
    }

    protected void onMainStSearchChanged()
    {
        try
        {
            int selectedID = SearchMainSt1.SelectedMainStreetID;
            if (selectedID != 0)
            {
                ddlMainSt.SelectedValue = selectedID.ToString();
                ddlMainSt_SelectedIndexChanged(new Object(), new EventArgs());
                SearchMainSt1.Visible = false;
            }
            else
            {
                SearchMainSt1.Visible = false;
                ddlMainSt.SelectedValue = "0";
                ddlMainSt_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void onSectionSearchChanged()
    {
        try
        {
            int selectedID = SearchSection1.SelectedSectionID;
            if (selectedID != 0)
            {
                ddlSections.SelectedValue = selectedID.ToString();
                ddlSections_SelectedIndexChanged(new Object(), new EventArgs());
                SearchSection1.Visible = false;
            }
            else
            {
                SearchSection1.Visible = false;
                ddlSections.SelectedValue = "0";
                ddlSections_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsQChecks_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.UpdateSuccessfull();
            gvQChecks_SelectedIndexChanged(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (pnlSearch.Visible)
        {
            pnlSearch.Visible = false;
            pnlEntry.Visible = true;
        }
        else
        {
            pnlSearch.Visible = true;
            pnlEntry.Visible = false;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        ddlSurveyorSearch.SelectedValue = "0";
        ddlMainStSearch.SelectedValue = "0";

        btnSearch_Click(sender, e);
    }

    protected void frvRating_DataBound(object sender, EventArgs e)
    {
        //frvRating.FindControl("lnkRemoveDistress
    }

    protected void lnkRemoveDistress_Click(object sender, CommandEventArgs e)
    {
        //e.CommandArgument 
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            new QcCheck().RemoveFailedQcSectionDistress(int.Parse(e.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lnkRemoveDistress_Click(object sender, EventArgs e)
    {

    }

    protected void ddlMainSt_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlMainSt_SelectedIndexChanged(o, (EventArgs)e);
    }

}
