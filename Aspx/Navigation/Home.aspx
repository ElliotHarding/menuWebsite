<%@ Page Title="Home" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Aspx_HomePage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <div class="generic_navigation_box">
        <asp:Button runat="server" class="generic_navigation_box_option" Text="Eat" onclick="Eat_Click"/>
        <asp:Button runat="server" class="generic_navigation_box_option" Text="Cook" onclick="Cook_Click" />
        <asp:Button runat="server" class="generic_navigation_box_option" Text="My Account" OnClick="Account_Click" /> 
    </div>
</asp:Content>