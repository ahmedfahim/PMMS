using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_AddContractorMini : System.Web.UI.UserControl
{
    public delegate void ContractorAdded(); //int contractorID, string contractorName);
    public event ContractorAdded OnContractorAdded;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void InsertCancelButton_Click(object sender, EventArgs e)
    {
        this.Visible = false;
    }

    protected void odsContractor_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception == null)
        {
            int contractorID = int.Parse(e.ReturnValue.ToString());
            string contractorName = ((TextBox)FormView1.FindControl("CONTRACTOR_NAMETextBox")).Text;

            OnContractorAdded(); //contractorID, contractorName);
            this.Visible = false;
        }
        else
        {
            e.ExceptionHandled = true;
        }
    }

    public void Display()
    {
        FormView1.DataBind();
        this.Visible = true;
    }

    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

}
