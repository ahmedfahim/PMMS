using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;
using JpmmsClasses;
using System.Threading;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Archive_EquipmentDistress : System.Web.UI.Page
{
    protected Guid RequestID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1' || Request.QueryString.Count == 0)
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1)
            {
                if (Request.QueryString[0].ToString() == "MIN")
                {
                    Label1.Text = "قرارات صيانة";
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().FinshedRrturnToMFVMaintenance();
                    gvRegionSamplesEqupment.DataBind();
                    BtnLeatestUDI.Visible = false;
                }
                else if (Request.QueryString[0].ToString() == "UDI")
                {
                    Label1.Text = "حالة الرصف";
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().FinshedRrturnToMFVUDI();
                    gvRegionSamplesEqupment.DataBind();
                    BtnLeatestUDI.Visible = true;
                   
                }
                else if (Request.QueryString[0].ToString() == "DID")
                {
                    Label1.Text = "العيوب";
                    gvRegionSamplesEqupment.Columns[2].Visible = true;
                    gvRegionSamplesEqupment.Columns[3].Visible = true;
                    gvRegionSamplesEqupment.Columns[4].Visible = true;
                    gvRegionSamplesEqupment.Columns[5].Visible = true;
                    gvRegionSamplesEqupment.DataSource = new JpmmsClasses.BL.MainStreet().GetDistressCount();
                    gvRegionSamplesEqupment.DataBind();
                    BtnLeatestUDI.Visible = false;
                }
                else
                    Response.Redirect("~/ASPX/Default.aspx", false);

            }

        }
    }
    protected void btnMainStreetsUdi_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "55")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());


                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateMainStreetsUdi);
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

    protected void btnMainStreetsMin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "55")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());
                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateMainStreetsMin);
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

    private void CalculateMainStreetsUdi()
    {

        bool result = true;
        SectionsUDI udiSections = new SectionsUDI();
        string user = Session["UserName"].ToString();

        DataTable dt = new JpmmsClasses.BL.MainStreet().FinshedRrturnToMFVUDI();//.CustomMunicpilityUdi();//
        foreach (DataRow dr in dt.Rows)
            result &= udiSections.CalculateMainStreetSectionsUDI(int.Parse(dr["STREET_ID"].ToString()), user, false);

        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    private void CalculateMainStreetsMin()
    {
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();

        DataTable dt = new JpmmsClasses.BL.MainStreet().FinshedRrturnToMFVMaintenance();//.CustomMunicpilityMaintenance();

        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareMainStreetSectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, false);

        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    protected void gvRegionSamples_DataBound(object sender, EventArgs e)
    {
        btnMainStreetsMin.Visible = Request.QueryString[0].ToString() == "MIN" && gvRegionSamplesEqupment.Rows.Count > 0 ? true : false;
        btnMainStreetsUdi.Visible = Request.QueryString[0].ToString() == "UDI" && gvRegionSamplesEqupment.Rows.Count > 0 ? true : false;
        lblFeedback.Text = " عدد الشوارع " + gvRegionSamplesEqupment.Rows.Count.ToString();
        int sum = 0;
        if (Request.QueryString[0].ToString() == "DID")
            if (gvRegionSamplesEqupment.Rows.Count > 0)
            {
                for (int i = 0; i < gvRegionSamplesEqupment.Rows.Count; i++)
                {
                    if (gvRegionSamplesEqupment.Rows[i].Cells[4].Text != gvRegionSamplesEqupment.Rows[i].Cells[5].Text)
                    {
                        sum++;
                        gvRegionSamplesEqupment.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                    }
                    else if (gvRegionSamplesEqupment.Rows[i].Cells[2].Text != gvRegionSamplesEqupment.Rows[i].Cells[3].Text)
                    {
                        sum++;
                        gvRegionSamplesEqupment.Rows[i].BackColor = System.Drawing.Color.Yellow;
                    }
                    //else
                    //    gvRegionSamplesEqupment.Rows[i].Visible = false;
                }
                lblFeedback.Text = " العدد الإجمالي " + gvRegionSamplesEqupment.Rows.Count + "<br /> عدد الشوارع تحتاج مراجعة " + sum.ToString();
            }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"].ToString() == "32")
            {
                lblFeedback.Text = "";

                if (!bool.Parse(Session["canEdit"].ToString()))
                    throw new Exception(Feedback.NoPermissions());
                RequestID = Guid.NewGuid();
                ThreadStart ts = new ThreadStart(CalculateMainStreetsMinWithDate);
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
    private void CalculateMainStreetsMinWithDate()
    {
        bool result = true;
        MaintenanceDecisions maintD = new MaintenanceDecisions();
        string user = Session["UserName"].ToString();

        DataTable dt = new JpmmsClasses.BL.MainStreet().FinshedMFVMaintenanceWithDate("02/01/2020","3");

        foreach (DataRow dr in dt.Rows)
            result &= maintD.PrepareMainStreetSectionsMaintenanceDecisions(int.Parse(dr["STREET_ID"].ToString()), user, true);

        dt = new DataTable();
        ThreadResults.Add(RequestID, dt);
    }
    protected void BtnLeatestUDI_Click(object sender, EventArgs e)
    {
        if (Request.QueryString[0].ToString() == "UDI")
        {
            if (Session["UserID"].ToString() == "55")
                lblFeedback.Text = new JpmmsClasses.BL.MainStreet().UpdateLengthMAXServey() == true ? "تم التحديث بنجاح" : "خطأ في التحديث";
            else
                lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}