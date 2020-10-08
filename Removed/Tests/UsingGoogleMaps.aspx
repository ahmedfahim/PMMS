<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsingGoogleMaps.aspx.cs"
    Inherits="ASPX_Tests_UsingGoogleMaps" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using Google Maps Sample</title>
    <style type="text/css">
        html
        {
            height: 100%;
        }
        body
        {
            height: 100%;
            margin: 0;
            padding: 0;
        }
        #map_canvas
        {
            height: 100%;
        }
    </style>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCuqwPqTz5FPCKcW7X0dLIx3UhCkot4gqQ&sensor=true">
    </script>

    <script type="text/javascript">
        function initialize() {
            var mapOptions = {
            center: new google.maps.LatLng(23.70790, 53.59303),
                zoom: 18,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"),
            mapOptions);
        }
    </script>

</head>
<body onload="initialize()">
    <div id="map_canvas" style="width: 60%; height: 80%">
    </div>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
