<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Aspx_ViewOrder" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <p class="generic_title">Meal Name will go here</p>

    <form id="viewOrderForm" runat="server" class="generic_form">

        <p>TODO: get the attributes of a chef and display them here</p>

        <a>attribute1</a>
        <input id="attribute1" type="text" runat="server"/>
        <a>attribute2</a>
        <input id="attribute2" type="text" runat="server"/>
        <a>attribute3</a>
        <input id="attribute3" type="text" runat="server"/>
        
        <p id="ErrorDisplay" class="generic_error_message" runat="server"></p>
            
    </form>

</asp:Content>

