Imports System.Data.SqlClient
Imports System.Data
Partial Class cabeceras
    Inherits System.Web.UI.Page
    Dim tipo_us As Integer
    Dim cod As String
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Clear()
            Session.Abandon()
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'carga nuevamente página web
        Session.Clear()
        Session.Abandon()

        Response.Write("<script language=javascript> parent.frames['leftFrame'].location = 'Izquierda.aspx';</script>")
        Response.Write("<script language=javascript> parent.frames['mainFrame'].location = 'default.aspx';</script>")
        Response.Write("<script language=javascript> parent.frames['topFrame'].location = 'cabeceras.aspx';</script>")

    End Sub
    Public Function GetData(ByVal cmd As SqlCommand) As DataTable

        Dim dt As New DataTable

        Dim strConnString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString

        Dim con As New SqlConnection(strConnString)

        Dim sda As New SqlDataAdapter

        cmd.CommandType = CommandType.Text

        cmd.Connection = con

        Try

            con.Open()

            sda.SelectCommand = cmd

            sda.Fill(dt)

            Return dt

        Catch ex As Exception

            Response.Write(ex.Message)

            Return Nothing

        Finally

            con.Close()

            sda.Dispose()

            con.Dispose()

        End Try

    End Function

    Protected Sub Cmdaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmdaceptar.Click
        Try


            Dim str, coduser, login, sql, txtUserId As String
            Dim i As Integer
            Dim Tabla As New DataTable
            Dim MiDataset As New DataSet
            If txtusuario.Text = Nothing Or txtclave.Text = Nothing Then
                'MsgBox1.ShowMessage("Ingrese correctamente los datos de usuario y/o password")
                LabelError.Text = "Ingrese los datos de usuario y/o password"
                Exit Sub
            End If

            Dim strQuery As String = "select * from USUARIO_SIS where login = @login and password=@password"

            Dim cmd As New SqlCommand(strQuery)

            cmd.Parameters.AddWithValue("@login", txtusuario.Text.Trim)
            cmd.Parameters.AddWithValue("@password", txtclave.Text.Trim)

            Dim dt As DataTable = GetData(cmd)
            i = dt.Rows.Count

            If i > 0 Then
                login = dt.Rows(0).Item("login").ToString().Replace(" ", "")
                tipo_us = dt.Rows(0).Item("id_usuarios").ToString().Replace(" ", "")

                lblbienvenido.Text = dt.Rows(0).Item("nombres").ToString()
                LabelError.Visible = True

                PanBienvenida.Visible = True
                Panel1.Visible = False
                'asigna cedula y tipo de usuario
                Session.Add("user", login)
                Session.Add("tusu", tipo_us)
                Session.Add("cusu", 3)
                LabelError.Text = Nothing

                Response.Write("<script language=javascript> parent.frames['mainFrame'].location = 'Informacion.aspx';</script>")
                Response.Write("<script language=javascript> parent.frames['leftFrame'].location = 'Izquierda.aspx';</script>")

            Else

                'str = "SELECT Codigo_Usuario, cedula, Apellidos_nombre, login, password, USUARIOS.fecha_ingreso, tipo_usuario " & _
                '       "FROM  USUARIOS,DATOS_ESTUD where codigo_estud=Codigo_Usuario AND login='" & txtusuario.Text & "' and password='" & txtclave.Text & "' "


                Dim strQuery1 As String = "select Codigo_Usuario, cedula, Apellidos_nombre, login, password, USUARIOS.fecha_ingreso, tipo_usuario FROM  USUARIOS,DATOS_ESTUD where codigo_estud=Codigo_Usuario AND login = @login and password=@password"

                Dim cmd1 As New SqlCommand(strQuery1)

                cmd1.Parameters.AddWithValue("@login", txtusuario.Text.Trim)
                cmd1.Parameters.AddWithValue("@password", txtclave.Text.Trim)

                Dim dt1 As DataTable = GetData(cmd1)
                i = dt1.Rows.Count


                If i > 0 Then
                    coduser = dt1.Rows(0).Item("Codigo_Usuario").ToString().Replace(" ", "")
                    tipo_us = dt1.Rows(0).Item("tipo_usuario").ToString().Replace(" ", "")

                    lblbienvenido.Text = dt1.Rows(0).Item("Apellidos_nombre").ToString()
                    LabelError.Visible = True

                    PanBienvenida.Visible = True
                    Panel1.Visible = False
                    'asigna cedula y tipo de usuario
                    Session.Add("user", coduser)
                    Session.Add("tusu", tipo_us)
                    Session.Add("cusu", 0)
                    LabelError.Text = Nothing

                    Response.Write("<script language=javascript> parent.frames['mainFrame'].location = 'Informacion.aspx';</script>")
                    Response.Write("<script language=javascript> parent.frames['leftFrame'].location = 'Izquierda.aspx';</script>")

                Else

                    '  str = "SELECT Codigo_Usuario, cedula, apellidos_nombre, login, password, USUARIOS.fecha_ingreso, tipo_usuario " & _
                    '      "FROM  USUARIOS,DATOSDOCENTE where codigo_doc=Codigo_Usuario AND login='" & txtusuario.Text & "' and password='" & txtclave.Text & "' "


                    Dim strQuery2 As String = "select Codigo_Usuario, cedula, apellidos_nombre, login, password, USUARIOS.fecha_ingreso, tipo_usuario FROM  USUARIOS,DATOSDOCENTE where codigo_doc=Codigo_Usuario AND login = @login and password=@password"

                    Dim cmd2 As New SqlCommand(strQuery2)

                    cmd2.Parameters.AddWithValue("@login", txtusuario.Text.Trim)
                    cmd2.Parameters.AddWithValue("@password", txtclave.Text.Trim)

                    Dim dt2 As DataTable = GetData(cmd2)
                    i = dt2.Rows.Count

                    If i > 0 Then
                        coduser = dt2.Rows(0).Item("Codigo_Usuario").ToString().Replace(" ", "")
                        tipo_us = dt2.Rows(0).Item("tipo_usuario").ToString().Replace(" ", "")

                        lblbienvenido.Text = dt2.Rows(0).Item("Apellidos_nombre").ToString()
                        LabelError.Visible = True

                        PanBienvenida.Visible = True
                        Panel1.Visible = False
                        'asigna cedula y tipo de usuario
                        Session.Add("user", coduser)
                        Session.Add("tusu", tipo_us)
                        Session.Add("cusu", 0)
                        LabelError.Text = Nothing

                        Response.Write("<script language=javascript> parent.frames['mainFrame'].location = 'Informacion.aspx';</script>")
                        Response.Write("<script language=javascript> parent.frames['leftFrame'].location = 'Izquierda.aspx';</script>")
                    End If
                End If
            End If

        Catch ex As Exception
            Dim u As String = ex.Message
        End Try
    End Sub

End Class
