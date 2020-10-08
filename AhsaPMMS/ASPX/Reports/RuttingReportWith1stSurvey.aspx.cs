using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_RuttingReportWith1stSurvey : System.Web.UI.Page
{
    private OracleDatabaseClass db = new OracleDatabaseClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
        {
            radByMainLanes.Checked = true;
            radByMainLanes_CheckedChanged(sender, e);
        }
    }

    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            string select = Session["lang"].ToString().Contains("ar") ? "اختيار" : "select";

            ddlMainStreets.Enabled = true;

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new ListItem(select, "0"));
            ddlMainStreets.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (radByAllinters122.Checked)
            {

                string sql = string.Format("SELECT * FROM RUTTING_INTERSECTIONS where SURVEY_NO={0}  ORDER BY INTERSECTION_ORDER, INTER_NO, LANE ", int.Parse(radlOldSurveys.SelectedValue));
                DataTable dt1 = new DataTable();
                dt1 = db.ExecuteQuery(sql);
                Session.Add("option", "radByIntersects");
                Session.Add("ReportData", dt1);
                string url = "ViewRuttingReport.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

            }
            else
            {
                lblFeedback.Text = "";
                //string lang = Session["lang"].ToString();

                if (!radByAllLanes.Checked && ddlMainStreets.SelectedValue == "0")
                    throw new Exception(Feedback.NoMainStreetSelected());
                else
                    if (radlOldSurveys.SelectedIndex == -1)
                        throw new Exception(Feedback.NoSurveyDateNum());


                DataTable dt = new RuttingReport().GetRuttingReportForMainStreet(ddlMainStreets.SelectedValue, int.Parse(radlOldSurveys.SelectedValue), radByAllLanes.Checked, radByIntersects.Checked);
                if (radByMainLanes.Checked)
                {
                    Session.Add("option", "radByMainLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewRuttingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else if (radByAllLanes.Checked)
                {
                    Session.Add("option", "radByAllLanes");
                    Session.Add("ReportData", dt);
                    string url = "ViewRuttingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else if (radByIntersects.Checked)
                {
                    Session.Add("option", "radByIntersects");
                    Session.Add("ReportData", dt);
                    string url = "ViewRuttingReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
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
        radByMainLanes.Checked = true;
        //radByIntersections.Checked = false;

        radByMainLanes_CheckedChanged(sender, e);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            radlOldSurveys.DataBind();
            radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 0) ? -1 : 0;
            //if (radlOldSurveys.Items.Count == 1)
            //radlOldSurveys.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByAllLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = false;
            
            radlOldSurveys.DataBind();
            radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 0) ? -1 : 0;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByIntersects_CheckedChanged(object sender, EventArgs e)
    {
        radByMainLanes_CheckedChanged(sender, e);
    }

    protected void radByAllintersect_CheckedChanged(object sender, EventArgs e)
    {
        radByAllLanes_CheckedChanged(sender, e);
    }
    
}
