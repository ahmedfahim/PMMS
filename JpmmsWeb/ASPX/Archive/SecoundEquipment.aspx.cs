using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SecoundEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
       
    }

    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString()== "49")
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
                if (count == 2 && e.OldValues[4].ToString() == true.ToString())
                {
                    e.Cancel = false;
                    lblFeedback.Text = string.Empty;
                }
                else
                {
                    e.Cancel = true;
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();
                }
            }
            else if (e.OldValues[4].ToString() == true.ToString() )
            {
                e.Cancel = true;
                lblFeedback.Text = "لا يمكن حذف  اعاده تحليل";
            }
            
            
            
        }
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}