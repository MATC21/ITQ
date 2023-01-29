<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngNuevoEstudianteWeb.aspx.vb" Inherits="IngNuevoEstudianteWeb" Culture="Auto" UICulture="Auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ITQ</title>
    <style type="text/css">



        .style43
        {
            width: 683px;
        }
        .style45
        {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style5 {
            height: 22px;
        }
        .auto-style6 {
        }
        .auto-style7 {
            height: 25px;
        }
        .auto-style8 {
            width: 255px;
            height: 105px;
        }
        .auto-style9 {
            width: 237px;
        }
        .auto-style10 {
            height: 25px;
            width: 237px;
        }
        .auto-style11 {
            height: 23px;
            width: 237px;
        }
        .auto-style13 {
        }
        .auto-style12 {
            height: 26px;
        }
        .auto-style14 {
            width: 200px;
        }
        </style>
</head>
<body>
    <center>
    <form  id="form1" runat="server" enctype="multipart/form-data">
         
    


    <div>
    
                      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
                      </asp:ScriptManager>
                                    <img alt="" class="auto-style8" src="images/logo.jpg" /><br />
                      <br />
                      <asp:Label ID="Label128" runat="server" style="text-align: center; font-weight: 700; font-size: large" Text="INSCRIPCIÓN DEL ESTUDIANTE" Width="1043px" Height="16px"></asp:Label>
                      <br />
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana; text-align: center;" 
                                        Text="Estimado Estudiante: Ingrese los datos requeridos por la Institución para su registro y posterior matriculación" 
                                        Width="1043px" Height="22px"></asp:Label>
                    
                                                <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                    
                            <br />
    
                    <asp:UpdatePanel ID="UpdateNuevoEst" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table border="0" class="style43" style="background-color: #F4F4F4; margin-right: 17px;" cellpadding="1" frame="above">
                                <tr>
                                    <td class="auto-style6" colspan="3">
                                        <table class="style45">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label153" runat="server" Text="Postulante:"></asp:Label>
                                                    <asp:CheckBox ID="ChkPos" runat="server" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label154" runat="server" Text="Regular:"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:CheckBox ID="ChkReg" runat="server" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style9" rowspan="3">
                                        <table class="style45">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style13">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" colspan="3">
                                        <asp:Label ID="Label127" runat="server" style="text-align: right" Text="Carrera:" Width="140px"></asp:Label>
                                        <asp:DropDownList ID="CboCarrera" runat="server" AutoPostBack="True" Height="20px" Width="400px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblCarrera" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" colspan="3">
                                        <asp:Label ID="Label126" runat="server" style="text-align: right" Text="Periodo:" Width="140px"></asp:Label>
                                        <asp:DropDownList ID="CboPeriodo" runat="server" AutoPostBack="True" Height="20px" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodPeriodo" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" colspan="4">
                                        <asp:Label ID="lblcurso" runat="server" style="color: #CC3300; font-weight: 700; font-style: italic; font-size: 14pt; text-align: center;" Height="25px" Width="1043px"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" colspan="2">
                                        <asp:Label ID="lblmensajeCed" runat="server"></asp:Label>
                                        <asp:Label ID="lblcodestud" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="lblcontrol" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td class="auto-style6" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblmensajeactualizar" runat="server" style="font-style: italic; font-weight: 700; color: #990000"></asp:Label>
                                    </td>
                                    <td colspan="2" rowspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label27" runat="server" Height="16px" style="font-size: medium; font-weight: 700; font-family: Verdana; color: #000080; text-align: center;" Text="Datos del estudiante" Width="465px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label155" runat="server" style="text-align: right" 
                                            Text="Tipo de Documento:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="CboTipoDoc" runat="server" AutoPostBack="True" Width="150px">
                                            <asp:ListItem Value="1">Cédula</asp:ListItem>
                                            <asp:ListItem Value="2">Pasaporte</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label29" runat="server" style="text-align: right" Text="Cédula / Pasaporte:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtcedula" runat="server" MaxLength="15"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/images/consulta.png" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">
                                        <asp:Label ID="Label30" runat="server" style="text-align: right" Text="Apellidos y Nombres:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="txtnombres" runat="server" Height="26px" MaxLength="50" Width="424px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style7">
                                    </td>
                                    <td class="auto-style10">
                                        <asp:Button ID="CmdNuevoEstud" runat="server" Enabled="False" Text="Nuevo Estudiante" Visible="False" />
                                        <asp:TextBox ID="txtpas" runat="server" MaxLength="4" ToolTip="Ultimos 4 dígitos de la cédula" Visible="False" Width="55px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label48" runat="server" style="text-align: right" Text="Corre electrónico:" Width="130px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtemail" runat="server" Width="212px" MaxLength="80"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label58" runat="server" style="text-align: right; " Text="Estado Civil:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:DropDownList ID="cboestadocivilestd" runat="server" AutoPostBack="True" Height="16px" Width="100px">
                                            <asp:ListItem>Soltero</asp:ListItem>
                                            <asp:ListItem>Casado</asp:ListItem>
                                            <asp:ListItem>Divorciado</asp:ListItem>
                                            <asp:ListItem>Viudo</asp:ListItem>
                                            <asp:ListItem>Unión Libre</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label49" runat="server" style="text-align: right; " Text="Dirección:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtCallePrincipal" runat="server" MaxLength="50" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        &nbsp;</td>
                                    <td class="style57">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label46" runat="server" style="text-align: right" Text="Teléfono:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txttelef" runat="server" Width="101px" MaxLength="30"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label57" runat="server" style="text-align: right; " Text="Celular:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="TxtCelular" runat="server" Width="101px" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label122" runat="server" style="text-align: right" Text="Lugar de Trabajo:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtLugarTrabajo" runat="server" MaxLength="100" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label123" runat="server" style="text-align: right" Text="Dirección Trabajo:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtDireccTrabajo" runat="server" MaxLength="100" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label124" runat="server" style="text-align: right" Text="Teléfono Trabajo:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="txttelefTrabajo" runat="server" Width="101px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label107" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Lugar de Nacimiento:"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label10" runat="server" Height="16px" style="text-align: right; " Text="Provincia:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodprov" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label52" runat="server" style="text-align: right; " Text="Cantón:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:DropDownList ID="ddlCanton" runat="server" AutoPostBack="True" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodcanton" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label53" runat="server" style="text-align: right; " Text="Parroquia:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="ddlParroquia" runat="server" AutoPostBack="True" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodparroquia" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label36" runat="server" style="text-align: right" Text="Fecha de nacimiento:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox runat="server" ID="txtfechaNac" />
                                        <ajaxToolkit:CalendarExtender ID="txtfechaNac_CalendarExtender"   runat="server" TargetControlID="txtfechaNac" PopupButtonID="Image1" >
                                        </ajaxToolkit:CalendarExtender>
        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click en el calendario" /><br />
        
                                        <asp:Label ID="Label37" runat="server" Text="Dia  / Mes / Año" style="font-size: small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label108" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Área de Estudio:"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label113" runat="server" style="text-align: right; " Text="Área:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="CboAreaEstudio" runat="server" AutoPostBack="True" Height="17px" Width="159px">
                                            <asp:ListItem>Seleccione</asp:ListItem>
                                            <asp:ListItem>Educación Continua</asp:ListItem>
                                            <asp:ListItem>Otros</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label112" runat="server" style="text-align: right; " Text="Modalidad:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="CboModalidadEstudio" runat="server" AutoPostBack="True" Height="17px" Width="159px">
                                            <asp:ListItem Value="10009">Presencial</asp:ListItem>
                                            <asp:ListItem Value="10006">Validación</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label110" runat="server" style="text-align: right" Text="Jornada:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:DropDownList ID="CboJornada" runat="server" AutoPostBack="True" Height="17px" Width="159px">
                                            <asp:ListItem>Seleccione</asp:ListItem>
                                            <asp:ListItem>Matutino</asp:ListItem>
                                            <asp:ListItem>Nocturna</asp:ListItem>
                                            <asp:ListItem Value="Virtual">Virtual</asp:ListItem>
                                            <asp:ListItem Value="Intensivo">Intensivo</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label118" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Tipo de Etnía:"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">&nbsp;</td>
                                    <td class="style57">
                                        <asp:DropDownList ID="CboTipoEtnia" runat="server" AutoPostBack="True" Height="17px" Width="159px">
                                            <asp:ListItem>Seleccione</asp:ListItem>
                                            <asp:ListItem>Blanco</asp:ListItem>
                                            <asp:ListItem>Negro</asp:ListItem>
                                            <asp:ListItem>Mestizo</asp:ListItem>
                                            <asp:ListItem>Afrodesciente</asp:ListItem>
                                            <asp:ListItem>Mulato</asp:ListItem>
                                            <asp:ListItem>Indigina</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label61" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Información Académica"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label62" runat="server" style="text-align: right" Text="Educación Primaria:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtEducPrimaria" runat="server" MaxLength="60" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label63" runat="server" style="text-align: right" Text="Educación Secundaria:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtEducSecundaria" runat="server" MaxLength="60" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label64" runat="server" style="text-align: right" Text="Educación Superior:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtEducSuperior" runat="server" MaxLength="60" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label50" runat="server" style="text-align: right" 
                                            Text="Colegio se Graduó:" Width="130px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtcolegiograduo" runat="server" Width="200px" MaxLength="60"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label60" runat="server" style="text-align: right; " Text="Título de Bachiller:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtBachiller" runat="server" MaxLength="70" Width="313px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label59" runat="server" style="text-align: right; " Text="Fecha Graduación:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                                              <asp:TextBox runat="server" ID="TxtFechaGrad" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtFechaGrad" PopupButtonID="Image2" >
                                        </ajaxToolkit:CalendarExtender>
        <asp:ImageButton runat="Server" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click en el calendario" /><br />
        
                                                              <asp:Label ID="Label156" runat="server" style="font-size: small" Text="Dia  / Mes / Año"></asp:Label>
        
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label119" runat="server" Height="16px" style="text-align: right; " Text="Provincia:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:DropDownList ID="ddlProvinciaAcad" runat="server" AutoPostBack="True" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodprovAcad" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label120" runat="server" style="text-align: right; " Text="Cantón:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:DropDownList ID="ddlCantonAcad" runat="server" AutoPostBack="True" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodcantonAcad" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label121" runat="server" style="text-align: right; " Text="Parroquia:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="ddlParroquiaAcad" runat="server" AutoPostBack="True" Width="200px">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblcodparroquiaAcad" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="2">
                                        <asp:Label ID="Label87" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Referencias Personales:"></asp:Label>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label88" runat="server" style="text-align: right; " Text="Nombres:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="TxtNombRef" runat="server" MaxLength="60" Width="312px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label89" runat="server" style="text-align: right; " Text="Ocupación:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="txtOcupacionRef" runat="server" Width="212px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label90" runat="server" style="text-align: right; " Text="Lugar de Trabajo:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="TxtLugarTrabajoRef" runat="server" MaxLength="60" Width="312px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label92" runat="server" style="text-align: right; " Text="Teléfono:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="TxtelefRef" runat="server" Width="113px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label91" runat="server" style="text-align: right; " Text="Que tiempo le Conoce:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="TxtTiempoConoce" runat="server" Width="113px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style11"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label93" runat="server" style="text-align: right; " Text="Nombres:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="TxtNombRef0" runat="server" MaxLength="60" Width="312px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label96" runat="server" style="text-align: right; " Text="Ocupación:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="txtOcupacionRef0" runat="server" Width="212px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label94" runat="server" style="text-align: right; " Text="Lugar de Trabajo:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="TxtLugarTrabajoRef0" runat="server" MaxLength="60" Width="312px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label97" runat="server" style="text-align: right; " Text="Teléfono:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="TxtelefRef0" runat="server" Width="113px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label95" runat="server" style="text-align: right; " Text="Que tiempo le Conoce:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="TxtTiempoConoce0" runat="server" Width="113px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="2">
                                        <asp:Label ID="Label98" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Información Adicional"></asp:Label>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="2">
                                        <asp:Label ID="Label99" runat="server" Text="Por qué escogió esta profesión?"></asp:Label>
                                    </td>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style11"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="3">
                                        <asp:TextBox ID="TxtInfAdicional" runat="server" MaxLength="200" Width="603px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="2">
                                        <asp:Label ID="Label100" runat="server" Text="Por qué decidió estudiar en el ITQ?"></asp:Label>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="3">
                                        <asp:TextBox ID="TxtEstudiaCenestur" runat="server" MaxLength="200" Width="603px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" colspan="2">
                                        <asp:Label ID="Label105" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Compromiso Económico"></asp:Label>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style5"></td>
                                    <td class="auto-style5" colspan="3">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                                            <asp:ListItem>El valor del semestre será cancelado en su totalidad al momento de la matrícula</asp:ListItem>
                                            <asp:ListItem>El valor del semestre será cancelado con crédito educativo</asp:ListItem>
                                            <asp:ListItem>El valor del semestre será cancelado con tarjeta de crédito</asp:ListItem>
                                            <asp:ListItem>El valor del semestre será cancelado hasta 4 cuotas durante los primeros cinco dias de cada mes por adelantado . En caso de incumplimiento, me comprometo cancelar los intereses generados por el atraso</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label158" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Requisitos"></asp:Label>
                                        <table class="style45">
                                            <tr>
                                                <td class="auto-style13">
                                                    <asp:Label ID="Label159" runat="server" style="text-align: right" Text="Cédula:" Width="200px"></asp:Label>
                                                </td>
                                                <td class="auto-style12">
                                                    <asp:CheckBox ID="chkCedula" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style14">
                                                    <asp:Label ID="Label157" runat="server" style="text-align: right" Text="Fotos:" Width="200px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ChkFotos" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td></td>
                                    <td class="auto-style9">
                                        &nbsp;<asp:ImageButton ID="ImgImprimir" runat="server" ImageUrl="~/images/imprimirinscripcion.jpg" Visible="False" />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="lblcompecono" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td class="style57" colspan="3">
                                        <asp:Button ID="cdmNuevoEstud" runat="server" Text="Enviar Datos" 
                                            Width="206px" style="font-weight: 700; color: #FFFFFF; font-size: medium; background-color: #0066FF" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LBLmensajeestud" runat="server" 
                                            style="color: #800000; font-size: small; font-family: Verdana"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="4">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cdmNuevoEstud" />
                        </Triggers>
                    </asp:UpdatePanel>
    
                                                <asp:Label ID="lblcod_us" runat="server" 
                        Visible="False"></asp:Label>
    
                      <asp:Label ID="lblnumestud" runat="server" Visible="False"></asp:Label>
    
                    <br />
    
    </div>
    </form>
</body>
</html>
