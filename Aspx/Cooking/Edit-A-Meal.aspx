<%@ Page Title="Edit Meal" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="false" CodeFile="Edit-A-Meal.aspx.cs" Inherits="Aspx_EditMeal" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <p>TODO: get the attributes of a meal and display them here in editable boxes</p>
    <input class="generic_title" id="meal_name" runat="server"/>

    <p id="Errors" runat="server"></p>
    <p id="Successes" runat="server"></p>
       
    <asp:Button CssClass="generic_asp_button" id="EditMealButton" runat="server" Text="Edit meal" OnClick="editMeal" />

</asp:Content>

