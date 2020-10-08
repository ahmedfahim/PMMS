using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Lookups_Regions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[6] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridView1.SelectedValue != null)
            {
                if (!bool.Parse(Session["canEdit"].ToString()))
                {
                    UpdateCancelButton_Click(sender, e);
                    lblFeedback.Text = Feedback.NoPermissions();
                    return;
                }

                FormView1.Visible = true;
                FormView1.DataBind();
                FormView1.Focus();
            }
            else
                FormView1.Visible = false;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.InnerException.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        GridView1.SelectedIndex = -1;
        GridView1_SelectedIndexChanged(sender, e);
    }

    protected void odsRegionsInfo_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            GridView1.DataBind();
            UpdateCancelButton_Click(sender, e);
            lblFeedback.Text = Feedback.UpdateSuccessfull();
        }
    }

}