
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Accesousuarios
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
                lblusuario.Text = cod
                Call cargarusuarios()
            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub
    Sub cargarusuarios()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DISTINCT nombres,id_usuarios " & _
                    "FROM USUARIO_SIS order by nombres"
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "USUARIO_SIS")
            CboUsuarios.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboUsuarios.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboUsuarios.Items.Add("- Seleccione -")
                        CboUsuarios.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboUsuarios.Items.Add(v(0))
                        CboUsuarios.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            Else
                CboUsuarios.Items.Clear()
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub


    Sub cargaraccesos()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DISTINCT opcion,idOpcion " & _
                    "FROM MENU_GENERAL where idGrupo=" & lblIdgrupo.Text & "  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MENU_USUARIOS")
            CboAcceso.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboAcceso.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboAcceso.Items.Add("- Seleccione -")
                        CboAcceso.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboAcceso.Items.Add(v(0))
                        CboAcceso.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            Else
                CboAcceso.Items.Clear()
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub

    Sub Grupo()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DISTINCT Grupo,idGrupo " & _
                    "FROM MENU_GENERAL "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MENU_GENERAL")
            CboGrupo.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboGrupo.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboGrupo.Items.Add("- Seleccione -")
                        CboGrupo.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboGrupo.Items.Add(v(0))
                        CboGrupo.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()

            UpdatePCabecera.Update()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try

    End Sub



    Sub VerAcceso()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer

        Try

            sel = "SELECT * " & _
                    "FROM MENU_USUARIOS " & _
                    "WHERE  id_usuarios=" & lblcod_estud.Text & "  order by Grupo,idOpcion,Opcion"
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MENU_USUARIOS")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdateIngAsig.Update()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CmdVerAsignaturas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdVerAsignaturas.Click
        Try
            GridView1.Visible = True
            Call VerAcceso()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub cmdAgregarRubro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAgregarRubro.Click
        Dim sel As String

        'matricula
        Dim numest, numrubros, s, es, Tt As Integer
        Dim Tabla As New DataTable
        Dim MiDataset As New DataSet
        Dim c As Boolean

        Try
            Call verurl()
            sel = "INSERT MENU_USUARIOS " & _
                  "(id_usuarios,idGrupo,Grupo,idOpcion,Opcion,url) " & _
                  "VALUES " & _
                  "(@id_usuarios,@idGrupo,@Grupo,@idOpcion,@Opcion,@url) "
            Dim cmdM As New SqlCommand(sel, cntDB)

            cmdM.Parameters.AddWithValue("id_usuarios", CType(lblcod_estud.Text, Integer))
            cmdM.Parameters.AddWithValue("idGrupo", CType(lblIdgrupo.Text, Integer))
            cmdM.Parameters.AddWithValue("Grupo", CType(lblGrupo.Text, String))
            cmdM.Parameters.AddWithValue("idOpcion", CType(lblcodacceso.Text, Integer))
            cmdM.Parameters.AddWithValue("Opcion", CType(lblOpcion.Text, String))
            cmdM.Parameters.AddWithValue("url", CType(lblURL.Text, String))

            cntDB.Open()
            Dim t As Integer = CInt(cmdM.ExecuteScalar())
            cntDB.Close()
            GridView1.Visible = True
            Call VerAcceso()
            LBLmensajeestud.Text = "Se genero correctamente los accesos"
            UpdatePCabecera.Update()
        Catch ex As Exception
            LBLmensajeestud.Text = "No se genero los accesos ......."
        End Try
    End Sub

    Sub verurl()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Try

            sel = "SELECT url from MENU_GENERAL " & _
                      "WHERE  idGrupo=" & lblIdgrupo.Text & " AND idOpcion=" & lblcodacceso.Text & " "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MENU_GENERAL")
            i = datos.Tables(0).Rows.Count
            lblURL.Text = datos.Tables(0).Rows(0).Item(0).ToString()
            lblURL.Text = lblURL.Text.Replace(" ", "").Trim

            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try

    End Sub

    Sub verpass()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Try

            sel = "SELECT password,login from USUARIO_SIS " & _
                      "WHERE  id_usuarios=" & lblcod_estud.Text & "  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "USUARIO_SIS")
            i = datos.Tables(0).Rows.Count
            txtpassword.Text = datos.Tables(0).Rows(0).Item(0).ToString()
            lblverLOGIN.Text = datos.Tables(0).Rows(0).Item("login").ToString()
            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        Call VerAcceso()

    End Sub



    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim i As Integer
        Dim N As Integer
        Dim sel As String

        i = Convert.ToInt32(e.RowIndex)
        Dim codunid As Label = DirectCast(GridView1.Rows(i).FindControl("lblNUM"), Label)
        N = codunid.Text
        sel = "delete MENU_USUARIOS " & _
              "where num=" & N & ""
        Dim cmd As New SqlCommand(sel, cntDB)
        cntDB.Open()
        Dim t As Integer = CInt(cmd.ExecuteScalar())
        cntDB.Close()
        GridView1.EditIndex = -1
        Call VerAcceso()

    End Sub


    Protected Sub CboGrupo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboGrupo.SelectedIndexChanged
        Try

            Dim p As Integer = CboGrupo.SelectedIndex
            Dim codg As String = CboGrupo.Items(p - 1).Value
            Dim g As String = CboGrupo.Items(p).Text

            lblGrupo.Text = g
            lblIdgrupo.Text = codg
            Call cargaraccesos()
            Me.UpdatePCabecera.Update()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CboAcceso_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAcceso.SelectedIndexChanged
        Try

            Dim p As Integer = CboAcceso.SelectedIndex
            Dim codrubro As String = CboAcceso.Items(p - 1).Value
            Dim op As String = CboAcceso.Items(p).Text

            lblOpcion.Text = op
            lblcodacceso.Text = codrubro
            Me.UpdatePCabecera.Update()
            Call VerAcceso()
            LBLmensajeestud.Text = Nothing
            UpdateIngAsig.Update()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CboUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboUsuarios.SelectedIndexChanged
        Dim p As Integer = CboUsuarios.SelectedIndex
        Dim codest As String = CboUsuarios.Items(p - 1).Value

        lblcod_estud.Text = codest
        Call verpass()
        Call Grupo()
        cargarAnioBasica()
        lblmensajepass.Text = Nothing
        UpdatePCabecera.Update()
    End Sub


    Protected Sub cmdAgregarTodos_Click(sender As Object, e As EventArgs) Handles cmdAgregarTodos.Click
        Dim sel, g, op, ur As String
        Dim daUs As SqlDataAdapter
        Dim i, ig, rc, io As Integer
        Try

            sel = "delete MENU_USUARIOS " & _
                   "where id_usuarios=" & lblcod_estud.Text & ""
            Dim cmd As New SqlCommand(sel, cntDB)
            cntDB.Open()
            Dim t1 As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()

            sel = "SELECT idGrupo, Grupo, idOpcion, Opcion, url, ReporteCry from MENU_GENERAL "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MENU_GENERAL")
            i = datos.Tables(0).Rows.Count

            For k = 0 To i - 1
                ig = datos.Tables(0).Rows(k).Item("idGrupo").ToString()
                g = datos.Tables(0).Rows(k).Item("Grupo").ToString().TrimEnd
                io = datos.Tables(0).Rows(k).Item("idOpcion").ToString()
                op = datos.Tables(0).Rows(k).Item("Opcion").ToString().TrimEnd
                ur = datos.Tables(0).Rows(k).Item("url").ToString().TrimEnd
                rc = datos.Tables(0).Rows(k).Item("ReporteCry").ToString()

                sel = "INSERT MENU_USUARIOS " & _
                      "(id_usuarios,idGrupo,Grupo,idOpcion,Opcion,url,ReporteCry) " & _
                      "VALUES " & _
                      "(@id_usuarios,@idGrupo,@Grupo,@idOpcion,@Opcion,@url,@ReporteCry) "
                Dim cmdM As New SqlCommand(sel, cntDB)

                cmdM.Parameters.AddWithValue("id_usuarios", CType(lblcod_estud.Text, Integer))
                cmdM.Parameters.AddWithValue("idGrupo", CType(ig, Integer))
                cmdM.Parameters.AddWithValue("Grupo", CType(g, String))
                cmdM.Parameters.AddWithValue("idOpcion", CType(io, Integer))
                cmdM.Parameters.AddWithValue("Opcion", CType(op, String))
                cmdM.Parameters.AddWithValue("url", CType(ur, String))
                cmdM.Parameters.AddWithValue("ReporteCry", CType(rc, Integer))

                cntDB.Open()
                Dim t As Integer = CInt(cmdM.ExecuteScalar())
                cntDB.Close()
            Next k
            Call VerAcceso()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CmdModificaPass_Click(sender As Object, e As EventArgs) Handles CmdModificaPass.Click
        Dim sel As String

        sel = "UPDATE USUARIO_SIS " & _
         "SET password=@password where  login='" & lblverLOGIN.Text & "'"
        Dim cmd As New SqlCommand(sel, cntDB)
        txtpassword.Text = txtpassword.Text.Replace(" ", "").Trim
        cmd.Parameters.AddWithValue("@password", CType(txtpassword.Text.TrimEnd, String))

        cntDB.Open()
        Dim t As Integer = CInt(cmd.ExecuteScalar())
        cntDB.Close()
        lblmensajepass.Text = "Password modificado"
    End Sub
    Protected Sub CboAnioBasica_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAnioBasica.SelectedIndexChanged
        Try
            Dim p As Integer = CboAnioBasica.SelectedIndex
            Dim coda As String = CboAnioBasica.Items(p).Value

            Me.lblCarrera.Text = coda

            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub cargarAnioBasica()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Try


            sel = "SELECT Nombre_Basica,Cod_AnioBasica " &
              "FROM CARRERAS  " &
              "ORDER BY Nombre_Basica"

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAS")
            CboAnioBasica.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboAnioBasica.DataTextField = "Nombre_Basica"
                CboAnioBasica.DataValueField = "Cod_AnioBasica"
                CboAnioBasica.DataBind()

                CboAnioBasica.Items.Insert(0, New ListItem(0))

                If lblCarrera.Text <> "" Then
                    CboAnioBasica.Items.FindByValue(lblCarrera.Text).Selected = True
                End If

            Else
                CboAnioBasica.Items.Clear()
            End If
            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub cmdAgregarRubro0_Click(sender As Object, e As EventArgs) Handles cmdAgregarRubro0.Click
        Dim sel As String
        Try

            sel = "UPDATE USUARIO_SIS " &
             "SET coordcarrera=@coordcarrera where login='" & lblverLOGIN.Text & "'"
            Dim cmd As New SqlCommand(sel, cntDB)

            cmd.Parameters.AddWithValue("@CoordCarrera", CType(lblCarrera.Text, Integer))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()


            LBLmensajeestud.Text = "Datos actualizados de coordinador"
            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try
    End Sub
End Class
