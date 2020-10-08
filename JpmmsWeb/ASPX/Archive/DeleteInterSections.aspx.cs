using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DeleteInterSections : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        BtnYes.Visible = false;
        BtnNO.Visible = false;
        if (ddlRegions.SelectedValue != "-1")
        {
            BoundInterSections();
        }
    }

    private void BoundInterSections()
    {
        ddlSections.Items.Clear();
        ddlSections.Items.Add(new ListItem("اختر التقاطع", "-1"));
        ddlSections.DataSource = new JpmmsClasses.BL.MainStreet().GetInterSections(ddlRegions.SelectedValue == "0" ? null : ddlRegions.SelectedValue);
        ddlSections.DataTextField = "INTER_NO";
        ddlSections.DataValueField = "INTERSECTION_ID";
        ddlSections.DataBind();
    }
    protected void BtnEND_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null && (Session["UserID"].ToString() == "46" || Session["UserID"].ToString() == "60"))
        {
            if (ddlSections.SelectedValue != "-1")
            {
                lblFeedback.Text = "هل انت متاكد سيتم حذف التقاطع ولن يمكنك التراجع";
                BtnYes.Visible = true;
                BtnNO.Visible = true;
            }
            else
                lblFeedback.Text = "يجب اختيار التقاطع أولا";
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
            BtnYes.Visible = false;
            BtnNO.Visible = false;
        }
    }
    protected void BtnYes_Click(object sender, EventArgs e)
    {
        if (ddlRegions.SelectedValue != "-1" && new JpmmsClasses.BL.MainStreet().RemovePreviousInterSections(int.Parse(ddlSections.SelectedValue)))
        {
            lblFeedback.Text = "تم حذف التقاطع";
            BoundInterSections();
            BtnYes.Visible = false;
            BtnNO.Visible = false;
        }

    }
    protected void BtnNO_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        BtnYes.Visible = false;
        BtnNO.Visible = false; ;
    }
    protected void ddlSections_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        BtnYes.Visible = false;
        BtnNO.Visible = false;
    }
    protected void BtnDelted_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null && Session["UserID"].ToString() == "60")
        {
            if (new JpmmsClasses.BL.MainStreet().RemoveRepetedIntersctions())
                lblFeedback.Text = Feedback.DeleteSuccessfull();
            else
                lblFeedback.Text = Feedback.DeleteException();
        }
        else
            lblFeedback.Text = Feedback.NoPermissions();

    }
}