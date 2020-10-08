using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;

public partial class ASPX_Reports_SectionDistresses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radBySection_CheckedChanged(sender, e);

            raddtpFrom.SelectedDate = DateTime.Now.AddMonths(-1);
            raddtpTo.SelectedDate = DateTime.Now;
        }
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreetSection.Items.Clear();
            ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreetSection.DataBind();
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

            if (radBySection.Checked)
            {
                if (ddlMainStreetSection.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreetSection.SelectedValue))
                    throw new Exception(Feedback.NoSectionSelected());
                //else if (radlOldSurveys.SelectedIndex == -1)
                //    throw new Exception(Feedback.NoSurveyNum()); int.Parse(radlOldSurveys.SelectedValue)


                DataTable dt = new DistressEntry().GetSectionDistresses(int.Parse(ddlMainStreetSection.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radBySection");
                    Session.Add("ReportData", dt);
                    Session.Add("title", "");
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radbyMainStreet.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new DistressEntry().GetMainStreetDistresses(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyMainStreet");
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByStreetDistressArea.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new DistressEntry().GetMainStreetDistressArea(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByStreetDistressArea");
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByStreetDistressAreaTotal.Checked)
            {
                if (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                    throw new Exception(Feedback.NoMainStreetSelected());

                DataTable dt = new DistressEntry().GetMainStreetDistressAreaTotal(int.Parse(ddlMainStreets.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByStreetDistressAreaTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByStreetAreaTotal.Checked)
            {
                if (ddlDistresses.SelectedValue == "0")
                    throw new Exception(Feedback.NoDistressSelected());

                DataTable dt = new DistressEntry().GetMainStreetDistressesTotalBydistress(int.Parse(ddlDistresses.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radByStreetAreaTotal");
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else if (radByDate.Checked)
            {
                DataTable dt = new DistressEntry().GetMainStreetDistresses(int.Parse(ddlMainStreets.SelectedValue), raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyMainStreet");
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radSectionsSurroundingRegion.Checked)
            {
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoSectionSelected());
                //else if (radlRegionSectionsSurveys.SelectedIndex == -1)
                //    throw new Exception(Feedback.NoSurveyNum());


                //int survey = int.Parse(radlRegionSectionsSurveys.SelectedValue);
                DataTable dt = new DistressEntry().GetSectionSurroundingRegionDistresses(int.Parse(ddlRegions.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radBySection");
                    Session.Add("title", string.Format("المحيطة بالمنطقة {0}", ddlRegions.SelectedItem.Text));
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    throw new Exception(Feedback.NoData());
            }
            else if (radMunicSections.Checked)
            {
                if (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue))
                    throw new Exception(Feedback.NoMuniciplaitySelected());

                DataTable dt = new DistressEntry().GetMunicSectionsDistresses(ddlMunic.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radBySection");
                    Session.Add("title", string.Format("ضمن نطاق بلدية {0}", ddlMunic.SelectedItem.Text));
                    Session.Add("ReportData", dt);
                    string url = "ViewSectionDistressesReport.aspx";
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
        Response.Redirect("SectionDistresses.aspx", false);
    }

    protected void radBySection_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = true;
            ddlMainStreetSection.Enabled = true;

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";
            //ddlRegions_SelectedIndexChanged(sender, e);

            ddlDistresses.SelectedValue = "0";
            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = false;
            //radlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;

            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radbyMainStreet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = true;

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection.Enabled = false;

            ddlDistresses.SelectedValue = "0";
            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = false;
            //radlOldSurveys.Visible = false;
            //radlRegionSectionsSurveys.Visible = false;

            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";
            //ddlRegions_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }

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
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = false;
            ddlMainStreets_SelectedIndexChanged(sender, e);

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection.Enabled = false;

            ddlRegions.Enabled = false;
            ddlRegions.SelectedValue = "0";
            //ddlRegions_SelectedIndexChanged(sender, e);

            ddlDistresses.Enabled = true;
            ddlMunic.Enabled = false;
            //radlOldSurveys.Visible = false;
            //radlRegionSectionsSurveys.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void radlOldSurveys_DataBound(object sender, EventArgs e)
    {
        //radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 0) ? -1 : 0;
    }

    protected void radByDate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = true;
            ddlMainStreets_SelectedIndexChanged(sender, e);

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection.Enabled = false;

            ddlRegions.SelectedValue = "0";
            ddlRegions.Enabled = false;
            //ddlRegions_SelectedIndexChanged(sender, e);

            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = false;
            //radlOldSurveys.Visible = false;
            //radlRegionSectionsSurveys.Visible = false;

            raddtpFrom.Enabled = true;
            raddtpTo.Enabled = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radSectionsSurroundingRegion_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlRegions.SelectedValue = "0";
            ddlRegions.Enabled = true;
            ddlRegions_SelectedIndexChanged(sender, e);

            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = false;
            ddlMainStreets_SelectedIndexChanged(sender, e);

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection.Enabled = false;

            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = false;
            //radlOldSurveys.Visible = false;
            //radlRegionSectionsSurveys.Visible = true;

            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;
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
            lblFeedback.Text = "";

            //radlRegionSectionsSurveys.DataBind();
            //radlRegionSectionsSurveys.SelectedIndex = (radlRegionSectionsSurveys.Items.Count == 0) ? -1 : 0;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlDistresses_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void radMunicSections_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlRegions.SelectedValue = "0";
            ddlRegions.Enabled = false;
            //ddlRegions_SelectedIndexChanged(sender, e);

            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets.Enabled = false;
            ddlMainStreets_SelectedIndexChanged(sender, e);

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection.Enabled = false;

            ddlDistresses.Enabled = false;
            ddlMunic.Enabled = true;

            raddtpFrom.Enabled = false;
            raddtpTo.Enabled = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}