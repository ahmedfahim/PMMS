using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SectionsErorrMainNO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "FWD")
            {
                Label1.Text = " من الحمل الساقط";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrMainNOFWD();
                gvERorrDistress.DataBind();

            }
            else if (Request.QueryString[0].ToString() == "GPR")
            {
                Label1.Text = " من سماكات الطبقات";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrMainNOGPR();
                gvERorrDistress.DataBind();

            }
            else if (Request.QueryString[0].ToString() == "SKID")
            {
                Label1.Text = " من مقاومة الإنزلاق";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrMainNOSKID();
                gvERorrDistress.DataBind();

            }
            else if (Request.QueryString[0].ToString() == "IRI")
            {
                Label1.Text = " من حالة الوعورة";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrMainNOIRI();
                gvERorrDistress.DataBind();

            }
            else if (Request.QueryString[0].ToString() == "DDF")
            {
                Label1.Text = " من العيوب ";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrMainNODDF();
                gvERorrDistress.DataBind();

            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }
}