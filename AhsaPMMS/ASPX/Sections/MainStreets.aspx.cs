using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Sections_MainStreets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void odsMainStreets_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
       
    }

    protected void gvMainSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        //frvMainStEdit.DataBind();
        if (ddlMainSt.SelectedValue != "0")
        {
            DataTable dt = new MainStreet().GetByID(int.Parse(ddlMainSt.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lblMainNo.Text = dr["MAIN_NO"].ToString();
                MAIN_NAMETextBox.Text = dr["MAIN_NAME"].ToString();
                MAIN_EN_NAMETextBox.Text = dr["MAIN_EN_NAME"].ToString();
                txtDetails.Text = dr["OWNERSHIP_DETAILS"].ToString();
                txtOfficialNum.Text = dr["OFFICIAL_MUNIC_NUM"].ToString();

                ddlCategories.SelectedValue = dr["MAINST_CATEGORY_ID"].ToString();
                ddlContractors.SelectedValue = dr["CONTRACTOR_ID"].ToString();

                radFully.Checked = bool.Parse(dr["FULLY_MUNIC_OWNED"].ToString());
                radPartially.Checked = bool.Parse(dr["PARTIALLY_MUNIC_OWNED"].ToString());
                radNot.Checked = bool.Parse(dr["NOT_MUNIC_OWNED"].ToString());
                chkIntersectSamples.Checked = bool.Parse(dr["ALL_INTERSAMP_OWNED_MUNIC"].ToString());
                chkIsR4.Checked = bool.Parse(dr["IS_R4"].ToString());

                pnlEdit.Visible = true;
            }
            else
                pnlEdit.Visible = false;
        }
        else
            pnlEdit.Visible = false;
    }

    protected void OnOnContractorAdded() 
    {
        try
        {
            ddlContractors.Items.Clear();
            ddlContractors.Items.Add(new ListItem("اختيار", "0"));
            ddlContractors.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void odsMainStreetInfoEdit_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //string lang = ;
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            try
            {
                lblFeedback.Text = Feedback.UpdateSuccessfull();
                ddlMainSt.Items.Clear();
                ddlMainSt.Items.Add(new ListItem("اختيار", "0"));
                ddlMainSt.DataBind();
                //frvMainStEdit.DataBind();
                //gvMainSt.DataBind();

            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }
    }

    protected void frvMainStEdit_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void ddlMainSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvMainSt_SelectedIndexChanged(sender, e);
    }

    protected void btnAddContractor_Click(object sender, EventArgs e)
    {
        AddContractorMini1.Display();
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = new MainStreet().Update(MAIN_NAMETextBox.Text, MAIN_EN_NAMETextBox.Text, int.Parse(ddlContractors.SelectedValue), chkIsR4.Checked, radFully.Checked,
                radPartially.Checked, radNot.Checked, txtDetails.Text, int.Parse(ddlCategories.SelectedValue), lblMainNo.Text, chkIntersectSamples.Checked,
                int.Parse(ddlMainSt.SelectedValue), txtOfficialNum.Text);

            if (saved)
            {
                lblFeedback.Text = Feedback.UpdateSuccessfull();
                pnlEdit.Visible = false;

                ddlMainSt.Items.Clear();
                ddlMainSt.Items.Add(new ListItem("اختيار", "0"));
                ddlMainSt.DataBind();
            }
            else
                lblFeedback.Text = Feedback.UpdateException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        ddlMainSt_SelectedIndexChanged(sender, e);
    }

}