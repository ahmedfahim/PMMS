using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.UDI;
using System.Data;
using System.Drawing;

public partial class ASPX_Reports_ViewPavementStatusTotals : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                    Response.Redirect("~/ASPX/Default.aspx", false);
            }

            lblFeedback.Text = "";
            lblDateTime.Text = DateTime.Now.ToString("hh:mm dd/MM/yyyy");
            //if (Session["option"] != null) //!IsPostBack &&
            //{
            PavementStatusReport rpt = new UdiShared().GetAllPavementStatusTotals();
            lblTotalSections.Text = rpt.MainStSectionsTotal.ToString("N1");
            lblTotalIntersects.Text = rpt.MainStIntersectsTotal.ToString("N1");
            lblTotalMainSt.Text = rpt.MainStTotal.ToString("N1");

            lblRegionsTotal.Text = rpt.RegionsTotal.ToString("N1");
            lblTotal.Text = rpt.WholeNetworkTotal.ToString("N1");

            lblMainStTotalExcellent.Text = rpt.MainStTotalExcellent.ToString("N1");
            lblMainStTotalGood.Text = rpt.MainStTotalGood.ToString("N1");
            lblMainStTotalFair.Text = rpt.MainStTotalFair.ToString("N1");
            lblMainStTotalPoor.Text = rpt.MainStTotalPoor.ToString("N1");
            lblMainStTotal.Text = rpt.MainStTotal.ToString("N1");

            lblRegionsTotalExcellent.Text = rpt.RegionsTotalExcellent.ToString("N1");
            lblRegionsTotalGood.Text = rpt.RegionsTotalGood.ToString("N1");
            lblRegionsTotalFair.Text = rpt.RegionsTotalFair.ToString("N1");
            lblRegionsTotalPoor.Text = rpt.RegionsTotalPoor.ToString("N1");
            lblTotalRegions.Text = rpt.RegionsTotal.ToString("N1");


            DataTable dtMainSt = new DataTable();
            DataTable dtRegions = new DataTable();

            dtMainSt.Columns.Add(new DataColumn("u_rating", typeof(string)));
            dtMainSt.Columns.Add(new DataColumn("udi_rate_count", typeof(double)));

            dtMainSt.Rows.Add("Excellent", rpt.MainStTotalExcellent.ToString("N1"));
            dtMainSt.Rows.Add("Good", rpt.MainStTotalGood.ToString("N1"));
            dtMainSt.Rows.Add("Fair", rpt.MainStTotalFair.ToString("N1"));
            dtMainSt.Rows.Add("Poor", rpt.MainStTotalPoor.ToString("N1"));


            dtRegions.Columns.Add(new DataColumn("u_rating", typeof(string)));
            dtRegions.Columns.Add(new DataColumn("udi_rate_count", typeof(double)));

            dtRegions.Rows.Add("Excellent", rpt.RegionsTotalExcellent.ToString("N1"));
            dtRegions.Rows.Add("Good", rpt.RegionsTotalGood.ToString("N1"));
            dtRegions.Rows.Add("Fair", rpt.RegionsTotalFair.ToString("N1"));
            dtRegions.Rows.Add("Poor", rpt.RegionsTotalPoor.ToString("N1"));


            chtMainStUDI.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            chtMainStUDI.PaletteCustomColors = new Color[] { Color.Green, Color.Blue, Color.Yellow, Color.Red };
            chtMainStUDI.Series[0].XValueMember = "u_rating";
            chtMainStUDI.Series[0].YValueMembers = "udi_rate_count";
            chtMainStUDI.Series[0].Label = "#PERCENT";
            chtMainStUDI.Series[0].LegendText = "#AXISLABEL";
            chtMainStUDI.DataSource = dtMainSt;
            chtMainStUDI.DataBind();

            chtRegionsUDI.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            chtRegionsUDI.PaletteCustomColors = new Color[] { Color.Green, Color.Blue, Color.Yellow, Color.Red };
            chtRegionsUDI.Series[0].XValueMember = "u_rating";
            chtRegionsUDI.Series[0].YValueMembers = "udi_rate_count";
            chtRegionsUDI.Series[0].Label = "#PERCENT";
            chtRegionsUDI.Series[0].LegendText = "#AXISLABEL";
            chtRegionsUDI.DataSource = dtRegions;
            chtRegionsUDI.DataBind();
            //}
            //else
            //    Response.Redirect("PavementStatus.aspx", false);

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
        finally
        {
            Session["option"] = null;
        }
    }

}
