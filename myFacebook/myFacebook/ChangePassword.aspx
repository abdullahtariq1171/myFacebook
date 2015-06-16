<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="myFacebook.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="margin-top:20%;">

    <asp:Literal runat="server" ID="error"></asp:Literal>

    <form id="form1" runat="server">
    <div>
        <fieldset>
            <asp:Label runat="server">Previous Password</asp:Label>
            <asp:TextBox ID="TextBox1" TextMode="Password" runat="server"/>
        </fieldset>
        <fieldset>
            <asp:Label runat="server">New Password</asp:Label>
            <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" />
        </fieldset>    
        <fieldset>
            <asp:Label runat="server">Confirm Password</asp:Label>
            <asp:TextBox ID="TextBox3" TextMode="Password" runat="server" />
        </fieldset>    
        <fieldset>
            <asp:Button Text="Change" OnClick="ChangeMyPassword" class="btn btn-success" runat="server"/>
        </fieldset>
    </div>
    </form>
        </div>
</asp:Content>
