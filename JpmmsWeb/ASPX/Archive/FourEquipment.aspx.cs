using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_FourEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString() == "49" || Session["UserID"].ToString() == "55")
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
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnNewSections_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "49" || Session["UserID"].ToString() == "55")
        {
           if (new JpmmsClasses.BL.MainStreet().UpdateSectionsInfo(true))
                lblFeedback.Text = Feedback.UpdateSuccessfull();
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void gvRegionSamples_DataBound(object sender, EventArgs e)
    {
        if (gvRegionSamples.Rows.Count > 0)
            BtnNewSections.Visible = true;
        else
            BtnNewSections.Visible = false;
    }
}