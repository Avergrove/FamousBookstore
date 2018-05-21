<%@ Page Title="" Language="C#" MasterPageFile="~/FamousBookstore.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FamousBookstore.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Resources/CSS/Details.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-6"><img src="Resources/Images/placeholder.png" id="book-image"></div>
        <div class="col-md-6">
            <h3 id="title">Book Title</h3>
            <div id="author">Author</div>
            <div id="synopsis">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum</div>
            <div id="price">$9.00</div>
            <div id="quantity">Quantity: <input type="text"/></div>

            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-success"/>

        </div>
    </div>

    <div class="container-fluid">
        <h2>Product Details</h2>
        <div>Author: <span>Avergrove</span></div>
        <div>Name: <span>NUS-ISS- Misadventures of a Computer Science Student Undergraduate</span></div>
        <div>ISBN: <span>136942584</span></div>
        </div>
    </div>

</asp:Content>
