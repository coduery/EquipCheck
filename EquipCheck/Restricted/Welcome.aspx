<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="EquipCheck.Welcome" MasterPageFile="~/Restricted/Site.Master" %>

<%-- Web page to welcome the user, and display their existing Equipment Checklists and Equipment Lists. --%>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Welcome</title>
</asp:Content>
<asp:Content ID="PageContent" ContentPlaceHolderID="PageContent" runat="server">
    <div>
        <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server"></asp:Label><br />
    </div>
    <div id="LeftLayout">
        <asp:Label ID="ChecklistsLabel" cssClass="BoxLabel" runat="server" Text="Checklists Summary:"></asp:Label><br />
        <asp:TextBox ID="ChecklistsTextBox" cssClass="SummaryTextBox" runat="server" TextMode="MultiLine" Rows="12" ReadOnly="True" onclick="" /><br />
        <asp:Label ID="EquipmentListsLabel" cssClass="BoxLabel" runat="server" Text="Equipment Lists Summary:"></asp:Label><br />
        <asp:TextBox ID="EquipmentListsTextBox" cssClass="SummaryTextBox" runat="server" TextMode="MultiLine" Rows="12" ReadOnly="True" />
    </div>    
</asp:Content>
