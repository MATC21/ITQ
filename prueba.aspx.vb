Imports System.Text.RegularExpressions
Partial Class prueba
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim texto As String = "ACHIG GUACHAMIN JONATHAN DANIEL"
        Dim n1, n2, a1, a2 As String
        'Split con expresión regular
        Dim regex As Regex = New Regex(" ")
        Dim vectoraux() As String
        vectoraux = regex.Split(texto)

        n1 = vectoraux(0)
        n2 = vectoraux(1)
        a1 = vectoraux(2)
        a2 = vectoraux(3)

    End Sub
End Class
