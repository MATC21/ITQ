<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngresoDiasMatricula.aspx.vb" Inherits="IngresoDiasMatricula" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

        .style8
        {
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
        .style40
        {
            width: 74px;
            height: 19px;
            text-align: right;
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
        .style62
        {
            width: 83px;
        }
        .style65
        {
            height: 20px;
            width: 149px;
        }
        .style66
        {
            height: 23px;
            width: 623px;
        }
        .style67
        {
            width: 623px;
        }
        .style69
        {
            width: 100%;
        }
        .style70
        {
            height: 19px;
        }
        .style71
        {
            height: 14px;
        }
        .auto-style1 {
            height: 48px;
        }
        .auto-style2 {
            height: 48px;
            width: 623px;
        }
        .auto-style3 {
            width: 19px;
        }
        .auto-style4 {
            height: 20px;
            width: 19px;
        }
        .auto-style5 {
            height: 3px;
            width: 4px;
        }
        .auto-style6 {
            height: 19px;
            width: 4px;
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
                        Text="INGRESO DE DÍAS " 
            Width="675px"></asp:Label>
        <table class="style8" width="80%">
            <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style2">
                                        <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                        <cc2:MsgBox ID="MsgBox1" runat="server" />
                </td>
                <td class="auto-style1">
                    </td>
            </tr>
            <tr>
                <td class="style28">
                    &nbsp;</td>
                <td class="style67">
                    <table bgcolor="#CCCCCC" jquery1263831934996="109" style="WIDTH: 50%">
                        <tr>
                            <td align="right" width="20%">
                                <asp:UpdatePanel ID="UpdateIngPreg" runat="server" ChildrenAsTriggers="False" 
                                    UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="style8">
                                            <tr>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label32" runat="server" BorderWidth="0px" Height="16px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Periodo:" Width="80px"></asp:Label>
&nbsp;</td>
                                                <td class="style53" style="text-align: left">
                                                    <asp:DropDownList ID="CboPeriodoAcad" runat="server" AutoPostBack="True" Height="22px" Width="240px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="auto-style5" style="text-align: left">
                                                    <asp:Label ID="lblCodperiodoacad" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label35" runat="server" BorderWidth="0px" Height="16px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Carrera:" Width="80px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    <asp:DropDownList ID="CboAnioBasica" runat="server" AutoPostBack="True" Font-Size="12pt" Height="25px" style="font-size: small; font-style: normal; font-family: Verdana;" Width="250px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="auto-style5" style="text-align: left">
                                                    <asp:Label ID="lblCarrera" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label33" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; height: 16px;" Text="Ciclos:" Width="50px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    <asp:DropDownList ID="Cbonum" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;<asp:Label ID="Label34" runat="server" Text="En el mismo periodo puede  dividir"></asp:Label>
                                                </td>
                                                <td class="auto-style5" style="text-align: left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label30" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Nivel:" Width="50px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    <asp:DropDownList ID="cbonivel" runat="server" AutoPostBack="True">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="auto-style5" style="text-align: left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label29" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Modalidad:" Width="50px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">&nbsp;<asp:DropDownList ID="Cbomodalidad" runat="server" AutoPostBack="True" Width="160px">
                                                    </asp:DropDownList>
                                                    &nbsp; </td>
                                                <td class="auto-style5" style="text-align: left"><asp:Label ID="lblcodmodalidad" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style70" style="text-align: left">
                                                    <asp:Label ID="Label28" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Día(s)" Width="50px"></asp:Label>
                                                </td>
                                                <td class="style70" style="text-align: left">
                                                    <asp:TextBox ID="TxtDetalle" runat="server" Width="281px"></asp:TextBox>
                                                </td>
                                                <td class="auto-style6" style="text-align: left">
                                                    <asp:Label ID="lblmoda" runat="server" Visible="False"></asp:Label>
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
                <td class="style67">
                    <table class="style54">
                        <tr>
                            <td class="style55">
                            </td>
                            <td class="style56">
                            </td>
                            <td class="style55">
                                <asp:Button ID="Button1" runat="server" Text="Grabar" 
                                    Width="178px" />
                                              
                                        <asp:Label ID="lbldatoserroneosOpcional" runat="server" 
                                            style="font-style: italic; font-weight: 700; color: #800000"></asp:Label>
                                              
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanel6" 
                                    DisplayAfter="100">
                                                            <ProgressTemplate>
                                                                <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                                Guardando .......
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
                                    <td>
                                        <asp:Label ID="LBLUNIDADLISTA" runat="server" 
                                            style="font-size: small; font-family: Verdana"></asp:Label>
                                    </td>
                                    <td class="auto-style3">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>A - Activo</td>
                                </tr>
                                <tr>
                                    <td class="style65">
                                    </td>
                                    <td class="auto-style4">
                                        &nbsp;</td>
                                    <td class="style59">
                                        &nbsp;</td>
                                    <td class="style59">P - Pasivo</td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="66px" 
                                style="font-size: small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                Width="578px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Código">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNum" runat="server" 
                                                Text='<%# eval("numd") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDetalle_Periodo" runat="server" 
                                                Text='<%# Bind("Detalledias") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDetalleSave" runat="server" 
                                                Text='<%# Bind("Detalledias") %>' Width="400px" MaxLength="200"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Control" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txttipomatricula" runat="server" Text='<%# Bind("TipoMatricula") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcontrol" runat="server" Text='<%# Bind("TipoMatricula") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtestado" runat="server" Text='<%#Eval("estado") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblestado" runat="server" Text='<%#Eval("estado") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cod. Modalidad" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtmodalidad" runat="server" Text='<%# eval("Cod_modalidad") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblmodalidad" runat="server" Text='<%# eval("Cod_modalidad") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nivel">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtnivel" runat="server" Text='<%# eval("nivel") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label31" runat="server" Text='<%# eval("nivel") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modalidad">
                                        <ItemTemplate>
                                            <asp:Label ID="Label36" runat="server" Text='<%# eval("modalidad") %>'></asp:Label>
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
