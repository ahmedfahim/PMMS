using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_WorkorderQcUdi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            gvRegionSamples.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetReceivedUDIStreets();
            gvRegionSamples.DataBind();
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (gvRegionSamples.Rows[i].Cells[1].Text != (int.Parse(gvRegionSamples.Rows[i].Cells[3].Text) + int.Parse(gvRegionSamples.Rows[i].Cells[4].Text)).ToString())
                     gvRegionSamples.Rows[i].Visible = true;//gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                else
                    gvRegionSamples.Rows[i].Visible = false;
            }
        }
    }
    
}