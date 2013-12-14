<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectItem.aspx.cs" Inherits="EquipCheck.SelectItem" %>

<%-- Web page to display user's equipment list items for user to select for an Equipment Checklist. --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Items</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
    <script type="text/javascript" src="JS/SelectItem.js" ></script>
</head>
<body>
    <form id="SelectItemForm" runat="server">
        <div>
            <asp:Label ID="PageHeaderLabel" runat="server" Text="Equipment Checklist Application"></asp:Label><br />
            <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server">Select Items for Checklist</asp:Label>
        </div>
        <div id="LeftLayout">
            <div id="SelectItemsMultilineLabelDiv">
                <asp:Label ID="SelectItemsMultilineLabel" cssClass="SelectItemsMultilineLabel" runat="server" ></asp:Label>
            </div>
            <asp:HiddenField ID="Selected_items" runat="server" />
            <asp:HiddenField ID="Selected_items_and_decriptions" runat="server" />
            <br /><br />
            <asp:Button ID="FinishedButton" runat="server" Text="Finished" OnClick="FinishedButton_Click" />
        </div>
    </form>
</body>
</html>
