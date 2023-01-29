Imports System.Data.SqlClient
Imports System.Data
Partial Class Cabecera
    Inherits System.Web.UI.Page
    Dim perfil As Integer
    Dim cod As String
    Private datos As DataSet
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Clear()
            Session.Abandon()
            lblfecha.Text = Date.Now
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'carga nuevamente página web
        Session.Clear()
        Session.Abandon()

        Response.Write("<script language=javascript> parent.frames['leftFrame'].location = 'Izquierda.aspx';</script>")
        Response.Write("<script language=javascript> parent.frames['mainFrame'].location = 'defaults.aspx';</script>")
        Response.Write("<script language=javascript> parent.frames['topFrame1'].location = 'cabeceras.aspx';</script>")

    End Sub


    Protected Sub Cmdaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmdaceptar.Click
        Try


            Dim str, login, coduser As String
            Dim i As Integer
            Dim Tabla As New DataTable
            Dim MiDataset As New DataSet


            If UserName.Text = Nothing Or Password.Text = Nothing Then
                'MsgBox1.ShowMessage("Ingrese correctamente los datos de usuario y/o password")
                LabelError.Text = "Ingrese los datos de usuario y/o password"
                Exit Sub
            End If

            str = "SELECT nombres,login,id_usuarios " &
              "FROM  USUARIO_sis where login='" & UserName.Text & "' and password='" & Password.Text & "' "
            Dim Adaptadordoc As New SqlDataAdapter(str, cntDB)
            MiDataset = New DataSet
            MiDataset.Clear()
            'enlazando al dataset con el adapter correspondiente.
            Adaptadordoc.Fill(MiDataset, "USUARIOS")

            i = MiDataset.Tables(0).Rows.Count
            If i > 0 Then
                login = MiDataset.Tables(0).Rows(0).Item("login").ToString().Replace(" ", "")
                coduser = MiDataset.Tables(0).Rows(0).Item("id_usuarios").ToString().Replace(" ", "")


                lblbienvenido.Text = MiDataset.Tables(0).Rows(0).Item(0).ToString()
                LabelError.Visible = True

                PanBienvenida.Visible = True
                Panel1.Visible = False
                'asigna cedula y tipo de usuario
                Session.Add("user", coduser)
                Session.Add("tusu", 1)
                LabelError.Text = Nothing

                Response.Write("<script language=javascript> parent.frames['mainFrame'].location = 'Informacion.aspx';</script>")
                Response.Write("<script language=javascript> parent.frames['leftFrame'].location = 'Izquierda.aspx';</script>")
            Else
                LabelError.Text = "Ingrese los datos de usuario y/o password"
            End If
            HyperLink1.Visible = True



        Catch ex As Exception
            LabelError.Text = "Ingrese los datos de usuario y/o password"
        End Try
    End Sub

End Class
