<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Aspx_UserAccount" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <%-- Height for the navigation boxes --%>
    <style>.height{height : 32%;}</style>
    
    <div class="generic_navigation_box">
        <div class="generic_navigation_box_option height" onclick="location.href='../Account/Orders.aspx';"><a>My Orders</a></div>
        <div class="generic_navigation_box_option height" onclick="location.href='../Account/Meals.aspx';"><a>My Meals</a></div>
        <div class="generic_navigation_box_option height" onclick="location.href='../Account/Settings.aspx';"><a>Settings</a></div> 
    </div>
</asp:Content>