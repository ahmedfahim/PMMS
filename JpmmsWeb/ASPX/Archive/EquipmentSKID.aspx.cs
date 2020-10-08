using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ASPX_Archive_EquipmentSKID : System.Web.UI.Page
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
            System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().TOTALSUMSKID();
            lblFeedbackTotalArea.Text = "  إجمالي الكمية الممسوحة  " + dt.Rows[0][0].ToString() + " كيلو متر ";
            lblFeedbackTotalStreets.Text = "  إجمالي عدد الشوارع  " + dt.Rows[0][1].ToString() + " شارع ";
            gvRegionSamples.DataSource = new JpmmsClasses.BL.MainStreet().CompareSKID(DropDownList1.SelectedValue);
            gvRegionSamples.DataBind();
            //bool IRI, SYS = false;
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                //IRI = gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;" && gvRegionSamples.Rows[i].Cells[5].Text == "&nbsp;" && gvRegionSamples.Rows[i].Cells[3].Text == "&nbsp;";
                //SYS = gvRegionSamples.Rows[i].Cells[6].Text == "&nbsp;" && gvRegionSamples.Rows[i].Cells[4].Text == "&nbsp;" && gvRegionSamples.Rows[i].Cells[2].Text == "&nbsp;";

                //if (gvRegionSamples.Rows[i].Cells[4].Text != gvRegionSamples.Rows[i].Cells[5].Text)
                //{
                //    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                //}
                //else if (gvRegionSamples.Rows[i].Cells[2].Text != gvRegionSamples.Rows[i].Cells[3].Text)
                //{
                //    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.Red;
                //}

                //if (IRI && SYS)
                //    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.Red;
                //else if (IRI && SYS == false)
                //    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                //else if (SYS && IRI == false)
                //    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.BlanchedAlmond;

                //if (gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;" && gvRegionSamples.Rows[i].Cells[6].Text == "&nbsp;")
                //    SUM += 0f;
                //else if (gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;")
                //    SUM += float.Parse(gvRegionSamples.Rows[i].Cells[6].Text == "&nbsp;" ? "0" : gvRegionSamples.Rows[i].Cells[6].Text);
                //else if (gvRegionSamples.Rows[i].Cells[6].Text == "&nbsp;")
                //    SUM += float.Parse(gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;" ? "0" : gvRegionSamples.Rows[i].Cells[7].Text);
                //else
                //    SUM += float.Parse(gvRegionSamples.Rows[i].Cells[7].Text);

                SUM += float.Parse(gvRegionSamples.Rows[i].Cells[6].Text);
                // SUM += float.Parse(gvRegionSamples.Rows[i].Cells[7].Text == "&nbsp;" ? gvRegionSamples.Rows[i].Cells[6].Text : gvRegionSamples.Rows[i].Cells[7].Text);
            }
            lblFeedbackClearance.Text = " عدد " + gvRegionSamples.Rows.Count + " شارع " + Math.Round(SUM, 2) + " كيلو متر ";
            if (gvRegionSamples.Rows.Count != int.Parse(dt.Rows[0][1].ToString()) && DropDownList1.SelectedValue == "ALL")
            {
                HyperLinkSKIDIR.Visible = true;
                HyperLinkSKIDIR.Text = new JpmmsClasses.BL.MainStreet().SKIDNotIRI().Rows.Count + " " + "شارع يحتاج المسح بـ IRI";
            }
            else
                HyperLinkSKIDIR.Visible = false;
            GridViewDuplicates();
        }
        else
        {
            lblFeedbackClearance.Text = lblFeedbackTotalStreets.Text = lblFeedbackTotalArea.Text = string.Empty;
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