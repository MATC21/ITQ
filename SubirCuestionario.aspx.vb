
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class SubirCuestionario
    Inherits System.Web.UI.Page
    Private datos As DataSet
    Dim cod As String
    Dim tipo_us As Integer
    Dim cod_curso As String
    Dim npreg As String
    Public cont, cargaFileUp As Integer
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                cod = Session("user").ToString()
                tipo_us = Session("tusu").ToString()
                lblcodusa.Text = cod
                Me.lblpacad1.Text = Session("pacad").ToString()
                Call cargarasignaturas()
                txtfechai.Text = Format(CType(Date.Now, Date), "dd/MM/yyyy")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub cargarasignaturas()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DISTINCT Nomb_Materia,PENSUM.codigo_materia " & _
                    "FROM CARRERAXDOCENTE,PENSUM " & _
                    "WHERE   (codigo_doc = '" & cod & "') and CARRERAXDOCENTE.codigo_materia=PENSUM.codigo_materia " & _
                        "order by Nomb_Materia "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXDOCENTE")
            CboAsignatura.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboAsignatura.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboAsignatura.Items.Add("- Seleccione una asignatura -")
                        CboAsignatura.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboAsignatura.Items.Add(v(0))
                        CboAsignatura.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub
    Sub cargarunidades()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT NumUnidad " & _
                    "FROM NO_UNIDADES " & _
                    "WHERE(Estado = 'A')" & _
                        "order by NumUnidad "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "NO_UNIDADES")
            CboUnidad.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboUnidad.Items.Clear()
                For c = 0 To i - 1
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboUnidad.Items.Add("- Seleccione una unidad -")
                        CboUnidad.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c)
                        CboUnidad.Items.Add(v(0))
                        'CboUnidad.Items.Item(c - 1).Value = v(0)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub

    Sub cargarpreguntas()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try


            sel = "SELECT * " & _
                    "FROM CUESTIONARIO " & _
                    "WHERE cod_materia='" & lblcodmateria.Text & "' and Unidad=" & lblunidad.Text & " " & _
                        "order by Tipo_Pregunta,No_Pregunta "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CUESTIONARIO")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()

            TxtNumPregIngresadas.Text = GridView1.Rows.Count

        Catch ex As Exception

        End Try
    End Sub
    'visualiza el número de preguntas solicitado
    Sub no_preg_solicita()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try


            sel = "SELECT Numero_Preg " & _
                    "FROM NUMEROPREGALEAT where Cod_Materia=" & lblcodmateria.Text & "  "

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "NUMEROPREGALEAT")
            v = datos.Tables(0).Rows(0)
            lblnumpreguntas.Text = v(0)

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub CboUnidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboUnidad.SelectedIndexChanged
        Dim p As Integer = CboUnidad.SelectedIndex
        Dim unidad As String = CboUnidad.Items(p).Value
        lblunidad.Text = unidad
        Call cargarpreguntas()
        UpdatePanel5.Update()


    End Sub


    Protected Sub CboAsignatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAsignatura.SelectedIndexChanged
        Try


            Dim p As Integer = CboAsignatura.SelectedIndex
            Dim codm As String = CboAsignatura.Items(p - 1).Value
            lblcodmateria.Text = codm
            CboUnidad.Enabled = True
            Call cargarunidades()
            Call no_preg_solicita()
            UpdatePanel5.Update()
        Catch ex As Exception

        End Try

    End Sub


    
   

    Private Sub EnlazarDatos()
        Try

            SqlDataSource1 = New SqlDataSource(ConnectionString, "SELECT * " & _
         "FROM CUESTIONARIO " & _
         "WHERE cod_periodo=" & lblpacad1.Text & " and cod_materia='" & lblcodmateria.Text & "' and Unidad=" & Me.lblunidad.Text & " " & _
             "order by No_Pregunta ")

            GridView1.DataSource = SqlDataSource1
            GridView1.DataBind()

            TxtNumPregIngresadas.Text = GridView1.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        EnlazarDatos()

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        If Not (fila Is Nothing) Then
            SqlDataSource1.ConnectionString = ConnectionString
            SqlDataSource1.DeleteCommand = "DELETE FROM CUESTIONARIO WHERE  cod_periodo=" & lblpacad1.Text & "  and No_Pregunta = @No_Pregunta and cod_materia=@cod_materia and Unidad=@Unidad and Tipo_Pregunta=@Tipo_Pregunta"
            SqlDataSource1.DeleteParameters.Add(New Parameter("No_Pregunta", TypeCode.Decimal))
            SqlDataSource1.DeleteParameters.Add(New Parameter("cod_materia", TypeCode.String))
            SqlDataSource1.DeleteParameters.Add(New Parameter("Unidad", TypeCode.Decimal))
            SqlDataSource1.DeleteParameters.Add(New Parameter("Tipo_Pregunta", TypeCode.Decimal))

            SqlDataSource1.DeleteParameters("No_Pregunta").DefaultValue = CType(fila.FindControl("lblno_pregunta"), Label).Text
            SqlDataSource1.DeleteParameters("cod_materia").DefaultValue = CType(fila.FindControl("lblCodMateria"), Label).Text
            SqlDataSource1.DeleteParameters("Unidad").DefaultValue = CType(fila.FindControl("LblUnidad"), Label).Text
            SqlDataSource1.DeleteParameters("Tipo_Pregunta").DefaultValue = CType(fila.FindControl("lbltipo_preg"), Label).Text


            SqlDataSource1.Delete()
            EnlazarDatos()
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        EnlazarDatos()
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        If Not (fila Is Nothing) Then
            SqlDataSource1.ConnectionString = ConnectionString
            SqlDataSource1.UpdateCommand = "UPDATE CUESTIONARIO SET Pregunta = @Pregunta, Explica_Resp = @Explica_Resp WHERE  cod_periodo=" & lblpacad1.Text & "  and No_Pregunta = @No_Pregunta and cod_materia=@cod_materia and Unidad=@Unidad and Tipo_Pregunta=@Tipo_Pregunta "
            SqlDataSource1.UpdateParameters.Add(New Parameter("Pregunta", TypeCode.String))
            SqlDataSource1.UpdateParameters.Add(New Parameter("Explica_Resp", TypeCode.String))
            SqlDataSource1.UpdateParameters.Add(New Parameter("No_Pregunta", TypeCode.Decimal))
            SqlDataSource1.UpdateParameters.Add(New Parameter("cod_materia", TypeCode.String))
            SqlDataSource1.UpdateParameters.Add(New Parameter("Unidad", TypeCode.Decimal))
            SqlDataSource1.UpdateParameters.Add(New Parameter("Tipo_Pregunta", TypeCode.Decimal))


            SqlDataSource1.UpdateParameters("Pregunta").DefaultValue = CType(fila.FindControl("txtpregunta"), TextBox).Text
            SqlDataSource1.UpdateParameters("Explica_Resp").DefaultValue = CType(fila.FindControl("txtexplica"), TextBox).Text

            SqlDataSource1.UpdateParameters("No_Pregunta").DefaultValue = CType(fila.FindControl("lblno_pregunta"), Label).Text
            SqlDataSource1.UpdateParameters("cod_materia").DefaultValue = CType(fila.FindControl("lblCodMateria"), Label).Text
            SqlDataSource1.UpdateParameters("Unidad").DefaultValue = CType(fila.FindControl("LblUnidad"), Label).Text
            SqlDataSource1.UpdateParameters("Tipo_Pregunta").DefaultValue = CType(fila.FindControl("lbltipo_preg"), Label).Text


            SqlDataSource1.Update()
            GridView1.EditIndex = -1
            EnlazarDatos()
        End If

    End Sub

    

    Protected Sub cmdSaveVF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSaveVF.Click
        Dim ping As Integer = TxtNumPregIngresadas.Text
        Dim npreg As Integer = lblnumpreguntas.Text
        Try
            If ping < npreg Then

                Exit Sub
            End If
            If txtfechai.Text = Nothing Or txtfechaFinal.Text = Nothing Then
                Exit Sub
            End If


            cntDB.Open()

            Dim cmdInsert As New SqlCommand("insert into CUESTIONARIOFINAL(No_Pregunta,cod_materia,Unidad,Tipo_Pregunta,cod_doc,Pregunta,Resp1,Resp2,Resp3,Resp4,Resp_Correcta,RespVerdadFalso,Explica_Resp,pathimagen,cod_periodo) " & _
            "SELECT No_Pregunta,cod_materia,Unidad,Tipo_Pregunta,cod_doc,Pregunta,Resp1,Resp2,Resp3,Resp4,Resp_Correcta,RespVerdadFalso,Explica_Resp,pathimagen,cod_periodo FROM CUESTIONARIO where  cod_periodo=" & lblpacad1.Text & "  and cod_materia='" & Me.lblcodmateria.Text & "' and Unidad=" & Me.lblunidad.Text & "", cntDB)
            cmdInsert.ExecuteNonQuery()

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "Ya existe este cuestionario en la evaluación, si requiere solicite soporte al administrador del sistema"
            Exit Sub
        End Try

        Try

            cntDB.Open()

            Dim cmdelete As New SqlCommand("delete FROM CUESTIONARIO where  cod_periodo=" & lblpacad1.Text & "  and cod_materia='" & Me.lblcodmateria.Text & "' and Unidad=" & Me.lblunidad.Text & "", cntDB)
            cmdelete.ExecuteNonQuery()

            cntDB.Close()
            Call verregunidad()

        Catch ex As Exception
            LabelErrorcab.Text = ex.ToString
        End Try
        'actualiza el ingreso de los datos, ver lista de eva. docentes
        Call actualizaingreso()

    End Sub
    Sub actualizaingreso()
        Dim sel As String
        '1 cuestionario o evaluación
        Try
            sel = "UPDATE REG_CUES_FORO_DOC " & _
                             "SET fecha=@fecha,Bandera=@Bandera where cod_materia='" & lblcodmateria.Text & "' and unidad=" & lblunidad.Text & " and tipo_cues_foro=1  "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("@fecha", CType(Date.Now, Date))
            cmd.Parameters.AddWithValue("@Bandera", CType("Si", String))


            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = ex.ToString
        End Try
    End Sub


    Sub verregunidad()


        Dim sel, det As String
        Dim ds As New DataSet

        Dim fi, ff As Date



        Try
            fi = (txtfechai.Text) & " " & "01:00:00" & " " & "AM"

            ff = Me.txtfechaFinal.Text & " " & "23:00:00" & " " & "PM"



            sel = "INSERT INTO REG_MENU_C_FORO " & _
                          "(Cod_Unidad,Orden,cod_doc,cod_materia,Detalle_Cuest_Foro,Link_Cuest_Foro,Path_Imagen,fecha_inicio,fecha_final,cod_periodo) " & _
                          "VALUES " & _
                          "(@Cod_Unidad, @Orden,@cod_doc, @cod_materia,@Detalle_Cuest_Foro, @Link_Cuest_Foro,@Path_Imagen,@fecha_inicio,@fecha_final,@cod_periodo) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("Cod_Unidad", CType(lblunidad.Text, Integer))


                'detalle del cuestionario
            cmd.Parameters.AddWithValue("Orden", CType(1, Integer))
                cmd.Parameters.AddWithValue("cod_materia", CType(lblcodmateria.Text, String))
            cmd.Parameters.AddWithValue("Detalle_Cuest_Foro", "Evaluación del cuestionario correspondiente a la Unidad:" & " " & lblunidad.Text)
                cmd.Parameters.AddWithValue("Link_Cuest_Foro", "PreguntasVF.aspx")
                cmd.Parameters.AddWithValue("Path_Imagen", "iContLect.gif")
                cmd.Parameters.AddWithValue("fecha_inicio", fi)
            cmd.Parameters.AddWithValue("fecha_final", ff)
            cmd.Parameters.AddWithValue("cod_periodo", lblpacad1.Text)
            cmd.Parameters.AddWithValue("cod_doc", lblcodusa.Text)



            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()

            cont = 0





            lblmensajeok.Visible = True
            EnlazarDatos()
        Catch ex As Exception
            LabelErrorcab.Text = ex.ToString
        End Try

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Call cargarpreguntas()
            UpdatePanel5.Update()


        Catch ex As Exception

        End Try

    End Sub
End Class

