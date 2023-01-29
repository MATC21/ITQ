<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Subirarchivos.aspx.vb" Inherits="Subirarchivos" %>

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
        .style44
        {
            font-family: Verdana;
            font-size: small;
            border-left-color: #A0A0A0;
            border-right-color: #C0C0C0;
            border-top-color: #A0A0A0;
            border-bottom-color: #C0C0C0;
        }
        .style47
        {
            height: 27px;
        }
        .style48
        {
            font-family: Verdana;
            color: #800000;
            font-size: x-small;
            border-left-color: #A0A0A0;
            border-right-color: #C0C0C0;
            border-top-color: #A0A0A0;
            border-bottom-color: #C0C0C0;
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
        <table class="style8" width="80%">
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style33">
                    <asp:Label ID="Label9" runat="server" 
                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                        
                        Text="ADJUNTAR  DETALLE Y/O ARCHIVO COMO INFORMACIÓN  DE LOS PLANES DE ESTUDIO" 
                        Width="675px"></asp:Label>
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
                                        <asp:Label ID="Label3" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Periodo Académico:" Width="150px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="CboPeriodoAcad" runat="server" AutoPostBack="True" 
                                            Width="320px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblpacad" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    <td class="style39">
                                        &nbsp;</td>
                                    <td rowspan="7">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style37">
                                        <asp:Label ID="lbldocente" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Docente:" Width="160px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="cbodocente" runat="server" AutoPostBack="True" 
                                            Font-Size="12pt" Height="25px" 
                                            style="font-size: small; font-style: normal; font-family: Verdana;" 
                                            Width="250px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcod_usu" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style39">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style37">
                                        <asp:Label ID="Label24" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Año de Básica:" Width="110px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="CboAnioBasica" runat="server" AutoPostBack="True" 
                                            Font-Size="12pt" Height="18px" 
                                            style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                            Width="195px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblCodanioBasica" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style39">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style37">
                                        <asp:Label ID="Label2" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Asignatura:" Width="110px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="CboAsignatura" runat="server" AutoPostBack="True" 
                                            Font-Size="12pt" Height="25px" 
                                            style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                            Width="350px">
                                        </asp:DropDownList>
                                        &nbsp;<br />
                                    </td>
                                    <td class="style39">
                                        <asp:Label ID="lblnoorden" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style40">
                                        <asp:Label ID="Label25" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" Text="Trimestre:" 
                                            Width="110px"></asp:Label>
                                    </td>
                                    <td class="style41">
                                        <asp:DropDownList ID="cboTrim" runat="server" AutoPostBack="True">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style42">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style40">
                                        <asp:Label ID="Label26" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" Text="Mes:" 
                                            Width="110px"></asp:Label>
                                    </td>
                                    <td class="style41">
                                        <asp:DropDownList ID="cbomes" runat="server" AutoPostBack="True">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style42">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style34">
                                    </td>
                                    <td class="style35">
                                        <asp:Label ID="lblcodmateria" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                        <asp:Label ID="lblNopregunta" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="LblNumTram" runat="server"></asp:Label>
                                    </td>
                                    <td class="style36">
                                        <cc2:MsgBox ID="MsgBox1" runat="server" />
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
                    <table bgcolor="#CCCCCC" jquery1263831934996="109" style="WIDTH: 81%">
                        <tr>
                            <td align="middle" colspan="2" style="text-align: justify">
                                <div class="style16">
                                    <table class="style31">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <span class="style44">Ingrese el detalle, el archivo que se visualizará en el 
                                                trimestre y mes, luego adjuntar el archivo</span> y/o detalle.<br />
                                                <span class="style48">Ejemplo: Archivo con la planificación del trimestre 1 mes 
                                                2</span></td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="Widget403071_Widget403071_AccordionPane1_content_UpdateProgress5">
                                    <div align="center">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" width="20%">
                                <asp:UpdatePanel ID="UpdateIngPreg" runat="server" ChildrenAsTriggers="False" 
                                    UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="style8">
                                            <tr>
                                                <td class="style46">
                                                    <span ID="Widget403071_Widget403071_AccordionPane1_content_RequiredFieldValidator1" 
                                                        controltovalidate="Widget403071_Widget403071_AccordionPane1_content_preguntaVFTB" 
                                                        errormessage="Ingrese el texto de la pregunta" focusonerror="t" initialvalue="" 
                                                        isvalid="true" style="VISIBILITY: hidden; COLOR: red" 
                                                        title="Ingrese el texto de la pregunta" validationgroup="txtpreguntaOpMul">*</span>&nbsp;&nbsp;<asp:Label 
                                                        ID="Label20" runat="server" 
                                                        BorderWidth="0px" Text="Detalle:" 
                                                        style="font-size: small; font-family: Verdana"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDetalle" runat="server" Height="46px" 
                                                        TextMode="MultiLine" Width="570px" 
                                                        style="font-size: small; font-family: Verdana"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style25" valign="top">
                                <br />
                                <br />
                                <br />
                             
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="lbltamarchivo" runat="server"></asp:Label>
                             
                            </td>
                            <td align="left">
                                <table id="Widget403071_Widget403071_AccordionPane1_content_respuestasVFRBL" 
                                    border="0">
                                    <tr>
                                        <td class="style19">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtDetalle" Display="None" 
                                                        ErrorMessage="No ingreso el detalle o mensaje de la unidad"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender0" 
                                                        runat="server" Enabled="True" 
                                    TargetControlID="RequiredFieldValidator2">
                                                    </cc1:ValidatorCalloutExtender>
                                <asp:Label ID="lblMenstamarchivo" runat="server" style="margin-bottom: 0px" 
                                    Width="240px"></asp:Label>
                                        </td>
                                        <td class="style47">
                                            </td>
                                        <td class="style17" rowspan="2">
                                            <table class="style8">
                                                <tr>
                                                    <td class="style32">
                                                        </td>
                                                    <td style="text-align: center" class="style32">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                            AssociatedUpdatePanelID="UpdateResVF" DisplayAfter="100">
                                                            <ProgressTemplate>
                                                                <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                                Subiendo el archivo.......
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    <asp:Label ID="Label21" runat="server" BorderWidth="0px" 
                                                        Text="Seleccione el archivo:" style="font-size: small; font-family: Verdana"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        &nbsp;</td>
                                                    <td style="text-align: center" class="style32">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style20">
                                                        &nbsp;</td>
                                                    <td style="text-align: left">
                                                        <asp:UpdatePanel ID="UpdateResVF" runat="server" ChildrenAsTriggers="False" 
                                                            UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table class="style8">
                                                                    <tr>
                                                                        <td rowspan="2">
                                                                            <asp:Image ID="Image1" runat="server" Height="51px" 
                                                                                ImageUrl="~/images/imagpreg.gif" Width="49px" />
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;&nbsp;</td>
                                                                        <td>
                                                                            <asp:Label ID="UploadStatusLabel" runat="server" Font-Size="Small" 
                                                                                Width="300px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            <asp:Label ID="LengthLabel" runat="server" Font-Size="Small"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" style="text-align: left">
                                                                            <asp:Label ID="lblmensajeErrorOpcional" runat="server" 
                                                                                
                                                                                style="text-align: left; font-style: italic; font-weight: 700; color: #800000; font-size: medium" 
                                                                                Width="300px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                            
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style19">
                                          
                                                    <asp:Button ID="cmdSaveVF" runat="server" Text="Adjuntar archivo y/o Detalle" 
                                                    style="font-size: small; font-family: Verdana; font-weight: 700" />
                                                    <ContentTemplate>
                                                    <br />
                                              
                                        <asp:Label ID="lbldatoserroneosOpcional" runat="server" 
                                            style="font-style: italic; font-weight: 700; color: #800000"></asp:Label>
                                              
                                        </td>
                                        <td class="style18">
                                            &nbsp;</td>
                                    </tr>
                                </table>
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
                <td class="style28">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
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
                                Text="LISTA DE LOS ITEMS EN LA UNIDAD:" Width="302px"></asp:Label>
                            <asp:Label ID="LBLUNIDADLISTA" runat="server" 
                                style="font-size: small; font-family: Verdana"></asp:Label>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="197px" 
                                style="font-size: small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                Width="795px" EnableModelValidation="True">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Trimestre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" runat="server" Text='<%# Bind("Trimestre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mes">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrden" runat="server" Text='<%# Bind("Mes") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOrdenSave" runat="server" 
                                                Width="20px" Text='<%# Bind("Orden") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalle de los Items">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDetalle" runat="server" 
                                                Text='<%# Bind("Detalle_Cuest_Foro") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDetalleSave" runat="server" 
                                                Text='<%# Bind("Detalle_Cuest_Foro") %>' TextMode="MultiLine" Width="503px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CodMateria" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCodMateria" runat="server" Text='<%# Bind("cod_materia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Link" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLinkr" runat="server" Text='<%# Bind("Link_Cuest_Foro") %>'></asp:Label>
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
