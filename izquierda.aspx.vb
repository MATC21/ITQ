Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class izquierda
    Inherits System.Web.UI.Page
    Dim tipo_usu, control_usu As Integer
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConAulaVirtual").ConnectionString
    Dim cntDB As New SqlConnection(ConnectionString)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Not IsPostBack Then
                tipo_usu = Session("tusu").ToString()
                control_usu = Session("cusu").ToString()

                If control_usu = 3 Then
                    crearmenu()
                    Lbltitmenu.Visible = True
                    TreeViewMenu.Visible = True

                    '1 estudiantes
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TreeViewMenu.SelectedNodeChanged
        Dim t, url, str As String
        Dim MiDataset As New DataSet
        Dim i, c As Integer
        Try

            t = TreeViewMenu.SelectedNode.Text
            url = TreeViewMenu.SelectedNode.Value.TrimEnd
            '  url = url.Trim.Replace(" ", "")

            str = "SELECT ReporteCry " & _
              "FROM  MENU_USUARIOS " & _
        "WHERE url = '" & url & "' "

            Dim Adaptador1 As New SqlDataAdapter(str, cntDB)
            MiDataset = New DataSet

            Adaptador1.Fill(MiDataset, "MENU_USUARIOS")

            'cmAuthors.Fill(ds, "Authors")
            i = MiDataset.Tables(0).Rows.Count
            If i > 0 Then
                c = MiDataset.Tables(0).Rows(0).Item(0).ToString()
                If c = 0 Then
                    Response.Write("<script language=javascript> parent.frames['mainFrame'].location = '" & url & "';</script>")
                ElseIf c = 1 Then
                    ' Define the name and type of the client scripts on the page. 
                    Dim csname1 As [String] = "PopupScript"
                    Dim cstype As Type = Me.[GetType]()

                    ' Get a ClientScriptManager reference from the Page class. 
                    Dim cs As ClientScriptManager = Page.ClientScript

                    ' Check to see if the startup script is already registered. 
                    If Not cs.IsStartupScriptRegistered(cstype, csname1) Then
                        Dim sb As New StringBuilder()
                        sb.Append("<script type = 'text/javascript'>")
                        sb.Append("window.open('")
                        sb.Append(url)
                        sb.Append("');")
                        sb.Append("</script>")

                        cs.RegisterStartupScript(cstype, csname1, sb.ToString())
                    End If

                End If

            End If



            '   

            Dim urlt As String = "menus.aspx?menu=" & t
            Dim frameScript As String = "<script language='JavaScript'>" & _
          "window.parent.topFrame1.location='" & urlt & "' ;</script>"
            Page.RegisterStartupScript("FrameScript", frameScript)

        Catch ex As Exception

        End Try
    End Sub

    Sub crearmenu()
        Dim str As String
        Dim MiDataset As New DataSet
        Dim i As Integer
        Dim grupo, gruposig As String

        Dim GrupoNode As New TreeNode

        str = "SELECT Grupo,Opcion,url " & _
               "FROM  MENU_USUARIOS " & _
         "WHERE id_usuarios = " & tipo_usu & " order by idGrupo,idOpcion"

        Dim Adaptador1 As New SqlDataAdapter(str, cntDB)
        MiDataset = New DataSet

        Adaptador1.Fill(MiDataset, "MENU_USUARIOS")

        'cmAuthors.Fill(ds, "Authors")
        i = MiDataset.Tables(0).Rows.Count
        Try
            gruposig = 0
            For k = 0 To i - 1
                'Dim Menu As New MenuItem
                'Menu.Text = rowAuthor("detalle_menu")
                'Menu.NavigateUrl = "~/" & rowAuthor("url")
                'Menu.Target = "inferiorframe"
                'Menu.SeparatorImageUrl = "~/images/imenus.png"

                grupo = MiDataset.Tables(0).Rows(k).Item(0).ToString()

                If k > 0 Then
                    gruposig = MiDataset.Tables(0).Rows(k - 1).Item(0).ToString()
                End If

                If grupo <> gruposig Then
                    GrupoNode = New TreeNode(grupo)
                    TreeViewMenu.Nodes.Add(GrupoNode)
                End If

                Dim node As New TreeNode()
                node.Text = MiDataset.Tables(0).Rows(k).Item(1).ToString()
                node.Value = MiDataset.Tables(0).Rows(k).Item(2).ToString()
                'node.ImageUrl = "~/images/imenus.png"
                GrupoNode.ChildNodes.Add(node)


            Next k
        Catch ex As Exception

        End Try
    End Sub

  
End Class
