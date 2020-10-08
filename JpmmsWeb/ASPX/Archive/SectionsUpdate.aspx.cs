using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SectionsUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void BtnNewSections_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "46" || Session["UserID"].ToString() == "54" || Session["UserID"].ToString() == "60")
        {
            System.Data.DataTable dtErorrUpdate = new JpmmsClasses.BL.MainStreet().CheckUpdateSectionsInfo();
            if (dtErorrUpdate != null && dtErorrUpdate.Rows.Count == 0)
            {
                if (new JpmmsClasses.BL.MainStreet().UpdateSectionsInfo(true))
                    lblFeedback.Text = Feedback.UpdateSuccessfull();
                else
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();
            }
            else
            {
                lblFeedback.Text = "بيانات مقاطع مكررة خطأ ";
                gvRegionSamplesErorr.DataSource = dtErorrUpdate;
                gvRegionSamplesErorr.DataBind();

            }
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}