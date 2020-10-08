using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;


public partial class ASPX_Archive_EquipmentASSETS : System.Web.UI.Page
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
            lblFeedbackTotal.Text = "  إجمالي الممسوح  " + new JpmmsClasses.BL.Lookups.MaintDecision().GetAllDecisionsAssets() + " كيلو متر ";
            DataTable dTable=new JpmmsClasses.BL.MainStreet().CompareASSETS(DropDownList1.SelectedValue);;
            gvRegionSamples.DataSource =dTable; 
            gvRegionSamples.DataBind();
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
                SUM += float.Parse(gvRegionSamples.Rows[i].Cells[2].Text);
            lblFeedbackClearance.Text = " عدد " + gvRegionSamples.Rows.Count + " شارع " + Math.Round(SUM,2) + " كيلو متر ";
            GridViewDuplicates();
        }
        else
        {
            lblFeedbackClearance.Text = lblFeedbackTotal.Text = string.Empty;
            gvRegionSamples.DataBind();
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