using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_InterSectionsMissing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1' )
            Response.Redirect("~/ASPX/Default.aspx", false);
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 1)
            {
                Label1.Text = "تقاطعات تم استلامها";
                DataTable dt = new JpmmsClasses.BL.MainStreet().GetInterSectionsComplete();
                DataTable distinctValues = new DataView(dt).ToTable(true, dt.Columns[1].ColumnName, dt.Columns[2].ColumnName);
                DropDownList1.DataSource = distinctValues;
                DropDownList1.DataTextField = dt.Columns[2].ColumnName;
                DropDownList1.DataValueField = dt.Columns[1].ColumnName;
                DropDownList1.DataBind();
                gvRegionSamplesEqupment.DataSource = dt;
                gvRegionSamplesEqupment.DataBind();
            }
            else
            {
                Label1.Text = "تقاطعات تحتاج استلام";
                DataTable dt = new JpmmsClasses.BL.MainStreet().GetInterSectionsMissing();
                DataTable distinctValues = new DataView(dt).ToTable(true, dt.Columns[1].ColumnName, dt.Columns[2].ColumnName);
                DropDownList1.DataSource = distinctValues;
                DropDownList1.DataTextField = dt.Columns[2].ColumnName;
                DropDownList1.DataValueField = dt.Columns[1].ColumnName;
                DropDownList1.DataBind();
                gvRegionSamplesEqupment.DataSource = dt;
                gvRegionSamplesEqupment.DataBind();
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1)
        {
            if (DropDownList1.SelectedValue == "0")
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().GetInterSectionsComplete();
            else
                if (DropDownList1.SelectedValue != "-1")
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().GetInterSectionsComplete(DropDownList1.SelectedValue);
        }
        else
        {
            if (DropDownList1.SelectedValue == "0")
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().GetInterSectionsMissing();
            else
                if (DropDownList1.SelectedValue != "-1")
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().GetInterSectionsMissing(DropDownList1.SelectedValue);
        }
        
        lblFeedback.Text = string.Empty;
        gvRegionSamplesEqupment.DataBind();
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "37" || Session["UserID"].ToString() == "60")
        {
            if (new JpmmsClasses.BL.Intersection().UpdateInterSectionsArname())
                lblFeedback.Text = "تم إلغاء التكرار";
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
            lblFeedback.Text = Feedback.NoPermissions();

    }
}