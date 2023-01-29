<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NuevoUsuario.aspx.vb" Inherits="NuevoUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">


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
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 110px">
    
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                                    <asp:Label ID="Label9" runat="server" 
                                        style="font-size: medium; font-weight: 400; font-family: Verdana;" 
                                        Text="INGRESO DE USUARIOS" 
                                        Width="675px"></asp:Label>
                    
                                                <asp:Label ID="LabelErrorcab" runat="server"></asp:Label>
                                                <asp:Label ID="lblcodcarrera" runat="server" 
                        Visible="False"></asp:Label>
                                                <asp:Label ID="lblcod_usu" runat="server" 
                        Visible="False"></asp:Label>
    
                    <br />
                    <asp:UpdatePanel ID="UpdateNuevoEst" runat="server" ChildrenAsTriggers="False" 
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="Label27" runat="server" Text="Datos del usuario" 
                                
                                
                                style="font-size: small; font-weight: 700; font-family: Verdana; color: #000080"></asp:Label>
                            <br />
                            <table border="1" class="style43" style="background-color: #F2F9FF">
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label29" runat="server" Text="Login:" Width="82px"></asp:Label>
                                    </td>
                                    <td class="style58">
                                        <asp:TextBox ID="txtlogin" runat="server" MaxLength="10" 
                                            style="font-size: small"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        <asp:Label ID="Label30" runat="server" Text="Password" Width="80px"></asp:Label>
                                    </td>
                                    <td class="style57">
                                        <asp:TextBox ID="txtClave" runat="server" MaxLength="80" Width="230px"></asp:TextBox>
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
                                        &nbsp;</td>
                                    <td class="style57">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style56">
                                        &nbsp;</td>
                                    <td class="style57">
                                        <asp:Button ID="cdmNuevoEstud" runat="server" Text="Agregar nuevo usuario" 
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
    
    </div>
    </form>
</body>
</html>
