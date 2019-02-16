<%@ Page Title="Home" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Aspx_HomePage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <%-- Height for the navigation boxes --%>
    <style>.height{height : 32%;}</style>

    <div class="generic_navigation_box">
        <div class="generic_navigation_box_option height" onclick="location.href='../Eat/Search-By-Meals.aspx';"><a>Eat</a></div>
        <div class="generic_navigation_box_option height" onclick="location.href='../Cooking/Add-Meal.aspx';"><a>Cook</a></div>
        <div class="generic_navigation_box_option height" onclick="location.href='../Navigation/Account.aspx';"><a>My Account</a></div> 
    </div>
</asp:Content>