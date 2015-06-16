<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="BlockedMsg.aspx.cs" Inherits="myFacebook.BlockedMsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container success" style="margin-top:50px;">
        <div class="jumbotron">
            <h2 class="text-center">Blocked</h2>
            <form id="form1" runat="server" class="text-center">
                <asp:Button class="btn btn-primary center-block" ID="btnTransfer" OnClick="btnTransfer_Click" runat="server" Text="Home"/>
                </form>
        </div>
    </div>
</asp:Content>
