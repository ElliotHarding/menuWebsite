<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administration.aspx.cs" Inherits="Aspx_Administration" %>

<style>
.adminForm{
    overflow:auto;
}
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administration</title>
</head>
<body>
   <form class="adminForm" runat="server">

       <div ID="showToOnlyAdmin" runat="server" visible="false">
        
            <%--SQL DATA SOURCES--%>

            <%-- <asp:SqlDataSource ID="databaseUsers" runat="server" ConnectionString="todo" UpdateCommand="UPDATE [profiles] SET [password] = @password, [email] = @email, [phone] = @phone, [basketList] = @basketList, [Address] = @Address, [postCode] = @postCode WHERE [username] = @username" DeleteCommand="DELETE FROM [profiles] WHERE [username] = @username" SelectCommand="SELECT * FROM [profiles]" InsertCommand="INSERT INTO [profiles] ([username], [password], [email], [phone], [basketList], [Address], [postCode]) VALUES (@username, @password, @email, @phone, @basketList, @Address, @postCode)">
            </asp:SqlDataSource>

            <asp:SqlDataSource ID="databaseMeals" runat="server" ConnectionString="<%$ ConnectionStrings:database %>" UpdateCommand="UPDATE [products] SET  [name] =@name, [sDesciption] = @sDesciption, [lDesciption] = @lDesciption, [imgUrl] = @imgUrl, [price] = @price, [vegiterian] = @vegiterian, [calories] = @calories WHERE [Id] = @Id" DeleteCommand="DELETE FROM [products] WHERE [id]=@id;" SelectCommand="SELECT * FROM [products]">
            </asp:SqlDataSource>--%>

            <%--END SQL DATA SOURCES--%>

            <h2 style="text-align:center;">Accounts</h2>
            <asp:GridView ID="UsersGridView" runat="server"></asp:GridView>
        
            <h2 style="text-align:center;">Meals</h2>
            <asp:GridView ID="MealsGridView" runat="server"></asp:GridView>

            <h2 style="text-align:center;">Active Orders</h2>
            <asp:GridView ID="ActiveOrdersGridView" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>