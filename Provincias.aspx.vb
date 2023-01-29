
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Provincias
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
                Call EnlazarDatos()
            End If
        Catch ex As Exception
            Response.Redirect("MensajeError.aspx")
        End Try
    End Sub


    Sub grabarasignatura()


        Dim sel As String
        Dim ds As New DataSet

        Try
            sel = "INSERT INTO Provincias " & _
                          "(Descripcion_Prov) " & _
                          "VALUES " & _
                          "(@Descripcion_Prov) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("Descripcion_Prov", CType(txtDetalle.Text, String))

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
                SqlDataSource1.DeleteCommand = "DELETE FROM Provincias WHERE Cod_Provincia=@Cod_Provincia "
                SqlDataSource1.DeleteParameters.Add(New Parameter("Cod_Provincia", TypeCode.Decimal))

                SqlDataSource1.DeleteParameters("Cod_Provincia").DefaultValue = CType(fila.FindControl("lblCod_Periodo"), Label).Text

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
                SqlDataSource1.UpdateCommand = "UPDATE PERIODO SET Detalle_Periodo = @Detalle_Periodo,Estado=@Estado WHERE cod_periodo = @cod_periodo "
                SqlDataSource1.UpdateParameters.Add(New Parameter("cod_periodo", TypeCode.Decimal))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Detalle_Periodo", TypeCode.String))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Estado", TypeCode.String))

                SqlDataSource1.UpdateParameters("cod_periodo").DefaultValue = CType(fila.FindControl("lblCod_Periodo"), Label).Text
                SqlDataSource1.UpdateParameters("Detalle_Periodo").DefaultValue = CType(fila.FindControl("txtDetalleSave"), TextBox).Text
                SqlDataSource1.UpdateParameters("Estado").DefaultValue = CType(fila.FindControl("txtEstadoSave"), TextBox).Text

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

            sel = "SELECT * " & _
                    "FROM Provincias " & _
                    " order by Descripcion_Prov "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "Provincias")
            i = datos.Tables(0).Rows.Count
            GridView1.DataSource = datos
            GridView1.DataBind()
            UpdatePanel6.Update()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If txtDetalle.Text = Nothing Then
                Exit Sub
            End If
            Call grabarasignatura()
            txtDetalle.Text = Nothing

            UpdateIngPreg.Update()
            lbldatoserroneosOpcional.Text = Nothing

            Call EnlazarDatos()
            UpdatePanel6.Update()
        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.ToString
        End Try
    End Sub


End Class

