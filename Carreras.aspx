<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Carreras.aspx.vb" Inherits="Carreras" %>

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
        .style40
        {
            width: 74px;
            height: 19px;
            text-align: right;
        }
        .style52
        {
            width: 236px;
            height: 3px;
        }
        .style53
        {
            height: 3px;
        }
        .style54
        {
            width: 100%;
            height: 25px;
        }
        .style55
        {
            height: 51px;
        }
        .style56
        {
            height: 51px;
            width: 120px;
        }
        .style57
        {
            width: 230px;
            height: 20px;
        }
        .style59
        {
            height: 20px;
        }
        .style60
        {
            width: 159px;
        }
        .style61
        {
            height: 20px;
            width: 159px;
        }
        .style65
        {
            height: 20px;
            width: 149px;
        }
        .style67
        {
            width: 623px;
        }
        .style70
        {
            height: 19px;
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label9" runat="server" 
                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                        Text="INGRESO DE CARRERAS" 
            Width="675px"></asp:Label>
        <table class="style8" width="80%">
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td class="style67">
                    <table bgcolor="#CCCCCC" jquery1263831934996="109" style="WIDTH: 50%">
                        <tr>
                            <td align="middle" style="text-align: justify">
                                <div class="style16">
                                        <cc2:MsgBox ID="MsgBox1" runat="server" />
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
                                                <td class="style52">
                                                    &nbsp;</td>
                                                <td style="text-align: left" class="style53">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label20" runat="server" BorderWidth="0px" 
                                                        style="font-size: small; font-family: Verdana; font-weight: 700;" 
                                                        Text="Detalle"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style40">
                                                    &nbsp;</td>
                                                <td style="text-align: left" class="style70">
                                                    <asp:TextBox ID="txtDetalle" runat="server" Height="21px" MaxLength="100" 
                                                        style="font-size: small; font-family: Verdana" Width="561px"></asp:TextBox>
                                                </td>
                                                <td class="style70" style="text-align: left">
                                                    &nbsp;</td>
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
                <td class="style67">
                    <table class="style54">
                        <tr>
                            <td class="style55">
                            </td>
                            <td class="style56">
                            </td>
                            <td class="style55">
                                <asp:Button ID="Button1" runat="server" Text="Grabar carrera" 
                                    Width="261px" />
                                              
                                        <asp:Label ID="lbldatoserroneosOpcional" runat="server" 
                                            style="font-style: italic; font-weight: 700; color: #800000"></asp:Label>
                                              
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanel6" 
                                    DisplayAfter="100">
                                                            <ProgressTemplate>
                                                                <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                                Guardando la carrera.......
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
                <td class="style67">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="style54">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="LBLUNIDADLISTA" runat="server" 
                                            style="font-size: small; font-family: Verdana"></asp:Label>
                                    </td>
                                    <td class="style60">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style57">
                                        <asp:Label ID="Label23" runat="server" 
                                            style="font-size: small; font-weight: 400; font-family: Verdana;" 
                                            Text="LISTA DE CARRERAS" Width="348px"></asp:Label>
                                    </td>
                                    <td class="style65">
                                    </td>
                                    <td class="style61">
                                        &nbsp;</td>
                                    <td class="style59">
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="25px" 
                                style="font-size: small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                Width="520px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Código">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCod" runat="server" Height="16px" 
                                                Text='<%# Bind("Cod_AnioBasica") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDetalle_Periodo" runat="server" 
                                                Text='<%# Bind("Nombre_Basica") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDetalleSave" runat="server" MaxLength="200" 
                                                Text='<%# Bind("Nombre_Basica") %>' Width="400px"></asp:TextBox>
                                        </EditItemTemplate>
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
                            <asp:Label ID="lblnummax" runat="server" Visible="False"></asp:Label>
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
                <td class="style67">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
