<%@ Page Title="Offers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Kupuvalnik.WebForms.Search" %>

<asp:Content ID="SearchContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- ScriptManger is in master page --%>

    <div class="container">
        <h2 class="text-center">All Offers</h2>
        <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Name" CssClass="control-label "></asp:Label>
            <asp:TextBox ID="tbName" runat="server" CssClass="form-control " ></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="control-label "></asp:Label>
            <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAuthor" runat="server" Text="Author" CssClass="control-label "></asp:Label>
            <asp:TextBox ID="tbAuthor" runat="server" CssClass="form-control "></asp:TextBox>
        </div>
        <div class="form-group">

            <asp:Label runat="server" AssociatedControlID="DropDownListxCategories" CssClass="col-md-2 control-label">Category</asp:Label>

            <asp:DropDownList ID="DropDownListxCategories" runat="server" CssClass="form-control"
                              DataTextField="Name" DataValueField="CategoryId"></asp:DropDownList>

        </div>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-lg" />
    </div>

    <br />
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="SearchGrid" runat="server" AutoGenerateColumns="False"
                          DataKeyNames="ComodityId" ItemType="Comodity"
                          CssClass="table table-bordered" AllowPaging="True" AllowSorting="True"
                          OnPageIndexChanging="SearchGrid_PageIndexChanging"
                          OnSorting ="SearchGrid_Sorting">
                <Columns>
                    <asp:HyperLinkField DataTextField="Name" DataNavigateUrlFields="ComodityId" SortExpression="Name" HeaderText="Product Name" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" SortExpression="Price" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Category" />
                    <asp:BoundField DataField="Author.UserName" HeaderText="Author" />
                </Columns>
                <EmptyDataTemplate>
                    <h3 class="text-info text-center">No results</h3>
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
