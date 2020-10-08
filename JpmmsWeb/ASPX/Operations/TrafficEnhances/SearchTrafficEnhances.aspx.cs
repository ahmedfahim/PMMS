using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class ASPX_Operations_TrafficEnhances_SearchTrafficEnhances : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack && !string.IsNullOrEmpty(Request.QueryString["msg"]))
        {
            if (int.Parse(Request.QueryString["msg"]) == 1)
            {
                lblMessage.Text = Feedback.InsertSuccessfull();
                lblMessage.ForeColor = Color.Green;
            }
        }
    }

    protected void odsTrafficEnhancesAll_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblMessage.Text = e.Exception.InnerException.Message;
            lblMessage.ForeColor = Color.Red;
            e.ExceptionHandled = true;
        }
        else
            lblMessage.Text = Feedback.DeleteSuccessfull();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblMessage.Text = Feedback.NoPermissions();
            lblMessage.ForeColor = Color.Red;
            e.Cancel = true;
        }
    }

}