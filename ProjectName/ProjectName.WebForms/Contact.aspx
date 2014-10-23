<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Kupuvalnik.WebForms.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Kupuvalnik Contacts.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support: </strong>
        <a href="">Support@kupuvalnik.com</a><br />
        <strong>Office: </strong>
        <a href="">Office@kupuvalnik.com</a><br />
    </address>
</asp:Content>
