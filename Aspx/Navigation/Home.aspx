<%@ Page Title="Home" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Aspx_HomePage" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

     <asp:Button runat="server" class="generic_navigation_box_option" style="top:10%; height:27%;" Text="Eat" onclick="Eat_Click"/>
     <asp:Button runat="server" class="generic_navigation_box_option" style="top:40%; height:27%;" Text="Cook" onclick="Cook_Click" />
     <asp:Button runat="server" class="generic_navigation_box_option" style="top:70%; height:27%;" Text="My Account" OnClick="Account_Click" /> 

</asp:Content>