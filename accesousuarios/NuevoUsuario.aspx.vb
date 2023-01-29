
Imports System.Data
Imports System.Data.SqlClient

Partial Class NuevoUsuario
    Inherits System.Web.UI.Page
    Dim cod As String
    Dim tipo_us As Integer
    Private datos As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then

                cod = Session("user").ToString()
            End If
        Catch ex As Exception
            Response.Redirect("DEFAULTs.aspx")
        End Try


    End Sub


    Protected Sub cdmverasignatura0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmNuevoEstud.Click
        Dim sel, str As String
        Dim MiDataset As New DataSet
        Dim i As Integer

        Try
            If txtlogin.Text.Length = 0 Then
                LBLmensajeestud.Text = "ERROR: ingrese correctamente el login"
                Exit Sub
            End If

            If txtClave.Text = "" Then
                LBLmensajeestud.Text = "ERROR: ingrese los 4 últimos dígitos de la cédula"
                Exit Sub
            End If

            sel = "INSERT INTO USUARIO_SIS " & _
                          "(login,password,nombres,fecha_ingreso,estado) " & _
                          "VALUES " & _
                          "(@login,@password,@nombres,@fecha_ingreso,@estado) "
            Dim cmd As New SqlCommand(sel, cntDB)

            cmd.Parameters.AddWithValue("login", CType(txtlogin.Text, String))
            cmd.Parameters.AddWithValue("password", CType(Me.txtClave.Text, String))
            cmd.Parameters.AddWithValue("nombres", CType(txtnombres.Text, String))
            cmd.Parameters.AddWithValue("fecha_ingreso", CType(Date.Now, Date))
            cmd.Parameters.AddWithValue("estado", CType("A", String))


            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()



            LBLmensajeestud.Text = "Se guardo el usuario"
        Catch ex As Exception
            LBLmensajeestud.Text = "ERROR: " & ex.Message

        End Try
    End Sub

End Class
