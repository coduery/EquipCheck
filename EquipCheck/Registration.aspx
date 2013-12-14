<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EquipCheck.Registration" %>

<%-- Web page to display Equipment Checklist Application Registration web page. --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link rel="stylesheet" type="text/css" href="Restricted/Styles.css" />
</head>
<body>
    <form id="RegistrationForm" runat="server">
        <div>
            <asp:Label ID="PageHeaderLabel" runat="server" Text="Equipment Checklist Application"></asp:Label><br />
            <asp:Label ID="PageNameLabel" cssClass="PageNameLabel" runat="server" Text="User Registration"></asp:Label><br /><br />
        </div>
        <div id="LeftLayout">
            <asp:CreateUserWizard ID="CreateUserWizard" runat="server" OnContinueButtonClick="CreateUserWizard_ContinueButtonClick" 
                OnCreatedUser="CreateUserWizard_CreatedUser" OnCreatingUser="CreateUserWizard_CreatingUser" CompleteSuccessText="Your account has been successfully created. Please login." >
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep" runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep" runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </div>
    </form>
</body>
</html>
