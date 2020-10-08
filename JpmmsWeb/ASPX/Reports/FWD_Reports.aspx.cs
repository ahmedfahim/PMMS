using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class ASPX_Reports_FWD_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        //if (IsPostBack)
        //{
        //    if (Session["rptFWD"] != null)
        //    {
        //        ReportDocument cr = new ReportDocument();
        //        cr = (ReportDocument)Session["rptFWD"];
        //        crv.ReportSource = cr;
        //        crv.DataBind();
        //    }
        //    else
        //        crv.Visible = false;
        //}
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (radMaintSt.Checked && (ddlMainStreets.SelectedValue == "0" || string.IsNullOrEmpty(ddlMainStreets.SelectedValue)))
                throw new Exception(Feedback.NoMainStreetSelected());


            DataTable dt = new FwdReport().GetFwdReport(ddlMainStreets.SelectedValue, radAll.Checked,RadioBtnSURVEYNO.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                Session.Add("ReportData", dt);
                string url = "ViewFwdReport.aspx";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);           
            }
            else
                lblFeedback.Text = Feedback.NoData();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        ddlMainStreets.SelectedValue = "0";
    }

}