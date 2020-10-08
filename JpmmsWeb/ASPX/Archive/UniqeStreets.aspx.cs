using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_UniqeStreets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            Session["PhotoChanged"] = false;
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
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (gvRegionSamples.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;")
                    {
                        float value;
                        if (float.TryParse(gvRegionSamples.Rows[i].Cells[5].Text, out value) && value > 0)
                            gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
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
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (gvRegionSamples.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;")
                    {
                        float value;
                        if (float.TryParse(gvRegionSamples.Rows[i].Cells[5].Text, out value) && value > 0)
                            gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.GreenYellow;
                    }
                        
                }
            }
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
    protected void gvRegionSamples_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()) || Session["Permissions"].ToString()[1] != '1' || Session["UserID"].ToString() != "37")
            lblFeedback.Text = Feedback.NoPermissions();
        else
            lblFeedback.Text = "لحذف شارع راجع GIS";
        //if (!bool.Parse(Session["canEdit"].ToString()) || Session["Permissions"].ToString()[1] != '1' || Session["UserID"].ToString() != "37")
        //    lblFeedback.Text = Feedback.NoPermissions();
        //else
        //{
        //    JpmmsClasses.BL.Region Rg = new JpmmsClasses.BL.Region();
        //    Rg.DeleteRegionSamplesStreet(int.Parse(gvRegionSamples.Rows[e.NewSelectedIndex].Cells[0].Text));
        //    gvRegionSamples.DataBind();
        //    lblFeedback.Text = "تم حذف الشارع وتم حذف العيوب";
        //    lblFeedback.Focus();

        //}
    }
}