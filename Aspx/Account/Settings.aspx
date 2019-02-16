<%@ Page Title="Your Settings" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Aspx_UserSettings" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <!-- PAGE PURPOSE: Display a users settings -->
    
    <p class="generic_title"><b>Your Settings</b></p>

    <form runat="server" class="generic_form" id="updateUserForm">  
        
        <p class="generic_error_message" id="Errors" runat="server"></p>

        <p>Settings will be displayed here</p>
        <br />
        <asp:button runat="server" onclick="LogOut" Text="Log out" />
        <asp:Button id="submitButton" runat="server" Text="Submit" OnClick="OnSubmit"/>
    </form>
</asp:Content>