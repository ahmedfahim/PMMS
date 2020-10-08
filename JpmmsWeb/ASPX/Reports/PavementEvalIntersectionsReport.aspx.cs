using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Reports_PavementEvalIntersectionsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radByIntersect_CheckedChanged(sender, e);

            //ddlMainStreets.SelectedValue = "0";
            //ddlMainStreets_SelectedIndexChanged(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radByIntersect.Checked)
            {
                if (ddlMainStreetIntersection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetIntersection.SelectedValue))
                    throw new Exception(Feedback.NoIntersectionSelected());
                //else if (radlOldSurveys.SelectedIndex == -1)
                //    throw new Exception(Feedback.NoSurveyNum());


                if (chkWithDistresses.Checked)
                {
                    if (ddlMainStreetIntersection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetIntersection.SelectedValue))
                        throw new Exception(Feedback.NoIntersectionSelected());
                    //else if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyNum());  int.Parse(radlOldSurveys.SelectedValue), 


                    DataTable dt = new IntersectionUDI().GetIntersectionsUDI(int.Parse(ddlMainStreetIntersection.SelectedValue), true, radAllDists.Checked, radDetails.Checked);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radByIntersectWithDistress");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalIntersectionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else
                {
                    // int.Parse(radlOldSurveys.SelectedValue), 
                    DataTable dt = new IntersectionUDI().GetIntersectionsUDI(int.Parse(ddlMainStreetIntersection.SelectedValue), false, radAllDists.Checked, radDetails.Checked);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", radDetails.Checked ? "radByIntersect" : "radbyStreet");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalIntersectionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }

            }
            else if (radbyStreet.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());


                DataTable dt = new IntersectionUDI().GetIntersectionUDI(int.Parse(ddlMainStreets.SelectedValue), radAllDists.Checked, radDetails.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", radDetails.Checked ? "radByIntersect" : "radbyStreet");
                    Session.Add("ReportData", dt);
                    string url = "ViewPavementEvalIntersectionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByMonth.Checked)
            {
                if (DrpDwnListMonth.SelectedValue == "-1")
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new IntersectionUDI().GetIntersectionUDIByMonth(DrpDwnListMonth.SelectedValue, radAllDists.Checked, radDetails.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", radDetails.Checked ? "radByIntersect" : "radbyStreet");
                    Session.Add("ReportData", dt);
                    string url = "ViewPavementEvalIntersectionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radByMunic.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new IntersectionUDI().GetIntersectionUDI(ddlMunic.SelectedValue, radAllDists.Checked, radDetails.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", radDetails.Checked ? "radByIntersect" : "radbyStreet");
                    Session.Add("ReportData", dt);
                    string url = "ViewPavementEvalIntersectionsReport.aspx";
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
        Response.Redirect("PavementEvalIntersectionsReport.aspx", false);
    }

    protected void radByIntersect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            DrpDwnListMonth.Enabled = false;
            ddlMainStreets.SelectedValue = "-1";

            ddlMainStreets.Enabled = true;
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);

            ddlMainStreetIntersection.Enabled = true;
            ddlMunic.Enabled = false;
            ddlMunic.SelectedValue = "0";

            chkWithDistresses.Enabled = true;
            chkWithDistresses.Checked = false;

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radbyStreet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            DrpDwnListMonth.Enabled = false;
            ddlMainStreets.SelectedValue = "-1";

            ddlMainStreetIntersection.SelectedValue = "0";
            ddlMainStreetIntersection.Enabled = false;

            chkWithDistresses.Enabled = false;
            chkWithDistresses.Checked = false;

            radTotal.Checked = true;

            ddlMunic.SelectedValue = "0";
            ddlMunic.Enabled = false;            

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

            ddlMainStreetIntersection.Items.Clear();
            ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreetIntersection.DataBind();

            ddlMainStreetIntersection.SelectedValue = "0";
            ddlMainStreetIntersection_SelectedIndexChanged(sender, e);
         
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
    }

    protected void radByMunic_CheckedChanged(object sender, EventArgs e)
    {        
        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
        ddlMainStreetIntersection.Enabled = false;
        ddlMainStreets.Enabled = false;

        ddlMunic.SelectedValue = "0";
        ddlMunic.Enabled = true;

        DrpDwnListMonth.Enabled = false;
        ddlMainStreets.SelectedValue = "-1";

        chkWithDistresses.Enabled = false;
        chkWithDistresses.Checked = false;
    }

    protected void radByMonth_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            DrpDwnListMonth.Enabled = true;
           
            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = false;

            ddlMainStreetIntersection.SelectedValue = "0";
            ddlMainStreetIntersection.Enabled = false;

            chkWithDistresses.Enabled = false;
            chkWithDistresses.Checked = false;

            radTotal.Checked = true;

            ddlMunic.SelectedValue = "0";
            ddlMunic.Enabled = false;

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
}