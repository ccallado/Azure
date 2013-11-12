<%@ Page Title="Administrar Password" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdminPassword.aspx.cs" Inherits="AdminPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BackColor="#F7F6F3" 
                BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="Verdana" Font-Size="0.8em">
                <SubmitButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#284775" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <SuccessTextStyle Font-Bold="True" ForeColor="#5D7B9D" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                    ForeColor="White" />
            </asp:PasswordRecovery>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F6F3" 
                BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="Verdana" Font-Size="0.8em">
                <CancelButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#284775" />
                <ChangePasswordButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#284775" />
                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#284775" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                    ForeColor="White" />
            </asp:ChangePassword>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
