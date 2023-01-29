
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class IngresoHorasMatricula
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
                Call cargarModalidad()

            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
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
                    "FROM ModalidadMatricula WHERE TipoMatricula='I' " &
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

    Sub cargarModalidadDias()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Detalledias,numd " &
                    "FROM DiasMatricula WHERE Cod_modalidad=" & lblcodmodalidad.Text & " " &
                    "order by Detalledias "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DiasMatricula")
            i = datos.Tables(0).Rows.Count
            Cbodias.Items.Clear()
            If i > 0 Then
                Cbodias.DataSource = datos
                Cbodias.DataTextField = "Detalledias"
                Cbodias.DataValueField = "numd"
                Cbodias.DataBind()

                'Add Default Item in the DropDownList
                Cbodias.Items.Insert(0, New ListItem("Seleccione"))

                '    Cbomodalidad.Items.FindByValue(lblcodmodalidad.Text).Selected = True
            End If

            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub
    Sub grabarParalelo()


        Dim sel As String
        Dim ds As New DataSet

        Try
            sel = "INSERT HorarioMatricula " &
                          "(DetalleH,Cod_modalidad, Cod_dia) " &
                          "VALUES " &
                          "(@DetalleH,@Cod_modalidad, @Cod_dia) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("DetalleH", CType(TxtDetalle.Text, String))
            cmd.Parameters.AddWithValue("Cod_modalidad", CType(lblcodmodalidad.Text, Integer))
            cmd.Parameters.AddWithValue("Cod_dia", CType(lblcoddia.Text, Integer))

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
                SqlDataSource1.DeleteCommand = "DELETE FROM HorarioMatricula WHERE Numh=@Numh "
                SqlDataSource1.DeleteParameters.Add(New Parameter("Numh", TypeCode.Decimal))

                SqlDataSource1.DeleteParameters("Numh").DefaultValue = CType(fila.FindControl("lblNum"), Label).Text

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
                SqlDataSource1.UpdateCommand = "UPDATE HorarioMatricula SET Cod_dia=@Cod_dia,Cod_modalidad=@Cod_modalidad, DetalleH=@DetalleH,Estado=@Estado,TipoMatricula=@TipoMatricula WHERE Numh = @Numh "
                SqlDataSource1.UpdateParameters.Add(New Parameter("Numh", TypeCode.Decimal))
                SqlDataSource1.UpdateParameters.Add(New Parameter("DetalleH", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("TipoMatricula", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Estado", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Cod_modalidad", TypeCode.Decimal))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Cod_dia", TypeCode.Decimal))

                SqlDataSource1.UpdateParameters("Numh").DefaultValue = CType(fila.FindControl("lblNum"), Label).Text
                SqlDataSource1.UpdateParameters("DetalleH").DefaultValue = CType(fila.FindControl("txtDetalleSave"), TextBox).Text
                SqlDataSource1.UpdateParameters("TipoMatricula").DefaultValue = CType(fila.FindControl("txtcontrol"), TextBox).Text
                SqlDataSource1.UpdateParameters("Estado").DefaultValue = CType(fila.FindControl("txtestado"), TextBox).Text
                SqlDataSource1.UpdateParameters("Cod_modalidad").DefaultValue = CType(fila.FindControl("txtcodmoda"), TextBox).Text
                SqlDataSource1.UpdateParameters("Cod_dia").DefaultValue = CType(fila.FindControl("txtcoddia"), TextBox).Text



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
                    "FROM HorarioMatricula " &
                    " order by DetalleH "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "HorarioMatricula")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

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
            Call cargarModalidadDias()
            Call EnlazarDatos()
            UpdateIngPreg.Update()
        Catch ex As Exception
            ' lblcodmodalidad.Text = 1
        End Try
    End Sub
    Protected Sub Cbomodalidad0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbodias.SelectedIndexChanged
        Try
            Dim p As Integer = Cbodias.SelectedIndex
            Dim pa As String = Cbodias.Items(p).Value
            lblcoddia.Text = pa
            Call EnlazarDatos()
            UpdateIngPreg.Update()
        Catch ex As Exception
            ' lblcodmodalidad.Text = 1
        End Try
    End Sub
End Class

