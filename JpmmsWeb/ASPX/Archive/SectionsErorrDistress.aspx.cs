using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SectionsErorrDistress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "DDF")
            {
                Label1.Text = "البيانات من العيوب";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrDistressDDF();
                gvERorrDistress.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "FWD")
            {
                Label1.Text = "البيانات من الحمل الساقط";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrDistressFWD();
                gvERorrDistress.DataBind();

            }
            else if (Request.QueryString[0].ToString() == "GPR")
            {
                Label1.Text = "البيانات من سماكات الطبقات";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrDistressGPR();
                gvERorrDistress.DataBind();

            }
            else if (Request.QueryString[0].ToString() == "SKID")
            {
                Label1.Text = "البيانات من مقاومة الإنزلاق";
                gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().GetSectionsErorrDistressSKID();
                gvERorrDistress.DataBind();

            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }

    }
    protected void gvERorrDistress_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            if (Request.QueryString[0].ToString() == "DDF")
                HeaderCell.Text = "البيانات من العيوب";
            else if (Request.QueryString[0].ToString() == "FWD")
                HeaderCell.Text = "البيانات من الحمل الساقط";
            else if (Request.QueryString[0].ToString() == "GPR")
                HeaderCell.Text = "البيانات من سماكات الطبقات";
            else if (Request.QueryString[0].ToString() == "SKID")
                HeaderCell.Text = "البيانات من مقاومة الإنزلاق";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvERorrDistress.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvERorrDistress.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
  
}