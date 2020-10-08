using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Security_LoginWorkOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            txtUserName.Focus();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        lblError.Text = "";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (DrpDwnListWork.SelectedValue == "-1")
            {
                lblError.Text = "";
                UserLogonDetails user = new SystemUsers().Login(txtUserName.Text, txtPassword.Text);
                if (user.UserID == 0)
                    lblError.Text = "بيانات الدخول غير صحيحة!";
                else
                {
                    Session["UserID"] = user.UserID;
                    Session["UserName"] = user.UserName;
                    Session["Permissions"] = user.Permissions;
                    Session["Login_Date"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    Session["Admin"] = user.IsAdmin.ToString();
                    Session["canEdit"] = user.CanEdit.ToString();
                    Session["ViewWorkOrder"] = false;
                    Session["lang"] = "ar-AE";

                    Shared.SaveLogfile("SYSTEM_USERS", user.UserID.ToString(), "User login", Session["UserName"].ToString());
                    Response.Redirect("~/aspx/home/Default.aspx", false);
                }
            }
            else
            {
                lblError.Text = "";
                UserLogonWorkOrdersDetails user = new SystemUsers().LoginWorkOrders(txtUserName.Text, txtPassword.Text);
                if (user.UserID == 0)
                    lblError.Text = "بيانات الدخول غير صحيحة!";
                else
                {
                    Session["UserID"] = user.UserID;
                    Session["UserName"] = user.UserName;
                    Session["Login_Date"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    Session["ViewWorkOrder"] = user.CanView.ToString();
                    Session["canEdit"] = user.CanEdit.ToString();
                    Session["IS_CONTRACTOR"] = user.IS_CONSULTANT.ToString();
                    Session["IS_CONSULTANT"] = user.IS_CONSULTANT.ToString();
                    Session["IS_PROJECTMANJER"] = user.IS_PROJECTMANJER.ToString();
                    Session["IS_DIRECTORMANGER"] = user.IS_DIRECTORMANGER.ToString();
                    Session["IS_SERVICESAVAILABLE"] = user.IS_SERVICESAVAILABLE.ToString();
                    Session["IS_GENERALDIRECTORMANGER"] = user.IS_GENERALDIRECTORMANGER.ToString();
                    Session["lang"] = "ar-AE";
                    Shared.SaveLogfile("SYSTEM_USERS_WORK", user.UserID.ToString(), "User login", Session["UserName"].ToString());
                    Response.Redirect("~/aspx/home/DefaultWorkOrders.aspx", false);
                }
               
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


   
}