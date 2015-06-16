<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="profile_page.aspx.cs" Inherits="myFacebook.profile_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Scripts/bootstrap.min.css" rel="stylesheet" />
    <link href="css/profile/profilecss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<div class="container" style="margin-top:10px;">
		<div class="row">
			<div class="col-md-4 col-sm-4">
				<img src="AppImages/<%:Session["profile_id"] %>.jpg" alt="Alternate Text" style="width:40px;height:45px;" />
                <h5>
				<%:Session["profile_Fname"] %> <%:Session["profile_Lname"] %>
                    </h5>
				<br />
				<br />
				<h4> <b>Friend List</b></h4>
				<ul class="list-styled">
                    <asp:Repeater runat="server" ID="friendList">
                        <ItemTemplate>
    					    <li><%#Eval("Fname")%> <%#Eval("Lname")%></li>
                        </ItemTemplate>
                    </asp:Repeater>
				</ul>
                <div id="friendReqForm" runat="server">
                    <form action="profile_page.aspx" method="get">
                            <input type="hidden" name="friend_req" value="<%=loadedID%>"/>
    				        <button class="btn btn-success"> Send Friend Request</button>
                    </form>
                </div>
                <div runat="server" id="statusButtonDiv">
                    <button class="btn btn-success disabled">Pending</button> 
                </div>
				<div id="blockButtonDiv" runat="server">
                <form action="BlockedMsg.aspx" method="get">
                    <input type="hidden" name="block_id" value="<%=loadedID%>"/>
    				<button class="btn btn-success">BLOCK</button>
                </form>
                    </div>
			</div>

			    <div class="col-md-8 col-sm-8">

                    <div id="ps" class="content_box">
                        <div class="ps_header">
                            <ul class="ps_menu">
                                <li id="update_status">
                                    <a >
                                        <div class="ps_link">
                                            <div class="update_status"></div>
                                            <div class="ps_link_text">Update Status</div>
                                        </div>
                                    </a>
                                </li>
                                <li style="line-height: 25px;color: #bbbbbb;">&nbsp;|&nbsp;</li>
                                <li id="add_media">
                                    <a >
                                        <div class="ps_link">
                                            <div class="add_media"></div>
                                            <div class="ps_link_text">Add Photos/Video</div>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <textarea class="ps_form" placeholder="Write on friends wall" runat="server" id="post_text" name="post_text"></textarea>
                        <div class="content_box_footer">
                            <div class="ps_rftr">
                                <button id="post_status" type="submit" style="float:right;">Post</button>
                            </div>
                        </div>
                    </div>

                    <asp:Repeater runat="server" ID="postRptr" onitemdatabound="Repeater1_ItemDataBound">
                        <ItemTemplate>

                            <div id="status_box" class="content_box" style="margin-top:40px;">
                        <div class="content_box_wrapper">
                            <div class="content_box_header">
                                <div class="content_box_user_avatar">
                                    <img src="AppImages/<%:Session["profile_id"]%>.jpg" alt="User Profile Pic" style="width:30px;height:40px;"/>
                                </div>
                                <div class="content_box_status_info">
                                    <p>
                                        <a> <%#Eval("Fname") %> <%#Eval("Lname") %></a>
                                    	   <%-- with 	<a>Guest</a>--%>
                                    </p>
                                    <p class="content_box_other_infos" style="margin-top:10px;">
                                        <a  title="Wednesday, May 21, 2014 at 8:15am" > <%#Eval("timing" , "{0:dd:M:yy - hh:mm:ss}")%> </a>
                                    </p>
                                </div>
                            </div>
                            <div class="content_box_status">
                                <p class="content_box_text" style="margin-top:10px;">
                                    <%#Eval("Content") %>
                                    
                                </p>
                                <p class="content_box_status_ftr">
                                     <form action="home.aspx" method="post">
                                                <input type="hidden" name="postIDLiked" value="5454554" />
                                                 <button class="Linkbutton" type="submit" >Like</button>
                                 
                                        <a  title="Leave a comment" >Comment</a>
                                        &#183;
                                        <a  title="Send this to friends or post it on your timeline." >Share</a>
                                      </form>
                                </p>
                            </div>
                        </div>

                  
                    
                            <div class="content_box_footer">
                        
                                <div class="content_box_footer_wrapper">

                                    <div class="content_like_box">
                               
                                        <div class="liked_user">
                                            <a class="content_box_other_link"  >
                                               <%#Eval("tCount")%> 
                                            </a> likes this.
                                        </div>
                                    </div>


                                    <div class="content_comment_box" >

                                        <asp:Repeater runat="server" ID="commentRptr">
                                            <ItemTemplate>


                                        <div class="comment_item" style="margin-bottom:7px;">
                                            <div class="comment_user_avatar">
                                                <img src="AppImages/<%#Eval("UserID")%>.jpg" alt="User Profile Pic" style="width:30px;height:40px;"/>
                                            </div>
                                            <div class="comment_info" style="padding-top:10px;">
                                                <a >Fname</a> <%#Eval("Content") %>
                                            </div>
                                        </div>

                                            </ItemTemplate>
                                        </asp:Repeater>

                                         

                                        <br/>


                                        <div class="comment_item">
                                            <div class="comment_user_avatar">
                                                <img src="AppImages/<%:Session["id"]%>.jpg" alt="User Profile Pic" style="width:30px;height:40px;"/>
                                            </div>
                                            <div class="comment_info">
                                                <form action="home.aspx" method="post">
                                                    <input type="hidden" name="postID" value="45" />
                                                    <input class="comment_input" type="text" name="CommentT" placeholder="Write a comment" />
                                                </form>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                        </div>



                    </div>
                      
                        </ItemTemplate>
                    </asp:Repeater>
            
                </div>

            </div>
        </div>
</asp:Content>
