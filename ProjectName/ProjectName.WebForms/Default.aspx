<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kupuvalnik.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Latest Offers</h2>

        <asp:GridView ID="LatestOffers" runat="server"
            AutoGenerateColumns="False" DataKeyNames="ComodityID">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Product Name"  />
                <asp:BoundField DataField="Description" HeaderText="Description"  />
                <asp:BoundField DataField="Price" HeaderText="Price"  />
                <asp:BoundField DataField="Category.Name" HeaderText="Category"  />
                <%--<asp:BoundField DataField="Image" HeaderText="Photo"  />--%>
            </Columns>
        </asp:GridView>
    </div>

   
</asp:Content>
