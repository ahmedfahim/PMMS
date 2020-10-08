using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Operations_PrintImages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mid"] == null || Request.QueryString["rid"] == null)
            Response.Redirect("ImagesGallery.aspx", false);
    }

}