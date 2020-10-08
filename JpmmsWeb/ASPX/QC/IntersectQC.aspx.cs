using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_QC_IntersectQC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void ddlMainSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlIntersects.Items.Clear();
            ddlIntersects.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlIntersects.DataBind();
            ddlIntersects.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlIntersects_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlSamples.Items.Clear();
            ddlSamples.Items.Add(new ListItem("اختيار", "0"));
            ddlSamples.DataBind();

            // get intersection samples area sum
            lblIntersectAreaSum.Text = Intersection.GetIntersectionSampleAreaSum(int.Parse(ddlIntersects.SelectedValue)).ToString("N2");
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            int userID = int.Parse(Session["UserID"].ToString());

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = new QcCheck().InsertIntersectQcCheckRecord(rdtpQcDate.SelectedDate, rdtpSurveyDate.SelectedDate, int.Parse(ddlSurveyor.SelectedValue),
                int.Parse(ddlQcSurveyor.SelectedValue), int.Parse(ddlIntersects.SelectedValue), int.Parse(ddlSamples.SelectedValue), userID);

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
        ddlIntersects_SelectedIndexChanged(sender, e);

        lblFeedback.Text = "";
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        //Response.Redirect("IntersectQC.aspx", false);
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

    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        SearchMainSt1.Visible = true;
    }

    protected void lbtnSearchIntersect_Click(object sender, EventArgs e)
    {
        if (ddlMainSt.SelectedValue != "0")
        {
            Session["MainStreetID"] = ddlMainSt.SelectedValue;
            SearchIntersect1.Visible = true;
        }
        else
            SearchIntersect1.Visible = false;
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

    protected void onIntersectSearchChanged()
    {
        try
        {
            int selectedID = SearchIntersect1.SelectedIntersectionID;
            if (selectedID != 0)
            {
                ddlIntersects.SelectedValue = selectedID.ToString();
                ddlIntersects_SelectedIndexChanged(new Object(), new EventArgs());
                SearchIntersect1.Visible = false;
            }
            else
            {
                SearchIntersect1.Visible = false;
                ddlIntersects.SelectedValue = "0";
                ddlIntersects_SelectedIndexChanged(new Object(), new EventArgs());
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
        ddlMainStSearch.SelectedValue = "0";

        btnSearch_Click(sender, e);
    }

    protected void lnkRemoveDistress_Click(object sender, CommandEventArgs e)
    {
        //e.CommandArgument 
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            new QcCheck().RemoveFailedQcIntersectDistress(int.Parse(e.CommandArgument.ToString()));
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lnkRemoveDistress_Click(object sender, EventArgs e)
    {

    }

}
