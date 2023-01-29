
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Carreras
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
            sel = "INSERT INTO CARRERAS " & _
                          "(Nombre_Basica,Abrevia,Cod_AnioBasica) " & _
                          "VALUES " & _
                          "(@Nombre_Basica,@Abrevia,@Cod_AnioBasica) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("Nombre_Basica", CType(txtDetalle.Text, String))
            cmd.Parameters.AddWithValue("Abrevia", CType("", String))
            cmd.Parameters.AddWithValue("Cod_AnioBasica", CType(lblnummax.Text, Integer))

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
                SqlDataSource1.DeleteCommand = "DELETE FROM CARRERAS WHERE Cod_AnioBasica=@Cod_AnioBasica "
                SqlDataSource1.DeleteParameters.Add(New Parameter("Cod_AnioBasica", TypeCode.Decimal))

                SqlDataSource1.DeleteParameters("Cod_AnioBasica").DefaultValue = CType(fila.FindControl("lblCod"), Label).Text

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
                SqlDataSource1.UpdateCommand = "update CARRERAS sET  Nombre_Basica = @Nombre_Basica WHERE Cod_AnioBasica=@Cod_AnioBasica "
                SqlDataSource1.UpdateParameters.Add(New Parameter("Cod_AnioBasica", TypeCode.Decimal))
                SqlDataSource1.UpdateParameters.Add(New Parameter("Nombre_Basica", TypeCode.String))

                SqlDataSource1.UpdateParameters("Cod_AnioBasica").DefaultValue = CType(fila.FindControl("lblCod"), Label).Text
                SqlDataSource1.UpdateParameters("Nombre_Basica").DefaultValue = CType(fila.FindControl("txtDetalleSave"), TextBox).Text
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
                    "FROM CARRERAS order by Nombre_Basica  "

            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAS")
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
            Call nummax()
            Call grabarasignatura()
            UpdateIngPreg.Update()
            lbldatoserroneosOpcional.Text = Nothing
            txtDetalle.Text = Nothing

            Call EnlazarDatos()
            UpdatePanel6.Update()
        Catch ex As Exception
            lbldatoserroneosOpcional.Text = ex.ToString
        End Try
    End Sub


    Sub nummax()

        Dim str As String
        Dim i As Integer
        Dim Tabla As New DataTable
        Dim MiDataset As New DataSet

        str = "SELECT max(Cod_AnioBasica) as n " & _
                      "FROM  CARRERAS  "
        Dim Adaptadordoc As New SqlDataAdapter(Str, cntDB)
        MiDataset = New DataSet
        MiDataset.Clear()
        'enlazando al dataset con el adapter correspondiente.
        Adaptadordoc.Fill(MiDataset, "CARRERAS")

        i = MiDataset.Tables(0).Rows.Count
        If i > 0 Then
            lblnummax.Text = MiDataset.Tables(0).Rows(0).Item("n").ToString().Replace(" ", "") + 1

        End If

    End Sub
   
End Class

