<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kupuvalnik.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 class="text-center" >Latest Offers</h2>

        <asp:GridView  ID="LatestOffers" runat="server"
                      AutoGenerateColumns="False" DataKeyNames="ComodityID"
                    CssClass="table table-bordered">
            <Columns>
                <asp:HyperLinkField DataTextField="Name" DataNavigateUrlFields="ComodityId" HeaderText="Product Name" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="Price"  >
                    <ItemTemplate>
                        
                    <%#: String.Format("{0:c}", (Container.DataItem as Kupuvalnik.WebForms.Models.Comodity).Price) %>

                    </ItemTemplate>
                </asp:TemplateField>
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
