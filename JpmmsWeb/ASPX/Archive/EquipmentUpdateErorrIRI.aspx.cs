using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentUpdateErorrIRI : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }



     protected void gvERorrIRI_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
         if (Session["UserID"].ToString() == "60" ||Session["UserID"].ToString() == "56" || Session["UserID"].ToString() == "54" || Session["UserID"].ToString() == "46" || Session["UserID"].ToString() == "48")
         {
            lblFeedback.Text = string.Empty;
         }
         else
         {
             e.Cancel = true;
             lblFeedback.Text = Feedback.NoPermissions();
         }
     }
}