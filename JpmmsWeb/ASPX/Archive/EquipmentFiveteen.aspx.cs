using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentFiveteen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            else
            {
                BOUNDSECTIONS();
             
            }

        }
    }

    private void BOUNDSECTIONS()
    {
        ddlMainStreets.Items.Clear();
        ddlMainStreets.Items.Add(new ListItem("اختيار", "-1"));
        ddlMainStreets.DataSource = new JpmmsClasses.BL.MainStreet().GetNewStreetsGis(false);
        ddlMainStreets.DataTextField = "arname";
        ddlMainStreets.DataValueField = "STREET_ID";
        ddlMainStreets.DataBind();
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnEND_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null && (Session["UserID"].ToString() == "46" || Session["UserID"].ToString() == "60"))
        {
            if (ddlMainStreets.SelectedValue != "-1")
            {
                lblFeedback.Text = "هل انت متاكد سيتم اضافة الشارع ولن يمكنك التراجع";
                BtnYes.Visible = true;
                BtnNO.Visible = true;
            }
            else
                lblFeedback.Text = "يجب اختيار الشارع أولا";
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
        if (ddlMainStreets.SelectedValue != "-1" && new JpmmsClasses.BL.MainStreet().InsertNewStreetsGis(int.Parse(ddlMainStreets.SelectedValue),false))
        {
            lblFeedback.Text = "تم إضافة الشارع بنجاح";
            BtnYes.Visible = false;
            BtnNO.Visible = false;
            BOUNDSECTIONS();
        }

    }
    protected void BtnNO_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        BtnYes.Visible = false;
        BtnNO.Visible = false; ;
    }
}