using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_LanesDeletedDistress : System.Web.UI.Page
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
                    ddlRegions.DataSource = new JpmmsClasses.BL.MainStreet().LanesDeletedGPR(null, true);
                    ddlRegions.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "SKID")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    ddlRegions.DataSource = new JpmmsClasses.BL.MainStreet().LanesDeletedSKID(null, true);
                    ddlRegions.DataBind();
                }
                else
                    Response.Redirect("~/ASPX/Default.aspx", false);

            }

        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1  )
        {
            if (ddlRegions.SelectedValue != "-1")
            {
                if (Request.QueryString[0].ToString() == "GPR")
                {
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().LanesDeletedGPR(ddlRegions.SelectedValue == "0" ? string.Empty : ddlRegions.SelectedValue, false);
                    gvRegionSamplesEqupment.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "SKID")
                {

                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().LanesDeletedSKID(ddlRegions.SelectedValue == "0" ? string.Empty : ddlRegions.SelectedValue, false);
                    gvRegionSamplesEqupment.DataBind();
                }
            }
            else
            {
                gvRegionSamplesEqupment.DataSource = null;
                gvRegionSamplesEqupment.DataBind();
            }

        }
    }

   
}