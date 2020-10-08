using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_InterSectionFinshed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int result;
        if ((gvRegionSamples.Rows[e.RowIndex].Cells[8].Controls[0] as CheckBox).Checked)
        {
            if (int.TryParse(gvRegionSamples.Rows[e.RowIndex].Cells[6].Text, out result))
            {
                lblFeedback.Text = "يجب حذف العيوب اولا";
                e.Cancel = true;
            }
        }
        else
        {
            lblFeedback.Text = string.Empty;
           // gvRegionSamples.Rows[e.RowIndex].BackColor = System.Drawing.Color.FromName("#D1DDF1");
        }
       
    }
}