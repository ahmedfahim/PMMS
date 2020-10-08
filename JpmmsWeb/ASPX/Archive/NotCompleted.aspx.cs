using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_NotCompleted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (Request.QueryString.Count == 1)
        {
            if (Request.QueryString[0].ToString() == "FWD")
            {
                LinkErorrSurvey.NavigateUrl += "FWD";
                System.Data.DataTable dtErorr = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoFWD();
                if (dtErorr.Rows.Count > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = dtErorr.Rows.Count.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
                Label1.Text = "الحمل الساقط";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().FWD_NotComplete();
                lblTotal.Text = " عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                lblSum.Text = " نقط الشوارع " + dt.Compute("Sum(LENGTH)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "GPR")
            {
                LinkErorrSurvey.NavigateUrl += "GPR";
                System.Data.DataTable dtErorr = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoGPR();
                if (dtErorr.Rows.Count > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = dtErorr.Rows.Count.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
                Label1.Text = "سماكات الطبقات";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GPR_NotComplete();
                lblTotal.Text = " عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                lblSum.Text = " طول الشوارع " + dt.Compute("Sum(LENGTH)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "SKID")
            {
                LinkErorrSurvey.NavigateUrl += "SKID";
                System.Data.DataTable dtErorr = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoSKID();
                if (dtErorr.Rows.Count > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = dtErorr.Rows.Count.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
                Label1.Text = "مقاومة الإنزلاق";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().SKID_NotComplete();
                lblTotal.Text = " اجمالي عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                lblSum.Text = " طول الشوارع " + dt.Compute("Sum(LENGTH)", string.Empty).ToString();
                gvErorr.DataSource = dt;
                gvErorr.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "ASSETES")
            {
                LinkErorrSurvey.NavigateUrl += "ASSETES";
                System.Data.DataTable dtErorr = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoASSETS();
                if (dtErorr.Rows.Count > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = dtErorr.Rows.Count.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
                Label1.Text = "أصول الطرق  الرئيسية";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().ASSETES_NotComplete();
                lblTotal.Text = " اجمالي عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                lblSum.Text = " طول الشوارع " + dt.Compute("Sum(LENGTH)", string.Empty).ToString();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "IRIDDF")
            {
                LinkErorrSurvey.NavigateUrl += "IRIDDF";
                System.Data.DataTable dtErorr = new JpmmsClasses.BL.MainStreet().ErorrSuerveyNoIRIDDF();
                if (dtErorr.Rows.Count > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = dtErorr.Rows.Count.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
                Label1.Text = "الوعورة - العيوب";
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().IRIDDF_NotComplete(null);
                lblTotal.Text = " اجمالي عدد الشوارع " + dt.Compute("Count(MAIN_NO)", string.Empty).ToString();
                lblSum.Text = " طول الشوارع " + dt.Compute("Sum(LENGTH)", string.Empty).ToString();
                gvErorrIRIDDF.DataSource = dt;
                gvErorrIRIDDF.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }
}