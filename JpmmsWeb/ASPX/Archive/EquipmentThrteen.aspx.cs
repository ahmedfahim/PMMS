using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentThrteen : System.Web.UI.Page
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
            HeaderCell.Text = "        العدد         ";
            HeaderCell.Text += new JpmmsClasses.BL.MainStreet().LenghthRowDataMFV().Rows[0][0];
            HeaderCell.Text += "       الطول        ";
            HeaderCell.Text += new JpmmsClasses.BL.MainStreet().LenghthRowDataMFV().Rows[1][0];
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamples.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamples.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
       
    }
}