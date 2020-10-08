using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DefaultQcUdi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() == "Regions")
                {
                    gvRegionSamples.DataSource = new JpmmsClasses.BL.MainStreet().GetRegionsNoUdi();
                    gvRegionSamples.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "Intersect")
                {
                    GridView1.DataSource = new JpmmsClasses.BL.MainStreet().GetIntersetionNoUdi();
                    GridView1.DataBind();
                }
                else 
                    Response.Redirect("~/ASPX/Default.aspx", false);
              
            }

        }
    }
    protected void DrpDwnListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString[0].ToString() == "Regions")
        {
            gvRegionSamples.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetReceivedUDIStreets(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue);
            gvRegionSamples.DataBind();
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (gvRegionSamples.Rows[i].Cells[1].Text != (int.Parse(gvRegionSamples.Rows[i].Cells[3].Text) + int.Parse(gvRegionSamples.Rows[i].Cells[4].Text)).ToString())
                    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
            }
            lblFeedback.Text = " عدد " + gvRegionSamples.Rows.Count + " منطقة "; 
        }
        else if (Request.QueryString[0].ToString() == "Intersect")
        {
            GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().GetReceivedUDIIntersections(DrpDwnListMonth.SelectedValue, RadioButtonList1.SelectedValue);
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[1].Text != (int.Parse(GridView1.Rows[i].Cells[2].Text) + int.Parse(GridView1.Rows[i].Cells[3].Text)).ToString())
                    GridView1.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
            }
            lblFeedback.Text = " عدد " + GridView1.Rows.Count + " التقاطعات ";
        }
              
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrpDwnListMonth_SelectedIndexChanged(null, null);
    }
}