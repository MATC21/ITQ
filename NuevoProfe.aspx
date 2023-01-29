<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NuevoProfe.aspx.vb" Inherits="NuevoProfe" %>

<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">


        .style8
        {
            width: 52%;
            height: 62px;
            background-color: #ffffff;
        }
        .style37
        {
            width: 74px;
            height: 31px;
        }
        .style38
        {
            width: 576px;
            height: 31px;
        }
        .style43
        {
            width: 50%;
            background-color: #ffffff;
        }
        .style56
        {
        }
        .style57
        {
        }
        .style58
        {
        }
        .style44
        {
            width: 79px;
        }
        .style49
        {
            width: 245px;
            height: 15px;
        }
        .style50
        {
            width: 123px;
            height: 15px;
        }
        .style53
        {
            width: 245px;
            height: 29px;
        }
        .style54
        {
            width: 123px;
            height: 29px;
        }
        .style47
        {
            width: 245px;
            text-align: center;
        }
        .style46
        {
            width: 123px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 110px">
    
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                                        Text="INGRESO DE DOCENTES NUEVOS Y/O ACTUALIZACIÓN DE ASIGNATURAS" 
                                        Width="675px"></asp:Label>
                    
                            <asp:UpdatePanel ID="UpdatePCabecera" runat="server" 
                        ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table bgcolor="#CCCCCC" class="style8" border="1">
                                        <tr>
                                            <td class="style37">
                                                <asp:Label ID="Label2" runat="server" 
                                                    style="text-align: right; font-size: small; font-family: Verdana;" 
                                                    Text="Tipo de carrera:" Width="120px"></asp:Label>
                                            </td>
                                            <td class="style38">
                                                <asp:DropDownList ID="CboCarrera" runat="server" AutoPostBack="True" 
                                                    Font-Size="12pt" Height="25px" 
                                                    style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                                    Width="350px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                    </asp:UpdatePanel>
    
                                                <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                                <asp:Label ID="lblcodcarrera" runat="server" 
                        Visible="False"></asp:Label>
                                                <asp:Label ID="lblcod_usu" runat="server" 
                        Visible="False"></asp:Label>
    
                    <br />
                    <asp:UpdatePanel ID="UpdateNuevoEst" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="Label27" runat="server" Text="Datos del profesor" 
                                
                                style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080"></asp:Label>
                            <br />
                            <table border="1" class="style43" style="background-color: #F2F9FF">
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label29" runat="server" Text="Cédula:" Width="82px"></asp:Label>
                                    </td>
                                    <td class="style58">
                                        <asp:TextBox ID="txtcedula" runat="server" MaxLength="10" 
                                            style="font-size: small"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpas" runat="server" MaxLength="4" 
                                            ToolTip="Ultimos 4 dígitos de la cédula" Width="55px" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label30" runat="server" Text="Apellidos" Width="80px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtApellidos" runat="server" MaxLength="80" Width="230px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label32" runat="server" Text="Nombres:" Width="75px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtnombres" runat="server" MaxLength="80" Width="227px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label35" runat="server" Text="Abrevia. Titulo" Width="95px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="TxtAbreTitulo" runat="server" ToolTip="Ing, Dr." Width="90px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        &nbsp;</td>
                                    <td class="style57">
                                        <asp:Button ID="cdmNuevoEstud" runat="server" Text="Agregar nuevo profesor" 
                                            Width="206px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56" colspan="3">
                                        <asp:Label ID="LBLmensajeestud" runat="server" 
                                            style="color: #800000; font-size: x-small; font-family: Verdana"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cdmNuevoEstud" />
                        </Triggers>
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
                            <asp:Button ID="cdmverasignatura" runat="server" Text="Ver asignaturas" 
                                Width="155px" />
                            <br />
                            <asp:Label ID="Label23" runat="server" 
                                style="font-size: small; font-weight: 400; font-family: Verdana; text-align: center; color: #000080;" 
                                Text="Asignaturas registradas" Width="619px"></asp:Label>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" Height="153px" 
                                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; text-align: left;" 
                                Width="761px">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" 
                                        HeaderText="Operaciones" ShowDeleteButton="True" />
                                    <asp:TemplateField HeaderText="Codigo_Estud" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcodestud" runat="server" Text='<%# Bind("codigo_doc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo de Carrera">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcarrera" runat="server" Text='<%# Bind("Nombre_Basica") %>' 
                                                Width="250px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtOrdenSave" runat="server" 
                                                Width="20px" Text='<%# Bind("Orden") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombres">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblnombres" runat="server" 
                                                Text='<%# Bind("apellidos_nombre") %>' style="text-align: left" 
                                                Width="230px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDetalleSave" runat="server" 
                                                Text='<%# Bind("Detalle_Cuest_Foro") %>' TextMode="MultiLine" Width="503px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Código Asignatura">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCodMateria" runat="server" 
                                                Text='<%# Bind("codigo_materia") %>' style="text-align: center"></asp:Label>
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
                                            <asp:Label ID="LblParalelos" runat="server" style="text-align: left" 
                                                Text='<%# Bind("paralelo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Año Básica" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnioBasica" runat="server" 
                                                Text='<%# Bind("cod_anio_Basica") %>'></asp:Label>
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
                            <asp:Label ID="lblerrorGrid" runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        </Triggers>
                    </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
    
                    <br />
                <asp:UpdatePanel ID="UpdateIngAsig" runat="server" 
        ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="style43">
                            <tr>
                                <td class="style44">
                                    &nbsp;</td>
                                <td bgcolor="#EEEEEE" style="text-align: center">
                                    <asp:Button ID="cdmverasignaturaCarr" runat="server" 
                                        Text="Ver asignaturas por tipo de carrera" Width="230px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style44">
                                    <asp:Label ID="Label24" runat="server" 
                                        style="text-align: right; font-size: small; font-family: Verdana;" 
                                        Text="Asignatura:" Width="70px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="CboAsignatura" runat="server" AutoPostBack="True" 
                                        Font-Size="12pt" Height="25px" 
                                        style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" 
                                        Width="350px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cdmverasignaturaCarr" />
                    </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdateAsign" runat="server" ChildrenAsTriggers="False" 
        UpdateMode="Conditional">
        <ContentTemplate>
            <table class="style43" style="background-color: #EEEEEE">
                <tr>
                    <td class="style49">
                        <asp:Label ID="lblcodasign" runat="server" 
                            style="font-size: small; font-family: Verdana" Visible="False"></asp:Label>
                    </td>
                    <td class="style50">
                        <asp:Label ID="Label26" runat="server" 
                            style="text-align: right; font-size: small; font-family: Verdana; color: #000080;" 
                            Text="Paralelo"></asp:Label>
                    </td>
                    <td class="style50">
                        <asp:Label ID="Label33" runat="server" 
                            style="text-align: right; font-size: small; font-family: Verdana; color: #000080;" 
                            Text="Periodo Académico" Width="200px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style53" bgcolor="White">
                        <asp:Label ID="LBLMATERIA" runat="server" 
                            style="font-size: small; font-family: Verdana; font-weight: 700;"></asp:Label>
                    </td>
                    <td class="style54">
                        <asp:DropDownList ID="CboParalelo" runat="server" Enabled="False">
                        </asp:DropDownList>
                    </td>
                    <td class="style54">
                        <asp:DropDownList ID="CboPeriodoAcad" runat="server" AutoPostBack="True" 
                            Width="320px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style47">
                        <asp:Button ID="cdmverasignaturaCarr0" runat="server" Text="Agregar asignatura al profesor" 
                            Width="246px" />
                        <br />
                    </td>
                    <td class="style46">
                        <asp:Label ID="lblparal" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td class="style46">
                        <asp:Label ID="lblperiodoacad" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
                    <br />
    
                    <br />
                                                    <br />
    
    </div>
    </form>
</body>
</html>
