using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_UpdateIRIValidate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            gvERorrDistress.DataSource = new JpmmsClasses.BL.MainStreet().ValidateUpdateDistress();
            gvERorrDistress.DataBind();
            gvERorrIRI.DataSource = new JpmmsClasses.BL.MainStreet().ValidateUpdateIRI();
            gvERorrIRI.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "55")
        {
            if (AreTablesTheSame((DataTable)gvERorrIRI.DataSource, (DataTable)gvERorrDistress.DataSource))
                lblFeedback.Text = "يجب اصلاح العيوب اولا";
            else if (new JpmmsClasses.BL.MainStreet().ValidateUpdateInsertIRI())
            {
                gvERorrIRI.DataBind();
                lblFeedback.Text = Feedback.UpdateSuccessfull();
            }
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnIRI_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "55")
        {
            if (AreTablesTheSame((DataTable)gvERorrIRI.DataSource, (DataTable)gvERorrDistress.DataSource))
                lblFeedback.Text = "يجب اصلاح العيوب اولا";
            else if (new JpmmsClasses.BL.MainStreet().Finshed_UpdateIRIValid())
            {
                gvERorrIRI.DataBind();
                lblFeedback.Text = Feedback.UpdateSuccessfull();
            }
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }


    public  bool AreTablesTheSame(DataTable tbl1, DataTable tbl2)
    {
        if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
            return false;
        for (int i = 0; i < tbl1.Rows.Count; i++)
        {
            for (int c = 0; c < tbl1.Columns.Count; c++)
            {
                if (!Equals(tbl1.Rows[i][c], tbl2.Rows[i][c]))
                    return false;
            }
        }
        return true;
    }
   
}