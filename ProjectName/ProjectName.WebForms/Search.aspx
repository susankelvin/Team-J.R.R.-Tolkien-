<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Kupuvalnik.WebForms.Search" %>

<asp:Content ID="SearchContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- ScriptManger is in master page --%>

    <div class="container">
        <h2>Search</h2>
        <div class="form-group">
            <asp:Label ID="lblName" runat="server" Text="Name" CssClass="control-label "></asp:Label>
            <asp:TextBox ID="tbName" runat="server" CssClass="form-control " onc></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="control-label "></asp:Label>
            <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAuthor" runat="server" Text="Author" CssClass="control-label "></asp:Label>
            <asp:TextBox ID="tbAuthor" runat="server" CssClass="form-control "></asp:TextBox>
        </div>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-lg" />
    </div>

    <br />
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="SearchGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ComodityId" ItemType="Comodity" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
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
