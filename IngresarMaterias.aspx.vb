
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class IngresarMaterias
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
                Call carrera()
            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub
    Sub carrera()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Nombre_Basica,Cod_AnioBasica " & _
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
    Sub cargarMalla()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Malla,NUM " & _
                    "FROM MALLA_PENSUM  " & _
                    "WHERE Cod_CARRERA=" & lblcodcarrera.Text & "  " & _
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
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub

    Sub grabarasignatura()


        Dim sel, s As String
        Dim ds As New DataSet

        Try
            sel = "INSERT INTO PENSUM " &
                          "(Cod_AnioBasica,Nomb_Materia,Semestre,Creditos,NumMalla,cod_materia,Horas, ValorHora,verreporte,valor1credito) " &
                          "VALUES " &
                          "(@Cod_AnioBasica,@Nomb_Materia,@Semestre,@Creditos,@NumMalla,@cod_materia,@Horas, @ValorHora,@verreporte,@valor1credito) "
            Dim cmd As New SqlCommand(sel, cntDB)

            cmd.Parameters.AddWithValue("Cod_AnioBasica", CType(lblcodcarrera.Text, Integer))
            cmd.Parameters.AddWithValue("Nomb_Materia", CType(txtDetalle.Text, String))
            cmd.Parameters.AddWithValue("Semestre", CType(txtsemestre.Text, Integer))
            cmd.Parameters.AddWithValue("Creditos", CType(txtCreditos.Text, Integer))
            cmd.Parameters.AddWithValue("NumMalla", CType(lblmalla.Text, Integer))
            cmd.Parameters.AddWithValue("cod_materia", CType(txtCodigoTexto.Text, String))
            cmd.Parameters.AddWithValue("Horas", CType(txtCreditos.Text * 11, Integer))
            txtValorHora.Text = txtValorHora.Text.Replace(".", ",").Trim
            cmd.Parameters.AddWithValue("ValorHora", CType(txtValorHora.Text, Double))
            If chkVerReporte.Checked = True Then
                s = 1
            Else
                s = 0
            End If
            cmd.Parameters.AddWithValue("verreporte", CType(s, Integer))
            txtValorCreditos.Text = txtValorCreditos.Text.Replace(".", ",").Trim
            cmd.Parameters.AddWithValue("valor1credito", CType(txtValorCreditos.Text, Double))
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
                SqlDataSource1.DeleteCommand = "DELETE FROM PENSUM WHERE codigo_materia=@codigo_materia  "
                SqlDataSource1.DeleteParameters.Add(New Parameter("codigo_materia", TypeCode.Int64))

                SqlDataSource1.DeleteParameters("codigo_materia").DefaultValue = CType(fila.FindControl("lblCod_Materia"), Label).Text
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
        Dim s As String
        Try


            If Not (fila Is Nothing) Then
                SqlDataSource1.ConnectionString = ConnectionString
                SqlDataSource1.UpdateCommand = "UPDATE PENSUM SET ValorHora=@ValorHora,Prerequisito=@Prerequisito, Horas=@Horas, CombinarMateria=@CombinarMateria,CombinaIngles=@CombinaIngles, Nomb_Materia=@Nomb_Materia, cod_materia=@cod_materia,  Semestre=@semestre, Creditos=@creditos, verreporte=@verreporte,valor1credito=@valor1credito WHERE codigo_materia = @codigo_materia  "
                SqlDataSource1.UpdateParameters.Add(New Parameter("Nomb_Materia", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("codigo_materia", TypeCode.Int64))

                SqlDataSource1.UpdateParameters.Add(New Parameter("verreporte", TypeCode.Int64))

                SqlDataSource1.UpdateParameters.Add(New Parameter("Semestre", TypeCode.Int32))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Creditos", TypeCode.Int32))
                SqlDataSource1.UpdateParameters.Add(New Parameter("cod_materia", TypeCode.String))

                SqlDataSource1.UpdateParameters.Add(New Parameter("Horas", TypeCode.Int32))
                SqlDataSource1.UpdateParameters.Add(New Parameter("ValorHora", TypeCode.Double))

                SqlDataSource1.UpdateParameters.Add(New Parameter("CombinarMateria", TypeCode.Int64))
                SqlDataSource1.UpdateParameters.Add(New Parameter("CombinaIngles", TypeCode.Int64))
                SqlDataSource1.UpdateParameters.Add(New Parameter("valor1credito", TypeCode.Double))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Prerequisito", TypeCode.String))

                SqlDataSource1.UpdateParameters("codigo_materia").DefaultValue = CType(fila.FindControl("lblCod_Materia"), Label).Text
                SqlDataSource1.UpdateParameters("Nomb_Materia").DefaultValue = CType(fila.FindControl("txtAsignaturaSave"), TextBox).Text

                SqlDataSource1.UpdateParameters("Semestre").DefaultValue = CType(fila.FindControl("txtsemesave"), TextBox).Text
                SqlDataSource1.UpdateParameters("Creditos").DefaultValue = CType(fila.FindControl("txtcreditossave"), TextBox).Text
                SqlDataSource1.UpdateParameters("cod_materia").DefaultValue = CType(fila.FindControl("Txtcodmateriatextosave"), TextBox).Text

                SqlDataSource1.UpdateParameters("Horas").DefaultValue = CType(fila.FindControl("txthorassave"), TextBox).Text
                SqlDataSource1.UpdateParameters("ValorHora").DefaultValue = CType(fila.FindControl("txtvalorhorasave"), TextBox).Text

                SqlDataSource1.UpdateParameters("CombinarMateria").DefaultValue = CType(fila.FindControl("txtconbsave"), TextBox).Text
                SqlDataSource1.UpdateParameters("CombinaIngles").DefaultValue = CType(fila.FindControl("txtconbsaveingles"), TextBox).Text
                SqlDataSource1.UpdateParameters("valor1credito").DefaultValue = CType(fila.FindControl("txtvalorcred"), TextBox).Text
                SqlDataSource1.UpdateParameters("Prerequisito").DefaultValue = CType(fila.FindControl("txtprerequisito"), TextBox).Text

                s = CType(fila.FindControl("Chkvereportesave"), CheckBox).Checked
                If s = "False" Then
                    s = 0
                Else
                    s = 1
                End If


                SqlDataSource1.UpdateParameters("verreporte").DefaultValue = s

                SqlDataSource1.Update()
                GridView1.EditIndex = -1
                EnlazarDatos()
            End If
        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.Message
        End Try
    End Sub
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer

        Try

            sel = "SELECT * " &
                    "FROM PENSUM " &
                    "WHERE  Cod_AnioBasica='" & lblcodcarrera.Text & "' and NumMalla=" & lblmalla.Text & " order by NumMalla, Semestre,Nomb_Materia "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PENSUM")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.Message
        End Try
    End Sub

    Protected Sub CboCarrera_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCarrera.SelectedIndexChanged

        Try


            Dim p As Integer = CboCarrera.SelectedIndex
            Dim codca As String = CboCarrera.Items(p - 1).Value

            lblcodcarrera.Text = codca
            Call cargarMalla()

            UpdatePanel5.Update()


        Catch ex As Exception

        End Try
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If txtDetalle.Text = Nothing Then
                lbldatoserroneosOpcional.Text = "Ingrese el detalle de la materia"
                Exit Sub
            Else
                lbldatoserroneosOpcional.Text = Nothing
            End If

            UpdateIngPreg.Update()
            lbldatoserroneosOpcional.Text = Nothing
            Call grabarasignatura()
            Call EnlazarDatos()
            txtDetalle.Text = Nothing
            txtCreditos.Text = Nothing
            txtsemestre.Text = Nothing
            txtCodigoTexto.Text = Nothing
            UpdatePanel6.Update()

        Catch ex As Exception
            'lbldatoserroneosOpcional.Text = ex.ToString
        End Try
    End Sub



    Protected Sub CboMalla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMalla.SelectedIndexChanged
        Try

            Dim p As Integer = CboMalla.SelectedIndex
            Dim codca As String = CboMalla.Items(p).Text
            lblmalla.Text = codca
            Call EnlazarDatos()
            UpdateIngPreg.Update()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try

    End Sub

End Class

