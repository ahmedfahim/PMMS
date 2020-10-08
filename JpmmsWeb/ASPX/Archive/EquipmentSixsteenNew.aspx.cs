using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentSixsteenNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (Session["UserID"].ToString() != "49" && Session["UserID"].ToString() != "55")
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnStreet_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() != "49" && Session["UserID"].ToString() != "55" && Session["UserID"].ToString() != "48")
            lblFeedback.Text = Feedback.NoPermissions();
        else
        {
            System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().CheckErorrInsertLength();
            if (dt.Rows.Count == 0)
            {
                if (new JpmmsClasses.BL.MainStreet().InsertNewStreetsDID(null))
                {
                    lblFeedback.Text = Feedback.StatusUpdateSuccessfull();
                    gvRegionSamples.DataBind();
                }
                else
                    lblFeedback.Text = Feedback.NoData();
            }
            else
            {
                lblFeedback.Text = "شوارع تحتاج تحديث الاطوال";
                gvERorrLength.DataSource = dt;
                gvERorrLength.DataBind();
            }
        }
    }
    protected void BtnLength_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() != "49" && Session["UserID"].ToString() != "55" && Session["UserID"].ToString() != "48")
            lblFeedback.Text = Feedback.NoPermissions();
        else
        {
            if (gvERorrLength.Rows.Count != 0)
            {
                if (new JpmmsClasses.BL.MainStreet().RemoveIRILength())
                {
                    if (new JpmmsClasses.BL.MainStreet().InsertLengthDDF())
                    {
                        lblFeedback.Text = new JpmmsClasses.BL.MainStreet().UpdateLengthSAMPLESOld() == true ? "تم تحديث الأطوال" : Feedback.UpdateUNSuccessfull();
                        gvERorrLength.DataBind();
                    }
                    else
                        lblFeedback.Text = Feedback.UpdateUNSuccessfull();
                }
                else
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();

            }
            else
            {
                lblFeedback.Text = Feedback.NoData();
                gvERorrLength.DataBind();
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = new JpmmsClasses.BL.MainStreet().StatisticsToMFV(RadioButtonList1.SelectedValue);
        GridView1.DataBind();
        System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetRecivedMFVNext(RadioButtonList1.SelectedValue);
        //gvRegionSamples.DataSource = dt;
        //gvRegionSamples.DataBind();
        lblFeedback0.Text = dt.Rows.Count.ToString() + "  شارع " + RadioButtonList1.SelectedItem.Text;
    }
}