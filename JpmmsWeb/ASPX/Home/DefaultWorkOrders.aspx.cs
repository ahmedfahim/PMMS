using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Home_DefaultWorkOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["ViewWorkOrder"].ToString() == false.ToString())
            Response.Redirect("Logout.aspx", false);
    }
}