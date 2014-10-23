<%@ Page Title="Approve Offer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveOffer.aspx.cs" Inherits="Kupuvalnik.WebForms.Admin.ApproveOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2 class="text-center">Offers for approvement</h2>

        <asp:GridView ID="ApprovementOffers" runat="server"
                      AutoGenerateColumns="False" DataKeyNames="ComodityID"
                      AllowPaging="True"
                      onrowcommand="TaskGridView_RowUpdating"
                      CssClass="table table-bordered"
                      OnPageIndexChanging="ApprovementOffers_PageIndexChanging">
            <EmptyDataTemplate >
                <div class="text-center"> No offers for approving</div>
            </EmptyDataTemplate>
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
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField  HeaderText="Photo" >
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# (Container.DataItem as Kupuvalnik.WebForms.Models.Comodity).ImagePath%>'  
                                   Height="150px" Width="200px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ButtonField  buttontype="Link"
                                  commandname="Approve" 
                                  text="Approve">
                </asp:ButtonField>

                <asp:ButtonField  buttontype="Link"
                                  commandname="Remove" 
                                  text="Remove">
                </asp:ButtonField>
            </Columns>

        </asp:GridView>

    </div>
</asp:Content>
