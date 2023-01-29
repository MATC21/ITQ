<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngresoMallaCarrera.aspx.vb" Inherits="IngresoMallaCarrera" %>

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
            height: 54px;
            background-color: #ffffff;
        }
        .style28
        {
            width: 58px;
        }
        .style32
        {
            height: 23px;
        }
        .style33
        {
            height: 23px;
        }
        .style46
        {
            width: 236px;
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
            width: 419px;
            height: 20px;
        }
        .style58
        {
            width: 179px;
            height: 20px;
        }
        .style59
        {
            height: 20px;
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
                        Text="INGRESO DE MALLAS POR AÑO" Width="675px"></asp:Label>
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
                            <td align="right" width="20%">
                                <asp:UpdatePanel ID="UpdateIngPreg" runat="server" ChildrenAsTriggers="False" 
                                    UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="style8">
                                            <tr>
                                                <td class="style52">
                                                    <asp:Label ID="Label24" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Carrera"></asp:Label>
                                                    <asp:Label ID="lblcodcarrera" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="text-align: left" class="style53">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label20" runat="server" BorderWidth="0px" 
                                                        style="font-size: small; font-family: Verdana; font-weight: 700;" 
                                                        Text="Ingrese el año"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style46">
                                                    <asp:DropDownList ID="CboCarrera" runat="server" AutoPostBack="True" Font-Size="12pt" Height="27px" style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" Width="530px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtAnio" runat="server" Height="21px" MaxLength="4" 
                                                        style="font-size: small; font-family: Verdana" Width="64px"></asp:TextBox>
                                                </td>
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
                                <asp:Button ID="Button1" runat="server" Text="Grabar Año" 
                                    Width="152px" />
                                              
                                        <asp:Label ID="lbldatoserroneosOpcional" runat="server" 
                                            style="font-style: italic; font-weight: 700; color: #800000"></asp:Label>
                                              
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanel6" 
                                    DisplayAfter="100">
                                                            <ProgressTemplate>
                                                                <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                                Guardando la asignatura.......
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
                                    <td colspan="3">
                                        <asp:Label ID="LBLUNIDADLISTA" runat="server" 
                                            style="font-size: small; font-family: Verdana"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style57">
                                        <asp:Label ID="Label23" runat="server" 
                                            style="font-size: small; font-weight: 400; font-family: Verdana;" 
                                            Text="LISTA DE MALLA POR CARRERA" Width="348px"></asp:Label>
                                    </td>
                                    <td class="style59">
                                    </td>
                                    <td class="style58">
                                    </td>
                                    <td class="style59">
                                        &nbsp;</td>
                                    <td class="style59">
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="66px" 
                                style="font-size: small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                Width="319px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" />
                                    <asp:TemplateField HeaderText="Num" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCod_Materia" runat="server" 
                                                Text='<%# Bind("nUM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDetalle" runat="server" 
                                                Text='<%# Bind("mALLA") %>' style="text-align: center"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
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
