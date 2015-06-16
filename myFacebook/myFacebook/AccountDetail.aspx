<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountDetail.aspx.cs" Inherits="myFacebook.AccountDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facebook</title>
    <link href="Scripts/bootstrap.min.css" rel="stylesheet" />

   
</head>
<body>



    <div class="row" style="margin-top:20%;">
        <div class="col-md-2 col-md-offset-5">
             <form id="form1" runat="server">
        
                <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-default btn-lg"/>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadImages" class="btn btn-primary btn-lg"/>
                 <asp:Literal ID="errorShow" runat="server"></asp:Literal>
            </form>
        </div>
    </div>
<%--       <form id="form1" runat="server">
        
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadImages" />
       
        </form>--%>
</body>
</html>

