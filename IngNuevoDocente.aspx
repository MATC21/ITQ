<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IngNuevoDocente.aspx.vb" Inherits="IngNuevoDocente" Culture="Auto" UICulture="Auto"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CENESTUR</title>
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
        .auto-style7 {
            height: 25px;
        }
        .auto-style8 {
            width: 144px;
            height: 63px;
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
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
                      </asp:ScriptManager>
                                    <img alt="" class="auto-style8" src="images/logo.jpg" /><br />
                      <br />
                      <asp:Label ID="Label128" runat="server" style="text-align: center; font-weight: 700; font-size: large" Text="FICHA DOCENTE" Width="905px"></asp:Label>
                      <br />
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                                        Text="Estimado Docente: Ingrese los datos requeridos por la Institución para su registro" 
                                        Width="920px"></asp:Label>
                    
                                                <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                    
                            <br />
    
                    <asp:UpdatePanel ID="UpdateNuevoEst" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <table border="0" class="style43" style="background-color: #F4F4F4; margin-right: 17px;" cellpadding="1" frame="above">
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label27" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080;" Text="1. DATOS GENERALES"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label29" runat="server" style="text-align: right" Text="Cédula:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="style58">
                                        <asp:TextBox ID="txtcedula" runat="server" MaxLength="15"></asp:TextBox>
                                        <asp:Label ID="lblmensajeCed" runat="server"></asp:Label>
                                        <asp:Label ID="lblcod_us" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="lblcod_Doc" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpas" runat="server" MaxLength="4" ToolTip="Ultimos 4 dígitos de la cédula" Visible="False" Width="55px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:Button ID="CmdNuevoEstud" runat="server" Enabled="False" Text="Nuevo Docente" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">
                                        <asp:Label ID="Label30" runat="server" style="text-align: right" Text="Apellidos y Nombres:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="auto-style7" colspan="2">
                                        <asp:TextBox ID="txtnombres" runat="server" MaxLength="80" Width="455px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style10">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">
                                        <asp:Label ID="Label132" runat="server" style="text-align: right" Text="Sexo:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:DropDownList ID="CboSexo" runat="server" AutoPostBack="True">
                                            <asp:ListItem>Masculino</asp:ListItem>
                                            <asp:ListItem>Femenino</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style7">&nbsp;</td>
                                    <td class="auto-style10">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style7">
                                        <asp:Label ID="Label36" runat="server" style="text-align: right" Text="Fecha de nacimiento:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:TextBox runat="server" ID="txtfechaNac" />
                                        <ajaxToolkit:CalendarExtender ID="txtfechaNac_CalendarExtender"   runat="server" TargetControlID="txtfechaNac" PopupButtonID="Image1" >
                                        </ajaxToolkit:CalendarExtender>
        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="Click en el calendario" /><br />
        
        
                                        <asp:Label ID="Label37" runat="server" style="font-size: small" Text="Dia / Mes / Año"></asp:Label>
                                    </td>
                                    <td class="auto-style7">
                                        <asp:Label ID="Label130" runat="server" style="text-align: right; " Text="Nacionalidad:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style10">
                                        <asp:TextBox ID="txtNacionalidad" runat="server" Width="87px">Ecuatoriana</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label48" runat="server" style="text-align: right" Text="Corre electrónico:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtemail" runat="server" Width="212px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label58" runat="server" style="text-align: right; " Text="Estado Civil:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:DropDownList ID="cboestadocivilestd" runat="server" AutoPostBack="True" Height="16px" Width="100px">
                                            <asp:ListItem>Soltero(a)</asp:ListItem>
                                            <asp:ListItem>Casado(a)</asp:ListItem>
                                            <asp:ListItem>Divorciado(a)</asp:ListItem>
                                            <asp:ListItem>Viudo(a)</asp:ListItem>
                                            <asp:ListItem>Unión Libre</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label46" runat="server" style="text-align: right" Text="Teléfono:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txttelef" runat="server" Width="101px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label57" runat="server" style="text-align: right; " Text="Celular:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="TxtCelular" runat="server" Width="101px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        &nbsp;</td>
                                    <td class="style57">
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        <asp:Label ID="Label109" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Capacidad Especial:"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style9">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label114" runat="server" style="text-align: right" Text="Tipo de Capacidad:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtTipoCapacEspec" runat="server" MaxLength="80" Width="312px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label115" runat="server" style="text-align: right" Text="% de Capacidad:" Width="138px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="txtPorcenCapaci" runat="server" MaxLength="10" ToolTip="Ej. 28/11/2010" Width="26px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label116" runat="server" style="text-align: right" Text="Carnet CONADIS:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:DropDownList ID="CboCarnetConadis" runat="server" AutoPostBack="True">
                                            <asp:ListItem>NO</asp:ListItem>
                                            <asp:ListItem>SI</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label117" runat="server" style="text-align: right" Text="No. de Carnet:" Width="140px"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="txtNoCarnet" runat="server" MaxLength="50" ToolTip="Ej. 28/11/2010" Width="132px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="2">
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style9">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label133" runat="server" style="text-align: right" Text="Docente Evaluador:" Width="220px"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:DropDownList ID="CboDocEvaluador" runat="server" AutoPostBack="True">
                                            <asp:ListItem>NO</asp:ListItem>
                                            <asp:ListItem>SI</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style11"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label134" runat="server" style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080" Text="Titulos Profesionales:"></asp:Label>
                                    </td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label135" runat="server" style="text-align: right" Text="De tercer nivel" Width="220px"></asp:Label>
                                    </td>
                                    <td class="auto-style2" colspan="3">
                                        <asp:TextBox ID="txttittercer" runat="server" Width="507px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label136" runat="server" style="text-align: right" Text="De cuarto nivel" Width="220px"></asp:Label>
                                    </td>
                                    <td class="auto-style2" colspan="3">
                                        <asp:TextBox ID="TxtTitCuarto" runat="server" Width="507px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style2">&nbsp;</td>
                                    <td class="auto-style11">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        &nbsp;</td>
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
    
                    <br />
    
    </div>
    </form>
</body>
</html>
