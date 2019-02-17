<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Chef.aspx.cs" Inherits="Aspx_ViewChef" %>
<%@ Register src="~/CustomControls/MealButton.ascx" tagname="MealButton" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <h2 ID="name" runat="server"></h2>

    <asp:Image ID="ChefImage" runat="server" />
    <p id="Errors" runat="server"></p>

    <asp:Label ID="rating" runat="server"></asp:Label>

    <br />
    <br />
<!-------- Below is for dispaying a list of meals that the chef 'owns' ---------->

    <!-- Script manager to handle populating our custom controls into lists -->
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <input ID="SearchBox" type="text" placeholder="Search meals..." runat="server"/>
    <br />

    <!-- MealList gets populated by code behind -->  
    <asp:PlaceHolder id="MealList" runat="server"/>     

</asp:Content>

