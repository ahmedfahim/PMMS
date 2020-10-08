using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_TwentyEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1 && Request.QueryString[0].ToString() == "DID")
        {
            BtnFinshed.Visible = false;
            if (new JpmmsClasses.BL.MainStreet().GetRecivedInsertDDF())
            {
                BtnFinshedMfv.Visible = true;
                gvRegionSamples.Columns[6].Visible = false;
            }
            else
                BtnFinshedMfv.Visible = false;
        }

    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString()== "48")
        {
            CheckBox CHK_Enterd = gvRegionSamples.Rows[e.RowIndex].Cells[3].Controls[0] as CheckBox;
            CheckBox CHK_System = gvRegionSamples.Rows[e.RowIndex].Cells[4].Controls[0] as CheckBox;
            CheckBox CHK_Return = gvRegionSamples.Rows[e.RowIndex].Cells[5].Controls[0] as CheckBox;
            if (CHK_System.Checked && CHK_Return.Checked)
            {
                e.Cancel = true;
                lblFeedback.Text = Feedback.DistressSelectedReturn();
            }
            else if (CHK_System.Checked == false && CHK_Enterd.Checked)
            {
                e.Cancel = true;
                lblFeedback.Text = Feedback.DistressSelectedNotEnterd();
            }
            else
            {
                lblFeedback.Text = string.Empty;
                int count = 0;
                for (int i = 0; i < e.NewValues.Count; i++)
                {
                    if (e.NewValues[i].ToString() == true.ToString())
                        count++;
                }
                if (count > 1)
                {
                    e.Cancel = true;
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();

                }
            }
        }
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void gvRegionSamples_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblFeedback.Text = string.Empty;
    }

    protected void BtnFinshed_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 0 && Session["UserID"].ToString() == "48")
        {
            if (new JpmmsClasses.BL.MainStreet().Finshed_UpdateEquipment())
                lblFeedback.Text = Feedback.StatusUpdateSuccessfull();
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnFinshedMfv_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1 && Session["UserID"].ToString() == "48" && Request.QueryString[0].ToString() == "DID")
        {
            System.Data.DataTable dtErorrInsert = new JpmmsClasses.BL.MainStreet().CheckErorrInsertDDF();
            if (dtErorrInsert != null && dtErorrInsert.Rows.Count == 0)
            {
                if (new JpmmsClasses.BL.MainStreet().FinalInsertDDF())
                {
                    lblFeedback.Text = Feedback.UpdateSuccessfull();
                    gvRegionSamples.DataBind();
                }
                else
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();
            }
            else
            {
                lblFeedback.Text = "بيانات مدخلة خطأ ";
                gvRegionSamplesErorr.DataSource = dtErorrInsert;
                gvRegionSamplesErorr.DataBind();

            }
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}