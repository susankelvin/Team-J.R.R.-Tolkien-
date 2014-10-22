<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Kupuvalnik.WebForms.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <h2>Search</h2>
            <div class="form-group">
                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="control-label "></asp:Label>
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control "></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="control-label "></asp:Label>
                <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAuthor" runat="server" Text="Author" CssClass="control-label "></asp:Label>
                <asp:TextBox ID="tbAuthor" runat="server" CssClass="form-control "></asp:TextBox>
            </div>
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-lg" />
        </div>


</asp:Content>
