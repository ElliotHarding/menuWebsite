<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderButton.ascx.cs" Inherits="Aspx_OrderButton" %>

<style>

</style>

<asp:UpdatePanel runat="server" >
    <ContentTemplate runat="server">

        <div class="listButton" runat="server">
            <asp:Image ID="picture" runat="server" />
            <asp:Label ID="name" runat="server"/>        
            <asp:Label ID="date" runat="server"/>
            <asp:Button ID="viewButton" runat="server" UseSubmitBehavior="false" OnClick="viewButton_Click" Text="View" Width="102px"/>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
