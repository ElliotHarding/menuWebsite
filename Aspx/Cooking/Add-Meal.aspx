<%@ Page Title="Add Meal" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Add-Meal.aspx.cs" Inherits="Aspx_AddMealPage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
    
    <h2 class="generic_title">Add a meal</h2>

    <p id="Errors" runat="server"></p>

    <a>Meal Name:</a>
    <input id="meal_name" type="text" runat="server"/>
    
    <a>**Picture ID... todo...**</a>
    <input id="picture_id" type="text" runat="server"/>
    
    <a>Number of portions</a>
    <input id="number_of_portions_avaliable" type="text" runat="server"/>

    <a>Is meal Halal?</a>
    <input id="is_halal" type="text" runat="server"/>
    
    <a>Is meal vegan?</a>
    <input id="is_vegan" type="text" runat="server"/>                
    
    <a>Is meal vegiterian?</a>
    <input id="is_vegiterian" type="text" runat="server"/>
    
    <a>Contains milk?</a>
    <input id="contains_milk" type="text" runat="server"/>
    
    <a>Contains gluten?</a>
    <input id="contains_gluten" type="text" runat="server"/>
    
    <a>Ingredients List</a>
    <input id="ingredients_list" type="text" aria-multiline="true" runat="server"/>
    
    <a>Estimated calories</a>
    <input id="estimated_calories" type="text" runat="server"/>

    <a>Price</a>
    <input id="price" type="text" runat="server"/>
    
    <a>What time will the meal be ready for collection?</a>
    <input id="collection_time" type="text" runat="server"/>
    
    <br />
    <br />
    <asp:Button CssClass="generic_asp_button" id="submitButton" runat="server" Text="Submit" OnClick="addMeal" />
</asp:Content>