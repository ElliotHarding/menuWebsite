<%@ Page Title="Meal" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Meal.aspx.cs" Inherits="Aspx_ViewMeal" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
   
    <p>TODO: get the attributes of a chef and display them here</p>
    <p id="Errors" runat="server"></p>

    <asp:Image ID="MealImage" runat="server" />

    <a>attribute1</a>
    <input id="attribute1" type="text" runat="server"/>
    <a>attribute2</a>
    <input id="attribute2" type="text" runat="server"/>
    <a>attribute3</a>
    <input id="attribute3" type="text" runat="server"/>
    <br />
    <br />
    <br />

    <a>Portions</a>
    <input id="Portions" type="text" runat="server" />
    <br />
    <asp:Button CssClass="generic_asp_button" id="orderMealButton" runat="server" Text="Order meal" OnClick="orderMeal" />
</asp:Content>