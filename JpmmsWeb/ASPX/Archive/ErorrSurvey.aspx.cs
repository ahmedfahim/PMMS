using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_ErorrSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "FWD")
            {
                Label1.Text = "الحمل الساقط";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoFWD();
                lblTotal.Text = " عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "GPR")
            {
                Label1.Text = "سماكات الطبقات";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoGPR();
                lblTotal.Text = " عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "SKID")
            {
                Label1.Text = "مقاومة الإنزلاق";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoSKID();
                lblTotal.Text = "  عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "ASSETES")
            {
                Label1.Text = "أصول الطرق  الرئيسية";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoASSETS();
                lblTotal.Text = "  عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "IRIDDF")
            {
                //LinkErorrSurvey.NavigateUrl += "IRIDDF";
                //Label1.Text = "الوعورة - العيوب";
                //System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().();
                //lblTotal.Text = " عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
        
                //gvErorr.DataSource = dt;
                //gvErorr.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }
}