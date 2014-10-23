<%@ Page Title="Unauthorized" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Unauthorized.aspx.cs" Inherits="Kupuvalnik.WebForms.Unauthorized" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center">You are not authorized to view this page. Please <a href="Account/Login">log in </a> to see this page!</h3>
    <h3 class="text-center"> If you do not have account yet, please <a href="Account/Register">sing up </a>here</h3>
</asp:Content>
