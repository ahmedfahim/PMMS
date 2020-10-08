using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_IntersectionsReady : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1' || Request.QueryString.Count == 0)
            Response.Redirect("~/ASPX/Default.aspx", false);
        if(!IsPostBack)
        {
            if (Request.QueryString.Count == 1)
            {
                System.Data.DataTable dt;
                if (Request.QueryString[0].ToString() == "0")
                {
                    Label1.Text = "تقاطعات تحتاج مراجعة الادخال";
                    dt = new JpmmsClasses.BL.MainStreet().ApproveInterSections(false);
                    lblFeedback.Text = "الطول الكلي تقاطعات تحتاج مراجعة للإدخال " + dt.Compute("Sum(TOTALLENGTH)", string.Empty).ToString();
                    gvRegionSamplesEqupment.DataSource = dt;
                    gvRegionSamplesEqupment.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "1")
                {
                    Label1.Text = "تقاطعات جاهزة للإدخال";
                    dt = new JpmmsClasses.BL.MainStreet().ApproveInterSections(true);
                    lblFeedback.Text = "الطول الكلي تقاطعات جاهزة للإدخال " + dt.Compute("Sum(TOTALLENGTH)", string.Empty).ToString();
                    gvRegionSamplesEqupment.DataSource = dt;
                    gvRegionSamplesEqupment.DataBind();
                }
                else
                    Response.Redirect("~/ASPX/Default.aspx", false);
            }
        }
    }
   
    protected void gvRegionSamplesEqupment_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView1.DataSource = new JpmmsClasses.BL.MainStreet().ApproveInterSections(gvRegionSamplesEqupment.Rows[e.NewSelectedIndex].Cells[1].Text);
        GridView1.DataBind();

    }
    protected void gvRegionSamplesEqupment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
        {
            if (new JpmmsClasses.BL.MainStreet().SelectInterSectionsReady(gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[1].Text, gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[3].Text, gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[5].Text))
            {
                if (new JpmmsClasses.BL.MainStreet().UpdateInterSectionsReady(gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[1].Text, gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[3].Text
                     , gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[4].Text, gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[5].Text, gvRegionSamplesEqupment.Rows[e.RowIndex].Cells[7].Text))
                {
                    lblFeedback.Text = "تم اعتماد الشارع بنجاح";
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().ApproveInterSections(Request.QueryString[0].ToString() == "1" ? true : false);
                    gvRegionSamplesEqupment.DataBind();
                }
                else
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();

            }
            else
            {
                lblFeedback.Text = "يجب اتمام المراجعة لجميع مقاطع الشارع";
                e.Cancel = true;
            }
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }

   
}