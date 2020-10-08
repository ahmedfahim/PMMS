using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data;
using JpmmsClasses.BL.UDI;
using JpmmsClasses;
using JpmmsClasses.BL.Lookups;
using JpmmsClasses.BL;

public partial class ASPX_Archive_InterSectionReportReview : System.Web.UI.Page
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
                if ((gvRegionSamples.Rows[i].Cells[8].Controls[0] as CheckBox).Checked)
                    Sum++;
            }
            if (gvRegionSamples.Rows.Count == Sum)
            {
                lblFeedback.Text = "هل انت متاكد سيتم اغلاق الشهر وتحويلة للمستخلص  ولن يمكنك التراجع";
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
        if (new JpmmsClasses.BL.Lookups.SystemUsers().UpdateReceivedInterSectReports())
        {
            lblFeedback.Text = " تم اغلاق الشهر وتحويلة للمستخلص";
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
                ThreadStart ts = new ThreadStart(CalculateMainIntersectionALL);
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
    private void CalculateMainIntersectionALL()
    {
        DataTable dt;
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();


        dt = new SystemUsers().GetReceivedInterMainStreet();
        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareMainStreetIntersectionsMaintenanceDecisions(int.Parse(dr["ID"].ToString()), user, true);

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
                ThreadStart ts = new ThreadStart(CalculateUdiudiIntersectionALL);
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
    private void CalculateUdiudiIntersectionALL()
    {
        DataTable dt;
        bool result = true;
        IntersectionUDI udiIntersection = new IntersectionUDI();
        string user = Session["UserName"].ToString();
        dt = new SystemUsers().GetReceivedInterMainStreet();
        foreach (DataRow dr in dt.Rows)
            result &= udiIntersection.CalculateMainStreetIntersectionsUDI(int.Parse(dr["ID"].ToString()), user, true);
        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
}