
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class IngresoDiasMatricula
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
                Call Periodo_Academico()


            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub

    Sub cargarAnioBasica()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow



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
            CboAnioBasica.Items.Clear()
            For c = 0 To i
                If c = 0 Then
                    CboAnioBasica.Items.Add("- Seleccione una carrera -")
                    CboAnioBasica.Items.Item(0).Value = "-1"

                Else
                    v = datos.Tables(0).Rows(c - 1)
                    CboAnioBasica.Items.Add(v(0))
                    CboAnioBasica.Items.Item(c - 1).Value = v(1)
                End If
            Next c
        End If

    End Sub
    Sub Periodo_Academico()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Detalle_Periodo,cod_periodo " &
                    "FROM PERIODO  " &
                    "order by cod_periodo Asc "
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
    Sub cargarModalidad()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT DetalleM,Numm " &
                    "FROM ModalidadMatricula WHERE estado='A' " &
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

                '    Cbomodalidad.Items.FindByValue(lblcodmodalidad.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub
    Sub grabarParalelo()


        Dim sel, tc As String
        Dim ds As New DataSet

        Try
            sel = "INSERT DiasMatricula " &
                          "(Detalledias,Cod_modalidad,nivel,cod_periodo, Num,cod_carrera,modalidad,TipoMatricula) " &
                          "VALUES " &
                          "(@Detalledias,@Cod_modalidad,@nivel,@cod_periodo, @Num,@cod_carrera,@modalidad,@TipoMatricula) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("Detalledias", CType(TxtDetalle.Text, String))
            cmd.Parameters.AddWithValue("Cod_modalidad", CType(lblcodmodalidad.Text, String))
            cmd.Parameters.AddWithValue("nivel", CType(cbonivel.Text, Integer))

            cmd.Parameters.AddWithValue("cod_periodo", CType(lblCodperiodoacad.Text, Integer))

            cmd.Parameters.AddWithValue("Num", CType(Cbonum.Text, Integer))
            cmd.Parameters.AddWithValue("cod_carrera", CType(lblCarrera.Text, Integer))
            cmd.Parameters.AddWithValue("modalidad", CType(lblmoda.Text, String))
            If lblCarrera.Text = 3 Then
                tc = "I"
            Else
                tc = "N"
            End If
            cmd.Parameters.AddWithValue("TipoMatricula", CType(tc, String))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()




        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.ToString
        End Try

    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        EnlazarDatos()

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Try


            If Not (fila Is Nothing) Then
                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.DeleteCommand = "DELETE FROM DiasMatricula WHERE numd=@numd "
                SqlDataSource1.DeleteParameters.Add(New Parameter("numd", TypeCode.Decimal))

                SqlDataSource1.DeleteParameters("numd").DefaultValue = CType(fila.FindControl("lblNum"), Label).Text

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

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Try


            If Not (fila Is Nothing) Then
                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.UpdateCommand = "UPDATE DiasMatricula SET nivel=@nivel, Cod_modalidad=@Cod_modalidad, Detalledias=@Detalledias,TipoMatricula=@TipoMatricula,estado=@estado WHERE numd = @numd "
                SqlDataSource1.UpdateParameters.Add(New Parameter("numd", TypeCode.Decimal))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Detalledias", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("TipoMatricula", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("estado", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Cod_modalidad", TypeCode.Decimal))
                SqlDataSource1.UpdateParameters.Add(New Parameter("nivel", TypeCode.Decimal))

                SqlDataSource1.UpdateParameters("numd").DefaultValue = CType(fila.FindControl("lblNum"), Label).Text
                SqlDataSource1.UpdateParameters("Detalledias").DefaultValue = CType(fila.FindControl("txtDetalleSave"), TextBox).Text
                SqlDataSource1.UpdateParameters("TipoMatricula").DefaultValue = CType(fila.FindControl("txttipomatricula"), TextBox).Text
                SqlDataSource1.UpdateParameters("estado").DefaultValue = CType(fila.FindControl("txtestado"), TextBox).Text
                SqlDataSource1.UpdateParameters("Cod_modalidad").DefaultValue = CType(fila.FindControl("txtmodalidad"), TextBox).Text
                SqlDataSource1.UpdateParameters("nivel").DefaultValue = CType(fila.FindControl("txtnivel"), TextBox).Text


                SqlDataSource1.Update()
                GridView1.EditIndex = -1
                EnlazarDatos()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer

        Try

            sel = "SELECT * " &
                    "FROM DiasMatricula where cod_periodo=" & lblCodperiodoacad.Text & " and Num=" & Cbonum.Text & " and cod_carrera=" & lblCarrera.Text & "  " &
                    " order by Detalledias "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DiasMatricula")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If lblCarrera.Text = Nothing Or lblCarrera.Text = Nothing Then

                Exit Sub
            End If

            Call grabarParalelo()


            UpdateIngPreg.Update()
            lbldatoserroneosOpcional.Text = Nothing

            Call EnlazarDatos()
            UpdatePanel6.Update()
        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.ToString
        End Try
    End Sub


    Protected Sub Cbomodalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbomodalidad.SelectedIndexChanged
        Try
            Dim p As Integer = Cbomodalidad.SelectedIndex
            Dim pa As String = Cbomodalidad.Items(p).Value
            lblcodmodalidad.Text = pa
            lblmoda.Text = Cbomodalidad.Items(p).Text
            Call EnlazarDatos()
            UpdateIngPreg.Update()
        Catch ex As Exception
            lblcodmodalidad.Text = 1
        End Try
    End Sub
    Protected Sub CboPeriodoAcad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPeriodoAcad.SelectedIndexChanged
        Try

            Dim p As Integer = CboPeriodoAcad.SelectedIndex
            Dim codpacad As String = CboPeriodoAcad.Items(p - 1).Value

            lblCodperiodoacad.Text = codpacad
            Call cargarModalidad()
            Call cargarAnioBasica()

            UpdateIngPreg.Update()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Cbonum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbonum.SelectedIndexChanged
        Call cargarModalidad()
        UpdateIngPreg.Update()
    End Sub
    Protected Sub CboAnioBasica_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAnioBasica.SelectedIndexChanged
        Try
            Dim p As Integer = CboAnioBasica.SelectedIndex
            Dim coda As String = CboAnioBasica.Items(p - 1).Value

            Me.lblCarrera.Text = coda


        Catch ex As Exception

        End Try
    End Sub
End Class

