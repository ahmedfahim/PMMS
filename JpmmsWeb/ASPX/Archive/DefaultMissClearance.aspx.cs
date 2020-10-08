using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_DefaultMissClearance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().CounMissClearance();

            int InterSectionsClearance = int.Parse(dt.Rows[0]["CountInterSectionsClearance"].ToString());
            int FWDNoReady = int.Parse(dt.Rows[0]["CountFWDCLEARANCE"].ToString());
            int SKIDNoReady = int.Parse(dt.Rows[0]["CountSKIDCLEARANCE"].ToString());
            int ASSETESNoReady = int.Parse(dt.Rows[0]["CountASSETSCLEARANCE"].ToString());
            int GPRNoReady = int.Parse(dt.Rows[0]["CountGPRCLEARANCE"].ToString());
            int IRIDDFCLEARANCE = int.Parse(dt.Rows[0]["CountIRIDDFCLEARANCE"].ToString());

            if (IRIDDFCLEARANCE > 0)
            {
                spanIRIDDFNoReady.Visible = true;
                spanIRIDDFNoReady.InnerText = IRIDDFCLEARANCE.ToString();
            }
            else
            {
                spanIRIDDFNoReady.Visible = false;
                spanIRIDDFNoReady.InnerText = string.Empty;
            }
            if (InterSectionsClearance > 0)
            {
                spanInterSectionsClearance.Visible = true;
                spanInterSectionsClearance.InnerText = InterSectionsClearance.ToString();
            }
            else
            {
                spanInterSectionsClearance.Visible = false;
                spanInterSectionsClearance.InnerText = string.Empty;
            }
            if (FWDNoReady > 0)
            {
                spanFWDNoReady.Visible = true;
                spanFWDNoReady.InnerText = FWDNoReady.ToString();
            }
            else
            {
                spanFWDNoReady.Visible = false;
                spanFWDNoReady.InnerText = string.Empty;
            }
            if (SKIDNoReady > 0)
            {
                spanSKIDNoReady.Visible = true;
                spanSKIDNoReady.InnerText = SKIDNoReady.ToString();
            }
            else
            {
                spanSKIDNoReady.Visible = false;
                spanSKIDNoReady.InnerText = string.Empty;
            }
            if (ASSETESNoReady > 0)
            {
                spanASSETESNoReady.Visible = true;
                spanASSETESNoReady.InnerText = ASSETESNoReady.ToString();
            }
            else
            {
                spanASSETESNoReady.Visible = false;
                spanASSETESNoReady.InnerText = string.Empty;
            }
            if (GPRNoReady > 0)
            {
                spanGPRNoReady.Visible = true;
                spanGPRNoReady.InnerText = GPRNoReady.ToString();
            }
            else
            {
                spanGPRNoReady.Visible = false;
                spanGPRNoReady.InnerText = string.Empty;
            }
        }
    }
}