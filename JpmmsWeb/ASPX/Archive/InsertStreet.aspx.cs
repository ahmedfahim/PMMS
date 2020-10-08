using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Archive_InsertStreet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1' || Session["UserID"].ToString() != "37")
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            ddlRegions.SelectedValue = "0";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
            lblFeedback.Text = Feedback.NoPermissions();
        else
        {
            if (txtSECOND_ST_NO.Text.Length == 2)
            {
                if (new Region().InsertNewStreetRegion(txtSECOND_ST_NO.Text.ToUpper(), int.Parse(ddlRegions.SelectedValue), ddlRegions.SelectedItem.Text))
                {

                    txtSECOND_ST_NO.Text = string.Empty;
                    lblFeedback.Text = Feedback.InsertSuccessfull();
                    ddlRegions_SelectedIndexChanged(null, null);
                }
                else
                    lblFeedback.Text = Feedback.UpdateExceptionUnique();
            }
            else
                lblFeedback.Text = "تأكد من رقم العينة ";

        }  
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
        PanelNewStreets.Visible = false;
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
             gvRegionSamples.AllowPaging = true;
             lblFeedback.Text = "";
             gvRegionSamples.DataBind();
            if (gvRegionSamples.Rows.Count > 0)
            {
                PanelNewStreets.Visible = true;
                gvRegionSamples.SelectedIndex = -1;
            }
            else
            {
               PanelNewStreets.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }
    protected void gvRegionSamples_PageIndexChanged(object sender, EventArgs e)
    {
        gvRegionSamples.SelectedIndex = -1;
    }
   
    protected void odsRegionSamples_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

   
}