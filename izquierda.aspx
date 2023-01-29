<%@ Page Language="VB" AutoEventWireup="false" CodeFile="izquierda.aspx.vb" Inherits="izquierda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <style type="text/css">
        #form1
        {
            height: 795px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Label ID="Lbltitmenu" runat="server" 
            style="font-weight: 700; color: #000080; font-size: small; text-align: center" 
            Text="ACCESO AL MENU" Width="200px" Visible="False"></asp:Label>
    
        <asp:TreeView ID="TreeViewMenu" runat="server" imageset="Simple" 
            onselectednodechanged="TreeView1_SelectedNodeChanged" 
        BackColor="#F7F7F7" BorderColor="Black" BorderStyle="Double" BorderWidth="2px" NodeWrap="True" Visible="False">
            <selectednodestyle font-underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" />
            <LeafNodeStyle BorderColor="#CCCCCC" BorderStyle="None" NodeSpacing="2px" VerticalPadding="2px" />
            <nodestyle font-names="Tahoma" font-size="10pt" forecolor="Black" 
                horizontalpadding="0px" NodeSpacing="0px" VerticalPadding="0px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ChildNodesPadding="1px" />
            <ParentNodeStyle Font-Bold="False" />
            <hovernodestyle font-underline="True" forecolor="#5555DD" />
        </asp:TreeView>
        <br />
    
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
