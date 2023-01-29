Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Threading
Imports System.Web.UI
Imports AjaxControlToolkit

Partial Class Vinculacion
    Inherits System.Web.UI.Page
    Dim cod As String
    Dim tipo_us As Integer
    Private datosInf As DataSet
    Private datos, datos2 As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                cod = Session("user").ToString()
                lblcod_usu.Text = cod
                Call cargarcarrera()
            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub
    Private Sub EMPRESA()
        Dim daUs2 As SqlDataAdapter
        Dim sel2 As String
        Dim ds2 As New DataSet
        Dim i2 As Integer

        Try
            sel2 = "SELECT  Empresa,Num_emp " &
                    "FROM EMPRESA " &
                    "order by Empresa "
            daUs2 = New SqlDataAdapter(sel2, cntDB)
            datos2 = New DataSet
            datos2.Clear()
            daUs2.Fill(datos2, "EMPRESA")
            CboEmpresa.DataSource = datos2

            i2 = datos2.Tables(0).Rows.Count
            If i2 > 0 Then
                CboEmpresa.DataTextField = "Empresa"
                CboEmpresa.DataValueField = "Num_emp"
                CboEmpresa.DataBind()

                CboEmpresa.Items.Insert(0, New ListItem("Seleccione"))
                If lblCodEmpresa.Text <> "" Then
                    CboEmpresa.Items.FindByValue(lblCodEmpresa.Text).Selected = True
                End If

            Else
                CboEmpresa.Items.Clear()
            End If

            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try
    End Sub

    Private Sub DoceResponsable()
        Dim daUs2 As SqlDataAdapter
        Dim sel2 As String
        Dim ds2 As New DataSet
        Dim i2 As Integer

        Try
            sel2 = "SELECT  codigo_doc,apellidos_nombre " &
                    "FROM DATOSDOCENTE " &
                    "order by codigo_doc "
            daUs2 = New SqlDataAdapter(sel2, cntDB)
            datos2 = New DataSet
            datos2.Clear()
            daUs2.Fill(datos2, "DATOSDOCENTE")
            CboDoceResponsable.DataSource = datos2

            i2 = datos2.Tables(0).Rows.Count
            If i2 > 0 Then
                CboDoceResponsable.DataTextField = "apellidos_nombre"
                CboDoceResponsable.DataValueField = "codigo_doc"
                CboDoceResponsable.DataBind()

                CboDoceResponsable.Items.Insert(0, New ListItem("Seleccione"))
                If lblcoddocresp.Text <> "" Then
                    CboDoceResponsable.Items.FindByValue(lblcoddocresp.Text).Selected = True
                End If

            Else
                CboDoceResponsable.Items.Clear()
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

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
            LabelErrorcab.Text = "ERROR: " & ex.Message

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
            sel = "SELECT distinct apellidos_nombre, DATOS_ESTUD.codigo_estud " &
                    "FROM DATOS_ESTUD,CABECERA_MATRICULA where cod_anio_Basica= " & lblcodcarrera.Text & " and DATOS_ESTUD.codigo_estud=CABECERA_MATRICULA.codigo_estud and apellidos_nombre like '" & nomb & "' " &
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
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub



    Protected Sub CboAsignatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCarrera.SelectedIndexChanged
        Try


            Dim p As Integer = CboCarrera.SelectedIndex
            Dim codca As String = CboCarrera.Items(p - 1).Value

            lblcodcarrera.Text = codca
            Call Periodo_Academico()

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
            sel = "SELECT Detalle_Periodo,cod_periodo " &
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
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel, sel1 As String
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


            sel = "SELECT  *,dbo.DATOS_ESTUD.Apellidos_nombre AS na, dbo.EMPRESA.Empresa, dbo.PRACTICASVINCULACION.FechaInicio, dbo.PRACTICASVINCULACION.FechaFinal, dbo.PRACTICASVINCULACION.NoHoras,Semestre, " &
                        " dbo.DATOSDOCENTE.apellidos_nombre As NombDoc, dbo.PRACTICASVINCULACION.DetalleProyecto, dbo.PRACTICASVINCULACION.num, dbo.PRACTICASVINCULACION.codigo_estud,  " &
                        " dbo.PRACTICASVINCULACION.cod_anio_Basica, dbo.PRACTICASVINCULACION.codigo_periodo, dbo.PERIODO.Detalle_Periodo,pathAr " &
                        " From dbo.DATOSDOCENTE INNER Join dbo.PRACTICASVINCULACION On dbo.DATOSDOCENTE.codigo_doc = dbo.PRACTICASVINCULACION.CodDocente INNER Join " &
                       "  dbo.EMPRESA ON dbo.PRACTICASVINCULACION.Cod_empresa = dbo.EMPRESA.Num_emp INNER JOIN   dbo.DATOS_ESTUD On dbo.PRACTICASVINCULACION.codigo_estud = dbo.DATOS_ESTUD.codigo_estud INNER Join " &
                        " dbo.PERIODO On dbo.PRACTICASVINCULACION.codigo_periodo = dbo.PERIODO.cod_periodo " &
                        " WHERE        (dbo.PRACTICASVINCULACION.codigo_estud = " & lblcod_usu.Text & ") And (dbo.PRACTICASVINCULACION.cod_anio_Basica = " & lblcodcarrera.Text & " ) "

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                GridView1.Visible = True
                GridView1.DataSource = datos
                GridView1.DataBind()
                lblnombestud.Text = datos.Tables(0).Rows(0).Item("na").ToString()

            Else
                GridView1.Visible = False
                lblnombestud.Text = Nothing
            End If


            sel1 = "SELECT        SUM(NoHoras) AS nh FROM            dbo.PRACTICASVINCULACION " &
                "GROUP BY codigo_estud HAVING   (codigo_estud = " & lblcod_usu.Text & ")"

            daUs = New SqlDataAdapter(sel1, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PRACTICASVINCULACION")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                lblHoras.Text = datos.Tables(0).Rows(0).Item("nh").ToString()
                CmdNuevoIngreso.Visible = True
                CmdActualizaValoresExiste.Visible = False

            End If

            UpdatePanel6.Update()


        Catch ex As Exception
            lblerrorGrid.Text = ex.Message
        End Try
    End Sub

    Private Sub EnlazarDatosPeriodo()

        Dim daUs As SqlDataAdapter
        Dim sel, sel1 As String
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


            sel = "SELECT  *,dbo.DATOS_ESTUD.Apellidos_nombre, dbo.EMPRESA.Empresa, dbo.PRACTICASVINCULACION.FechaInicio, dbo.PRACTICASVINCULACION.FechaFinal, dbo.PRACTICASVINCULACION.NoHoras,Semestre, " &
                        " dbo.DATOSDOCENTE.apellidos_nombre As NombDoc, dbo.PRACTICASVINCULACION.DetalleProyecto, dbo.PRACTICASVINCULACION.num, dbo.PRACTICASVINCULACION.codigo_estud,  " &
                        " dbo.PRACTICASVINCULACION.cod_anio_Basica, dbo.PRACTICASVINCULACION.codigo_periodo, dbo.PERIODO.Detalle_Periodo,pathAr " &
                        " From dbo.DATOSDOCENTE INNER Join dbo.PRACTICASVINCULACION On dbo.DATOSDOCENTE.codigo_doc = dbo.PRACTICASVINCULACION.CodDocente INNER Join " &
                       "  dbo.EMPRESA ON dbo.PRACTICASVINCULACION.Cod_empresa = dbo.EMPRESA.Num_emp INNER JOIN   dbo.DATOS_ESTUD On dbo.PRACTICASVINCULACION.codigo_estud = dbo.DATOS_ESTUD.codigo_estud INNER Join " &
                        " dbo.PERIODO On dbo.PRACTICASVINCULACION.codigo_periodo = dbo.PERIODO.cod_periodo " &
                        " WHERE        (dbo.PRACTICASVINCULACION.codigo_estud = " & lblcod_usu.Text & ") And (dbo.PRACTICASVINCULACION.cod_anio_Basica = " & lblcodcarrera.Text & " )  And (dbo.PRACTICASVINCULACION.codigo_periodo = " & lblperiodoacad.Text & " )  "

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                GridView1.Visible = True
                GridView1.DataSource = datos
                GridView1.DataBind()


            Else
                GridView1.Visible = False
                lblnombestud.Text = Nothing
            End If


            sel1 = "SELECT        SUM(NoHoras) AS nh FROM            dbo.PRACTICASVINCULACION " &
                "GROUP BY codigo_estud HAVING   (codigo_estud = " & lblcod_usu.Text & ")"

            daUs = New SqlDataAdapter(sel1, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PRACTICASVINCULACION")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                lblHoras.Text = datos.Tables(0).Rows(0).Item("nh").ToString()
                CmdNuevoIngreso.Visible = False
                CmdActualizaValoresExiste.Visible = True
            Else
                lblHoras.Text = Nothing
                CmdNuevoIngreso.Visible = True
                CmdActualizaValoresExiste.Visible = False
            End If

            UpdatePanel6.Update()


        Catch ex As Exception
            lblerrorGrid.Text = ex.Message
        End Try
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim cod_mat As String
        Try


            If Not (fila Is Nothing) Then
                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.DeleteCommand = "DELETE FROM PRACTICASVINCULACION WHERE num=@num  "
                SqlDataSource1.DeleteParameters.Add(New Parameter("num", TypeCode.Int64))
                SqlDataSource1.DeleteParameters("num").DefaultValue = CType(fila.FindControl("Lblnum"), Label).Text

                SqlDataSource1.Delete()
                EnlazarDatos()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex

        EnlazarDatos()
    End Sub

    Protected Sub cdmverasignatura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmverInformacion.Click


        txtNumHoras.Text = Nothing

        txtproyecto.Text = Nothing
        lblnombestud.Text = Nothing

        Call EnlazarDatos()


        If lblcod_usu.Text.Length = 0 Then
            lblerrorGrid.Text = "Seleccione el estudiante"
            Exit Sub
        End If
        Session.Add("cod_usu", lblcod_usu.Text)
        Session.Add("cod_periodo", lblperiodoacad.Text)
        Session.Add("cod_carrera", lblcodcarrera.Text)

        CmdNuevoIngreso.Visible = True
        CmdActualizaValoresExiste.Visible = False

    End Sub

    Protected Sub CboEstudiantes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboEstudiantes.SelectedIndexChanged
        Dim p As Integer = Me.CboEstudiantes.SelectedIndex
        Dim codest As String = CboEstudiantes.Items(p - 1).Value

        lblcod_usu.Text = codest

    End Sub

    Sub actualizacabecera()
        Dim sel As String
        Try

            If txtFechaInicio.Text = Nothing Or txtFechaFinal.Text = Nothing Then
                lblerrorGrid.Text = "Revise los datos de la fecha ....."
                UpdatePanel6.Update()
                Exit Sub
            End If



        Catch ex As Exception
            'lblmensaje.Text = ex.Message

        End Try
    End Sub
    Protected Sub cmdvernombre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdvernombre.Click
        Try

            Call cargarEstud()
            UpdatePCabecera.Update()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub CboPeriodoAcad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPeriodoAcad.SelectedIndexChanged
        Try

            Dim p As Integer = CboPeriodoAcad.SelectedIndex
            Dim codpacad As String = CboPeriodoAcad.Items(p - 1).Value

            lblperiodoacad.Text = codpacad
            Me.UpdatePCabecera.Update()
            Call EMPRESA()

            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub CmdActualizaValores_Click(sender As Object, e As EventArgs) Handles CmdNuevoIngreso.Click
        Dim sel As String
        Dim fi, ff As Date
        fi = txtFechaInicio.Text
        ff = txtFechaFinal.Text
        Call guardaarchivo()
        If fi > ff Then
            lblerrorGrid.Text = "Fecha Incorrecta"
            Exit Sub
        End If

        sel = "INSERT INTO PRACTICASVINCULACION " &
                              "(codigo_estud, cod_anio_Basica, codigo_periodo, Cod_empresa, FechaInicio, FechaFinal, NoHoras, CodDocente, DetalleProyecto,Semestre,pathAr,NombreProyecto) " &
                              "VALUES " &
                              "(@codigo_estud, @cod_anio_Basica, @codigo_periodo, @Cod_empresa, @FechaInicio, @FechaFinal, @NoHoras, @CodDocente, @DetalleProyecto, @Semestre, @pathAr,@NombreProyecto) "
        Dim cmd As New SqlCommand(sel, cntDB)

        cmd.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
        cmd.Parameters.AddWithValue("cod_anio_Basica", CType(lblcodcarrera.Text, String))
        cmd.Parameters.AddWithValue("codigo_periodo", CType(lblperiodoacad.Text, Integer))
        cmd.Parameters.AddWithValue("Cod_empresa", CType(lblCodEmpresa.Text, Integer))
        cmd.Parameters.AddWithValue("FechaInicio", CType(txtFechaInicio.Text, Date))
        cmd.Parameters.AddWithValue("FechaFinal", CType(txtFechaFinal.Text, Date))

        cmd.Parameters.AddWithValue("NoHoras", CType(txtNumHoras.Text, Integer))
        cmd.Parameters.AddWithValue("CodDocente", CType(lblcoddocresp.Text, Integer))
        cmd.Parameters.AddWithValue("DetalleProyecto", CType(txtproyecto.Text, String))
        cmd.Parameters.AddWithValue("Semestre", CType(cboSemestre.Text, Integer))

        cmd.Parameters.AddWithValue("pathAr", CType(lblpatharc.Text, String))
        cmd.Parameters.AddWithValue("NombreProyecto", CType(txtNombProyecto.Text, String))

        Try
            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()
            Call EnlazarDatos()
            Call encerardatos()
            lblerrorGrid.Text = "Datos generados"
        Catch ex As Exception
            cntDB.Close()
            lblerrorGrid.Text = ex.Message
        End Try
    End Sub

    Sub encerardatos()
        lblextension.Text = Nothing
        txtFechaInicio.Text = Nothing
        txtFechaFinal.Text = Nothing
        txtNumHoras.Text = Nothing
        txtproyecto.Text = Nothing

    End Sub
    Sub guardaarchivo()

        Dim savePath As String = Server.MapPath("~/Archivos/")
        Dim nombarchivo1 As String
        Dim nombarchivo, d1 As String
        Try
            If lblperiodoacad.Text = Nothing Then
                lblerrorGrid.Text = "Seleccione el periodo"
                Exit Sub
            End If
            If Me.FileUpload1.HasFile Then
                Thread.Sleep(1000)
                nombarchivo1 = FileUpload1.FileName
                Dim fileExtension As String
                fileExtension = System.IO.Path.
                GetExtension(FileUpload1.FileName).ToLower()
                lblextension.Text = fileExtension
                d1 = Day(txtFechaInicio.Text) & Month(txtFechaInicio.Text) & Year(txtFechaInicio.Text)
                nombarchivo = lblcod_usu.Text & "-" & lblperiodoacad.Text & d1 & fileExtension
                nombarchivo = nombarchivo.Replace(" ", "")
                savePath += nombarchivo

                lblpatharc.Text = nombarchivo
                FileUpload1.SaveAs(savePath)

            Else
                '  Me.lblNombArchivo.Text = "Hay que insertar un fichero"
            End If



        Catch ex As Exception
            lblerrorGrid.Text = "ERROR: " & ex.Message
        End Try
    End Sub

    Protected Sub CboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEmpresa.SelectedIndexChanged
        Dim p As Integer = CboEmpresa.SelectedIndex
        Dim code As String = CboEmpresa.Items(p).Value
        lblCodEmpresa.Text = code
        Call DoceResponsable()

    End Sub
    Protected Sub CboDoceResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDoceResponsable.SelectedIndexChanged
        Dim p As Integer = CboDoceResponsable.SelectedIndex
        Dim coddoc As String = CboDoceResponsable.Items(p).Value
        lblcoddocresp.Text = coddoc

    End Sub


    Protected Sub CmdActualizaValoresExiste_Click(sender As Object, e As EventArgs) Handles CmdActualizaValoresExiste.Click
        Dim sel, nombarchivo As String
        Dim fi, ff As Date
        fi = txtFechaInicio.Text
        ff = txtFechaFinal.Text
        Call guardaarchivo()
        If fi > ff Then
            lblerrorGrid.Text = "Fecha Incorrecta"
            Exit Sub
        End If

        sel = "update PRACTICASVINCULACION SET " &
                              " FechaInicio=@FechaInicio, FechaFinal=@FechaFinal, NoHoras=@NoHoras, CodDocente=@CodDocente, DetalleProyecto= @DetalleProyecto,Semestre=@Semestre,pathAr= @pathAr,NombreProyecto=@NombreProyecto " &
                              "where  num=" & lblnumregistro.Text & "  "

        Dim cmd As New SqlCommand(sel, cntDB)

        cmd.Parameters.AddWithValue("FechaInicio", CType(txtFechaInicio.Text, Date))
        cmd.Parameters.AddWithValue("FechaFinal", CType(txtFechaFinal.Text, Date))

        cmd.Parameters.AddWithValue("NoHoras", CType(txtNumHoras.Text, Integer))
        cmd.Parameters.AddWithValue("CodDocente", CType(lblcoddocresp.Text, Integer))
        cmd.Parameters.AddWithValue("DetalleProyecto", CType(txtproyecto.Text, String))
        cmd.Parameters.AddWithValue("Semestre", CType(cboSemestre.Text, Integer))


        cmd.Parameters.AddWithValue("pathAr", CType(lblpatharc.Text, String))
        cmd.Parameters.AddWithValue("NombreProyecto", CType(txtNombProyecto.Text, String))
        Try
            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()
            Call EnlazarDatos()
            Call encerardatos()
            lblerrorGrid.Text = "Datos generados"
        Catch ex As Exception
            cntDB.Close()
            lblerrorGrid.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim fila As Integer = e.RowIndex

        Try

            If fila >= 0 Then

                Dim fi As Label = DirectCast(GridView1.Rows(fila).FindControl("Lblfi"), Label)
                txtFechaInicio.Text = fi.Text
                Dim ff As Label = DirectCast(GridView1.Rows(fila).FindControl("Lblff"), Label)
                txtFechaFinal.Text = ff.Text
                Dim nh As Label = DirectCast(GridView1.Rows(fila).FindControl("lblhoras"), Label)
                txtNumHoras.Text = nh.Text
                Dim dp As Label = DirectCast(GridView1.Rows(fila).FindControl("lblproyectogrid"), Label)
                txtproyecto.Text = dp.Text
                Dim code As Label = DirectCast(GridView1.Rows(fila).FindControl("lblcodempresa"), Label)
                lblCodEmpresa.Text = code.Text
                Dim codd As Label = DirectCast(GridView1.Rows(fila).FindControl("lblcoddoc"), Label)
                lblcoddocresp.Text = codd.Text
                Dim se As Label = DirectCast(GridView1.Rows(fila).FindControl("lblseme"), Label)
                cboSemestre.Text = se.Text
                Dim lblnumr As Label = DirectCast(GridView1.Rows(fila).FindControl("lblnum"), Label)
                lblnumregistro.Text = lblnumr.Text

                Dim lblpath As Label = DirectCast(GridView1.Rows(fila).FindControl("lblpatharc"), Label)
                lblpatharc.Text = lblpath.Text
                Call EMPRESA()
                Call DoceResponsable()
            End If
            CmdNuevoIngreso.Visible = False
            CmdActualizaValoresExiste.Visible = True
        Catch ex As Exception
            lblerrorGrid.Text = ex.Message
        End Try
    End Sub
End Class
