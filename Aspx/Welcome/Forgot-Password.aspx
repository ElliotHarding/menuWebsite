<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Forgot-Password.aspx.cs" Inherits="Aspx_ForgotPassword" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
    <br />
    <br />
    <p>Enter the email of your registerd account we'll send you a reset password link</p>
    <br />
    <br />
    <p id="Errors" runat="server"></p>
    <input type="text" runat="server" placeholder="Email..." id="emailInput"/><br/>
    <asp:Button CssClass="generic_asp_button" id="submitButton" runat="server" Text="Send Email" OnClick="sendRestLink" />
    <p id="Successes" runat="server"></p>
</asp:Content>