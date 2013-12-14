<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="EquipCheck.Message" %>

<%-- Web page for displaying a successful action or error to the user. --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
</head>
<body>
    <form id="MessageForm" runat="server">
        <div>
            <asp:Label ID="PageHeaderLabel" runat="server"></asp:Label><br />
            <asp:Label ID="PageNameLabel" runat="server"></asp:Label><br /><br /><br />
        </div>
        <div>
            <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="OkButton_Click" />
        </div>
    </form>
</body>
</html>
