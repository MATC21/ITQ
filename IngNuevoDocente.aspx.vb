
Imports System.Data
Imports System.Data.SqlClient

Partial Class IngNuevoDocente
    Inherits System.Web.UI.Page
    Dim cod As String
    Dim tipo_us As Integer
    Private datos As DataSet
    Private datosInf As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then

                'cod = Session("user").ToString()
                lblcod_us.Text = ""
            End If
        Catch ex As Exception
            Response.Redirect("DEFAULTs.aspx")
        End Try


    End Sub
  
    Sub buscacodigo()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Try

            sel = "SELECT codigo_doc from DATOSDOCENTE WHERE cedula_doc='" & txtcedula.Text.TrimEnd & "'  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "DATOS_ESTUD")
            i = datosInf.Tables(0).Rows.Count
            lblcod_Doc.Text = datosInf.Tables(0).Rows(0).Item(0).ToString()

        Catch ex As Exception
            ' lblcod_estud.Text = 1
        End Try

    End Sub


    Protected Sub cdmverasignatura0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmNuevoEstud.Click
        Dim sel, nomb As String
        Dim c As Integer

        Try
            Call buscacodigo()
            If txtcedula.Text = Nothing Then
                txtcedula.Text = lblmensajeCed.Text
                UpdateNuevoEst.Update()
            End If
            If txtfechaNac.Text.Length = 0 Then
                txtfechaNac.Text = "01/01/1900"
            End If
            txtpas.Text = Me.txtcedula.Text.Substring(6, 4)
            If txtpas.Text = "" Then
                LBLmensajeestud.Text = "ERROR: ingrese los 4 últimos dígitos de la cédula"
                Exit Sub
            End If

            sel = "INSERT INTO DATOSDOCENTE " &
                          "(cedula_doc, apellidos_nombre,  correo, telefono, movil,  sexo, nacionalidad, fecha_nac, tipo_discapa, carnet_conadis, num_carnet_cona, porcen_discapa,estado_civil,evaluador,tercernivel,cuartonivel  ) " &
                          "VALUES " &
                          "(@cedula_doc, @apellidos_nombre,  @correo, @telefono, @movil,  @sexo, @nacionalidad, @fecha_nac, @tipo_discapa, @carnet_conadis, @num_carnet_cona, @porcen_discapa,@estado_civil,@evaluador,@tercernivel,@cuartonivel) "
            Dim cmd As New SqlCommand(sel, cntDB)

            cmd.Parameters.AddWithValue("cedula_doc", CType(txtcedula.Text, String))
            nomb = txtnombres.Text
            cmd.Parameters.AddWithValue("apellidos_nombre", CType(nomb, String))
            cmd.Parameters.AddWithValue("correo", CType(txtemail.Text, String))
            cmd.Parameters.AddWithValue("telefono", CType(txttelef.Text, String))
            cmd.Parameters.AddWithValue("movil", CType(TxtCelular.Text, String))
            cmd.Parameters.AddWithValue("SEXO", CType(CboSexo.Text, String))
            cmd.Parameters.AddWithValue("nacionalidad", CType(txtNacionalidad.Text, String))
            cmd.Parameters.AddWithValue("fecha_nac", CType(txtfechaNac.Text, Date))
            cmd.Parameters.AddWithValue("tipo_discapa", CType(txtTipoCapacEspec.Text, String))
            cmd.Parameters.AddWithValue("carnet_conadis", CType(CboCarnetConadis.Text, String))
            cmd.Parameters.AddWithValue("num_carnet_cona", CType(txtNoCarnet.Text, String))
            cmd.Parameters.AddWithValue("evaluador", CType(CboDocEvaluador.Text, String))
            If txtPorcenCapaci.Text.Length > 0 Then
                Try
                    c = txtPorcenCapaci.Text

                Catch ex As Exception
                    LBLmensajeestud.Text = "**  Revise el dato de % de Capacidad   ** "
                    Exit Sub
                End Try
            Else
                c = 0
            End If

            cmd.Parameters.AddWithValue("porcen_discapa", CType(c, Integer))
            cmd.Parameters.AddWithValue("estado_civil", CType(cboestadocivilestd.Text, String))
            cmd.Parameters.AddWithValue("tercernivel", CType(txttittercer.Text, String))
            cmd.Parameters.AddWithValue("cuartonivel", CType(TxtTitCuarto.Text, String))
            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()
            Call buscacodigo()
            Call usuarios()

            LBLmensajeestud.Text = "**  Se envió los datos ingresados  ** "
            '  cdmNuevoEstud.Enabled = False

            UpdateNuevoEst.Update()
        Catch ex As Exception
            Dim er As String = ex.Message
            LBLmensajeestud.Text = "ERROR: Datos incorrectos o existe la cédula registrada"

        End Try
    End Sub
    Sub usuarios()
        Dim sel, str As String
        Dim MiDataset As New DataSet
        Dim i As Integer
        sel = "INSERT INTO USUARIOS " & _
               "(Codigo_Usuario,cedula,login,password,tipo_usuario) " & _
               "VALUES " & _
               "(@Codigo_Usuario,@cedula,@login,@password,@tipo_usuario) "
        Dim cmdu As New SqlCommand(sel, cntDB)

        cmdu.Parameters.AddWithValue("Codigo_Usuario", CType(lblcod_Doc.Text, Integer))
        cmdu.Parameters.AddWithValue("cedula", CType(txtcedula.Text.TrimEnd, String))
        cmdu.Parameters.AddWithValue("login", CType(txtcedula.Text.TrimEnd, String))
        cmdu.Parameters.AddWithValue("password", CType(txtpas.Text.TrimEnd, String))
        '1 estudinates  2 docentes
        cmdu.Parameters.AddWithValue("tipo_usuario", CType(2, Integer))

        cntDB.Open()
        Dim tu As Integer = CInt(cmdu.ExecuteScalar())
        cntDB.Close()
    End Sub

    Sub encerar()
        Try
            txtcedula.Text = Nothing
            txtpas.Text = Nothing
            txtnombres.Text = Nothing
            txtfechaNac.Text = Nothing
            txtemail.Text = Nothing
            txttelef.Text = Nothing
            LBLmensajeestud.Text = Nothing

            UpdateNuevoEst.Update()
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub CmdNuevoEstud_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdNuevoEstud.Click
        Try
            Call encerar()
            Call buscacodigo()
            cdmNuevoEstud.Enabled = True
            UpdateNuevoEst.Update()

        Catch ex As Exception

        End Try

    End Sub


End Class


