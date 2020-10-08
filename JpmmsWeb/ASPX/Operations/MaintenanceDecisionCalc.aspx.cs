using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using JpmmsClasses;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Operations_MaintenanceDecisionCalc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("~/ASPX/Default.aspx", false);
        if (!IsPostBack)
        {

            if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')// ||  Session["UserID"].ToString()!= "32")
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (Request.QueryString["adv"] != null)
                ddlOldSurveys.Visible = (Request.QueryString["adv"].ToString() == "1");


            radByMainLanes_CheckedChanged(sender, e);
            ddlMainStreets_SelectedIndexChanged(sender, e);
        }
    }
    protected void btnMainStreets_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "55")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());
                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateMainStreets);
                Thread worker = new Thread(ts);
                worker.Start();

                string url = string.Format("ResultMd.aspx?id={0}&All=0", RequestID.ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

                lblFeedback.Text = "تم الحساب بنجاح";
      

            }
            else
            {
                lblFeedback.Text = Feedback.NoPermissions();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.Enabled = true;
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = false;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("الكل", "0"));
            ddlMainStreets.SelectedValue = "0";
            //ddlMainStreets.Items[0].Selected = true;
            ddlMainStreets.DataBind();

            //ddlMainStreets.SelectedValue = "0";
            ddlMainStreets_SelectedIndexChanged(sender, e);
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

    protected void radByRegionNo_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = true;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = false;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlRegions.Items.Clear();
            ddlRegions.Items.Add(new Telerik.Web.UI.RadComboBoxItem("الكل", "0"));
            ddlRegions.SelectedValue = "0";
            ddlRegions.DataBind();

            ddlMainStreets_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = true;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = false;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlRegionNames.Items.Clear();
            ddlRegionNames.Items.Add(new Telerik.Web.UI.RadComboBoxItem("الكل", "0"));
            ddlRegionNames.SelectedValue = "0";
            ddlRegionNames.DataBind();

            ddlMainStreets_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByRegionsAreaName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = true;
            ddlMunic.Enabled = false;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new Telerik.Web.UI.RadComboBoxItem("الكل", "0"));
            ddlDistrict.SelectedValue = "0";
            ddlDistrict.DataBind();

            ddlMainStreets_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radByMunicName_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreets.Enabled = false;
            ddlRegions.Enabled = false;
            ddlRegionNames.Enabled = false;
            ddlDistrict.Enabled = false;
            ddlMunic.Enabled = true;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlMunic.Items.Clear();
            ddlMunic.Items.Add(new Telerik.Web.UI.RadComboBoxItem("الكل", "0"));
            ddlMunic.SelectedValue = "0";
            ddlMunic.DataBind();

            ddlMainStreets_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected Guid RequestID;


    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            btnShowReport.Enabled = false;

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if ((radByIntersections.Checked || radByMainLanes.Checked) && (string.IsNullOrEmpty(ddlMainStreets.SelectedValue)))
                throw new Exception(Feedback.NoMainStreetSelected());


            RequestID = Guid.NewGuid();
            int survey = int.Parse(ddlOldSurveys.SelectedValue);
            int mainStId = int.Parse(ddlMainStreets.SelectedValue);
            ThreadStart ts = new ThreadStart(() => CalculateUDI(survey, mainStId)); 
            Thread worker = new Thread(ts);
            worker.Start();

            string url = "";
            if (radByMainLanes.Checked)
                url = string.Format("../Sections/MdResults.aspx?id={0}&All=0", RequestID.ToString());
            else if (radByIntersections.Checked)
                url = string.Format("../Intersections/MdResults.aspx?id={0}&All=0", RequestID.ToString());
            else if (radByRegionNo.Checked || radByRegionName.Checked || radByRegionsAreaName.Checked || radByMunicName.Checked)
                url = string.Format("../Regions/MdResults.aspx?id={0}&All=0", RequestID.ToString());

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
        finally
        {
            btnShowReport.Enabled = true;
        }
    }

    protected void btnRoadNetworkUdiCalc_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "32")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());


                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(Calculate);
                Thread worker = new Thread(ts);
                worker.Start();

                string url = string.Format("ResultMd.aspx?id={0}&All=0", RequestID.ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

                lblFeedback.Text = "تم الحساب بنجاح";
            }
            else
            {
                lblFeedback.Text = Feedback.NoPermissions();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    private void CalculateUDI(int survey, int mainStID )
    {

        string user = Session["UserName"].ToString();
        bool result = true;

        MaintenanceDecisions md = new MaintenanceDecisions();
        if (radByMainLanes.Checked)
        {
           
            if (ddlMainStreets.SelectedValue == "0")
            {
                DataTable dt = new MainStreet().GetMainStreetsHavingSurveyDistresses();
                foreach (DataRow dr in dt.Rows)
                {
                    if (survey != 0)
                        result &= md.PrepareMainStreetSectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), survey, user);
                    else
                        result &= md.PrepareMainStreetSectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, false);
                }
            }
            else
            {
                if (survey != 0)
                    result &= md.PrepareMainStreetSectionsMaintenanceDecisions(mainStID, survey, user);
                else
                    result &= md.PrepareMainStreetSectionsMaintenanceDecisions(mainStID, user, false);
            }

            if (result)
            {
                lblFeedback.Text = "تم الحساب بنجاح";
                DataTable dt = md.GetMainStreetSectionLaneSamplesMaintenanceDecisions(mainStID, survey); //, true);

                ThreadResults.Add(RequestID, dt);
            }
            else
                lblFeedback.Text = "فشلت عملية الحساب";
        }
        else if (radByIntersections.Checked)
        {
           
            if (ddlMainStreets.SelectedValue == "0")
            {
                DataTable dt = new MainStreet().GetMainStreetsHavingIntersectionsSurveyDistresses();
                foreach (DataRow dr in dt.Rows)
                {
                    if (survey != 0)
                        result &= md.PrepareMainStreetIntersectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), survey, user); // id3
                    else
                        result &= md.PrepareMainStreetIntersectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, false);
                }
            }
            else
            {
                if (survey != 0)
                    result &= md.PrepareMainStreetIntersectionsMaintenanceDecisions(mainStID, survey, user);
                else
                    result &= md.PrepareMainStreetIntersectionsMaintenanceDecisions(mainStID, user, false);
            }

            if (result)
            {
                lblFeedback.Text = "تم الحساب بنجاح";
                DataTable dt = md.GetMainStreetIntersectionSamplesMaintenanceDecisions(mainStID, survey);

                ThreadResults.Add(RequestID, dt);
            }
            else
                lblFeedback.Text = "فشلت عملية الحساب";
        }
        else
        {
            if (radByRegionNo.Checked)
            {
                if (ddlRegions.SelectedValue == "0")
                {
                    DataTable dt = new Region().GetSurveyedRegions();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (survey != 0)
                            result = md.PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), survey, user);
                        else
                            result &= md.PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), user, false);
                    }
                }
                else
                {
                    int regionID = int.Parse(ddlRegions.SelectedValue);
                    if (survey != 0)
                        result = md.PrepareRegionSecondaryStreetsMaintenanceDecisions(regionID, survey, user);
                    else
                        result &= md.PrepareRegionSecondaryStreetsMaintenanceDecisions(regionID, user, false);
                }
            }
            else if (radByRegionName.Checked)
            {
                if (ddlRegionNames.SelectedValue == "0")
                    throw new Exception("الرجاء اختيار الحي الفرعي");
                else
                {
                    if (survey != 0)
                        result = md.PrepareSubdistrictSecondaryStreetsMaintenanceDecisions(ddlRegionNames.SelectedValue, survey, user);
                    else
                        result &= md.PrepareSubdistrictSecondaryStreetsMaintenanceDecisions(ddlRegionNames.SelectedValue, user);
                }
            }
            else if (radByRegionsAreaName.Checked)
            {
                if (ddlDistrict.SelectedValue == "0")
                    throw new Exception("الرجاء اختيار الحي");
                else
                {
                    if (survey != 0)
                        result = md.PrepareDistrictSecondaryStreetsMaintenanceDecisions(ddlDistrict.SelectedValue, survey, user);
                    else
                        result &= md.PrepareDistrictSecondaryStreetsMaintenanceDecisions(ddlDistrict.SelectedValue, user);
                }
            }
            else if (radByMunicName.Checked)
            {
                if (ddlMunic.SelectedValue == "0")
                    throw new Exception("الرجاء اختيار البلدية الفرعية");
                else
                {
                    if (survey != 0)
                        result = md.PrepareMunicipalitySecondaryStreetsMaintenanceDecisions(ddlMunic.SelectedValue, survey, user);
                    else
                        result &= md.PrepareMunicipalitySecondaryStreetsMaintenanceDecisions(ddlMunic.SelectedValue, user);
                }
            }

            if (result)
            {
                lblFeedback.Text = "تم الحساب بنجاح";

                DataTable dt = new DataTable();
                if (radByRegionNo.Checked)
                    dt = md.GetRegionSecondaryStreetsMaintenanceDecisions(int.Parse(ddlRegions.SelectedValue), survey);
                else if (radByRegionName.Checked)
                    dt = md.GetSubdistrictSecondaryStreetsMaintenanceDecisions(ddlRegionNames.SelectedValue, survey);
                else if (radByRegionsAreaName.Checked)
                    dt = md.GetDistrictSecondaryStreetsMaintenanceDecisions(ddlDistrict.SelectedValue, survey);
                else if (radByMunicName.Checked)
                    dt = md.GetMunicipalitySecondaryStreetsMaintenanceDecisions(ddlMunic.SelectedValue, survey);

                ThreadResults.Add(RequestID, dt);
            }
            else
                lblFeedback.Text = "فشلت عملية الحساب";
        }
    }

    private void CalculateRegionsALL()
    {
        DataTable dt;
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();


        dt = new Region().GetSurveyedRegions();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), user, true);

        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    private void CalculateMainStreets()
    {
        DataTable dt;
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();


        dt = new MainStreet().GetMainStreetsHavingSurveyDistresses();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareMainStreetSectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, true);

        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    private void Calculate()
    {
        DataTable dt;
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();


        dt = new MainStreet().GetMainStreetsHavingSurveyDistresses();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareMainStreetSectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, true); // id3

        dt = new MainStreet().GetMainStreetsHavingIntersectionsSurveyDistresses();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareMainStreetIntersectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, true);

        dt = new Region().GetSurveyedRegions();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["REGION_ID"].ToString()), user, true);


        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintenanceDecisionCalc.aspx", false);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlOldSurveys.Items.Clear();
            ddlOldSurveys.Items.Add(new ListItem("المسح الأخير", "0"));
            ddlOldSurveys.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void ddlRegionNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void ddlMunic_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }



    protected void btnRegions_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "32")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());
                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateRegionsALL);
                Thread worker = new Thread(ts);
                worker.Start();

                string url = string.Format("ResultMd.aspx?id={0}&All=0", RequestID.ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

                lblFeedback.Text = "تم الحساب بنجاح";


            }
            else
            {
                lblFeedback.Text = Feedback.NoPermissions();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
}