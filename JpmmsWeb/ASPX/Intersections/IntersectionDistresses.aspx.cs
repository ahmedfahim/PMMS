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

public partial class ASPX_Intersections_IntersectionDistresses : System.Web.UI.Page
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

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            string select = (Culture == "en-GB") ? "Select" : "اختيار";

            ddlMainStreetIntersection.Items.Clear();
            ddlMainStreetIntersection.Items.Add(new ListItem(select, "0"));
            ddlMainStreetIntersection.DataBind();
            ddlMainStreetIntersection.SelectedValue = "0";
            ddlMainStreetIntersection_SelectedIndexChanged(sender, e);

            gvIntersectionSamples.DataBind();
            gvIntersectionSamples.SelectedIndex = -1;
            gvIntersectionSamples_SelectedIndexChanged(select, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            frvIntersectInfo.DataBind();
            gvIntersectionSamples.DataBind();
            gvIntersectionSamples.SelectedIndex = -1;

            pnlSurvey.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        string select = (Culture == "en-GB") ? "Select" : "اختيار";

        ddlMainStreets.Items.Clear();
        ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem(select,"0"));
        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
        pnlSurvey.Visible = false;
    }

    protected void radOldSurvey_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (radOldSurvey.Checked)
            {
                pnlNewSurvey.Visible = false;
                radlOldSurveys.Visible = true;
                radlOldSurveys.DataBind();

                lblSurveysCount.Text = radlOldSurveys.Items.Count.ToString();
                lbtnAddDistress.Visible = (radlOldSurveys.Items.Count > 0);
                if (radlOldSurveys.Items.Count == 1)
                {
                    radlOldSurveys.SelectedValue = DistressSurvey.GetLastIntersectionSurveyNumber(int.Parse(gvIntersectionSamples.SelectedValue.ToString())).ToString();
                    radlOldSurveys_SelectedIndexChanged(sender, e);
                    //gvDistresses.DataBind();
                }
                else
                    radlOldSurveys.SelectedIndex = 0; //-1;
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
                int SurveyNo = DistressSurvey.GetNextIntersectionSurveyNumber(int.Parse(gvIntersectionSamples.SelectedValue.ToString()));
                rntxtSurveyNo.Text = SurveyNo < 3 ? "3" : SurveyNo.ToString();

                string date = DistressSurvey.GetIntersectCurrentSurveyDate(int.Parse(ddlMainStreetIntersection.SelectedValue), int.Parse(rntxtSurveyNo.Text));
                rdtpSurveyDate.SelectedDate = (date == "0") ? DateTime.Today : DateTime.Parse(date);
            }

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


            //string lang = ;
            if (rntxtSurveyNo.Value == null)
                throw new Exception(Feedback.NoSurveyNum());
            else if (rdtpSurveyDate.SelectedDate == null)
                throw new Exception(Feedback.NoSurveyDate());


            int newSurveyNo = (int)rntxtSurveyNo.Value;
            string user = Session["UserName"].ToString();
            int userID = int.Parse(Session["UserID"].ToString());

            bool saved = new DistressEntry().InsertNewIntersectionSampleSurvey(int.Parse(gvIntersectionSamples.SelectedValue.ToString()), int.Parse(ddlMainStreetIntersection.SelectedValue),
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

    protected void radlOldSurveys_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvIntersectDistresses.DataBind();
            DataRow dr = DistressSurvey.GetIntersectSampleSurveyNumDate(int.Parse(gvIntersectionSamples.SelectedValue.ToString()), int.Parse(radlOldSurveys.SelectedValue)).Rows[0];

            lblSurveyNo.Text = dr["SURVEY_NO"].ToString();
            lblSurveyDate.Text = DateTime.Parse(dr["SURVEY_DATE"].ToString()).ToString("dd/MM/yyyy");

            lbtnAddDistress.Visible = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


    protected void gvIntersectionSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //string lang = ;
            if (gvIntersectionSamples.SelectedValue != null)
            {
                lblFeedback.Text = "";
                lblDistressFeedback.Text = "";

                pnlSurvey.Visible = true;
                pnlDistressDetails.Visible = false;

                bool sampleHasSurveys = new DistressSurvey().IntersectionSampleHasSurveys(int.Parse(gvIntersectionSamples.SelectedValue.ToString()));
                bool sampleAreaReady = IntersectionSamples.IntersectionSampleReadyForDistressEntry(int.Parse(gvIntersectionSamples.SelectedValue.ToString()));

                if (sampleAreaReady)
                {
                    if (sampleHasSurveys)
                    {
                        lbtnAddDistress.Visible = false;
                        radNewSurvey.Checked = false;
                        radOldSurvey.Checked = true;
                        radOldSurvey_CheckedChanged(sender, e);
                    }
                    else
                    {
                        lbtnAddDistress.Visible = false;
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


            //string lang = ;

            //string imageFileName = "";
            if (radlOldSurveys.SelectedValue == "")
                throw new Exception(Feedback.NoSurveyDateNum());
            else if (gvIntersectionSamples.SelectedValue == null)
                throw new Exception(Feedback.NoIntersectSampleSelected());
            else if (ddlDistresses.SelectedValue == "-1")
                throw new Exception(Feedback.NoDistressSelected());
            else if (rntxtArea.Value == null)
                throw new Exception("الرجاء إدخال مساحة العيب");
            else if (int.Parse(ddlDistresses.SelectedValue) > 0 && ddlDistressSeverity.SelectedValue == "N")
                throw new Exception(Feedback.NoDistressSeveritySelected());


            // saving the distress
            string user = Session["UserName"].ToString();
            string intersectNo = ((Label)frvIntersectInfo.FindControl("INTER_NOLabel")).Text;
            double? sampleArea = IntersectionSamples.GetIntersectionSampleArea(int.Parse(gvIntersectionSamples.SelectedValue.ToString()));

            int userID = int.Parse(Session["UserID"].ToString());
            int surveyNum = int.Parse(lblSurveyNo.Text);
            int sampleID = int.Parse(gvIntersectionSamples.SelectedValue.ToString());
            //decimal.Parse(gvIntersectionSamples.Rows[gvIntersectionSamples.SelectedIndex].Cells[2].Text);

            bool saved = new DistressEntry().InsertIntersectionDistress(sampleID, lblSurveyDate.Text, surveyNum, ddlDistresses.SelectedItem.Text,
                ddlDistressSeverity.SelectedValue[0], rntxtArea.Value, sampleArea, intersectNo, txtDistressNotes.Text, user,
                int.Parse(ddlMainStreetIntersection.SelectedValue), userID, int.Parse(ddlMainStreets.SelectedValue));

            if (saved)
            {
                btnCancelDistress_Click(sender, e);
                lblDistressFeedback.Text = Feedback.InsertSuccessfull();
                gvIntersectDistresses.DataBind();
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
            else if (ddlDistresses.SelectedValue == "4")
            {
                ddlDistressSeverity.SelectedValue = "L";
                rntxtArea.Enabled = true;
                ddlDistressSeverity.Enabled = true;
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

    protected void odsIntersectionSamples_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void odsIntersectionSurveyDistresses_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblDistressFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblDistressFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void odsIntersectionSurveyDistresses_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
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
                gvIntersectDistresses.DataBind();
                if (gvIntersectDistresses.Rows.Count == 0)
                    gvIntersectionSamples_SelectedIndexChanged(sender, e);

                lblDistressFeedback.Text = Feedback.DeleteSuccessfull();
            }
            catch (Exception ex)
            {
                lblDistressFeedback.Text = ex.Message;
            }
        }
    }

    protected void lbtnSearchMainSt_Click(object sender, EventArgs e)
    {
        SearchMainSt1.Visible = true;
    }

    protected void lbtnSearchIntersect_Click(object sender, EventArgs e)
    {
        //if (ddlMainStreets.SelectedValue != "0")
        //{
            Session["MainStreetID"] = ddlMainStreets.SelectedValue;
            SearchIntersect1.Visible = true;
        //}
        //else
        //    SearchIntersect1.Visible = false;
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

    protected void onIntersectSearchChanged()
    {
        try
        {
            
            //if (selectedID != 0)
            //{
            //    ddlMainStreetIntersection.SelectedValue = selectedID.ToString();
            //    ddlMainStreetIntersection_SelectedIndexChanged(new Object(), new EventArgs());
            //    SearchIntersect1.Visible = false;
            //}
            //else
            //{
            //    SearchIntersect1.Visible = false;
            //    ddlMainStreetIntersection.SelectedValue = "0";
            //    ddlMainStreetIntersection_SelectedIndexChanged(new Object(), new EventArgs());
            //}
            int selectedID = SearchIntersect1.SelectedIntersectionID;
            if (selectedID != 0)
            {
                ddlMainStreets.Items.Clear();
                ddlMainStreets.DataSource = new MainStreet().GetMainStreets(SearchIntersect1.SelectedMain_NO);
                ddlMainStreets.DataBind();

                ddlMainStreets.Items[0].Selected = true;

                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.DataSource = new Intersection().GetMainStreetByIntersectionID(int.Parse(selectedID.ToString()));
                ddlMainStreetIntersection.DataBind();

                ddlMainStreetIntersection.Items[0].Selected = true;
                ddlMainStreetIntersection_SelectedIndexChanged(null, null);
                frvIntersectInfo.Visible = false;
                SearchIntersect1.Visible = false;
            }
            else
            {
                SearchIntersect1.Visible = false;
                ddlMainStreetIntersection.SelectedValue = "0";

            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void gvIntersectionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvIntersectDistresses_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvIntersectDistresses_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

}