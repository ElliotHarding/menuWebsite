<%@ Page Title="My Meals" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" CodeFile="Meals.aspx.cs" Inherits="Aspx_UserMeals" EnableEventValidation="false" %>
<%@ Register src="~/CustomControls/MealButton.ascx" tagname="MealButton" tagprefix="CustomControls" %> 
            
<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
        <!-- PAGE PURPOSE: Display a users meals -->

    <h2>Your Meals</h2>
        
    <a id="infoMessage" runat="server"></a>

    <asp:ScriptManager runat="server"></asp:ScriptManager>   
    <!-- MealList gets populated by code behind -->
    <asp:PlaceHolder id="MealList" runat="server"/> 
   
</asp:Content>

