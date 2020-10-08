
Partial Class Controls_Header
    Inherits System.Web.UI.UserControl

   
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Session("UserName") Is Nothing Then
            lblUserName.Text = Session("UserName").ToString()
        End If
    End Sub
End Class
