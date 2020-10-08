using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SecondryNewStreets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "0")
            {
                Label1.Text = "شوارع جديدة تحتاج اكمال بيانتها";
                GridView2.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().SelectNewStreets();
                GridView2.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "1")
            {
                Label1.Text = "مناطق غير مطابقه انتاجية المسح بين المساحين والنظام";
                GridView1.DataSource = new JpmmsClasses.BL.Lookups.SystemUsers().SelectNewStreetsQC();
                GridView1.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }

    }
    protected void BtnNEW_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
        {
            if (new JpmmsClasses.BL.Lookups.SystemUsers().UpdateUDINewStreets())
            {
                lblFeedback.Text = "تم نقل الشوارع الجديده";
            }
            else lblFeedback.Text = "لا توجد شوارع جديدة";
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnALLStreets_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "60")
        {
            if (new JpmmsClasses.BL.MainStreet().UpdateStreetsMUNICDIST())
            {
                lblFeedback.Text = "تم تحديث كل الشوارع الفرعية";
            }
            else lblFeedback.Text = Feedback.NoData();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }

    }
}