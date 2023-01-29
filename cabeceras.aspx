<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cabeceras.aspx.vb" Inherits="cabeceras" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="MsgBox" namespace="MsgBox" tagprefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Aula Virtual</title>
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
        
.tx_right {
	font-family: Verdana, Geneva, sans-serif;
	font-size: 12px;
	font-style: normal;
	font-weight: normal;
	color: #000000;
	text-align: right;
}
.tx_leftbd {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 1.5em;
	font-weight: bold;
	color: #f7f7f7;
	text-align: right;
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
            width: 211px;
            height: 20px;
        }
        .style42
        {
            font-family: Verdana, Geneva, sans-serif;
            font-size: 12px;
            font-style: normal;
            font-weight: normal;
            color: #FFF;
            text-align: right;
            width: 65px;
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

    body{font-family: Arial;font-size: 10pt;}
    .main_menu{width: 100px; background-color: #fff;border: 1px solid #ccc !important; color: #000;text-align: center;height: 30px;line-height: 30px;margin-right: 5px;}
    .level_menu{width: 110px; background-color: #fff; color: #333;border: 1px solid #ccc !important;text-align: center;height: 30px;line-height: 30px;margin-top: 5px;}
    .selected{background-color: #9F9F9F;color: #fff;}
    input[type=text], input[type=password]{width: 200px;}
    /*table{border: 1px solid #ccc;}*/
    table th { background-color: #F7F7F7;color: #333;font-weight: bold;}
    table th, table td { padding: 5px; border-color: #ccc; }
        .auto-style1 {
            width: 65px;
            text-align: right;
            height: 20px;
        }
        .auto-style2 {
            height: 26px;
        }
    .header
{
	width: 1024px;
	height: 135px;
    background: url('images/headerpITQAmbientePruebas.jpg') no-repeat;
        }
.menu
{
	width: 1024px;
	height: 44px;
    background: url('images/menu.GIF') no-repeat;
        }

.menu-text
{
font-family: verdana;
font-size: 14px;
color: #ffffff;
padding: 12px 45px 10px 10px;
float: left;
font-stretch: condensed;
cursor: pointer;
}


        </style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

</head>
<body>
        <center>
      <form id="form1" runat="server">
         

          <div class="header">
              <div style="float:left; margin-left:50px; margin-top:20px; width: 120px;">
                  <div style="float:left;  text-align:left; font-family:tahoma; font-size:24pt; color:#636363; margin-left:5px;margin-top:5px;">
                      </div>
              </div>
              <div style="float:left; margin-left:50px; margin-top:40px; width: 182px;">
                  <div style="float:left;  text-align:left; font-family:tahoma; font-size:24pt; color:#636363; margin-left:5px;margin-top:5px;">
                      </div>
              </div>
              <div style="float:right; margin-right:10px; margin-top:2x; text-align:left; font-family:tahoma;">
&nbsp;
                <asp:Panel ID="PanBienvenida" runat="server" Height="58px" style="margin-left: 0px" Visible="False" Width="243px">
                  <table border="0" cellpadding="3" cellspacing="0" id="curuserTable" style="width:204px;" runat="server"  enableviewstate="false">
                    <tr>
                      <td rowspan="2" align="right" style="text-align: left" valign="middle">
                          <asp:Label ID="lblbienvenido" runat="server" CssClass="tx_leftbd" Width="194px"></asp:Label>
                          <br />
                        </td>
                     <td align="right">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/logout.gif" ToolTip="Cerrar sesión" />
                        </td>
                    </tr>
<%--                    <tr>
                      <td valign="top" class="auto-style2">ww</td>
                    </tr>--%>
                  </table>
                </asp:Panel>

            <asp:Panel ID="Panel1" runat="server" Width="233px">
                <table border="0" cellpadding="2" style="font-size: medium; background-color: #FFFFFF;">
                  <tr>
                    <td >
                        <asp:Label ID="lblbienvenido0" runat="server" Width="80px">Usuario:</asp:Label>
                    </td>
                    <td class="style44">
                          <asp:TextBox ID="txtusuario" runat="server" Width="110px"></asp:TextBox>
                    </td>
                  </tr>
                  <tr>
                    <td >
                        <asp:Label ID="lblbienvenido1" runat="server" Width="80px">Password:</asp:Label>
                    </td>
                      <td class="style44">
                          <asp:TextBox ID="txtclave" runat="server" Width="110px" TextMode="Password"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                    <td class="auto-style1">
                    </td>
                    <td >
                          <asp:Button ID="Cmdaceptar" runat="server" Text="Aceptar" Width="118px" />
                    </td>
                  </tr>
                </table>

                  <asp:Label ID="LabelError" runat="server" Font-Size="XX-Small" Height="20px" 
                      style="color: #800000; font-size xx-small; font-family: Verdana; text-align: right; font-weight: 700;" 
                      Width="180px"></asp:Label>
                  <br />
                
            </asp:Panel>
                     
              </div>
          </div>
          <div class="menu">
              <div class="menu-text">
                  </div>
          </div>
         

      <p>
          </p>
       
        </form>
                   </body>
</html>
