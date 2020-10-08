using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Home_ChangeLanguage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void radEnglish_CheckedChanged(object sender, EventArgs e)
    {
        Session["lang"] = "en-GB";
    }

    protected void radArabic_CheckedChanged(object sender, EventArgs e)
    {
        Session["lang"] = "ar-AE";
    }

}
