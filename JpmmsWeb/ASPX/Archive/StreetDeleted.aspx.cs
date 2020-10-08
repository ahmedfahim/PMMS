using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_StreetDeleted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            gvERorrIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetDeleted();
            gvERorrIRI.DataBind();
        }
    }
    protected void BtnStreet_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() != "55")
            lblFeedback.Text = Feedback.NoPermissions();
        else
        {
            if (new JpmmsClasses.BL.MainStreet().DeleteNewStreets())
            {
                lblFeedback.Text = Feedback.StatusUpdateSuccessfull();
                gvERorrIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetDeleted();
                gvERorrIRI.DataBind();
            }
            else
                lblFeedback.Text = Feedback.NoData();
        }
    }
}