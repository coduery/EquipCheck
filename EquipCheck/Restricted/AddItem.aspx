<%@ Page Title="" Language="C#" MasterPageFile="~/Restricted/Site.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="EquipCheck.AddItem" %>

<%-- Web page for adding a new Equipment Item to an Equipment List. --%>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>View List</title>
</asp:Content>
<asp:Content ID="PageContent" ContentPlaceHolderID="PageContent" runat="server">
    <div>
        <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server">Add Item to Equipment List</asp:Label>
    </div>
    <div id="LeftLayout">
        <asp:Label ID="SelectListLabel" cssClass="BoxLabel" runat="server" Text="* Equipment List:"></asp:Label><br />
        <asp:DropDownList ID="DropDownList" cssClass="DropDownList" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Camping Equipment</asp:ListItem>
            <asp:ListItem>Camping Clothes</asp:ListItem>
            <asp:ListItem>Camping Food</asp:ListItem>
            <asp:ListItem>Camping Miscellaneous</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="ItemNameLabel" cssClass="BoxLabel" runat="server" Text="* Item Name:"></asp:Label><br />
        <asp:TextBox ID="ItemNameTextBox" cssClass="ItemTextBox" runat="server"></asp:TextBox><br />
        <asp:Label ID="ItemDescriptionLabel" cssClass="BoxLabel" runat="server" Text="* Item Description:"></asp:Label><br />
        <asp:TextBox ID="ItemDescriptionTextBox" cssClass="ItemTextBox" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox><br /><br />
        <asp:Label ID="RequiredEntryLabel" cssClass="BoxLabel" runat="server" Text="* - Required Entry"></asp:Label><br /><br /><br />
        <asp:Button ID="SaveItemButton" runat="server" Text="Save Item" OnClick="SaveItemButton_Click" />
    </div>  
</asp:Content>