using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Operations_TrafficEnhances_EditTrafficEnhance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            Response.Redirect("SearchTrafficEnhances.aspx", false);

        try
        {
            if (!IsPostBack)
            {
                if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
                    Response.Redirect("~/ASPX/Default.aspx", false);

                // load data to edit
                DataTable dt = new TrafficEnhances().GetByID(int.Parse(Request.QueryString["ID"]));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    PROPOSE_TITLETextBox.Text = dr["PROPOSE_TITLE"].ToString();
                    ucProposeDate.SelectedGregDate = dr["APPROVE_DATE"].ToString();
                    ucProposeDate.SelectedHijriDate = dr["APPROVE_DATE_H"].ToString();

                    ddlMunic.SelectedValue = dr["MUNIC_NAME"].ToString();
                    ddlLetterFrom.SelectedValue = dr["LETTER_FROM"].ToString();

                    LETTER_NOTextBox.Text = dr["LETTER_NO"].ToString();
                    ucLetterDate.SelectedGregDate = dr["LETTER_DATE"].ToString();
                    ucLetterDate.SelectedHijriDate = dr["LETTER_DATE_H"].ToString();

                    COMMITTE_HEAD_NAMETextBox.Text = dr["COMMITTE_HEAD_NAME"].ToString();
                    NOTESTextBox.Text = dr["NOTES"].ToString();
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    private bool ValidateData()
    {
        if (string.IsNullOrEmpty(ucProposeDate.SelectedGregDate) || string.IsNullOrEmpty(ucProposeDate.SelectedHijriDate))
        {
            ucProposeDate.Focus();
            throw new Exception("الرجاء اختيار تاريخ اعتماد المقترح");
        }
        else if (string.IsNullOrEmpty(ucLetterDate.SelectedGregDate) || string.IsNullOrEmpty(ucLetterDate.SelectedHijriDate))
        {
            ucLetterDate.Focus();
            throw new Exception("الرجاء اختيار تاريخ ورود الخطاب");
        }
        else if (DateTime.Parse(ucProposeDate.SelectedGregDate) < DateTime.Parse(ucLetterDate.SelectedGregDate))
        {
            ucProposeDate.Focus();
            throw new Exception("تاريخ الاعتماد لايمكن أن يكون قبل تاريخ ورود الخطاب");
        }
        else
            return true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (!ValidateData())
                return;


            bool saved = new TrafficEnhances().Update(PROPOSE_TITLETextBox.Text, ucProposeDate.SelectedGregDate, ddlLetterFrom.SelectedValue, ucLetterDate.SelectedGregDate,
                LETTER_NOTextBox.Text, COMMITTE_HEAD_NAMETextBox.Text, NOTESTextBox.Text, ddlMunic.SelectedValue, ucProposeDate.SelectedHijriDate, ucLetterDate.SelectedHijriDate,
                int.Parse(Request.QueryString["ID"]));

            if (saved)
                Response.Redirect("SearchTrafficEnhances.aspx?msg=1", false);
            else
                lblFeedback.Text = Feedback.InsertException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string url = string.Format("EditTrafficEnhance.aspx?ID={0}", Request.QueryString["ID"]);
        Response.Redirect(url, false);
    }

}