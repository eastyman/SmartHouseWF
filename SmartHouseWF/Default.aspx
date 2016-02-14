<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Умный дом</title>
        <style>
        
        .mac {
                display: inline-block;
                border: 1px solid black;               
                margin: 3px;
                padding: 3px;
                border-radius: 20px;
                padding: 5px 8px;
                color: #333;
                background: #E6E6FA;
                box-shadow: 
                    inset 0 2px 0 rgba(0,0,0,.2), 
                    0 0 4px rgba(0,0,0,0.1);
            }
       </style>
</head>
<body bgcolor = "#F5FFFA">
    <form id="form1" runat="server">
    <div>
         <asp:Label ID ="ErrText" runat="server"></asp:Label>
         <br />
         <asp:TextBox ID="DeviceName" runat="server"></asp:TextBox>
         <asp:DropDownList ID="dropDownDevicesList" runat="server">
                <asp:ListItem>Холодильник</asp:ListItem>
                <asp:ListItem>Телевизор</asp:ListItem>
                <asp:ListItem>Микроволновка</asp:ListItem>
                <asp:ListItem>Печь</asp:ListItem>
                <asp:ListItem>Спутниковый тюнер</asp:ListItem>
                <asp:ListItem>Игровая приставка</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="addDeviceButton" runat="server" Text="Добавить" />
            <br />
            <asp:Panel ID="DevicePanel" runat="server" ></asp:Panel>
    </div>
        
    </form>
</body>
</html>
