using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;

public partial class ASPX_Regions_Regiondistresses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            Session["PhotoChanged"] = false;
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            pnlSurvey.Visible = false;

            gvRegionSamples.DataBind();
            gvRegionSamples.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);

        pnlSurvey.Visible = false;
    }

    protected void btnNewSurveySave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            int newSurveyNo = (int)rntxtSurveyNo.Value;
            string regionNo = ((Label)frvRegionInfo.FindControl("REGION_NOLabel")).Text;
            string user = Session["UserName"].ToString();
            int userID = int.Parse(Session["UserID"].ToString());

            bool saved = new DistressEntry().InsertNewSecondaryStreetSampleSurvey(int.Parse(gvRegionSamples.SelectedValue.ToString()), regionNo, newSurveyNo,
                ((DateTime)rdtpSurveyDate.SelectedDate).ToString("dd/MM/yyyy"), user, userID, int.Parse(ddlRegions.SelectedValue));

            if (saved)
            {
                radlOldSurveys.Items.Clear();
                radlOldSurveys.DataBind();
                radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count > 0) ? 0 : -1;

                pnlDistressDetails.Visible = true;
                btnCancelDistress_Click(sender, e);

                radOldSurvey.Checked = true;
                radNewSurvey.Checked = false;
                radOldSurvey_CheckedChanged(sender, e);

                radlOldSurveys.Visible = true;
                pnlNewSurvey.Visible = false;
                lbtnAddDistress.Visible = true;

                lblSurveysCount.Text = radlOldSurveys.Items.Count.ToString();
                lblSurveyNo.Text = rntxtSurveyNo.Text;
                lblSurveyDate.Text = ((DateTime)rdtpSurveyDate.SelectedDate).ToString("dd/MM/yyyy");

                radlOldSurveys.SelectedValue = newSurveyNo.ToString();
                radlOldSurveys_SelectedIndexChanged(sender, e);
            }
            else
            {
                lblFeedback.Text = Feedback.InsertException();
                pnlDistressDetails.Visible = false;
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnNewSurveyCancel_Click(object sender, EventArgs e)
    {
        radNewSurvey.Checked = false;
        radOldSurvey.Checked = true;
        radOldSurvey_CheckedChanged(sender, e);
    }

    protected void radOldSurvey_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (radOldSurvey.Checked)
            {
                pnlDistressDetails.Visible = false;
                pnlNewSurvey.Visible = false;
                radlOldSurveys.Visible = true;
                radlOldSurveys.DataBind();

                lblSurveysCount.Text = radlOldSurveys.Items.Count.ToString();
                lbtnAddDistress.Visible = (radlOldSurveys.Items.Count > 0);
                if (radlOldSurveys.Items.Count == 1)
                {
                    radlOldSurveys.SelectedValue = DistressSurvey.GetLastSecondaryStreetSurveyNumber(int.Parse(gvRegionSamples.SelectedValue.ToString())).ToString();
                    radlOldSurveys_SelectedIndexChanged(sender, e);
                    //gvDistresses.DataBind();
                }
                else if (radlOldSurveys.Items.Count > 1)
                    radlOldSurveys.SelectedIndex = 0; //-1;
                else
                    radlOldSurveys.SelectedIndex = -1;
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radNewSurvey_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (radNewSurvey.Checked)
            {
                pnlNewSurvey.Visible = true;
                pnlDistressDetails.Visible = false;
                radlOldSurveys.Visible = false;
                lbtnAddDistress.Visible = false;

                radlOldSurveys.SelectedIndex = -1;

                lblSurveysCount.Text = radlOldSurveys.Items.Count.ToString();
                rntxtSurveyNo.Text = DistressSurvey.GetNextSecondaryStreetSurveyNumber(int.Parse(gvRegionSamples.SelectedValue.ToString())).ToString();

                string date = DistressSurvey.GetRegionCurrentSurveyDate(int.Parse(ddlRegions.SelectedValue), int.Parse(rntxtSurveyNo.Text));
                rdtpSurveyDate.SelectedDate = (date == "0") ? DateTime.Today : DateTime.Parse(date);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radlOldSurveys_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvDistresses.DataBind();
            DataTable dt = DistressSurvey.GetRegionSeondaryStreetSampleSurveyNumDate(int.Parse(gvRegionSamples.SelectedValue.ToString()), int.Parse(radlOldSurveys.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lblSurveyNo.Text = dr["SURVEY_NO"].ToString();
                lblSurveyDate.Text = DateTime.Parse(dr["SURVEY_DATE"].ToString()).ToString("dd/MM/yyyy");

                lbtnAddDistress.Visible = true;
            }
            else
            {
                pnlDistressDetails.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void gvRegionSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (gvRegionSamples.SelectedValue != null)
            {
                lblFeedback.Text = "";
                lblDistressFeedback.Text = "";

                pnlSurvey.Visible = true;
                pnlDistressDetails.Visible = false;


                bool sampleHasSurveys = new DistressSurvey().SecondaryStreetSampleHasSurveys(int.Parse(gvRegionSamples.SelectedValue.ToString()));
                bool sampleAreaReady = SecondaryStreets.SecondaryStreetSampleReadyForDistressEntry(int.Parse(gvRegionSamples.SelectedValue.ToString()));

                if (sampleAreaReady)
                {
                    if (sampleHasSurveys)
                    {
                        radNewSurvey.Checked = false;
                        radOldSurvey.Checked = true;
                        radOldSurvey_CheckedChanged(sender, e);
                    }
                    else
                    {
                        radOldSurvey.Checked = false;
                        radNewSurvey.Checked = true;
                        radNewSurvey_CheckedChanged(sender, e);
                    }
                }
                else
                {
                    pnlSurvey.Visible = false;
                    lblFeedback.Text = Feedback.NonReadySample(); // "العينة غير جاهزة لعدم حساب المساحة، لايمكن إدخال العيوب عليها";
                }
            }
            else
                pnlSurvey.Visible = false;

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnSaveDistress_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblDistressFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (radlOldSurveys.SelectedValue == "")
                throw new Exception("الرجاء اختيار رقم وتاريخ المسح");
            else if (gvRegionSamples.SelectedValue == null)
                throw new Exception("الرجاء اختيار عينة الشارع الفرعي لإدخال عيوبها");
            else if (ddlDistresses.SelectedValue == "-1")
                throw new Exception(Feedback.NoDistressSelected());
            else if (rntxtArea.Value == null)
                throw new Exception("الرجاء إدخال مساحة العيب");
            else if (int.Parse(ddlDistresses.SelectedValue) > 0 && ddlDistressSeverity.SelectedValue == "N")
                throw new Exception(Feedback.NoDistressSeveritySelected());


            // saving the distress

            string user = Session["UserName"].ToString();
            string regionNo = ((Label)frvRegionInfo.FindControl("REGION_NOLabel")).Text;
            double? sampleArea = double.Parse(gvRegionSamples.Rows[gvRegionSamples.SelectedIndex].Cells[5].Text);

            int userID = int.Parse(Session["UserID"].ToString());
            int surveyNum = int.Parse(lblSurveyNo.Text);
            int sampleID = int.Parse(gvRegionSamples.SelectedValue.ToString());

            // imageFileName,
            bool saved = new DistressEntry().InsertRegionSecondaryStreetDistress(sampleID, lblSurveyDate.Text, surveyNum, ddlDistresses.SelectedItem.Text,
                ddlDistressSeverity.SelectedValue[0], rntxtArea.Value, sampleArea, regionNo, txtDistressNotes.Text, user, int.Parse(ddlRegions.SelectedValue), userID);

            if (saved)
            {
                btnCancelDistress_Click(sender, e);
                lblDistressFeedback.Text = Feedback.InsertSuccessfull();
                gvDistresses.DataBind();
            }
            else
            {
                lblDistressFeedback.Text = Feedback.InsertException();
            }

        }
        catch (Exception ex)
        {
            lblDistressFeedback.Text = ex.Message;
        }
        finally
        {
            Session["PhotoChanged"] = false;
        }
    }

    protected void btnCancelDistress_Click(object sender, EventArgs e)
    {
        try
        {
            ddlDistresses.SelectedValue = "-1";
            //ddlDistressSeverity.SelectedValue = "N";
            rntxtArea.Text = "";
            txtDistressNotes.Text = "";
            lblDistressFeedback.Text = "";

            //Session["PhotoChanged"] = false;
            rntxtArea.Enabled = true;
            ddlDistressSeverity.Enabled = true;

            ddlDistressSeverity.Items.Clear();
            //ddlDistressSeverity.Items.Add(new ListItem("اختيار", "0"));
            ddlDistressSeverity.DataBind();
            ddlDistresses.Focus();

            string[] surveyDateNum = radlOldSurveys.SelectedItem.Text.Split('-');
            if (surveyDateNum.Length > 0)
            {
                lblSurveyNo.Text = surveyDateNum[0];
                lblSurveyDate.Text = surveyDateNum[1];
            }
            else
                throw new Exception("الرجاء التأكد من رقم المسح");
        }
        catch (Exception ex)
        {
            lblDistressFeedback.Text = ex.Message;
        }
    }

    protected void updDistressImage_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        Session["PhotoChanged"] = true;
    }

    protected void ddlDistresses_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlDistressSeverity.Items.Clear();
            //ddlDistressSeverity.Items.Add(new ListItem("اختيار", "0"));
            ddlDistressSeverity.DataBind();

            if (ddlDistresses.SelectedValue == "0")
            {
                // نوع العيب المختار نظيف فلاداعي لإدخال المساحة والشدة
                rntxtArea.Text = "0";
                ddlDistressSeverity.SelectedValue = "N";
                rntxtArea.Enabled = false;
                ddlDistressSeverity.Enabled = false;
            }
            else
            {
                rntxtArea.Enabled = true;
                ddlDistressSeverity.Enabled = true;
                //ddlDistressSeverity.SelectedValue = "N";
            }
        }
        catch (Exception ex)
        {
            lblDistressFeedback.Text = ex.Message;
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnAddDistress_Click(object sender, EventArgs e)
    {
        pnlDistressDetails.Visible = !pnlDistressDetails.Visible;
        btnCancelDistress_Click(sender, e);
    }

    protected void odsRegionSamples_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void odsSecondaryStSurveyDistresses_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblDistressFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblDistressFeedback.Text = Feedback.UpdateSuccessfull();
            gvDistresses.DataBind();
        }
    }

    protected void odsSecondaryStSurveyDistresses_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblDistressFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            try
            {
                lblDistressFeedback.Text = Feedback.DeleteSuccessfull();

                gvDistresses.DataBind();
                if (gvDistresses.Rows.Count == 0)
                    gvRegionSamples_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblDistressFeedback.Text = ex.Message;
            }
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

    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvDistresses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvDistresses_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvRegionSamples_PageIndexChanged(object sender, EventArgs e)
    {
        gvRegionSamples.SelectedIndex = -1;
        gvRegionSamples_SelectedIndexChanged(sender, e);
    }

}