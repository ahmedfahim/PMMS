using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_IntersectionSumery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (!IsPostBack)
        {
            Label1.Text = " متابعة التقاطعات ";

            gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.Intersection().GetIntersectionSampleAreaSum();
            gvRegionSamplesEqupment.DataBind();

        }
    }
}