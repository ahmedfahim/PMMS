using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Lookups;
using Oracle.DataAccess.Client;

public partial class ASPX_Security_Login : System.Web.UI.Page
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
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void radArabic_CheckedChanged(object sender, EventArgs e)
    {
        Session["lang"] = "ar";
    }

    protected void radEnglish_CheckedChanged(object sender, EventArgs e)
    {
        Session["lang"] = "en";
    }

    protected void lnkReports_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            UserLogonDetails user = new SystemUsers().GetReportsUser();
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

                Shared.SaveLogfile("SYSTEM_USERS", user.UserID.ToString(), "User login", Session["UserName"].ToString());
                Response.Redirect("~/aspx/home/DefaultReports.aspx", false);
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void lnkData_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            UserLogonDetails user = new SystemUsers().GetDataBrowsingUser();
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

                Shared.SaveLogfile("SYSTEM_USERS", user.UserID.ToString(), "User login", Session["UserName"].ToString());
                Response.Redirect("~/aspx/home/Default.aspx", false);
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

}