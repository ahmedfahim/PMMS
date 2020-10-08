using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_EquipmentTwelve : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            
        }
    }
    protected void gvRegionSamplesIRI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            //HeaderCell.Text = "        العدد        ";
            //HeaderCell.Text += new JpmmsClasses.BL.MainStreet().LenghthStreetsMFV().Rows[0][0];
            //HeaderCell.Text += "       الطول        ";
            //HeaderCell.Text += new JpmmsClasses.BL.MainStreet().LenghthStreetsMFV().Rows[0][1];
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamples.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamples.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "-1")
        {
            float value = 0;
            int count = 0;
            int rowNum = (RadioButtonList1.Items[0].Selected) ? 2 : 3;
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if (DropDownList1.SelectedValue == "4")
                {
                    if ((gvRegionSamples.Rows[i].Cells[4].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "5")
                {
                    if ((gvRegionSamples.Rows[i].Cells[5].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "6")
                {
                    if ((gvRegionSamples.Rows[i].Cells[6].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "7")
                {
                    if ((gvRegionSamples.Rows[i].Cells[7].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "8")
                {
                    if ((gvRegionSamples.Rows[i].Cells[8].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "9")
                {
                    if ((gvRegionSamples.Rows[i].Cells[9].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "10")
                {
                    if ((gvRegionSamples.Rows[i].Cells[10].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "11")
                {
                    if ((gvRegionSamples.Rows[i].Cells[11].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "12")
                {
                    if ((gvRegionSamples.Rows[i].Cells[12].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "13")
                {
                    if ((gvRegionSamples.Rows[i].Cells[13].Controls[0] as CheckBox).Checked)
                    {
                        value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                        count++;
                    }
                }
                else if (DropDownList1.SelectedValue == "0")
                {
                    value += float.Parse((gvRegionSamples.Rows[i].Cells[rowNum]).Text);
                    count++;
                }
                else
                    break;
            }
            string x = (RadioButtonList1.Items[0].Selected) ? RadioButtonList1.Items[0].Text : RadioButtonList1.Items[1].Text;
            lblFeedback.Text = value.ToString() + " كم من   " + x;
            lblCount.Text = count.ToString() + " شارع   ";
        }
        else
        {
            lblFeedback.Text = Feedback.NoDistressSelected();
            lblCount.Text = string.Empty;
        }

    }
    protected void RadioBtnListClearance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioBtnListClearance.SelectedValue == true.ToString())
            gvRegionSamples.DataSource = new JpmmsClasses.BL.MainStreet().FinshedStreetsMFV(true);
        else
            gvRegionSamples.DataSource = new JpmmsClasses.BL.MainStreet().FinshedStreetsMFV(false);

        ViewState["gvRegionSamples"] = gvRegionSamples.DataSource;
        ViewState["sortdr"] = "Asc";
        gvRegionSamples.DataBind();
        
    }
    protected void gvRegionSamples_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamples"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            gvRegionSamples.DataSource = dtrslt;
            gvRegionSamples.DataBind();
        }
    }
    protected void gvRegionSamples_DataBound(object sender, EventArgs e)
    {
        
    }
}