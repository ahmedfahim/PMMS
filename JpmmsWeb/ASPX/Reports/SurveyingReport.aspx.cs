using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_SurveyingReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            if (DrpDwnListMonth.SelectedValue == "-1")
                lblFeedback.Text = Feedback.NoSearchBeginDate();
            else
            {
                DataTable dt0,dt;
                lblFeedback.Text = "";
                if (DrpDwnListMonth.SelectedValue == "0")
                {
                    if (RadioButtonList1.SelectedValue.StartsWith("0") && RadioButtonList1.SelectedValue.Length == 2)
                        dt = new DistressSurvey().GetSurveyedAreasWithDateInterSetions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "00" ? null : int.Parse(RadioButtonList1.SelectedValue).ToString(), true, false, false);
                    else
                        dt = new DistressSurvey().GetSurveyedAreasWithDateRegions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "0" ? null : RadioButtonList1.SelectedValue, true, false);
                    //dt.Merge(dt0, true);
                }
                else
                {
                    if (RadioButtonList1.SelectedValue.StartsWith("0") && RadioButtonList1.SelectedValue.Length == 2)
                        dt = new DistressSurvey().GetSurveyedAreasWithDateInterSetions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "00" ? null : int.Parse(RadioButtonList1.SelectedValue).ToString(), false, false, false);
                    else
                        dt = new DistressSurvey().GetSurveyedAreasWithDateRegions(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue == "0" ? null : RadioButtonList1.SelectedValue, false, false);
                    //dt.Merge(dt0, true);
                }
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    Session.Add("option", RadioButtonList1.SelectedValue.StartsWith("0") && RadioButtonList1.SelectedValue.Length == 2 ? "intersectregion" : "region");
                    string url = "ViewFinishedSurveyingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

  
  
}