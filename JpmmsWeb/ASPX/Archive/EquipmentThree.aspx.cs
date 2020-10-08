using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_EquipmentThree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);


        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsGPR();
        RadioButtonList1.Items.Clear();
        RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString()));
        RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
        RadioButtonList1.DataBind();
        if (dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString() == "1")
            RadioButtonList1.Enabled = false;
        else
            RadioButtonList1.Enabled = true;
        gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoGPR(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
        gvRegionIRI.DataBind();

        gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionSections.DataBind();

        DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsGPR(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSections(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
        gvRegionSamplesIRI.DataSource = dtIRI;
        gvRegionSamplesIRI.DataBind();
        for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
        {
            if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
            {
                if (gvRegionSamplesIRI.Rows[i].Cells[1].Text != gvRegionSamplesIRI.Rows[i].Cells[4].Text)
                {
                    if (gvRegionSamplesIRI.Rows[i].Cells[1].Text == "&nbsp;")
                        gvRegionSamplesIRI.Rows[i].Cells[1].Text = "0";
                    if (gvRegionSamplesIRI.Rows[i].Cells[4].Text == "&nbsp;")
                        gvRegionSamplesIRI.Rows[i].Cells[4].Text = "0";

                    int value = int.Parse(gvRegionSamplesIRI.Rows[i].Cells[4].Text) - int.Parse(gvRegionSamplesIRI.Rows[i].Cells[1].Text);
                    gvRegionSamplesIRI.Rows[i].Cells[4].Text = value.ToString();
                    if (value > 0)
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Green;
                    else
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Yellow;

                }
                if (gvRegionSamplesIRI.Rows[i].Cells[1].Text == gvRegionSamplesIRI.Rows[i].Cells[4].Text && (gvRegionSamplesIRI.Rows[i].BackColor != System.Drawing.Color.Green || gvRegionSamplesIRI.Rows[i].BackColor != System.Drawing.Color.Yellow))
                    gvRegionSamplesIRI.Rows[i].Cells[4].Text = string.Empty;
            }
        }

        gvRegionSamplesSECTION.DataSource = dtSection;
        gvRegionSamplesSECTION.DataBind();

        ViewState["gvRegionSamplesSECTION"] = gvRegionSamplesSECTION.DataSource;
        ViewState["gvRegionSamplesIRI"] = gvRegionSamplesIRI.DataSource;
        ViewState["sortdrIRI"] = "Asc";
        ViewState["sortdr"] = "Asc";
    }
    protected void gvRegionSamplesSECTION_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من IRI";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamplesSECTION.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamplesSECTION.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void gvRegionSamplesIRI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من GPR";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamplesIRI.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamplesIRI.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void gvRegionSamplesSECTION_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamplesSECTION"];
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
            gvRegionSamplesSECTION.DataSource = dtrslt;
            gvRegionSamplesSECTION.DataBind();
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoGPR(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionIRI.DataBind();

        gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionSections.DataBind();

        DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsGPR(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSections(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionSamplesIRI.DataSource = dtIRI;
        gvRegionSamplesIRI.DataBind();
        for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
        {
            if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
            {
                if (gvRegionSamplesIRI.Rows[i].Cells[1].Text != gvRegionSamplesIRI.Rows[i].Cells[4].Text)
                {
                    if (gvRegionSamplesIRI.Rows[i].Cells[1].Text == "&nbsp;")
                        gvRegionSamplesIRI.Rows[i].Cells[1].Text = "0";
                    if (gvRegionSamplesIRI.Rows[i].Cells[4].Text == "&nbsp;")
                        gvRegionSamplesIRI.Rows[i].Cells[4].Text = "0";

                    int value = int.Parse(gvRegionSamplesIRI.Rows[i].Cells[4].Text) - int.Parse(gvRegionSamplesIRI.Rows[i].Cells[1].Text);
                    gvRegionSamplesIRI.Rows[i].Cells[4].Text = value.ToString();
                    if (value > 0)
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Green;
                    else
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Yellow;

                }
                if (gvRegionSamplesIRI.Rows[i].Cells[1].Text == gvRegionSamplesIRI.Rows[i].Cells[4].Text && (gvRegionSamplesIRI.Rows[i].BackColor != System.Drawing.Color.Green || gvRegionSamplesIRI.Rows[i].BackColor != System.Drawing.Color.Yellow))
                    gvRegionSamplesIRI.Rows[i].Cells[4].Text = string.Empty;
            }
        }

        gvRegionSamplesSECTION.DataSource = dtSection;
        gvRegionSamplesSECTION.DataBind();

        ViewState["gvRegionSamplesSECTION"] = gvRegionSamplesSECTION.DataSource;
        ViewState["gvRegionSamplesIRI"] = gvRegionSamplesIRI.DataSource;
        ViewState["sortdrIRI"] = "Asc";
        ViewState["sortdr"] = "Asc";
    }
    protected void gvRegionSamplesIRI_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamplesIRI"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdrIRI"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdrIRI"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdrIRI"] = "Asc";
            }

            gvRegionSamplesIRI.DataSource = dtrslt;
            gvRegionSamplesIRI.DataBind();
            for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
            {
                if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (gvRegionSamplesIRI.Rows[i].Cells[1].Text != gvRegionSamplesIRI.Rows[i].Cells[4].Text)
                    {
                        int value = int.Parse(gvRegionSamplesIRI.Rows[i].Cells[4].Text) - int.Parse(gvRegionSamplesIRI.Rows[i].Cells[1].Text);
                        gvRegionSamplesIRI.Rows[i].Cells[4].Text = value.ToString();
                        if (value > 0)
                            gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Green;
                        else
                            gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Yellow;

                    }
                    if (gvRegionSamplesIRI.Rows[i].Cells[1].Text == gvRegionSamplesIRI.Rows[i].Cells[4].Text && (gvRegionSamplesIRI.Rows[i].BackColor != System.Drawing.Color.Green || gvRegionSamplesIRI.Rows[i].BackColor != System.Drawing.Color.Yellow))
                        gvRegionSamplesIRI.Rows[i].Cells[4].Text = string.Empty;
                }
            }
        }
    }
}