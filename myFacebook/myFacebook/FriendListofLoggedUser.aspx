<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendListofLoggedUser.aspx.cs" Inherits="myFacebook.FriendListofLoggedUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form  id="reg" name="reg" runat="server">

        <input type="text"  name="myID"  placeholder="First name" id="u_0_1" aria-label="First name" />
        <asp:button type="submit" Text="Search"  name="websubmit"   OnClick="PrintFriendList" runat="server"/>
    </form>

    <asp:Repeater runat="server" ID="repeater1"> 
          <ItemTemplate>
              <%--<a href="profile.aspx/?profile_id=<%#Eval("id")%>" ><%#Eval("Fname")%> <%#Eval("Lname")%></a>--%>
           User: <%#Eval("id1")%> and User: <%#Eval("id2")%> are Friends<br />
        </ItemTemplate>
    </asp:Repeater>

</body>
</html>
