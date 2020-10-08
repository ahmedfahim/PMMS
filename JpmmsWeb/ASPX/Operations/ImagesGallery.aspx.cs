using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Operations_ImagesGallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            radSection_CheckedChanged(sender, e);
        }
    }

    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        if (radSection.Checked)
        {
            //if (ddlMainStreets.SelectedValue != "0")
            //{
            //Session["MainStreetID"] = ddlMainStreets.SelectedValue;
            SearchMainSt1.Visible = true;
            //}
            //else
            //    SearchMainSt1.Visible = false;
        }
        //else if (radIntersection.Checked)
        //{
        //    if (ddlMainStreets.SelectedValue != "0")
        //    {
        //        Session["MainStreetID"] = ddlMainStreets.SelectedValue;
        //        SearchIntersect1.Visible = true;
        //    }
        //    else
        //        SearchIntersect1.Visible = false;
        //}
        else if (radRegionSecondary.Checked)
        {
            SearchRegion1.Visible = true;
        }
    }

    protected void OnMainStSearchChanged()
    {
        try
        {
            int selectedID = SearchMainSt1.SelectedMainStreetID;
            if (selectedID != 0)
            {
                ddlMainStreets.SelectedValue = selectedID.ToString();
                ddlMainStreets_SelectedIndexChanged(new object(), new EventArgs());
                SearchMainSt1.Visible = false;
            }
            else
            {
                SearchMainSt1.Visible = false;
                ddlMainStreets.SelectedValue = "0";
                ddlMainStreets_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void OnSetSearchChanged()
    {
        try
        {
            int selectedID = SearchRegion1.SelectedRegionID;
            if (selectedID != 0)
            {
                ddlRegions.SelectedValue = selectedID.ToString();
                ddlRegions_SelectedIndexChanged(new Object(), new EventArgs());
                SearchRegion1.Visible = false;
            }
            else
            {
                SearchRegion1.Visible = false;
                ddlRegions.SelectedValue = "0";
                ddlRegions_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            pnlMainSt.Visible = true;
            ddlMainStreets.Visible = true;
            //ddlMainStreetIntersection.Visible = false;
            ddlRegions.Visible = false;
            pnlRegion.Visible = false;
            lbtnSearchMainSt.Visible = radSection.Checked;
            lbtnSearchRegions.Visible = radRegionSecondary.Checked;

            ddlMainStreets.SelectedValue = "0";
            //ddlMainStreetSection.Visible = true;
            //ddlMainStreetSection.SelectedValue = "0";
            //ddlMainStreetSection_SelectedIndexChanged(sender, e);

            //ddlMainStreetIntersection.SelectedValue = "0";
            ddlRegions.SelectedValue = "0";

            Session["MainStreetID"] = ddlMainStreets.SelectedValue;
            lblFeedback.Text = "";
            lnkPrint.NavigateUrl = "";

            //lvwImages.DataSource = null;
            //lvwImages.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void radRegionSecondary_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            pnlMainSt.Visible = false;

            ddlMainStreets.Visible = false;
            //ddlMainStreetSection.Visible = false;
            //ddlMainStreetIntersection.Visible = false;

            lbtnSearchMainSt.Visible = radSection.Checked;
            lbtnSearchRegions.Visible = radRegionSecondary.Checked;

            pnlRegion.Visible = true;
            ddlRegions.Visible = true;
            ddlRegions.SelectedValue = "0";

            //ddlMainStreetIntersection.SelectedValue = "0";
            //ddlMainStreetSection.SelectedValue = "0";

            lblFeedback.Text = "";
            lnkPrint.NavigateUrl = "";

            //lvwImages.DataSource = null;
            //lvwImages.DataBind();
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

            if (ddlMainStreets.SelectedValue != "0")
            {
                //DataTable dt = new ImagesGallery().GetImages(int.Parse(ddlMainStreets.SelectedValue), RoadType.MainStreet);
                //if (dt.Rows.Count > 0)
                //{
                //    lvwImages.DataSource = dt;
                lvwImages.DataBind();
                lnkPrint.NavigateUrl = string.Format("PrintImages.aspx?mid={0}&rid=0", ddlMainStreets.SelectedValue);
            }
            //    else
            //    {
            //        lvwImages.DataSource = null;
            //        lvwImages.DataBind();
            //        throw new Exception(Feedback.NoData());
            //    }
            //}
            //else
            //{
            //    lvwImages.DataSource = null;
            //    lvwImages.DataBind();
            //    throw new Exception(Feedback.NoData());
            //}

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

            if (ddlRegions.SelectedValue != "0")
            {
            //    DataTable dt = new ImagesGallery().GetImages(int.Parse(ddlRegions.SelectedValue), RoadType.RegionSecondarySt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        lvwImages.DataSource = dt;
                    lvwImages.DataBind();
                    lnkPrint.NavigateUrl = string.Format("PrintImages.aspx?mid=0&rid={0}", ddlRegions.SelectedValue);
            }
            //    else
            //    {
            //        lvwImages.DataSource = null;
            //        lvwImages.DataBind();
            //        throw new Exception(Feedback.NoData());
            //    }
            //}
            //else
            //{
            //    lvwImages.DataSource = null;
            //    lvwImages.DataBind();
            //    throw new Exception(Feedback.NoData());
            //}

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lvwImages_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            lvwImages.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        try
        {
            lvwImages.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}
