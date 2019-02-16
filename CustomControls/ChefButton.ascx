<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChefButton.ascx.cs" Inherits="Aspx_ChefButton" %>

<style>

</style>

<fieldset runat="server">    
    <asp:UpdatePanel runat="server" >
        <ContentTemplate runat="server">

            <div class="listButton" runat="server">
                <asp:Image ID="picture" runat="server"/>
                <asp:Label ID="name" runat="server" />   
                <asp:Label ID="rating" runat="server" />
                <asp:Button ID="viewButton" runat="server" UseSubmitBehavior="false" OnClick="viewButton_Click" Text="View" Width="102px"/>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>