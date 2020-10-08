using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESRI.ArcGIS.ADF.Web.UI.WebControls;
using System.Configuration;

public partial class Secret_Map_frmGoogle_Maps : System.Web.UI.Page
{
    //private bool _hasNonPooledResources = false;

    #region Page Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Map1.MapResourceManager == null || Map1.MapResourceManager.Length == 0)
                callErrorPage("No Map Resource Manager defined for the Map.", null);
            if (MapResourceManager1.ResourceItems.Count == 0)
                callErrorPage("The Map Resource Manager does not have a valid Resouce Item.", null);
            if (Map1.PrimaryMapResourceInstance == null)
                callErrorPage("The Map does not have a valid Primary Map Resource.", null);
        }

        // Check for locale decimal delimiter and pass to client side
        string delimiterScript = "var webMapAppDecimalDelimiter = '" + GetDecimalSeparatorFromLocale() + "';";
        if (!Page.ClientScript.IsClientScriptBlockRegistered("decimalDelimiterScript"))
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "decimalDelimiterScript", delimiterScript, true);
    }

    /// <summary>
    /// Handles Page's PreRenderComplete.
    /// </summary>
    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            // add separator between each task in task menu

            Map map = Map1;


            // Remove the overview toggle it overviewmap doesn't exist, and identify if none of the resources support it.
            OverviewMap ov = Page.FindControl("OverviewMap1") as OverviewMap;
            Magnifier magnifier = Page.FindControl("Magnifier1") as Magnifier;
            bool supportsIdentify = true;
            bool canMeasure = true;
            //if (Measure1.MapUnits == MapUnit.Resource_Default)
            //    canMeasure = Measure1.CanGetUnits();
            Toolbar tb = Page.FindControl("Toolbar1") as Toolbar;
            if (tb != null)
            {
                for (int t = tb.ToolbarItems.Count - 1; t >= 0; t--)
                {
                    ToolbarItem item = tb.ToolbarItems[t];
                    if (item.Name == "OverviewMapToggle" && ov == null)
                        tb.ToolbarItems.Remove(item);
                    if (item.Name == "MapIdentify" && !supportsIdentify)
                        tb.ToolbarItems.Remove(item);
                    if (item.Name == "Measure" && !canMeasure)
                        tb.ToolbarItems.Remove(item);
                    if (item.Name == "Magnifier" && magnifier == null)
                        tb.ToolbarItems.Remove(item);
                }
            }
        }

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // Enforce SSL requirement.
        bool requireSSL = false;
        if (!Page.IsPostBack && ConfigurationManager.AppSettings["RequireSSL"] != null)
        {
            bool.TryParse(ConfigurationManager.AppSettings["RequireSSL"], out requireSSL);
            if (requireSSL && !Request.IsSecureConnection)
            {
                Response.Redirect(Request.Url.ToString().Replace("http://", "https://"));
                return;
            }
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (Request.QueryString["resetSession"] == "true")
        {
            // Allows client applications (such as Manager) to pass in a query string
            // to clear out session state for ADF controls.             
            Session.RemoveAll();
            Response.Redirect("~/default.aspx");
        }
        base.OnPreInit(e);
    }

    private char GetDecimalSeparatorFromLocale()
    {
        return (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray())[0];
    }

    #endregion

    #region Error Handlers
    /// <summary>
    /// Handles unhandled exceptions in the page.
    /// </summary>
    protected void Page_Error(object sender, System.EventArgs e)
    {
        Exception exception = Server.GetLastError();
        Server.ClearError();
        callErrorPage("Page_Error", exception);
    }

    /// <summary>
    /// Displays the error page.
    /// </summary>
    private void callErrorPage(string errorMessage, Exception exception)
    {
        Session["ErrorMessage"] = errorMessage;
        Session["Error"] = exception;
        Page.Response.Redirect("ErrorPage.aspx", true);
    }
    #endregion

    #region ResourceManager Methods
    /// <summary>
    /// Handles ResourceManager ResourceInit event
    /// </summary>
    protected void ResourceManager_ResourceInit(object sender, EventArgs e)
    {
        if (DesignMode)
            return;
        ResourceManager manager = sender as ResourceManager;
        if (!manager.FailureOnInitialize)
            return;
        if (manager is MapResourceManager)
        {
            MapResourceManager mapManager = manager as MapResourceManager;
            for (int i = 0; i < mapManager.ResourceItems.Count; i++)
            {
                MapResourceItem item = mapManager.ResourceItems[i];
                if (item != null && item.FailedToInitialize)
                {
                    mapManager.ResourceItems[i] = null;
                }
            }
        }
        else if (manager is GeocodeResourceManager)
        {
            GeocodeResourceManager gcManager = manager as GeocodeResourceManager;
            for (int i = 0; i < gcManager.ResourceItems.Count; i++)
            {
                GeocodeResourceItem item = gcManager.ResourceItems[i];
                if (item != null && item.FailedToInitialize)
                {
                    gcManager.ResourceItems[i] = null;
                }
            }
        }
        else if (manager is GeoprocessingResourceManager)
        {
            GeoprocessingResourceManager gpManager = manager as GeoprocessingResourceManager;
            for (int i = 0; i < gpManager.ResourceItems.Count; i++)
            {
                GeoprocessingResourceItem item = gpManager.ResourceItems[i];
                if (item != null && item.FailedToInitialize)
                {
                    gpManager.ResourceItems[i] = null;
                }
            }
        }
    }

    #endregion


    #region Clean Up
    /// <summary>
    /// Handles call from client to clean up session.
    /// </summary>
    [System.Web.Services.WebMethod]
    public static string CleanUp()
    {
        string response = ConfigurationManager.AppSettings["CloseOutUrl"];
        if (String.IsNullOrEmpty(response)) response = "ApplicationClosed.aspx";
        try
        {
            //ArcGISServerLocalSupport.ReleaseNonPooledContexts();
            HttpContext.Current.Session.RemoveAll();
            // FormsAuthentication.SignOut();
        }
        catch { }
        return response;
    }
    #endregion

    protected void Toolbar1_CommandClick(object sender, ESRI.ArcGIS.ADF.Web.UI.WebControls.ToolbarCommandClickEventArgs args)
    {

    }

    protected void Map1_MapClick(object sender, ESRI.ArcGIS.ADF.Web.UI.WebControls.PointEventArgs args)
    {

    }

}

