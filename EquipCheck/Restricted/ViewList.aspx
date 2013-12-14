<%@ Page Title="" Language="C#" MasterPageFile="~/Restricted/Site.Master" AutoEventWireup="true" CodeBehind="ViewList.aspx.cs" Inherits="EquipCheck.ViewList" %>

<%-- Web page to display user's existing Equipment Lists. --%>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>View Equipment List</title>
</asp:Content>
<asp:Content ID="PageContent" ContentPlaceHolderID="PageContent" runat="server">
    <div>
        <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server">View List&nbsp&nbsp&nbsp</asp:Label>
        <asp:DropDownList ID="DropDownList" cssClass="DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
            <asp:ListItem>Camping Equipment</asp:ListItem>
            <asp:ListItem>Camping Clothes</asp:ListItem>
            <asp:ListItem>Camping Food</asp:ListItem>
            <asp:ListItem>Camping Miscellaneous</asp:ListItem>
        </asp:DropDownList><br /><br />
    </div>
    <div>
        <asp:TextBox ID="ViewListTextBox" cssClass="SummaryTextBox" runat="server" TextMode="MultiLine" Rows="30" ReadOnly="True"></asp:TextBox>
    </div>  
</asp:Content>
