using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Archive_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            ddlRegions.SelectedValue = "0";
    }
    protected void odsSurveySubmitJobs_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.DeleteSuccessfull();
    }
    protected void odsSurveySubmitJobs_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
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
        rntxtSurveyNo.Text = "4";
        RadNumericRegionSum.Text = "";
        RadNumericStreets.Text = "";
        RadNumericStreetsAdd.Text="0";
        RadNumericStreetDelete.Text = "0";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());
            if (ddlRegions.SelectedValue == "0")
                throw new Exception("الرجاء إدخال  المنطقة");
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
            if (RadNumericStreets.Value == null)
                throw new Exception("الرجاء إدخال عدد الشوارع");
            if (RadNumericRegionSum.Value == null)
                throw new Exception("الرجاء إدخال مساحه المنطقة");
            if (RadNumericStreetsAdd.Value == null)
                throw new Exception("الرجاء إدخال عدد الشوارع المضافة");
            if (RadNumericStreetDelete.Value == null)
                throw new Exception("الرجاء إدخال عدد الشوارع المحذوفة");
            else if (rntxtSurveyNo.Value < 3)
                throw new Exception("قيمه المسح اقل من 3");

            int ReportYear = int.Parse(DrpDwnYear.SelectedValue);
            //switch (rntxtSurveyNo.Value.ToString())
            //{
            //    case "3":
            //        ReportYear = 1;
            //        break;
            //    case "4":
            //        ReportYear = 2;
            //        break;
            //    case "5":
            //        ReportYear = 3;
            //        break;
            //    default:
            //        ReportYear = 1;
            //        break;
            //}

            bool SavedOne = new SurveyorSubmitJob().Insert(int.Parse(ddlSurveyor.SelectedValue), raddtpIssueDate.SelectedDate, raddtpDeliveryDate.SelectedDate,
                int.Parse(rntxtSurveyNo.Text), txtNotes.Text, ddlRegions.SelectedValue, JobType.RegionSecondaryStreets);
            
            if (SavedOne)
            {
                bool SavedTwo = new SystemUsers().InsertReportQc(Session["UserID"].ToString(), int.Parse(ddlRegions.SelectedValue), RadNumericStreets.Text,
                    RadNumericRegionSum.Text, rntxtSurveyNo.Text, int.Parse(ddlReportMonth.SelectedValue),
                    ReportYear, ddlSurveyor.SelectedItem.Text, ddlDataEntry.SelectedItem.Text, RadNumericStreetsAdd.Text, RadNumericStreetDelete.Text);
                bool SavedThree = new SystemUsers().InsertReceivedFiles(ddlRegions.SelectedValue, ddlDataEntry.SelectedValue);
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
    
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadNumericRegionSum.Text = Region.GetRegionSampleAreaSum(int.Parse(ddlRegions.SelectedValue)).ToString("N2");
            RadNumericStreets.Text = Region.GetRegionSampleAreaSumStreets(int.Parse(ddlRegions.SelectedValue)).ToString("N2");
          //lblFeedback.Text = string.Empty;
          //pnlSurveyor.Visible = (ddlRegions.SelectedValue != "0");
          //int SurveyNo = DistressSurvey.GetNextSecondaryRegionSurveyNumber(int.Parse(ddlRegions.SelectedValue.ToString()));
          //rntxtSurveyNo.Text = SurveyNo < 3 ? "3" : SurveyNo.ToString();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void ddlSurveyor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSurveyor.SelectedValue == "12" || ddlSurveyor.SelectedValue == "20")
            ddlDataEntry.SelectedValue = "44";
        else if (ddlSurveyor.SelectedValue == "17" || ddlSurveyor.SelectedValue == "19")
            ddlDataEntry.SelectedValue = "42";
        else if (ddlSurveyor.SelectedValue == "14" || ddlSurveyor.SelectedValue == "10")
            ddlDataEntry.SelectedValue = "49";
        else if (ddlSurveyor.SelectedValue == "18" || ddlSurveyor.SelectedValue == "13")
            ddlDataEntry.SelectedValue = "33";
        else if (ddlSurveyor.SelectedValue == "11" || ddlSurveyor.SelectedValue == "39")
            ddlDataEntry.SelectedValue = "34";
        else if (ddlSurveyor.SelectedValue == "35" || ddlSurveyor.SelectedValue == "16")
            ddlDataEntry.SelectedValue = "49";
    }
   
}