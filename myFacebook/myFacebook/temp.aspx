<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="myFacebook.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Facebook</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        
<%--		<asp:Panel id="loginPanel" DefaultButton="loginSubmit" Runat="Server">	
			<asp:TextBox Width="178px" id="email" runat="server" />
			<asp:TextBox Width="178px" id="password" runat="server" TextMode="Password" />
			<asp:imagebutton id="loginSubmit" onclick="loginSubmit_Click" runat="server" ImageUrl="images/login.gif"/>	
		</asp:Panel>

		<asp:Panel id="signupPanel" DefaultButton="Submit" Runat="Server">		
				<asp:TextBox Width="240px" id="FName" runat="server" />
				<asp:TextBox Width="240px" id="LName" runat="server" />
				<asp:imagebutton id="Submit" onclick="Submit_Click" runat="server" ImageUrl="images/signup.gif"/>
		</asp:Panel>--%>
		
    
<%--
        file upload working
    
            <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadImages" />
        <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
            <Columns>
                <asp:BoundField DataField="Text" />
                <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
            </Columns>
        </asp:GridView>
        --%>

            <asp:ScriptManager runat="server" ID="scriptMgr1">

            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <input id="Text1" type="text" runat="server" />
                <asp:Button ID="Button3" runat="server" Text="Button" OnClick="ajaxCall" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

&nbsp;</form>

</body>
</html>

