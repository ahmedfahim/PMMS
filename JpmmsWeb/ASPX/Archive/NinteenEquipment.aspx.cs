using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_NinteenEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }

    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString() != "49" && Session["UserID"].ToString() != "55")
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}