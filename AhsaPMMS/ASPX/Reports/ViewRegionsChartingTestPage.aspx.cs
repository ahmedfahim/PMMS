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

public partial class ASPX_Tests_ViewRegionsChartingTestPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[7] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);


            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("ChartedPavementStatus.aspx", false);


            DataTable dt = new JpmmsCharting().GetRegionsRatingChart(int.Parse(Request.QueryString["id"]));

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
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

}
