using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class ASPX_Archive_EquipmentFWD : System.Web.UI.Page
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
            float SUMLEN = 0f;
            float SumHafria = 0f;
            lblFeedbackTotal.Text = "  إجمالي الممسوح  " + new JpmmsClasses.BL.Lookups.MaintDecision().GetAllDecisionsFWD_HAFRIAT() + " نقطة ";
            DataSet ds = new JpmmsClasses.BL.MainStreet().CompareFWD(DropDownList1.SelectedValue);
            gvRegionSamples.DataSource = ds.Tables[0];
            gvRegionSamples.DataMember = ds.Tables[0].TableName;
            gvRegionSamples.DataBind();
            GridView1.DataSource = ds.Tables[1];
            GridView1.DataMember = ds.Tables[1].TableName;
            GridView1.DataBind();

            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                //    if (gvRegionSamples.Rows[i].Cells[4].Text != gvRegionSamples.Rows[i].Cells[5].Text)
                //    {
                //        gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                //    }
                //    else if (gvRegionSamples.Rows[i].Cells[2].Text != gvRegionSamples.Rows[i].Cells[3].Text)
                //    {
                //        gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.Red;
                //    } 
                SUM += float.Parse(gvRegionSamples.Rows[i].Cells[2].Text);
                SUMLEN += float.Parse(gvRegionSamples.Rows[i].Cells[3].Text);
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
                SumHafria += float.Parse(GridView1.Rows[i].Cells[1].Text == "&nbsp;" ? "0" : GridView1.Rows[i].Cells[1].Text);

            lblFeedbackClearance.Text = " عدد " + gvRegionSamples.Rows.Count + " شارع " + Math.Round(SUM, 2) + " نقطة " + Math.Round(SUMLEN, 2) + " كيلو متر ";
            lblFeedbackHAFRIAT.Text = " عدد " + GridView1.Rows.Count + " ترخيص " + Math.Round(SumHafria, 2) + " نقطة ";
            GridViewDuplicates();
        }
        else
        {
            lblFeedbackHAFRIAT.Text= lblFeedbackClearance.Text = lblFeedbackTotal.Text = string.Empty;
            gvRegionSamples.DataBind();
            GridView1.DataBind();
        }
    }


    protected int findIDInGrid(ArrayList array, string s)
    {
        int digit = -1;
        foreach (object obj in array)
        {
            if (obj.ToString() == s)
            {
                digit = array.IndexOf(obj);
                break;
            }
        }

        return digit;
    }
    protected void GridViewDuplicates()
    {
        try
        {
            ArrayList array = new ArrayList();
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (findIDInGrid(array, gvRegionSamples.Rows[i].Cells[0].Text) != -1)
                    gvRegionSamples.Rows[findIDInGrid(array, gvRegionSamples.Rows[i].Cells[0].Text)].BackColor = System.Drawing.Color.Red;
                array.Add(gvRegionSamples.Rows[i].Cells[0].Text);
            }
        }
        catch
        {

        }
    }
}