using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data;
using JpmmsClasses.BL;
using JpmmsClasses;
using JpmmsClasses.BL.UDI;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Archive_ReportReview : System.Web.UI.Page
{
    protected Guid RequestID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();

        }
        if (Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
        {

        }
        else if (Session["UserID"].ToString() != "37")
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }

    }
    protected void BtnEND_Click(object sender, EventArgs e)
    {
        if (gvRegionSamples.Rows.Count > 0 && Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
        {
            int Sum = 0;
            for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
            {
                if ((gvRegionSamples.Rows[i].Cells[7].Controls[0] as CheckBox).Checked)
                    Sum++;
            }
            if (gvRegionSamples.Rows.Count == Sum)
            {
                lblFeedback.Text = "هل انت متاكد سيتم اغلاق الشهر ولن يمكنك التراجع";
                BtnYes.Visible = true;
                BtnNO.Visible = true;
            }
            else
            {
                lblFeedback.Text = "يجب ان تكون كل العناصر جاهزة للتقرير قبل اغلاق الشهر ";
                BtnYes.Visible = false;
                BtnNO.Visible = false;
            }
            
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
        if (new JpmmsClasses.BL.Lookups.SystemUsers().UpdateReceivedReports())
        {
            lblFeedback.Text = "تم اغلاق الشهر";
            BtnYes.Visible = false;
            BtnNO.Visible = false;
            gvRegionSamples.DataSource = null;
            gvRegionSamples.DataBind();
        }

    }
    protected void BtnNO_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        BtnYes.Visible = false;
        BtnNO.Visible = false; ;
    }

    protected void BtnNEW_Click(object sender, EventArgs e)
    {   //gvRegionSamples.Rows.Count > 0 &&
        if ( Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
        {
            if (new JpmmsClasses.BL.Lookups.SystemUsers().UpdateUDINewStreets())
            {
                lblFeedback.Text = "تم نقل الشوارع الجديده";
            }
            else lblFeedback.Text = "لا توجد شوارع جديدة";
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void btnMainStreetsMin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());
                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateMainRegionsALL);
                Thread worker = new Thread(ts);
                worker.Start();

                string url = string.Format(@"../Operations/ResultMd.aspx?id={0}&All=0", RequestID.ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

                lblFeedback.Text = "تم الحساب بنجاح";


            }
            else
            {
                lblFeedback.Text = Feedback.NoPermissions();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    private void CalculateMainRegionsALL()
    {
        DataTable dt;
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();


        dt = new SystemUsers().GetReceivedReports();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareRegionSecondaryStreetsMaintenanceDecisions(int.Parse(dr["ID"].ToString()), user, true);

        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    protected void gvRegionSamples_DataBound(object sender, EventArgs e)
    {
        btnMainStreetsMin.Visible = gvRegionSamples.Rows.Count > 0 ? true : false;
        btnMainStreetsUdi.Visible = gvRegionSamples.Rows.Count > 0 ? true : false;
        BtnEND.Visible = gvRegionSamples.Rows.Count > 0 ? true : false;

    }
    protected void btnMainStreetsUdi_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "32" || Session["UserID"].ToString() == "37")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());


                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateUdiRegionsALL);
                Thread worker = new Thread(ts);
                worker.Start();

                string url = string.Format(@"../Operations/ResultUDI.aspx?id={0}&All=1", RequestID.ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RedirectScriptCoupon", "window.open('" + url + "', '_blank')", true);

                lblFeedback.Text = "تم الحساب بنجاح";

            }
            else
            {
                lblFeedback.Text = Feedback.NoPermissions();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    private void CalculateUdiRegionsALL()
    {
        DataTable dt;
        bool result = true;
        RegionSecondaryStUDI udiRegions = new RegionSecondaryStUDI();
        string user = Session["UserName"].ToString();
        dt = new SystemUsers().GetReceivedReports();
        foreach (DataRow dr in dt.Rows)
            result &= udiRegions.CalculateRegionSecondaryStreetsUDI(int.Parse(dr["ID"].ToString()), user, true);
        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    
}