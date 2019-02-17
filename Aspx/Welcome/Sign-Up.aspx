<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Aspx/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Sign-Up.aspx.cs" Inherits="Aspx_SignUp" %>

<asp:Content ContentPlaceHolderID="Main_Content_Placeholder" Runat="Server">
    
    <h2>Enter your new account details</h2>

    <p id="Errors" runat="server"></p>
    
    <a>Username</a>
    <input id="name" type="text" runat="server"/>

    <a>Password</a>
    <input id="password" type="text" runat="server"/>

    <a>Full name</a>
    <input id="full_name" type="text" runat="server"/>

    <a>Birth-date</a>
    <input id="date_of_birth" type="text" runat="server"/>


    <p>Address</p>

    <a>Address line 1</a>
    <input id="address_line_1" type="text" runat="server"/>

    <a>Address line 2</a>
    <input id="address_line_2" type="text" runat="server"/>

    <a>Address City</a>
    <input id="address_city" type="text" runat="server"/>

    <a>Address post code</a>
    <input id="address_post_code" type="text" runat="server"/>

    <a>Address description</a>
    <input id="address_description" type="text" runat="server"/>


    <p>Contact</p>

    <a>Email</a>
    <input id="contact_email" type="text" runat="server"/>

    <a>Phone</a>
    <input id="contact_phone" type="text" runat="server"/>


    <p>Details</p>

    <a>Additional Info</a>
    <input id="additional_info" type="text" runat="server"/>

    <a>Photo</a>
    <asp:FileUpload ID="photo_upload" runat="server" />

    <br />
    <br />
    <asp:Button CssClass="generic_asp_button" id="submitButton" runat="server" Text="Submit" OnClick="signUpButtonClicked" />
</asp:Content>

