using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_SysNotIn_FWD_GPR_SKID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1' || Request.QueryString.Count == 0)
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1)
            {
                if (Request.QueryString[0].ToString() == "GPR")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    ddlRegions.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateGPRIRI(null, null);
                    ddlRegions.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "FWD")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    ddlRegions.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateFWD(null, null);
                    ddlRegions.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "SKID")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    ddlRegions.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateSKIDIRI(null, null);
                    ddlRegions.DataBind();
                }
                else
                    Response.Redirect("~/ASPX/Default.aspx", false);

            }

        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1 && ddlRegions.SelectedValue != "0")
        {
            if (Request.QueryString[0].ToString() == "GPR")
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsGPR();
                dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns["MAIN_NO"] };
                RadioButtonList1.SelectedValue = dt.Rows.Find(ddlRegions.SelectedValue)[2].ToString();
                RadioButtonList1.DataBind();
                if (dt.Rows.Find(ddlRegions.SelectedValue)[3].ToString() == "1")
                    RadioButtonList1.Enabled = false;
                else
                    RadioButtonList1.Enabled = true;
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateGPRIRI(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
                gvRegionSamplesEqupment.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "FWD")
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsFWD();
                dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns["MAIN_NO"] };
                RadioButtonList1.SelectedValue = dt.Rows.Find(ddlRegions.SelectedValue)[2].ToString();
                RadioButtonList1.DataBind();
                if (dt.Rows.Find(ddlRegions.SelectedValue)[3].ToString() == "1")
                    RadioButtonList1.Enabled = false;
                else
                    RadioButtonList1.Enabled = true;
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateFWD(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
                gvRegionSamplesEqupment.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "SKID")
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsSKID();
                dt.PrimaryKey = new System.Data.DataColumn[] { dt.Columns["MAIN_NO"] };
                RadioButtonList1.SelectedValue = dt.Rows.Find(ddlRegions.SelectedValue)[2].ToString();
                RadioButtonList1.DataBind();
                if (dt.Rows.Find(ddlRegions.SelectedValue)[3].ToString() == "1")
                    RadioButtonList1.Enabled = false;
                else
                    RadioButtonList1.Enabled = true;
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateSKIDIRI(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
                gvRegionSamplesEqupment.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1 && ddlRegions.SelectedValue != "0")
        {
            if (Request.QueryString[0].ToString() == "GPR")
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateGPRIRI(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            else if (Request.QueryString[0].ToString() == "FWD")
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateFWD(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            else if (Request.QueryString[0].ToString() == "SKID")
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().CountValidateSKIDIRI(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);

            gvRegionSamplesEqupment.DataBind();
        }
    }
}