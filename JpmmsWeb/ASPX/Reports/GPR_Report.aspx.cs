using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_GPR_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radByMainLanes.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new GprReport().GetGprReportForMainStreet(ddlMainStreets.SelectedItem.Text, false, RadioButtonList1.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewGprReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByIntersections.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new GprReport().GetGprReportForMainStreet(ddlMainStreets.SelectedItem.Text, true, RadioButtonList1.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewGprReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByAllLanes.Checked)
            {
                DataTable dt = new GprReport().GetGprReportForMainStreet(false, RadioButtonList1.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewGprReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByAllIntersections.Checked)
            {
                DataTable dt = new GprReport().GetGprReportForMainStreet(true, RadioButtonList1.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersections");
                    Session.Add("ReportData", dt);
                    string url = "ViewGprReport.aspx";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        ddlMainStreets.SelectedValue = "0";

        radByMainLanes.Checked = true;
        radByMainLanes_CheckedChanged(sender, e);
        radByIntersections.Checked = false;
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.Enabled = true;

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreets.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByIntersections_CheckedChanged(object sender, EventArgs e)
    {
        radByMainLanes_CheckedChanged(sender, e);
    }

    protected void radByAllLanes_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
    }

    protected void radByAllIntersections_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
    }

    protected void ddlMainStreets_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        DataTable dtx = new JpmmsClasses.BL.MainStreet().GetStreetsGPR();
        RadioButtonList1.Items.Clear();
        RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dtx.Rows[ddlMainStreets.SelectedIndex - 1][3].ToString()));
        RadioButtonList1.SelectedValue = dtx.Rows[ddlMainStreets.SelectedIndex - 1][2].ToString();
        RadioButtonList1.DataBind();
    }
}