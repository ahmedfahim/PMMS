using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;

public partial class ASCX_AddContractMini : System.Web.UI.UserControl
{
    public delegate void ContractAdded(); 
    public event ContractAdded OnContractAdded;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool DataAreValid()
    {
        if (string.IsNullOrEmpty(CONTRACT_NOTextBox.Text))
        {
            CONTRACT_NOTextBox.Focus();
            throw new Exception("الرجاء إدخال رقم العقد");
        }
        else if (string.IsNullOrEmpty(CONTRACT_NAMETextBox.Text))
        {
            CONTRACT_NAMETextBox.Focus();
            throw new Exception("الرجاء إدخال اسم العقد");
        }
        else if (ddlContractors.SelectedValue == "0")
        {
            ddlContractors.Focus();
            throw new Exception("الرجاء اختيار المقاول");
        }
        else if (raddtpBegin.SelectedDate == null)
        {
            raddtpBegin.Focus();
            throw new Exception("الرجاء إدخال تاريخ العقد");
        }
        else if (raddtpWorkBegin.SelectedDate == null)
        {
            raddtpWorkBegin.Focus();
            throw new Exception("الرجاء إدخال تاريخ بدء التنفيذ");
        }
        else if (raddtpEnd.SelectedDate == null)
        {
            raddtpEnd.Focus();
            throw new Exception("الرجاء إدخال تاريخ الانتهاء");
        }
        else if (raddtpEnd.SelectedDate < raddtpWorkBegin.SelectedDate)
        {
            raddtpEnd.Focus();
            throw new Exception("تاريخ الانتهاء لايمكن ان يكون قبل تاريخ بدء التنفيذ");
        }
        else
            return true;
    }


    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        this.Visible = false;
    }

    protected void btnAddContract_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (!DataAreValid())
                return;


            bool saved = new Contract().Insert(CONTRACT_NOTextBox.Text, CONTRACT_NAMETextBox.Text, raddtpBegin.SelectedDate, raddtpWorkBegin.SelectedDate, 
                raddtpEnd.SelectedDate, int.Parse(ddlContractors.SelectedValue));

            if (saved)
            {
                lblFeedback.Text = Feedback.InsertSuccessfull();
                OnContractAdded(); 
                this.Visible = false;
            }
            else
                lblFeedback.Text = Feedback.InsertException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

}