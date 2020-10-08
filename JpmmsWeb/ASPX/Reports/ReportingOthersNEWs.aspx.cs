using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Reports_ReportingOthersNEWs : System.Web.UI.Page
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
            if (DrpDwnListMonth.SelectedValue == "-1" && RadioButtonList1.SelectedValue != "-1")
                lblFeedback.Text = Feedback.NoSearchBeginDate();
            else
            {
                DataTable dt;
                lblFeedback.Text = "";
                if (RadioButtonList1.SelectedValue == "-1")
                    dt = new DistressSurvey().GetSurveyedAreasWithDateALL(null, null, true);
                else
                {
                    if (DrpDwnListMonth.SelectedValue == "0")
                        dt = new DistressSurvey().GetSurveyedAreasWithDateALL(null, (RadioButtonList1.SelectedValue == "0" ? string.Empty : RadioButtonList1.SelectedValue), false);
                    else
                        dt = new DistressSurvey().GetSurveyedAreasWithDateALL(DrpDwnListMonth.SelectedValue, (RadioButtonList1.SelectedValue == "0" ? string.Empty : RadioButtonList1.SelectedValue), false);
                }
                if (dt.Rows.Count > 0)
                {
                    Session.Add("ReportData", dt);
                    if (CheckBoxOne.Checked)
                        Session.Add("option", "regionOne");
                    else
                        Session.Add("option", "region");

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