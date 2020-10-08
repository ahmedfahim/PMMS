using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_LandingOthers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString.Count == 1)
            {
                spanASSETESNoReady.Visible = false;
                spanDistreesFWD.Visible = false;
                spanDistreesGPR.Visible = false;
                spanDistreesSKID.Visible = false;
                spanDublicateGPR.Visible = false;
                spanDublicateSKID.Visible = false;
                spanFWDNoReady.Visible = false;
                spanGPRNoReady.Visible = false;
                spanSKIDNoReady.Visible = false;
                spanValidateFWD.Visible = false;
                spanValidateFWDLane.Visible = false;
                spanValidateFWDSection.Visible = false;
                spanValidateGPR.Visible = false;
                spanValidateGPRLane.Visible = false;
                spanValidateGPRSections.Visible = false;
                spanValidateSKID.Visible = false;
                spanValidateSKIDLane.Visible = false;
                spanValidateSKIDSection.Visible = false;
                spanIRISKID.Visible = false;
                spanIRIGPR.Visible = false;
                spanFinshedFWD.Visible = false;
                spanDistreesDeletedGPR.Visible = false;
                spanDistreesDeletedSKID.Visible = false;
                spanSectionsMainNOGPR.Visible = false;
                spanSectionsMainNOFWD.Visible = false;
                spanSectionsMainNOSKID.Visible = false;
                spanMFVGPR.Visible = false;
                spanMFVSKID.Visible = false;
                spanMFVASSETS.Visible = false;
                spanCompareASSETS.Visible = false;

                
            }
            else
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().CountOthersEquipment(false);
                int FWDNoReady = int.Parse(dt.Rows[0]["CountFWDCLEARANCE"].ToString());
                int GPRNoReady = int.Parse(dt.Rows[0]["CountGPRCLEARANCE"].ToString());
                int SKIDNoReady = int.Parse(dt.Rows[0]["CountSKIDCLEARANCE"].ToString());
                int ASSETESNoReady = int.Parse(dt.Rows[0]["CountASSETSCLEARANCE"].ToString());
                int DistreesGPR = int.Parse(dt.Rows[0]["CountDistreesGPR"].ToString());
                int DistreesFWD = int.Parse(dt.Rows[0]["CountDistreesFWD"].ToString());
                int DistreesSKID = int.Parse(dt.Rows[0]["CountDistreesSKID"].ToString());
                int ValidateGPRLane = int.Parse(dt.Rows[0]["CountValidateGPRLane"].ToString());
                int ValidateFWDLane = int.Parse(dt.Rows[0]["CountValidateFWDLane"].ToString());
                int ValidateSKIDLane = int.Parse(dt.Rows[0]["CountValidateSKIDLane"].ToString());
                int ValidateGPRSections = int.Parse(dt.Rows[0]["CountValidateGPRSections"].ToString());
                int ValidateFWDSections = int.Parse(dt.Rows[0]["CountValidateFWDSections"].ToString());
                int ValidateSKIDSections = int.Parse(dt.Rows[0]["CountValidateSKIDSections"].ToString());
                int ValidateGPR = int.Parse(dt.Rows[0]["CountValidateGPR"].ToString());
                int ValidateFWD = int.Parse(dt.Rows[0]["CountValidateFWD"].ToString());
                int ValidateSKID = int.Parse(dt.Rows[0]["CountValidateSKID"].ToString());
                int DublicateGPR = int.Parse(dt.Rows[0]["CountDublicateGPR"].ToString());
                int DublicateSKID = int.Parse(dt.Rows[0]["CountDublicateSKID"].ToString());
                int FinshedFwd = int.Parse(dt.Rows[0]["FinshedReadyFWD"].ToString());
                int DeletedSKID = int.Parse(dt.Rows[0]["LanesDeletedSKID"].ToString());
                int DeletedGPR = int.Parse(dt.Rows[0]["LanesDeletedGPR"].ToString());
                int SectionsMainNOFWD = int.Parse(dt.Rows[0]["CountSectionMainNOFWD"].ToString());
                int SectionsMainNOSKID = int.Parse(dt.Rows[0]["CountSectionMainNOSKID"].ToString());
                int SectionsMainNOSGPR = int.Parse(dt.Rows[0]["CountSectionMainNOGPR"].ToString());
                int IRISKID = new JpmmsClasses.BL.MainStreet().SKIDNotIRI().Rows.Count;
                int IRIGPR = new JpmmsClasses.BL.MainStreet().GPRNotIRI().Rows.Count;
                int MFVGPR = int.Parse(dt.Rows[0]["CountMFVGPR"].ToString());
                int MFVSKID = int.Parse(dt.Rows[0]["CountMFVSKID"].ToString());
                int MFVASSETS = int.Parse(dt.Rows[0]["CountMFVASSETS"].ToString());
                int CompareASSETS = int.Parse(dt.Rows[0]["CountCompareASSETS"].ToString());

                if (CompareASSETS > 0)
                {
                    spanCompareASSETS.Visible = true;
                    spanCompareASSETS.InnerText = CompareASSETS.ToString();
                }
                else
                {
                    spanCompareASSETS.Visible = false;
                    spanCompareASSETS.InnerText = string.Empty;
                }
                if (MFVGPR > 0)
                {
                    spanMFVGPR.Visible = true;
                    spanMFVGPR.InnerText = MFVGPR.ToString();
                }
                else
                {
                    spanMFVGPR.Visible = false;
                    spanMFVGPR.InnerText = string.Empty;
                }
                if (MFVSKID > 0)
                {
                    spanMFVSKID.Visible = true;
                    spanMFVSKID.InnerText = MFVSKID.ToString();
                }
                else
                {
                    spanMFVSKID.Visible = false;
                    spanMFVSKID.InnerText = string.Empty;
                }
                if (MFVASSETS > 0)
                {
                    spanMFVASSETS.Visible = true;
                    spanMFVASSETS.InnerText = MFVASSETS.ToString();
                }
                else
                {
                    spanMFVASSETS.Visible = false;
                    spanMFVASSETS.InnerText = string.Empty;
                }
                if (SectionsMainNOSGPR > 0)
                {
                    spanSectionsMainNOGPR.Visible = true;
                    spanSectionsMainNOGPR.InnerText = SectionsMainNOSGPR.ToString();
                }
                else
                {
                    spanSectionsMainNOGPR.Visible = false;
                    spanSectionsMainNOGPR.InnerText = string.Empty;
                }
                if (SectionsMainNOSKID > 0)
                {
                    spanSectionsMainNOSKID.Visible = true;
                    spanSectionsMainNOSKID.InnerText = SectionsMainNOSKID.ToString();
                }
                else
                {
                    spanSectionsMainNOSKID.Visible = false;
                    spanSectionsMainNOSKID.InnerText = string.Empty;
                }
                if (SectionsMainNOFWD > 0)
                {
                    spanSectionsMainNOFWD.Visible = true;
                    spanSectionsMainNOFWD.InnerText = SectionsMainNOFWD.ToString();
                }
                else
                {
                    spanSectionsMainNOFWD.Visible = false;
                    spanSectionsMainNOFWD.InnerText = string.Empty;
                }
                if (DeletedGPR > 0)
                {
                    spanDistreesDeletedGPR.Visible = true;
                    spanDistreesDeletedGPR.InnerText = DeletedGPR.ToString();
                }
                else
                {
                    spanDistreesDeletedGPR.Visible = false;
                    spanDistreesDeletedGPR.InnerText = string.Empty;
                }
                if (DeletedSKID > 0)
                {
                    spanDistreesDeletedSKID.Visible = true;
                    spanDistreesDeletedSKID.InnerText = DeletedSKID.ToString();
                }
                else
                {
                    spanDistreesDeletedSKID.Visible = false;
                    spanDistreesDeletedSKID.InnerText = string.Empty;
                }
                if (FinshedFwd > 0)
                {
                    spanFinshedFWD.Visible = true;
                    spanFinshedFWD.InnerText = FinshedFwd.ToString();
                }
                else
                {
                    spanFinshedFWD.Visible = false;
                    spanFinshedFWD.InnerText = string.Empty;
                }
                if (IRISKID > 0)
                {
                    spanIRISKID.Visible = true;
                    spanIRISKID.InnerText = IRISKID.ToString();
                }
                else
                {
                    spanIRISKID.Visible = false;
                    spanIRISKID.InnerText = string.Empty;
                }
                if (IRIGPR > 0)
                {
                    spanIRIGPR.Visible = true;
                    spanIRIGPR.InnerText = IRIGPR.ToString();
                }
                else
                {
                    spanIRIGPR.Visible = false;
                    spanIRIGPR.InnerText = string.Empty;
                }
                if (DublicateGPR > 0)
                {
                    spanDublicateGPR.Visible = true;
                    spanDublicateGPR.InnerText = DublicateGPR.ToString();
                }
                else
                {
                    spanDublicateGPR.Visible = false;
                    spanDublicateGPR.InnerText = string.Empty;
                }
                if (DublicateSKID > 0)
                {
                    spanDublicateSKID.Visible = true;
                    spanDublicateSKID.InnerText = DublicateSKID.ToString();
                }
                else
                {
                    spanDublicateSKID.Visible = false;
                    spanDublicateSKID.InnerText = string.Empty;
                }
                if (ValidateGPR > 0)
                {
                    spanValidateGPR.Visible = true;
                    spanValidateGPR.InnerText = ValidateGPR.ToString();
                }
                else
                {
                    spanValidateGPR.Visible = false;
                    spanValidateGPR.InnerText = string.Empty;
                }
                if (ValidateFWD > 0)
                {
                    spanValidateFWD.Visible = true;
                    spanValidateFWD.InnerText = ValidateFWD.ToString();
                }
                else
                {
                    spanValidateFWD.Visible = false;
                    spanValidateFWD.InnerText = string.Empty;
                }
                if (ValidateSKID > 0)
                {
                    spanValidateSKID.Visible = true;
                    spanValidateSKID.InnerText = ValidateSKID.ToString();
                }
                else
                {
                    spanValidateSKID.Visible = false;
                    spanValidateSKID.InnerText = string.Empty;
                }
                if (ValidateGPRLane > 0)
                {
                    spanValidateGPRLane.Visible = true;
                    spanValidateGPRLane.InnerText = ValidateGPRLane.ToString();
                }
                else
                {
                    spanValidateGPRLane.Visible = false;
                    spanValidateGPRLane.InnerText = string.Empty;
                }
                if (ValidateFWDLane > 0)
                {
                    spanValidateFWDLane.Visible = true;
                    spanValidateFWDLane.InnerText = ValidateFWDLane.ToString();
                }
                else
                {
                    spanValidateFWDLane.Visible = false;
                    spanValidateFWDLane.InnerText = string.Empty;
                }
                if (ValidateSKIDLane > 0)
                {
                    spanValidateSKIDLane.Visible = true;
                    spanValidateSKIDLane.InnerText = ValidateSKIDLane.ToString();
                }
                else
                {
                    spanValidateSKIDLane.Visible = false;
                    spanValidateSKIDLane.InnerText = string.Empty;
                }
                if (ValidateGPRSections > 0)
                {
                    spanValidateGPRSections.Visible = true;
                    spanValidateGPRSections.InnerText = ValidateGPRSections.ToString();
                }
                else
                {
                    spanValidateGPRSections.Visible = false;
                    spanValidateGPRSections.InnerText = string.Empty;
                }
                if (ValidateFWDSections > 0)
                {
                    spanValidateFWDSection.Visible = true;
                    spanValidateFWDSection.InnerText = ValidateFWDSections.ToString();
                }
                else
                {
                    spanValidateFWDSection.Visible = false;
                    spanValidateFWDSection.InnerText = string.Empty;
                }
                if (ValidateSKIDSections > 0)
                {
                    spanValidateSKIDSection.Visible = true;
                    spanValidateSKIDSection.InnerText = ValidateSKIDSections.ToString();
                }
                else
                {
                    spanValidateSKIDSection.Visible = false;
                    spanValidateSKIDSection.InnerText = string.Empty;
                }
                if (DistreesGPR > 0)
                {
                    spanDistreesGPR.Visible = true;
                    spanDistreesGPR.InnerText = DistreesGPR.ToString();
                }
                else
                {
                    spanDistreesGPR.Visible = false;
                    spanDistreesGPR.InnerText = string.Empty;
                }
                if (DistreesFWD > 0)
                {
                    spanDistreesFWD.Visible = true;
                    spanDistreesFWD.InnerText = DistreesFWD.ToString();
                }
                else
                {
                    spanDistreesFWD.Visible = false;
                    spanDistreesFWD.InnerText = string.Empty;
                }
                if (DistreesSKID > 0)
                {
                    spanDistreesSKID.Visible = true;
                    spanDistreesSKID.InnerText = DistreesSKID.ToString();
                }
                else
                {
                    spanDistreesSKID.Visible = false;
                    spanDistreesSKID.InnerText = string.Empty;
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
            }
        }
    }
}