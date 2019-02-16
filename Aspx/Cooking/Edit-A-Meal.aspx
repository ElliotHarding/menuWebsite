<%@ Page Title="Edit Meal" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="false" CodeFile="Edit-A-Meal.aspx.cs" Inherits="Aspx_EditMeal" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <form id="updateMealForm" runat="server" class="generic_form">
        
        <p>TODO: get the attributes of a meal and display them here in editable boxes</p>
        <input class="generic_title" id="meal_name" runat="server"/>

        <p class="generic_error_message" id="Errors" runat="server"></p>
        <p class="generic_success_message" id="Successes" runat="server"></p>
       
        <asp:Button id="EditMealButton" runat="server" Text="Edit meal" OnClick="editMeal" />
        
    </form>

</asp:Content>

