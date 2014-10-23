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
    <h3>
        Comments:
        <input class="btn btn-primary" type="button" name="Post Comment" id="PostCommentTootleButton" value="Post Comment" onclick="show()"/>
    </h3>
    <div id="CommentContainer"class="form-horizontal">
        <div class="form-group col-md-12">
            <div class="col-md-7">
                <asp:TextBox runat="server" ID="CommentText" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CommentText"
                                            CssClass="text-danger" ErrorMessage="The comment field is required." />
            </div>
            <div class="col-md-offset-2 col-md-5 pull-right" >
                <asp:Button runat="server" OnClick="CreateComment_Click" Text="Post" CssClass="btn btn-primary" />
                <input class="btn btn-primary" type="button" value="Cancel" onclick="hide()" />
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
    <script>
        $("#CommentContainer").hide();
        function hide() {
            $("#CommentContainer").hide();
            $("#PostCommentTootleButton").show();
        }

        function show() {
            $("#CommentContainer").show();
            $("#PostCommentTootleButton").hide();
        }
    </script>
</asp:Content>
