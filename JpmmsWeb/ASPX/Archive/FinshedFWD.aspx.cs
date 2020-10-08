using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_FinshedFWD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            else
            {
                string v1 = new JpmmsClasses.BL.MainStreet().SumReadyFWD(null);
                string v2 = new JpmmsClasses.BL.MainStreet().SumReadyFWD(false);
                string v3 = new JpmmsClasses.BL.MainStreet().SumReadyFWD(true);
                lblSumReadyFWDNULL.Text = "    عدد النقاط الناقصة " + v1;
                lblSumReadyFWDFalse.Text = "    عدد النقاط بالنظام " + v2;
                lblSumReadyFWDTrue.Text = "    عدد النقاط المنجزة " + v3;
                lblSum.Text = "  إجمالي  عدد النقاط  " + (float.Parse(v1) + float.Parse(v2) + float.Parse(v3)).ToString();
            }
        }
    }
    protected void gvRegionSamples_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        lblFWDTOTAL.Text = "  إجمالي  عدد الشوارع  " + gvRegionSamples.Rows.Count.ToString();
    }
}