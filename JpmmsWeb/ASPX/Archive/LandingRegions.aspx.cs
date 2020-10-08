using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_LandingRegions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString.Count == 1)
            {
                spanQcMain.Visible = false;
                spanQcUdi.Visible = false;
                spanRegionsClosedNote.Visible = false;
                spanRegionsColsed.Visible = false;
                spanRegionsError.Visible = false;
                spanRegionsFinshed.Visible = false;
                spanRegionsLength.Visible = false;
                spanRegionsNotFinshed.Visible = false;
                spanRegionsOpend.Visible = false;
                spanRegionsOpenedNote.Visible = false;
                spanRegionsReportReview.Visible = false;
                spanRegionsWidth.Visible = false;
                spanSecoundStreets.Visible = false;
                spanValidateAREA.Visible = false;
                spanValidateReports.Visible = false;
                spanNewStreets.Visible = false;
                spanNewStreetsQC.Visible = false;
                spanDublicateStreets.Visible = false;
            }
            else
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().CountRegionsUdiMin();
                int RegionsClosed = int.Parse(dt.Rows[0]["TOTALRegionsClosed"].ToString());
                int RegionsOpend = int.Parse(dt.Rows[0]["TOTALRegionsOpend"].ToString());
                int RegionsWidth = int.Parse(dt.Rows[0]["CountStreetWidth"].ToString());
                int RegionsLength = int.Parse(dt.Rows[0]["CountStreetLength"].ToString());
                int RegionsClosedNote = int.Parse(dt.Rows[0]["CountRegionsClosedNote"].ToString());
                int RegionsOpenedNote = int.Parse(dt.Rows[0]["CountRegionsOpenedNote"].ToString());
                int SecoundStreets = int.Parse(dt.Rows[0]["CountSECOND_ST"].ToString());
                int RegionsError = new JpmmsClasses.BL.Region().GetAllRegionsErorrs().Rows.Count;
                int RegionsNotFinshed = int.Parse(dt.Rows[0]["CountRegionsNotFinshed"].ToString());
                int RegionsFinshed = int.Parse(dt.Rows[0]["CountRegionFinshed"].ToString());
                int RegionsReportReview = int.Parse(dt.Rows[0]["CountRegionsReports"].ToString());
                int QcUdi = int.Parse(dt.Rows[0]["CountRegionsNoUdi"].ToString());
                int ValidateAREA = int.Parse(dt.Rows[0]["CountAREA"].ToString());
                int ValidateReports = int.Parse(dt.Rows[0]["CountReports"].ToString());
                int NewStreets = int.Parse(dt.Rows[0]["CountNewStreets"].ToString());
                int NewStreetsQC = int.Parse(dt.Rows[0]["CountNewStreetsQC"].ToString());
                int DublicateStreets = int.Parse(dt.Rows[0]["GetDublicateStreets"].ToString());

                if (DublicateStreets > 0)
                {
                    spanDublicateStreets.Visible = true;
                    spanDublicateStreets.InnerText = DublicateStreets.ToString();
                }
                else
                {
                    spanDublicateStreets.Visible = false;
                    spanDublicateStreets.InnerText = string.Empty;
                }
                if (NewStreetsQC > 0)
                {
                    spanNewStreetsQC.Visible = true;
                    spanNewStreetsQC.InnerText = NewStreetsQC.ToString();
                }
                else
                {
                    spanNewStreetsQC.Visible = false;
                    spanNewStreetsQC.InnerText = string.Empty;
                }
                if (NewStreets > 0)
                {
                    spanNewStreets.Visible = true;
                    spanNewStreets.InnerText = NewStreets.ToString();
                }
                else
                {
                    spanNewStreets.Visible = false;
                    spanNewStreets.InnerText = string.Empty;
                }
                if (ValidateReports > 0)
                {
                    spanValidateReports.Visible = true;
                    spanValidateReports.InnerText = ValidateReports.ToString();
                }
                else
                {
                    spanValidateReports.Visible = false;
                    spanValidateReports.InnerText = string.Empty;
                }
                if (ValidateAREA > 0)
                {
                    spanValidateAREA.Visible = true;
                    spanValidateAREA.InnerText = ValidateAREA.ToString();
                }
                else
                {
                    spanValidateAREA.Visible = false;
                    spanValidateAREA.InnerText = string.Empty;
                }
                //int QcMain = int.Parse(dt.Rows[0]["CountRegionsNoMin"].ToString());
                int QcMain = 0;// Convert.ToInt32(new JpmmsClasses.BL.MainStreet().CountRegionsNoMin());
                if (RegionsReportReview > 0)
                {
                    spanRegionsReportReview.Visible = true;
                    spanRegionsReportReview.InnerText = RegionsReportReview.ToString();
                }
                else
                {
                    spanRegionsReportReview.Visible = false;
                    spanRegionsReportReview.InnerText = string.Empty;
                }
                if (RegionsFinshed > 0)
                {
                    spanRegionsFinshed.Visible = true;
                    spanRegionsFinshed.InnerText = RegionsFinshed.ToString();
                }
                else
                {
                    spanRegionsFinshed.Visible = false;
                    spanRegionsFinshed.InnerText = string.Empty;
                }
                if (RegionsNotFinshed > 0)
                {
                    spanRegionsNotFinshed.Visible = true;
                    spanRegionsNotFinshed.InnerText = RegionsNotFinshed.ToString();
                }
                else
                {
                    spanRegionsNotFinshed.Visible = false;
                    spanRegionsNotFinshed.InnerText = string.Empty;
                }
                if (RegionsError > 0)
                {
                    spanRegionsError.Visible = true;
                    spanRegionsError.InnerText = RegionsError.ToString();
                }
                else
                {
                    spanRegionsError.Visible = false;
                    spanRegionsError.InnerText = string.Empty;
                }
                if (SecoundStreets > 0)
                {
                    spanSecoundStreets.Visible = true;
                    spanSecoundStreets.InnerText = SecoundStreets.ToString();
                }
                else
                {
                    spanSecoundStreets.Visible = false;
                    spanSecoundStreets.InnerText = string.Empty;
                }
                if (QcUdi > 0)
                {
                    spanQcUdi.Visible = true;
                    spanQcUdi.InnerText = QcUdi.ToString();
                }
                else
                {
                    spanQcUdi.Visible = false;
                    spanQcUdi.InnerText = string.Empty;
                }
                if (QcMain > 0)
                {
                    spanQcMain.Visible = true;
                    spanQcMain.InnerText = QcMain.ToString();
                }
                else
                {
                    spanQcMain.Visible = false;
                    spanQcMain.InnerText = string.Empty;
                }
                if (RegionsClosedNote > 0)
                {
                    spanRegionsClosedNote.Visible = true;
                    spanRegionsClosedNote.InnerText = RegionsClosedNote.ToString();
                }
                else
                {
                    spanRegionsClosedNote.Visible = false;
                    spanRegionsClosedNote.InnerText = string.Empty;
                }
                if (RegionsOpenedNote > 0)
                {
                    spanRegionsOpenedNote.Visible = true;
                    spanRegionsOpenedNote.InnerText = RegionsOpenedNote.ToString();
                }
                else
                {
                    spanRegionsOpenedNote.Visible = false;
                    spanRegionsOpenedNote.InnerText = string.Empty;
                }
                if (RegionsClosed > 0)
                {
                    spanRegionsColsed.Visible = true;
                    spanRegionsColsed.InnerText = RegionsClosed.ToString();
                }
                else
                {
                    spanRegionsColsed.Visible = false;
                    spanRegionsColsed.InnerText = string.Empty;
                }
                if (RegionsOpend > 0)
                {
                    spanRegionsOpend.Visible = true;
                    spanRegionsOpend.InnerText = RegionsOpend.ToString();
                }
                else
                {
                    spanRegionsOpend.Visible = false;
                    spanRegionsOpend.InnerText = string.Empty;
                }
                if (RegionsWidth > 0)
                {
                    spanRegionsWidth.Visible = true;
                    spanRegionsWidth.InnerText = RegionsWidth.ToString();
                }
                else
                {
                    spanRegionsWidth.Visible = false;
                    spanRegionsWidth.InnerText = string.Empty;
                }
                if (RegionsLength > 0)
                {
                    spanRegionsLength.Visible = true;
                    spanRegionsLength.InnerText = RegionsLength.ToString();
                }
                else
                {
                    spanRegionsLength.Visible = false;
                    spanRegionsLength.InnerText = string.Empty;
                }
            }
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

    }
}