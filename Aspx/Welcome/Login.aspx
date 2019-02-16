<%@ Page Title="Login" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Aspx_LoginPage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <div class="center_text"><img src="../../media/logo1.png" style="max-height:50%; max-width:100%;"/></div>
    <br />

    <a>Username</a>
    <input type="text" placeholder="Enter username" id="usernameInput" runat="server"/>
    <br />

    <a>Password</a>
    <input type="text" placeholder="Enter Password" id="passwordInput" runat="server"/>
    <br />

    <p id="Errors" runat="server"></p>
    
    <asp:Button CssClass="generic_asp_button" ID="LoginButton" runat="server" Text="Login" OnClick="tryLogin" />
    <br />
    <a href="Forgot-Password.aspx" style="font-size:400%;">Lost your password?</a>
    <br />
    <a href="Sign-Up.aspx" style="font-size:400%;">Don't have an account?</a>
    
</asp:Content>