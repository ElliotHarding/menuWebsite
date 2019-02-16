<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Search-By-Chefs.aspx.cs" Inherits="Aspx_Eat_Search_By_Chefs" %>
<%@ Register src="~/CustomControls/ChefButton.ascx" tagname="ChefButton" tagprefix="CustomControls" %> 
<%@ Register src="~/CustomControls/EatNavigator.ascx" tagname="EatNavigator" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <!-- Script manager to handle populating our custom controls -->
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <CustomControls:EatNavigator runat="server" />

    <p style="text-align:left;">Filter results</p>
    <input ID="SearchBox" type="text" placeholder="Search..." runat="server" onkeyup="ViewChefs" />

    <!-- ChefsList gets populated by code behind -->
    <p>Chefs</p>
    <p id="Errors" runat="server"></p>
    <asp:PlaceHolder id="ChefsList" runat="server"/>

</asp:Content>