
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class ModificaFechaCuest
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
                Call periodo()


            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub


    Sub periodo()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Detalle_Periodo,cod_periodo " & _
                     "FROM PERIODO "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PERIODO")
            CboPeriodo.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboPeriodo.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboPeriodo.Items.Add("- Seleccione un periodo -")
                        CboPeriodo.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboPeriodo.Items.Add(v(0))
                        CboPeriodo.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If

            cntDB.Close()
        Catch ex As Exception
            'LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub
    


    Protected Sub CboAsignatura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboPeriodo.SelectedIndexChanged
        Try


            Dim p As Integer = CboPeriodo.SelectedIndex
            Dim codm As String = CboPeriodo.Items(p - 1).Value
            lblCodPeriodo.Text = codm
            Call EnlazarDatos()
            lblerrorGrid.Text = Nothing
            UpdatePanel5.Update()

        Catch ex As Exception

        End Try

    End Sub



    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        EnlazarDatos()

    End Sub


    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        EnlazarDatos()
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim fila As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim fi, ff As Date
        Dim codm As Integer
        Dim sel As String
        Try

        
        If Not (fila Is Nothing) Then
                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.UpdateCommand = "UPDATE REG_MENU_C_FORO SET fecha_inicio=@fecha_inicio, fecha_final = @fecha_final WHERE cod_materia=@cod_materia and cod_periodo=" & lblCodPeriodo.Text & "  "
                SqlDataSource1.UpdateParameters.Add(New Parameter("fecha_inicio", TypeCode.DateTime))
                SqlDataSource1.UpdateParameters.Add(New Parameter("fecha_final", TypeCode.DateTime))
                SqlDataSource1.UpdateParameters.Add(New Parameter("cod_materia", TypeCode.Int64))


                SqlDataSource1.UpdateParameters("cod_materia").DefaultValue = CType(fila.FindControl("lblcod_materia"), Label).Text
                SqlDataSource1.UpdateParameters("fecha_final").DefaultValue = CType(fila.FindControl("txtffinalSave"), TextBox).Text
                SqlDataSource1.UpdateParameters("fecha_inicio").DefaultValue = CType(fila.FindControl("txtInicioSave"), TextBox).Text

                '    codm = CType(fila.FindControl("lblcod_materia"), Label).Text
                '    ff = CType(fila.FindControl("txtffinalSave"), TextBox).Text
                '    fi = CType(fila.FindControl("txtInicioSave"), TextBox).Text

                '    '    sel = "UPDATE REG_MENU_C_FORO " &
                '    '"SET fecha_inicio=fecha_inicio, fecha_final = @fecha_final where  cod_materia=" & codm & " and cod_periodo=" & lblCodPeriodo.Text & " "
                '    '    Dim cmd As New SqlCommand(sel, cntDB)
                '    '    cmd.Parameters.AddWithValue("@fecha_inicio", CType(fi, Date))
                '    '    cmd.Parameters.AddWithValue("@fecha_final", CType(ff, Date))
                '    fi = Date.Now

                '    sel = "UPDATE REG_MENU_C_FORO " &
                '"SET fecha_inicio=@fecha_inicio where  cod_materia=" & codm & " and cod_periodo=" & lblCodPeriodo.Text & " "
                '    Dim cmd As New SqlCommand(sel, cntDB)
                '    cmd.Parameters.AddWithValue("@fecha_inicio", CType(fi, Date))


                '    cntDB.Open()
                '    Dim t As Integer = CInt(cmd.ExecuteScalar())
                '    cntDB.Close()

                SqlDataSource1.Update()
                GridView1.EditIndex = -1
            EnlazarDatos()
        End If
        Catch ex As Exception
            lblerrorGrid.Text = ex.Message
        End Try
    End Sub
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer

        Try

            sel = "SELECT PENSUM.Nomb_Materia, REG_MENU_C_FORO.Cod_Unidad, REG_MENU_C_FORO.Detalle_Cuest_Foro, REG_MENU_C_FORO.fecha_inicio, " & _
                "REG_MENU_C_FORO.fecha_final, REG_MENU_C_FORO.cod_materia " & _
                "FROM            REG_MENU_C_FORO INNER JOIN  PENSUM ON REG_MENU_C_FORO.cod_materia = PENSUM.codigo_materia where  cod_periodo=" & lblCodPeriodo.Text & "  "
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

End Class

