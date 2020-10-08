<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewerGis.aspx.cs" Inherits="ASPX_Archive_viewerGis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
    body {
  margin: 0;
}
iframe {
  height:calc(100vh - 4px);
  width:calc(100vw - 4px);
  box-sizing: border-box;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <iframe src ="https://namaa.maps.arcgis.com/apps/webappviewer/index.html?id=96f3474c1d9f41dfb03e52c87947cc72" width="100%" height="100%" frameborder="0"></iframe>
    </div>
    </form>
</body>
</html>
