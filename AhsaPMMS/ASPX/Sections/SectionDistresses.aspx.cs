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
using Telerik.Web.UI;

public partial class ASPX_Sections_SectionDistresses : System.Web.UI.Page
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

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            frvSectionInfo.DataBind();
            radlLanes.DataBind();
            gvLaneSamples.DataBind();
            gvLaneSamples.SelectedIndex = -1;

            pnlSurvey.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreetSection.Items.Clear();
            ddlMainStreetSection.Items.Add(new ListItem("اختيار", "0"));
            ddlMainStreetSection.DataBind();
            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection_SelectedIndexChanged(sender, e);

            gvLaneSamples.DataBind();
            gvLaneSamples.SelectedIndex = -1;
            gvLaneSamples_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
        pnlSurvey.Visible = false;
    }

    protected void odsSectionLanes_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    //protected void gvLanesSamples_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (gvLanesSamples.SelectedValue != null)
    //    {
    //        if (!Lane.LaneSurveyIsComplete(int.Parse(gvLanesSamples.SelectedValue.ToString())))
    //        {
    //            lblFeedback.Text = "لايمكن إدخال العيوب على عينة غير مكتملة المسح، الرجاء إدخال طول وعرض المسار لإكمال المسح";
    //            gvLanesSamples.SelectedIndex = -1;
    //        }
    //    }
    //}


    protected void radlLanes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblDistressFeedback.Text = "";
            lblFeedback.Text = "";

            gvLaneSamples.DataBind();
            gvLaneSamples.SelectedIndex = -1;

            pnlSurvey.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radlLanes_DataBound(object sender, EventArgs e)
    {
        radlLanes_SelectedIndexChanged(sender, e);
    }

    protected void gvLaneSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblDistressFeedback.Text = "";
            lblFeedback.Text = "";

            if (gvLaneSamples.SelectedValue != null)
            {
                lblFeedback.Text = "";
                lblDistressFeedback.Text = "";
                pnlSurvey.Visible = true;
                pnlDistressDetails.Visible = false;

                int sampleID = int.Parse(gvLaneSamples.SelectedValue.ToString());
                bool sampleHasSurveys = new DistressSurvey().SampleHasSurveys(sampleID);
                bool sampleAreaReady = LaneSample.SampleReadyForDistressEntry(sampleID);

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
                    lblFeedback.Text = Feedback.NonReadySample(); 
                }
            }
            else
            {
                pnlSurvey.Visible = false;
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radOldSurvey_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblDistressFeedback.Text = "";
            if (radOldSurvey.Checked)
            {
                pnlNewSurvey.Visible = false;
                radlOldSurveys.Visible = true;
                radlOldSurveys.DataBind();

                lblSurveysCount.Text = radlOldSurveys.Items.Count.ToString();
                lbtnAddDistress.Visible = (radlOldSurveys.Items.Count > 0);
                if (radlOldSurveys.Items.Count >= 1) //== 1)
                {
                    radlOldSurveys.SelectedValue = DistressSurvey.GetLastSectionSurveyNumber(int.Parse(gvLaneSamples.SelectedValue.ToString())).ToString();
                    radlOldSurveys_SelectedIndexChanged(sender, e);
                    radlOldSurveys.SelectedIndex = 0;
                    //gvDistresses.DataBind();
                }
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
                rntxtSurveyNo.Text = DistressSurvey.GetNextSectionSurveyNumber(int.Parse(gvLaneSamples.SelectedValue.ToString())).ToString();

                string date = DistressSurvey.GetSectionCurrentSurveyDate(int.Parse(ddlMainStreetSection.SelectedValue), int.Parse(rntxtSurveyNo.Text));
                rdtpSurveyDate.SelectedDate = (date == "0") ? DateTime.Today : DateTime.Parse(date); // string.IsNullOrEmpty(date)
                //rdtpSurveyDate.SelectedDate = DateTime.Today;
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
            DataRow dr = DistressSurvey.GetSectionSampleSurveyNumDate(int.Parse(gvLaneSamples.SelectedValue.ToString()), int.Parse(radlOldSurveys.SelectedValue)).Rows[0];

            lblSurveyNo.Text = dr["SURVEY_NO"].ToString();
            lblSurveyDate.Text = DateTime.Parse(dr["SURVEY_DATE"].ToString()).ToString("dd/MM/yyyy");

            lbtnAddDistress.Visible = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnNewSurveySave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            int newSurveyNo = (int)rntxtSurveyNo.Value;
            string user = Session["UserName"].ToString();
            int userID = int.Parse(Session["UserID"].ToString());

            bool saved = new DistressEntry().InsertNewSectionSampleSurvey(int.Parse(gvLaneSamples.SelectedValue.ToString()), int.Parse(ddlMainStreetSection.SelectedValue),
                newSurveyNo, ((DateTime)rdtpSurveyDate.SelectedDate).ToString("dd/MM/yyyy"), user, userID, int.Parse(ddlMainStreets.SelectedValue));

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

    protected void btnCancelDistress_Click(object sender, EventArgs e)
    {
        try
        {
            ddlDistresses.SelectedValue = "-1";
            //ddlDistressSeverity.SelectedValue = "N";
            rntxtArea.Text = "";
            txtDistressNotes.Text = "";
            lblDistressFeedback.Text = "";

            Session["PhotoChanged"] = false;
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

    protected void btnSaveDistress_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblDistressFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            //string imageFileName = "";
            if (radlOldSurveys.SelectedValue == "")
                throw new Exception(Feedback.NoSurveyDateNum());
            else if (gvLaneSamples.SelectedValue == null)
                throw new Exception(Feedback.NoSectionSampleSelected());
            else if (ddlDistresses.SelectedValue == "-1")
                throw new Exception(Feedback.NoDistressSelected());
            else if (rntxtArea.Value == null)
                throw new Exception("الرجاء إدخال مساحة العيب");
            else if (int.Parse(ddlDistresses.SelectedValue) > 0 && ddlDistressSeverity.SelectedValue == "N")
                throw new Exception(Feedback.NoDistressSeveritySelected());


            // saving the distress
            string user = Session["UserName"].ToString();
            string sectionNo = ((Label)frvSectionInfo.FindControl("SECTION_NOLabel")).Text;
            double? sampleArea = double.Parse(gvLaneSamples.Rows[gvLaneSamples.SelectedIndex].Cells[4].Text);

            int userID = int.Parse(Session["UserID"].ToString());
            int surveyNum = int.Parse(lblSurveyNo.Text);
            int sampleID=int.Parse(gvLaneSamples.SelectedValue.ToString());

            // imageFileName,
            bool saved = new DistressEntry().InsertSectionDistress(sampleID, lblSurveyDate.Text, surveyNum, ddlDistresses.SelectedItem.Text,
                ddlDistressSeverity.SelectedValue[0], rntxtArea.Value, sampleArea, sectionNo, txtDistressNotes.Text, user,
                int.Parse(ddlMainStreetSection.SelectedValue), userID, int.Parse(ddlMainStreets.SelectedValue));

            if (saved)
            {
                btnCancelDistress_Click(sender, e);
                lblDistressFeedback.Text = Feedback.InsertSuccessfull();
                gvDistresses.DataBind();
            }
            else
                lblDistressFeedback.Text = Feedback.InsertException();

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

    protected void updDistressImage_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        Session["PhotoChanged"] = true;
    }

    protected void lbtnAddDistress_Click(object sender, EventArgs e)
    {
        pnlDistressDetails.Visible = !pnlDistressDetails.Visible;
        btnCancelDistress_Click(sender, e);
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


    protected void odsSectionsurveyDistresses_Updated(object sender, ObjectDataSourceStatusEventArgs e)
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

    protected void odsSectionsurveyDistresses_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
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
                    gvLaneSamples_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblDistressFeedback.Text = ex.Message;
            }
        }
    }

    protected void odsLaneSamples_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void gvDistresses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hl = (HyperLink)e.Row.FindControl("idAddDistImage");
            hl.NavigateUrl = "javascript:" + hl.NavigateUrl;
        }
    }

    protected void lbtnSearchMainSt_Click(object sender, EventArgs e)
    {
        SearchMainSt1.Visible = true;
    }

    protected void lbtnSearchSection_Click(object sender, EventArgs e)
    {
        if (ddlMainStreets.SelectedValue != "0")
        {
            Session["MainStreetID"] = ddlMainStreets.SelectedValue;
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
                ddlMainStreets.SelectedValue = selectedID.ToString();
                ddlMainStreets_SelectedIndexChanged(new Object(), new EventArgs());
                SearchMainSt1.Visible = false;
            }
            else
            {
                SearchMainSt1.Visible = false;
                ddlMainStreets.SelectedValue = "0";
                ddlMainStreets_SelectedIndexChanged(new Object(), new EventArgs());
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
                ddlMainStreetSection.SelectedValue = selectedID.ToString();
                ddlMainStreetSection_SelectedIndexChanged(new Object(), new EventArgs());
                SearchSection1.Visible = false;
            }
            else
            {
                SearchSection1.Visible = false;
                ddlMainStreetSection.SelectedValue = "0";
                ddlMainStreetSection_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void gvLaneSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

    protected void gvLaneSamples_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLaneSamples.SelectedIndex = -1;
        gvLaneSamples_SelectedIndexChanged(sender, new EventArgs());
    }

}