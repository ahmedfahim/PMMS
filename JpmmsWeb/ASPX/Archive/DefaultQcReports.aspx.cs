using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_DefaultQcReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (!IsPostBack && Request.QueryString.Count == 1)
            {
                GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().SelectAREAReportsQC("0", null);
                RadioButtonList1.Items[0].Selected = false;
                GridView1.DataBind();
            }
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        bool select = (DropDownList2.SelectedValue == "0" || DropDownList2.SelectedValue == "-1") && Request.QueryString.Count == 1;
        GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().SelectAREAReportsQC(select ? "0" : DropDownList2.SelectedValue, RadioButtonList1.SelectedValue);
        GridView1.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue != "0" || DropDownList2.SelectedValue != "-1")
        {
            if (Request.QueryString.Count == 1)
                Request.QueryString[0].Remove(0);
            if (string.IsNullOrEmpty(RadioButtonList1.SelectedValue))
                RadioButtonList1.Items[0].Selected = true;
        }
        GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().SelectAREAReportsQC(DropDownList2.SelectedValue, RadioButtonList1.SelectedValue);
        GridView1.DataBind();
    }
}