using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmenSKIDIRI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1' || Request.QueryString.Count != 1)
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString[0] == "GPR")
            {
                Label1.Text = "سمكات الطبقات";
                gvErorr.DataSource = new JpmmsClasses.BL.MainStreet().GPRNotIRI();
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0] == "SKID")
            {
                Label1.Text = "مقاومة الإنزلاق";
                gvErorr.DataSource = new JpmmsClasses.BL.MainStreet().SKIDNotIRI();
                gvErorr.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
            
    }
}