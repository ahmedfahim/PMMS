using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DefaultQcAreaStreet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "Width")
            {
                Label1.Text = "عروض";
                GridView2.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetStreetWidthQuality();
                GridView2.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "Length")
            {
                Label1.Text = "أطوال";
                GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetStreetLenthQuality();
                GridView1.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "Area")
            {
                Label1.Text = "المساحة";
                GridView3.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetStreetAreaQuality();
                GridView3.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }
  
}