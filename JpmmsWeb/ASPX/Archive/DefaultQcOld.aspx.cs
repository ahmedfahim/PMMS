using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Archive_DefaultQcOld : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        pnlSearch.Visible = false;
        pnlEntry.Visible = false;
        btnSearch.Visible = false;
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();
            ddlRegionSecondaryStreets.SelectedValue = "0";

            lblRegionSum.Text = Region.GetRegionSampleAreaSum(int.Parse(ddlRegions.SelectedValue)).ToString("N2");
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
        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        rntxtQcArea.Text = "";
        rntxtSurvArea.Text = "";
        lblFeedback.Text = "";
    }


    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            int userID = int.Parse(Session["UserID"].ToString());

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = new QcCheck().InsertRegionQcCheckRecord(rdtpQcDate.SelectedDate, rdtpSurveyDate.SelectedDate, int.Parse(ddlSurveyor.SelectedValue),
                int.Parse(ddlQcSurveyor.SelectedValue), int.Parse(ddlRegions.SelectedValue), int.Parse(ddlRegionSecondaryStreets.SelectedValue), rntxtSurvArea.Value,
                rntxtQcArea.Value, Session["UserName"].ToString(), userID);

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

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        //Response.Redirect("RegionQC.aspx", false);
        try
        {
            ClearQcData(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void gvQChecks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvQChecks.SelectedValue != null)
        {
            gvQcDetails.Visible = true;
            gvQcDistress.Visible = true;
            pnlDists.Visible = false;
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

    private bool ValidateDistressInfo()
    {
        if (ddlDistresses.SelectedValue == "-1")
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
            if (!ValidateDistressInfo())
                return;


            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

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

    protected void odsQChecks_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void gvQChecks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
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

    protected void gvQcDistress_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        SearchRegion1.Visible = true;
    }

    protected void OnSetSearchChanged()
    {
        try
        {
            int selectedID = SearchRegion1.SelectedRegionID;
            if (selectedID != 0)
            {
                ddlRegions.SelectedValue = selectedID.ToString();
                ddlRegions_SelectedIndexChanged(new Object(), new EventArgs());
                SearchRegion1.Visible = false;
            }
            else
            {
                SearchRegion1.Visible = false;
                ddlRegions.SelectedValue = "0";
                ddlRegions_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
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
        ddlRegionSearch.SelectedValue = "0";

        btnSearch_Click(sender, e);
    }

    protected void lnkRemoveDistress_Click(object sender, CommandEventArgs e)
    {
        //e.CommandArgument 
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            new QcCheck().RemoveFailedQcRegionDistress(int.Parse(e.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lnkRemoveDistress_Click(object sender, EventArgs e)
    {

    }

    protected void lbtnPagingNO_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            // pnlSurvey.Visible = false;
            gvQChecks.SelectedIndex = -1;
            gvQChecks.AllowPaging = true;
            gvQChecks.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void lbtnPagingYes_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            // pnlSurvey.Visible = false;
            gvQChecks.SelectedIndex = -1;
            gvQChecks.AllowPaging = false;
            gvQChecks.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
}