<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Search-By-Meals.aspx.cs" Inherits="Aspx_Eat_Search_By_Meals" %>
<%@ Register src="~/CustomControls/MealButton.ascx" tagname="MealButton" tagprefix="CustomControls" %> 
<%@ Register src="~/CustomControls/EatNavigator.ascx" tagname="EatNavigator" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <form class="generic_form" runat="server">

        <!-- Script manager to handle populating our custom controls into lists -->
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <CustomControls:EatNavigator runat="server" />

        <p class="generic_form_p generic_error_message" id="Errors" runat="server"></p>

        <p style="text-align:left;">Filter results</p>
        <input ID="SearchBox" type="text" placeholder="Search..." runat="server"/>
        <br />
        <br />
        <br />

        <!-- MealList gets populated by code behind -->
        <p>Meals</p>
        <asp:PlaceHolder id="MealList" runat="server"/> 

    </form>

</asp:Content>