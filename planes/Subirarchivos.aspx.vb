
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Subirarchivos
    Inherits System.Web.UI.Page
    Private datos As DataSet
    Dim cod As String
    Dim tipo_us As Integer
    Dim cod_curso As String
    Public cont, cargaFileUp As Integer
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                cod = Session("user").ToString()
                tipo_us = Session("tusu").ToString()
                Call PeriodoAcad()

                Call vertamaperarchivo()

            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub
    Sub PeriodoAcad()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT cod_periodo, PERIODO.Detalle_Periodo " & _
                "FROM  PERIODO where estado='A' " & _
                " order by cod_periodo "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "periodo")

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
                        CboPeriodoAcad.Items.Add(v(1))
                        CboPeriodoAcad.Items.Item(c - 1).Value = v(0)
                    End If
                Next c
            End If
            cntDB.Close()
        Catch ex As Exception
            'LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub
    Sub cargardocente()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow


        Try
            sel = "SELECT distinct apellidos_nombre,CARRERAXDOCENTE.codigo_doc " & _
                    "FROM DATOSDOCENTE,CARRERAXDOCENTE where  DATOSDOCENTE.codigo_doc=CARRERAXDOCENTE.codigo_doc and  codigo_periodo=" & lblpacad.Text & "  " & _
                        "order by apellidos_nombre "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DATOSDOCENTE")
            cbodocente.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                cbodocente.Items.Clear()
                For c = 0 To i
                    If c = 0 Then
                        cbodocente.Items.Add("- Seleccione un docente -")
                        cbodocente.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        cbodocente.Items.Add(v(0))
                        cbodocente.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            'LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try

    End Sub
    Sub vertamaperarchivo()
        'cod = 2 esta asignado al tamaño de los archivos adjuntos a cada unidad
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim v As DataRow
        Try
            sel = "SELECT NumBytes " & _
                            "FROM TAMANIOARCHIVOS where Cod=2 "

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "TAMANIOARCHIVOS")
            v = datos.Tables(0).Rows(0)

        Catch ex As Exception

        End Try

    End Sub
    Sub cargarAnioBasica()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow


        Try
            sel = "SELECT Abrevia,CARRERAS.Num, CARRERAXDOCENTE.codigo_periodo,  CARRERAXDOCENTE.codigo_doc, CARRERAS.Paralelo " & _
                    "FROM         CARRERAXDOCENTE INNER JOIN CARRERAS ON CARRERAXDOCENTE.Paralelo = CARRERAS.Paralelo COLLATE SQL_Latin1_General_CP1_CI_AS AND " & _
                    "CARRERAXDOCENTE.cod_Anio_Basica = CARRERAS.NUM  " & _
                    "WHERE     (CARRERAXDOCENTE.codigo_doc = '" & lblcod_usu.Text & "') AND (CARRERAXDOCENTE.codigo_periodo = " & Me.lblpacad.Text & ")  " & _
                    "ORDER BY CARRERAS.Nombre_Basica"

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXDOCENTE")
            CboAnioBasica.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboAnioBasica.Items.Clear()
                For c = 0 To i
                    If c = 0 Then
                        CboAnioBasica.Items.Add("- Seleccione un curso -")
                        CboAnioBasica.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboAnioBasica.Items.Add(v(0))
                        CboAnioBasica.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

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
                     "WHERE(codigo_doc = '" & lblcod_usu.Text & "') and cod_Anio_Basica=" & lblCodanioBasica.Text & "  AND  CARRERAXDOCENTE.codigo_materia=PENSUM.codigo_materia " & _
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
                        CboAsignatura.Items.Add("- Seleccione  -")
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

    Protected Sub CboAsignatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAsignatura.SelectedIndexChanged
        Try


            Dim p As Integer = CboAsignatura.SelectedIndex
            Dim codm As String = CboAsignatura.Items(p - 1).Value
            lblnoorden.Text = 0
            lblcodmateria.Text = codm
            UpdatePanel5.Update()

        Catch ex As Exception

        End Try

    End Sub


    Sub DisplayFileContents(ByVal file As HttpPostedFile)

        Dim fileLen As Integer
        Dim displayString As New StringBuilder()

        ' Get the length of the file.
        fileLen = FileUpload1.PostedFile.ContentLength
        ' Display the length of the file in a label.
        LengthLabel.Text = "Tamaño del archivo " & "  " & FileUpload1.PostedFile.FileName & " : " & fileLen.ToString & " " & " bytes.  "

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSaveVF.Click

        Dim savePath As String = Server.MapPath("~/website/archivos/")
        Dim nombarchivo As String
        Dim FileLen As Integer
        Try

            UploadStatusLabel.Text = Nothing
            nombarchivo = FileUpload1.FileName
            nombarchivo = nombarchivo.Replace(" ", "")
            savePath += nombarchivo
            ' Verifica si el archivo existe en la carpeta designada 
            Dim f As New IO.FileInfo(savePath)

            FileLen = FileUpload1.PostedFile.ContentLength
            If FileLen > 100000000 Then

                lblMenstamarchivo.Text = "Exedió el tamaño del archivo a subir"
                lbltamarchivo.Text = FileLen & "   " & "Bytes"
                Exit Sub
            End If


            If f.Exists = True Then
                lbldatoserroneosOpcional.Text = "Cambie el nombre del archivo a subir y ejecute nuevamente  "
                MsgBox1.ShowMessage("Modifique el nombre del archivo por qué ya existe")
                UpdateResVF.Update()
                Exit Sub
            End If


            If txtDetalle.Text.Replace(" ", "").Length = 0 Then
                lbldatoserroneosOpcional.Text = "No ingreso el detalle del archivo"
                lblmensajeErrorOpcional = Nothing
                Exit Sub
            End If

            If (FileUpload1.HasFile) Then

                FileUpload1.SaveAs(savePath)

                UploadStatusLabel.Text = "Su archivo se subió correctamente"
                DisplayFileContents(FileUpload1.PostedFile)

                Image1.ImageUrl = "~/website/archivos/" + FileUpload1.FileName
            Else
                UploadStatusLabel.Text = Nothing
                LengthLabel.Text = Nothing
                Image1.ImageUrl = savePath
            End If

            Call verregunidad()
            txtDetalle.Text = Nothing
            UpdateResVF.Update()
            UpdateIngPreg.Update()
            lbldatoserroneosOpcional.Text = Nothing

            Call EnlazarDatos()
            UpdatePanel6.Update()
        Catch ex As Exception
            lblmensajeErrorOpcional.Text = ex.ToString
        End Try
    End Sub
    Sub verregunidad()


        Dim sel As String
        Dim ds As New DataSet
        Dim i, m, tr As Integer

        Dim savePaths, PathImagen As String
        Try

            savePaths = FileUpload1.PostedFile.FileName
            If savePaths.Length > 2 Then
                savePaths = "~/WebSite/archivos/" & FileUpload1.PostedFile.FileName
                savePaths = savePaths.Trim.Replace(" ", "")
            Else
                savePaths = ""
            End If


            If savePaths = "" Then
                PathImagen = "sinarchivo.jpg"
            Else
                PathImagen = "download.gif"
            End If
            m = cbomes.Text
            tr = cboTrim.Text

            sel = "INSERT INTO REG_MENU_C_FORO " & _
                          "(Trimestre,Mes,cod_materia,Detalle_Cuest_Foro,Link_Cuest_Foro,Path_Imagen,cod_anio_basica) " & _
                          "VALUES " & _
                          "(@Trimestre, @Mes, @cod_materia,@Detalle_Cuest_Foro, @Link_Cuest_Foro,@Path_Imagen,@cod_anio_basica) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("Trimestre", CType(tr, Integer))
            cmd.Parameters.AddWithValue("Mes", CType(m, Integer))
            cmd.Parameters.AddWithValue("cod_materia", CType(lblcodmateria.Text, String))
            cmd.Parameters.AddWithValue("Detalle_Cuest_Foro", CType(txtDetalle.Text, String))
            cmd.Parameters.AddWithValue("Link_Cuest_Foro", CType(savePaths, String))
            cmd.Parameters.AddWithValue("Path_Imagen", CType(PathImagen, String))
            cmd.Parameters.AddWithValue("cod_anio_basica", CType(Me.lblCodanioBasica.Text, Integer))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()



        Catch ex As Exception
            lblmensajeErrorOpcional.Text = ex.ToString
        End Try

    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        EnlazarDatos()

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim ord As Integer

        If Not (fila Is Nothing) Then
            SqlDataSource1.ConnectionString = ConnectionString
            SqlDataSource1.DeleteCommand = "DELETE FROM REG_MENU_C_FORO WHERE cod_materia='" & Me.lblcodmateria.Text & "' and Mes=@Mes and Trimestre=@Trimestre "
            SqlDataSource1.DeleteParameters.Add(New Parameter("Mes", TypeCode.Decimal))
            SqlDataSource1.DeleteParameters.Add(New Parameter("Trimestre", TypeCode.Decimal))

            SqlDataSource1.DeleteParameters("Mes").DefaultValue = CType(fila.FindControl("lblOrden"), Label).Text
            SqlDataSource1.DeleteParameters("Trimestre").DefaultValue = CType(fila.FindControl("lblUnidad"), Label).Text
            lblinkar.Text = CType(fila.FindControl("lblLinkr"), Label).Text


            SqlDataSource1.Delete()
            EnlazarDatos()
            Call elimiararchivo()
        End If

    End Sub
    Sub elimiararchivo()
        Dim s As String
        'Dim path As String = "c:\webarchivos\txtarchivo.Text"
        Dim path As String = Server.MapPath("~/WebSite/archivos/")
        ' path = "~/archivos/" & FileUpload1.PostedFile.FileName
        s = lblinkar.Text.Replace("~", "")
        path = "C:\WebSite\" & s
        Try
            Dim sw As StreamWriter = File.CreateText(path)
            sw.Close()

            ' Ensure that the target does not exist.
            File.Delete(path)

        Catch ex As Exception
            lbldatoserroneosOpcional.Text = "ERROR: " & ex.Message
        End Try
    End Sub


    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        EnlazarDatos()
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim tr As Integer = cboTrim.Text

        If Not (fila Is Nothing) Then
            SqlDataSource1.ConnectionString = ConnectionString
            SqlDataSource1.UpdateCommand = "UPDATE REG_MENU_C_FORO SET Mes = @Mes, Detalle_Cuest_Foro = @Detalle_Cuest_Foro WHERE Trimestre = " & tr & " and cod_materia='" & Me.lblcodmateria.Text & "' and Orden=@Orden  "
            SqlDataSource1.UpdateParameters.Add(New Parameter("Detalle_Cuest_Foro", TypeCode.String))
            SqlDataSource1.UpdateParameters.Add(New Parameter("Mes", TypeCode.Decimal))

            SqlDataSource1.UpdateParameters("Mes").DefaultValue = CType(fila.FindControl("txtOrdenSave"), TextBox).Text
            SqlDataSource1.UpdateParameters("Detalle_Cuest_Foro").DefaultValue = CType(fila.FindControl("txtDetalleSave"), TextBox).Text

            SqlDataSource1.Update()
            GridView1.EditIndex = -1
            EnlazarDatos()
        End If

    End Sub
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i, tr As Integer
        Dim v As DataRow

        Try
            tr = cboTrim.Text
            sel = "SELECT * " & _
                    "FROM REG_MENU_C_FORO " & _
                    "WHERE cod_anio_basica=" & Me.lblCodanioBasica.Text & "  and cod_materia='" & lblcodmateria.Text & "' and Trimestre=" & tr & " " & _
                        "order by Mes "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "REG_MENU_C_FORO")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CboAnioBasica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboAnioBasica.SelectedIndexChanged
        Try
            Dim p As Integer = CboAnioBasica.SelectedIndex
            Dim coda As String = CboAnioBasica.Items(p - 1).Value

            Me.lblCodanioBasica.Text = coda
            Call cargarasignaturas()
            UpdatePanel5.Update()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CboPeriodoAcad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPeriodoAcad.SelectedIndexChanged
        Try

            Dim p As Integer = CboPeriodoAcad.SelectedIndex
            Dim codpacad As String = CboPeriodoAcad.Items(p - 1).Value

            lblpacad.Text = codpacad

            Call cargardocente()
            UpdatePanel5.Update()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cbodocente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbodocente.SelectedIndexChanged
        Try


            Dim p As Integer = cbodocente.SelectedIndex
            Dim codm As String = cbodocente.Items(p - 1).Value

            lblcod_usu.Text = codm
            Call cargarAnioBasica()
            UpdatePanel5.Update()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cbomes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbomes.SelectedIndexChanged

        Call EnlazarDatos()
        UpdatePanel6.Update()
    End Sub
End Class

