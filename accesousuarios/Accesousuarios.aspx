<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Accesousuarios.aspx.vb" Inherits="Accesousuarios" %>

 
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">


        .style43
        {
            width: 47%;
            background-color: #ffffff;
            margin-left: 125px;
        }
        .style44
        {
        }
        .style54
        {
            width: 5px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 123px">
    
                            <asp:UpdatePanel ID="UpdatePCabecera" runat="server" 
                        ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                                        Text="Accesos a los usuarios" Width="675px"></asp:Label>
                                    <br />
                                    <table bgcolor="#CCCCCC" border="1" cellpadding="0" cellspacing="1" 
                                        class="style8">
                                        <tr>
                                            <td class="style40">
                                                &nbsp;</td>
                                            <td class="style41">
                                                <asp:Label ID="LBLLOGIN" runat="server" style="text-align: right; font-weight: 700" Width="327px">LOGIN:</asp:Label>
                                                 </td>
                                            <td class="style54">
                                                <asp:Label ID="lblverLOGIN" runat="server" style="font-weight: 700"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">&nbsp;</td>
                                            <td class="style41">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                            <td class="style54">
                                                <asp:TextBox ID="txtpassword" runat="server" Height="22px" MaxLength="10" Width="135px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                &nbsp;</td>
                                            <td class="style41">
                                                &nbsp;</td>
                                            <td class="style54">
                                                <asp:Button ID="CmdModificaPass" runat="server" Text="Modificar Password" Width="143px" />
                                                <asp:Label ID="lblmensajepass" runat="server" style="color: #008000"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label10" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" Text="Nombre del Usuario:" Width="157px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:DropDownList ID="CboUsuarios" runat="server" AutoPostBack="True" Height="23px" Width="317px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style54">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label3" runat="server" 
                                                    style="text-align: right; font-size: small; font-family: Verdana;" 
                                                    Text="Grupo:" Width="153px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:DropDownList ID="CboGrupo" runat="server" AutoPostBack="True" 
                                                    Width="320px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style54">
                                                <asp:Button ID="cmdAgregarTodos" runat="server" Text="Agregar Todos Los  Accesos" Width="186px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label28" runat="server" 
                                                    style="text-align: right; font-size: small; font-family: Verdana;" 
                                                    Text="Opción:" Width="153px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:DropDownList ID="CboAcceso" runat="server" AutoPostBack="True" 
                                                    Width="320px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style54">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                &nbsp;</td>
                                            <td class="style41">
                                                <asp:Label ID="LBLmensajeestud" runat="server" 
                                                    style="color: #800000; font-size: small; font-family: Verdana"></asp:Label>
                                            </td>
                                            <td class="style54">
                                                <asp:Button ID="cmdAgregarRubro" runat="server" Text="Agregar nuevo acceso" 
                                                    Width="149px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">&nbsp;</td>
                                            <td class="style41">&nbsp;</td>
                                            <td class="style54">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label134" runat="server" style="text-align: right" Text="Coordinador de Carrera:" Width="154px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:DropDownList ID="CboAnioBasica" runat="server" AutoPostBack="True" Font-Size="12pt" Height="25px" style="font-size: small; font-style: normal; font-family: Verdana;" Width="250px">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblCarrera" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style54">
                                                <asp:Button ID="cmdAgregarRubro0" runat="server" Text="Agregar coordinador" Width="149px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                    <asp:Label ID="lblcod_estud" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblusuario" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblIdgrupo" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCodaniobasica" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblLugarBus" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblcodacceso" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblURL" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblOpcion" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblGrupo" runat="server" Visible="False"></asp:Label>
                                    <br />
                                </ContentTemplate>
                    </asp:UpdatePanel>
    
    </div>
                <asp:UpdatePanel ID="UpdateIngAsig" runat="server" 
        ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="style43">
                            <tr>
                                <td class="style44" colspan="2">
                                    <br />
                                    <br />
                                    <asp:Button ID="CmdVerAsignaturas" runat="server" BorderColor="#49617A" 
                                        BorderStyle="Solid" BorderWidth="3px" 
                                        style="color: #FFFFFF; background-color: #5D7B9D" Text="Ver accesos asignados " 
                                        Width="145px" />
                                </td>
                                <td rowspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
                                        GridLines="None" Height="197px" 
                                        style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                        Width="393px">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                                HeaderText="Operaciones" ShowDeleteButton="True" />
                                            <asp:TemplateField HeaderText="Num" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNum" runat="server" Text='<%# Bind("Num") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Detalle del Grupo">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDetalle" runat="server" Text='<%# Bind("grupo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Detalle del acceso">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblValor" runat="server" Text='<%# Bind("opcion") %>'></asp:Label>
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
                                </td>
                                <td rowspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
