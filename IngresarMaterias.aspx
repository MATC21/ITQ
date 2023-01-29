<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngresarMaterias.aspx.vb" Inherits="IngresarMaterias" %>

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
        .auto-style1 {
            width: 92px;
            height: 29px;
        }
        .auto-style2 {
            height: 16px;
            width: 92px;
        }
        .auto-style3 {
            width: 92px;
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
                        Text="INGRESO DE ASIGNATURAS POR CARRERA" Width="675px"></asp:Label>
        <table class="style8" width="80%">
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style33">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <table bgcolor="#CCCCCC" class="style8">
                                <tr>
                                    <td class="style37">
                                        <asp:Label ID="Label2" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Carerra:" Width="120px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="CboCarrera" runat="server" AutoPostBack="True" 
                                            Font-Size="12pt" Height="25px" 
                                            style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                            Width="350px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodcarrera" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label38" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" Text="No. Malla" Width="92px"></asp:Label>
                                        </td>
                                    <td>
                                        <asp:DropDownList ID="CboMalla" runat="server" AutoPostBack="True" style="margin-left: 0px" Width="60px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblmalla" runat="server" Visible="False"></asp:Label>
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
                <td>
                    <table bgcolor="#CCCCCC" jquery1263831934996="109" style="WIDTH: 50%">
                        <tr>
                            <td align="middle" style="text-align: justify">
                                <div class="style16">
                                    <table class="style31">
                                        <tr>
                                            <td class="style51">
                                                </td>
                                            <td class="style51">
                                                <span class="style44">Ingrese el </spacódigo de la asignatura , el detalle de 
                                                la misma y su nivel</td>
                                            <td class="style51">
                                        <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                        <cc2:MsgBox ID="MsgBox1" runat="server" />
                                                </td>
                                        </tr>
                                    </table>
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
                                                    <asp:Label ID="Label39" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" Text="Código Materia" Width="150px"></asp:Label>
                                                </td>
                                                <td class="style52">
                                                    &nbsp;</td>
                                                <td style="text-align: left" class="style53">
                                                    <asp:Label ID="Label36" runat="server" BorderWidth="0px" 
                                                        style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" 
                                                        Text="NIVEL" Width="92px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label20" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700;" Text="Detalle" Width="51px"></asp:Label>
                                                </td>
                                                <td class="auto-style2" style="text-align: left">
                                                    <asp:Label ID="Label45" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" Text="Valor x hora" Width="92px"></asp:Label>
                                                </td>
                                                <td class="auto-style2" style="text-align: left">
                                                    <asp:Label ID="Label37" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" Text="Creditos" Width="92px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label44" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" Text="Valor de 1 crédito" Width="92px"></asp:Label>
                                                </td>
                                                <td class="style53" style="text-align: left">
                                                    <asp:Label ID="Label43" runat="server" BorderWidth="0px" style="font-size: small; font-family: Verdana; font-weight: 700; text-align: center;" Text="Ver en reporte" Width="92px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style46">
                                                    <asp:TextBox ID="txtCodigoTexto" runat="server" Height="22px"></asp:TextBox>
                                                </td>
                                                <td class="style46">
                                                    &nbsp;</td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtsemestre" runat="server" Height="22px" MaxLength="2" style="text-align: center" Width="75px"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtDetalle" runat="server" Height="21px" MaxLength="100" style="font-size: small; font-family: Verdana" Width="384px"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left" class="auto-style3">
                                                    <asp:TextBox ID="txtValorHora" runat="server" Height="22px" MaxLength="6" style="text-align: center" Width="75px"></asp:TextBox>
                                                </td>
                                                <td class="auto-style3" style="text-align: left">
                                                    <asp:TextBox ID="txtCreditos" runat="server" Height="22px" MaxLength="2" style="text-align: center" Width="75px"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtValorCreditos" runat="server" Height="22px" MaxLength="6" style="text-align: center" Width="75px"></asp:TextBox>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:CheckBox ID="chkVerReporte" runat="server" Checked="True" />
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
                                <asp:Button ID="Button1" runat="server" Text="Grabar asignatura por nivel" 
                                    Width="261px" />
                                              
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
                                    <td class="style57">
                                        <asp:Label ID="Label23" runat="server" 
                                            style="font-size: small; font-weight: 400; font-family: Verdana;" 
                                            Text="LISTA DE ASIGNATURAS POR CARRERA" Width="348px"></asp:Label>
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
                                Width="716px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Código" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCod_Materia" runat="server" 
                                                Text='<%# eval("codigo_materia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Año Básica" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodCarrera" runat="server" 
                                                Text='<%# Bind("Cod_AnioBasica") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Código Materia">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="Txtcodmateriatextosave" runat="server" Text='<%# eval("cod_materia") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcodmateriatexto" runat="server" Text='<%# eval("cod_materia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cod. Materia" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Label42" runat="server" Text='<%# eval("codigo_materia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prerequisito">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtprerequisito" runat="server" Text='<%# eval("prerequisito") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblprerequisito" runat="server" Text='<%# eval("prerequisito") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nivel">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtsemesave" runat="server" 
                                                Text='<%# Bind("semestre") %>' Width="40px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSemestre" runat="server" Text='<%# Bind("semestre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asignatura">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAsignatura" runat="server" 
                                                Text='<%# Bind("Nomb_Materia") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAsignaturaSave" runat="server" 
                                                Text='<%# Bind("Nomb_Materia") %>' Width="400px" MaxLength="200"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Créditos">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtcreditossave" runat="server" Text='<%# eval("creditos") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreditos" runat="server" Text='<%# eval("creditos") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Horas">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txthorassave" runat="server" Height="16px" Text='<%# eval("Horas") %>' Width="63px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label40" runat="server" Text='<%# eval("Horas") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valor Hora">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtvalorhorasave" runat="server" Height="16px" Text='<%# eval("ValorHora") %>' Width="53px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label41" runat="server" Text='<%# eval("ValorHora") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Valor 1 crédito">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtvalorcred" runat="server" Text='<%# eval("valor1credito") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblvalorcredito" runat="server" Text='<%# eval("valor1credito") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. Malla">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumMalla" runat="server" Text='<%# Bind("NumMalla")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Combinar">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtconbsave" runat="server" Text='<%# eval("CombinarMateria") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcombinar" runat="server" Text='<%# eval("CombinarMateria") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Combinar Ingles">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtconbsaveingles" runat="server" Text='<%# eval("CombinaIngles") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblcombinaringles" runat="server" Text='<%# eval("CombinaIngles") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver reporte">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="Chkvereportesave" runat="server" Checked='<%# eval("verreporte") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chkvereporte" runat="server" Checked='<%# eval("verreporte") %>' />
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
