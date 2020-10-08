using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.UDI;
using System.Threading;
using System.Data;
using JpmmsClasses;

public partial class ASPX_Operations_PavementStatusCalc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Response.Redirect("~/ASPX/Default.aspx", false);
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')//||  Session["UserID"].ToString()!= "32")
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (Request.QueryString["adv"] != null)
                ddlOldSurveys.Visible = (Request.QueryString["adv"].ToString() == "1");


            radByMainLanes_CheckedChanged(sender, e);
            ddlMainStreets_SelectedIndexChanged(sender, e);
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
            DrpDwnListMonth.Enabled = false;

            ddlMainStreets.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";
            ddlRegionNames.SelectedValue = "0";
            ddlMunic.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";

            ddlMainStreets.Items.Clear();
            ddlMainStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("الكل", "0"));
            ddlMainStreets.Items[0].Selected = true;
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
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = true;
        ddlRegionNames.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = false;
        DrpDwnListMonth.Enabled = false;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";

        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radByRegionName_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlRegionNames.Enabled = true;
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = false;
        DrpDwnListMonth.Enabled = false;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";

        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radByRegionsAreaName_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlDistrict.Enabled = true;
        ddlMunic.Enabled = false;
        DrpDwnListMonth.Enabled = false;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";

        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radByMunicName_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = true;
        DrpDwnListMonth.Enabled = false;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";

        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    private void CalculateUDI()
    {
        int survey = int.Parse(ddlOldSurveys.SelectedValue);
        string user = Session["UserName"].ToString();
        bool result = true;

        if (radByMainLanes.Checked)
        {
            int mainStID = int.Parse(ddlMainStreets.SelectedValue);
            SectionsUDI udi = new SectionsUDI();
            if (ddlMainStreets.SelectedValue == "0")
            {
                DataTable dt = new MainStreet().GetMainStreetsHavingSurveyDistresses();
                foreach (DataRow dr in dt.Rows)
                {
                    if (survey != 0)
                        result &= udi.CalculateMainStreetSectionsUDI(int.Parse(dr["STREET_ID"].ToString()), survey, user); // id3
                    else
                        result &= udi.CalculateMainStreetSectionsUDI(int.Parse(dr["STREET_ID"].ToString()), user, false);
                }
            }
            else
            {
                if (survey != 0)
                    result &= udi.CalculateMainStreetSectionsUDI(mainStID, survey, user);
                else
                    result &= udi.CalculateMainStreetSectionsUDI(mainStID, user, false);
            }

            if (result)
            {
                lblFeedback.Text = "تم الحساب بنجاح";
                DataTable dt = udi.GetSectionsUdiByMainStreet(mainStID, survey, true);

                ThreadResults.Add(RequestID, dt);
            }
            else
                lblFeedback.Text = "فشلت عملية الحساب";
        }
        else if (radByIntersections.Checked)
        {
            int mainStID = int.Parse(ddlMainStreets.SelectedValue);
            IntersectionUDI udi = new IntersectionUDI();
            if (ddlMainStreets.SelectedValue == "0")
            {
                DataTable dt = new MainStreet().GetMainStreetsHavingIntersectionsSurveyDistresses();
                foreach (DataRow dr in dt.Rows)
                {
                    if (survey != 0)
                        result &= udi.CalculateMainStreetIntersectionsUDI(int.Parse(dr["STREET_ID"].ToString()), survey, user);
                    else
                        result &= udi.CalculateMainStreetIntersectionsUDI(int.Parse(dr["STREET_ID"].ToString()), user, false);
                }
            }
            else
            {
                if (survey != 0)
                    result &= udi.CalculateMainStreetIntersectionsUDI(mainStID, survey, user);
                else
                    result &= udi.CalculateMainStreetIntersectionsUDI(mainStID, user, false);
            }

            if (result)
            {
                lblFeedback.Text = "تم الحساب بنجاح";
                DataTable dt = udi.GetMainStreetIntersectionUDI(mainStID, survey);

                ThreadResults.Add(RequestID, dt);
            }
            else
                lblFeedback.Text = "فشلت عملية الحساب";
        }
        else
        {
            RegionSecondaryStUDI udi = new RegionSecondaryStUDI();
            if (radByRegionNo.Checked)
            {
                if (ddlRegions.SelectedValue == "0")
                {
                    DataTable dt = new Region().GetSurveyedRegions();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (survey != 0)
                            result = udi.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), survey, user);
                        else
                            result &= udi.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), user, false);
                    }
                }
                else
                {
                    int regionID = int.Parse(ddlRegions.SelectedValue);
                    if (survey != 0)
                        result = udi.CalculateRegionSecondaryStreetsUDI(regionID, survey, user);
                    else
                        result &= udi.CalculateRegionSecondaryStreetsUDI(regionID, user, false);
                }
            }
            else if (radByMonth.Checked)
            {
                DataTable dt = new Region().GetSurveyedRegionsByMonth(DrpDwnListMonth.SelectedValue);
                foreach (DataRow dr in dt.Rows)
                {
                    if (survey != 0)
                        result = udi.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), survey, user);
                    else
                        result &= udi.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), user, false);
                }
            }
            else if (radByRegionName.Checked)
            {
                if (ddlRegionNames.SelectedValue == "0")
                {
                    throw new Exception("الرجاء اختيار الحي الفرعي");
                    //DataTable dt = new Region().GetSurveyedSubdistricts();
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (survey != 0)
                    //        result = udi.CalculateRegionSecondaryStreetsUDI(dr["subdistrict"].ToString(), survey, user);
                    //    else
                    //        result &= udi.CalculateRegionSecondaryStreetsUDI(dr["subdistrict"].ToString(), user);
                    //}
                }
                else
                {
                    if (survey != 0)
                        result = udi.CalculateRegionSecondaryStreetsUDI_BySubdistrict(ddlRegionNames.SelectedValue, survey, user);
                    else
                        result &= udi.CalculateRegionSecondaryStreetsUDI_BySubdistrict(ddlRegionNames.SelectedValue, user);
                }
            }
            else if (radByRegionsAreaName.Checked)
            {
                if (ddlDistrict.SelectedValue == "0")
                {
                    throw new Exception("الرجاء اختيار الحي");
                    //DataTable dt = new Region().GetSurveyedDistricts();
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (survey != 0)
                    //        result = udi.CalculateRegionSecondaryStreetsUDI_ByDistrict(dr["DIST_NAME"].ToString(), survey, user);
                    //    else
                    //        result &= udi.CalculateRegionSecondaryStreetsUDI_ByDistrict(dr["DIST_NAME"].ToString(), user);
                    //}
                }
                else
                {
                    if (survey != 0)
                        result = udi.CalculateRegionSecondaryStreetsUDI_ByDistrict(ddlDistrict.SelectedValue, survey, user);
                    else
                        result &= udi.CalculateRegionSecondaryStreetsUDI_ByDistrict(ddlDistrict.SelectedValue, user);
                }
            }
            else if (radByMunicName.Checked)
            {
                if (ddlMunic.SelectedValue == "0")
                {
                    throw new Exception("الرجاء اختيار البلدية الفرعية");
                    //DataTable dt = new Region().GetSurveyedMunicipalities();
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (survey != 0)
                    //        result = udi.CalculateRegionSecondaryStreetsUDI_ByDistrict(dr["MUNIC_NAME"].ToString(), survey, user);
                    //    else
                    //        result &= udi.CalculateRegionSecondaryStreetsUDI_ByDistrict(dr["MUNIC_NAME"].ToString(), user);
                    //}
                }
                else
                {
                    if (survey != 0)
                        result = udi.CalculateRegionSecondaryStreetsUDI_ByMunicipality(ddlMunic.SelectedValue, survey, user);
                    else
                        result &= udi.CalculateRegionSecondaryStreetsUDI_ByMunicipality(ddlMunic.SelectedValue, user);
                }
            }

            if (result)
            {
                lblFeedback.Text = "تم الحساب بنجاح";

                DataTable dt = new DataTable();
                if (radByRegionNo.Checked)
                    dt = udi.GetSecondaryStreetsUdiByRegion(int.Parse(ddlRegions.SelectedValue), survey);
                else if (radByRegionName.Checked)
                    dt = udi.GetSecondaryStreetsUdiByRegion(ddlRegionNames.SelectedValue, survey);
                else if (radByRegionsAreaName.Checked)
                    dt = udi.GetSecondaryStreetsUdiByDistrict(ddlDistrict.SelectedValue, survey);
                else if (radByMunicName.Checked)
                    dt = udi.GetSecondaryStreetsUdiByMuniciplaity(ddlMunic.SelectedValue, survey);

                ThreadResults.Add(RequestID, dt);

            }
            else
                lblFeedback.Text = "فشلت عملية الحساب";
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

            if ((radByIntersections.Checked || radByMainLanes.Checked) && string.IsNullOrEmpty(ddlMainStreets.SelectedValue))
                throw new Exception(Feedback.NoMainStreetSelected());


            RequestID = Guid.NewGuid();
            ThreadStart ts = new ThreadStart(CalculateUDI);
            Thread worker = new Thread(ts);
            worker.Start();


            string url = "";
            if (radByMainLanes.Checked)
                url = string.Format("../Sections/result.aspx?id={0}&All=0", RequestID.ToString());
            else if (radByIntersections.Checked)
                url = string.Format("../Intersections/result.aspx?id={0}&All=0", RequestID.ToString());
            else if (radByRegionNo.Checked || radByRegionName.Checked || radByRegionsAreaName.Checked || radByMunicName.Checked || radByMonth.Checked)
                url = string.Format("../Regions/result.aspx?id={0}&All=0", RequestID.ToString());

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


    private void Calculate()
    {
        DataTable dt;
        bool result = true;

        SectionsUDI udiSections = new SectionsUDI();
        IntersectionUDI udiIntersect = new IntersectionUDI();
        RegionSecondaryStUDI udiRegions = new RegionSecondaryStUDI();
        string user = Session["UserName"].ToString();


        dt = new MainStreet().GetMainStreetsHavingSurveyDistresses();
        foreach (DataRow dr in dt.Rows)
            result &= udiSections.CalculateMainStreetSectionsUDI(int.Parse(dr["STREET_ID"].ToString()), user, true);

        dt = new MainStreet().GetMainStreetsHavingIntersectionsSurveyDistresses();
        foreach (DataRow dr in dt.Rows)
            result &= udiIntersect.CalculateMainStreetIntersectionsUDI(int.Parse(dr["STREET_ID"].ToString()), user, true);

        dt = new Region().GetSurveyedRegions();
        foreach (DataRow dr in dt.Rows)
            result &= udiRegions.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), user, true);


        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    private void CalculateMainStreets()
    {
        DataTable dt;
        bool result = true;
        SectionsUDI udiSections = new SectionsUDI();
        string user = Session["UserName"].ToString();
        dt = new MainStreet().GetMainStreetsHavingSurveyDistresses();
        foreach (DataRow dr in dt.Rows)
            result &= udiSections.CalculateMainStreetSectionsUDI(int.Parse(dr["STREET_ID"].ToString()), user, true);
        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    private void CalculateRegionsALL()
    {
        DataTable dt;
        bool result = true;
        RegionSecondaryStUDI udiRegions = new RegionSecondaryStUDI();
        string user = Session["UserName"].ToString();
        dt = new Region().GetSurveyedRegions();
        foreach (DataRow dr in dt.Rows)
            result &= udiRegions.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["REGION_ID"].ToString()), user, true);
        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
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

                string url = string.Format("ResultUDI.aspx?id={0}&All=1", RequestID.ToString());
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PavementStatusCalc.aspx", false);
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

    protected void radlOldSurveys_DataBound(object sender, EventArgs e)
    {
        //radlOldSurveys.SelectedIndex = (radlOldSurveys.Items.Count == 0) ? -1 : 0;
    }

    protected void radByMonth_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Enabled = false;
        ddlRegions.Enabled = false;
        ddlRegionNames.Enabled = false;
        ddlDistrict.Enabled = false;
        ddlMunic.Enabled = false;
        DrpDwnListMonth.Enabled = true;

        ddlMainStreets.SelectedValue = "0";
        ddlRegions.SelectedValue = "0";
        ddlRegionNames.SelectedValue = "0";
        ddlMunic.SelectedValue = "0";
        ddlDistrict.SelectedValue = "0";
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

                string url = string.Format("ResultUDI.aspx?id={0}&All=1", RequestID.ToString());
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

                string url = string.Format("ResultUDI.aspx?id={0}&All=1", RequestID.ToString());
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