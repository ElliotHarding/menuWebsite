<%@ Page Title="Meal" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Meal.aspx.cs" Inherits="Aspx_ViewMeal" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
   
    <h2 runat="server" id="meal_name"></h2>

    <asp:Image ID="MealImage" runat="server" />

    <p id="Errors" runat="server"></p>
      
    <a>Number of avaliable portions</a>
    <asp:Label ID="number_of_portions_avaliable" runat="server"></asp:Label>

    <a>Is meal Halal?</a>
    <asp:Label ID="is_halal" runat="server"></asp:Label>
    
    <a>Is meal vegan?</a>  
    <asp:Label ID="is_vegan" runat="server"></asp:Label>
    
    <a>Is meal vegiterian?</a>
    <asp:Label ID="is_vegiterian" runat="server"></asp:Label>
    
    <a>Contains milk?</a>
    <asp:Label ID="contains_milk" runat="server"></asp:Label>
    
    <a>Contains gluten?</a>
    <asp:Label ID="contains_gluten" runat="server"></asp:Label>
    
    <a>Ingredients List</a>
    <asp:Label ID="ingredients_list" runat="server"></asp:Label>
    
    <a>Estimated calories</a>
    <asp:Label ID="estimated_calories" runat="server"></asp:Label>

    <a>Price</a>
    <asp:Label ID="price" runat="server"></asp:Label>
    
    <a>What time will the meal be ready for collection?</a>
    <asp:Label ID="collection_time" runat="server"></asp:Label>


    <br />
    <br />
    <br />
    <a>Portions</a>
    <input id="Portions" type="text" runat="server" />
    <br />
    <asp:Button CssClass="generic_asp_button" id="orderMealButton" runat="server" Text="Order meal" OnClick="orderMeal" />
</asp:Content>