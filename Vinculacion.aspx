<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Vinculacion.aspx.vb" Inherits="Vinculacion" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">


        .style8
        {
            width: 54%;
            height: 62px;
            background-color: #ffffff;
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
        .style43
        {
            background-color: #ffffff;
            margin-left: 125px;
        }
        .style44
        {
        }
        .style56
        {
            width: 100%;
            height: 221px;
            border-style: solid;
            border-width: 1px;
            background-color: #ffffff;
        }
        .style57
        {
            height: 232px;
            width: 798px;
        }
        .style49
        {
            height: 15px;
            text-align: right;
        }
        .style50
        {
            height: 15px;
        }
        .style53
        {
            height: 29px;
        }
        .style54
        {
            width: 40px;
            height: 29px;
        }
        .style47
        {
            width: 245px;
            text-align: center;
        }
        .style46
        {
            width: 40px;
        }
        .auto-style23 {
        }
        .auto-style27 {
            height: 27px;
        }
        .auto-style32 {
            width: 23%;
        }
        .auto-style33 {
            width: 10%;
        }
        .auto-style34 {
            width: 1%;
        }
        .auto-style35 {
            width: 8%;
        }
        .auto-style36 {
            width: 28%;
        }
        .auto-style37 {
            height: 27px;
            width: 23%;
            text-align: center;
        }
        .auto-style38 {
            height: 27px;
            width: 10%;
        }
        .auto-style40 {
            height: 27px;
            }
        .auto-style52 {
            width: 198px;
        }
        .auto-style53 {
            height: 27px;
            }
        .auto-style54 {
            height: 27px;
            width: 1%;
        }
        .auto-style58 {
            text-align: right;
        }
        .auto-style59 {
            width: 10px;
        }
        </style>
        <script language="javascript" type="text/javascript">
        // <!CDATA[
        function openPopup(strOpen) {
            //alert(strOpen);
            open(strOpen, "Archivos", "status=1, scrollbars=YES, width=900, height=600, top=100, left=600");
        }
       
        // ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 123px">
    
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
                    </asp:ScriptManager>
                    
                            <asp:UpdatePanel ID="UpdatePCabecera" runat="server" 
                        ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                                        Text="PRACTICAS DE VINCULACIÓN" Width="675px"></asp:Label>
                                    <br />
                                    <table bgcolor="#CCCCCC" class="style8" border="1" cellpadding="0" 
                                        cellspacing="1">
                                        <tr>
                                            <td class="style37">
                                                <asp:Label ID="Label2" runat="server" 
                                                    style="text-align: right; font-size: small; font-family: Verdana;" 
                                                    Text="Carrera:" Width="160px"></asp:Label>
                                            </td>
                                            <td class="style38">
                                                <asp:DropDownList ID="CboCarrera" runat="server" AutoPostBack="True" 
                                                    Font-Size="12pt" Height="25px" 
                                                    style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                                    Width="400px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label27" runat="server" 
                                                    style="font-size: small; font-family: Verdana;" 
                                                    Text="Digite el primer apellido:" Width="160px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:TextBox ID="txtapellido" runat="server" 
                                                    style="color: #800000; font-size: medium; font-weight: 400; font-family: Verdana; background-color: #F7FBFF" 
                                                    Width="218px"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="cmdvernombre" runat="server" Text="Ver Estudiante" 
                                                    Width="105px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label10" runat="server" 
                                                    style="text-align: right; font-size: small; font-family: Verdana;" 
                                                    Text="Estudiantes:" Width="157px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:DropDownList ID="CboEstudiantes" runat="server" AutoPostBack="True" 
                                                    Font-Size="12pt" Height="25px" 
                                                    style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                                    Width="347px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style40">
                                                <asp:Label ID="Label3" runat="server" 
                                                    style="text-align: right; font-size: small; font-family: Verdana;" 
                                                    Text="Periodo Académico:" Width="153px"></asp:Label>
                                            </td>
                                            <td class="style41">
                                                <asp:DropDownList ID="CboPeriodoAcad" runat="server" AutoPostBack="True" 
                                                    Width="320px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblcodcarrera" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                    <asp:Label ID="lblcod_usu" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblusuario" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblperiodoacad0" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblperiodotipo" runat="server" Visible="False"></asp:Label>
                                    <br />
                                </ContentTemplate>
                    </asp:UpdatePanel>
    
                    <table border="1" cellspacing="1" class="style56">
                        <tr>
                            <td bgcolor="#F2F9FF" class="style57" width="50%">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                                                            AssociatedUpdatePanelID="UpdatePanel6" 
                        DisplayAfter="100">
                                                            <ProgressTemplate>
                                                                <img alt="" src="images/control.gif" style="width: 31px; height: 31px" /> 
                                                                Cargando las Practicas Profesionales .....</ProgressTemplate>
                                                        </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="cdmverInformacion" runat="server" Text="Ver información por Periodo" 
                                Width="224px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblnombestud" runat="server" 
                                style="font-size: small; font-weight: 700; font-family: Verdana; text-align: center; color: #000080;" Width="363px"></asp:Label>
                            &nbsp;&nbsp;<asp:Label ID="Label63" runat="server" style="font-weight: 700" Text="No. de Horas:"></asp:Label>
                            &nbsp;<asp:Label ID="lblHoras" runat="server" style="font-weight: 700; color: #003366"></asp:Label>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="136px" 
                                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; text-align: left;" 
                                Width="1004px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:TemplateField HeaderText="Codigo_Estud" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcodestud" runat="server" Text='<%# Bind("codigo_estud") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombres" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblnombres" runat="server" 
                                                Text='<%# Bind("apellidos_nombre") %>' style="text-align: left" 
                                                Width="250px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Empresa">
                                        <ItemTemplate>
                                            <asp:Label ID="lblempresa" runat="server" Text='<%# Bind("Empresa") %>' 
                                                Width="150px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Inicio">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblfi" runat="server" style="text-align: left" 
                                                Text='<%# Bind("FechaInicio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Final">
                                        <ItemTemplate>
                                            <asp:Label ID="lblff" runat="server" Text='<%# Bind("FechaFinal") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. de Horas">
                                        <ItemTemplate>
                                            <asp:Label ID="lblhoras" runat="server" Text='<%#Eval("NoHoras") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Docente Responsable">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDocResponsable" runat="server" Text='<%# Bind("NombDoc") %>' style="text-align: left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre del Proyecto">
                                        <ItemTemplate>
                                            <asp:Label ID="lblproyectogrid" runat="server" 
                                                Text='<%# Bind("DetalleProyecto") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Periodo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblperiodo" runat="server" Text='<%# Eval("Detalle_Periodo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Semestre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblseme" runat="server" Text='<%#Eval("Semestre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="num" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnum" runat="server" Text='<%# Eval("num") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descargar">
                                        <ItemTemplate>
                                            <a href="javascript:openPopup('VerArchivos.aspx?na=<%# Eval("pathAr")%>')">
                                                                        <img src="images/descarga.jpg" border=0px style="height: 31px; width: 29px"/>
                                                                        </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Label62" runat="server" Text='<%#Eval("pathAr") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="codempresa" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcodempresa" runat="server" Text='<%#Eval("Cod_empresa") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="coddoc" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcoddoc" runat="server" Text='<%#Eval("CodDocente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="path" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpatharc" runat="server" Text='<%# eval("pathAr") %>'></asp:Label>
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
                            <asp:Label ID="lblerrorGrid" runat="server" 
                                style="color: #800000; font-size: medium; font-family: Verdana"></asp:Label>
                            <asp:Label ID="lblperiodoacad" runat="server" Visible="False"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        </Triggers>
                    </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
    
    </div>
               
                        <table class="style43">
                            <tr>
                                <td class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    <asp:Label ID="Label42" runat="server" style="font-weight: 700" Text="INGRESE LOS DATOS "></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label61" runat="server" style="text-align: right" Text="Subir Archivo:" Width="123px"></asp:Label>
                                    &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Height="22px" Width="324px" />
                                </td>
                            </tr>
                        </table>
                   
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="style43" style="background-color: #EEEEEE; width: 875px;">
                    <tr>
                        <td class="auto-style58">
                            <table class="auto-style23">
                                <tr>
                                    <td class="auto-style32">
                                        <asp:Label ID="Label51" runat="server" style="text-align: center" Text="Empresa" Width="245px"></asp:Label>
                                    </td>
                                    <td class="auto-style52">
                                        <asp:Label ID="Label58" runat="server" style="text-align: center" Text="Fecha Inicio" Width="111px"></asp:Label>
                                    </td>
                                    <td class="auto-style33">
                                        <asp:Label ID="Label38" runat="server" style="text-align: center" Text="Fecha Final" Width="111px"></asp:Label>
                                    </td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style35">
                                        <asp:Label ID="Label39" runat="server" style="text-align: center" Text="No. Horas" Width="78px"></asp:Label>
                                    </td>
                                    <td class="auto-style34">
                                        <asp:Label ID="Label54" runat="server" Height="20px" style="text-align: center" Text="Docente Responsable" Width="300px"></asp:Label>
                                    </td>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style36">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style37">
                                        <asp:DropDownList ID="CboEmpresa" runat="server" AutoPostBack="True" Height="25px" Width="259px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style53">
                                        <asp:TextBox ID="txtFechaInicio" runat="server" Width="80px" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtFechaInicio" />
                                        <asp:ImageButton ID="Image1" runat="Server" AlternateText="Click en el calendario" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                    </td>
                                    <td class="auto-style38">
                                        <asp:TextBox ID="txtFechaFinal" runat="server" Width="80px" />
                                        <ajaxToolkit:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" PopupButtonID="Image2" TargetControlID="txtFechaFinal" />
                                        <asp:ImageButton ID="Image2" runat="Server" AlternateText="Click en el calendario" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                    </td>
                                    <td class="auto-style54"></td>
                                    <td class="auto-style40">
                                        <asp:TextBox ID="txtNumHoras" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style54">
                                        <asp:DropDownList ID="CboDoceResponsable" runat="server" AutoPostBack="True" Height="25px" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2" class="auto-style27">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style37">
                                        <asp:Label ID="Label60" runat="server" style="text-align: center" Text="Semestre" Width="245px"></asp:Label>
                                    </td>
                                    <td class="auto-style27" colspan="4">
                                        <asp:Label ID="Label59" runat="server" style="text-align: center" Text="Tipo de documento entregado" Width="266px"></asp:Label>
                                    </td>
                                    <td class="auto-style54">
                                        <asp:Label ID="Label64" runat="server" style="text-align: center" Text="Nombre del Proyecto" Width="266px"></asp:Label>
                                    </td>
                                    <td class="auto-style27" colspan="2"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style37">
                                        <asp:DropDownList ID="cboSemestre" runat="server" AutoPostBack="True" Height="25px" style="text-align: center" Width="54px">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style53" colspan="4">
                                        <asp:TextBox ID="txtproyecto" runat="server" Height="39px" TextMode="MultiLine" Width="326px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style54">
                                        <asp:TextBox ID="txtNombProyecto" runat="server" Height="39px" TextMode="MultiLine" Width="326px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style27" colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style37">
                                        <asp:Label ID="lblpatharc" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="auto-style53" colspan="5">
                                        <asp:Label ID="lblcoddocresp" runat="server" Visible="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCodEmpresa" runat="server" Visible="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblextension" runat="server" Visible="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblnumregistro" runat="server" Visible="False"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td class="auto-style27" colspan="2">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style59"></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

       

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="CmdNuevoIngreso" runat="server" style="background-color: #99CCFF" Text="Guardar Nuevos Datos" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="CmdActualizaValoresExiste" runat="server" style="background-color: #99CCFF" Text="Actualizar Información" />
            <br />
      
       

            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
      
    </form>
</body>
</html>
