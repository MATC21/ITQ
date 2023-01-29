<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngresoEmpresas.aspx.vb" Inherits="IngresarMaterias" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc2" %>

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
        .style28
        {
            width: 58px;
        }
        .style31
        {
            width: 100%;
            background-color: #ffffff;
            height: 28px;
            margin-bottom: 0px;
        }
        .style32
        {
            height: 23px;
        }
        .style33
        {
            height: 23px;
        }
        .style37
        {
            width: 64px;
            height: 29px;
        }
        .style38
        {
            width: 353px;
            height: 29px;
        }
        .style39
        {
            width: 209px;
            height: 29px;
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
        .style51
        {
            height: 34px;
        }
        .style52
        {
            width: 236px;
            height: 16px;
        }
        .style53
        {
            height: 16px;
        }
        .style54
        {
            width: 100%;
            height: 25px;
        }
        .style55
        {
            height: 33px;
        }
        .style56
        {
            height: 33px;
            width: 198px;
        }
        .style57
        {
            width: 302px;
            height: 20px;
        }
        .style59
        {
            height: 20px;
            width: 59px;
        }
        .style61
        {
            height: 20px;
            width: 46px;
        }
        .style65
        {
            height: 20px;
        }
        .style67
        {
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
        }
        .style68
        {
            width: 100%;
        }
        .style69
        {
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            width: 179px;
        }
        .style70
        {
            width: 179px;
            font-size: xx-small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style71
        {
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            font-weight: bold;
            text-align: center;
        }
        .style72
        {
            width: 173px;
            font-size: xx-small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style73
        {
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            width: 151px;
            font-weight: bold;
        }
        .style74
        {
            width: 111px;
            font-size: xx-small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style75
        {
            font-size: xx-small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style76
        {
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            width: 111px;
            font-weight: bold;
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
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label9" runat="server" 
                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                        Text="INGRESO DE EMPRESAS" Width="675px"></asp:Label>
        <table class="style8" width="80%">
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style33">
                    &nbsp;</td>
                <td class="style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td>
                    <table bgcolor="#CCCCCC" jquery1263831934996="109" style="WIDTH: 50%">
                        <tr>
                            <td align="middle" style="text-align: justify">
                                <div class="style16">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                <asp:UpdatePanel ID="UpdateIngPreg" runat="server" ChildrenAsTriggers="False" 
                                    UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="style8">
                                            <tr>
                                                <td style="text-align: left" class="style53">
                                                    &nbsp;</td>
                                                <td class="style53" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label20" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Empresa" Width="51px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    &nbsp;</td>
                                                <td class="style53" style="text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    &nbsp;</td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtDetalle" runat="server" Height="21px" MaxLength="100" style="font-size: small; font-family: Verdana" Width="384px"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left">
                                                    &nbsp;</td>
                                                <td style="text-align: center">
                                                    &nbsp;&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td>
                    <table class="style54">
                        <tr>
                            <td class="style55">
                            </td>
                            <td class="style56">
                                                    &nbsp;</td>
                            <td class="style55">
                                <asp:Button ID="Button1" runat="server" Text="Grabar Empresa" 
                                    Width="261px" />
                                              
                                        <asp:Label ID="lbldatoserroneosOpcional" runat="server" 
                                            style="font-style: italic; font-weight: 700; color: #800000"></asp:Label>
                                              
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanel6" 
                                    DisplayAfter="100">
                                                            <ProgressTemplate>
                                                                <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                                Guardando la empresa.......
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="style54">
                                <tr>
                                    <td class="style57">
                                        <asp:Label ID="Label23" runat="server" 
                                            style="font-size: small; font-weight: 400; font-family: Verdana;" 
                                            Text="LISTA DE EMPRESA" Width="348px"></asp:Label>
                                    </td>
                                    <td class="style59">
                                        &nbsp;</td>
                                    <td class="style65">
                                        <asp:Label ID="LBLUNIDADLISTA" runat="server" 
                                            style="font-size: small; font-family: Verdana"></asp:Label>
                                    </td>
                                    <td class="style61">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="66px" 
                                style="font-size: small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                Width="500px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Código" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCod_Materia" runat="server" 
                                                Text='<%# Bind("Num_emp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Empresa">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtempresasave" runat="server" Height="16px" Text='<%# eval("empresa") %>' Width="53px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label41" runat="server" 
                                                Text='<%# eval("Empresa") %>'></asp:Label>
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
