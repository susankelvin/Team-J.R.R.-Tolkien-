﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kupuvalnik.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h>Latest Offers</h>

        <asp:GridView ID="LatestOffers" runat="server"
                      AutoGenerateColumns="False" DataKeyNames="ComodityID">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Product Name" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Price" HeaderText="Price"  />
                <asp:BoundField DataField="Category.Name" HeaderText="Category"  >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField  HeaderText="Photo" >
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# (Container.DataItem as Kupuvalnik.WebForms.Models.Comodity).ImagePath%>'  
                                   Height="150px" Width="200px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
