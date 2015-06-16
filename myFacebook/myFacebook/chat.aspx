<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="myFacebook.chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!--[if IE]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <![endif]-->
    <!-- BOOTSTRAP CORE STYLE CSS -->

     <style>
        .Linkbutton {
            background:none!important;
            border:none; 
            padding:0!important;
            /*border is optional
            border-bottom:1px solid #444;*/ 
        }
    </style>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script>
        $("#send").click(function () {
            $("html, #myPanel").animate({ scrollTop: $(document).height() }, 0);
        }
       );
        $(window).load(function () {
            $("html, #myPanel").animate({ scrollTop: $(document).height() }, 0);
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="container">

<div class="row " style="padding-top:25px;">

<form runat="server" method="post">
        <asp:ScriptManager runat="server" id="scMgr1">
                                        </asp:ScriptManager>
                    <div>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
    <div class="col-md-8">
        <div class="panel panel-info">
            <div class="panel-heading">
                RECENT CHAT HISTORY
            </div>
            <div id="myPanel" class="panel-body" style="min-height: 500px; max-height: 500px;overflow-y: scroll;">
                <ul class="media-list">
                        <asp:Repeater ID="chatRtr" runat="server">
                                                    <ItemTemplate >
                                
                                            <li class="media">
                                                <div class="media-body">
                                                    <div class="media">
                                                        <a class="pull-left" href="#">
                                                            <img class="media-object " src="AppImages/<%#Eval("SenderID")%>.jpg" style="height:30px;width:30px;"/>
                                                        </a>
                                                        <div class="media-body" >
                                                           <b><%#Eval("Fname") %> </b>  <%#Eval("Content")%>
                                                            <br />
                                                           <small class="text-muted">Alex Deo | 23rd June at 5:00pm</small>
                                                            <hr/>
                                                        </div>
                                                    </div>

                                                </div>
                                            </li>

                                 </ItemTemplate>
                                            </asp:Repeater>
                </ul>
            </div>

                                       
                                            
		                                

            <div class="panel-footer">
                <div class="input-group">
                                    <input type="text" class="form-control" name="chatText" placeholder="Enter Message" />
                                    <span class="input-group-btn">
                                         <asp:Panel id="loginPanel" DefaultButton="send" Runat="Server">
                                            <asp:Button id="send" CssClass="btn btn-info" Text="SEND" runat="server" OnClick="SendMessage"/>
                                         </asp:Panel>
                                     </span>
                                </div>
            </div>
        </div>
    </div>

 </ContentTemplate>
                          </asp:UpdatePanel>
                        </div>
</form>

    <div class="col-md-4">
          <div class="panel panel-primary">
            <div class="panel-heading">
              Friends
            </div>
            <div class="panel-body">
                <ul class="media-list">
                    <asp:Repeater runat="server" ID="FriendListRpr">
                        <ItemTemplate>
                                    <li class="media">

                                        <div class="media-body">

                                            <div class="media">
                                                <a class="pull-left" href="#">
                                                    <img class="media-object img-circle" style="max-height:40px;" src="AppImages/<%#Eval("id")%>.jpg" />
                                                </a>
                                                         
                                                <div class="media-body" >
                                                    <form action="chat.aspx" method="get">
                                                       <input type="hidden" value="<%#Eval("id")%>" name="clickedID" />
                                                        <button type="submit" class="Linkbutton"><%#Eval("Fname")%> <%#Eval("Lname")%></button>
                                                    </form>
                                                    
                                                   <small class="text-muted">Active From 3 hours</small>
                                                </div>
                                            </div>

                                        </div>
                                    </li>
                                                    </ItemTemplate>
                    </asp:Repeater>

                                </ul>
                </div>
            </div>
    </div>
                                       
</div>
  </div>
</asp:Content>
 