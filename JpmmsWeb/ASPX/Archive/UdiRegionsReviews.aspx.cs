using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_UdiRegionsReviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "TRUE")
                Label1.Text = "ممتاز / جيد";
            else if (Request.QueryString[0].ToString() == "FALSE")
                Label1.Text = "مقبول / ضعيف";
            else
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }
   
}