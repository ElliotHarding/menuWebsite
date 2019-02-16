<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Aspx_UserAccount" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
  
    <asp:Button class="generic_navigation_box_option" runat="server" style="top:10%; height:27%;" Text="My Orders" OnClick="Orders_Click" />
    <asp:Button class="generic_navigation_box_option" runat="server" style="top:40%; height:27%;" Text="My Meals" OnClick="Meals_Click" />
    <asp:Button class="generic_navigation_box_option" runat="server" style="top:70%; height:27%;" Text="Settings" OnClick="Settings_Click"/>

</asp:Content>