<%@ Page Title="Meal Added!" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Meal-Added.aspx.cs" Inherits="Aspx_AfterMealAdditionPage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
    
    <p class="generic_title" style="top:15%; height:30%;">Your meal has been added!</p>

    <asp:Button class="generic_navigation_box_option" runat="server" style="top:30%; height:30%;" Text="Another" OnClick="Another_Click" />
    <asp:Button class="generic_navigation_box_option" runat="server" style="top:65%; height:30%;" Text="Home" OnClick="Home_Click" />

</asp:Content>