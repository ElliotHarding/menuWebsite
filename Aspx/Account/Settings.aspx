<%@ Page Title="Your Settings" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Aspx_UserSettings" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <!-- PAGE PURPOSE: Display a users settings -->
    
    <h2>Your Settings</h2>

    <p id="Errors" runat="server"></p>

    <p>Settings will be displayed here</p>

    <asp:button CssClass="generic_asp_button" runat="server" onclick="LogOut" Text="Log out" />
    <asp:Button CssClass="generic_asp_button" id="submitButton" runat="server" Text="Submit" OnClick="OnSubmit"/>
</asp:Content>