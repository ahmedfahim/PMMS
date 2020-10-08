using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_DefaultClearance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);


        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "-1")
        {
            float SUM = 0f;
            lblFeedbackTotal.Text = "  إجمالي الممسوح  " + new JpmmsClasses.BL.Lookups.MaintDecision().GetAllDecisionsInterSections() + " كيلو متر ";
            gvRegionSamples.DataSource = new JpmmsClasses.BL.MainStreet().CompareInterSetions(DropDownList1.SelectedValue);
            gvRegionSamples.DataBind();
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (gvRegionSamples.Rows[i].Cells[2].Text != gvRegionSamples.Rows[i].Cells[3].Text)
                {
                    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                }
                //else
                //    gvRegionSamples.Rows[i].Visible = false; 

                SUM += float.Parse(gvRegionSamples.Rows[i].Cells[5].Text);
            }
            lblFeedbackClearance.Text = " عدد " + gvRegionSamples.Rows.Count + " شارع " + Math.Round(SUM, 2) + " كيلو متر /حارة ";
        }
        else
        {
            lblFeedbackClearance.Text = lblFeedbackTotal.Text = string.Empty;
            gvRegionSamples.DataBind();
        }
    }
}