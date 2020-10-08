using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_CompletedASSETES : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 1)
            {
                DropDownList1.Visible = false;
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().FinalCompareASSETS();
                Label1.Text = " عدد الشوارع "+ dt.Compute("Count(main_no)", string.Empty).ToString();
                gvASSETES.DataSource = dt;
                gvASSETES.DataBind();

            }
            else
            {
                Label1.Text = "المستخلص رقم";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().FinalCompareASSETS(null);
                gvASSETES.DataSource = dt;
                gvASSETES.DataBind();
                CompareDiffr(gvASSETES);
            }
                ViewState["gvASSETES"] = gvASSETES.DataSource;
                ViewState["sortdrDetials"] = "Asc";
        }
    }

    private void CompareDiffr(GridView gvRegionSamples)
    {
        for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
        {
            if (gvRegionSamples.Rows[i].Cells[3].Text != gvRegionSamples.Rows[i].Cells[4].Text)
            {
                int valueSYS = gvRegionSamples.Rows[i].Cells[3].Text == "&nbsp;" ? 0 : int.Parse(gvRegionSamples.Rows[i].Cells[3].Text);
                int valueEqipment = gvRegionSamples.Rows[i].Cells[4].Text == "&nbsp;" ? 0 : int.Parse(gvRegionSamples.Rows[i].Cells[4].Text);

                if (valueEqipment != valueSYS)
                    gvRegionSamples.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
            }
            else
                gvRegionSamples.Rows[i].Visible = false;
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "-1")
        {
            gvASSETES.DataSource = new JpmmsClasses.BL.MainStreet().FinalCompareASSETS(DropDownList1.SelectedValue);
            gvASSETES.DataBind();
            CompareDiffr(gvASSETES);
        }
    }
    protected void gvASSETES_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvASSETES"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdrDetials"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdrDetials"] = "Asc";
            }
            gvASSETES.DataSource = dtrslt;
            gvASSETES.DataBind();
        }
    }
}