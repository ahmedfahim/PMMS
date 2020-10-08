using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ASPX_Archive_LandingWorkOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
        {
            if (Request.QueryString.Count == 1)
            {
                spanInterSectionsExcellent.Visible = false;
                spanInterSectionsPoor.Visible = false;
                spanInterSectionWorkorderMin.Visible = false;
                spanInterSectionWorkorderUdi.Visible = false;
                spanRegionsExcellent.Visible = false;
                spanRegionsPoor.Visible = false;
                spanRegionsWorkorderMin.Visible = false;
                spanRegionsWorkorderUdi.Visible = false;
                spanSectionsExcellent.Visible = false;
                spanSectionsPoor.Visible = false;
                spanSectionWorkorderMin.Visible = false;
                spanSectionWorkorderUdi.Visible = false;
            }
            else
            {
                System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().CountUDI();
                System.Data.DataTable dtMinRegions = new JpmmsClasses.BL.Lookups.SystemUsers().GetReceivedMaintinanceStreets();

                int SectionsExcellent = 0;
                int SectionsPoor = 0;
                int SectionWorkorderMin = 0;
                int SectionWorkorderUdi = 0;
                int RegionsExcellent = int.Parse(dt.Rows[0]["CountRegionsExcellent"].ToString());
                int RegionsPoor = int.Parse(dt.Rows[0]["CountRegionsPoor"].ToString());
                int RegionsWorkorderUdi = int.Parse(dt.Rows[0]["TOTALUDI"].ToString());
                int RegionsWorkorderMin = dtMinRegions.Rows.Count;

                int InterSectionsExcellent = 0;
                int InterSectionsPoor = 0;
                int InterSectionWorkorderMin = 0;
                int InterSectionWorkorderUdi = 0;


                if (SectionsExcellent > 0)
                {
                    spanSectionsExcellent.Visible = true;
                    spanSectionsExcellent.InnerText = SectionsExcellent.ToString();
                }
                else
                {
                    spanSectionsExcellent.Visible = false;
                    spanSectionsExcellent.InnerText = string.Empty;
                }
                if (SectionsPoor > 0)
                {
                    spanSectionsPoor.Visible = true;
                    spanSectionsPoor.InnerText = SectionsPoor.ToString();
                }
                else
                {
                    spanSectionsPoor.Visible = false;
                    spanSectionsPoor.InnerText = string.Empty;
                }
                if (SectionWorkorderMin > 0)
                {
                    spanSectionWorkorderMin.Visible = true;
                    spanSectionWorkorderMin.InnerText = SectionWorkorderMin.ToString();
                }
                else
                {
                    spanSectionWorkorderMin.Visible = false;
                    spanSectionWorkorderMin.InnerText = string.Empty;
                }
                if (SectionWorkorderUdi > 0)
                {
                    spanSectionWorkorderUdi.Visible = true;
                    spanSectionWorkorderUdi.InnerText = SectionWorkorderUdi.ToString();
                }
                else
                {
                    spanSectionWorkorderUdi.Visible = false;
                    spanSectionWorkorderUdi.InnerText = string.Empty;
                }
                if (RegionsExcellent > 0)
                {
                    spanRegionsExcellent.Visible = true;
                    spanRegionsExcellent.InnerText = RegionsExcellent.ToString();
                }
                else
                {
                    spanRegionsExcellent.Visible = false;
                    spanRegionsExcellent.InnerText = string.Empty;
                }
                if (RegionsPoor > 0)
                {
                    spanRegionsPoor.Visible = true;
                    spanRegionsPoor.InnerText = RegionsPoor.ToString();
                }
                else
                {
                    spanRegionsPoor.Visible = false;
                    spanRegionsPoor.InnerText = string.Empty;
                }
                if (RegionsWorkorderUdi > 0)
                {
                    spanRegionsWorkorderUdi.Visible = true;
                    spanRegionsWorkorderUdi.InnerText = RegionsWorkorderUdi.ToString();
                }
                else
                {
                    spanRegionsWorkorderUdi.Visible = false;
                    spanRegionsWorkorderUdi.InnerText = string.Empty;
                }
                if (RegionsWorkorderMin > 0)
                {
                    RegionsWorkorderMin = 0;
                    for (int i = 0; i < dtMinRegions.Rows.Count; i++)
                    {
                        if (dtMinRegions.Rows[i][1].ToString() != (int.Parse(dtMinRegions.Rows[i][0].ToString()) + int.Parse(dtMinRegions.Rows[i][2].ToString())).ToString())
                            RegionsWorkorderMin++;
                    }
                    spanRegionsWorkorderMin.Visible = true;
                    spanRegionsWorkorderMin.InnerText = RegionsWorkorderMin.ToString();
                }
                else
                {
                    spanRegionsWorkorderMin.Visible = false;
                    spanRegionsWorkorderMin.InnerText = string.Empty;
                }

                if (InterSectionsExcellent > 0)
                {
                    spanInterSectionsExcellent.Visible = true;
                    spanInterSectionsExcellent.InnerText = SectionsExcellent.ToString();
                }
                else
                {
                    spanInterSectionsExcellent.Visible = false;
                    spanInterSectionsExcellent.InnerText = string.Empty;
                }
                if (InterSectionsPoor > 0)
                {
                    spanInterSectionsPoor.Visible = true;
                    spanInterSectionsPoor.InnerText = InterSectionsPoor.ToString();
                }
                else
                {
                    spanInterSectionsPoor.Visible = false;
                    spanInterSectionsPoor.InnerText = string.Empty;
                }
                if (InterSectionWorkorderMin > 0)
                {
                    spanInterSectionWorkorderMin.Visible = true;
                    spanInterSectionWorkorderMin.InnerText = InterSectionWorkorderMin.ToString();
                }
                else
                {
                    spanInterSectionWorkorderMin.Visible = false;
                    spanInterSectionWorkorderMin.InnerText = string.Empty;
                }
                if (InterSectionWorkorderUdi > 0)
                {
                    spanInterSectionWorkorderUdi.Visible = true;
                    spanInterSectionWorkorderUdi.InnerText = InterSectionWorkorderUdi.ToString();
                }
                else
                {
                    spanInterSectionWorkorderUdi.Visible = false;
                    spanInterSectionWorkorderUdi.InnerText = string.Empty;
                }
            }
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

    }
}