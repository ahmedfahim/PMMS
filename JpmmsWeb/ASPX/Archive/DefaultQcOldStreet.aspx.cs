using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DefaultQcOldStreet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            gvRegionSamples.AllowPaging = true;
            gvRegionSamples.DataBind();
            gvRegionSamples.SelectedIndex = -1;
            gvRegionSamplesSurveyThree.AllowPaging = true;
            gvRegionSamplesSurveyThree.DataBind();
            gvRegionSamplesSurveyThree.SelectedIndex = -1;
            gvRegionSamplesOLD.AllowPaging = true;
            gvRegionSamplesOLD.DataBind();
            gvRegionSamplesOLD.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void lbtnPagingYes_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            gvRegionSamples.SelectedIndex = -1;
            gvRegionSamples.AllowPaging = false;
            gvRegionSamples.DataBind();
            gvRegionSamplesSurveyThree.SelectedIndex = -1;
            gvRegionSamplesSurveyThree.AllowPaging = false;
            gvRegionSamplesSurveyThree.DataBind();
            gvRegionSamplesOLD.SelectedIndex = -1;
            gvRegionSamplesOLD.AllowPaging = false;
            gvRegionSamplesOLD.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);


    }
    protected void lbtnPagingNO_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            gvRegionSamples.SelectedIndex = -1;
            gvRegionSamples.AllowPaging = true;
            gvRegionSamples.DataBind();
            gvRegionSamplesSurveyThree.SelectedIndex = -1;
            gvRegionSamplesSurveyThree.AllowPaging = true;
            gvRegionSamplesSurveyThree.DataBind();
            gvRegionSamplesOLD.SelectedIndex = -1;
            gvRegionSamplesOLD.AllowPaging = true;
            gvRegionSamplesOLD.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void gvRegionSamples_PageIndexChanged(object sender, EventArgs e)
    {
        gvRegionSamples.SelectedIndex = -1;

    }


    protected void gvRegionSamples_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()) || Session["Permissions"].ToString()[0] != '1' || Session["UserID"].ToString() != "37")
            lblFeedback.Text = Feedback.NoPermissions();
        else
        {
         
        }
    }
}