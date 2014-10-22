<%@ Page Title="Add Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Kupuvalnik.WebForms.Admin.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger bg-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <p class="text-success bg-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Add a new category</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="NewCategory" CssClass="col-md-2 control-label">Category Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="NewCategory" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewCategory"
                                            CssClass="text-danger" ErrorMessage="The category name field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="AddCategory_Click" Text="Add" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="form-group">

            <asp:Label runat="server" AssociatedControlID="DropDownListxCategories" CssClass="col-md-2 control-label">All Categories</asp:Label>
            <div class="col-md-10">

                <asp:DropDownList ID="DropDownListxCategories" runat="server" CssClass="form-control"
                    DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>
            </div>
        </div>
    </div>
</asp:Content>
