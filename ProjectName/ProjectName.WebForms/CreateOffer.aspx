<%@ Page Title="Create Offer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOffer.aspx.cs" Inherits="Kupuvalnik.WebForms.CreateOffer" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger bg-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <p class="text-success bg-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new offer</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                            CssClass="text-danger" ErrorMessage="The name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                                            CssClass="text-danger" ErrorMessage="The price field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                                            CssClass="text-danger" ErrorMessage="The description field is required." />
            </div>
        </div>
        <div class="form-group">

            <asp:Label runat="server" AssociatedControlID="DropDownListxCategories" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">

                <asp:DropDownList ID="DropDownListxCategories" runat="server" CssClass="form-control"
                                  DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListxCategories"
                                            CssClass="text-danger" ErrorMessage="The category field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FileUploadControl" CssClass="col-md-2 control-label">Image:</asp:Label>
            <div class="col-md-10">
                <asp:FileUpload ID="FileUploadControl" runat="server" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FileUploadControl"
                  CssClass ="text-danger"  ErrorMessage="The image  field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateOffer_Click" Text="Create" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
