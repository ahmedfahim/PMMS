using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Reports_AssetsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
   
    protected void btnShowReport_Click(object sender, EventArgs e)
    { 
        //DataTable dt = new MainStreet().GetAssets("0013");
        DataSet ds = new MainStreet().GetAssetsTotal(ddlMainStreets.SelectedItem.Text,RadioButtonList1.SelectedValue);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Session.Add("option", "radByMainLanes");
            Session.Add("ReportDataDs", ds);
            string url = "ViewAssets.aspx";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);
        }
        else
            lblFeedback.Text = Feedback.NoData();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void radByMainLanes_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void radByAllLanes_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void ddlMainStreets_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        DataTable dtx = new JpmmsClasses.BL.MainStreet().GetStreetsAssets();
        RadioButtonList1.Items.Clear();
        RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dtx.Rows[ddlMainStreets.SelectedIndex - 1][3].ToString()));
        RadioButtonList1.SelectedValue = dtx.Rows[ddlMainStreets.SelectedIndex - 1][2].ToString();
        RadioButtonList1.DataBind();
    }
   
}