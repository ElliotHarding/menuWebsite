<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Aspx_UserOrders" %>
<%@ Register src="~/CustomControls/OrderButton.ascx" tagname="OrderButton" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <!-- PAGE PURPOSE: Display a users orders -->
    <p class="generic_title"><b>Your Orders</b></p>
    
    <form runat="server" >

        <p class="generic_text_a" id="infoMessage" runat="server"></p>

        <asp:ScriptManager runat="server"></asp:ScriptManager>   
        <!-- OrderList gets populated by code behind -->
        <asp:PlaceHolder id="OrderList" runat="server"/> 

    </form>

</asp:Content>