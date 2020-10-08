using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;
using System.Data;

public partial class ASPX_Reports_PavementStatusAllRoads : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radRegionSecondary.Checked = true;
            radRegionSecondary_CheckedChanged(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            int surveyNum = int.Parse(ddlOldSurveys.SelectedValue);

            if (radSection.Checked)
            {
                // int.Parse(radlOldSurveys.SelectedValue), 
                DataTable dt = new UdiShared().GetRoadsNetworkUDI(RoadType.Section, ddlMunic.SelectedValue, surveyNum);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyLane4MainSt");
                    Session.Add("ReportData", dt);
                    string url = "ViewWholeRoadsUDI.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    throw new Exception(Feedback.NoData());
            }
            else if (radIntersection.Checked)
            {
                DataTable dt = new UdiShared().GetRoadsNetworkUDI(RoadType.Intersect, ddlMunic.SelectedValue, surveyNum);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersect");
                    Session.Add("ReportData", dt);
                    string url = "ViewWholeRoadsUDI.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    throw new Exception(Feedback.NoData());
            }
            else if (radRegionSecondary.Checked)
            {
                DataTable dt = new UdiShared().GetRoadsNetworkUDI(RoadType.RegionSecondarySt, ddlMunic.SelectedValue, surveyNum);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByRegion");
                    Session.Add("ReportData", dt);
                    string url = "ViewWholeRoadsUDI.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    throw new Exception(Feedback.NoData());
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnNewSurveyCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PavementStatusAllRoads.aspx", false);
    }

    protected void radlOldSurveys_DataBound(object sender, EventArgs e)
    {
        //if (radlOldSurveys.Items.Count > 0)
        //    radlOldSurveys.SelectedIndex = 0;
    }


    private void BindSurveysList()
    {
        try
        {
            ddlOldSurveys.Items.Clear();
            ddlOldSurveys.Items.Add(new ListItem("اختيار", "0"));
            ddlOldSurveys.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radRegionSecondary_CheckedChanged(object sender, EventArgs e)
    {
        ddlMunic.Enabled = true;
        BindSurveysList();
    }

    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMunic.Enabled = false;
        BindSurveysList();
    }

    protected void radIntersection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMunic.Enabled = false;
        BindSurveysList();
    }

}