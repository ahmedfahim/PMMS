using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Operations_TrafficEnhances_TrafficEnhances : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
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


            bool saved = new TrafficEnhances().Insert(PROPOSE_TITLETextBox.Text, ucProposeDate.SelectedGregDate, ddlLetterFrom.SelectedValue, ucLetterDate.SelectedGregDate,
                LETTER_NOTextBox.Text, COMMITTE_HEAD_NAMETextBox.Text, NOTESTextBox.Text, ddlMunic.SelectedValue, ucProposeDate.SelectedHijriDate, ucLetterDate.SelectedHijriDate);

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
        Response.Redirect("TrafficEnhances.aspx", false);
    }

}