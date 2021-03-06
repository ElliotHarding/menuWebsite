﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Search-By-Meals.aspx.cs" Inherits="Aspx_Eat_Search_By_Meals" %>
<%@ Register src="~/CustomControls/MealButton.ascx" tagname="MealButton" tagprefix="CustomControls" %> 
<%@ Register src="~/CustomControls/EatNavigator.ascx" tagname="EatNavigator" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <!-- Script manager to handle populating our custom controls into lists -->
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <CustomControls:EatNavigator runat="server" />

    <p style="text-align:left;">Filter results</p>
    <input ID="SearchBox" type="text" placeholder="Search..." runat="server"/>

    <!-- MealList gets populated by code behind -->
    <p>Meals</p>
    <p id="Errors" runat="server"></p>
    <asp:PlaceHolder id="MealList" runat="server"/> 

</asp:Content>