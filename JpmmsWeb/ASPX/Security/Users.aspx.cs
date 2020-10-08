using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Security_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[6] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void odsLabUsers_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.DeleteSuccessfull();
            gvUsers.SelectedIndex = -1;
            gvUsers_SelectedIndexChanged(sender, e);
        }
    }

    protected void odsLabUsers_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.InsertSuccessfull();
    }

    protected void odsLabUsers_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void btnSavePermissions_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (gvUsers.SelectedValue != null)
            {
                string permissions = "";

                permissions += chkGeneralInfo.Checked ? "1" : "0";
                permissions += chkDistresses.Checked ? "1" : "0";

                permissions += chkUDI.Checked ? "1" : "0";
                permissions += chkMaintDecisions.Checked ? "1" : "0";
                permissions += chkMaintPrio.Checked ? "1" : "0";

                permissions += chkSurveyingInfo.Checked ? "1" : "0";
                permissions += chkSystemAdmin.Checked ? "1" : "0";
                permissions += chkReports.Checked ? "1" : "0";
                permissions += chkOperations.Checked ? "1" : "0";


                bool saved = new SystemUsers().UpdateUserPermissions(permissions, int.Parse(gvUsers.SelectedValue.ToString()));
                lblFeedback.Text = saved ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelPermissions_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        pnlUserDetails.Visible = false;
        gvUsers.SelectedIndex = -1;
    }

    protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (gvUsers.SelectedValue != null)
            {
                string permissions = SystemUsers.GetUserPermissions(int.Parse(gvUsers.SelectedValue.ToString()));
                if (string.IsNullOrEmpty(permissions) || permissions.Length < 6)
                    lblFeedback.Text = Feedback.NoData();
                else
                {
                    // parse permissions
                    chkGeneralInfo.Checked = (permissions[0] == '1');
                    chkDistresses.Checked = (permissions[1] == '1');

                    chkUDI.Checked = (permissions[2] == '1');
                    chkMaintDecisions.Checked = (permissions[3] == '1');
                    chkMaintPrio.Checked = (permissions[4] == '1');

                    chkSurveyingInfo.Checked = (permissions[5] == '1');
                    chkSystemAdmin.Checked = (permissions[6] == '1');

                    chkReports.Checked = (permissions[7] == '1');
                    chkOperations.Checked = (permissions[8] == '1');
                }
            }

            pnlUserDetails.Visible = (gvUsers.SelectedValue != null);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = new SystemUsers().ChangeUserPassword(txtChangeUserPassword.Text, txtChangeUserPasswordConfirm.Text, int.Parse(gvUsers.SelectedValue.ToString()));
            lblFeedback.Text = saved ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}