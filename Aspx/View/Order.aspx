<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Aspx_ViewOrder" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <asp:Label ID="meal_name" runat="server"></asp:Label>

    <a>Number of portions</a>
    <asp:Label ID="num_portions_ordered" runat="server"></asp:Label>

    <a>Active?</a>
    <asp:Label ID="active" runat="server"></asp:Label>
        
    <p id="ErrorDisplay" class="generic_error_message" runat="server"></p>

</asp:Content>

