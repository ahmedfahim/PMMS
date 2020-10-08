using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL.Tests;
using JpmmsClasses.BL.UDI;
using System.Drawing;
using Telerik.Charting;
using Telerik.Charting.Styles;

public partial class ASPX_Tests_ViewTestChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //RadChart1.HttpHandlerUrl = ResolveUrl("ChartImage.axd");
            //DataTable dtRates = UdiShared.GetDistrinctRates();

            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);


            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("ChartedPavementStatus.aspx", false);


            DataTable dt = new JpmmsCharting().GetSectionsRatingChart(int.Parse(Request.QueryString["id"]));

            chkMainStUDI.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            chkMainStUDI.PaletteCustomColors = new Color[] { Color.Green, Color.Yellow, Color.Blue, Color.Red };
            chkMainStUDI.Series[0].XValueMember = "u_rating";
            chkMainStUDI.Series[0].YValueMembers = "udi_rate_count";
            chkMainStUDI.Series[0].Label = "#PERCENT";
            chkMainStUDI.Series[0].LegendText = "#AXISLABEL";
            chkMainStUDI.DataSource = dt;
            chkMainStUDI.DataBind();

            chkMainstBars.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            chkMainstBars.PaletteCustomColors = new Color[] { Color.DarkSlateGray };
            chkMainstBars.Series[0].XValueMember = "u_rating";
            chkMainstBars.Series[0].YValueMembers = "udi_rate_count";
            chkMainstBars.DataSource = dt;
            chkMainstBars.DataBind();

            //RadChart1.DataSource = dt;
            //RadChart1.Series[0].DataYColumn = "udi_rate_count";
            //RadChart1.PlotArea.XAxis.DataLabelsColumn = "UDI_RATE";

            //RadChart1.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 300;
            //RadChart1.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Color = Color.BlueViolet;
            //RadChart1.PlotArea.Appearance.Dimensions.Margins.Bottom = Telerik.Charting.Styles.Unit.Percentage(30);
            //RadChart1.DataBind();

            //RadChart2.DataSource = dt;
            //foreach (DataRow dr in dtRates.Rows)
            //    RadChart2.Series.Add(new ChartSeries(dr["UDI_RATE"].ToString()));

            ////RadChart2.Series[0].DataYColumn = "udi_rate_count";
            //RadChart2.PlotArea.XAxis.DataLabelsColumn = "UDI_RATE";
            //RadChart2.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

}
