using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentValidate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1' || Request.QueryString.Count==0)
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1)
            {
                if (Request.QueryString[0].ToString() == "IRI")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    gvRegion.DataSource = new JpmmsClasses.BL.MainStreet().ValidateIRI(null, null);
                    gvRegion.DataBind();

                }
                else if (Request.QueryString[0].ToString() == "GPR")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    gvRegion.DataSource = new JpmmsClasses.BL.MainStreet().ValidateGPR(null,null);
                    gvRegion.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "FWD")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    gvRegion.DataSource = new JpmmsClasses.BL.MainStreet().ValidateFWD(null,null);
                    gvRegion.DataBind();
                }
                else if (Request.QueryString[0].ToString() == "SKID")
                {
                    Label1.Text = Request.QueryString[0].ToString();
                    gvRegion.DataSource = new JpmmsClasses.BL.MainStreet().ValidateSKID(null, null);
                    gvRegion.DataBind();

                }
                else
                    Response.Redirect("~/ASPX/Default.aspx", false);

            }

                }
    }
   
    protected void gvRegion_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (Request.QueryString.Count == 1 )
        {
            if (Request.QueryString[0].ToString() == "IRI")
            {
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().ValidateIRI(gvRegion.DataKeys[e.NewSelectedIndex].Value.ToString(), gvRegion.Rows[e.NewSelectedIndex].Cells[3].Text);
                gvRegionSamplesEqupment.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "GPR")
            {
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().ValidateGPR(gvRegion.DataKeys[e.NewSelectedIndex].Value.ToString(), gvRegion.Rows[e.NewSelectedIndex].Cells[3].Text);
                gvRegionSamplesEqupment.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "FWD")
            {
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().ValidateFWD(gvRegion.DataKeys[e.NewSelectedIndex].Value.ToString(), gvRegion.Rows[e.NewSelectedIndex].Cells[3].Text);
                gvRegionSamplesEqupment.DataBind();
            }
            else if (Request.QueryString[0].ToString() == "SKID")
            {
                gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().ValidateSKID(gvRegion.DataKeys[e.NewSelectedIndex].Value.ToString(), gvRegion.Rows[e.NewSelectedIndex].Cells[3].Text);
                gvRegionSamplesEqupment.DataBind();
            }
            else
                Response.Redirect("~/ASPX/Default.aspx", false);

        }
    }
}