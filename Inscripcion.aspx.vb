Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports AjaxControlToolkit
Partial Class Inscripcion
    Inherits System.Web.UI.Page
    Dim cod As String
    Dim tipo_us As Integer
    Private datos As DataSet
    Private datosInf As DataSet
    Private datose, datosi As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Page.IsPostBack Then
                Session.Clear()
                Session.Abandon()
                Me.Form.Attributes.Add("autocomplete", "off")
                'cod = Session("user").ToString()
                lblcod_us.Text = ""
                Call verperiodo()

                lblCodCarrera.Text = 0
                lblcodModalidad.Text = 0

                lblcontrolced.Text = 0

            End If
        Catch ex As Exception
            Response.Redirect("DEFAULTs.aspx")
        End Try


    End Sub


    Protected Sub FileUploadComplete(ByVal sender As Object, ByVal e As EventArgs)
        Dim nomba, ext As String
        Try
            If AsyncFileUpload1.HasFile And lblcn.Text = 0 Then
                ext = Path.GetExtension(AsyncFileUpload1.FileName)
                nomba = txtcedula.Text.TrimEnd
                If nomba.ToString.Length > 8 Then
                    Dim filename As String = System.IO.Path.GetFileName(AsyncFileUpload1.FileName)
                    AsyncFileUpload1.SaveAs(Server.MapPath("~/docusubidos/") + nomba + ext)
                    lblArchivo.Text = "http://academico.itq.edu.ec:82/docusubidos/" + nomba + ext
                    lblarchivoadjunto.Text = 1
                    lblMessageced.Text = "Archivo adjuntado"
                    lblMessageced.Visible = True
                    AsyncFileUpload1.Visible = False

                    Session.Add("ceda", lblArchivo.Text.Trim)
                    lblced.Text = Session("ceda").ToString()
                    lblmensajeactualizar.Text = Nothing
                    Call grabardatos()
                Else
                    lblmensajeactualizar.Text = "No tiene permisos para subir archivos"
                    lblmensajeactualizar.Visible = True
                End If

            End If
        Catch ex As Exception
            lblmensajeactualizar.Text = ex.Message
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
    Sub jornada()
        Dim daUs As SqlDataAdapter
        Dim sel, cx As String
        Dim ds As New DataSet
        Dim i, c As Integer
        Dim v As DataRow



        Try
            sel = "SELECT DetalleJornada, Id_Jornada " &
                    "FROM JORNADA  order by DetalleJornada "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "JORNADA")
            cbojornada.DataSource = datos
            cbojornada.Items.Clear()
            i = datos.Tables(0).Rows.Count
            If i > 0 Then

                cbojornada.DataSource = datos
                cbojornada.DataTextField = "DetalleJornada"
                cbojornada.DataValueField = "Id_Jornada"
                cbojornada.DataBind()

                'Add Default Item in the DropDownList
                cbojornada.Items.Insert(0, New ListItem("Seleccione"))

                cbojornada.Items.FindByValue(lblcodjornada.Text.TrimEnd).Selected = True


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
            sel = "SELECT distinct   Nombre_Basica,Cod_AnioBasica " &
                    "FROM CARRERAS where Inscripciong='A'  order by  Nombre_Basica  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAS")
            CboCarrera.DataSource = datos
            CboCarrera.Items.Clear()
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                CboCarrera.DataSource = datos
                CboCarrera.DataTextField = "Nombre_Basica"
                CboCarrera.DataValueField = "Cod_AnioBasica"
                CboCarrera.DataBind()

                'Add Default Item in the DropDownList
                CboCarrera.Items.Insert(0, New ListItem("Seleccione"))

                CboCarrera.Items.FindByValue(lblCodCarrera.Text).Selected = True

            End If

            cntDB.Close()
        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try
    End Sub




    Sub grabardatos()
        Dim sel, sel1, sel2, nomb As String
        Dim GC, valor, np As Double

        Try
            LBLmensajeestud.Text = Nothing
            If Chk1.Checked = True And Chk2.Checked = True Then

                LBLmensajeestud.Text = "Seleccione una sola opción de pago "
                Exit Sub
            End If

            If Chk1.Checked = False And Chk2.Checked = False Then

                LBLmensajeestud.Text = "Seleccione la opción de pago "
                Exit Sub
            End If



            If lblMessageced.Text = "" Then

                LBLmensajeestud.Text = "Envié el archivo adjunto"
                Exit Sub
            End If


            If TxtCelular.Text = "" Then

                LBLmensajeestud.Text = "Ingrese el No. de celular"
                Exit Sub
            End If
            If Txtnombres.Text = "" Then

                LBLmensajeestud.Text = "Ingrese el nombre"
                Exit Sub
            End If

            If Txtapellidopat.Text = "" Then

                LBLmensajeestud.Text = "Ingrese el apellido paterno"
                Exit Sub
            End If


            If Txtapellidomat.Text = "" Then

                LBLmensajeestud.Text = "Ingrese el apellido materno"
                Exit Sub
            End If


            If txtdirecdomi.Text = "" Then

                LBLmensajeestud.Text = "Ingrese la dirección"
                Exit Sub
            End If


            If txtemail.Text = "" Then

                LBLmensajeestud.Text = "Ingrese el correo"
                Exit Sub
            End If

            If txtfechaNac.Text = "" Then

                LBLmensajeestud.Text = "Ingrese fecha de nacimiento"
                Exit Sub
            End If

            Call valida()

            If lblcontrol.Text = 1 Then
                Call actualizadatos()
                Exit Sub
            End If

            If lblcontrolced.Text = 1 Then
                Call vermax()

                If txtcedula.Text = Nothing Or (txtcedula.Text.Length < 10 Or txtcedula.Text.Length > 10) And CboTipoDoc.SelectedValue = 1 Then
                    txtcedula.Text = lblmensajeCed.Text
                    LBLmensajeestud.Text = "Ingrese los 10 dígitos de la cédula sin el - "

                    Exit Sub
                End If



                If CboCarrera.SelectedIndex.ToString = 0 Then
                    LBLmensajeestud.Text = " Seleccione la carrera o Periodo"
                    Exit Sub
                End If

                sel = "INSERT INTO datos_ESTUD " &
                              "(codigo_estud,Cedula_Est, Apellidos_nombre, Fecha_Nac, correo, calle_principal, telefono, movil,  Usuario, Fecha_Ingreso,  " &
               "    ModalidadEstudio, Jornada,correocamb  " &
    "  Cod_Periodo,Cod_Carrera,Apellido1,Apellido2,Nombres12,carrera,ControlPlataforma) " &
                              "VALUES " &
                              "(@codigo_estud,@Cedula_Est, @Apellidos_nombre, @Fecha_Nac, @correo, @calle_principal,  @telefono, @movil, @Usuario, @Fecha_Ingreso,   " &
    "  @ModalidadEstudio, @Jornada, @Cod_Periodo,@Cod_Carrera,@Apellido1,@Apellido2,@Nombres12,@carrera,@ControlPlataforma,@correocamb) "
                Dim cmd As New SqlCommand(sel, cntDB)

                cmd.Parameters.AddWithValue("codigo_estud", CType(lblnumestud.Text, Integer))
                cmd.Parameters.AddWithValue("cedula_est", CType(txtcedula.Text, String))
                nomb = Txtapellidopat.Text & " " & Txtapellidomat.Text & " " & Txtnombres.Text
                cmd.Parameters.AddWithValue("apellidos_nombre", CType(UCase(nomb), String))
                cmd.Parameters.AddWithValue("Estado", CType("A", String))

                cmd.Parameters.AddWithValue("Fecha_Nac", CType(txtfechaNac.Text, Date))
                cmd.Parameters.AddWithValue("correo", CType(txtemail.Text, String))
                cmd.Parameters.AddWithValue("correocamb", CType(txtemailCambridge.Text, String))
                cmd.Parameters.AddWithValue("calle_principal", CType(UCase(txtdirecdomi.Text), String))

                cmd.Parameters.AddWithValue("telefono", CType(txttelef.Text, String))
                cmd.Parameters.AddWithValue("movil", CType(TxtCelular.Text, String))

                cmd.Parameters.AddWithValue("Usuario", CType("", String))
                cmd.Parameters.AddWithValue("Fecha_Ingreso", CType(Date.Now, Date))



                cmd.Parameters.AddWithValue("ModalidadEstudio", CType(10011, Integer))
                cmd.Parameters.AddWithValue("Jornada", CType(lbljornada.Text.TrimEnd, String))


                cmd.Parameters.AddWithValue("Cod_Periodo", CType(lblcodPeriodo.Text, String))
                cmd.Parameters.AddWithValue("Cod_Carrera", CType(lblCodCarrera.Text, String))

                cmd.Parameters.AddWithValue("Apellido1", CType(UCase(Txtapellidopat.Text), String))
                cmd.Parameters.AddWithValue("Apellido2", CType(UCase(Txtapellidomat.Text), String))
                cmd.Parameters.AddWithValue("Nombres12", CType(UCase(Txtnombres.Text), String))

                'carrera
                cmd.Parameters.AddWithValue("carrera", CType((lblnombCarrera.Text), String))

                cmd.Parameters.AddWithValue("@ControlPlataforma", CType(CboPlataforma.SelectedValue, Integer))


                Try


                    cntDB.Open()
                    Dim t As Integer = CInt(cmd.ExecuteScalar())
                    cntDB.Close()
                Catch ex As Exception
                    Dim ES As String = ex.Message
                End Try
                Call buscacodigo()
                Call usuarios()



                sel2 = "INSERT INTO PracticasProfesionales " &
                              "(CODIGOESTUD) " &
                              "VALUES " &
                              "(@CODIGOESTUD) "
                Dim cmd2 As New SqlCommand(sel2, cntDB)

                cmd2.Parameters.AddWithValue("CODIGOESTUD", CType(lblcodestud.Text, Integer))

                Try
                    cntDB.Open()
                    Dim t2 As Integer = CInt(cmd2.ExecuteScalar())
                    cntDB.Close()

                Catch ex As Exception
                    Dim s As String = ex.Message
                    cntDB.Close()
                End Try

                Session.Add("cod_usuM", lblnumestud.Text)

                Session.Add("codca", 3)


                Session.Add("codp", lblcodPeriodo.Text)
                Session.Add("detallep", lblperiodo.Text)
                Session.Add("codj", lblcodjornada.Text)
                Session.Add("jornada", lbljornada.Text)
                Session.Add("nmat", lblnumMatricula.Text)

                LBLmensajeestud.Text = "**  Se envió los datos ingresados, puede matricularse  ** "


                Dim ar As String = Session("ceda").ToString()

                If ar.Length > 5 Then
                    '  Response.Redirect("matriculaingles.aspx")
                    ' cdmNuevoEstud.Enabled = False
                Else
                    LBLmensajeestud.Text = "Adjunte el archivo"
                End If

                Session.Add("cod_usu", lblnumestud.Text)
                Session.Add("cod_periodo", lblcodPeriodo.Text)
                Session.Add("cod_carrera", 3)
                Session.Add("grupo", 0)



            End If

        Catch ex As Exception
            LBLmensajeestud.Text = "ERROR: " & ex.Message

        End Try
    End Sub
    Sub actualizadatos()
        Dim sel, nomb As String
        Dim gc, np As Double

        Try

            If txtcedula.Text = Nothing Or (txtcedula.Text.TrimEnd.Length < 10 Or txtcedula.Text.TrimEnd.Length > 10) Then
                txtcedula.Text = lblmensajeCed.Text
                LBLmensajeestud.Text = "Ingrese los 10 dígitos de la cédula sin el - "

                Exit Sub
            End If





            sel = "update datos_ESTUD " &
                           " set  Apellidos_nombre=@Apellidos_nombre, Fecha_Nac=@Fecha_Nac, correo=@correo, calle_principal=@calle_principal,  telefono=@telefono, movil=@movil, Usuario=@Usuario, Fecha_Ingreso=@Fecha_Ingreso,   " &
"  ModalidadEstudio=@ModalidadEstudio, Jornada=@Jornada, carrera=@carrera,  " &
"Cod_Periodo=@Cod_Periodo, Cod_Carrera=@Cod_Carrera,Apellido1=@Apellido1, Apellido2=@Apellido2,Nombres12=@Nombres12,ControlPlataforma=@ControlPlataforma,correocamb=@correocamb " &
" where codigo_estud=" & lblcodestud.Text & ""
            Dim cmd As New SqlCommand(sel, cntDB)
            '
            nomb = Txtapellidopat.Text & " " & Txtapellidomat.Text & " " & Txtnombres.Text
            cmd.Parameters.AddWithValue("@apellidos_nombre", CType(UCase(nomb), String))
            cmd.Parameters.AddWithValue("@Estado", CType("A", String))

            cmd.Parameters.AddWithValue("@Fecha_Nac", CType(txtfechaNac.Text, Date))
            cmd.Parameters.AddWithValue("@correo", CType(txtemail.Text, String))
            cmd.Parameters.AddWithValue("correocamb", CType(txtemailCambridge.Text, String))
            cmd.Parameters.AddWithValue("@calle_principal", CType(UCase(txtdirecdomi.Text), String))
            cmd.Parameters.AddWithValue("@telefono", CType(txttelef.Text, String))
            cmd.Parameters.AddWithValue("@movil", CType(TxtCelular.Text, String))

            cmd.Parameters.AddWithValue("@Usuario", CType("", String))
            cmd.Parameters.AddWithValue("@Fecha_Ingreso", CType(Date.Now, Date))


            cmd.Parameters.AddWithValue("@ModalidadEstudio", CType(10011, String))
            cmd.Parameters.AddWithValue("@Jornada", CType(lbljornada.Text.TrimEnd, String))

            cmd.Parameters.AddWithValue("@Cod_Periodo", CType(lblcodPeriodo.Text, Integer))
            cmd.Parameters.AddWithValue("@Cod_Carrera", CType(lblCodCarrera.Text, Integer))

            cmd.Parameters.AddWithValue("@Apellido1", CType(UCase(Txtapellidopat.Text), String))

            cmd.Parameters.AddWithValue("@Apellido2", CType(UCase(Txtapellidomat.Text), String))
            cmd.Parameters.AddWithValue("@Nombres12", CType(UCase(Txtnombres.Text), String))

            cmd.Parameters.AddWithValue("carrera", CType((lblnombCarrera.Text), String))
            'ControlPlataforma
            cmd.Parameters.AddWithValue("@ControlPlataforma", CType(CboPlataforma.SelectedValue, Integer))

            cntDB.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())
            cntDB.Close()



            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('**  Se actualizó los datos ingresados y el archivo, puede matricularse **');", True)



            If Chk1.Checked = True Then
                gc = 110
                np = 1
            End If

            If Chk2.Checked = True Then
                gc = 55
                np = 2
            End If
            Session.Add("cod_usuM", lblcodestud.Text)

            Session.Add("vpago", gc)
            Session.Add("npago", np)
            Session.Add("codca", 3)
            Session.Add("codp", lblcodPeriodo.Text)
            Session.Add("detallep", lblperiodo.Text)

            Session.Add("codj", lblcodjornada.Text.TrimEnd)
            Session.Add("jornada", lbljornada.Text)
            Session.Add("nmat", lblnumMatricula.Text)

            Dim ar As String = Session("ceda").ToString()

            If ar.Length > 5 Then
                ' Response.Redirect("matriculaingles.aspx")
                '  cdmNuevoEstud.Enabled = False
                ' LBLmensajeestud.Text = "**  Se actualizó los datos ingresados  ** "
            Else
                LBLmensajeestud.Text = "Adjunte el archivo"
            End If

        Catch ex As Exception
            '  LBLmensajeestud.Text = "ERROR: " & ex.Message

        End Try
    End Sub

    Sub valida()
        Dim m_ruc As String
        Dim m_largoruc, m_digito_provincia, m_modulo, m_suma, m_residuo, m_digito_verificador As Double
        Dim m_d1, m_d2, m_d3, m_d4, m_d5, m_d6, m_d7, m_d8, m_d9, m_d10 As Double
        Dim m_p1, m_p2, m_p3, m_p4, m_p5, m_p6, m_p7, m_p8, m_p9 As Double
        Dim m_pri, m_pub, m_nat As Integer

        m_pri = 0
        m_pub = 0
        m_nat = 0

        lblCodTipoIdent0.Text = Nothing
        m_modulo = 11
        m_ruc = Trim(txtcedula.Text)
        m_largoruc = Len(m_ruc)


        m_digito_provincia = Val(Left(m_ruc, 2))
        If m_digito_provincia >= 1 And m_digito_provincia <= 24 Then
            m_d1 = Val(Mid(m_ruc, 1, 1))
            m_d2 = Val(Mid(m_ruc, 2, 1))
            m_d3 = Val(Mid(m_ruc, 3, 1))
            m_d4 = Val(Mid(m_ruc, 4, 1))
            m_d5 = Val(Mid(m_ruc, 5, 1))
            m_d6 = Val(Mid(m_ruc, 6, 1))
            m_d7 = Val(Mid(m_ruc, 7, 1))
            m_d8 = Val(Mid(m_ruc, 8, 1))
            m_d9 = Val(Mid(m_ruc, 9, 1))
            m_d10 = Val(Mid(m_ruc, 10, 1))
            If m_d3 <> 7 And m_d3 <> 8 Then
                If m_d3 < 6 Then
                    m_nat = 1
                    m_p1 = m_d1 * 2
                    If m_p1 >= 10 Then m_p1 = m_p1 - 9
                    m_p2 = m_d2 * 1
                    If m_p2 >= 10 Then m_p2 = m_p2 - 9
                    m_p3 = m_d3 * 2
                    If m_p3 >= 10 Then m_p3 = m_p3 - 9
                    m_p4 = m_d4 * 1
                    If m_p4 >= 10 Then m_p4 = m_p4 - 9
                    m_p5 = m_d5 * 2
                    If m_p5 >= 10 Then m_p5 = m_p5 - 9
                    m_p6 = m_d6 * 1
                    If m_p6 >= 10 Then m_p6 = m_p6 - 9
                    m_p7 = m_d7 * 2
                    If m_p7 >= 10 Then m_p7 = m_p7 - 9
                    m_p8 = m_d8 * 1
                    If m_p8 >= 10 Then m_p8 = m_p8 - 9
                    m_p9 = m_d9 * 2
                    If m_p9 >= 10 Then m_p9 = m_p9 - 9
                    m_modulo = 10
                Else
                    If m_d3 = 6 Then
                        m_pub = 1
                        m_p1 = m_d1 * 3
                        m_p2 = m_d2 * 2
                        m_p3 = m_d3 * 7
                        m_p4 = m_d4 * 6
                        m_p5 = m_d5 * 5
                        m_p6 = m_d6 * 4
                        m_p7 = m_d7 * 3
                        m_p8 = m_d8 * 2
                        m_p9 = 0
                    Else
                        m_pri = 1
                        m_p1 = m_d1 * 4
                        m_p2 = m_d2 * 3
                        m_p3 = m_d3 * 2
                        m_p4 = m_d4 * 7
                        m_p5 = m_d5 * 6
                        m_p6 = m_d6 * 5
                        m_p7 = m_d7 * 4
                        m_p8 = m_d8 * 3
                        m_p9 = m_d9 * 2
                    End If
                End If
                m_suma = m_p1 + m_p2 + m_p3 + m_p4 + m_p5 + m_p6 + m_p7 + m_p8 + m_p9
                m_residuo = m_suma Mod m_modulo
                If m_residuo = 0 Then
                    m_digito_verificador = 0
                Else
                    m_digito_verificador = m_modulo - m_residuo
                End If
                If m_pub = 1 Then
                    If m_digito_verificador <> m_d9 Then
                        lblCodTipoIdent0.Text = "ERROR: El ruc de la empresa del sector público es incorrecto"
                    Else
                        If Right(m_ruc, 4) <> "0001" Then
                            lblCodTipoIdent0.Text = "ERROR: El ruc de la empresa del sector público debe terminar con 0001"
                        End If
                    End If
                Else
                    If m_pri = 1 Then
                        If m_digito_verificador <> m_d10 Then
                            lblCodTipoIdent0.Text = "ERROR: El ruc de la empresa del sector privado es incorrecto"
                        Else
                            If Right(m_ruc, 3) <> "001" Then
                                lblCodTipoIdent0.Text = "ERROR: El ruc de la empresa del sector privado debe terminar con 001"
                            End If
                        End If
                    Else
                        If m_nat = 1 Then
                            If m_digito_verificador <> m_d10 Then
                                lblCodTipoIdent0.Text = "ERROR: El número de cédula de la persona natural es incorrecto"
                                lblcontrolced.Text = 0
                            Else
                                lblcontrolced.Text = 1
                                If m_largoruc > 10 And Right(m_ruc, 3) <> "001" Then
                                    lblCodTipoIdent0.Text = "ERROR: El ruc de la persona natural debe terminar con 001"
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                lblCodTipoIdent0.Text = "ERROR: el tercer digito es incorrecto..."
            End If
        Else
            lblCodTipoIdent0.Text = "ERROR: error en el codigo de provincia..."
        End If

    End Sub
    Sub vermax()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Try


            sel = "SELECT max (codigo_estud) as numest " &
                 "FROM DATOS_ESTUD  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datose = New DataSet
            datose.Clear()
            daUs.Fill(datose, "DATOS_ESTUD")
            lblnumestud.Text = datose.Tables(0).Rows(0).Item("numest").ToString + 1


        Catch ex As Exception

        End Try

    End Sub

    Sub verperiodo()
        Dim sel As String
        Dim daUs As SqlDataAdapter
        Try


            sel = "SELECT cod_periodo, Detalle_Periodo,NumMatricula " &
                 "FROM PERIODO WHERE ControlPlataforma='A'  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datose = New DataSet
            datose.Clear()
            daUs.Fill(datose, "PERIODO")
            lblperiodo.Text = datose.Tables(0).Rows(0).Item("Detalle_Periodo").ToString
            lblcodPeriodo.Text = datose.Tables(0).Rows(0).Item("cod_periodo").ToString
            lblcodperiodoacad.Text = datose.Tables(0).Rows(0).Item("cod_periodo").ToString
            lblnumMatricula.Text = datose.Tables(0).Rows(0).Item("NumMatricula").ToString
            lblnummat.Text = datose.Tables(0).Rows(0).Item("NumMatricula").ToString
        Catch ex As Exception

        End Try

    End Sub
    Sub VerDatos()
        Dim sel, f As String
        Dim daUs As SqlDataAdapter
        Dim i As Integer
        Dim da As Date
        Try

            sel = "SELECT *,CONVERT(nvarchar(30),Fecha_Nac, 121) as fn from DATOS_ESTUD  where Cedula_Est='" & txtcedula.Text.TrimEnd & "'  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datosInf = New DataSet
            datosInf.Clear()
            daUs.Fill(datosInf, "DATOS_ESTUD")
            i = datosInf.Tables(0).Rows.Count
            If i > 0 Then
                '  Txtapellidopat.Text = datosInf.Tables(0).Rows(0).Item("Apellido1").ToString().TrimEnd
                '  Txtapellidomat.Text = datosInf.Tables(0).Rows(0).Item("Apellido2").ToString().TrimEnd
                '  Txtnombres.Text = datosInf.Tables(0).Rows(0).Item("Nombres12").ToString().TrimEnd
                If datosInf.Tables(0).Rows(0).Item("Apellido1").ToString().TrimEnd.Length > 0 Then
                    Txtapellidopat.Text = datosInf.Tables(0).Rows(0).Item("Apellido1").ToString().TrimEnd
                    Txtapellidopat.Enabled = False
                Else
                    Txtapellidopat.Enabled = True
                End If

                If datosInf.Tables(0).Rows(0).Item("Apellido2").ToString().TrimEnd.Length > 0 Then
                    Txtapellidomat.Text = datosInf.Tables(0).Rows(0).Item("Apellido2").ToString().TrimEnd
                    Txtapellidomat.Enabled = False
                Else
                    Txtapellidomat.Enabled = True
                End If

                If datosInf.Tables(0).Rows(0).Item("Nombres12").ToString().TrimEnd.Length > 0 Then
                    Txtnombres.Text = datosInf.Tables(0).Rows(0).Item("Nombres12").ToString().TrimEnd
                    Txtnombres.Enabled = False
                Else
                    Txtnombres.Enabled = True
                End If

                txtemailCambridge.Text = datosInf.Tables(0).Rows(0).Item("correocamb").ToString().TrimEnd
                txtemail.Text = datosInf.Tables(0).Rows(0).Item("correo").ToString().TrimEnd

                txtdirecdomi.Text = datosInf.Tables(0).Rows(0).Item("calle_principal").ToString().TrimEnd

                txttelef.Text = datosInf.Tables(0).Rows(0).Item("telefono").ToString().TrimEnd
                TxtCelular.Text = datosInf.Tables(0).Rows(0).Item("movil").ToString().TrimEnd
                If datosInf.Tables(0).Rows(0).Item("fn").ToString().TrimEnd.Length > 0 Then
                    da = datosInf.Tables(0).Rows(0).Item("fn").ToString().TrimEnd
                    txtfechaNac.Text = da
                End If

                ' lblcodPeriodo.Text = datosInf.Tables(0).Rows(0).Item("Cod_Periodo").ToString()

                lblcodestud.Text = datosInf.Tables(0).Rows(0).Item("codigo_estud").ToString().TrimEnd
                lblcod_usu.Text = datosInf.Tables(0).Rows(0).Item("codigo_estud").ToString().TrimEnd
                lblcodjornada.Text = datosInf.Tables(0).Rows(0).Item("codjornada").ToString()
                lblCodCarrera.Text = datosInf.Tables(0).Rows(0).Item("Cod_carrera").ToString()

                CboPlataforma.SelectedValue = datosInf.Tables(0).Rows(0).Item("ControlPlataforma").ToString().TrimEnd

                lblmensajeactualizar.Text = "Actualice sus Datos"
                lblcontrol.Text = 1

            Else
                lblmensajeactualizar.Text = Nothing
                lblcontrol.Text = 0
            End If
        Catch ex As Exception
            lblcontrol.Text = 1
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

    Sub usuarios()
        Dim sel, l As String
        Dim MiDataset As New DataSet
        Try
            l = txtcedula.Text.Length - 4
            txtpas.Text = txtcedula.Text.Substring(l, 4).Trim
            sel = "INSERT INTO USUARIOS " &
                   "(Codigo_Usuario,cedula,login,password,tipo_usuario,fecha_ingreso) " &
                   "VALUES " &
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
    '   Call jornada()


    Protected Sub CboCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCarrera.SelectedIndexChanged
        Dim p As Integer = Me.CboCarrera.SelectedIndex
        Dim codest As String = CboCarrera.Items(p).Value
        lblnombCarrera.Text = CboCarrera.Items(p).Text
        lblCodCarrera.Text = codest


        Call jornada()


        Session.Add("cod_usu", lblcodestud.Text)
        Session.Add("cod_periodo", lblcodPeriodo.Text)
        Session.Add("cod_carrera", 3)
        Session.Add("grupo", 0)

    End Sub
    Protected Sub ImgImprimir_Click(sender As Object, e As ImageClickEventArgs) Handles ImgImprimir.Click
        If txtcedula.Text = Nothing Or (txtcedula.Text.Length < 10 Or txtcedula.Text.Length > 10) And CboTipoDoc.SelectedValue = 1 Then
            LBLmensajeestud.Text = "Ingrese el No. de Cédula"
            Exit Sub
        End If
        Session.Add("cedula", txtcedula.Text)
        Response.Redirect("ImprimirEstudianteWeb.aspx")
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        lblMesg.Text = ""
        Session.Clear()
        Call VerDatos()
        Call jornada()
        Call Carrera()
        Call vermatricula()
        Session.Add("cod_usu", lblcodestud.Text)
        Session.Add("cod_periodo", lblcodPeriodo.Text)
        Session.Add("cod_carrera", 3)
        Session.Add("grupo", 0)
        Session.Add("ciclo", lblnumMatricula.Text)

        Call malla()
        Call cargarasignaturas()
        Call cargarModalidad()

        Call EnlazarDatos()

    End Sub
    Sub malla()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Try


            sel = "SELECT        dbo.PENSUM.NumMalla, dbo.CARRERAXESTUD.codigo_estud " &
" FROM            dbo.PENSUM INNER JOIN " &
                       "  dbo.CARRERAXESTUD On dbo.PENSUM.codigo_materia = dbo.CARRERAXESTUD.codigo_materia And dbo.PENSUM.Cod_AnioBasica = dbo.CARRERAXESTUD.cod_anio_Basica INNER JOIN " &
                       "  dbo.PERIODO On dbo.CARRERAXESTUD.codigo_periodo = dbo.PERIODO.cod_periodo " &
" WHERE        (dbo.CARRERAXESTUD.cod_anio_Basica = 3) AND (dbo.CARRERAXESTUD.codigo_estud = " & lblcodestud.Text & ") "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PENSUM")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                lblmalla.Text = datos.Tables(0).Rows(0).Item("NumMalla").ToString()

            Else
                lblmalla.Text = 2
            End If

        Catch ex As Exception

        End Try


    End Sub
    Sub cargarasignaturas()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            lblmalla.Text = 0
            sel = "SELECT distinct Nomb_Materia,PENSUM.codigo_materia,Creditos " &
                    "FROM PENSUM  " &
                    "WHERE  Cod_AnioBasica=3 and NumMalla=" & lblmalla.Text & "    " &
                        "order by Nomb_Materia "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PENSUM")

            i = datos.Tables(0).Rows.Count

            If i > 0 Then
                CboAsignatura.Items.Clear()
                For c = 0 To i
                    'cbomodelo.Items.Clear()
                    If c = 0 Then
                        CboAsignatura.Items.Add("- Seleccione una asignatura -")
                        CboAsignatura.Items.Item(0).Value = "-1"

                    Else
                        v = datos.Tables(0).Rows(c - 1)
                        CboAsignatura.Items.Add(v(0))
                        CboAsignatura.Items.Item(c - 1).Value = v(1)
                    End If
                Next c
            End If




            cntDB.Close()
            UpdatePCabecera.Update()
        Catch ex As Exception
            LabelErrorcab.Text = "Error: " & ex.Message

        End Try


    End Sub
    Sub vermatricula()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer


        Try



            sel = "SELECT        dbo.CARRERAXESTUD.paralelo, dbo.CARRERAXESTUD.codigo_periodo, dbo.CARRERAS.Nombre_Basica, dbo.CARRERAXESTUD.codigo_estud, dbo.DATOS_ESTUD.Apellidos_nombre,  " &
                         "dbo.CARRERAXESTUD.codigo_materia, dbo.CARRERAXESTUD.Num_Matricula, dbo.PENSUM.Nomb_Materia, dbo.PENSUM.Semestre, dbo.CARRERAXESTUD.num, dbo.CARRERAXESTUD.Num_Folio,  dbo.CARRERAXESTUD.Num_Reg_Mat, dbo.CARRERAXESTUD.NumGrupo, dbo.PERIODO.Detalle_Periodo " &
                        "FROM            dbo.CARRERAS INNER JOIN " &
                        " dbo.PENSUM INNER JOIN " &
                        " dbo.DATOS_ESTUD INNER JOIN " &
                        " dbo.CARRERAXESTUD ON dbo.DATOS_ESTUD.codigo_estud = dbo.CARRERAXESTUD.codigo_estud ON dbo.PENSUM.codigo_materia = dbo.CARRERAXESTUD.codigo_materia AND  " &
                       "  dbo.PENSUM.Cod_AnioBasica = dbo.CARRERAXESTUD.cod_anio_Basica ON dbo.CARRERAS.Cod_AnioBasica = dbo.CARRERAXESTUD.cod_anio_Basica INNER JOIN " &
                        " dbo.PERIODO ON dbo.CARRERAXESTUD.codigo_periodo = dbo.PERIODO.cod_periodo " &
             "WHERE  NumRegistro=" & lblnumMatricula.Text & "  and CARRERAXESTUD.codigo_periodo=" & lblcodPeriodo.Text & " and  (CARRERAXESTUD.codigo_estud = " & lblcodestud.Text & ") and CARRERAXESTUD.cod_anio_Basica=" & 3 & " and Num_Matricula<>10   "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then

                Panel1.Visible = False
                '  AsyncFileUpload1.Visible = False
                lblmensajeactualizar.Text = "Ya existe la matricula, proceda a imprimir"
                lblMesg.Text = "Ya existe la matricula, proceda a imprimir"
                lblcn.Text = 1
                lblmensajeactualizar.Visible = True
            Else
                lblcn.Text = 0

                Panel1.Visible = True
                '  AsyncFileUpload1.Visible = True
                lblmensajeactualizar.Text = ""
                lblmensajeactualizar.Visible = False
            End If


            UpdatePCabecera.Update()

        Catch ex As Exception

            Panel1.Visible = True
            '  AsyncFileUpload1.Visible = True
            lblmensajeactualizar.Text = ""
            lblmensajeactualizar.Visible = False
        End Try
    End Sub

    Protected Sub cbojornada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbojornada.SelectedIndexChanged
        Dim p As Integer = cbojornada.SelectedIndex
        Dim codasign As String = cbojornada.Items(p - 1).Value
        lblcodjornada.Text = codasign
        lbljornada.Text = cbojornada.Items(p).Text.TrimEnd

    End Sub

    Sub verPrerequisitoAprobado()
        Dim daUs As SqlDataAdapter
        Dim sel, seli, pr As String
        Dim ds As New DataSet
        Dim i, codm As Integer
        Try

            lblcontrolaprueba.Text = ""

            ' ver si tiene aprobado
            lblcaprueba.Text = 0

            seli = "SELECT  CASE WHEN (((dbo.PERIODO.p1 / 100 * dbo.CARRERAXESTUD.Nota1) + (dbo.PERIODO.p2 / 100 * dbo.CARRERAXESTUD.Nota2) +  " &
" (dbo.PERIODO.p3 / 100 * dbo.CARRERAXESTUD.Nota3) ))>= 7 And Asistencia>=70 Then 'Aprueba' ELSE 'Reprueba' END AS condicion from dbo.CARRERAXESTUD INNER JOIN   dbo.PERIODO ON dbo.CARRERAXESTUD.codigo_periodo = dbo.PERIODO.cod_periodo " &
                    "WHERE Num_Matricula<>10 and codigo_materia=" & lblcodasign.Text & " and  codigo_estud=" & lblcod_usu.Text & "  "
            daUs = New SqlDataAdapter(seli, cntDB)
            datosi = New DataSet
            datosi.Clear()
            daUs.Fill(datosi, "CARRERAXESTUD")
            i = datosi.Tables(0).Rows.Count
            If i > 0 Then
                lblcontrolaprueba.Text = datosi.Tables(0).Rows(0).Item("condicion").ToString().TrimEnd
                If lblcontrolaprueba.Text = "Aprueba" Then
                    lbdetalletipmatri.Text = "Este nivel de inglés tiene aprobado"
                    lblcaprueba.Text = 1
                Else

                    sel = "SELECT  CASE WHEN ((NOTA3))>= 7  THEN 'Aprueba' ELSE 'Reprueba' END AS condicion from CARRERAXESTUD " &
                   "WHERE Num_Matricula=10 and codigo_materia=" & lblcodasign.Text & " and  codigo_estud=" & lblcod_usu.Text & "  "
                    daUs = New SqlDataAdapter(sel, cntDB)
                    datos = New DataSet
                    datos.Clear()
                    daUs.Fill(datos, "CARRERAXESTUD")
                    i = datos.Tables(0).Rows.Count
                    If i > 0 Then
                        lblcontrolaprueba.Text = datos.Tables(0).Rows(0).Item("condicion").ToString().TrimEnd
                        If lblcontrolaprueba.Text = "Aprueba" Then
                            lbdetalletipmatri.Text = "Este nivel de inglés tiene aprobado"
                            lblcaprueba.Text = 1
                        End If

                    End If
                End If
            End If




            sel = "SELECT  Prerequisito,Semestre from pensum " &
                 "WHERE Cod_AnioBasica=" & 3 & " and codigo_materia=" & lblcodasign.Text & "  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PENSUM")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                pr = datos.Tables(0).Rows(0).Item("Prerequisito").ToString()
                lblcsemestre.Text = datos.Tables(0).Rows(0).Item("Semestre").ToString()
            Else
                pr = 0
            End If


            sel = "SELECT  codigo_materia from pensum " &
                    "WHERE cod_materia='" & pr & "'  and NumMalla=0  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "PENSUM")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                codm = datos.Tables(0).Rows(0).Item("codigo_materia").ToString()

            Else
                codm = 0
            End If



            sel = " SELECT        dbo.PENSUM.Cod_AnioBasica, dbo.PERIODO.p1 / 100 * dbo.CARRERAXESTUD.Nota1 AS n1, dbo.PERIODO.p2 / 100 * dbo.CARRERAXESTUD.Nota2 AS n2, dbo.PERIODO.p3 / 100 * dbo.CARRERAXESTUD.Nota3 AS n3, " &
" dbo.PERIODO.Detalle_Periodo, dbo.PENSUM.Nomb_Materia, CASE WHEN ((dbo.PERIODO.p1 / 100 * dbo.CARRERAXESTUD.Nota1) + (dbo.PERIODO.p2 / 100 * dbo.CARRERAXESTUD.Nota2)  " &
"  + (dbo.PERIODO.p3 / 100 * dbo.CARRERAXESTUD.Nota3)) >= 7 AND Asistencia >= 70 THEN 'Aprueba' ELSE 'Reprueba' END AS condicion, CASE WHEN (NOTA3) >= 7 THEN 'Aprueba' ELSE '' END AS condicionv,  " &
"   dbo.CARRERAXESTUD.Asistencia, dbo.PENSUM.NumMalla, dbo.CARRERAXESTUD.codigo_estud " &
" FROM            dbo.CARRERAXESTUD INNER JOIN " &
" dbo.PENSUM ON dbo.CARRERAXESTUD.codigo_materia = dbo.PENSUM.codigo_materia AND dbo.CARRERAXESTUD.cod_anio_Basica = dbo.PENSUM.Cod_AnioBasica INNER JOIN " &
"   dbo.PERIODO ON dbo.CARRERAXESTUD.codigo_periodo = dbo.PERIODO.cod_periodo " &
" WHERE  (((dbo.PERIODO.p1 / 100 * dbo.CARRERAXESTUD.Nota1) + (dbo.PERIODO.p2 / 100 * dbo.CARRERAXESTUD.Nota2)  " &
"  + (dbo.PERIODO.p3 / 100 * dbo.CARRERAXESTUD.Nota3)) >= 7)   and  Num_Matricula<>10 and     (dbo.PENSUM.Cod_AnioBasica = 3) AND (dbo.PENSUM.NumMalla = 0) AND (dbo.CARRERAXESTUD.codigo_estud = " & lblcod_usu.Text & ") and CARRERAXESTUD.codigo_materia=" & codm & " "


            ' "WHERE ((NOTA1*0.30) + (NOTA2*0.30) + (NOTA3*0.40))>= 7 and Num_Matricula<>10 and  codigo_materia=" & codm & " and  codigo_estud=" & lblcod_usu.Text & "   "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                lblcontrolaprueba.Text = datos.Tables(0).Rows(0).Item("condicion").ToString().TrimEnd
            Else
                sel = "SELECT  CASE WHEN ( (NOTA3))>= 7  THEN 'Aprueba' ELSE 'Reprueba' END AS condicion from CARRERAXESTUD " &
                    "WHERE  Num_Matricula=10 and  codigo_materia=" & codm & " and  codigo_estud=" & lblcod_usu.Text & "  "
                daUs = New SqlDataAdapter(sel, cntDB)
                datos = New DataSet
                datos.Clear()
                daUs.Fill(datos, "CARRERAXESTUD")
                i = datos.Tables(0).Rows.Count
                If i > 0 Then
                    lblcontrolaprueba.Text = datos.Tables(0).Rows(0).Item("condicion").ToString().TrimEnd
                Else

                    lblcontrolaprueba.Text = "R"
                    lbdetalletipmatri.Text = "No tiene la asignatura de prerequisito aprobado"
                End If

            End If


            If lblnivel.Text = 1 And lblcaprueba.Text = 0 Then
                lblcontrolaprueba.Text = "Aprueba"
                lbdetalletipmatri.Text = ""
            End If
            UpdatePanel6.Update()

        Catch ex As Exception
            Dim er As String = ex.Message
        End Try

    End Sub
    Private Sub EnlazarDatos()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer


        Try

            sel = " SELECT        dbo.PENSUM.Cod_AnioBasica, dbo.PERIODO.p1 / 100 * dbo.CARRERAXESTUD.Nota1 AS n1, dbo.PERIODO.p2 / 100 * dbo.CARRERAXESTUD.Nota2 AS n2, dbo.PERIODO.p3 / 100 * dbo.CARRERAXESTUD.Nota3 AS n3, " &
" dbo.PERIODO.Detalle_Periodo, dbo.PENSUM.Nomb_Materia, CASE WHEN ((dbo.PERIODO.p1 / 100 * dbo.CARRERAXESTUD.Nota1) + (dbo.PERIODO.p2 / 100 * dbo.CARRERAXESTUD.Nota2)  " &
"  + (dbo.PERIODO.p3 / 100 * dbo.CARRERAXESTUD.Nota3)) >= 7 AND Asistencia >= 70 THEN 'Aprueba' ELSE 'Reprueba' END AS condicion, CASE WHEN (NOTA3) >= 7 THEN 'Aprueba' ELSE '' END AS condicionv,  " &
"   dbo.CARRERAXESTUD.Asistencia, dbo.PENSUM.NumMalla, dbo.CARRERAXESTUD.codigo_estud " &
" FROM            dbo.CARRERAXESTUD INNER JOIN " &
" dbo.PENSUM ON dbo.CARRERAXESTUD.codigo_materia = dbo.PENSUM.codigo_materia AND dbo.CARRERAXESTUD.cod_anio_Basica = dbo.PENSUM.Cod_AnioBasica INNER JOIN " &
"   dbo.PERIODO ON dbo.CARRERAXESTUD.codigo_periodo = dbo.PERIODO.cod_periodo " &
" WHERE        (dbo.PENSUM.Cod_AnioBasica = 3) AND (dbo.PENSUM.NumMalla = 0) AND (dbo.CARRERAXESTUD.codigo_estud = " & lblcod_usu.Text & ") "



            '"WHERE  (dbo.CARRERAXESTUD.codigo_estud = " & lblcod_usu.Text & ") And (dbo.CARRERAXESTUD.cod_anio_Basica = " & 3 & " ) "


            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "CARRERAXESTUD")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                GridView1.Visible = True
                GridView1.DataSource = datos
                GridView1.DataBind()


            Else
                GridView1.Visible = False
            End If

            UpdatePanel6.Update()


        Catch ex As Exception
            lblmensaje.Text = "Seleccione el periodo académico"
        End Try
    End Sub

    Protected Sub cdmverasignaturaCarr0_Click(sender As Object, e As EventArgs) Handles CmdMatricularEstud.Click
        Dim sel, tm, seln As String
        Dim valor As Double
        Try

            lblnumreg.Text = lblnummat.Text
            lbdetalletipmatri.Text = Nothing


            lblerrorGrid.Text = ""

            If lblced.Text = Nothing Then
                lblMesg.Text = "Debe cargar el archivo para poder matricularse"
                UpdatePCabecera.Update()
                Exit Sub
            End If

            Call grabardatos()
            Call verPrerequisitoAprobado()
            '  Call nummaxregisro()

            If lblcontrolaprueba.Text = "Aprueba" And lblcaprueba.Text = 0 Then

                sel = "INSERT INTO CABECERA_MATRICULA " &
                          "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica, codigo_materia, codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,codhorario, codmodalidad, coddias,codjornada,urldocumento,NumRegistro,numpagos ) " &
                          "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_materia,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@codhorario, @codmodalidad, @coddias, @codjornada,@urldocumento,@NumRegistro,@numpagos ) "
                Dim cmde As New SqlCommand(sel, cntDB)

                cmde.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
                cmde.Parameters.AddWithValue("cod_anio_Basica", CType(3, Integer))
                cmde.Parameters.AddWithValue("codigo_materia", CType(0, Integer))
                cmde.Parameters.AddWithValue("codigo_periodo", CType(lblcodperiodoacad.Text, Integer))

                cmde.Parameters.AddWithValue("fecha_pago", CType(Date.Now, Date))
                cmde.Parameters.AddWithValue("valor", CType(0, Double))

                cmde.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))

                cmde.Parameters.AddWithValue("InscripValor", CType(0, Double))

                cmde.Parameters.AddWithValue("MatriValor", CType(lblvalorpago.Text, Double))


                cmde.Parameters.AddWithValue("Cuota1", CType(lblvalorpago.Text, Double))
                'AyudaEcono
                cmde.Parameters.AddWithValue("AyudaEcono", CType(0, Double))
                cmde.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))
                cmde.Parameters.AddWithValue("codjornada", CType(lblcodjornada.Text, Integer))

                cmde.Parameters.AddWithValue("RecargoMatricula", CType(0, Double))
                cmde.Parameters.AddWithValue("Beca", CType(0, Double))
                cmde.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
                cmde.Parameters.AddWithValue("ValorNivelacion", CType(0, Double))

                cmde.Parameters.AddWithValue("codhorario", CType(1, Integer))
                cmde.Parameters.AddWithValue("codmodalidad", CType(lblcodModalidad.Text, Integer))
                cmde.Parameters.AddWithValue("coddias", CType(lblcoddias.Text, Integer))

                cmde.Parameters.AddWithValue("urldocumento", CType(lblced.Text, String))

                cmde.Parameters.AddWithValue("NumRegistro", CType(lblnumreg.Text, Integer))

                cmde.Parameters.AddWithValue("numpagos", CType(lblnumpago.Text, Integer))

                Try
                    cntDB.Open()
                    Dim te As Integer = CInt(cmde.ExecuteScalar())
                    cntDB.Close()
                Catch ex As Exception
                    cntDB.Close()
                End Try





                sel = "INSERT INTO CARRERAXESTUD " &
                          "(codigo_estud,cod_anio_Basica,codigo_materia,Num_Matricula,codigo_periodo,usuario,Num_Creditos,Fecha_Matricula,controlperiodo,paralelo,TipoMatricula,ControlMatricula,NumRegistro) " &
                          "VALUES " &
                          "(@codigo_estud,@cod_anio_Basica,@codigo_materia,@Num_Matricula,@codigo_periodo,@usuario,@Num_Creditos,@Fecha_Matricula,@controlperiodo,@paralelo,@TipoMatricula,@ControlMatricula,@NumRegistro) "
                Dim cmd As New SqlCommand(sel, cntDB)

                cmd.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
                cmd.Parameters.AddWithValue("cod_anio_Basica", CType(3, String))
                cmd.Parameters.AddWithValue("codigo_materia", CType(lblcodasign.Text, String))
                cmd.Parameters.AddWithValue("Num_Matricula", CType(lblnummat.Text, Integer))
                cmd.Parameters.AddWithValue("codigo_periodo", CType(lblcodperiodoacad.Text, Integer))
                cmd.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))
                cmd.Parameters.AddWithValue("Num_Creditos", CType(LblNumCreditos.Text, Integer))
                cmd.Parameters.AddWithValue("paralelo", CType("A", String))
                cmd.Parameters.AddWithValue("TipoMatricula", CType("N", String))
                cmd.Parameters.AddWithValue("Fecha_Matricula", CType(Date.Now, Date))
                cmd.Parameters.AddWithValue("NumRegistro", CType(lblnumreg.Text, Integer))
                ' cmd.Parameters.AddWithValue("Num", CType(lblnumreg.Text, Integer))
                cmd.Parameters.AddWithValue("controlperiodo", CType(1, Integer))
                cmd.Parameters.AddWithValue("ControlMatricula", CType(1, Integer))


                Try
                    cntDB.Open()
                    Dim t As Integer = CInt(cmd.ExecuteScalar())
                    cntDB.Close()
                Catch ex As Exception
                    cntDB.Close()
                    Exit Sub
                End Try







                'VARIAS MATRICULAS
                seln = "INSERT INTO CABECERA_MATRICULA_VARIOS " &
                          "(Beca,RecargoMatricula,codigo_estud, cod_anio_Basica,  codigo_periodo,  fecha_pago, valor, InscripValor, MatriValor, Cuota1, jornada,AyudaEcono,ControlMatricula,ValorNivelacion,NUMGRUPO ) " &
                          "VALUES  (@Beca,@RecargoMatricula,@codigo_estud, @cod_anio_Basica,@codigo_periodo,  @fecha_pago, @valor, @InscripValor, @MatriValor, @Cuota1, @jornada,@AyudaEcono,@ControlMatricula,@ValorNivelacion,@numgrupo ) "
                Dim cmden As New SqlCommand(seln, cntDB)

                cmden.Parameters.AddWithValue("codigo_estud", CType(lblcod_usu.Text, Integer))
                cmden.Parameters.AddWithValue("cod_anio_Basica", CType(3, Integer))
                cmden.Parameters.AddWithValue("codigo_periodo", CType(lblcodperiodoacad.Text, Integer))

                cmden.Parameters.AddWithValue("fecha_pago", CType(Date.Now, Date))
                cmden.Parameters.AddWithValue("valor", CType(lblvalorpago.Text, Double))

                cmden.Parameters.AddWithValue("usuario", CType(lblusuario.Text, String))

                cmden.Parameters.AddWithValue("InscripValor", CType(0, Double))

                cmden.Parameters.AddWithValue("MatriValor", CType(0, Double))

                cmden.Parameters.AddWithValue("Cuota1", CType(0, Double))
                'AyudaEcono
                cmden.Parameters.AddWithValue("AyudaEcono", CType(0, Double))
                cmden.Parameters.AddWithValue("jornada", CType(lbljornada.Text, String))

                cmden.Parameters.AddWithValue("RecargoMatricula", CType(0, Double))
                cmden.Parameters.AddWithValue("Beca", CType(0, Double))
                cmden.Parameters.AddWithValue("ControlMatricula", CType(lbltipoMatricula.Text, Integer))
                cmden.Parameters.AddWithValue("ValorNivelacion", CType(0, Double))
                cmden.Parameters.AddWithValue("numgrupo", CType(0, Integer))

                Try
                    cntDB.Open()
                    Dim ten As Integer = CInt(cmden.ExecuteScalar())
                    cntDB.Close()
                Catch ex As Exception
                    Dim ra As String = ex.Message
                    cntDB.Close()
                End Try


                Call EnlazarDatos()

                lblmensaje.Text = "** Ingresado **"

                lbdetalletipmatri.Text = "** Se encuentra matriculado **"

            End If

            UpdatePCabecera.Update()
            UpdatePanel6.Update()
        Catch ex As Exception
            lblmensaje.Text = ex.Message
            Call EnlazarDatos()
        End Try


        Session.Add("cod_usu", lblcod_usu.Text)
        Session.Add("cod_periodo", lblcodperiodoacad.Text)
        Session.Add("cod_carrera", 3)
        Session.Add("grupo", 0)

        '    LinkVerMaricula.Visible = True
    End Sub
    Protected Sub CboAsignatura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAsignatura.SelectedIndexChanged
        Try


            Dim p As Integer = CboAsignatura.SelectedIndex
            Dim codasign As String = CboAsignatura.Items(p - 1).Value
            lblcodasign.Text = codasign
            Call vercredvalor()


            If Chk1.Checked = True Then
                lblvalorpago.Text = 110
                lblnumpago.Text = 1
            End If

            If Chk2.Checked = True Then
                lblvalorpago.Text = 55
                lblnumpago.Text = 2
            End If

            lblced.Text = Session("ceda").ToString()

            lblmensaje.Text = Nothing
            UpdatePCabecera.Update()

        Catch ex As Exception

        End Try
    End Sub

    Sub vercredvalor()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        sel = "Select  Creditos,Semestre from pensum " &
                     "WHERE Cod_AnioBasica=3 And codigo_materia=" & lblcodasign.Text & "  "
        daUs = New SqlDataAdapter(sel, cntDB)
        datos = New DataSet
        datos.Clear()
        daUs.Fill(datos, "PENSUM")
        i = datos.Tables(0).Rows.Count
        If i > 0 Then
            LblNumCreditos.Text = datos.Tables(0).Rows(0).Item(0).ToString()
            lblnivel.Text = datos.Tables(0).Rows(0).Item("Semestre").ToString()
        Else
            LblNumCreditos.Text = 0
            lblnivel.Text = 0
        End If
    End Sub


    Protected Sub Cbomodalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbomodalidad.SelectedIndexChanged
        Try
            Dim p As Integer = Cbomodalidad.SelectedIndex
            Dim pa As String = Cbomodalidad.Items(p).Value
            lblcodModalidad.Text = pa

            Call cargarDias()
            UpdatePCabecera.Update()
        Catch ex As Exception
            lblcodModalidad.Text = 1
        End Try
    End Sub

    Sub cargarDias()

        Dim daUs As SqlDataAdapter
        Dim sel, self As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            Call numero()
            sel = "Select Detalledias,numd " &
                    "FROM DiasMatricula where  TipoMatricula='I' and  cod_periodo=" & lblcodperiodoacad.Text & " and num=" & lblnum.Text & "   and Cod_modalidad=" & lblcodModalidad.Text & " and nivel=" & lblnivel.Text & " " &
                    "order by Detalledias "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DiasMatricula")
            i = datos.Tables(0).Rows.Count
            CboDias.Items.Clear()
            If i > 0 Then
                CboDias.DataSource = datos
                CboDias.DataTextField = "Detalledias"
                CboDias.DataValueField = "numd"
                CboDias.DataBind()

                'Add Default Item in the DropDownList
                CboDias.Items.Insert(0, New ListItem("Seleccione"))

                ' CboDias.Items.FindByValue(lblcodmodalidad.Text).Selected = True
            End If


            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: " & ex.Message

        End Try


    End Sub

    Protected Sub CboDias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboDias.SelectedIndexChanged
        Try
            Dim p As Integer = CboDias.SelectedIndex
            Dim pa As String = CboDias.Items(p).Value
            lblcoddias.Text = pa

            Call cargarJornada()
            UpdatePCabecera.Update()

        Catch ex As Exception
            lblcoddias.Text = 1
        End Try

    End Sub


    Sub cargarJornada()

        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Dim v As DataRow

        Try
            sel = "SELECT Id_Jornada, DetalleJornada " &
                    "FROM JORNADA where ControlIngles='I' " &
                    "order by DetalleJornada "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "JORNADA")
            i = datos.Tables(0).Rows.Count
            CboJornada0.Items.Clear()
            If i > 0 Then
                CboJornada0.DataSource = datos
                CboJornada0.DataTextField = "DetalleJornada"
                CboJornada0.DataValueField = "Id_Jornada"
                CboJornada0.DataBind()

                'Add Default Item in the DropDownList
                CboJornada0.Items.Insert(0, New ListItem("Seleccione"))

            End If

            cntDB.Close()

        Catch ex As Exception
            LabelErrorcab.Text = "ERROR: JORNADA" & ex.Message

        End Try


    End Sub


    Protected Sub CboJornada0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboJornada0.SelectedIndexChanged
        Dim p As Integer = CboJornada0.SelectedIndex
        Dim codasign As String = CboJornada0.Items(p).Value
        lblcodjornada0.Text = codasign
        lbljornada0.Text = CboJornada0.Items(p).Text
        UpdatePCabecera.Update()
    End Sub


    Sub numero()
        Dim daUs As SqlDataAdapter
        Dim sel As String
        Dim ds As New DataSet
        Dim i As Integer
        Try


            sel = "SELECT  max(Num) as nu from DiasMatricula " &
                     "WHERE cod_periodo=" & lblcodperiodoacad.Text & "  "
            daUs = New SqlDataAdapter(sel, cntDB)
            datos = New DataSet
            datos.Clear()
            daUs.Fill(datos, "DiasMatricula")
            i = datos.Tables(0).Rows.Count
            If i > 0 Then
                lblnum.Text = datos.Tables(0).Rows(0).Item("nu").ToString()
            Else

                lblnum.Text = 1
            End If
        Catch ex As Exception
            lblnum.Text = 1

        End Try
    End Sub



End Class