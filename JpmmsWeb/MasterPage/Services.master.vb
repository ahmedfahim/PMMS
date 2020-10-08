
Partial Class MasterPage_Services
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack And (Request.Browser.Browser = "IE" And Convert.ToDecimal(Request.Browser.Version) < 7.0) Then
            Response.Redirect("~/BrowserUpgrade.aspx", False)
        End If
    End Sub
End Class

