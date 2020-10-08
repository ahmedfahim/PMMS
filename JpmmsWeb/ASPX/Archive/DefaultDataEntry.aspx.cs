using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;
using System.Data;

public partial class ASPX_Archive_DefaultDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        try
        {
            PanelDetials.Visible = false;
            PanelALL.Visible = true;
            if (raddtpFrom.SelectedDate == null || raddtpTo.SelectedDate == null)
            {
                gvAll.DataSource = new SystemUsers().GetDataEntry(RadioButtonList1.SelectedValue);
            }
            else
            {
                gvAll.DataSource = new SystemUsers().GetDataEntry(RadioButtonList1.SelectedValue, raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
            }
            gvAll.DataBind();


            ViewState["gvAll"] = gvAll.DataSource;
            ViewState["sortdrAll"] = "Asc";
     

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
       
    }
    protected void btnDetials_Click(object sender, EventArgs e)
    {
        try
        { 
            PanelALL.Visible = false;
            PanelDetials.Visible = true;
            if (raddtpFrom.SelectedDate == null || raddtpTo.SelectedDate == null)
            {
                gvDetials.DataSource = new SystemUsers().GetDataEntryDetials(RadioButtonList1.SelectedValue);
            }
            else
            {
                gvDetials.DataSource = new SystemUsers().GetDataEntryDetials(RadioButtonList1.SelectedValue, raddtpFrom.SelectedDate, raddtpTo.SelectedDate);
            }
            gvDetials.DataBind();


            ViewState["gvDetials"] = gvDetials.DataSource;
            ViewState["sortdrDetials"] = "Asc";

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void gvDetials_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvDetials"];
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
            gvDetials.DataSource = dtrslt;
            gvDetials.DataBind();
        }
    }
    protected void gvAll_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvAll"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdrAll"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdrAll"] = "Asc";
            }
            gvAll.DataSource = dtrslt;
            gvAll.DataBind();
        }
    }
}