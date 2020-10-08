using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DeleteDistressStreets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        BtnYes.Visible = false;
        BtnNO.Visible = false;
        if (ddlMainStreets.SelectedValue != "-1")
        {
            BOUNDSECTIONS();
        }
      
    }


    private void BOUNDSECTIONS()
    {
        ddlMainStreetSection.Items.Clear();
        ddlMainStreetSection.Items.Add(new ListItem("اختر المقطع", "-1"));
        ddlMainStreetSection.DataSource = new JpmmsClasses.BL.MainStreetSection().GetMainStreetSections(int.Parse(ddlMainStreets.SelectedValue));
        ddlMainStreetSection.DataTextField = "section_from_to";
        ddlMainStreetSection.DataValueField = "section_id";
        ddlMainStreetSection.DataBind();
    }
    protected void BtnEND_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null && Session["UserID"].ToString() == "48")
        {
            if (ddlMainStreets.SelectedValue != "-1")
            {
                lblFeedback.Text = " هل انت متاكد سيتم حذف عيوب الشارع ولن يمكنك التراجع";
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
        if (new JpmmsClasses.BL.MainStreet().RemoveDistressStreets(int.Parse(ddlMainStreets.SelectedValue)))
        {
            lblFeedback.Text = Feedback.DeleteSuccessfull();
            BtnYes.Visible = false;
            BtnNO.Visible = false;
            ddlMainStreets.SelectedValue = "-1";
        }
        else
        {
            lblFeedback.Text = Feedback.DeleteException();
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
    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            frvSectionInfo.DataBind();
            radlLanes.DataBind();
            gvLaneSamples.DataBind();
            gvLaneSamples.SelectedIndex = -1;

            
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void radlLanes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            gvLaneSamples.DataBind();
            gvLaneSamples.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void radlLanes_DataBound(object sender, EventArgs e)
    {
        radlLanes_SelectedIndexChanged(sender, e);
    }
}