using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_EquipmentSix : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1)
            {
                ddlRegions.Visible = false;
                lblFeedback.Text = string.Empty;
                gvRegionSamplesIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsSampleNotFoundIRI();
                gvRegionSamplesIRI.DataBind();

            }
        }

    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegions.SelectedValue != "0")
        {
            lblFeedback.Text = string.Empty;
            DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsIRI();
            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString()));
            RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
            RadioButtonList1.DataBind();

            gvRegionSamplesIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsSampleNotFoundIRI(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
            gvRegionSamplesIRI.DataBind();

            if (gvRegionSamplesIRI.Rows.Count > 0)
            {
                lblFeedback0.Text = string.Empty;
                gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
                gvRegionIRI.DataBind();
            }
            else
            {
                lblFeedback0.Text = Feedback.NoData();
                gvRegionIRI.DataSource = null;
                gvRegionIRI.DataBind();
            }
            
        }
    }
    protected void gvRegionSamplesIRI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من معدة استوائيه رصف الطريق";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamplesIRI.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamplesIRI.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
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

        }
    }

}