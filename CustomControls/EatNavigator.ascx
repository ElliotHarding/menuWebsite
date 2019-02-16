<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EatNavigator.ascx.cs" Inherits="CustomControls_EatNavigator" %>

<div>
    <asp:Button 
        style="
            display:inline-block;
            width: 49%;
            height: 9%;
            border: none;
            padding: 0;
            margin: 0;
            font-size: var(--font-big);
        "
        runat="server"
        Text="Search Meals"
        OnClick="Meals_Click"
        UseSubmitBehavior="false"
    />
    
    <asp:Button     
        style="
            display:inline-block;
            width: 49%;
            height: 9%;
            padding: 0;
            border: none;
            font-size: var(--font-big);
        "
        runat="server"
        Text="Search Chefs"
        OnClick="Chefs_Click"
        UseSubmitBehavior="false"
    />
    <br />
    <br />
</div>