<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Kupuvalnik.WebForms.ComodityDetails.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Comodity.Name %></h1>
    <img src='<%: this.Comodity.ImagePath.TrimStart(new char[]{'/', '~'}) %>' height="150px" width="200px" />
    <h3>Description:</h3>
    <p><%: this.Comodity.Name %></p>
    <h3>Price:</h3>
    <p><%: String.Format("{0:c}", this.Comodity.Price) %></p>
    <h3>Sold by:</h3>
    <p><%: this.Comodity.Author.UserName %></p>
    <h3>Posted:</h3>
    <p><%: this.Comodity.DateCreated %></p>
</asp:Content>
