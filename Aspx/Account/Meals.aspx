<%@ Page Title="My Meals" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" CodeFile="Meals.aspx.cs" Inherits="Aspx_UserMeals" EnableEventValidation="false" %>
<%@ Register src="~/CustomControls/MealButton.ascx" tagname="MealButton" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <!-- PAGE PURPOSE: Display a users meals -->

    <p class="generic_title"><b>Your Meals</b></p>
    <br />
        
    <form runat="server" >

        <p class="generic_text_a" id="infoMessage" runat="server"></p>

        <asp:ScriptManager runat="server"></asp:ScriptManager>   
        <!-- MealList gets populated by code behind -->
        <asp:PlaceHolder id="MealList" runat="server"/> 

    </form>
   
</asp:Content>

