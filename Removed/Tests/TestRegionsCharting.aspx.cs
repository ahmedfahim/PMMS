using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Tests_TestRegionsCharting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        string url = string.Format("ViewRegionsChartingTestPage.aspx?id={0}", ddlRegions.SelectedValue);
        Response.Redirect(url, false);
    }

}
