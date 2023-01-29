Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class IngNuevoEstudianteWeb
    Inherits System.Web.UI.Page
    Dim cod As String
    Dim tipo_us As Integer
    Private datos As DataSet
    Private datosInf As DataSet
    Private datose As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then

                'cod = Session("user").ToString()
                lblcod_us.Text = ""
                Dim query As String = "select Cod_Provincia, Descripcion_Prov from Provincias"
                BindDropDownList(ddlProvincia, query, "Descripcion_Prov", "Cod_Provincia", "Seleccione")
                ddlCanton.Enabled = False
                ddlParroquia.Enabled = False
                ddlCanton.Items.Insert(0, New ListItem("Seleccione", "0"))
                ddlParroquia.Items.Insert(0, New ListItem("Seleccione", "0"))

                Dim queryAcad As String = "select Cod_Provincia, Descripcion_Prov from Provincias"
                BindDropDownList(ddlProvinciaAcad, queryAcad, "Descripcion_Prov", "Cod_Provincia", "Seleccione")
                ddlCantonAcad.Enabled = False
                ddlParroquiaAcad.Enabled = False
                ddlCantonAcad.Items.Insert(0, New ListItem("Seleccione", "0"))
                ddlParroquiaAcad.Items.Insert(0, New ListItem("Seleccione", "0"))

                Call periodo()
                Call Carrera()

            End If
        Catch ex As Exception
            Response.Redirect("DEFAULTs.aspx")
        End Try


    End Sub



    Sub VerDatos()
        Dim sel, f As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Try

            sel = "SELECT * from DATOS_ESTUD  where Cedula_Est='" & txtcedula.Text.TrimEnd & "'  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "DATOS_ESTUD")
            i = datosInf.Tables(0).Rows.Count
            If i > 0 Then

                txtnombres.Text = datosInf.Tables(0).Rows(0).Item("Apellidos_nombre").ToString().TrimEnd
                txtemail.Text = datosInf.Tables(0).Rows(0).Item("correo").ToString().TrimEnd
                cboestadocivilestd.SelectedValue = datosInf.Tables(0).Rows(0).Item("EstadoCivil").ToString().TrimEnd
                txtCallePrincipal.Text = datosInf.Tables(0).Rows(0).Item("calle_principal").ToString().TrimEnd
                txttelef.Text = datosInf.Tables(0).Rows(0).Item("telefono").ToString().TrimEnd
                TxtCelular.Text = datosInf.Tables(0).Rows(0).Item("movil").ToString().TrimEnd
                txtLugarTrabajo.Text = datosInf.Tables(0).Rows(0).Item("Lugar_Trabajo").ToString().TrimEnd
                txtDireccTrabajo.Text = datosInf.Tables(0).Rows(0).Item("DireccionTrabajo").ToString().TrimEnd
                txttelefTrabajo.Text = datosInf.Tables(0).Rows(0).Item("Telefono_Trabajo").ToString().TrimEnd
                lblcodprov.Text = datosInf.Tables(0).Rows(0).Item("Provincia").ToString().TrimEnd
                lblcodcanton.Text = datosInf.Tables(0).Rows(0).Item("Canton").ToString().TrimEnd
                lblcodparroquia.Text = datosInf.Tables(0).Rows(0).Item("Parroquia").ToString().TrimEnd
                txtfechaNac.Text = datosInf.Tables(0).Rows(0).Item("Fecha_Nac").ToString().TrimEnd
                CboAreaEstudio.SelectedValue = datosInf.Tables(0).Rows(0).Item("AreaEstudio").ToString().TrimEnd
                CboModalidadEstudio.SelectedValue = datosInf.Tables(0).Rows(0).Item("ModalidadEstudio").ToString().TrimEnd
                CboJornada.SelectedValue = datosInf.Tables(0).Rows(0).Item("Jornada").ToString().TrimEnd.TrimEnd
               
                CboTipoEtnia.SelectedValue = datosInf.Tables(0).Rows(0).Item("Etnia").ToString().TrimEnd
                txtEducPrimaria.Text = datosInf.Tables(0).Rows(0).Item("Primaria").ToString().TrimEnd
                txtEducSecundaria.Text = datosInf.Tables(0).Rows(0).Item("Secundaria").ToString().TrimEnd
                txtEducSuperior.Text = datosInf.Tables(0).Rows(0).Item("Superior").ToString().TrimEnd
                txtcolegiograduo.Text = datosInf.Tables(0).Rows(0).Item("Colegio").ToString().TrimEnd
                txtBachiller.Text = datosInf.Tables(0).Rows(0).Item("TituloBachiller").ToString().TrimEnd
                TxtFechaGrad.Text = datosInf.Tables(0).Rows(0).Item("Fecha_Graduacion").ToString().TrimEnd
                lblcodprovAcad.Text = datosInf.Tables(0).Rows(0).Item("prov_gradua").ToString().TrimEnd
                lblcodcantonAcad.Text = datosInf.Tables(0).Rows(0).Item("canton_gradua").ToString().TrimEnd
                lblcodparroquiaAcad.Text = datosInf.Tables(0).Rows(0).Item("parroq_gradua").ToString().TrimEnd

                TxtNombRef.Text = datosInf.Tables(0).Rows(0).Item("Nombres_Ref").ToString().TrimEnd
                txtOcupacionRef.Text = datosInf.Tables(0).Rows(0).Item("Ocupacion_Ref").ToString().TrimEnd
                TxtLugarTrabajoRef.Text = datosInf.Tables(0).Rows(0).Item("Lugar_Trab_Ref").ToString().TrimEnd
                TxtelefRef.Text = datosInf.Tables(0).Rows(0).Item("Telef_Traba_Ref").ToString().TrimEnd
                TxtTiempoConoce.Text = datosInf.Tables(0).Rows(0).Item("Tiempo_Conoce").ToString().TrimEnd
                TxtNombRef0.Text = datosInf.Tables(0).Rows(0).Item("Nombres_Ref1").ToString().TrimEnd
                txtOcupacionRef0.Text = datosInf.Tables(0).Rows(0).Item("Ocupacion_Ref1").ToString().TrimEnd
                TxtLugarTrabajoRef0.Text = datosInf.Tables(0).Rows(0).Item("Lugar_Trab_Ref1").ToString().TrimEnd
                TxtelefRef0.Text = datosInf.Tables(0).Rows(0).Item("Telef_Traba_Ref1").ToString().TrimEnd
                TxtTiempoConoce0.Text = datosInf.Tables(0).Rows(0).Item("Tiempo_Conoce1").ToString().TrimEnd
                TxtInfAdicional.Text = datosInf.Tables(0).Rows(0).Item("EscogioProfesion").ToString().TrimEnd
                TxtEstudiaCenestur.Text = datosInf.Tables(0).Rows(0).Item("EstudiarCenestur").ToString().TrimEnd

                lblcompecono.Text = datosInf.Tables(0).Rows(0).Item("Compromiso_econo").ToString().TrimEnd
                lblcodPeriodo.Text = datosInf.Tables(0).Rows(0).Item("Cod_Periodo").ToString()
                lblCarrera.Text = datosInf.Tables(0).Rows(0).Item("Cod_Carrera").ToString()
                lblcodPeriodo.Text = datosInf.Tables(0).Rows(0).Item("Cod_Periodo").ToString().TrimEnd
                lblcodestud.Text = datosInf.Tables(0).Rows(0).Item("codigo_estud").ToString().TrimEnd
                chkCedula.Checked = datosInf.Tables(0).Rows(0).Item("cedula").ToString()
                ChkFotos.Checked = datosInf.Tables(0).Rows(0).Item("fotos").ToString()

                lblcontrol.Text = 1
                RadioButtonList1.SelectedValue = datosInf.Tables(0).Rows(0).Item("Compromiso_econo").ToString().TrimEnd
                lblmensajeactualizar.Text = "Actualice sus Datos"
            Else
                lblmensajeactualizar.Text = Nothing
                lblcontrol.Text = 0
            End If
        Catch ex As Exception
            '   LBLmensajeestud.Text = ex.Message
        End Try
        UpdateNuevoEst.Update()
    End Sub
    Sub periodo()
        Dim daUs As SqlDataAdapter
        Dim sel, nomb As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT distinct  Detalle_Periodo,cod_periodo " & _
                    "FROM PERIODO order by Detalle_Periodo desc "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PERIODO")
            CboPeriodo.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboPeriodo.Items.Clear()
                For c = 0 To i
                    If c = 0 Then
                        CboPeriodo.Items.Add("- Seleccione -")
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
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try
    End Sub
    Sub Carrera()
        Dim daUs As SqlDataAdapter
        Dim sel, nomb As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT distinct   Nombre_Basica,Cod_AnioBasica " & _
                    "FROM CARRERAS order by  Nombre_Basica  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAS")
            CboCarrera.DataSource = datos

            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboCarrera.Items.Clear()
                For c = 0 To i
                    If c = 0 Then
                        CboCarrera.Items.Add("- Seleccione -")
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
    Sub buscacodigo()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Try

            sel = "SELECT codigo_estud from DATOS_ESTUD where Cedula_Est='" & txtcedula.Text.TrimEnd & "'  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "DATOS_ESTUD")
            i = datosInf.Tables(0).Rows.Count
            lblcodestud.Text = datosInf.Tables(0).Rows(0).Item(0).ToString()

        Catch ex As Exception
            ' lblcod_estud.Text = 1
        End Try

    End Sub


    Protected Sub cdmverasignatura0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdmNuevoEstud.Click
        Dim sel, nomb As String
        Dim daUs As SqlDataAdapter
        Try
            If lblcontrol.Text = 1 Then
                Call actualizadatos()
                Exit Sub
            End If

            If txtcedula.Text = Nothing Or (txtcedula.Text.Length < 10 Or txtcedula.Text.Length > 10) And CboTipoDoc.SelectedValue = 1 Then
                txtcedula.Text = lblmensajeCed.Text
                LBLmensajeestud.Text = "Ingrese los 10 dígitos de la cédula sin el - "
                UpdateNuevoEst.Update()
                Exit Sub
            End If


            If TxtFechaGrad.Text = Nothing Or txtfechaNac.Text = Nothing Then
                txtcedula.Text = lblmensajeCed.Text
                LBLmensajeestud.Text = "Revise las fechas de nacimiento o graduación "
                UpdateNuevoEst.Update()
                Exit Sub
            End If

            If lblcompecono.Text.Length = 0 Then
                LBLmensajeestud.Text = " Seleccione un compromiso económico"
                Exit Sub
            End If

            If CboCarrera.SelectedIndex.ToString = 0 Or CboPeriodo.SelectedIndex.ToString = 0 Then
                LBLmensajeestud.Text = " Seleccione la carrera o Periodo"
                Exit Sub
            End If

            sel = "SELECT max (codigo_estud) as numest " &
                 "FROM DATOS_ESTUD  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datose = New DataSet
            datose.Clear()
            daUs.Fill(datose, "DATOS_ESTUD")
            lblnumestud.Text = datose.Tables(0).Rows(0).Item("numest").ToString + 1


            sel = "INSERT INTO datos_ESTUD " &
                          "(codigo_estud,Cedula_Est, Apellidos_nombre, Provincia, Canton, Parroquia, Fecha_Nac, correo, calle_principal,  telefono, movil, Lugar_Trabajo,  " &
" DireccionTrabajo, Telefono_Trabajo, EstadoCivil, Primaria, Secundaria, Superior, Colegio, TituloBachiller, Fecha_Graduacion, Usuario, Fecha_Ingreso,  " &
           " Nombres_Ref, Ocupacion_Ref, Lugar_Trab_Ref, Telef_Traba_Ref, Tiempo_Conoce, Nombres_Ref1, Ocupacion_Ref1, Lugar_Trab_Ref1, Telef_Traba_Ref1, Tiempo_Conoce1, " &
           " EscogioProfesion, EstudiarCenestur,  Compromiso_econo, AreaEstudio, ModalidadEstudio, Jornada,  " &
"  Etnia,Cod_Periodo,Cod_Carrera,prov_gradua,canton_gradua,parroq_gradua,cedula,fotos) " &
                          "VALUES " &
                          "(@codigo_estud,@Cedula_Est, @Apellidos_nombre, @Provincia, @Canton, @Parroquia, @Fecha_Nac, @correo, @calle_principal,  @telefono, @movil, @Lugar_Trabajo,  " &
"@DireccionTrabajo, @Telefono_Trabajo, @EstadoCivil, @Primaria, @Secundaria, @Superior, @Colegio, @TituloBachiller, @Fecha_Graduacion, @Usuario, @Fecha_Ingreso, " &
"@Nombres_Ref, @Ocupacion_Ref, @Lugar_Trab_Ref, @Telef_Traba_Ref, @Tiempo_Conoce, @Nombres_Ref1, @Ocupacion_Ref1, @Lugar_Trab_Ref1, @Telef_Traba_Ref1, @Tiempo_Conoce1,  " &
"@EscogioProfesion, @EstudiarCenestur, @Compromiso_econo, @AreaEstudio, @ModalidadEstudio, @Jornada, @Etnia,@Cod_Periodo,@Cod_Carrera,@prov_gradua,@canton_gradua,@parroq_gradua,@cedula,@fotos) "
            Dim cmd As New SqlCommand(sel, cntDB)
            cmd.Parameters.AddWithValue("codigo_estud", CType(lblnumestud.Text, Integer))
            cmd.Parameters.AddWithValue("cedula_est", CType(txtcedula.Text, String))
            nomb = txtnombres.Text
            cmd.Parameters.AddWithValue("apellidos_nombre", CType(UCase(nomb), String))
            cmd.Parameters.AddWithValue("Estado", CType("A", String))
            If lblcodprov.Text.Length = 0 Then
                lblcodprov.Text = 0
            End If
            If lblcodcanton.Text.Length = 0 Then
                lblcodcanton.Text = 0
            End If
            If lblcodparroquia.Text.Length = 0 Then
                lblcodparroquia.Text = 0
            End If
            cmd.Parameters.AddWithValue("Provincia", CType(lblcodprov.Text, String))
            cmd.Parameters.AddWithValue("Canton", CType(lblcodcanton.Text, String))
            cmd.Parameters.AddWithValue("Parroquia", CType(lblcodparroquia.Text, String))
            cmd.Parameters.AddWithValue("Fecha_Nac", CType(txtfechaNac.Text, Date))
            cmd.Parameters.AddWithValue("correo", CType(txtemail.Text, String))
            cmd.Parameters.AddWithValue("calle_principal", CType(UCase(txtCallePrincipal.Text), String))
            cmd.Parameters.AddWithValue("telefono", CType(txttelef.Text, String))
            cmd.Parameters.AddWithValue("movil", CType(TxtCelular.Text, String))
            cmd.Parameters.AddWithValue("Lugar_Trabajo", CType(txtLugarTrabajo.Text, String))
            cmd.Parameters.AddWithValue("DireccionTrabajo", CType(txtDireccTrabajo.Text, String))
            cmd.Parameters.AddWithValue("Telefono_Trabajo", CType(txttelefTrabajo.Text, String))
            cmd.Parameters.AddWithValue("EstadoCivil", CType(cboestadocivilestd.Text, String))
            cmd.Parameters.AddWithValue("Primaria", CType(txtEducPrimaria.Text, String))
            cmd.Parameters.AddWithValue("Secundaria", CType(txtEducSecundaria.Text, String))
            cmd.Parameters.AddWithValue("Superior", CType(txtEducSuperior.Text, String))
            cmd.Parameters.AddWithValue("Colegio", CType(txtcolegiograduo.Text, String))
            cmd.Parameters.AddWithValue("TituloBachiller", CType(txtBachiller.Text, String))
            cmd.Parameters.AddWithValue("Fecha_Graduacion", CType(TxtFechaGrad.Text, Date))
            cmd.Parameters.AddWithValue("Usuario", CType("", String))
            cmd.Parameters.AddWithValue("Fecha_Ingreso", CType(Date.Now, Date))

            cmd.Parameters.AddWithValue("Nombres_Ref", CType(TxtNombRef.Text, String))
            cmd.Parameters.AddWithValue("Ocupacion_Ref", CType(txtOcupacionRef.Text, String))
            cmd.Parameters.AddWithValue("Lugar_Trab_Ref", CType(TxtLugarTrabajoRef.Text, String))
            cmd.Parameters.AddWithValue("Telef_Traba_Ref", CType(TxtelefRef.Text, String))
            cmd.Parameters.AddWithValue("Tiempo_Conoce", CType(TxtTiempoConoce.Text, String))
            cmd.Parameters.AddWithValue("Nombres_Ref1", CType(TxtNombRef0.Text, String))
            cmd.Parameters.AddWithValue("Ocupacion_Ref1", CType(txtOcupacionRef0.Text, String))
            cmd.Parameters.AddWithValue("Lugar_Trab_Ref1", CType(TxtLugarTrabajoRef0.Text, String))
            cmd.Parameters.AddWithValue("Telef_Traba_Ref1", CType(TxtelefRef0.Text, String))
            cmd.Parameters.AddWithValue("Tiempo_Conoce1", CType(TxtTiempoConoce0.Text, String))
            cmd.Parameters.AddWithValue("EscogioProfesion", CType(TxtInfAdicional.Text, String))
            cmd.Parameters.AddWithValue("EstudiarCenestur", CType(TxtEstudiaCenestur.Text, String))
            cmd.Parameters.AddWithValue("Compromiso_econo", CType(lblcompecono.Text, String))
            cmd.Parameters.AddWithValue("AreaEstudio", CType(CboAreaEstudio.Text, String))
            'CboModalidadEstudio
            cmd.Parameters.AddWithValue("ModalidadEstudio", CType(CboModalidadEstudio.SelectedValue, Integer))
            cmd.Parameters.AddWithValue("Jornada", CType(CboJornada.Text, String))
           
            cmd.Parameters.AddWithValue("Etnia", CType(CboTipoEtnia.Text, String))
            cmd.Parameters.AddWithValue("Cod_Periodo", CType(lblcodPeriodo.Text, String))
            cmd.Parameters.AddWithValue("Cod_Carrera", CType(lblCarrera.Text, String))

            If lblcodprovAcad.Text.Length = 0 Then
                lblcodprovAcad.Text = 0
            End If
            If lblcodcantonAcad.Text.Length = 0 Then
                lblcodcantonAcad.Text = 0
            End If
            If lblcodparroquiaAcad.Text.Length = 0 Then
                lblcodparroquiaAcad.Text = 0
            End If
            cmd.Parameters.AddWithValue("prov_gradua", CType(lblcodprovAcad.Text, Integer))
            cmd.Parameters.AddWithValue("canton_gradua", CType(lblcodcantonAcad.Text, Integer))
            cmd.Parameters.AddWithValue("parroq_gradua", CType(lblcodparroquiaAcad.Text, Integer))
            cmd.Parameters.AddWithValue("cedula", CType(chkCedula.Checked, Integer))
            cmd.Parameters.AddWithValue("fotos", CType(ChkFotos.Checked, Integer))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()

            
            Call buscacodigo()
            Call usuarios()

            LBLmensajeestud.Text = "**  Se envió los datos ingresados  ** "
            cdmNuevoEstud.Enabled = False
            UpdateNuevoEst.Update()

            '   Session.Add("cod_usuM", lblnumestud.Text)

            ' Response.Redirect("matriculaingles.aspx")

        Catch ex As Exception
            LBLmensajeestud.Text = "ERROR: " & ex.Message

        End Try
    End Sub
    
    Sub usuarios()
        Dim sel As String
        Dim l As Integer
        Dim MiDataset As New DataSet
        Try
            l = (txtcedula.Text.Length) - 4
            txtpas.Text = txtcedula.Text.Substring(l, 4).Trim
            sel = "INSERT INTO USUARIOS " & _
                   "(Codigo_Usuario,cedula,login,password,tipo_usuario,fecha_ingreso) " & _
                   "VALUES " & _
                   "(@Codigo_Usuario,@cedula,@login,@password,@tipo_usuario,@fecha_ingreso) "
        Dim cmdu As New SqlCommand(sel, cntDB)

        cmdu.Parameters.AddWithValue("Codigo_Usuario", CType(lblcodestud.Text, Integer))
        cmdu.Parameters.AddWithValue("cedula", CType(txtcedula.Text.TrimEnd, String))
        cmdu.Parameters.AddWithValue("login", CType(txtcedula.Text.TrimEnd, String))
        cmdu.Parameters.AddWithValue("password", CType(txtpas.Text.TrimEnd, String))
        '1 estudinates  2 docentes
            cmdu.Parameters.AddWithValue("tipo_usuario", CType(1, Integer))
            cmdu.Parameters.AddWithValue("fecha_ingreso", CType(Date.Now, Date))

        cntDB.Open()
        Dim tu As Integer = CInt(cmdu.ExecuteScalar())
            cntDB.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub actualizadatos()
        Dim sel, nomb As String

        Try

            If txtcedula.Text = Nothing Or (txtcedula.Text.TrimEnd.Length < 10 Or txtcedula.Text.TrimEnd.Length > 10) Then
                txtcedula.Text = lblmensajeCed.Text
                LBLmensajeestud.Text = "Ingrese los 10 dígitos de la cédula sin el - "
                UpdateNuevoEst.Update()
                Exit Sub
            End If


            If TxtFechaGrad.Text = Nothing Or txtfechaNac.Text = Nothing Then
                txtcedula.Text = lblmensajeCed.Text
                LBLmensajeestud.Text = "Revise las fechas de nacimiento o graduación "
                UpdateNuevoEst.Update()
                Exit Sub
            End If

            If lblcompecono.Text.Length = 0 Then
                LBLmensajeestud.Text = " Seleccione un compromiso económico"
                Exit Sub
            End If


            sel = "update datos_ESTUD " &
                           " set  Apellidos_nombre=@Apellidos_nombre, Provincia=@Provincia, Canton=@Canton, Parroquia=@Parroquia, Fecha_Nac=@Fecha_Nac, correo=@correo, calle_principal=@calle_principal,  telefono=@telefono, movil=@movil, Lugar_Trabajo=@Lugar_Trabajo,  " &
"DireccionTrabajo=@DireccionTrabajo, Telefono_Trabajo=@Telefono_Trabajo, EstadoCivil=@EstadoCivil, Primaria=@Primaria, Secundaria=@Secundaria, Superior=@Superior, Colegio=@Colegio, TituloBachiller=@TituloBachiller, Fecha_Graduacion=@Fecha_Graduacion, Usuario=@Usuario, Fecha_Ingreso=@Fecha_Ingreso,   " &
"  Nombres_Ref=@Nombres_Ref, Ocupacion_Ref=@Ocupacion_Ref, Lugar_Trab_Ref=@Lugar_Trab_Ref, Telef_Traba_Ref=@Telef_Traba_Ref, Tiempo_Conoce=@Tiempo_Conoce, Nombres_Ref1=@Nombres_Ref1, Ocupacion_Ref1=@Ocupacion_Ref1, Lugar_Trab_Ref1=@Lugar_Trab_Ref1, Telef_Traba_Ref1=@Telef_Traba_Ref1, Tiempo_Conoce1=@Tiempo_Conoce1,  " &
"EscogioProfesion=@EscogioProfesion, EstudiarCenestur=@EstudiarCenestur,   Compromiso_econo=@Compromiso_econo, AreaEstudio=@AreaEstudio, ModalidadEstudio=@ModalidadEstudio, Jornada=@Jornada,  " &
"Etnia=@Etnia, Cod_Periodo=@Cod_Periodo, Cod_Carrera=@Cod_Carrera, prov_gradua=@prov_gradua,canton_gradua=@canton_gradua,parroq_gradua=@parroq_gradua,cedula=@cedula,fotos=@fotos  " &
" where codigo_estud=" & lblcodestud.Text & ""
            Dim cmd As New SqlCommand(sel, cntDB)
            '
            nomb = txtnombres.Text
            cmd.Parameters.AddWithValue("@apellidos_nombre", CType(UCase(nomb), String))
            cmd.Parameters.AddWithValue("@Estado", CType("A", String))
            cmd.Parameters.AddWithValue("@Provincia", CType(lblcodprov.Text, String))
            cmd.Parameters.AddWithValue("@Canton", CType(lblcodcanton.Text, String))
            cmd.Parameters.AddWithValue("@Parroquia", CType(lblcodparroquia.Text, String))
            cmd.Parameters.AddWithValue("@Fecha_Nac", CType(txtfechaNac.Text, Date))
            cmd.Parameters.AddWithValue("@correo", CType(txtemail.Text, String))
            cmd.Parameters.AddWithValue("@calle_principal", CType(UCase(txtCallePrincipal.Text), String))
            cmd.Parameters.AddWithValue("@telefono", CType(txttelef.Text, String))
            cmd.Parameters.AddWithValue("@movil", CType(TxtCelular.Text, String))
            cmd.Parameters.AddWithValue("@Lugar_Trabajo", CType(txtLugarTrabajo.Text, String))
            cmd.Parameters.AddWithValue("@DireccionTrabajo", CType(txtDireccTrabajo.Text, String))
            cmd.Parameters.AddWithValue("@Telefono_Trabajo", CType(txttelefTrabajo.Text, String))
            cmd.Parameters.AddWithValue("@EstadoCivil", CType(cboestadocivilestd.Text, String))
            cmd.Parameters.AddWithValue("@Primaria", CType(txtEducPrimaria.Text, String))
            cmd.Parameters.AddWithValue("@Secundaria", CType(txtEducSecundaria.Text, String))
            cmd.Parameters.AddWithValue("@Superior", CType(txtEducSuperior.Text, String))
            cmd.Parameters.AddWithValue("@Colegio", CType(txtcolegiograduo.Text, String))
            cmd.Parameters.AddWithValue("@TituloBachiller", CType(txtBachiller.Text, String))
            cmd.Parameters.AddWithValue("@Fecha_Graduacion", CType(TxtFechaGrad.Text, Date))
            cmd.Parameters.AddWithValue("@Usuario", CType("", String))
            cmd.Parameters.AddWithValue("@Fecha_Ingreso", CType(Date.Now, Date))

            cmd.Parameters.AddWithValue("@Nombres_Ref", CType(TxtNombRef.Text, String))
            cmd.Parameters.AddWithValue("@Ocupacion_Ref", CType(txtOcupacionRef.Text, String))
            cmd.Parameters.AddWithValue("@Lugar_Trab_Ref", CType(TxtLugarTrabajoRef.Text, String))
            cmd.Parameters.AddWithValue("@Telef_Traba_Ref", CType(TxtelefRef.Text, String))
            cmd.Parameters.AddWithValue("@Tiempo_Conoce", CType(TxtTiempoConoce.Text, String))
            cmd.Parameters.AddWithValue("@Nombres_Ref1", CType(TxtNombRef0.Text, String))
            cmd.Parameters.AddWithValue("@Ocupacion_Ref1", CType(txtOcupacionRef0.Text, String))
            cmd.Parameters.AddWithValue("@Lugar_Trab_Ref1", CType(TxtLugarTrabajoRef0.Text, String))
            cmd.Parameters.AddWithValue("@Telef_Traba_Ref1", CType(TxtelefRef0.Text, String))
            cmd.Parameters.AddWithValue("@Tiempo_Conoce1", CType(TxtTiempoConoce0.Text, String))
            cmd.Parameters.AddWithValue("@EscogioProfesion", CType(TxtInfAdicional.Text, String))
            cmd.Parameters.AddWithValue("@EstudiarCenestur", CType(TxtEstudiaCenestur.Text, String))

            cmd.Parameters.AddWithValue("@Compromiso_econo", CType(lblcompecono.Text, String))
            cmd.Parameters.AddWithValue("@AreaEstudio", CType(CboAreaEstudio.Text, String))
            cmd.Parameters.AddWithValue("@ModalidadEstudio", CType(CboModalidadEstudio.SelectedValue, String))
            cmd.Parameters.AddWithValue("@Jornada", CType(CboJornada.Text, String))
           
            cmd.Parameters.AddWithValue("@Etnia", CType(CboTipoEtnia.Text, String))
            cmd.Parameters.AddWithValue("@Cod_Periodo", CType(lblcodPeriodo.Text, Integer))
            cmd.Parameters.AddWithValue("@Cod_Carrera", CType(lblCarrera.Text, Integer))

            cmd.Parameters.AddWithValue("@prov_gradua", CType(lblcodprovAcad.Text, Integer))
            cmd.Parameters.AddWithValue("@canton_gradua", CType(lblcodcantonAcad.Text, Integer))
            cmd.Parameters.AddWithValue("@parroq_gradua", CType(lblcodparroquiaAcad.Text, Integer))
            cmd.Parameters.AddWithValue("@cedula", CType(chkCedula.Checked, Integer))
            cmd.Parameters.AddWithValue("@fotos", CType(ChkFotos.Checked, Integer))
            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()

            LBLmensajeestud.Text = "**  Se actualizó los datos ingresados  ** "
            cdmNuevoEstud.Enabled = False
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('**  Se actualizó los datos ingresados, puede reimprimir la inscripción  **');", True)
            UpdateNuevoEst.Update()

            Session.Add("cod_usuM", lblcodestud.Text)

            Response.Redirect("matriculaingles.aspx")

        Catch ex As Exception
            LBLmensajeestud.Text = "ERROR: " & ex.Message

        End Try
    End Sub

    Sub encerar()
        Try
            txtcedula.Text = Nothing
            txtpas.Text = Nothing
            txtnombres.Text = Nothing

            txtfechaNac.Text = Nothing
            lblcodprov.Text = Nothing

            txtemail.Text = Nothing
            txttelef.Text = Nothing
            txtcolegiograduo.Text = Nothing

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

    Protected Sub CboPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPeriodo.SelectedIndexChanged
        Dim p As Integer = Me.CboPeriodo.SelectedIndex
        Dim codest As String = CboPeriodo.Items(p - 1).Value
        lblcodPeriodo.Text = codest
        UpdateNuevoEst.Update()
    End Sub

    Protected Sub CboCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCarrera.SelectedIndexChanged
        Dim p As Integer = Me.CboCarrera.SelectedIndex
        Dim codest As String = CboCarrera.Items(p - 1).Value
        lblcurso.Text = CboCarrera.Items(p).Text
        lblCarrera.Text = codest
        UpdateNuevoEst.Update()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim p As Integer = Me.RadioButtonList1.SelectedIndex
        Dim codest As String = RadioButtonList1.Items(p).Value
        lblcompecono.Text = codest
        UpdateNuevoEst.Update()
    End Sub

    Protected Sub ImgImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles ImgImprimir.Click
        If txtcedula.Text.Length < 10 Then
            LBLmensajeestud.Text = "Ingrese el No. de Cédula"
            Exit Sub
        End If
        Session.Add("cedula", txtcedula.Text)
        Response.Redirect("ImprimirEstudianteWeb.aspx")


    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Call VerDatos()
        Call CARGARDATOSPROVCANTON()
    End Sub

    Protected Sub ChkPos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPos.CheckedChanged
        ChkReg.Checked = False
        ChkPos.Checked = True
        CboCarrera.Visible = True
        UpdateNuevoEst.Update()
    End Sub

    Protected Sub ChkReg_CheckedChanged(sender As Object, e As EventArgs) Handles ChkReg.CheckedChanged
        ChkPos.Checked = False
        ChkReg.Checked = True
        CboCarrera.Visible = True
        UpdateNuevoEst.Update()
    End Sub


    Private Sub BindDropDownList(ddl As DropDownList, query As String, text As String, value As String, defaultText As String)
        Dim ConAulaVirtual As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection(ConAulaVirtual)
            Using sda As New SqlDataAdapter()
                cmd.Connection = con
                con.Open()
                ddl.DataSource = cmd.ExecuteReader()
                ddl.DataTextField = text
                ddl.DataValueField = value
                ddl.DataBind()
                con.Close()
            End Using
        End Using
        ddl.Items.Insert(0, New ListItem(defaultText, "0"))
        UpdateNuevoEst.Update()
    End Sub

    Sub CARGARDATOSPROVCANTON()
        If lblcodprov.Text <> Nothing Then
            Dim query As String = "select Cod_Provincia, Descripcion_Prov from Provincias  "
            BindDropDownListco(ddlProvincia, query, "Descripcion_Prov", "Cod_Provincia", lblcodprov.Text)
            Dim queryAcad As String = "select Cod_Provincia, Descripcion_Prov from Provincias  "
            BindDropDownListco(ddlProvinciaAcad, queryAcad, "Descripcion_Prov", "Cod_Provincia", lblcodprovAcad.Text)
        End If
        If lblcodcanton.Text <> Nothing Then
            Dim queryc As String = "select ID_CANTON, DETALLECANTON from CANTON where IN_PROVINCIA=" & lblcodprov.Text & " and  ID_CANTON=" & lblcodcanton.Text & " "
            BindDropDownListco(ddlCanton, queryc, "DETALLECANTON", "ID_CANTON", lblcodcanton.Text)
            Dim querycAcad As String = "select ID_CANTON, DETALLECANTON from CANTON where IN_PROVINCIA=" & lblcodprovAcad.Text & " and  ID_CANTON=" & lblcodcantonAcad.Text & " "
            BindDropDownListco(ddlCantonAcad, querycAcad, "DETALLECANTON", "ID_CANTON", lblcodcantonAcad.Text)
        End If
        If lblcodparroquia.Text <> Nothing Then
            Dim queryp As String = "select id_parroquia, parroquia from PARROQUIA WHERE id_prov=" & lblcodprov.Text & " and  id_cant=" & lblcodcanton.Text & " and id_parroquia=" & lblcodparroquia.Text & " "
            BindDropDownListco(ddlParroquia, queryp, "parroquia", "id_parroquia", lblcodparroquia.Text)
            Dim querypAcad As String = "select id_parroquia, parroquia from PARROQUIA WHERE id_prov=" & lblcodprovAcad.Text & " and  id_cant=" & lblcodcantonAcad.Text & " and id_parroquia=" & lblcodparroquiaAcad.Text & " "
            BindDropDownListco(ddlParroquiaAcad, querypAcad, "parroquia", "id_parroquia", lblcodparroquiaAcad.Text)
        End If
    End Sub

    Private Sub BindDropDownListco(ddl As DropDownList, query As String, text As String, value As String, defaultText As String)
        Dim ConAulaVirtual As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection(ConAulaVirtual)
            Using sda As New SqlDataAdapter()
                cmd.Connection = con
                con.Open()
                ddl.DataSource = cmd.ExecuteReader()
                ddl.DataTextField = text
                ddl.DataValueField = value
                ddl.DataBind()
                con.Close()
            End Using
        End Using
        Try

        Catch ex As Exception
            ddl.Items.FindByValue(defaultText).Selected = True
            UpdateNuevoEst.Update()
        End Try

    End Sub

    Protected Sub ddlProvincia_changed(sender As Object, e As EventArgs) Handles ddlProvincia.SelectedIndexChanged
        ddlCanton.Enabled = False
        ddlParroquia.Enabled = False
        ddlCanton.Items.Clear()
        ddlParroquia.Items.Clear()
        ddlCanton.Items.Insert(0, New ListItem("Seleccione", "0"))
        ddlParroquia.Items.Insert(0, New ListItem("Seleccione", "0"))
        Dim countryId As Integer = Integer.Parse(ddlProvincia.SelectedItem.Value)
        lblcodprov.Text = countryId
        If countryId > 0 Then
            Dim query As String = String.Format("select ID_CANTON, DETALLECANTON from CANTON where IN_PROVINCIA = {0}", countryId)
            BindDropDownList(ddlCanton, query, "DETALLECANTON", "ID_CANTON", "Seleccione")
            ddlCanton.Enabled = True
        End If
    End Sub
    Protected Sub ddlCanton_Changed(sender As Object, e As EventArgs) Handles ddlCanton.SelectedIndexChanged
        ddlParroquia.Enabled = False
        ddlParroquia.Items.Clear()
        ddlParroquia.Items.Insert(0, New ListItem("Seleccione", "0"))
        Dim stateId As Integer = Integer.Parse(ddlCanton.SelectedItem.Value)
        Dim countryId As Integer = Integer.Parse(ddlProvincia.SelectedItem.Value)
        lblcodcanton.Text = stateId
        If stateId > 0 Then
            Dim query As String = "select id_parroquia, parroquia from PARROQUIA where id_prov=" & countryId & " and  id_cant=" & stateId & " "
            BindDropDownList(ddlParroquia, query, "parroquia", "id_parroquia", "Seleccione")
            ddlParroquia.Enabled = True
        End If
    End Sub
    Protected Sub ddlParroquia_Changed(sender As Object, e As EventArgs) Handles ddlParroquia.SelectedIndexChanged
        Dim parr As Integer = Integer.Parse(ddlParroquia.SelectedItem.Value)
        lblcodparroquia.Text = parr
    End Sub
    Protected Sub ddlProvinciaAcad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvinciaAcad.SelectedIndexChanged
        ddlCantonAcad.Enabled = False
        ddlParroquiaAcad.Enabled = False
        ddlCantonAcad.Items.Clear()
        ddlParroquiaAcad.Items.Clear()
        ddlCantonAcad.Items.Insert(0, New ListItem("Seleccione", "0"))
        ddlParroquiaAcad.Items.Insert(0, New ListItem("Seleccione", "0"))
        Dim countryIdAcad As Integer = Integer.Parse(ddlProvinciaAcad.SelectedItem.Value)
        lblcodprovAcad.Text = countryIdAcad
        If countryIdAcad > 0 Then
            Dim query As String = String.Format("select ID_CANTON, DETALLECANTON from CANTON where IN_PROVINCIA = {0}", countryIdAcad)
            BindDropDownList(ddlCantonAcad, query, "DETALLECANTON", "ID_CANTON", "Seleccione")
            ddlCantonAcad.Enabled = True
        End If
    End Sub
    Protected Sub ddlParroquiaAcad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlParroquiaAcad.SelectedIndexChanged
        Dim parr As Integer = Integer.Parse(ddlParroquiaAcad.SelectedItem.Value)
        lblcodparroquiaAcad.Text = parr
    End Sub
    Protected Sub ddlCantonAcad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCantonAcad.SelectedIndexChanged
        ddlParroquiaAcad.Enabled = False
        ddlParroquiaAcad.Items.Clear()
        ddlParroquiaAcad.Items.Insert(0, New ListItem("Seleccione", "0"))
        Dim stateIdAcad As Integer = Integer.Parse(ddlCantonAcad.SelectedItem.Value)
        Dim countryIdAcad As Integer = Integer.Parse(ddlProvinciaAcad.SelectedItem.Value)
        lblcodcantonAcad.Text = stateIdAcad
        If stateIdAcad > 0 Then
            Dim query As String = "select id_parroquia, parroquia from PARROQUIA where id_prov=" & countryIdAcad & " and  id_cant=" & stateIdAcad & " "
            BindDropDownList(ddlParroquiaAcad, query, "parroquia", "id_parroquia", "Seleccione")
            ddlParroquiaAcad.Enabled = True
        End If
    End Sub

End Class


