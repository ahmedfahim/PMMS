using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Lookups;
using Telerik.Web.UI;
using System.Data;

public partial class ASPX_Archive_DefaultIntersect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

    }
    protected void odsSurveySubmitJobs_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedbackSave.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedbackSave.Text = Feedback.DeleteSuccessfull();
        }
    }

    protected void odsSurveySubmitJobs_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedbackSave.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedbackSave.Text = Feedback.UpdateSuccessfull();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlSurveyor.SelectedValue = "0";
        ddlDataEntry.SelectedValue = "0";
        ddlReportMonth.SelectedValue = "0";
        raddtpIssueDate.SelectedDate = null;
        raddtpDeliveryDate.SelectedDate = null;
        txtNotes.Text = "";
        lblFeedback.Text = "";
        rntxtSurveyNo.Text = "3";
        RadNumericRegionSum.Text = "";
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());
            if (ddlMainStreets.SelectedValue == "0")
                throw new Exception("الرجاء إدخال  الطريق");
            if (ddlSurveyor.SelectedValue == "0")
                throw new Exception("الرجاء إدخال إسم المساح");
            if (raddtpIssueDate.SelectedDate == null)
                throw new Exception("الرجاء إدخال تاريخ الاستلام");
            else if (raddtpDeliveryDate.SelectedDate != null && (raddtpIssueDate.SelectedDate > raddtpDeliveryDate.SelectedDate))
                throw new Exception("تاريخ التسليم لايمكن أن يكون سابقا لتاريخ الاستلام");
            else if (rntxtSurveyNo.Value == null)
                throw new Exception(Feedback.NoSurveyNum());
            if (ddlDataEntry.SelectedValue == "0")
                throw new Exception("الرجاء اختيار المدخل");
            if (ddlReportMonth.SelectedValue == "0")
                throw new Exception("الرجاء إدخال شهر التقرير");
            if (RadNumericRegionSum.Value == null)
                throw new Exception("الرجاء إدخال مساحه التقاطع");
            else if (rntxtSurveyNo.Value < 3)
                throw new Exception("قيمه المسح اقل من 3");

            int ReportYear = int.Parse(DrpDwnYear.SelectedValue);

            bool SavedOne = new SurveyorSubmitJob().Insert(int.Parse(ddlSurveyor.SelectedValue), raddtpIssueDate.SelectedDate, raddtpDeliveryDate.SelectedDate,
                         int.Parse(rntxtSurveyNo.Text), txtNotes.Text, ddlMainStreetIntersection.SelectedValue, JobType.Intersection);
            if (SavedOne)
            {
                bool SavedTwo = new SystemUsers().InsertIntersectQc(Session["UserID"].ToString(), int.Parse(ddlMainStreetIntersection.SelectedValue),ddlMainStreets.SelectedValue,
                    RadNumericRegionSum.Text, rntxtSurveyNo.Text, int.Parse(ddlReportMonth.SelectedValue),
                    ReportYear, ddlSurveyor.SelectedItem.Text, ddlDataEntry.SelectedItem.Text);

                bool SavedThree = new SystemUsers().InsertReceivedInterSectFiles(ddlMainStreetIntersection.SelectedValue, ddlDataEntry.SelectedValue);
                btnCancel_Click(sender, e);
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvSurveyorJob.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


   

    protected void ddlSurveyor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSurveyor.SelectedValue == "11" )
            ddlDataEntry.SelectedValue = "33";
        else if (ddlSurveyor.SelectedValue == "12" )
            ddlDataEntry.SelectedValue = "42";
       
    }
    protected void onIntersectSearchChanged()
    {
        try
        {
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

                frvIntersectInfo.Visible = false;
                SearchIntersect1.Visible = false;

                RadNumericRegionSum.Text = Intersection.GetIntersectionSampleAreaSum(int.Parse(selectedID.ToString())).ToString("N2");
               
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
    protected void lbtnSearchIntersect_Click(object sender, EventArgs e)
    {
        SearchIntersect1.Visible = true;
       
    }
}