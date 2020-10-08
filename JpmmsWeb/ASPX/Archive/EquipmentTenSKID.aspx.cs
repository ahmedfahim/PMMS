using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentTenSKID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1)
            {
                gvERorrLanes.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanesSKID(null);
                gvERorrLanes.DataBind();
            }
        }
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvERorrLanes.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanesSKID(ddlRegions.SelectedItem.Text);
        gvERorrLanes.DataBind();

        if (gvERorrLanes.Rows.Count > 0)
            lblFeedback.Text = string.Empty;
        else
            lblFeedback.Text = Feedback.NoData();
    }
}