<%@ Page Title="" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Chef.aspx.cs" Inherits="Aspx_ViewChef" %>
<%@ Register src="~/CustomControls/MealButton.ascx" tagname="MealButton" tagprefix="CustomControls" %> 

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">

    <p>TODO: get the attributes of a chef and display them here</p>

    <asp:Image ID="ChefImage" runat="server" />

    <p id="Errors" runat="server"></p>

    <a>attribute1</a>
    <input id="attribute1" type="text" runat="server"/>
    <a>attribute2</a>
    <input id="attribute2" type="text" runat="server"/>
    <a>attribute3</a>
    <input id="attribute3" type="text" runat="server"/>

    <br />
    <br />
<!-------- Below is for dispaying a list of meals that the chef 'owns' ---------->

    <!-- Script manager to handle populating our custom controls into lists -->
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <p>Filter results when searching meals that chef owns</p>
    <input ID="SearchBox" type="text" placeholder="Search meals..." runat="server"/>
    <br />

    <!-- MealList gets populated by code behind -->  
    <p>List of meals that the chef owns:</p>
    <asp:PlaceHolder id="MealList" runat="server"/>     

</asp:Content>

