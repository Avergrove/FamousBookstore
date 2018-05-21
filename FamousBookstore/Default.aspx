<%@ Page Title="" Language="C#" MasterPageFile="~/FamousBookstore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FamousBookstore.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Resources/CSS/Default.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Image Header-->
    <div class="google">
        <h1>Welcome to Famous Bookstore!</h1>
    </div>

    <!-- Search Area-->
        <div class="form">  
      <form>
        <label for="form-search"></label>
        <input type="text" id="form-search" placeholder="Search for a book by its title!">
      </form>
    </div>  

     <!-- Button -->
    <div class= "buttons">  
      <input type="submit" class="btn" value="Search!" id="search">
    </div>

</asp:Content>
