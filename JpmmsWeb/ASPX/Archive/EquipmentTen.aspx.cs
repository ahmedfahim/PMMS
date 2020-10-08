using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Archive_EquipmentTen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1)
            {
                RadioButtonList1.Visible = false;
                ddlRegions.Visible = false;
                lblFeedback.Text = string.Empty;
                if (Request.QueryString[0].ToString() == "SYS")
                {
                    RadioBtnListSYS.SelectedValue = "2";
                    gvERorrLanes.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanes();
                    gvERorrLanes.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "IRI")
                {
                    RadioBtnListSYS.SelectedValue = "1";
                    gvERorrLanesIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanesIRI(null);
                    gvERorrLanesIRI.DataBind();
                }
                
            }
        }
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegions.SelectedValue != "0")
        {
            RadioBtnListSYS_SelectedIndexChanged(null, null);
        }
        
    }
    protected void RadioBtnListSYS_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegions.SelectedValue != "0")
        {
            System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsIRI();
            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString()));
            RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
            RadioButtonList1.DataBind();

            if (RadioBtnListSYS.SelectedValue == "1")
            {
                gvERorrLanes.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanesIRI(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
                gvERorrLanes.DataBind();

                if (gvERorrLanes.Rows.Count > 0)
                    lblFeedback.Text = string.Empty;
                else
                    lblFeedback.Text = Feedback.NoData();

            }
            else
            {
                gvERorrLanes.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanes(ddlRegions.SelectedItem.Text);
                gvERorrLanes.DataBind();

                if (gvERorrLanes.Rows.Count > 0)
                    lblFeedback.Text = string.Empty;
                else
                    lblFeedback.Text = Feedback.NoData();

            }
        }
    }
}