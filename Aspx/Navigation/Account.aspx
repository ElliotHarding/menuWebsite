<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Aspx_UserAccount" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
  
    <div class="generic_navigation_box">
        <asp:Button class="generic_navigation_box_option" runat="server" Text="My Orders" OnClick="Orders_Click" />
        <asp:Button class="generic_navigation_box_option" runat="server" Text="My Meals" OnClick="Meals_Click" />
        <asp:Button class="generic_navigation_box_option" runat="server" Text="Settings" OnClick="Settings_Click"/>
    </div>
</asp:Content>