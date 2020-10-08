using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Reports_PavementEvalSectionsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radBySamples_CheckedChanged(sender, e);

            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);
        }
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if ((radBySamples.Checked || radByLanes.Checked || radSectionsOfMainStreet.Checked) && (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue)))
                throw new Exception(Feedback.NoMainStreetSelected());

            if ((radLanesByMunic.Checked || radSectionsByMunic.Checked) && (ddlMunic.SelectedValue == "0" || string.IsNullOrEmpty(ddlMunic.SelectedValue)))
                throw new Exception(Feedback.NoMuniciplaitySelected());          


            if (radBySamples.Checked)
            {
                if (chkWithDistresses.Checked)
                {
                    if (ddlMainStreetSection.SelectedValue == "0")
                    {
                        DataTable dt = new SectionsUDI().GetSamplesUdiWithDistresses(int.Parse(ddlMainStreets.SelectedValue), false, radAllDists.Checked);
                        if (dt.Rows.Count > 0)
                        {
                            Session.Add("option", "radbySamples4MainStWithDist");
                            Session.Add("ReportData", dt);
                            string url = "ViewPavementEvalSectionsReport.aspx";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                        }
                        else
                            lblFeedback.Text = Feedback.NoData();
                    }
                    else
                    {
                        DataTable dt = new SectionsUDI().GetSamplesUdiWithDistresses(int.Parse(ddlMainStreetSection.SelectedValue), true, radAllDists.Checked);
                        if (dt.Rows.Count > 0)
                        {
                            Session.Add("option", "radbySamples4SectionsWithDist");
                            Session.Add("ReportData", dt);
                            string url = "ViewPavementEvalSectionsReport.aspx";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                        }
                        else
                            lblFeedback.Text = Feedback.NoData();
                    }
                }
                else
                {
                    if (ddlMainStreetSection.SelectedValue == "0")
                    {
                        DataTable dt = new SectionsUDI().GetSamplesUdiByMainStreet(int.Parse(ddlMainStreets.SelectedValue), radAllDists.Checked);
                        if (dt.Rows.Count > 0)
                        {
                            Session.Add("option", "radbySamples4MainSt");
                            Session.Add("ReportData", dt);
                            string url = "ViewPavementEvalSectionsReport.aspx";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                        }
                        else
                            lblFeedback.Text = Feedback.NoData();
                    }
                    else
                    {
                        //if (radlOldSurveys.SelectedIndex == -1)
                        //    throw new Exception(Feedback.NoSurveyNum(lang));

                        DataTable dt = new SectionsUDI().GetSamplesUdiBySection(int.Parse(ddlMainStreetSection.SelectedValue), radAllDists.Checked);
                        if (dt.Rows.Count > 0)
                        {
                            Session.Add("option", "radbySamples4Sections");
                            Session.Add("ReportData", dt);
                            string url = "ViewPavementEvalSectionsReport.aspx";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                        }
                        else
                            lblFeedback.Text = Feedback.NoData();
                    }
                }

            }
            else if (radByLanes.Checked)
            {
                //if (radlOldSurveys.SelectedIndex == -1)
                //    throw new Exception(Feedback.NoSurveyNum(lang));

                if (ddlMainStreetSection.SelectedValue == "0")
                {
                    DataTable dt = new SectionsUDI().GetLanesUdiByMainStreet(int.Parse(ddlMainStreets.SelectedValue), radAllDists.Checked);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radbyLane4MainSt");
                        Session.Add("title", "");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalSectionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else
                {
                    //if (radlOldSurveys.SelectedIndex == -1)
                    //    throw new Exception(Feedback.NoSurveyNum(lang));

                    DataTable dt = new SectionsUDI().GetLanesUdiBySection(int.Parse(ddlMainStreetSection.SelectedValue), radAllDists.Checked);
                    if (dt.Rows.Count > 0)
                    {
                        Session.Add("option", "radbyLane4Sections");
                        Session.Add("ReportData", dt);
                        string url = "ViewPavementEvalSectionsReport.aspx";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
            }
            else if (radSectionsOfMainStreet.Checked)
            {
                DataTable dt = new SectionsUDI().GetSectionsUdiByMainStreet(int.Parse(ddlMainStreets.SelectedValue), radAllDists.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbySections4MainSt");
                    Session.Add("ReportData", dt);
                    string url = "ViewPavementEvalSectionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radRegionSurroundSections.Checked)
            {
                if (ddlRegions.SelectedValue == "0" || string.IsNullOrEmpty(ddlRegions.SelectedValue))
                    throw new Exception(Feedback.NoRegionSelected());
                //if (radlRegionSectionsSurveys.SelectedIndex == -1)
                //    throw new Exception(Feedback.NoSurveyNum());


                //survey = int.Parse(radlRegionSectionsSurveys.SelectedValue);
                DataTable dt = new SectionsUDI().GetLanesUdiSurroundingRegion(int.Parse(ddlRegions.SelectedValue), radAllDists.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", "radbyLane4MainSt");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("المحيطة بالمنطقة {0}", ddlRegions.SelectedItem.Text)); ;
                    string url = "ViewPavementEvalSectionsReport.aspx";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else if (radLanesByMunic.Checked || radSectionsByMunic.Checked)
            {
                DataTable dt = new SectionsUDI().GetLaneSectionsUdiByMunic(radLanesByMunic.Checked, radSectionsByMunic.Checked, ddlMunic.SelectedValue, radAllDists.Checked);
                if (dt.Rows.Count > 0)
                {
                    Session.Add("option", radSectionsByMunic.Checked ? "radbySections4MainSt" : "radbyLane4MainSt");
                    Session.Add("ReportData", dt);
                    Session.Add("title", string.Format("ضمن بلدية {0}", ddlMunic.SelectedItem.Text)); ;
                    string url = "ViewPavementEvalSectionsReport.aspx";
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
        Response.Redirect("PavementEvalSectionsReport.aspx", false);      
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreetSection.Items.Clear();
            ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlMainStreetSection.DataBind();
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetSection_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            //radlOldSurveys.DataBind();
            //radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 0) ? -1 : 0;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radSectionsOfMainStreet_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = true;
            ddlMainStreetSection.Enabled = false;
            chkWithDistresses.Enabled = false;
            chkWithDistresses.Checked = false;

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);

            //radlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection_SelectedIndexChanged(sender, e);

            ddlRegions.SelectedValue = "0";
            ddlRegions_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radBySamples_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = true;
            ddlMainStreetSection.Enabled = true;
            ddlRegions.Enabled = false;
            chkWithDistresses.Enabled = true;
            chkWithDistresses.Checked = false;

            //radlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection_SelectedIndexChanged(sender, e);

            ddlRegions.SelectedValue = "0";
            ddlRegions_SelectedIndexChanged(sender, e);

            ddlMunic.SelectedValue = "0";
            ddlMunic.Enabled = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = true;
            ddlMainStreetSection.Enabled = true;
            ddlRegions.Enabled = false;
            chkWithDistresses.Enabled = false;
            chkWithDistresses.Checked = false;

            //radlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection_SelectedIndexChanged(sender, e);

            ddlRegions.SelectedValue = "0";
            ddlRegions_SelectedIndexChanged(sender, e);

            ddlMunic.SelectedValue = "0";
            ddlMunic.Enabled = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radlOldSurveys_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void radRegionSurroundSections_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = false;
            ddlMainStreetSection.Enabled = false;
            ddlRegions.Enabled = true;
            chkWithDistresses.Enabled = false;
            chkWithDistresses.Checked = false;

            //radlOldSurveys.Visible = false;
            //radlRegionSectionsSurveys.Visible = true;

            ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);
            ddlMainStreetSection.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
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

    protected void radlRegionSectionsSurveys_DataBound(object sender, EventArgs e)
    {
        //radlRegionSectionsSurveys.SelectedIndex = (radlRegionSectionsSurveys.Items.Count == 0) ? -1 : 0;
    }

    protected void radLanesByMunic_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            ddlMainStreets.Enabled = false;
            ddlMainStreetSection.Enabled = false;
            ddlRegions.Enabled = false;
            chkWithDistresses.Enabled = false;
            chkWithDistresses.Checked = false;

            //radlOldSurveys.Visible = true;
            //radlRegionSectionsSurveys.Visible = false;

            ddlMainStreetSection.SelectedValue = "0";
            ddlMainStreetSection_SelectedIndexChanged(sender, e);

            ddlRegions.SelectedValue = "0";
            ddlRegions_SelectedIndexChanged(sender, e);

            ddlMunic.SelectedValue = "0";
            ddlMunic.Enabled = true;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radSectionsByMunic_CheckedChanged(object sender, EventArgs e)
    {
        radLanesByMunic_CheckedChanged(sender, e);
    }

}