
Imports System.Data
Imports System.Data.SqlClient

Partial Class NuevoProfe
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
               
                Call cargarcarrera()

            End If
        Catch ex As Exception
            Response.Redirect("DEFAULTs.aspx")
        End Try


    End Sub

    Sub cargarcarrera()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DISTINCT Nombre_Basica,Cod_AnioBasica " & _
                    "FROM CARRERAS " & _
                    "order by Cod_AnioBasica "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAS")
            CboCarrera.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboCarrera.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboCarrera.Items.Add("- Seleccione una carrera -")
                        CboCarrera.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboCarrera.Items.Add(v(0))
                        CboCarrera.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try




    End Sub
    Sub cargarParalelos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT paralelo " & _
                    "FROM PARALELOS  order by paralelo "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PARALELOS")
            CboParalelo.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboParalelo.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboParalelo.Items.Add("- Seleccione el paralelo -")
                        CboParalelo.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboParalelo.Items.Add(v(0))
                    End If
                Next c
                'CboUnidad.Items.Add(v(0))

            End If

            cntDB.Close()
            CboParalelo.Enabled = True
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub




    Protected Sub CboAsignatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCarrera.SelectedIndexChanged
        Try


            Dim p As Integer = CboCarrera.SelectedIndex
            Dim codca As String = CboCarrera.Items(p - 1).Value

            lblcodcarrera.Text = codca

            Me.UpdatePCabecera.Update()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer

        Try


            sel = "SELECT Nombre_Basica, CARRERAXDOCENTE.codigo_doc, DATOSDOCENTE.apellidos_nombre, CARRERAXDOCENTE.codigo_materia, " & _
            "PENSUM.Nomb_Materia,CARRERAXDOCENTE.paralelo,cod_Anio_Basica FROM    DATOSDOCENTE INNER JOIN " & _
            "CARRERAXDOCENTE ON DATOSDOCENTE.codigo_doc = CARRERAXDOCENTE.codigo_doc INNER JOIN " & _
            "PENSUM ON CARRERAXDOCENTE.codigo_materia = PENSUM.codigo_materia AND CARRERAXDOCENTE.cod_Anio_Basica = PENSUM.Cod_AnioBasica INNER JOIN " & _
            "CARRERAS ON CARRERAXDOCENTE.cod_Anio_Basica = CARRERAS.Cod_AnioBasica AND CARRERAXDOCENTE.Paralelo COLLATE Modern_Spanish_CI_AS = CARRERAS.Paralelo " & _
            "WHERE        (CARRERAXDOCENTE.codigo_doc = " & lblcod_usu.Text & ")  and CARRERAXDOCENTE.codigo_periodo=" & lblperiodoacad.Text & " "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXDOCENTE")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim cod_mat As String
        If Not (fila Is Nothing) Then
            SqlDataSource1.ConnectionString = ConnectionString
            SqlDataSource1.DeleteCommand = "DELETE FROM CARRERAXDOCENTE WHERE codigo_doc = '" & lblcod_usu.Text & "' and codigo_materia=@cod_mat and cod_anio_Basica=@cod_anio_Basica "
            SqlDataSource1.DeleteParameters.Add(New Parameter("cod_mat", TypeCode.String))
            SqlDataSource1.DeleteParameters.Add(New Parameter("cod_anio_Basica", TypeCode.Int32))

            SqlDataSource1.DeleteParameters("cod_mat").DefaultValue = CType(fila.FindControl("LblCodMateria"), Label).Text
            SqlDataSource1.DeleteParameters("cod_anio_Basica").DefaultValue = CType(fila.FindControl("lblAnioBasica"), Label).Text
            cod_mat = CType(fila.FindControl("LblCodMateria"), Label).Text


            SqlDataSource1.Delete()
            EnlazarDatos()
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        EnlazarDatos()
    End Sub

    Protected Sub cdmverasignatura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverasignatura.Click
        Call EnlazarDatos()
    End Sub



    Protected Sub cdmverasignaturaCarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverasignaturaCarr.Click
        Call cargarasignaturas()
        Call cargarParalelos()
        Call Periodo_Academico()
    End Sub
    Sub cargarasignaturas()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DISTINCT Nomb_Materia,PENSUM.codigo_materia " & _
                    "FROM PENSUM " & _
                    "WHERE Cod_AnioBasica='" & lblcodcarrera.Text & "' " & _
                        "order by Nomb_Materia "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PENSUM")
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

    Protected Sub CboAsignatura_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAsignatura.SelectedIndexChanged
        Dim p As Integer = CboAsignatura.SelectedIndex
        Dim codasign As String = CboAsignatura.Items(p - 1).Value
        lblcodasign.Text = codasign
        LBLMATERIA.Text = CboAsignatura.Items(p).Text
        UpdateAsign.Update()

    End Sub

    Protected Sub cdmverasignaturaCarr0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverasignaturaCarr0.Click
        Dim sel As String
        Try
            
            sel = "INSERT INTO CARRERAXDOCENTE " & _
                          "(codigo_doc,cod_Anio_Basica,codigo_materia,paralelo,codigo_periodo) " & _
                          "VALUES " & _
                          "(@codigo_doc,@cod_Anio_Basica,@codigo_materia,@paralelo,@codigo_periodo) "
            Dim cmd As New SqlCommand(sel, cntDB)

            cmd.Parameters.AddWithValue("codigo_doc", CType(lblcod_usu.Text, Integer))
            cmd.Parameters.AddWithValue("cod_Anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmd.Parameters.AddWithValue("codigo_materia", CType(lblcodasign.Text, String))
            cmd.Parameters.AddWithValue("paralelo", CType(lblparal.Text, String))
            cmd.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()

            Call EnlazarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cdmverasignatura0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmNuevoEstud.Click
        Dim sel, str As String
        Dim MiDataset As New DataSet
        Dim i As Integer

        Try
            If txtcedula.Text.Length < 10 Then
                LBLmensajeestud.Text = "ERROR: ingrese correctamente el No. de cédula"
                Exit Sub
            End If

            txtpas.Text = Me.txtcedula.Text.Substring(6, 4)
            If txtpas.Text = "" Then
                LBLmensajeestud.Text = "ERROR: ingrese los 4 últimos dígitos de la cédula"
                Exit Sub
            End If

            sel = "INSERT INTO DATOSDOCENTE " & _
                          "(cedula_doc,apellidos_nombre,Abrevia_Titulo) " & _
                          "VALUES " & _
                          "(@cedula_doc,@apellidos_nombre,@Abrevia_Titulo) "
            Dim cmd As New SqlCommand(sel, cntDB)

            cmd.Parameters.AddWithValue("cedula_doc", CType(txtcedula.Text, String))
            cmd.Parameters.AddWithValue("apellidos_nombre", CType(Me.txtApellidos.Text & " " & txtnombres.Text, String))
            cmd.Parameters.AddWithValue("Abrevia_Titulo", CType(TxtAbreTitulo.Text, String))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()


            str = "SELECT codigo_doc " & _
               "FROM  DATOSDOCENTE where cedula_doc='" & txtcedula.Text & "' "
            Dim Adaptadordoc As New SqlDataAdapter(Str, cntDB)
            MiDataset = New DataSet
            MiDataset.Clear()
            'enlazando al dataset con el adapter correspondiente.
            Adaptadordoc.Fill(MiDataset, "DATOSDOCENTE")

            i = MiDataset.Tables(0).Rows.Count
            If i > 0 Then
                lblcod_usu.Text = MiDataset.Tables(0).Rows(0).Item(0).ToString().Replace(" ", "")

            End If


            Call EnlazarDatos()

            sel = "INSERT INTO USUARIOS " & _
                     "(Codigo_Usuario,cedula,login,password,tipo_usuario) " & _
                     "VALUES " & _
                     "(@Codigo_Usuario,@cedula,@login,@password,@tipo_usuario) "
            Dim cmdu As New SqlCommand(sel, cntDB)

            cmdu.Parameters.AddWithValue("Codigo_Usuario", CType(lblcod_usu.Text, Integer))
            cmdu.Parameters.AddWithValue("cedula", CType(txtcedula.Text, String))
            cmdu.Parameters.AddWithValue("login", CType(txtcedula.Text, String))
            cmdu.Parameters.AddWithValue("password", CType(txtpas.Text, String))
            '1 estudinates  2 docentes
            cmdu.Parameters.AddWithValue("tipo_usuario", CType(2, Integer))

            cntDB.Open()
            Dim tu As Integer = CInt(cmdu.ExecuteScalar())
            cntDB.Close()

            LBLmensajeestud.Text = "Se guardo el docente ingresado"
        Catch ex As Exception
            LBLmensajeestud.Text = "ERROR: " & ex.Message

        End Try
    End Sub

    Protected Sub CboParalelo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboParalelo.SelectedIndexChanged
        Dim p As Integer = CboParalelo.SelectedIndex
        Dim pa As String = CboParalelo.Items(p).Value
        lblparal.Text = pa
        Call EnlazarDatos()
        UpdateAsign.Update()

    End Sub

    Protected Sub CboPeriodoAcad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPeriodoAcad.SelectedIndexChanged
        Dim p As Integer = CboPeriodoAcad.SelectedIndex
        Dim pa As String = CboPeriodoAcad.Items(p - 1).Value
        lblperiodoacad.Text = pa
        UpdateAsign.Update()
    End Sub
    Sub Periodo_Academico()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Detalle_Periodo,cod_periodo " & _
                    "FROM PERIODO order by cod_periodo desc "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PERIODO")
            CboPeriodoAcad.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboPeriodoAcad.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboPeriodoAcad.Items.Add("- Seleccione un periodo -")
                        CboPeriodoAcad.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboPeriodoAcad.Items.Add(v(0))
                        CboPeriodoAcad.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try

    End Sub
End Class
