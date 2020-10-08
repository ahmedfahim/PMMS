using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DataEntryReviewed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();

        }
        if (Session["UserID"].ToString() == "37" || Session["UserID"].ToString() == "34" )
        {
           
        }
        else 
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }

    }
}