<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Forgot-Password.aspx.cs" Inherits="Aspx_ForgotPassword" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
    <form runat="server" class="generic_form">
        <br />
        <br />
        <p>Enter the email of your registerd account we'll send you a reset password link</p>
        <br />
        <br />
        <p class="generic_error_message" id="Errors" runat="server"></p>
        <input type="text" runat="server" placeholder="Email..." id="emailInput"/><br/>
        <asp:Button id="submitButton" runat="server" Text="Send Email" OnClick="sendRestLink" />
    </form>
</asp:Content>