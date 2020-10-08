using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_LandingInterSections : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString.Count == 1)
            {
                spanIntersectionsEditReady.Visible = false;
                spanIntersectionsReady.Visible = false;
                spanInterSectionsFinshed.Visible = false;
                spanInterSectionsNotFinshed.Visible = false;
                spanInterSectionsReportReview.Visible = false;
                spanInterSectionsClearance.Visible = false;
                spanInterSectionsMissing.Visible = false;
                spanValidateAREA.Visible = false;
                spanInsertGis.Visible = false;
                spanQcUdi.Visible = false;
                spanIntersectionArea.Visible = false;
            }
            else
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().CounIntersectionsUdiMin();
                int IntersectionsEditReady = int.Parse(dt.Rows[0]["TOTALIntersectionsEditReady"].ToString());
                int IntersectionsReady = int.Parse(dt.Rows[0]["TOTALIntersectionsReady"].ToString());
                int InterSectionsNotFinshed = int.Parse(dt.Rows[0]["CountInterSectionsNotFinshed"].ToString());
                int InterSectionsFinshed = int.Parse(dt.Rows[0]["CountInterSectionsFinshed"].ToString());
                int InterSectionsReportReview = int.Parse(dt.Rows[0]["CountInterSectionsReports"].ToString());
                int InterSectionsClearance = int.Parse(dt.Rows[0]["CountInterSectionsClearance"].ToString());
                int InterSectionsMissing = int.Parse(dt.Rows[0]["CountInterSectionsMissing"].ToString());
                int ValidateAREA = int.Parse(dt.Rows[0]["CountAREA"].ToString());
                int InsertGis = int.Parse(dt.Rows[0]["CountGis"].ToString());
                int IntersectionArea = int.Parse(dt.Rows[0]["CountExceedArea"].ToString());
                int QcUdi = int.Parse(dt.Rows[0]["CountQcUDI"].ToString());

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
                if (IntersectionArea > 0)
                {
                    spanIntersectionArea.Visible = true;
                    spanIntersectionArea.InnerText = IntersectionArea.ToString();
                }
                else
                {
                    spanIntersectionArea.Visible = false;
                    spanIntersectionArea.InnerText = string.Empty;
                }
                if (InsertGis > 0)
                {
                    spanInsertGis.Visible = true;
                    spanInsertGis.InnerText = InsertGis.ToString();
                }
                else
                {
                    spanInsertGis.Visible = false;
                    spanInsertGis.InnerText = string.Empty;
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
                if (InterSectionsMissing > 0)
                {
                    spanInterSectionsMissing.Visible = true;
                    spanInterSectionsMissing.InnerText = InterSectionsMissing.ToString();
                }
                else
                {
                    spanInterSectionsMissing.Visible = false;
                    spanInterSectionsMissing.InnerText = string.Empty;
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
                if (InterSectionsNotFinshed > 0)
                {
                    spanInterSectionsNotFinshed.Visible = true;
                    spanInterSectionsNotFinshed.InnerText = InterSectionsNotFinshed.ToString();
                }
                else
                {
                    spanInterSectionsNotFinshed.Visible = false;
                    spanInterSectionsNotFinshed.InnerText = string.Empty;
                }
                if (InterSectionsFinshed > 0)
                {
                    spanInterSectionsFinshed.Visible = true;
                    spanInterSectionsFinshed.InnerText = InterSectionsFinshed.ToString();
                }
                else
                {
                    spanInterSectionsFinshed.Visible = false;
                    spanInterSectionsFinshed.InnerText = string.Empty;
                }
                if (InterSectionsReportReview > 0)
                {
                    spanInterSectionsReportReview.Visible = true;
                    spanInterSectionsReportReview.InnerText = InterSectionsReportReview.ToString();
                }
                else
                {
                    spanInterSectionsReportReview.Visible = false;
                    spanInterSectionsReportReview.InnerText = string.Empty;
                }
                if (IntersectionsEditReady > 0)
                {
                    spanIntersectionsEditReady.Visible = true;
                    spanIntersectionsEditReady.InnerText = IntersectionsEditReady.ToString();
                }
                else
                {
                    spanIntersectionsEditReady.Visible = false;
                    spanIntersectionsEditReady.InnerText = string.Empty;
                }
                if (IntersectionsReady > 0)
                {
                    spanIntersectionsReady.Visible = true;
                    spanIntersectionsReady.InnerText = IntersectionsReady.ToString();
                }
                else
                {
                    spanIntersectionsReady.Visible = false;
                    spanIntersectionsReady.InnerText = string.Empty;
                }
            }
        }

    }
}