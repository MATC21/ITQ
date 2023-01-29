<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SubirCuestionario.aspx.vb" Inherits="SubirCuestionario" %>

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
            width: 191px;
            height: 22px;
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
            width: 468px;
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
            width: 219px;
            height: 21px;
        }
        .style47
        {
            height: 21px;
        }
        .style48
        {
            width: 219px;
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
                <td class="style33">
                    <asp:Label ID="Label9" runat="server" 
                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                        
                        Text="PREGUNTAS INGRESADAS CON RESPUESTAS VERDADERO O FALSO Y OPCIÓN MULTIPLE" 
                        Width="821px"></asp:Label>
                </td>
                <td class="style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <table bgcolor="#CCCCCC" class="style8">
                                <tr>
                                    <td class="style37">
                                        <asp:Label ID="Label2" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="Curso:" Width="101px" Height="16px"></asp:Label>
                                    </td>
                                    <td class="style38">
                                        <asp:DropDownList ID="CboAsignatura" runat="server" AutoPostBack="True" 
                                            Font-Size="12pt" Height="25px" 
                                            style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                            Width="350px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style39">
                                        &nbsp;</td>
                                    <td rowspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style40">
                                        <asp:Label ID="Label25" runat="server" 
                                            style="text-align: right; font-size: small; font-family: Verdana;" 
                                            Text="No. de Unidad:" Width="110px"></asp:Label>
                                    </td>
                                    <td class="style41">
                                        <asp:DropDownList ID="CboUnidad" runat="server" AutoPostBack="True" 
                                            Enabled="False" Font-Size="12pt" Height="25px" 
                                            style="font-size: small; font-weight: 700; font-family: Verdana;" Width="200px">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button1" runat="server" Text="Ver Preguntas" />
                                    </td>
                                    <td class="style42">
                                        <asp:Label ID="Label19" runat="server" 
                                            style="font-weight: 700; font-size: medium; font-family: Arial, Helvetica, sans-serif;" 
                                            Text="Unidad:"></asp:Label>
                                        <asp:Label ID="lblunidad" runat="server" 
                                            style="font-weight: 700; color: #000099; font-size: medium; font-family: Verdana;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style34">
                                        <asp:Label ID="lblpacad1" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style35">
                                        <asp:Label ID="lblcodmateria" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="LabelErrorcab" runat="server" style="color: #800000"></asp:Label>
                                        <asp:Label ID="lblcodusa" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style36">
                                        &nbsp;</td>
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
                    <table bgcolor="#CCCCCC" jquery1263831934996="109" style="WIDTH: 81%">
                        <tr>
                            <td align="middle" colspan="2" style="text-align: justify">
                                <div class="style16">
                                    <table class="style31">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                R<span class="style44">evise las preguntas ingresadas, luego haga click en el 
                                                botón Subir preguntas a la evaluación, para genererar el cuestionario de 
                                                evaluación, posterior a este paso no se puede modificar las preguntas.</span></td>
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
                            <td align="middle" colspan="2" style="text-align: justify">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <table class="style31">
                                            <tr>
                                                <td class="style46">
                                                    <asp:Label ID="Label20" runat="server" Text="Total preguntas registradas:"></asp:Label>
                                                </td>
                                                <td class="style47">
                                                    <asp:Label ID="TxtNumPregIngresadas" runat="server" 
                                                        style="color: #800000; font-weight: 700; font-family: Verdana"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style48">
                                                    <asp:Label ID="Label21" runat="server" 
                                                Text="No. mínimo de preguntas solicitado:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblnumpreguntas" runat="server" style="font-weight: 700"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label28" runat="server" 
                                                        style="font-weight: 700; font-style: italic; color: #800000" 
                                                        Text="Ingrese las fechas"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style48">
                                                    <asp:Label ID="Label29" runat="server" 
                                                        style="color: #000080; font-size: small; font-style: italic" 
                                                        Text="Formato de fecha:  mm/dd/yyyy"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server" Text="Fecha inicio del cuestionario:"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtfechai" runat="server" Width="80px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label27" runat="server" Text="Hasta:"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtfechaFinal" runat="server" Width="80px"></asp:TextBox>
                                                    <strong>&nbsp;</strong></td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="2" style="text-align: center">
                                                    <asp:Button ID="cmdSaveVF" runat="server" Text="Subir preguntas a la evaluación" 
                                                    
                                    style="font-size: small; font-family: Verdana; font-weight: 700" 
                                    Height="32px" />
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                        AssociatedUpdatePanelID="UpdatePanel6">
                                                        <ProgressTemplate>
                                                            <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                            Actualizando el cuestionario
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" width="20%" style="text-align: center">
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <br />
                                                            <asp:Label ID="lblmensajeok" runat="server" 
                                                                style="font-size: medium; font-weight: 700; font-family: Verdana" 
                                                                Text="Se genero correctamente  el cuestionario para la evaluación" 
                                                                Visible="False"></asp:Label>
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                        CellPadding="4" 
    ForeColor="#333333" GridLines="None" Height="197px" 
                                                        style="font-size: small; font-family: Arial, Helvetica, sans-serif; text-align: justify;" 
                                                        Width="795px">
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <Columns>
                                                                    <asp:CommandField HeaderText="Operaciones" 
                                                                CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                                                ShowDeleteButton="True" />
                                                                    <asp:TemplateField HeaderText="Pregunta">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtpregunta" runat="server" Text='<%# Bind("Pregunta") %>' 
                                                                        TextMode="MultiLine" Width="500px"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpregunta" runat="server" Text='<%# Bind("Pregunta") %>' 
                                                                        Width="500px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Explicación">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtexplica" runat="server" Text='<%# Bind("Explica_Resp") %>' 
                                                                        TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblexplicacion" runat="server" 
                                                                        Text='<%# Bind("Explica_Resp") %>' Width="300px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Resp. V/F">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LblrespVF" runat="server" Text='<%# Bind("RespVerdadFalso") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Resp. Op. M.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LblrespOMul" runat="server" Text='<%# Bind("Resp_Correcta") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Imagen">
                                                                        <EditItemTemplate>
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                            <br />
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpathimagen" runat="server" Text='<%# Bind("pathimagen") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No. Preg" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblno_pregunta" runat="server" Text='<%# Bind("No_Pregunta") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cod_Materia" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCodMateria" runat="server" Text='<%# Bind("cod_materia") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Unidad" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LblUnidad" runat="server" Text='<%# Bind("Unidad") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Tipo_Preg" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltipo_preg" runat="server" Text='<%# eval("Tipo_Pregunta") %>'></asp:Label>
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
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" width="20%" style="text-align: center">
                                                    &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" width="20%" style="text-align: justify">
                                            
                                                    <br />
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                               
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style25" valign="top">
                                <span id="Widget403071_Widget403071_AccordionPane1_content_RequiredFieldValidator2" 
                                    controltovalidate="Widget403071_Widget403071_AccordionPane1_content_respuestasVFRBL" 
                                    errormessage="Seleccione la respuesta" focusonerror="t" initialvalue="" 
                                    isvalid="true" style="VISIBILITY: hidden; COLOR: red" 
                                    title="Seleccione la respuesta" validationgroup="preguntasVF">*</span>
                                <br />
                                <br />
                                <br />
                             
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" class="style25" valign="top">
                                &nbsp;</td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatedatoserroneosOpcional" runat="server" 
                                    ChildrenAsTriggers="False" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lbldatoserroneosOpcional" runat="server" 
                                            style="font-style: italic; font-weight: 700; color: #800000"></asp:Label>
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
