using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_ReportsQC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 1)
                    GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetReportsQC(false);
                else
                    GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetReportsQC(null);
                GridView1.DataBind();
            }
        }
    }
}