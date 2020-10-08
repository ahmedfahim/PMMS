using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Archive_LandingMFV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString.Count == 1)
            {
                spanDEquipStreet.Visible = false;
                spanDistressmanuale.Visible = false;
                spanDrawStreet.Visible = false;
                spanDrawUpdateStreet.Visible = false;
                spanEditStreet.Visible = false;
                spanEquipStreet.Visible = false;
                spanErorrIRI.Visible = false;
                spanExiststStreet.Visible = false;
                spanExiststStreetNext.Visible = false;
                spanFDrawStreet.Visible = false;
                spanFinshStreet.Visible = false;
                spanGisStreet.Visible = false;
                spanLaneDublicate.Visible = false;
                spanLaneDublicateIRI.Visible = false;
                spanLaneSampleErorr.Visible = false;
                spanLaneSecErorr.Visible = false;
                spanMainErorr.Visible = false;
                spanMinStreet.Visible = false;
                spanMinStreetSampleDelete.Visible = false;
                spanMissSample.Visible = false;
                spanNewStreet.Visible = false;
                spanNewStreetGIS.Visible = false;
                spanQDistrssStreet.Visible = false;
                spanQDrawStreet.Visible = false;
                spanSampleDublicate.Visible = false;
                spanSamplesAreaStreet.Visible = false;
                spanSecFromTO.Visible = false;
                spanSectionsErorrDistress.Visible = false;
                spanStreetsDeleted.Visible = false;
                spanStreetsErorr.Visible = false;
                spanUdiStreet.Visible = false;
                spanUpdateStreet.Visible = false;
                spanSectionsMainNOIRI.Visible = false;
                spanSectionsMainNODDF.Visible = false;
                spanErorrData.Visible = false;
                spanISNotComplete.Visible = false;
            }
            else
            {
                System.Data.DataTable dt = new MainStreet().CountMFV();

                int ISNotComplete = int.Parse(dt.Rows[0]["GetIsNotComplete"].ToString());
                int GisStreetOK = int.Parse(dt.Rows[0]["GetNewStreetsGisOK"].ToString());
                int NewStreetGIS = int.Parse(dt.Rows[0]["GetNewStreetsGis"].ToString());
                int NewStreet = int.Parse(dt.Rows[0]["GetFinshedSTREETSMFVCount"].ToString());
                int EditStreet = int.Parse(dt.Rows[0]["GetRecivedEditingIRI"].ToString());
                int UpdateStreet = int.Parse(dt.Rows[0]["GetRecivedEditIRI"].ToString());
                int FinshStreet = int.Parse(dt.Rows[0]["GetRecivedFinshedIRI"].ToString());
                int DrawStreet = int.Parse(dt.Rows[0]["GetRecivedDrawingIRI"].ToString());
                int FDrawStreet = int.Parse(dt.Rows[0]["GetRecivedCompleteDrawingIRI"].ToString());
                int QDrawStreet = int.Parse(dt.Rows[0]["GetRecivedFinshedIRIANALYZE"].ToString());
                int EquipStreet = int.Parse(dt.Rows[0]["FinshedRrturnToMFV"].ToString());
                int DEquipStreet = int.Parse(dt.Rows[0]["FinshedRrturnToMFVDelete"].ToString());
                int LaneDublicate = int.Parse(dt.Rows[0]["GetStreetsDublicateLanes"].ToString());
                int LaneSecErorr = int.Parse(dt.Rows[0]["GetErorrSectionLane"].ToString());
                int LaneSampleErorr = int.Parse(dt.Rows[0]["GetStreetsSampleExceed"].ToString());
                int ExiststStreet = int.Parse(dt.Rows[0]["GetRecivedMFV"].ToString());
                int ExiststStreetNext = int.Parse(dt.Rows[0]["GetRecivedMFVNext"].ToString());
                int ErorrIRI = int.Parse(dt.Rows[0]["GetStreetsUpdateErorrIRI"].ToString());
                int SampleDublicate = int.Parse(dt.Rows[0]["GetStreetsSampleDublicateIRI"].ToString());
                int StreetsErorr = int.Parse(dt.Rows[0]["GetStreetsERorrIRI"].ToString());
                int QDistrssStreet = int.Parse(dt.Rows[0]["GetDistressCount"].ToString());
                int UdiStreet = int.Parse(dt.Rows[0]["GetUDICount"].ToString());
                int MinStreet = int.Parse(dt.Rows[0]["GetMINCount"].ToString());
                int DrawUpdateStreet = int.Parse(dt.Rows[0]["GetDrawUpdateSections"].ToString());
                int SampleDelete = int.Parse(dt.Rows[0]["GetDeletedSamples"].ToString());
                int Distressmanuale = int.Parse(dt.Rows[0]["Distressmanuale"].ToString());
                int StreetsDeleted = int.Parse(dt.Rows[0]["GetStreetDeleted"].ToString());
                int ErorrData = int.Parse(dt.Rows[0]["CountErorrData"].ToString());

                int SamplesAreaStreet = 0, MissSample = 0, LaneDublicateIRI = 0, SectionsErorrDistress = 0;
                if (DrawStreet > 0 || FinshStreet > 0 || DrawStreet > 0 || EditStreet > 0 || QDrawStreet > 0)
                {
                    MissSample = new MainStreet().GetStreetsSampleNotFoundIRI().Rows.Count;
                    LaneDublicateIRI = new MainStreet().GetStreetsDublicateLanesIRI(null).Rows.Count;
                    System.Data.DataTable dtDistressIRI = new MainStreet().CountSectionsErorrDistressIRI();
                    SectionsErorrDistress = dtDistressIRI.Rows.Count == 1 && dtDistressIRI.Rows[0][0].ToString() == "0" ? 0 : int.Parse(dtDistressIRI.Rows[0][0].ToString());
                    if (QDrawStreet > 0 || FinshStreet > 0)
                    {
                        if (new MainStreet().CheckGetLaneSamplesArea())
                        {
                            System.Data.DataTable dtArea = new MainStreet().GetLaneSamplesArea(true);
                            SamplesAreaStreet = dtArea.Rows.Count == 1 && dtArea.Rows[0][0].ToString() == "0" ? 0 : int.Parse(dtArea.Rows[0][0].ToString());
                        }
                    }
                }
                if (ISNotComplete > 0)
                {
                    spanISNotComplete.Visible = true;
                    spanISNotComplete.InnerText = ISNotComplete.ToString();
                }
                else
                {
                    spanISNotComplete.Visible = false;
                    spanISNotComplete.InnerText = string.Empty;
                }
                if (ErorrData > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = ErorrData.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
                if (StreetsDeleted > 0)
                {
                    spanStreetsDeleted.Visible = true;
                    spanStreetsDeleted.InnerText = StreetsDeleted.ToString();
                }
                else
                {
                    spanStreetsDeleted.Visible = false;
                    spanStreetsDeleted.InnerText = string.Empty;
                }
                if (Distressmanuale > 0)
                {
                    spanDistressmanuale.Visible = true;
                    spanDistressmanuale.InnerText = Distressmanuale.ToString();
                }
                else
                {
                    spanDistressmanuale.Visible = false;
                    spanDistressmanuale.InnerText = string.Empty;
                }
                if (SampleDelete > 0)
                {
                    spanMinStreetSampleDelete.Visible = true;
                    spanMinStreetSampleDelete.InnerText = SampleDelete.ToString();
                }
                else
                {
                    spanMinStreetSampleDelete.Visible = false;
                    spanMinStreetSampleDelete.InnerText = string.Empty;
                }
                if (NewStreetGIS > 0)
                {
                    spanNewStreetGIS.Visible = true;
                    spanNewStreetGIS.InnerText = NewStreetGIS.ToString();
                }
                else
                {
                    spanNewStreetGIS.Visible = false;
                    spanNewStreetGIS.InnerText = string.Empty;
                }
                if (GisStreetOK > 0)
                {
                    spanGisStreet.Visible = true;
                    spanGisStreet.InnerText = GisStreetOK.ToString();
                }
                else
                {
                    spanGisStreet.Visible = false;
                    spanGisStreet.InnerText = string.Empty;
                }
                if (NewStreet > 0)
                {
                    spanNewStreet.Visible = true;
                    spanNewStreet.InnerText = NewStreet.ToString();
                }
                else
                {
                    spanNewStreet.Visible = false;
                    spanNewStreet.InnerText = string.Empty;
                }
                if (EditStreet > 0)
                {
                    spanEditStreet.Visible = true;
                    spanEditStreet.InnerText = EditStreet.ToString();
                }
                else
                {
                    spanEditStreet.Visible = false;
                    spanEditStreet.InnerText = string.Empty;
                }
                if (UpdateStreet > 0)
                {
                    spanUpdateStreet.Visible = true;
                    spanUpdateStreet.InnerText = UpdateStreet.ToString();
                }
                else
                {
                    spanUpdateStreet.Visible = false;
                    spanUpdateStreet.InnerText = string.Empty;
                }
                if (FinshStreet > 0)
                {
                    spanFinshStreet.Visible = true;
                    spanFinshStreet.InnerText = FinshStreet.ToString();
                }
                else
                {
                    spanFinshStreet.Visible = false;
                    spanFinshStreet.InnerText = string.Empty;
                }
                if (DrawStreet > 0)
                {
                    spanDrawStreet.Visible = true;
                    spanDrawStreet.InnerText = DrawStreet.ToString();
                }
                else
                {
                    spanDrawStreet.Visible = false;
                    spanDrawStreet.InnerText = string.Empty;
                }
                if (QDrawStreet > 0)
                {
                    spanQDrawStreet.Visible = true;
                    spanQDrawStreet.InnerText = QDrawStreet.ToString();
                }
                else
                {
                    spanQDrawStreet.Visible = false;
                    spanQDrawStreet.InnerText = string.Empty;
                }
                if (FDrawStreet > 0)
                {
                    spanFDrawStreet.Visible = true;
                    spanFDrawStreet.InnerText = FDrawStreet.ToString();
                }
                else
                {
                    spanFDrawStreet.Visible = false;
                    spanFDrawStreet.InnerText = string.Empty;
                }
                if (EquipStreet > 0)
                {
                    spanEquipStreet.Visible = true;
                    spanEquipStreet.InnerText = EquipStreet.ToString();
                }
                else
                {
                    spanEquipStreet.Visible = false;
                    spanEquipStreet.InnerText = string.Empty;
                }
                if (DEquipStreet > 0)
                {
                    spanDEquipStreet.Visible = true;
                    spanDEquipStreet.InnerText = DEquipStreet.ToString();
                }
                else
                {
                    spanDEquipStreet.Visible = false;
                    spanDEquipStreet.InnerText = string.Empty;
                }
                if (ExiststStreet > 0)
                {
                    spanExiststStreet.Visible = true;
                    spanExiststStreet.InnerText = ExiststStreet.ToString();
                }
                else
                {
                    spanExiststStreet.Visible = false;
                    spanExiststStreet.InnerText = string.Empty;
                }
                if (ExiststStreetNext > 0)
                {
                    spanExiststStreetNext.Visible = true;
                    spanExiststStreetNext.InnerText = ExiststStreetNext.ToString();
                }
                else
                {
                    spanExiststStreetNext.Visible = false;
                    spanExiststStreetNext.InnerText = string.Empty;
                }
                if (SampleDublicate > 0)
                {
                    spanSampleDublicate.Visible = true;
                    spanSampleDublicate.InnerText = SampleDublicate.ToString();
                }
                else
                {
                    spanSampleDublicate.Visible = false;
                    spanSampleDublicate.InnerText = string.Empty;
                }
                if (LaneDublicate > 0)
                {
                    spanLaneDublicate.Visible = true;
                    spanLaneDublicate.InnerText = LaneDublicate.ToString();
                }
                else
                {
                    spanLaneDublicate.Visible = false;
                    spanLaneDublicate.InnerText = string.Empty;
                }
                if (MissSample > 0)
                {
                    spanMissSample.Visible = true;
                    spanMissSample.InnerText = MissSample.ToString();
                }
                else
                {
                    spanMissSample.Visible = false;
                    spanMissSample.InnerText = string.Empty;
                }
                if (LaneSecErorr > 0)
                {
                    spanLaneSecErorr.Visible = true;
                    spanLaneSecErorr.InnerText = LaneSecErorr.ToString();
                }
                else
                {
                    spanLaneSecErorr.Visible = false;
                    spanLaneSecErorr.InnerText = string.Empty;
                }

                if (ErorrIRI > 0)
                {
                    spanErorrIRI.Visible = true;
                    spanErorrIRI.InnerText = ErorrIRI.ToString();
                }
                else
                {
                    spanErorrIRI.Visible = false;
                    spanErorrIRI.InnerText = string.Empty;
                }
                if (LaneDublicateIRI > 0)
                {
                    spanLaneDublicateIRI.Visible = true;
                    spanLaneDublicateIRI.InnerText = LaneDublicateIRI.ToString();
                }
                else
                {
                    spanLaneDublicateIRI.Visible = false;
                    spanLaneDublicateIRI.InnerText = string.Empty;
                }
                if (LaneSampleErorr > 0)
                {
                    spanLaneSampleErorr.Visible = true;
                    spanLaneSampleErorr.InnerText = LaneSampleErorr.ToString();
                }
                else
                {
                    spanLaneSampleErorr.Visible = false;
                    spanLaneSampleErorr.InnerText = string.Empty;
                }
                if (StreetsErorr > 0)
                {
                    spanStreetsErorr.Visible = true;
                    spanStreetsErorr.InnerText = StreetsErorr.ToString();
                }
                else
                {
                    spanStreetsErorr.Visible = false;
                    spanStreetsErorr.InnerText = string.Empty;
                }
                if (QDistrssStreet > 0)
                {
                    spanQDistrssStreet.Visible = true;
                    spanQDistrssStreet.InnerText = QDistrssStreet.ToString();
                }
                else
                {
                    spanQDistrssStreet.Visible = false;
                    spanQDistrssStreet.InnerText = string.Empty;
                }
                if (UdiStreet > 0)
                {
                    spanUdiStreet.Visible = true;
                    spanUdiStreet.InnerText = UdiStreet.ToString();
                }
                else
                {
                    spanUdiStreet.Visible = false;
                    spanUdiStreet.InnerText = string.Empty;
                }
                if (MinStreet > 0)
                {
                    spanMinStreet.Visible = true;
                    spanMinStreet.InnerText = MinStreet.ToString();
                }
                else
                {
                    spanMinStreet.Visible = false;
                    spanMinStreet.InnerText = string.Empty;
                }
                if (DrawUpdateStreet > 0)
                {
                    spanDrawUpdateStreet.Visible = true;
                    spanDrawUpdateStreet.InnerText = DrawUpdateStreet.ToString();
                }
                else
                {
                    spanDrawUpdateStreet.Visible = false;
                    spanDrawUpdateStreet.InnerText = string.Empty;
                }
                if (SamplesAreaStreet > 0)
                {
                    spanSamplesAreaStreet.Visible = true;
                    spanSamplesAreaStreet.InnerText = SamplesAreaStreet.ToString();
                }
                else
                {
                    spanSamplesAreaStreet.Visible = false;
                    spanSamplesAreaStreet.InnerText = string.Empty;
                }
                if (SectionsErorrDistress > 0)
                {
                    spanSectionsErorrDistress.Visible = true;
                    spanSectionsErorrDistress.InnerText = SectionsErorrDistress.ToString();
                }
                else
                {
                    spanSectionsErorrDistress.Visible = false;
                    spanSectionsErorrDistress.InnerText = string.Empty;
                }
            }
        }
    }
   
}