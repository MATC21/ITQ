<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cabecera.aspx.vb" Inherits="Cabecera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">

        .style35
        {
	width: 190px;
	height: 20px;
        }
        .style36
        {
            width: 107px;
            height: 24px;
        }
        body {
	background-image: url(images/logocabecera.gif);
background-repeat: no-repeat;
}
.tx_right {
	font-family: Verdana, Geneva, sans-serif;
	font-size: 12px;
	font-style: normal;
	font-weight: normal;
	color: #000000;
	text-align: right;
}
.tx_leftbd {
	font-family: Verdana;
	font-size: xx-small;
	font-style: normal;
	font-weight: 400;
	color: #000000;
	text-align: left;
	margin-bottom: 5px;
}
        .style37
        {
	width: 190px;
	height: 60px;
        }
#menuholder {
	margin-bottom: 10px;
	padding-bottom: 10px;
}
        .style39
        {
        }
        .style40
        {
	width: 150px;
        }
.menuhld {
	margin-top: 40px;
}
        .style41
        {
            width: 290px;
        }
        .tx_leftsmall {
	font-family: Verdana, Geneva, sans-serif;
	font-size: 9px;
	font-style: normal;
	font-weight: normal;
	color: #000000;
	text-align: left;
            background-color: #FFFFFF;
        }
        .style44
        {
            height: 20px;
        }
        .style42
        {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
            color: #FFF;
            text-align: center;
            }
        .style43
        {
            width: 65px;
            text-align: right;
        }
        .style45
        {
            width: 76px;
        }
        .auto-style1 {
            width: 500px;
            height: 20px;
        }
    </style>
</head>
<body>
      <form id="form2" runat="server">
    <blockquote style="width: 71%">
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height: 110 px;">
          <tr>
            <td class="style35">
              
                &nbsp;</td>
            <td class="style36">
                <asp:Label CssClass="style39" ID="Label4" runat="server"></asp:Label>
              
            </td>
            <td class="auto-style1">
              
                  <asp:Label CssClass="style39" ID="Label6" runat="server" Width="442px" Height="20px"></asp:Label>
            </td>
            <td rowspan="2">
                &nbsp;</td>
            <td rowspan="2" valign="top" class="style41"><asp:Panel ID="PanBienvenida" runat="server" Height="70px" 
                            style="margin-left: 0px" Visible="False" Width="200px">
              <table border="0" 
    cellpadding="3" cellspacing="0" id="curuserTable" 
                                style="width:204px;" runat="server" 
                                enableviewstate="false">
                <tr>
                  <td height="59" rowspan="2" class="style45">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                  <td rowspan="2" align="right" valign="middle" style="text-align: left">
                      <asp:Label CssClass="tx_leftbd" 
                                            ID="lblbienvenido" runat="server" Width="159px" 
                                            
                                            ></asp:Label>
                    <br />
                      <asp:HyperLink ID="HyperLink1" runat="server" BorderColor="#0217A6" 
                          BorderStyle="Solid" BorderWidth="1px" CssClass="tx_leftsmall" Height="16px" 
                          NavigateUrl="~/Actualiza_Informacion.aspx" Target="mainFrame" 
                          Width="161px">Actualizar 
                      información personal</asp:HyperLink>
                      <br />
                      <br />
                    </td>
                  <td align="right">
                      <asp:ImageButton ID="ImageButton1" runat="server" 
                                            ImageUrl="~/images/logout.gif" ToolTip="Cerrar sesión" /></td>
                </tr>
                <tr>
                  <td valign="top">&nbsp;</td>
                </tr>
              </table>
            </asp:Panel></td>
            <td rowspan="2" valign="top">
              <asp:Panel ID="Panel1" runat="server" 
                    Width="165px">
                <table border="0" cellpadding="2" 
                      
                      
                      style="border-style: solid; border-color: #2273CE; color: #FFFFFF; font-size: medium; width: 149px; background-color: #FFFFFF;">
                  <tr>
                    <td class="style42" colspan="3">
                        <asp:Label ID="Label7" runat="server" style="color: #000000; font-weight: 700; font-size: medium" Text="Ingreso al Sistema" Font-Names="Arial Narrow"></asp:Label>
                      </td>
                  </tr>
                    <tr>
                        <td class="style42">
                            <asp:Label ID="UserNameLabel" runat="server" associatedcontrolid="UserName" CssClass="tx_right">Usuario:</asp:Label>
                        </td>
                        <td class="style44">
                            <asp:TextBox ID="UserName" runat="server" Font-Size="0.9em" style="font-size: small; font-family: Verdana" Width="80px"></asp:TextBox>
                        </td>
                        <td class="style44">&nbsp;</td>
                    </tr>
                  <tr>
                    <td class="style42">
                      <asp:Label CssClass="tx_right" ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                                                    
                >Password:</asp:Label>
                    </td>
                    <td class="style44">
                      <asp:TextBox ID="Password" 
                runat="server" Font-Size="0.9em" TextMode="Password" 
                                                            Width="80px" style="font-size: small; font-family: Verdana"></asp:TextBox>
                    </td>
                      <td class="style44">
                          <asp:Button ID="Cmdaceptar" runat="server" Height="25px" Text="Aceptar" Width="100px" OnClick="Cmdaceptar_Click" />
                      </td>
                  </tr>
                </table>
                  <asp:Label ID="LabelError" runat="server" Font-Size="XX-Small" Height="20px" 
                      style="color: #800000; font-size xx-small; font-family: Verdana; text-align: right; font-weight: 700;" 
                      Width="180px"></asp:Label>
                  <asp:Label ID="lblcodTipoIngreso" runat="server" Visible="False"></asp:Label>
                  <br />
                </asp:Panel>
              <asp:Label ID="lblfecha" runat="server" 
                            
                        style="color: #FFFFFF; font-style: italic; font-size: xx-small; font-family: Verdana; margin-bottom: 0px; text-align: center;" 
                        Width="260px"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="style37">
              
              <br />
              
            </td>
            <td colspan="2" valign="top">
                <br />
                <br />
                <br />
                <br />
              </td>
          </tr>
        </table>
</blockquote>
      <p>
          &nbsp;</p>
        </form>
    
</body>
</html>
