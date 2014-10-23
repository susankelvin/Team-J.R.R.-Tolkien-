<%@ Page Title="Contact Kupuvalnik" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Kupuvalnik.WebForms.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <address>
        17585, Pari ne vrashtam str.<br />
        1000 Sofia<br />
        <abbr title="Phone">P:</abbr>
        +359 555 111 222
    </address>

    <h4>E-mail us</h4>
    <address>
        <strong>Support: </strong>
        <a href="mailto:Support@kupuvalnik.com" target="mai">Support@kupuvalnik.com</a><br />
        <strong>Office: </strong>
        <a href="mailto:Office@kupuvalnik.com">Office@kupuvalnik.com</a><br />
    </address>
</asp:Content>
