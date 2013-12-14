<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotAuthorized.aspx.cs" Inherits="EquipCheck.NotAuthorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message</title>
    <link rel="stylesheet" type="text/css" href="~/Restricted/Styles.css" />
</head>
<body>
    <form id="NotAuthorizedForm" runat="server">
        <div>
            <asp:Label ID="PageHeaderLabel" runat="server" Text="Equipment Checklist Application" ></asp:Label><br />
            <asp:Label ID="PageNameLabel" runat="server" Text="Access is Not Authorized for this User Account!" ></asp:Label><br /><br /><br />
        </div>
        <div>
            <asp:Button ID="OkButton" runat="server" Text="OK" OnClick="OkButton_Click" />
        </div>
    </form>
</body>
</html>
