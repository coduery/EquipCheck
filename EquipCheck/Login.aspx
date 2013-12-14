<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EquipCheck.Login" %>

<%-- Web page to display Equipment Checklist Application Login web page. --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Restricted/Styles.css" />
</head>
<body>
    <form id="LoginForm" runat="server">
        <div>
            <asp:Label ID="PageHeaderLabel" cssClass="PageHeaderLabel" runat="server" Text="Equipment Checklist Application"></asp:Label><br />
            <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server" Text="User Login"></asp:Label><br />
        </div>
        <div id="LeftLayout">
            <asp:Login ID="EquipCheckLoginCtrl" runat="server" OnAuthenticate="EquipCheckLoginCtrl_Authenticate" 
                LabelStyle-CssClass="BoxLabel" CreateUserText="Register" CreateUserUrl="~/Registration.aspx" 
                TitleText="" DisplayRememberMe="false" UserNameLabelText="Username:" TextLayout="TextOnTop">
                <LoginButtonStyle CssClass="LoginButton" />
            </asp:Login>
        </div>
    </form>
</body>
</html>
