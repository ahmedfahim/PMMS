using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Sections_DrillingPermitsIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ddlMainStreets.SelectedValue = "0";
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreetSection.Items.Clear();
            ddlMainStreetSection.Items.Add(new ListItem("اختيار", "0"));
            ddlMainStreetSection.DataBind();

            ddlMainStreetSection_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            int id = int.Parse(ddlMainStreetSection.SelectedValue);
            if (id != 0)
            {
                string sDate = new MainStreetSection().GetSectionNoPermitTillDate(id);
                if (string.IsNullOrEmpty(sDate))
                {
                    lblPermits.Text = "يمكن إصدار رخصة حفريات";
                    lblPermits.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    DateTime stopTill = DateTime.Parse(sDate);
                    if (stopTill >= DateTime.Today)
                    {
                        lblPermits.Text = "إصدار رخص الحفريات موقوف حتى تاريخ: " + sDate;
                        lblPermits.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblPermits.Text = "يمكن إصدار رخصة حفريات";
                        lblPermits.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
                lblPermits.Text = "";

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        lblPermits.Text = "";

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

}