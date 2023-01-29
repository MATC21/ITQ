<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificarMaterias.aspx.vb" Inherits="ModificarMaterias" %>

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
        .auto-style2 {
            height: 29px;
            background-color: #FFFFFF;
        }
        .auto-style6 {
            height: 29px;
            background-color: #FFFFFF;
            }
        .auto-style12 {
            height: 15px;
            }
        .auto-style13 {
        }
        .auto-style14 {
            height: 15px;
            }
        .auto-style16 {
            height: 29px;
            background-color: #FFFFFF;
            }
        .auto-style17 {
            width: 42px;
        }
        .auto-style23 {
            width: 100%;
        }
        .auto-style25 {
            height: 24px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
                    </asp:ScriptManager>
                    
                            <asp:UpdatePanel ID="UpdatePCabecera" runat="server" 
                        ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                                        Text="Matricular asignaturas por estudiante" Width="675px"></asp:Label>
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
                                                                Cargando las asignaturas.....
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="cdmverasignatura" runat="server" Text="Ver asignaturas / matricula" 
                                Width="224px" style="height: 26px" />
                            <asp:Label ID="Label23" runat="server" 
                                style="font-size: small; font-weight: 400; font-family: Verdana; text-align: center; color: #000080;" 
                                Text="Asignaturas registradas" Width="303px"></asp:Label>
                            <asp:Label ID="Label57" runat="server" style="font-weight: 700" Text="JORNADA:"></asp:Label>
                            <asp:Label ID="lbljornada" runat="server" style="color: #800000; font-weight: 700; text-align: left; font-size: large" Width="185px"></asp:Label>
                            <asp:Label ID="lbdetalletipmatri" runat="server" style="color: #800000; font-weight: 700; text-align: center; font-size: large" Width="850px" Height="25px"></asp:Label>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="136px" 
                                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; text-align: left;" 
                                Width="855px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" />
                                    <asp:TemplateField HeaderText="Codigo_Estud" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcodestud" runat="server" Text='<%# Bind("codigo_estud") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Carrera">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcarrera" runat="server" Text='<%# Bind("Nombre_Basica") %>' 
                                                Width="250px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOrdenSave" runat="server" 
                                                Width="20px" Text='<%# Bind("Orden") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombres" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblnombres" runat="server" 
                                                Text='<%# Bind("apellidos_nombre") %>' style="text-align: left" 
                                                Width="250px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDetalleSave" runat="server" 
                                                Text='<%# Bind("Detalle_Cuest_Foro") %>' TextMode="MultiLine" Width="503px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cod_materia" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCodMateria" runat="server" 
                                                Text='<%# Bind("codigo_materia") %>' style="text-align: center"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. Matricula" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="LblNumMatic" runat="server" style="text-align: left" 
                                                Text='<%# Bind("Num_Matricula") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Periodo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSemestre" runat="server" Text='<%# Bind("Semestre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asignatura">
                                        <ItemTemplate>
                                            <asp:Label ID="LblMateria" runat="server" Text='<%# Bind("Nomb_Materia") %>' 
                                                style="text-align: left"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paralelo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblparalelo" runat="server" Text='<%# Bind("pa") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="num" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnum" runat="server" Text='<%# eval("mna") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. Matricula">
                                        <ItemTemplate>
                                            <asp:Label ID="Label58" runat="server" Text='<%# eval("Num_Matricula") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. Grupo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label61" runat="server" Text='<%# eval("NumGrupo") %>'></asp:Label>
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
                <asp:UpdatePanel ID="UpdateIngAsig" runat="server" 
        ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="style43">
                            <tr>
                                <td class="style44">
                                    &nbsp;</td>
                                <td class="style44">
                                    <asp:Label ID="Label42" runat="server" style="font-weight: 700" Text="INGRESE LOS DATOS DE MATRICULA"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdateAsign" runat="server" ChildrenAsTriggers="False" 
        UpdateMode="Conditional">
        <ContentTemplate>
            <table  style="background-color: #EEEEEE; ">
                <tr>
                    <td class="style49" colspan="6">
                        <table class="auto-style23">
                            <tr>
                                <td>
                                    <asp:Label ID="Label62" runat="server" Text="No. de grupo:" Width="96px"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="Cbotipogrupo" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtnumgrupo" runat="server" Width="29px" Visible="False">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label59" runat="server" style="text-align: right" Text="Tipo de matricula:" Width="150px"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="CboTipoMatricula" runat="server" AutoPostBack="True" Height="17px" Width="159px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lbltipoMatricula" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label51" runat="server" style="text-align: center" Text="Jornada" Width="111px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label38" runat="server" style="text-align: center" Text="Fecha Matricula" Width="111px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label50" runat="server" style="text-align: center" Text="Colegiatura" Width="91px" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label37" runat="server" Height="16px" style="text-align: right" Text="Inscripción" Width="78px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label39" runat="server" style="text-align: center" Text="Matricula" Width="78px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label52" runat="server" style="text-align: center" Text="Ayuda Económica" Width="78px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label53" runat="server" Height="16px" style="text-align: center" Text="Beca" Width="78px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label54" runat="server" Height="34px" style="text-align: center" Text="Recargo 2da. Matricula" Width="108px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="CboJornada" runat="server" AutoPostBack="True" Height="17px" Width="159px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaMatricula" runat="server" Width="80px" />
                                    <asp:ImageButton ID="Image1" runat="Server" AlternateText="Click en el calendario" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                    &nbsp;<ajaxToolkit:CalendarExtender ID="txtfechaNac_CalendarExtender" runat="server" PopupButtonID="Image1" TargetControlID="txtFechaMatricula" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcolegiatura" runat="server" Height="16px" Width="76px" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtinscripcion" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmatricula" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAyudaEcono" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBeca" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                </td>
                                <td style="text-align: center">
                                    <asp:TextBox ID="txtRecSegMatricula" runat="server" Height="16px" style="text-align: center" Width="76px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">
                                    <asp:Label ID="lblcodjornada" runat="server" style="font-size: small; font-family: Verdana" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style25">
                                    &nbsp;</td>
                                <td class="auto-style25">
                                    &nbsp;</td>
                                <td class="auto-style25">
                                    <asp:Label ID="Label67" runat="server" style="text-align: right" Text="Reingreso:" Width="171px"></asp:Label>
                                </td>
                                <td class="auto-style25">
                                    <asp:TextBox ID="txtreingreso" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                </td>
                                <td class="auto-style25" colspan="2">
                                    <asp:Label ID="Label60" runat="server" style="text-align: center" Text="Curso de Nivelación" Width="171px"></asp:Label>
                                </td>
                                <td class="auto-style25" style="text-align: center">
                                    <asp:TextBox ID="txtvalorNivela" runat="server" Height="16px" Width="76px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">&nbsp;</td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label63" runat="server" Height="16px" style="text-align: right" Text="Modalidad" Visible="False" Width="78px"></asp:Label>
                                    <asp:DropDownList ID="Cbomodalidad" runat="server" AutoPostBack="True" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label64" runat="server" Height="16px" style="text-align: right" Text="Horario" Visible="False" Width="78px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="CboHorario" runat="server" AutoPostBack="True" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Label65" runat="server" Height="16px" style="text-align: left" Text="Días" Visible="False" Width="78px"></asp:Label>
                                    <asp:DropDownList ID="CboDias" runat="server" AutoPostBack="True" Visible="False" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label66" runat="server" Height="16px" style="text-align: left" Text="Paralelo" Width="78px"></asp:Label>
                                    <asp:DropDownList ID="cboparalelosave" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="style50">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style49">
                        <asp:Button ID="cmdtipomat" runat="server"  style="background-color: #99CCFF" Text="Actualizar tipo de matricula y jornada" Width="232px" />
                        <asp:Label ID="lblcodasign" runat="server" style="font-size: small; font-family: Verdana" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblmalla" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td class="style50">
                        <asp:Label ID="LblNumCreditos" runat="server" style="font-weight: 700; text-align: center" Visible="False" Width="100px"></asp:Label>
                    </td>
                    <td class="style50">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:Label ID="lblcodmodalidad" runat="server" style="font-size: small; font-family: Verdana" Visible="False">1</asp:Label>
                        <asp:Label ID="lblcodHorario" runat="server" style="font-size: small; font-family: Verdana" Visible="False">1</asp:Label>
                        <asp:Label ID="lblcoddias" runat="server" style="font-size: small; font-family: Verdana" Visible="False">1</asp:Label>
                        <asp:Label ID="lblparalsave" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:Button ID="CmdActualizaValores" runat="server" style="background-color: #99CCFF" Text="Actualizar Valores y parametros" Height="25px" Width="210px" />
                        <asp:Label ID="lblvaloractua" runat="server" style="color: #800000" Width="186px"></asp:Label>
                        <br />
                    </td>
                    <td class="style50">&nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="White" class="style53" colspan="3">
                        &nbsp;<asp:Label ID="Label40" runat="server" Height="16px" style="text-align: right; font-size: small; font-family: Verdana;" Text="Periodo:" Width="288px"></asp:Label>
                        <asp:DropDownList ID="CboPeriodo" runat="server" AutoPostBack="True">
                            <asp:ListItem>0</asp:ListItem>
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
                    <td class="auto-style6" colspan="3">
                        <asp:Label ID="Label49" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" Text="Malla:" Width="73px"></asp:Label>
                        <asp:DropDownList ID="CboMalla" runat="server" AutoPostBack="True" Width="60px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cdmverasignaturaCarr" runat="server" Height="31px" Text="Ver asignaturas por carrera" Width="193px" />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="White" class="style53" colspan="2">
                        <asp:Label ID="Label24" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" Text="Asignatura:" Width="250px"></asp:Label>
                        <asp:DropDownList ID="CboAsignatura" runat="server" AutoPostBack="True" Font-Size="12pt" Height="25px" style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" Width="350px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label55" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" Text="No. Matricula:" Width="128px"></asp:Label>
                        <asp:DropDownList ID="CboNumMatricula" runat="server" AutoPostBack="True" Width="60px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style16" colspan="2">
                        <asp:Label ID="Label56" runat="server" style="text-align: right; font-size: small; font-family: Verdana;" Text="Paralelo:" Width="84px"></asp:Label>
                        <asp:DropDownList ID="CboParalelo" runat="server" AutoPostBack="True" Width="50px">
                        </asp:DropDownList>
                        <asp:Label ID="lblparal" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="White" class="style53" colspan="3">
                        <asp:Label ID="LBLMATERIA" runat="server" style="font-size: small; font-family: Verdana; font-weight: 700; color: #003366;"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style53" colspan="3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblmensaje" runat="server" style="color: #800000; font-weight: 700; font-style: italic"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style47">
                        <asp:Button ID="cdmverasignaturaCarr0" runat="server" Text="Agregar asignatura" 
                            Width="185px" />
                    </td>
                    <td class="auto-style13" colspan="3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;
                        <asp:Button ID="cdmmatPeriodo" runat="server" Text="Matricula por Periodo" Width="185px" />
                        <br />
                        &nbsp;
                        </td>
                    <td class="auto-style17">
                        &nbsp;</td>
                    <td class="auto-style17">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/imprimematriculaPeriodoOrdinario.png" NavigateUrl="~/ImprimirMatriculaGrupo0.aspx" Target="_blank">HyperLink</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/images/imprimematriculaPeriodoExtraordinario.png" NavigateUrl="~/ImprimirMatriculaGrupo1.aspx" Target="_blank">HyperLink</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
