<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="notification.aspx.cs" Inherits="myFacebook.notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" > 

        <div class ="container" style="margin-left:30px;">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Your Liked Post
                    </div>
                    <div class="panel-body">

                        <asp:Repeater runat="server" ID="likeRptr">
                            <ItemTemplate>
                                <form action="notification.aspx" method="post">
                                    <button type="submit" class="btn btn-primary btn-xs">Mark Read</button>
                                    <%#Eval("Fname") %> <%#Eval("Lname") %> Liked your  <a href="post.aspx?thistPost=<%#Eval("P_id")%>" target="_blank">post</a>
                                    <input type="hidden"  name="markAsRead" value="<%#Eval("Nid")%>"/>
                                </form>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Comments Notification
                    </div>
                    <div class="panel-body">
                       <asp:Repeater runat="server" ID="commentRptr">
                            <ItemTemplate>
                                <form action="notification.aspx" method="post">
                                    <button type="submit" class="btn btn-primary btn-xs">Mark Read</button>
                                    <%#Eval("Fname") %> <%#Eval("Lname") %> Commented on your <a href="post.aspx?thistPost=<%#Eval("P_id")%>" target="_blank">post</a><br/>
                                    <input type="hidden"  name="markAsRead" value="<%#Eval("Nid")%>"/>
                                    
                                </form>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>

         <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Pending Requests
                    </div>
                    <div class="panel-body">
                       <asp:Repeater runat="server" ID="reqRecRptr">
                            <ItemTemplate>
                                <form action="notification.aspx" method="post">
                                    <button type="submit" class="btn btn-primary btn-xs">Mark Read</button>
                                    <%#Eval("Fname") %> <%#Eval("Lname") %> Sent Your Friend Request<br/>
                                    <input type="hidden"  name="markAsRead" value="<%#Eval("Nid")%>"/>
                                </form>
                                <form action="notification.aspx" method="post">
                                    <button type="submit" class="btn btn-primary btn-xs">ACCEPT</button>
                                    <input type="hidden"  name="AccReqID" value="<%#Eval("U_id")%>"/>
                                    <input type="hidden"  name="Nid" value="<%#Eval("Nid")%>"/>
                                </form>
                                <form action="notification.aspx" method="post" style="margin-bottom:10px;">
                                    <button type="submit" class="btn btn-primary btn-xs">REJECT</button>
                                    <input type="hidden"  name="RejReqID" value="<%#Eval("U_id")%>"/>
                                    <input type="hidden"  name="Nid" value="<%#Eval("Nid")%>"/>
                                </form>
                                 
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>



    </div>

</asp:Content>
