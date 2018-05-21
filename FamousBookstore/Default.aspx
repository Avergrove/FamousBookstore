<%@ Page Title="" Language="C#" MasterPageFile="~/FamousBookstore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FamousBookstore.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Resources/CSS/Default.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Image Header-->
    <div class="google">
        <h1>Welcome to Famous Bookstore!</h1>
        <h2>Only the most mind-gripping and gut clenching for the reader in you!</h2>
    </div>

    <!-- Search Area-->
    <div class="middleAlign">
    <asp:TextBox ID="TextBox1" runat="server" placeholder="Search for a book by title!"></asp:TextBox>
    </div>


     <!-- Button -->
    <div class= "buttons">  
      <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Search" />
    </div>

</asp:Content>
