<%@ Page Title="" Language="C#" MasterPageFile="~/Restricted/Site.Master" AutoEventWireup="true" CodeBehind="CreateChecklist.aspx.cs" Inherits="EquipCheck.CreateChecklist" %>

<%-- Web page for creating a user's new Equipment Checklist. --%>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Create Checklist</title>
</asp:Content>
<asp:Content ID="PageContent" ContentPlaceHolderID="PageContent" runat="server">
    <div>
        <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server">Create New Checklist</asp:Label>
    </div>
    <div id="LeftLayout">
        <div id="LeftPanel">
            <asp:Label ID="ChecklistNameLabel" cssClass="BoxLabel" runat="server" Text="* Checklist Name:"></asp:Label><br />
            <asp:TextBox ID="ChecklistNameTextBox" cssClass="ChecklistTextBox" runat="server" TabIndex="1"></asp:TextBox><br />
            <asp:Label ID="TripNameLabel" cssClass="BoxLabel" runat="server" Text="Trip Name:"></asp:Label><br />
            <asp:TextBox ID="TripNameTextBox" cssClass="ItemTextBox" runat="server" TabIndex="3"></asp:TextBox><br />
            <asp:Label ID="TripDateLabel" cssClass="BoxLabel" runat="server" Text="Trip Date:"></asp:Label><br />
            <asp:TextBox ID="TripDateTextBox" cssClass="ItemTextBox" runat="server" TabIndex="5"></asp:TextBox><br />
        </div>

        <div id="RightPanel">
            <asp:Label ID="ChecklistDescriptionLabel" cssClass="BoxLabel" runat="server" Text="* Checklist Description:"></asp:Label><br />
            <asp:TextBox ID="ChecklistDescriptionTextBox" cssClass="ItemTextBox" runat="server" TextMode="MultiLine" Rows="3" TabIndex="2"></asp:TextBox><br />
            <asp:Label ID="TripDescriptionLabel" cssClass="BoxLabel" runat="server" Text="Trip Description:"></asp:Label><br />
            <asp:TextBox ID="TripDescriptionTextBox" cssClass="ItemTextBox" runat="server" TextMode="MultiLine" Rows="3" TabIndex="4"></asp:TextBox><br /><br />
        </div>

        <asp:Label ID="ChecklistItemsLabel" cssClass="BoxLabel" runat="server" Text="Checklist Items:"></asp:Label>
        <asp:Button ID="SelectItemsButton" runat="server" Text="Select Items" OnClick="SelectItemsButton_Click" /><br />
        <asp:TextBox ID="ChecklistItemsTextBox" cssClass="SummaryTextBox" runat="server" TextMode="MultiLine" Rows="12" ReadOnly="True"></asp:TextBox><br /><br />
        <asp:Button ID="SaveChecklistButton" runat="server" Text="Save Checklist" OnClick="SaveChecklistButton_Click" />
        <asp:Label ID="RequiredEntryLabel" cssClass="RequiredEntryBoxLabel" runat="server" Text="* - Required Entry"></asp:Label>
    </div>  
</asp:Content>