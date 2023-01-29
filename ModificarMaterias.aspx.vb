
Imports System.Data
Imports System.Data.SqlClient

Partial Class ModificarMaterias
    Inherits System.Web.UI.Page
    Dim cod As String
    Dim tipo_us As Integer
    Private datosInf As DataSet
    Private datos, datos1 As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                cod = Session("user").ToString()
                Call cargarcarrera()

            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub
    Sub cargarParalelos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT paralelo " &
                    "FROM PARALELOS order by paralelo "
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
            'LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub
    Sub cargarhoras()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DetalleH,Numh " &
                    "FROM HorarioMatricula " &
                    "order by DetalleH "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "HorarioMatricula")

            i = datos.Tables(0).Rows.Count
            CboHorario.Items.Clear()
            If i > 0 Then
                CboHorario.DataSource = datos
                CboHorario.DataTextField = "DetalleH"
                CboHorario.DataValueField = "Numh"
                CboHorario.DataBind()

                'Add Default Item in the DropDownList
                CboHorario.Items.Insert(0, New ListItem("Seleccione"))

                CboHorario.Items.FindByValue(lblcodHorario.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: HORAS " & ex.Message

        End Try


    End Sub
    Sub cargarModalidad()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DetalleM,Numm " &
                    "FROM ModalidadMatricula " &
                    "order by DetalleM "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "ModalidadMatricula")
            i = datos.Tables(0).Rows.Count
            Cbomodalidad.Items.Clear()
            If i > 0 Then
                Cbomodalidad.DataSource = datos
                Cbomodalidad.DataTextField = "DetalleM"
                Cbomodalidad.DataValueField = "Numm"
                Cbomodalidad.DataBind()

                'Add Default Item in the DropDownList
                Cbomodalidad.Items.Insert(0, New ListItem("Seleccione"))

                Cbomodalidad.Items.FindByValue(lblcodmodalidad.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: MODALIDAD" & ex.Message

        End Try


    End Sub

    Sub cargarJornada()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Id_Jornada, DetalleJornada " &
                    "FROM JORNADA  " &
                    "order by DetalleJornada "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "JORNADA")
            i = datos.Tables(0).Rows.Count
            CboJornada.Items.Clear()
            If i > 0 Then
                CboJornada.DataSource = datos
                CboJornada.DataTextField = "DetalleJornada"
                CboJornada.DataValueField = "Id_Jornada"
                CboJornada.DataBind()

                'Add Default Item in the DropDownList
                CboJornada.Items.Insert(0, New ListItem("Seleccione"))

                CboJornada.Items.FindByValue(lblcodjornada.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            '    LabelErrorcab.Text = "ERROR: JORNADA" & ex.Message

        End Try


    End Sub

    Sub cargarParalelosave()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT num, paralelo " &
                    "FROM PARALELOS  " &
                    "order by paralelo "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PARALELOS")
            i = datos.Tables(0).Rows.Count
            cboparalelosave.Items.Clear()
            If i > 0 Then
                cboparalelosave.DataSource = datos
                cboparalelosave.DataTextField = "paralelo"
                cboparalelosave.DataValueField = "num"
                cboparalelosave.DataBind()

                'Add Default Item in the DropDownList
                cboparalelosave.Items.Insert(0, New ListItem("Seleccione"))

                cboparalelosave.Items.FindByText(lblparalsave.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            '  LabelErrorcab.Text = "ERROR: TIPO DE MATRICULA" & ex.Message

        End Try


    End Sub

    Sub cargarTipoMatricula()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT num, detalle " &
                    "FROM CONTROLMATRICULA  " &
                    "order by detalle "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CONTROLMATRICULA")
            i = datos.Tables(0).Rows.Count
            CboTipoMatricula.Items.Clear()
            If i > 0 Then
                CboTipoMatricula.DataSource = datos
                CboTipoMatricula.DataTextField = "detalle"
                CboTipoMatricula.DataValueField = "num"
                CboTipoMatricula.DataBind()

                'Add Default Item in the DropDownList
                CboTipoMatricula.Items.Insert(0, New ListItem("Seleccione"))

                CboTipoMatricula.Items.FindByValue(lbltipoMatricula.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            Dim er As String = "ERROR: TIPO DE MATRICULA" & ex.Message

        End Try


    End Sub
    Sub cargarDias()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Detalledias,numd " &
                    "FROM DiasMatricula " &
                    "order by Detalledias "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DiasMatricula")
            i = datos.Tables(0).Rows.Count
            CboDias.Items.Clear()
            If i > 0 Then
                CboDias.DataSource = datos
                CboDias.DataTextField = "Detalledias"
                CboDias.DataValueField = "numd"
                CboDias.DataBind()

                'Add Default Item in the DropDownList
                CboDias.Items.Insert(0, New ListItem("Seleccione"))

                CboDias.Items.FindByValue(lblcoddias.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            '  LabelErrorcab.Text = "ERROR: DIAS " & ex.Message

        End Try


    End Sub
    Sub cargarcarrera()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Nombre_Basica,Cod_AnioBasica " &
                    "FROM CARRERAS " &
                    "order by Nombre_Basica "
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
            '   LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub



    Sub cargarEstud()

        Dim daUs As SqlDataAdapter
        Dim sel, nomb As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            'Cod_Carrera=" & lblcodcarrera.Text & " and 
            nomb = txtapellido.Text.Replace(" ", "") & "%"
            sel = "SELECT distinct apellidos_nombre,codigo_estud " & _
                    "FROM DATOS_ESTUD where   apellidos_nombre like '" & nomb & "' " & _
                    "order by apellidos_nombre "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DATOS_ESTUD")
            CboEstudiantes.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboEstudiantes.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboEstudiantes.Items.Add("- Seleccione -")
                        CboEstudiantes.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboEstudiantes.Items.Add(v(0))
                        CboEstudiantes.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            Else
                CboEstudiantes.Items.Clear()
                lblcod_usu.Text = "0"
            End If

            cntDB.Close()
        Catch ex As Exception
            '     LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub



    Protected Sub CboAsignatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCarrera.SelectedIndexChanged
        Try


            Dim p As Integer = CboCarrera.SelectedIndex
            Dim codca As String = CboCarrera.Items(p - 1).Value

            lblcodcarrera.Text = codca
            Call Periodo_Academico()
            Call cargarMalla()


            '  Label63.Visible = True
            '  Label64.Visible = True
            '  Label65.Visible = True
            ' Cbomodalidad.Visible = True
            ' CboHorario.Visible = True
            ' CboDias.Visible = True



            UpdateAsign.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub Periodo_Academico()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Detalle_Periodo,cod_periodo " & _
                    "FROM PERIODO where Estado='A' "
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
    Sub vertipomateria()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try


            sel = "SELECT Detalle_Periodo,cod_periodo " &
                "FROM PERIODO where Estado='A' "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PERIODO")
            CboPeriodoAcad.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub vertipomatricula()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try

            sel = "SELECT detalle,num " &
                "FROM CONTROLMATRICULA where num=" & lbltipoMatricula.Text & " "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CONTROLMATRICULA")

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                lbdetalletipmatri.Text = datos.Tables(0).Rows(0).Item("detalle").ToString()
            Else
                lbdetalletipmatri.Text = Nothing
            End If
        Catch ex As Exception
            lblmensaje.Text = "ERROR: CONTROL MATRICULA" & ex.Message
        End Try
    End Sub
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer


        Try
            Dim p As Integer = CboCarrera.SelectedIndex

            If p = 0 Then
                lblerrorGrid.Text = "Seleccione una carrera ....."

                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If


            sel = "SELECT  *,CARRERAXESTUD.paralelo as pa,CARRERAXESTUD.num as mna,codigo_periodo,Nombre_Basica, CARRERAXESTUD.codigo_estud, DATOS_ESTUD.apellidos_nombre, CARRERAXESTUD.codigo_materia,Num_Matricula, " &
            "PENSUM.Nomb_Materia,Semestre,CARRERAXESTUD.num,Num_Folio, Num_Reg_Mat,NumGrupo FROM CARRERAS INNER JOIN  PENSUM INNER JOIN  DATOS_ESTUD INNER JOIN " &
            "CARRERAXESTUD ON DATOS_ESTUD.codigo_estud = CARRERAXESTUD.codigo_estud ON PENSUM.codigo_materia = CARRERAXESTUD.codigo_materia AND  " &
            "PENSUM.Cod_AnioBasica = CARRERAXESTUD.cod_anio_Basica ON CARRERAS.Cod_AnioBasica = CARRERAXESTUD.cod_anio_Basica " &
             "WHERE        (CARRERAXESTUD.codigo_estud = " & lblcod_usu.Text & ") and CARRERAXESTUD.cod_anio_Basica=" & lblcodcarrera.Text & " and CARRERAXESTUD.codigo_periodo=" & lblperiodoacad.Text & " and TipoMatricula='N'  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                GridView1.Visible = True
                GridView1.DataSource = datos
                GridView1.DataBind()
                lblparal.Text = datos.Tables(0).Rows(0).Item("paralelo").ToString()


            Else
                GridView1.Visible = False
            End If

            UpdatePanel6.Update()
            UpdateAsign.Update()

        Catch ex As Exception
            lblmensaje.Text = "ERROR: LISTA MATERIAS" & ex.Message
        End Try
    End Sub

    Sub vervalores()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Dim vm, vi, vt, ay, be, sm, bec As Double
        Try

            sel = "SELECT paralelo " &
"FROM  CARRERAXESTUD" &
" WHERE        (codigo_estud = " & lblcod_usu.Text & ") AND (codigo_periodo = " & lblperiodoacad.Text & ") AND (cod_anio_Basica = " & lblcodcarrera.Text & " ) "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "CARRERAXESTUD")
            i = datosInf.Tables(0).Rows.Count
            If i > 0 Then
                lblparalsave.Text = datosInf.Tables(0).Rows(0).Item("paralelo").ToString()

            Else
                lblparalsave.Text = "A"

            End If

            sel = "SELECT Jornada,codJornada,codhorario, codmodalidad, coddias,ControlMatricula " &
"FROM  CABECERA_MATRICULA" &
" WHERE        (codigo_estud = " & lblcod_usu.Text & ") AND (codigo_periodo = " & lblperiodoacad.Text & ") AND (cod_anio_Basica = " & lblcodcarrera.Text & " ) "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "CABECERA_MATRICULA")
            i = datosInf.Tables(0).Rows.Count
            If i > 0 Then
                lblcoddias.Text = datosInf.Tables(0).Rows(0).Item("coddias").ToString()
                lblcodmodalidad.Text = datosInf.Tables(0).Rows(0).Item("codmodalidad").ToString()
                lblcodHorario.Text = datosInf.Tables(0).Rows(0).Item("codhorario").ToString()
                lbltipoMatricula.Text = datosInf.Tables(0).Rows(0).Item("ControlMatricula").ToString()
                lblcodjornada.Text = datosInf.Tables(0).Rows(0).Item("codJornada").ToString()
                lbljornada.Text = datosInf.Tables(0).Rows(0).Item("Jornada").ToString()
            Else
                lblcoddias.Text = 1
                lblcodmodalidad.Text = 1
                lblcodHorario.Text = 1
                lbltipoMatricula.Text = 1
            End If



            sel = "SELECT codigo_estud, fecha_pago,MatriValor,InscripValor,AyudaEcono,Beca,cuota1,RecargoMatricula,jornada,ControlMatricula,ValorNivelacion,colegiatura,Reingreso " &
"FROM  CABECERA_MATRICULA_VARIOS " &
" WHERE        (codigo_estud = " & lblcod_usu.Text & ") AND (codigo_periodo = " & lblperiodoacad.Text & ") AND (cod_anio_Basica = " & lblcodcarrera.Text & " and NumGrupo=" & txtnumgrupo.Text & ") "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "CABECERA_MATRICULA_VARIOS")
            i = datosInf.Tables(0).Rows.Count
            If i > 0 Then
                txtFechaMatricula.Text = datosInf.Tables(0).Rows(0).Item("fecha_pago").ToString()
                txtcolegiatura.Text = datosInf.Tables(0).Rows(0).Item("colegiatura").ToString()
                txtmatricula.Text = datosInf.Tables(0).Rows(0).Item("MatriValor").ToString()
                txtAyudaEcono.Text = datosInf.Tables(0).Rows(0).Item("AyudaEcono").ToString()
                txtinscripcion.Text = datosInf.Tables(0).Rows(0).Item("InscripValor").ToString()
                txtBeca.Text = datosInf.Tables(0).Rows(0).Item("Beca").ToString()
                ' lbljornada.Text = datosInf.Tables(0).Rows(0).Item("Jornada").ToString()
                txtRecSegMatricula.Text = datosInf.Tables(0).Rows(0).Item("RecargoMatricula").ToString()
                txtvalorNivela.Text = datosInf.Tables(0).Rows(0).Item("ValorNivelacion").ToString()
                txtreingreso.Text = datosInf.Tables(0).Rows(0).Item("Reingreso").ToString()

                If txtmatricula.Text.Length > 0 Then
                    vm = txtmatricula.Text
                Else
                    vm = 0
                End If

                If txtinscripcion.Text.Length > 0 Then
                    vi = txtinscripcion.Text
                Else
                    vi = 0
                End If

                If txtcolegiatura.Text.Length > 0 Then
                    vt = txtcolegiatura.Text
                Else
                    vt = 0
                End If

                If txtAyudaEcono.Text.Length > 0 Then
                    ay = txtAyudaEcono.Text
                Else
                    ay = 0
                End If

                If txtBeca.Text.Length > 0 Then
                    bec = txtBeca.Text
                Else
                    bec = 0
                End If

                If txtRecSegMatricula.Text.Length > 0 Then
                    sm = txtRecSegMatricula.Text
                Else
                    sm = 0
                End If

                '    txtcolegiatura.Text = (vm + vi + vt) - (ay + be)
            Else

                txtFechaMatricula.Text = Date.Now
                txtcolegiatura.Text = Nothing
                txtmatricula.Text = Nothing
                txtAyudaEcono.Text = Nothing
                txtinscripcion.Text = Nothing
                txtBeca.Text = Nothing
                lbljornada.Text = Nothing
                txtRecSegMatricula.Text = Nothing
                txtvalorNivela.Text = Nothing
                lbltipoMatricula.Text = 1
                txtreingreso.Text = Nothing
            End If
            UpdatePanel6.Update()
        Catch ex As Exception
            '  lblmensaje.Text = ex.Message
        End Try

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim cod_mat As String
        Dim n As Integer
        Try


            If Not (fila Is Nothing) Then
                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.DeleteCommand = "DELETE FROM CARRERAXESTUD WHERE  num=@num  "
                SqlDataSource1.DeleteParameters.Add(New Parameter("cod_mat", TypeCode.String))
                SqlDataSource1.DeleteParameters.Add(New Parameter("num", TypeCode.Int64))
                SqlDataSource1.DeleteParameters("cod_mat").DefaultValue = CType(fila.FindControl("LblCodMateria"), Label).Text
                SqlDataSource1.DeleteParameters("num").DefaultValue = CType(fila.FindControl("Lblnum"), Label).Text
                cod_mat = CType(fila.FindControl("LblCodMateria"), Label).Text
                n = CType(fila.FindControl("Lblnum"), Label).Text

                SqlDataSource1.Delete()

                EnlazarDatos()
                UpdatePanel6.Update()

                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.DeleteCommand = "DELETE FROM CARRERA_ESTUD_MES WHERE  num = " & n & " "
                SqlDataSource1.Delete()

                EnlazarDatos()
                UpdatePanel6.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        EnlazarDatos()
    End Sub

    Protected Sub cdmverasignatura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverasignatura.Click
        lblmensaje.Text = Nothing
        Call verdatos()

    End Sub

    Sub verdatos()
        txtcolegiatura.Text = Nothing
        txtinscripcion.Text = Nothing
        txtmatricula.Text = Nothing
        txtAyudaEcono.Text = Nothing
        txtRecSegMatricula.Text = Nothing
        txtBeca.Text = Nothing
        LabelErrorcab.Text = Nothing

        'Call cargarMalla()
        Call tipoPeriodoNotas()
        '  Call cargarParalelos()
        Call vervalores()

        Call cargarTipoMatricula()
        Call EnlazarDatos()
        Call numgrupo()
        Call cargarParalelosave()
        Call cargarJornada()
        Call cargarhoras()
        Call cargarModalidad()
        Call cargarDias()

        Call vertipomatricula()

        lblvaloractua.Text = Nothing

        If lblcod_usu.Text.Length = 0 Then
            lblerrorGrid.Text = "Seleccione el estudiante"
            Exit Sub
        End If
        Session.Add("cod_usu", lblcod_usu.Text)
        Session.Add("cod_periodo", lblperiodoacad.Text)
        Session.Add("cod_carrera", lblcodcarrera.Text)
        Session.Add("grupo", txtnumgrupo.Text)
    End Sub

    Protected Sub CboEstudiantes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboEstudiantes.SelectedIndexChanged
        Dim p As Integer = Me.CboEstudiantes.SelectedIndex
        Dim codest As String = CboEstudiantes.Items(p - 1).Value

        lblcod_usu.Text = codest

        UpdateAsign.Update()

    End Sub
    Sub cargarMalla()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Malla,NUM " &
                    "FROM MALLA_PENSUM  " &
                    "WHERE Cod_CARRERA=" & lblcodcarrera.Text & "  and estado='A' " &
                        "order by MALLA "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MALLA_PENSUM")
            CboMalla.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboMalla.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboMalla.Items.Add("- Seleccione una malla -")
                        CboMalla.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboMalla.Items.Add(v(0))
                        CboMalla.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: EN LA MALLA"

        End Try


    End Sub
    Sub cargarasignaturas()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT distinct Nomb_Materia,PENSUM.codigo_materia " & _
                    "FROM PENSUM  " & _
                    "WHERE Semestre=" & CboPeriodo.Text & " and Cod_AnioBasica=" & lblcodcarrera.Text & "  and NumMalla=" & lblmalla.Text & " " & _
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
        Call vercredvalor()

        ' lblmensaje.Text = Nothing
        UpdateAsign.Update()

    End Sub


    Sub tipoPeriodoNotas()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        sel = "SELECT  VersionCalificacion from PERIODO " & _
                     "WHERE cod_periodo=" & lblperiodoacad.Text & "  "
        daUs = New SqlDataAdapter(sel, cntDB)
        datos = New DataSet
        datos.Clear()
        daUs.Fill(datos, "PERIODO")
        i = datos.Tables(0).Rows.Count
        If i > 0 Then
            lblperiodotipo.Text = datos.Tables(0).Rows(0).Item(0).ToString()
        Else
            lblperiodotipo.Text = 0
        End If
    End Sub



    Sub vercredvalor()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        sel = "SELECT  Creditos from pensum " & _
                     "WHERE Cod_AnioBasica=" & lblcodcarrera.Text & "  "
        daUs = New SqlDataAdapter(sel, cntDB)
        datos = New DataSet
        datos.Clear()
        daUs.Fill(datos, "PENSUM")
        i = datos.Tables(0).Rows.Count
        If i > 0 Then
            LblNumCreditos.Text = datos.Tables(0).Rows(0).Item(0).ToString()

        Else
            LblNumCreditos.Text = 0
        End If
    End Sub
    Protected Sub cdmverasignaturaCarr0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverasignaturaCarr0.Click
        Dim sel, tm, seln, sel1 As String
        Dim valor As Double

        Dim daUs As SqlDataAdapter
        Dim ds As New DataSet
        Dim i, nume As Integer
        Try

            lblmensaje.Text = Nothing

            Dim p As Integer = CboCarrera.SelectedIndex

        If p = 0 Then
            lblerrorGrid.Text = "Seleccione un Curso ....."
            UpdatePanel6.Update()
            Exit Sub
        Else
            lblerrorGrid.Text = ""
        End If

            If lbltipoMatricula.Text = 0 Then
                lblerrorGrid.Text = "Seleccione un tipo de matricula ....."
                UpdatePanel6.Update()
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If

            If lblcodjornada.Text = 0 Then
                lblcodjornada.Text = "Seleccione la jornada ....."
                UpdatePanel6.Update()
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If



            If txtFechaMatricula.Text = Nothing Then
                lblerrorGrid.Text = "Revise los datos de matricula ....."
                UpdatePanel6.Update()
                Exit Sub
            End If

            If txtinscripcion.Text.Length > 0 Then
                txtinscripcion.Text = txtinscripcion.Text.Replace(".", ",")
            Else
                txtinscripcion.Text = 0
            End If

            If lblparal.Text = Nothing Then
                lblerrorGrid.Text = "Revise el paralelo ....."
                UpdatePanel6.Update()
                Exit Sub
            End If

            If txtmatricula.Text.Length > 0 Then
                txtmatricula.Text = txtmatricula.Text.Replace(".", ",")
            Else
                txtmatricula.Text = 0
            End If



            If txtAyudaEcono.Text.Length > 0 Then
                txtAyudaEcono.Text = txtAyudaEcono.Text.Replace(".", ",")
            Else
                txtAyudaEcono.Text = 0
            End If

            If txtcolegiatura.Text.Length > 0 Then
                txtcolegiatura.Text = txtcolegiatura.Text.Replace(".", ",")
            Else
                txtcolegiatura.Text = 0
            End If
            If txtRecSegMatricula.Text.Length > 0 Then
                txtRecSegMatricula.Text = txtRecSegMatricula.Text.Replace(".", ",")
            Else
                txtRecSegMatricula.Text = 0
            End If
            If txtBeca.Text.Length > 0 Then
                txtBeca.Text = txtBeca.Text.Replace(".", ",")
            Else
                txtBeca.Text = 0
            End If
            If CboPeriodo.Text = 0 Then
                tm = "X"
            Else
                tm = "N"
            End If


            sel1 = "SELECT  max(num) as nume from CARRERAXESTUD "
            daUs = New SqlDataAdapter(sel1, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                nume = datos.Tables(0).Rows(0).Item("nume").ToString() + 1

            End If


            sel = "INSERT INTO CARRERAXESTUD " &
                          "(codigo_estud,cod_anio_Basica,codigo_materia,Num_Matricula,codigo_periodo,usuario,Num_Creditos,Fecha_Matricula,controlperiodo,paralelo,TipoMatricula,ControlMatricula,NumGrupo) " &
                          "VALUES " &
                          "(@codigo_estud,@cod_anio_Basica,@codigo_materia,@Num_Matricula,@codigo_periodo,@usuario,@Num_Creditos,@Fecha_Matricula,@controlperiodo,@paralelo,@TipoMatricula,@ControlMatricula,@NumGrupo) "
            Dim cmd As New SqlCommand(sel, cntDB)

        cmd.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
        cmd.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, String))
        cmd.Parameters.AddWithValue("codigo_materia", CType(lblcodasign.Text, String))
            cmd.Parameters.AddWithValue("Num_Matricula", CType(CboNumMatricula.Text, Integer))
            cmd.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))
        cmd.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
        cmd.Parameters.AddWithValue("Num_Creditos", CType(LblNumCreditos.Text, Integer))
            cmd.Parameters.AddWithValue("paralelo", CType(lblparal.Text, String))
            cmd.Parameters.AddWithValue("TipoMatricula", CType(tm, String))
            cmd.Parameters.AddWithValue("Fecha_Matricula", CType(txtFechaMatricula.Text, Date))
            '  cmd.Parameters.AddWithValue("Num_Reg_Mat", CType(txtNumMat.Text, Integer))
            cmd.Parameters.AddWithValue("controlperiodo", CType(lblperiodotipo.Text, Integer))
            cmd.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmd.Parameters.AddWithValue("NumGrupo", CType(txtnumgrupo.Text, Integer))
            '  cmd.Parameters.AddWithValue("num", CType(nume, Integer))
            Try
                cntDB.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                lblmensaje.Text = "Revise los datos o ya existe esta materia ingresada"
            End Try


            sel = "INSERT INTO CABECERA_MATRICULA " &
                      "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica, codigo_materia, codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,codhorario, codmodalidad, coddias,codjornada ) " &
                      "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_materia,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@codhorario, @codmodalidad, @coddias,@codjornada ) "
            Dim cmde As New SqlCommand(sel, cntDB)

        cmde.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
        cmde.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmde.Parameters.AddWithValue("codigo_materia", CType(0, Integer))
        cmde.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmde.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmde.Parameters.AddWithValue("valor", CType(0, Double))

            cmde.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmde.Parameters.AddWithValue("InscripValor", CType(0, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmde.Parameters.AddWithValue("MatriValor", CType(0, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If
            cmde.Parameters.AddWithValue("Cuota1", CType(0, Double))



            'AyudaEcono
            cmde.Parameters.AddWithValue("AyudaEcono", CType(0, Double))
            cmde.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))
            cmde.Parameters.AddWithValue("codjornada", CType(lblcodjornada.Text, Integer))

            cmde.Parameters.AddWithValue("RecargoMatricula", CType(0, Double))
            cmde.Parameters.AddWithValue("Beca", CType(0, Double))
            cmde.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmde.Parameters.AddWithValue("ValorNivelacion", CType(0, Double))

            cmde.Parameters.AddWithValue("codhorario", CType(lblcodHorario.Text, Integer))
            cmde.Parameters.AddWithValue("codmodalidad", CType(lblcodmodalidad.Text, Integer))
            cmde.Parameters.AddWithValue("coddias", CType(lblcoddias.Text, Integer))

            Try
                cntDB.Open()
                Dim te As Integer = CInt(cmde.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                cntDB.Close()
            End Try

            'VARIAS MATRICULAS
            seln = "INSERT INTO CABECERA_MATRICULA_VARIOS " &
                      "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica,  codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,NUMGRUPO,Reingreso ) " &
                      "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@numgrupo,@Reingreso ) "
            Dim cmden As New SqlCommand(seln, cntDB)

            cmden.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
            cmden.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmden.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmden.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmden.Parameters.AddWithValue("valor", CType(valor, Double))

            cmden.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmden.Parameters.AddWithValue("InscripValor", CType(txtinscripcion.Text, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmden.Parameters.AddWithValue("MatriValor", CType(txtmatricula.Text, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If
            cmden.Parameters.AddWithValue("Cuota1", CType(txtcolegiatura.Text, Double))
            'AyudaEcono
            cmden.Parameters.AddWithValue("AyudaEcono", CType(txtAyudaEcono.Text, Double))
            cmden.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))

            cmden.Parameters.AddWithValue("RecargoMatricula", CType(txtRecSegMatricula.Text, Double))
            cmden.Parameters.AddWithValue("Beca", CType(txtBeca.Text, Double))
            cmden.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmden.Parameters.AddWithValue("ValorNivelacion", CType(txtvalorNivela.Text, Double))
            cmden.Parameters.AddWithValue("numgrupo", CType(txtnumgrupo.Text, Integer))

            If txtreingreso.Text = Nothing Then
                txtreingreso.Text = 0
            End If
            cmden.Parameters.AddWithValue("Reingreso", CType(txtreingreso.Text, Double))

            Try
                cntDB.Open()
                Dim ten As Integer = CInt(cmden.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                cntDB.Close()
            End Try


            Call EnlazarDatos()

            Call verdatos()

            lblmensaje.Text = "** Ingresado **"
        UpdateAsign.Update()
        Catch ex As Exception
            ' lblmensaje.Text = "Revise los datos"
            Call EnlazarDatos()
        End Try


        Session.Add("cod_usu", lblcod_usu.Text)
        Session.Add("cod_periodo", lblperiodoacad.Text)
        Session.Add("cod_carrera", lblcodcarrera.Text)
        Session.Add("grupo", txtnumgrupo.Text)

    End Sub
    Sub grabarcabecerupdate()

        Dim sel, tm, seln As String
        Dim valor As Double
        Try


            Dim p As Integer = CboCarrera.SelectedIndex

            If p = 0 Then
                lblerrorGrid.Text = "Seleccione un Curso ....."
                UpdatePanel6.Update()
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If

            If lbltipoMatricula.Text = 0 Then
                lblerrorGrid.Text = "Seleccione un tipo de matricula ....."
                UpdatePanel6.Update()
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If

            If txtFechaMatricula.Text = Nothing Then
                lblerrorGrid.Text = "Revise los datos de matricula ....."
                UpdatePanel6.Update()
                Exit Sub
            End If

            If txtinscripcion.Text.Length > 0 Then
                txtinscripcion.Text = txtinscripcion.Text.Replace(".", ",")
            Else
                txtinscripcion.Text = 0
            End If

            If lblparal.Text = Nothing Then
                lblerrorGrid.Text = "Revise el paralelo ....."
                UpdatePanel6.Update()
                Exit Sub
            End If

            If txtmatricula.Text.Length > 0 Then
                txtmatricula.Text = txtmatricula.Text.Replace(".", ",")
            Else
                txtmatricula.Text = 0
            End If



            If txtAyudaEcono.Text.Length > 0 Then
                txtAyudaEcono.Text = txtAyudaEcono.Text.Replace(".", ",")
            Else
                txtAyudaEcono.Text = 0
            End If

            If txtcolegiatura.Text.Length > 0 Then
                txtcolegiatura.Text = txtcolegiatura.Text.Replace(".", ",")
            Else
                txtcolegiatura.Text = 0
            End If
            If txtRecSegMatricula.Text.Length > 0 Then
                txtRecSegMatricula.Text = txtRecSegMatricula.Text.Replace(".", ",")
            Else
                txtRecSegMatricula.Text = 0
            End If

            'txtvalorNivela.Text

            If txtvalorNivela.Text.Length > 0 Then
                txtvalorNivela.Text = txtvalorNivela.Text.Replace(".", ",")
            Else
                txtvalorNivela.Text = 0
            End If


            If txtBeca.Text.Length > 0 Then
                txtBeca.Text = txtBeca.Text.Replace(".", ",")
            Else
                txtBeca.Text = 0
            End If
            If CboPeriodo.Text = 0 Then
                tm = "X"
            Else
                tm = "N"
            End If


            sel = "INSERT INTO CABECERA_MATRICULA " &
                      "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica, codigo_materia, codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,codhorario, codmodalidad, coddias,codjornada ) " &
                      "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_materia,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@codhorario, @codmodalidad, @coddias,@codjornada ) "
            Dim cmde As New SqlCommand(sel, cntDB)

            cmde.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
            cmde.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmde.Parameters.AddWithValue("codigo_materia", CType(0, Integer))
            cmde.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmde.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmde.Parameters.AddWithValue("valor", CType(0, Double))

            cmde.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmde.Parameters.AddWithValue("InscripValor", CType(0, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmde.Parameters.AddWithValue("MatriValor", CType(0, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If
            cmde.Parameters.AddWithValue("Cuota1", CType(0, Double))
            'AyudaEcono
            cmde.Parameters.AddWithValue("AyudaEcono", CType(0, Double))
            cmde.Parameters.AddWithValue("jornada", CType(lbljornada.Text.TrimEnd, String))
            cmde.Parameters.AddWithValue("codjornada", CType(lblcodjornada.Text, Integer))

            cmde.Parameters.AddWithValue("RecargoMatricula", CType(0, Double))
            cmde.Parameters.AddWithValue("Beca", CType(0, Double))
            cmde.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmde.Parameters.AddWithValue("ValorNivelacion", CType(0, Double))

            cmde.Parameters.AddWithValue("codhorario", CType(lblcodHorario.Text, Integer))
            cmde.Parameters.AddWithValue("codmodalidad", CType(lblcodmodalidad.Text, Integer))
            cmde.Parameters.AddWithValue("coddias", CType(lblcoddias.Text, Integer))

            Try
                cntDB.Open()
                Dim te As Integer = CInt(cmde.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                cntDB.Close()
            End Try

            'VARIAS MATRICULAS
            seln = "INSERT INTO CABECERA_MATRICULA_VARIOS " &
                      "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica,  codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,NUMGRUPO ) " &
                      "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@numgrupo ) "
            Dim cmden As New SqlCommand(seln, cntDB)

            cmden.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
            cmden.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmden.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmden.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmden.Parameters.AddWithValue("valor", CType(valor, Double))

            cmden.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmden.Parameters.AddWithValue("InscripValor", CType(txtinscripcion.Text, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmden.Parameters.AddWithValue("MatriValor", CType(txtmatricula.Text, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If
            cmden.Parameters.AddWithValue("Cuota1", CType(txtcolegiatura.Text, Double))
            'AyudaEcono
            cmden.Parameters.AddWithValue("AyudaEcono", CType(txtAyudaEcono.Text, Double))
            cmden.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))

            cmden.Parameters.AddWithValue("RecargoMatricula", CType(txtRecSegMatricula.Text, Double))
            cmden.Parameters.AddWithValue("Beca", CType(txtBeca.Text, Double))
            cmden.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmden.Parameters.AddWithValue("ValorNivelacion", CType(txtvalorNivela.Text, Double))
            cmden.Parameters.AddWithValue("numgrupo", CType(txtnumgrupo.Text, Integer))

            Try
                cntDB.Open()
                Dim ten As Integer = CInt(cmden.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                cntDB.Close()
            End Try


            Call EnlazarDatos()



            lblmensaje.Text = "** Ingresado **"
            UpdateAsign.Update()
        Catch ex As Exception
            ' lblmensaje.Text = "Revise los datos"
            Call EnlazarDatos()
        End Try


    End Sub


    Sub actualizacabecera()
        Dim sel As String
        If txtFechaMatricula.Text = Nothing Then
            lblerrorGrid.Text = "Revise los datos de matricula ....."
            UpdatePanel6.Update()
            Exit Sub
        End If

        If txtinscripcion.Text.Length > 0 Then
            txtinscripcion.Text = txtinscripcion.Text.Replace(".", ",")
        Else
            txtinscripcion.Text = 0
        End If


        If txtmatricula.Text.Length > 0 Then
            txtmatricula.Text = txtmatricula.Text.Replace(".", ",")
        Else
            txtmatricula.Text = 0
        End If


        If txtAyudaEcono.Text.Length > 0 Then
            txtAyudaEcono.Text = txtAyudaEcono.Text.Replace(".", ",")
        Else
            txtAyudaEcono.Text = 0
        End If

        If txtcolegiatura.Text.Length > 0 Then
            txtcolegiatura.Text = txtcolegiatura.Text.Replace(".", ",")
        Else
            txtcolegiatura.Text = 0
        End If
        If txtRecSegMatricula.Text.Length > 0 Then
            txtRecSegMatricula.Text = txtRecSegMatricula.Text.Replace(".", ",")
        Else
            txtRecSegMatricula.Text = 0
        End If
        If txtBeca.Text.Length > 0 Then
            txtBeca.Text = txtBeca.Text.Replace(".", ",")
        Else
            txtBeca.Text = 0
        End If

        If txtreingreso.Text.Length > 0 Then
            txtreingreso.Text = txtreingreso.Text.Replace(".", ",")
        Else
            txtreingreso.Text = 0
        End If

        sel = "update CABECERA_MATRICULA_VARIOS  set " &
              "fecha_pago=@fecha_pago,Beca=@Beca,RecargoMatricula=@RecargoMatricula,  InscripValor=@InscripValor, MatriValor=@MatriValor, Cuota1=@Cuota1, jornada=@jornada,AyudaEcono=@AyudaEcono,ValorNivelacion=@ValorNivelacion, Reingreso=@Reingreso where codigo_periodo=" & lblperiodoacad.Text & " and cod_anio_Basica=" & lblcodcarrera.Text & " and codigo_estud=" & lblcod_usu.Text & " "

        Dim cmde As New SqlCommand(sel, cntDB)

        If txtinscripcion.Text = Nothing Then
            txtinscripcion.Text = 0
        End If
        cmde.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
        cmde.Parameters.AddWithValue("InscripValor", CType(txtinscripcion.Text, Double))
        If txtmatricula.Text = Nothing Then
            txtmatricula.Text = 0
        End If
        cmde.Parameters.AddWithValue("MatriValor", CType(txtmatricula.Text, Double))
        If txtcolegiatura.Text = Nothing Then
            txtcolegiatura.Text = 0
        End If
        cmde.Parameters.AddWithValue("Cuota1", CType(txtcolegiatura.Text, Double))
        'AyudaEcono
        cmde.Parameters.AddWithValue("AyudaEcono", CType(txtAyudaEcono.Text, Double))
        cmde.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))


        cmde.Parameters.AddWithValue("RecargoMatricula", CType(txtRecSegMatricula.Text, Double))
        cmde.Parameters.AddWithValue("Beca", CType(txtBeca.Text, Double))
        If txtreingreso.Text.Length > 0 Then
            txtreingreso.Text = txtreingreso.Text.Replace(".", ",")
        Else
            txtreingreso.Text = 0
        End If
        cmde.Parameters.AddWithValue("Reingreso", CType(txtreingreso.Text, Double))
        cmde.Parameters.AddWithValue("ValorNivelacion", CType(txtvalorNivela.Text, Double))


        Try
            cntDB.Open()
            Dim te As Integer = CInt(cmde.ExecuteScalar())
            cntDB.Close()
            UpdateAsign.Update()
        Catch ex As Exception
            '  lblmensaje.Text = ex.Message

        End Try


        sel = "update CABECERA_MATRICULA  set " &
            "jornada=@jornada,codJornada=@codJornada,codhorario=@codhorario,codmodalidad=@codmodalidad,coddias=@coddias where codigo_periodo=" & lblperiodoacad.Text & " and cod_anio_Basica=" & lblcodcarrera.Text & " and codigo_estud=" & lblcod_usu.Text & " "

        Dim cmdex As New SqlCommand(sel, cntDB)


        cmdex.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))
        cmdex.Parameters.AddWithValue("codJornada", CType(lblcodjornada.Text, Integer))

        cmdex.Parameters.AddWithValue("codhorario", CType(lblcodHorario.Text, Integer))
        cmdex.Parameters.AddWithValue("codmodalidad", CType(lblcodmodalidad.Text, Integer))
        cmdex.Parameters.AddWithValue("coddias", CType(lblcoddias.Text, Integer))

        Try
            cntDB.Open()
            Dim tex As Integer = CInt(cmdex.ExecuteScalar())
            cntDB.Close()
            UpdateAsign.Update()
        Catch ex As Exception
            '  lblmensaje.Text = ex.Message

        End Try

        sel = "update CARRERAXESTUD  set " &
            "paralelo=@paralelo where codigo_periodo=" & lblperiodoacad.Text & " and cod_anio_Basica=" & lblcodcarrera.Text & " and codigo_estud=" & lblcod_usu.Text & " "

        Dim cmdey As New SqlCommand(sel, cntDB)


        cmdey.Parameters.AddWithValue("paralelo", CType(lblparalsave.Text, String))


        Try
            cntDB.Open()
            Dim tex As Integer = CInt(cmdey.ExecuteScalar())
            cntDB.Close()
            lblvaloractua.Text = "** Valores Actualizados **"
            UpdateAsign.Update()
        Catch ex As Exception
            ' lblmensaje.Text = ex.Message

        End Try

    End Sub
    Protected Sub cmdvernombre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdvernombre.Click
        Try

            Call cargarEstud()
            Call cargarParalelosave()
            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub CboPeriodoAcad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPeriodoAcad.SelectedIndexChanged
        Try

            Dim p As Integer = CboPeriodoAcad.SelectedIndex
            Dim codpacad As String = CboPeriodoAcad.Items(p - 1).Value
            LabelErrorcab.Text = Nothing
            lblperiodoacad.Text = codpacad
            Me.UpdatePCabecera.Update()
            Call cargarMalla()
            Call tipoPeriodoNotas()
            Call cargarParalelos()
            Call vervalores()

            Call cargarTipoMatricula()
            Call EnlazarDatos()
            Call numgrupo()
            Call cargarParalelosave()
            Call cargarJornada()
            Call cargarhoras()
            Call cargarModalidad()
            Call cargarDias()

            Call vertipomatricula()
            '  lbltipoMatricula.Text = 0
            UpdatePanel6.Update()

            Session.Add("cod_usu", lblcod_usu.Text)
            Session.Add("cod_periodo", lblperiodoacad.Text)
            Session.Add("cod_carrera", lblcodcarrera.Text)
            Session.Add("grupo", txtnumgrupo.Text)

        Catch ex As Exception

        End Try
    End Sub
    Sub numgrupo()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            Dim p As Integer = CboCarrera.SelectedIndex

            If p = 0 Then
                lblerrorGrid.Text = "Seleccione una carrera ....."
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If


            '            sel = "SELECT        MAX(NumGrupo) AS nx, codigo_estud, cod_anio_Basica, codigo_periodo, TipoMatricula " &
            '"FROM            dbo.CARRERAXESTUD " &
            '"GROUP BY codigo_estud, cod_anio_Basica, codigo_periodo, TipoMatricula " &
            '"HAVING        (codigo_estud = " & lblcod_usu.Text & ") AND (cod_anio_Basica = " & lblcodcarrera.Text & ") AND (codigo_periodo = " & lblperiodoacad.Text & ") AND (TipoMatricula = 'N') ORDER BY nx DESC "

            sel = "SELECT   NumGrupo, codigo_estud, cod_anio_Basica, codigo_periodo, TipoMatricula " &
          "FROM           NumeroGrupo " &
         "where    (codigo_estud = " & lblcod_usu.Text & ") AND (cod_anio_Basica = " & lblcodcarrera.Text & ") AND (codigo_periodo = " & lblperiodoacad.Text & ") AND (TipoMatricula = 'N') ORDER BY NumGrupo "

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            Cbotipogrupo.DataSource = datos

            i = datos.Tables(0).Rows.Count
            Cbotipogrupo.Items.Clear()
            If i > 0 Then

                For c = 0 To i

                    If c < i Then
                        v = datos.Tables(0).Rows(c)
                        Cbotipogrupo.Items.Add(v(0))
                    ElseIf c = i Then
                        v = datos.Tables(0).Rows(c - 1)
                        Cbotipogrupo.Items.Add(v(0) + 1)
                    End If
                Next c
            Else
                Cbotipogrupo.Items.Add("0")
                Cbotipogrupo.Items.Item(0).Value = "0"
                Cbotipogrupo.Items.Add("1")
                Cbotipogrupo.Items.Item(0).Value = "1"
            End If
            txtnumgrupo.Text = 0
            UpdatePanel6.Update()
            UpdateAsign.Update()

        Catch ex As Exception

            lblmensaje.Text = "ERROR: TIPODE GRUPO" & ex.Message
        End Try
    End Sub
    Protected Sub cdmverasignaturaCarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverasignaturaCarr.Click

        Try

            cargarasignaturas()
            UpdateIngAsig.Update()
            UpdateAsign.Update()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub CboMalla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMalla.SelectedIndexChanged
        Try

            Dim p As Integer = CboMalla.SelectedIndex
            Dim codca As String = CboMalla.Items(p).Text
            lblmalla.Text = codca
            UpdateAsign.Update()

        Catch ex As Exception

        End Try



    End Sub
    Protected Sub CmdActualizaValores_Click(sender As Object, e As EventArgs) Handles CmdActualizaValores.Click
        cntDB.Close()
        Call grabacabecera()

        Call actualizacabecera()

        Call verdatos()
    End Sub
    Sub grabacabecera()
        Dim sel As String
        Dim valor As Double

        Try

            sel = "INSERT INTO CABECERA_MATRICULA_VARIOS " &
                     "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica, NumGrupo, codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion ) " &
                     "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@NumGrupo,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion ) "
            Dim cmde As New SqlCommand(sel, cntDB)

            cmde.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
            cmde.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmde.Parameters.AddWithValue("NumGrupo", CType(txtnumgrupo.Text, Integer))
            cmde.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmde.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmde.Parameters.AddWithValue("valor", CType(valor, Double))

            cmde.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmde.Parameters.AddWithValue("InscripValor", CType(txtinscripcion.Text, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmde.Parameters.AddWithValue("MatriValor", CType(txtmatricula.Text, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If

            cmde.Parameters.AddWithValue("Cuota1", CType(txtcolegiatura.Text, Double))
            'AyudaEcono
            If txtAyudaEcono.Text = Nothing Then
                txtAyudaEcono.Text = 0
            End If
            cmde.Parameters.AddWithValue("AyudaEcono", CType(txtAyudaEcono.Text, Double))
            cmde.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))

            If txtRecSegMatricula.Text = Nothing Then
                txtRecSegMatricula.Text = 0
            End If

            cmde.Parameters.AddWithValue("RecargoMatricula", CType(txtRecSegMatricula.Text, Double))
            If txtBeca.Text = Nothing Then
                txtBeca.Text = 0
            End If
            cmde.Parameters.AddWithValue("Beca", CType(txtBeca.Text, Double))
            cmde.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))

            If txtvalorNivela.Text = Nothing Then
                txtvalorNivela.Text = 0
            End If
            cmde.Parameters.AddWithValue("ValorNivelacion", CType(txtvalorNivela.Text, Double))
            If txtreingreso.Text.Length > 0 Then
                txtreingreso.Text = txtreingreso.Text.Replace(".", ",")
            Else
                txtreingreso.Text = 0
            End If

            cmde.Parameters.AddWithValue("Reingreso", CType(txtreingreso.Text, Double))

            cntDB.Open()
            Dim te As Integer = CInt(cmde.ExecuteScalar())
            cntDB.Close()

        Catch ex As Exception
            cntDB.Close()
        End Try
    End Sub
    Protected Sub cdmmatPeriodo_Click(sender As Object, e As EventArgs) Handles cdmmatPeriodo.Click
        Dim daUs, Daus1 As SqlDataAdapter
        Dim sel, sel1, selm, seln As String
        Dim ds As New DataSet
        Dim i, codm, cre, nume As Integer
        Dim v As DataRow
        Dim valor As Double
        Try

            lblmensaje.Text = Nothing
            Dim p As Integer = CboCarrera.SelectedIndex

            If p = 0 Then
                lblerrorGrid.Text = "Seleccione un Curso ....."
                UpdatePanel6.Update()
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If

            If lbltipoMatricula.Text = 0 Then
                lblerrorGrid.Text = "Seleccione un tipo de matricula ....."
                UpdatePanel6.Update()
                Exit Sub
            Else
                lblerrorGrid.Text = ""
            End If

            If txtFechaMatricula.Text = Nothing Then
                lblerrorGrid.Text = "Revise los datos de matricula ....."
                UpdatePanel6.Update()
                Exit Sub
            End If

            If lblparal.Text = Nothing Then
                lblerrorGrid.Text = "Revise el paralelo ....."
                UpdatePanel6.Update()
                Exit Sub
            End If

            If txtinscripcion.Text.Length > 0 Then
                txtinscripcion.Text = txtinscripcion.Text.Replace(".", ",")
            Else
                txtinscripcion.Text = 0
            End If


            If txtmatricula.Text.Length > 0 Then
                txtmatricula.Text = txtmatricula.Text.Replace(".", ",")
            Else
                txtmatricula.Text = 0
            End If



            If txtAyudaEcono.Text.Length > 0 Then
                txtAyudaEcono.Text = txtAyudaEcono.Text.Replace(".", ",")
            Else
                txtAyudaEcono.Text = 0
            End If

            If txtcolegiatura.Text.Length > 0 Then
                txtcolegiatura.Text = txtcolegiatura.Text.Replace(".", ",")
            Else
                txtcolegiatura.Text = 0
            End If
            If txtRecSegMatricula.Text.Length > 0 Then
                txtRecSegMatricula.Text = txtRecSegMatricula.Text.Replace(".", ",")
            Else
                txtRecSegMatricula.Text = 0
            End If
            If txtBeca.Text.Length > 0 Then
                txtBeca.Text = txtBeca.Text.Replace(".", ",")
            Else
                txtBeca.Text = 0
            End If

            If txtreingreso.Text.Length > 0 Then
                txtreingreso.Text = txtreingreso.Text.Replace(".", ",")
            Else
                txtreingreso.Text = 0
            End If




            selm = "SELECT Creditos,PENSUM.codigo_materia " &
                        "FROM PENSUM  " &
                        "WHERE Semestre=" & CboPeriodo.Text & " and Cod_AnioBasica=" & lblcodcarrera.Text & "  and NumMalla=" & lblmalla.Text & " " &
                            "order by Nomb_Materia "
            daUs = New SqlDataAdapter(selm, cntDB)
            datos = New DataSet
                datos.Clear()
                daUs.Fill(datos, "PENSUM")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                For j = 0 To i - 1
                    sel1 = "SELECT  max(num) as nume from CARRERAXESTUD "
                    daUs1 = New SqlDataAdapter(sel1, cntDB)
                    datos1 = New DataSet
                    datos1.Clear()
                    daUs1.Fill(datos1, "CARRERAXESTUD")
                    nume = datos1.Tables(0).Rows(0).Item("nume").ToString() + 1


                    codm = datos.Tables(0).Rows(j).Item("codigo_materia").ToString
                    cre = datos.Tables(0).Rows(j).Item("Creditos").ToString
                    sel = "INSERT INTO CARRERAXESTUD " &
                              "(codigo_estud,cod_anio_Basica,codigo_materia,Num_Matricula,codigo_periodo,usuario,Num_Creditos,Fecha_Matricula,controlperiodo,paralelo,ControlMatricula,NumGrupo) " &
                              "VALUES " &
                              "(@codigo_estud,@cod_anio_Basica,@codigo_materia,@Num_Matricula,@codigo_periodo,@usuario,@Num_Creditos,@Fecha_Matricula,@controlperiodo,@paralelo,@ControlMatricula,@NumGrupo) "
                    Dim cmd As New SqlCommand(sel, cntDB)

                    cmd.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
                    cmd.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, String))
                    cmd.Parameters.AddWithValue("codigo_materia", CType(codm, Integer))
                    cmd.Parameters.AddWithValue("Num_Matricula", CType(CboNumMatricula.Text, Integer))
                    cmd.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))
                    cmd.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
                    cmd.Parameters.AddWithValue("Num_Creditos", CType(cre, Integer))
                    cmd.Parameters.AddWithValue("paralelo", CType(lblparal.Text, String))
                    '      cmd.Parameters.AddWithValue("Num_Folio", CType(txtNumFolio.Text, Integer))
                    cmd.Parameters.AddWithValue("Fecha_Matricula", CType(txtFechaMatricula.Text, Date))
                    '  cmd.Parameters.AddWithValue("Num_Reg_Mat", CType(txtNumMat.Text, Integer))
                    cmd.Parameters.AddWithValue("controlperiodo", CType(lblperiodotipo.Text, Integer))
                    cmd.Parameters.AddWithValue("ControlMatricula", CType(lblperiodotipo.Text, Integer))

                    cmd.Parameters.AddWithValue("NumGrupo", CType(txtnumgrupo.Text, Integer))
                    '   cmd.Parameters.AddWithValue("Num", CType(nume, Integer))
                    Try
                        cntDB.Open()
                        Dim t As Integer = CInt(cmd.ExecuteScalar())
                        cntDB.Close()
                    Catch ex As Exception
                        cntDB.Close()
                    End Try

                Next j
            End If


            sel = "INSERT INTO CABECERA_MATRICULA " &
                      "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica, codigo_materia, codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,codhorario, codmodalidad, coddias,codJornada ) " &
                      "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_materia,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@codhorario, @codmodalidad, @coddias,@codJornada ) "
            Dim cmde As New SqlCommand(sel, cntDB)

            cmde.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
            cmde.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmde.Parameters.AddWithValue("codigo_materia", CType(0, Integer))
            cmde.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmde.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmde.Parameters.AddWithValue("valor", CType(valor, Double))

            cmde.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmde.Parameters.AddWithValue("InscripValor", CType(txtinscripcion.Text, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmde.Parameters.AddWithValue("MatriValor", CType(txtmatricula.Text, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If
            cmde.Parameters.AddWithValue("Cuota1", CType(txtcolegiatura.Text, Double))
            'AyudaEcono
            If txtAyudaEcono.Text = Nothing Then
                txtAyudaEcono.Text = 0
            End If
            cmde.Parameters.AddWithValue("AyudaEcono", CType(txtAyudaEcono.Text, Double))
            cmde.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))
            cmde.Parameters.AddWithValue("codJornada", CType(lblcodjornada.Text, Integer))
            If txtRecSegMatricula.Text = Nothing Then
                txtRecSegMatricula.Text = 0
            End If
            cmde.Parameters.AddWithValue("RecargoMatricula", CType(txtRecSegMatricula.Text, Double))
            If txtBeca.Text = Nothing Then
                txtBeca.Text = 0
            End If
            cmde.Parameters.AddWithValue("Beca", CType(txtBeca.Text, Double))
            cmde.Parameters.AddWithValue("ControlMatricula", CType(lblperiodotipo.Text, Integer))
            If txtvalorNivela.Text = Nothing Then
                txtvalorNivela.Text = 0
            End If
            cmde.Parameters.AddWithValue("ValorNivelacion", CType(txtvalorNivela.Text, Double))

            cmde.Parameters.AddWithValue("codhorario", CType(lblcodHorario.Text, Integer))
            cmde.Parameters.AddWithValue("codmodalidad", CType(lblcodmodalidad.Text, Integer))
            cmde.Parameters.AddWithValue("coddias", CType(lblcoddias.Text, Integer))


            Try
                cntDB.Open()
                Dim te As Integer = CInt(cmde.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                cntDB.Close()
                'lblmensaje.Text = ex.Message
            End Try



            'VARIAS MATRICULAS
            seln = "INSERT INTO CABECERA_MATRICULA_VARIOS " &
                      "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica,  codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,NUMGRUPO,Reingreso ) " &
                      "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@numgrupo,@Reingreso ) "
            Dim cmden As New SqlCommand(seln, cntDB)

            cmden.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
            cmden.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, Integer))
            cmden.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))

            cmden.Parameters.AddWithValue("fecha_pago", CType(txtFechaMatricula.Text, Date))
            cmden.Parameters.AddWithValue("valor", CType(valor, Double))

            cmden.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
            If txtinscripcion.Text = Nothing Then
                txtinscripcion.Text = 0
            End If
            cmden.Parameters.AddWithValue("InscripValor", CType(txtinscripcion.Text, Double))
            If txtmatricula.Text = Nothing Then
                txtmatricula.Text = 0
            End If
            cmden.Parameters.AddWithValue("MatriValor", CType(txtmatricula.Text, Double))
            If txtcolegiatura.Text = Nothing Then
                txtcolegiatura.Text = 0
            End If
            cmden.Parameters.AddWithValue("Cuota1", CType(txtcolegiatura.Text, Double))
            'AyudaEcono
            cmden.Parameters.AddWithValue("AyudaEcono", CType(txtAyudaEcono.Text, Double))
            cmden.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))

            cmden.Parameters.AddWithValue("RecargoMatricula", CType(txtRecSegMatricula.Text, Double))
            cmden.Parameters.AddWithValue("Beca", CType(txtBeca.Text, Double))
            cmden.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmden.Parameters.AddWithValue("ValorNivelacion", CType(txtvalorNivela.Text, Double))
            cmden.Parameters.AddWithValue("numgrupo", CType(txtnumgrupo.Text, Integer))
            'Reingreso
            If txtreingreso.Text.Length > 0 Then
                txtreingreso.Text = txtreingreso.Text.Replace(".", ",")
            Else
                txtreingreso.Text = 0
            End If
            cmden.Parameters.AddWithValue("Reingreso", CType(txtreingreso.Text, Double))

            Try
                cntDB.Open()
                Dim ten As Integer = CInt(cmden.ExecuteScalar())
                cntDB.Close()
            Catch ex As Exception
                cntDB.Close()
            End Try



            Call EnlazarDatos()

            Call verdatos()
            lblmensaje.Text = "** Ingresado **"
            UpdateAsign.Update()
        Catch ex As Exception
            '  lblmensaje.Text = ex.Message
            Call EnlazarDatos()
        End Try


        Session.Add("cod_usu", lblcod_usu.Text)
        Session.Add("cod_periodo", lblperiodoacad.Text)
        Session.Add("cod_carrera", lblcodcarrera.Text)
        Session.Add("grupo", txtnumgrupo.Text)
    End Sub
    Protected Sub CboParalelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboParalelo.SelectedIndexChanged
        Dim p As Integer = CboParalelo.SelectedIndex
        Dim pa As String = CboParalelo.Items(p).Value
        lblparal.Text = pa
        UpdateAsign.Update()
    End Sub
    Protected Sub CboTipoMatricula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTipoMatricula.SelectedIndexChanged
        Try

            Dim p As Integer = CboTipoMatricula.SelectedIndex
            Dim codpacad As String = CboTipoMatricula.Items(p).Value

            lbltipoMatricula.Text = codpacad

        Catch ex As Exception
            lbltipoMatricula.Text = 0
        End Try
    End Sub
    Protected Sub cmdtipomat_Click(sender As Object, e As EventArgs) Handles cmdtipomat.Click
        Dim sel As String
        Try
            Call grabarcabecerupdate()
            sel = "update  CABECERA_MATRICULA " &
             " set ControlMatricula=@ControlMatricula,jornada=@jornada,codjornada=@codjornada " &
             "where codigo_estud=" & lblcod_usu.Text & " and codigo_periodo=" & lblperiodoacad.Text & " and cod_anio_Basica =" & lblcodcarrera.Text & " "

            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("@ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmd.Parameters.AddWithValue("@jornada", CType(lbljornada.Text, String))
            cmd.Parameters.AddWithValue("@codjornada", CType(lblcodjornada.Text, Integer))
            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()

            sel = "update  CARRERAXESTUD " &
               " set ControlMatricula=@ControlMatricula,paralelo=@paralelo " &
               "where codigo_estud=" & lblcod_usu.Text & " and codigo_periodo=" & lblperiodoacad.Text & " and cod_anio_Basica =" & lblcodcarrera.Text & " "

            Dim cmd1 As New SqlCommand(sel, cntDB)
            cmd1.Parameters.AddWithValue("@ControlMatricula", CType(lbltipoMatricula.Text, Integer))
            cmd1.Parameters.AddWithValue("@paralelo", CType(lblparalsave.Text, String))
            cntDB.Open()
            Dim t1 As Integer = CInt(cmd1.ExecuteScalar())
            cntDB.Close()

            lblmensaje.Text = "Tipo de matricula actualizado"
            Session.Add("cod_usu", lblcod_usu.Text)
            Session.Add("cod_periodo", lblperiodoacad.Text)
            Session.Add("cod_carrera", lblcodcarrera.Text)
            Session.Add("grupo", txtnumgrupo.Text)

            Call verdatos()

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub Cbotipogrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbotipogrupo.SelectedIndexChanged
        Dim p As Integer = Cbotipogrupo.SelectedIndex
        Dim pa As String = Cbotipogrupo.Items(p).Value
        txtnumgrupo.Text = pa

        Call vervalores()
        Session.Add("grupo", txtnumgrupo.Text)
        UpdateAsign.Update()
    End Sub

    Protected Sub Cbomodalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbomodalidad.SelectedIndexChanged
        Try
            Dim p As Integer = Cbomodalidad.SelectedIndex
            Dim pa As String = Cbomodalidad.Items(p).Value
            lblcodmodalidad.Text = pa
            UpdateAsign.Update()
        Catch ex As Exception
            lblcodmodalidad.Text = 1
        End Try

    End Sub
    Protected Sub CboDias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDias.SelectedIndexChanged
        Try
            Dim p As Integer = CboDias.SelectedIndex
            Dim pa As String = CboDias.Items(p).Value
            lblcoddias.Text = pa
            UpdateAsign.Update()
        Catch ex As Exception
            lblcoddias.Text = 1
        End Try

    End Sub
    Protected Sub CboHorario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboHorario.SelectedIndexChanged
        Try
            Dim p As Integer = CboHorario.SelectedIndex
            Dim pa As String = CboHorario.Items(p).Value
            lblcodHorario.Text = pa
            UpdateAsign.Update()
        Catch ex As Exception
            lblcodHorario.Text = 1
        End Try

    End Sub
    Protected Sub CboJornada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboJornada.SelectedIndexChanged
        Try
            Dim p As Integer = CboJornada.SelectedIndex
            Dim pa As String = CboJornada.Items(p).Value
            lblcodjornada.Text = pa
            Dim pax As String = CboJornada.Items(p).Text
            lbljornada.Text = pax

        Catch ex As Exception
            Dim r As String = ex.Message
        End Try
    End Sub

    Protected Sub cboparalelosave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboparalelosave.SelectedIndexChanged
        Try
            Dim p As Integer = cboparalelosave.SelectedIndex
            Dim pa As String = cboparalelosave.Items(p).Text
            lblparalsave.Text = pa
            UpdateAsign.Update()
        Catch ex As Exception
            Dim r As String = ex.Message
        End Try
    End Sub



End Class
