<%@ Page Title="Login" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Aspx_LoginPage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

        <div class="center_text"><img src="../../media/logo1.png" style="max-height:50%; max-width:100%;"/></div>
        
        <form runat="server" class="generic_form">
            <br />
            <a>Username</a>
            <input type="text" placeholder="Enter username" id="usernameInput" runat="server"/>
            <br />
            <a>Password</a>
            <input type="text" placeholder="Enter Password" id="passwordInput" runat="server"/>
            <br />
            <asp:Button ID="LoginButton" runat="server" CssClass="generic_form_asp_button" Text="Login" OnClick="tryLogin" />
            <br />
            <a href="Forgot-Password.aspx" style="font-size:400%;">Lost your password?</a>
            <br />
            <a href="Sign-Up.aspx" style="font-size:400%;">Don't have an account?</a>
            <p class="generic_error_message" id="Errors" runat="server"></p>            
        </form>

</asp:Content>