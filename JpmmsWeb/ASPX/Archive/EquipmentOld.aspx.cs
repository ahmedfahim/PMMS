using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_EquipmentOld : System.Web.UI.Page
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

        if (ddlRegions.SelectedValue != "0")
        {
            gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo((int.Parse(ddlRegions.SelectedValue)));
            gvRegionSections.DataBind();

            DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsNotIRI();
            RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
            RadioButtonList1.DataBind();

            DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSections(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSections(int.Parse(ddlRegions.SelectedValue));


            gvRegionSamplesSECTION.DataSource = dtSection;
            gvRegionSamplesSECTION.DataBind();

            ViewState["gvRegionSamplesSECTION"] = gvRegionSamplesSECTION.DataSource;

            ViewState["sortdr"] = "Asc";
        }
    }
    protected void gvRegionSamplesSECTION_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من النظام";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamplesSECTION.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamplesSECTION.Controls[0].Controls.AddAt(0, HeaderGridRow);

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

    
}