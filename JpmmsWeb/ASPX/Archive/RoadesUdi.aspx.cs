using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_RoadesUdi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }



    protected void gvRegionSamplesIRI_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamplesIRI"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdrIRI"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdrIRI"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdrIRI"] = "Asc";
            }

            gvRegionSamplesIRI.DataSource = dtrslt;
            gvRegionSamplesIRI.DataBind();

        }
    }

   
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        DataTable dtIRI = new JpmmsClasses.BL.MainStreet().RoadsUdi(RadioButtonListType.SelectedValue, RadioButtonListSurvey.SelectedValue);
        gvRegionSamplesIRI.DataSource = dtIRI;
        gvRegionSamplesIRI.DataBind();
        ViewState["gvRegionSamplesIRI"] = dtIRI;
    }
}