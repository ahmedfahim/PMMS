<%@ Page Language="C#" MasterPageFile="~/MasterPage/ServicesHome.master" AutoEventWireup="true"
    CodeFile="frmGoogle_Maps.aspx.cs" Inherits="Secret_Map_frmGoogle_Maps" %>

<%@ Register Assembly="ESRI.ArcGIS.ADF.Web.UI.WebControls, Version=10.0.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86"
    Namespace="ESRI.ArcGIS.ADF.Web.UI.WebControls" TagPrefix="esri" %>
<%@ Register Src="~/ascx/Measure.ascx" TagName="Measure" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table dir="ltr" style="width: 100%;">
        <tr>
            <td colspan="2">
                &nbsp; &nbsp; &nbsp;
                <esri:Toolbar ID="Toolbar1" runat="server" BuddyControlType="Map" Group="Toolbar1_Group"
                    Height="32px" ToolbarItemDefaultStyle-BackColor="Transparent" ToolbarItemDefaultStyle-Font-Names="Arial"
                    ToolbarItemDefaultStyle-Font-Size="Smaller" ToolbarItemDisabledStyle-BackColor="Transparent"
                    ToolbarItemDisabledStyle-Font-Names="Arial" ToolbarItemDisabledStyle-Font-Size="Smaller"
                    ToolbarItemDisabledStyle-ForeColor="Gray" ToolbarItemHoverStyle-Font-Bold="True"
                    ToolbarItemHoverStyle-Font-Italic="True" ToolbarItemHoverStyle-Font-Names="Arial"
                    ToolbarItemHoverStyle-Font-Size="Smaller" ToolbarItemSelectedStyle-BackColor="WhiteSmoke"
                    ToolbarItemSelectedStyle-Font-Bold="True" ToolbarItemSelectedStyle-Font-Names="Arial"
                    ToolbarItemSelectedStyle-Font-Size="Smaller" ToolbarStyle="ImageOnly" WebResourceLocation="/aspnet_client/ESRI/WebADF/"
                    Width="414px" ToolbarItemHoverStyle-BorderColor="Black" ToolbarItemSelectedStyle-BorderColor="Black"
                    CurrentTool="MapPan" Alignment="Right" ToolbarItemDefaultStyle-BorderColor="Transparent"
                    CssClass="appFloat2" ToolbarItemHoverStyle-BackColor="White" OnCommandClick="Toolbar1_CommandClick">
                    <ToolbarItems>
                        <esri:Tool ClientAction="DragRectangle" DefaultImage="esriZoomIn.png" HoverImage="esriZoomIn.png"
                            JavaScriptFile="" Name="MapZoomIn" SelectedImage="esriZoomIn.png" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls"
                            ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapZoomIn" Text="Zoom In"
                            ToolTip="Zoom In" />
                        <esri:Tool ClientAction="DragRectangle" DefaultImage="esriZoomOut.png" HoverImage="esriZoomOut.png"
                            JavaScriptFile="" Name="MapZoomOut" SelectedImage="esriZoomOut.png" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls"
                            ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapZoomOut" Text="Zoom Out"
                            ToolTip="Zoom Out" />
                        <esri:Tool ClientAction="DragImage" DefaultImage="esriPan.png" HoverImage="esriPan.png"
                            JavaScriptFile="" Name="MapPan" SelectedImage="esriPan.png" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls"
                            ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapPan" Text="Pan"
                            ToolTip="Pan" />
                        <esri:Command ClientAction="" DefaultImage="esriZoomFullExtent.png" HoverImage="esriZoomFullExtent.png"
                            JavaScriptFile="" Name="MapFullExtent" SelectedImage="esriZoomFullExtent.png"
                            ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls" ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.Tools.MapFullExtent"
                            Text="Full Extent" ToolTip="Full Extent" />
                        <esri:Tool ClientAction="MapIdentifyTool()" Cursor="pointer" DefaultImage="esriIdentify.png"
                            HoverImage="esriIdentify.png" JavaScriptFile="" Name="MapIdentify" SelectedImage="esriIdentify.png"
                            Text="Map Identify" ToolTip="Map Identify" ServerActionAssembly="ESRI.ArcGIS.ADF.Web.UI.WebControls"
                            ServerActionClass="ESRI.ArcGIS.ADF.Web.UI.WebControls.MapIdentify" />
                    </ToolbarItems>
                    <BuddyControls>
                        <esri:BuddyControl Name="Map1"></esri:BuddyControl>
                    </BuddyControls>
                </esri:Toolbar>
            </td>
        </tr>
        <tr>
            <td style="width: 847px">
                &nbsp; &nbsp; &nbsp; &nbsp;
                <esri:Map ID="Map1" runat="server" Height="600px" MapResourceManager="MapResourceManager1"
                    Width="100%" BorderStyle="Solid" OnMapClick="Map1_MapClick" EnableZoomAnimation="False"
                    InitialExtent="Full">
                </esri:Map>
            </td>
            <td valign="top" style="width: 175px">
                <esri:Toc ID="Toc1" dir="rtl" runat="server" BuddyControl="Map1" Height="300px" Width="175px"
                    Style="cursor: default; float: right;" ForeColor="Black" ExpandDepth="1" Font-Bold="True"
                    Font-Names="Traditional Arabic" OffsetWidth="0" />
            </td>
            <%--<uc2:Measure ID="Measure1" runat="server" AreaUnits="Sq_Miles" MapBuddyId="Map1"
        MapUnits="Resource_Default" MeasureUnits="Miles" NumberDecimals="3" />--%>
        </tr>
    </table>
    <div id="maindiv">
        <div id="pagefooterdiv">
            <esri:MapResourceManager ID="MapResourceManager1" runat="server">
                <ResourceItems>
                    <esri:MapResourceItem Definition="&lt;Definition DataSourceDefinition=&quot;http://gissrv/ArcGIS/services/&quot; DataSourceType=&quot;ArcGIS Server Internet&quot; Identity=&quot;XnCuZRa/5MCP6F0neealKY+iYM0okwrdKrMLL7lwX6OWe/TeDxYWEA==&quot; ResourceDefinition=&quot;Layers@Sec_St_UDI&quot; /&gt;"
                        DisplaySettings="visible=True:transparency=0:mime=True:imgFormat=PNG8:height=100:width=100:dpi=96:color=:transbg=False:displayInToc=True:dynamicTiling="
                        LayerDefinitions="" Name="عناصر الخارطة" />
                </ResourceItems>
            </esri:MapResourceManager>
        </div>
    </div>
</asp:Content>
