using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_DefaultUDIStreet : System.Web.UI.Page
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
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void lbtnPagingNO_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            gvRegionSamples.SelectedIndex = -1;
            gvRegionSamples.AllowPaging = true;
            gvRegionSamples.DataBind();
            gvRegionSamplesOLD.SelectedIndex = -1;
            gvRegionSamplesOLD.AllowPaging = true;
            gvRegionSamplesOLD.DataBind();
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
    protected void odsRegionSamples_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        DataTable dt = e.ReturnValue as DataTable;
        lblFeedback.Text = "مجموع عدد الشوارع" + " " + dt.Rows.Count.ToString();
       
    }

    protected void odsRegionSamplesOLD_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        DataTable dt = e.ReturnValue as DataTable;
        lblFeedback0.Text = "مجموع عدد الشوارع" + " " + dt.Rows.Count.ToString();
    }
}