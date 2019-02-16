<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EatNavigator.ascx.cs" Inherits="CustomControls_EatNavigator" %>

<div>
    <asp:Button 
        style="
            width: 50%;
            height: 9%;
            border: none;
            padding: 0;
            margin: 0;
            top: 0;
            left: 0;
            position: absolute;
            font-size: 300%;
        "
        runat="server"
        Text="Search Meals"
        OnClick="Meals_Click"
        UseSubmitBehavior="false"
    />
    
    <asp:Button     
        style="
            width: 50%;
            height: 9%;
            padding: 0;
            border: none;
            margin: 0;
            top: 0;
            right: 0;
            position: absolute;
            font-size: 300%;
        "
        runat="server"
        Text="Search Chefs"
        OnClick="Chefs_Click"
        UseSubmitBehavior="false"
    />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</div>