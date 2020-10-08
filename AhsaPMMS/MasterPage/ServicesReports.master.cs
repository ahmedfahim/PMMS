using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_ServicesReports : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && (Request.Browser.Browser == "IE" && float.Parse(Request.Browser.Version) < 7.0))
            Response.Redirect("~/BrowserUpgrade.aspx", false);
    }

}
