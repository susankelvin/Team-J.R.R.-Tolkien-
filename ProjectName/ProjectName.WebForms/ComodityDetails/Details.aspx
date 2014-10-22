<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Kupuvalnik.WebForms.ComodityDetails.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Comodity.Name %></h1>
    <img class="pull-right" style="margin-right:500px" src='<%: this.Comodity.ImagePath.TrimStart(new char[]{'/', '~'}) %>' height="300px" width="350px" />
    <h3>Description:</h3>
    <p><%: this.Comodity.Name %></p>
    <h3>Price:</h3>
    <p><%: String.Format("{0:c}", this.Comodity.Price) %></p>
    <h3>Sold by:</h3>
    <p><%: this.Comodity.Author.UserName %></p>
    <h3>Posted:</h3>
    <p><%: this.Comodity.DateCreated %></p>
</asp:Content>
