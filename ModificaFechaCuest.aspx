<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificaFechaCuest.aspx.vb" Inherits="ModificaFechaCuest" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

        .style8
        {
            width: 99%;
            height: 62px;
            background-color: #ffffff;
        }
        .style25
        {
            width: 190px;
            height: 22px;
            font-size: small;
            font-family: Verdana;
            color: #800000;
        }
        .style28
        {
            width: 58px;
        }
        .style31
        {
            width: 100%;
            background-color: #ffffff;
        }
        .style32
        {
            height: 23px;
        }
        .style33
        {
            height: 23px;
        }
        .style34
        {
            width: 74px;
        }
        .style35
        {
        }
        .style36
        {
            width: 209px;
        }
        .style37
        {
            width: 74px;
            height: 29px;
        }
        .style38
        {
            width: 468px;
            height: 29px;
        }
        .style39
        {
            width: 209px;
            height: 29px;
        }
        .style40
        {
            width: 74px;
            height: 24px;
        }
        .style41
        {
            width: 468px;
            height: 24px;
        }
        .style42
        {
            width: 209px;
            height: 24px;
        }
        .style44
        {
            font-family: Verdana;
            font-size: small;
            border-left-color: #A0A0A0;
            border-right-color: #C0C0C0;
            border-top-color: #A0A0A0;
            border-bottom-color: #C0C0C0;
        }
        .style46
        {
            width: 236px;
        }
        .style47
        {
            height: 27px;
        }
        </style>
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style8" width="80%">
            <tr>
                <td class="style32">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style33">
                    <asp:Label ID="Label9" runat="server" 
                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                        Text="MODIFICAR LA FECHA FINAL DEL CUESTIONARIO" Width="675px"></asp:Label>
                </td>
                <td class="style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <table bgcolor="#CCCCCC" class="style8">
                                <tr>
                                    <td class="style37">
                                        <asp:Label ID="Label2" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Periodo:" Width="110px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="CboPeriodo" runat="server" AutoPostBack="True" 
                                            Font-Size="12pt" Height="21px" 
                                            style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                            Width="203px">
                                        </asp:DropDownList>
                                        &nbsp;<br />
                                        </td>
                                    <td class="style39">
                                        <asp:Label ID="lblCodPeriodo" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td class="style28">
                    &nbsp;</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="Label23" runat="server" 
                                style="font-size: small; font-weight: 400; font-family: Verdana;" 
                                Text="LISTA DE LOS ITEMS POR UNIDAD:" Width="302px"></asp:Label>
                            <asp:Label ID="LBLUNIDADLISTA" runat="server" 
                                style="font-size: small; font-family: Verdana"></asp:Label>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="197px" 
                                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                Width="795px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Unidad">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Bind("Cod_Unidad") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Curso">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrden" runat="server" Text='<%# Bind("Nomb_Materia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle de los Items">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDetalle" runat="server" 
                                                Text='<%# Bind("Detalle_Cuest_Foro") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Inicial">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtInicioSave" runat="server" Height="17px" Text='<%# Bind("Fecha_inicio") %>' Width="141px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LblFechaI" runat="server" Text='<%# Bind("fecha_inicio")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha final">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtffinalSave" runat="server" Height="17px" Text='<%# Bind("Fecha_final") %>' Width="141px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LblFechaF" runat="server" Text='<%# Bind("fecha_final") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cod_materia" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcod_materia" runat="server" Text='<%# Bind("cod_materia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:Label ID="lblinkar" runat="server" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblerrorGrid" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td class="style28">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
