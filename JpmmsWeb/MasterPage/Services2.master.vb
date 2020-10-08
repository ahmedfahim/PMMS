
Partial Class MasterPage_Services2
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_Title.Text = Session("Title")
    End Sub
End Class

