<%@ Page Title="Meal Added!" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Meal-Added.aspx.cs" Inherits="Aspx_AfterMealAdditionPage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
    <p class="generic_title"><b>Your meal has been added!</b></p>
    
    <div class="generic_navigation_box">
         <div class="">
            <a>Here's your new meal information: </a>
            <p></p>
            <p></p>
            <p></p> <%--todo...--%>
            <p></p>
            <p></p>
            <p></p>
         </div>
        <div class="" onclick="location.href='Add-Meal.aspx';"><a>Another</a></div>
        <div class="" onclick="location.href='../Navigation/Home.aspx';"><a>Home</a></div>
    </div>
</asp:Content>