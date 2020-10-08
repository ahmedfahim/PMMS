using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;

public partial class ASPX_Reports_IntersectionDistresses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radBySection_CheckedChanged(sender, e);
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
            lblFeedback.Text = "";

            if (radByIntersection.Checked)
            {
                if (ddlMainStreetIntersection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetIntersection.SelectedValue))
                    throw new Exception(Feedback.NoIntersectionSelected());
                //else if (radlOldSurveys.SelectedIndex == -1)
                //    throw new Exception(Feedback.NoSurveyDateNum()); // int.Parse(radlOldSurveys.SelectedValue)

                DataTable dt = new DistressEntry().GetIntersectionDistressesReport(int.Parse(ddlMainStreetIntersection.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersection");
                    Session.Add("ReportData", dt);
                    string url = "ViewIntersectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radbyMainStreet.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new DistressEntry().GetMainStreetInersectionsDistressesReport(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyMainStreet");
                    Session.Add("ReportData", dt);
                    string url = "ViewIntersectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByMunic.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new DistressEntry().GetIntersectionDistressesReport(ddlMunic.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByIntersection");
                    Session.Add("ReportData", dt);
                    string url = "ViewIntersectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            //else if (radByStreetDistressArea.Checked)
            //{
            //    if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
            //        throw new Exception(Feedback.NoMainStreetSelected());


            //    DataTable dt = new DistressEntry().GetMainStreetIntersectionsDistressArea(int.Parse(ddlMainStreets.SelectedValue));
            //    if (dt.Rows.Count > 0)
            //    {
            //        Session.Add("option", "radByStreetDistressArea");
            //        Session.Add("ReportData", dt);
            //        string url = "ViewIntersectionDistressesReport.aspx";
            //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
            //    }
            //    else
            //        lblFeedback.Text = Feedback.NoData();
            //}
            else if (radByStreetDistressAreaTotal.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());


                DataTable dt = new DistressEntry().GetMainStreetIntersectionsDistressAreaTotal(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByStreetDistressAreaTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewIntersectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByStreetAreaTotal.Checked)
            {
                if (ddlDistresses.SelectedValue == "0")
                    throw new Exception(Feedback.NoDistressSelected());

                DataTable dt = new DistressEntry().GetMainStreetIntersectionDistressesTotalBydistress(int.Parse(ddlDistresses.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByStreetAreaTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewIntersectionDistressesReport.aspx";
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


    protected void radBySection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;
        ddlMainStreetIntersection.Enabled = true;

        ddlDistresses.SelectedValue = "0";
        ddlDistresses.Enabled = false;
        ddlMunic.Enabled = false;
        //radlOldSurveys.Enabled = true;
    }

    protected void radbyMainStreet_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = true;

        ddlMainStreetIntersection.SelectedValue = "0";
        ddlMainStreetIntersection.Enabled = false;

        ddlDistresses.SelectedValue = "0";
        ddlDistresses.Enabled = false;
        ddlMunic.Enabled = false;
    }

    protected void radByStreetDistressArea_CheckedChanged(object sender, EventArgs e)
    {
        radbyMainStreet_CheckedChanged(sender, e);
    }

    protected void radByStreetDistressAreaTotal_CheckedChanged(object sender, EventArgs e)
    {
        radbyMainStreet_CheckedChanged(sender, e);
    }

    protected void radByStreetAreaTotal_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets.Enabled = false;
        ddlMainStreets_SelectedIndexChanged(sender, e);

        ddlMainStreetIntersection.SelectedValue = "0";
        ddlMainStreetIntersection.Enabled = false;

        ddlDistresses.Enabled = true;
        ddlMunic.Enabled = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("IntersectionDistresses.aspx", false);
        //lblFeedback.Text = "";

        //radByIntersection.Checked = true;

        //radbyMainStreet.Checked = false;
        ////radByStreetDistressArea.Checked = false;
        //radByStreetDistressAreaTotal.Checked = false;
        //radByStreetAreaTotal.Checked = false;
        //radBySection_CheckedChanged(sender, e);

        //ddlMainStreets.SelectedValue = "0";
        //ddlMainStreets_SelectedIndexChanged(sender, e);
        //ddlMainStreetIntersection.SelectedValue = "0";
        //ddlDistresses.SelectedValue = "0";
    }

    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
    }

    protected void radByMunic_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlMainStreetIntersection.Enabled = false;

        ddlDistresses.SelectedValue = "0";
        ddlDistresses.Enabled = false;
        ddlMunic.Enabled = true;
    }

}