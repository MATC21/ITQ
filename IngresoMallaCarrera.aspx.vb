
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class IngresoMallaCarrera
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
            '   LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try

    End Sub

    Sub grabarasignatura()


        Dim sel As String
        Dim ds As New DataSet

        Try
            sel = "INSERT INTO MALLA_PENSUM " & _
                          "(Malla, Cod_Carrera) " & _
                          "VALUES " & _
                          "(@Malla, @Cod_Carrera) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("Malla", CType(txtAnio.Text, Integer))
            cmd.Parameters.AddWithValue("Cod_Carrera", CType(lblcodcarrera.Text, Integer))

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
                SqlDataSource1.DeleteCommand = "DELETE FROM MALLA_PENSUM WHERE Num=@Num "
                SqlDataSource1.DeleteParameters.Add(New Parameter("Num", TypeCode.Int64))

                SqlDataSource1.DeleteParameters("Num").DefaultValue = CType(fila.FindControl("lblCod_Materia"), Label).Text

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


    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer

        Try

            sel = "SELECT * " & _
                    "FROM MALLA_PENSUM where Cod_Carrera=" & lblcodcarrera.Text & " " & _
                    "order by Malla "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "MALLA_PENSUM")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Call grabarasignatura()
            txtAnio.Text = Nothing

            UpdateIngPreg.Update()
            lbldatoserroneosOpcional.Text = Nothing

            Call EnlazarDatos()
            UpdatePanel6.Update()
        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.ToString
        End Try
    End Sub

    Protected Sub CboCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCarrera.SelectedIndexChanged
        Try


            Dim p As Integer = CboCarrera.SelectedIndex
            Dim codca As String = CboCarrera.Items(p - 1).Value

            lblcodcarrera.Text = codca
            Call EnlazarDatos()
            UpdatePanel6.Update()


        Catch ex As Exception

        End Try
    End Sub
End Class

