<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Kupuvalnik.WebForms.ComodityDetails.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Comodity.Name %></h1>
    <asp:Image ID="ComodityImage" style="margin-right:400px" CssClass="pull-right" runat="server" ImageUrl='<%# this.Comodity.ImagePath%>'  
               Height="300px" Width="450px" />
    <h3>Description:</h3>
    <p><%: this.Comodity.Name %></p>
    <h3>Price:</h3>
    <p><%: String.Format("{0:c}", this.Comodity.Price) %></p>
    <h3>Sold by:</h3>
    <p><%: this.Comodity.Author.UserName %></p>
    <h3>Posted:</h3>
    <p><%: this.Comodity.DateCreated %></p>
    <h3 class="text-center">Comments: </h3>
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-md-5">
                <asp:TextBox runat="server" ID="CommentText" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CommentText"
                                            CssClass="text-danger" ErrorMessage="The comment field is required." />
            </div>
            <div class="col-md-offset-2 col-md-5">
                <asp:Button runat="server" OnClick="CreateComment_Click" Text="Post Comment" CssClass="btn btn-primary" />
            </div>
        </div>

    </div>
    <asp:Repeater ID="CommentsView" runat="server" ItemType="Kupuvalnik.WebForms.Models.Comment"
                  SelectMethod="CommentsView_GetData">
        <ItemTemplate>
            <div class="well">
                <pre style="border:none">
                <%# Item.Text %>
                </pre>
                <div class="pull-right">by <%# Item.Author.UserName %> on <%# Item.DateCreated %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
