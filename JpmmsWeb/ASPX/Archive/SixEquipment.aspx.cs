using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SixEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            int ErorrData = new JpmmsClasses.BL.MainStreet().ValidateUpdateIRI().Rows.Count;
            if (ErorrData > 0)
            {
                spanErorrData.Visible = true;
                spanErorrData.InnerText = ErorrData.ToString();
            }
            else
            {
                spanErorrData.Visible = false;
                spanErorrData.InnerText = string.Empty;
            }
        }

    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString() == "55")
        {
            CheckBox CHK_Enterd = gvRegionSamples.Rows[e.RowIndex].Cells[2].Controls[0] as CheckBox;
            CheckBox CHK_System = gvRegionSamples.Rows[e.RowIndex].Cells[3].Controls[0] as CheckBox;
            CheckBox CHK_Return = gvRegionSamples.Rows[e.RowIndex].Cells[4].Controls[0] as CheckBox;
            if (CHK_System.Checked && CHK_Return.Checked)
            {
                e.Cancel = true;
                lblFeedback.Text = Feedback.DistressSelectedReturn();
            }
            //else if (CHK_System.Checked == false && CHK_Enterd.Checked)
            //{
            //    e.Cancel = true;
            //    lblFeedback.Text = Feedback.DistressSelectedNotEnterd();
            //}
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
  
}