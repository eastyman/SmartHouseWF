<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:TextBox ID="DeviceName" runat="server"></asp:TextBox>
         <asp:DropDownList ID="dropDownDevicesList" runat="server">
                <asp:ListItem>Холодильник</asp:ListItem>
                <asp:ListItem>Телевизор</asp:ListItem>
                <asp:ListItem>Микроволновка</asp:ListItem>
                <asp:ListItem>Печь</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="addDeviceButton" runat="server" Text="Добавить" />
            <br />
            <asp:Panel ID="DevicePanel" runat="server" ></asp:Panel>
    </div>
        
    </form>
</body>
</html>
