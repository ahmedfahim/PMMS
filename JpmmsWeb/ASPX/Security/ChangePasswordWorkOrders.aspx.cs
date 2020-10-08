using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Security_ChangePasswordWorkOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null || Session["Permissions"] == null)
            Response.Redirect("~/aspx/home/Logout.aspx", false);

        if (!IsPostBack && Session["UserName"] != null)
            lblUserName.Text = Session["UserName"].ToString();
    }

    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = new SystemUsers().ChangeUserPassword(txtOldPassword.Text, txtnewPassword.Text, txtPasswordConfirm.Text, int.Parse(Session["UserID"].ToString()));
            lblFeedback.Text = saved ? "تم تغيير كلمة السر." : Feedback.UpdateException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        txtOldPassword.Text = "";
        txtnewPassword.Text = "";
        txtPasswordConfirm.Text = "";
    }
}