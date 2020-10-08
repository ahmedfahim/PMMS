using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_ChangeSecoundST : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

           
        }

    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            gvRegionSamples.AllowPaging = true;
            gvRegionSamples.DataBind();
            gvRegionSamples.SelectedIndex = -1;
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

    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()) || Session["Permissions"].ToString()[1] != '1')
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();

        }
        if (Session["UserID"].ToString() == "51" || Session["UserID"].ToString() == "33" || Session["UserID"].ToString() == "37" )
        {

        }
        else if (Session["UserID"].ToString() != "51")
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
       
           
    }


    
}