using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_InterSectionsDrawing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString() == "46" || Session["UserID"].ToString() == "58" || Session["UserID"].ToString() == "56" || Session["UserID"].ToString() == "54" || Session["UserID"].ToString() == "60")
        {
            lblFeedback.Text = string.Empty;
            int count = 0;
            for (int i = 0; i < e.NewValues.Count; i++)
            {
                if (e.NewValues[i].ToString() == true.ToString())
                    count++;
            }
            if (count == 1 && e.OldValues[7].ToString() == true.ToString())
            {
                e.Cancel = false;
                lblFeedback.Text = string.Empty;
            }
            else if (count > 1)
            {
                e.Cancel = true;
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
            }
        }
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sumAll = 0;
        foreach (GridViewRow row in gvRegionSamples.Rows)
        {
            CheckBox chk = row.Cells[2].Controls[0] as CheckBox;
            if (RadioButtonList1.SelectedValue == "-1")
            {
                row.Visible = true;
                sumAll++;
            }
            else if (RadioButtonList1.SelectedValue == "0")
            {
                if (chk != null && chk.Checked)
                {
                    row.Visible = true;
                    sumAll++;
                }
                else
                    row.Visible = false;
            }
            else if (RadioButtonList1.SelectedValue == "1")
            {
                if (chk != null && chk.Checked)
                    row.Visible = false;
                else
                {
                    row.Visible = true;
                    sumAll++;
                }
            }
        }
        lblFeedback.Text = " العدد الإجمالي " + sumAll;
    }
}