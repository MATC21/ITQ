
Partial Class menus
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                lblmenu.Text = Request.QueryString("menu")
                
            End If
        Catch ex As Exception
            Dim url As String = "MensajeError.aspx"
            Response.Redirect(url)
        End Try
    End Sub
End Class
