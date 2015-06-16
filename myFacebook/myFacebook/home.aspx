<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="myFacebook.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .Linkbutton {
            background:none!important;
            border:none; 
            padding:0!important;
            color:#0000EE;
            /*border is optional
            border-bottom:1px solid #444;*/ 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         
            <div id="leftBar">
                <div id="user_box">
                    <div id="user_avatar">
                        <img src="AppImages/<%:Session["id"]%>.jpg" alt="Alternate Text" style="width:40px;height:45px;" />
                    </div>
                    <div id="user_info">
                        <a class="_user_info font_set" href="#profile"> <%:Session["Fname"]%></a>
                        <br />
                        <a class="_user_info font_set" style="font-weight:normal;" href="#edit-profile">Edit Profile</a>
                    </div>
                </div>
                <div id="user_nav" style="margin-top: 15px;">
                    <ul class="nav">
                        <li>
                            <a href="#welcome">
                                <div class="nav_link">
                                    <div class="welcome"></div>
                                    <div class="link_text">Welcome</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#newsfeed">
                                <div class="nav_link">
                                    <div class="newsfeed"></div>
                                    <div class="link_text">News Feed</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="chat.aspx" target="_blank">
                                <div class="nav_link">
                                    <div class="messages"></div>
                                    <div class="link_text">Messages</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#events">
                                <div class="nav_link">
                                    <div class="events"></div>
                                    <div class="link_text">Events</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#findfriends">
                                <div class="nav_link">
                                    <div class="findfriends"></div>
                                    <div class="link_text">Find Friends</div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="title">
                    <a class="title" href="#groups">Groups</a>
                </div>
                <div id="user_groups">
                    <ul class="nav">
                        <li>
                            <a href="#uit">
                                <div class="nav_link">
                                    <div class="welcome"></div>
                                    <div class="link_text">Dai hoc CNTT</div>
                                    <div class="number">1</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#uit-nt">
                                <div class="nav_link">
                                    <div class="newsfeed"></div>
                                    <div class="link_text">Mang may tinh va truyen thong</div>
                                    <div class="number">10</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#ltudm">
                                <div class="nav_link">
                                    <div class="messages"></div>
                                    <div class="link_text">Lap trinh ung dung mang</div>
                                    <div class="number">10</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#tbmvttdpt">
                                <div class="nav_link">
                                    <div class="events"></div>
                                    <div class="link_text">Thiet bi mang va truyen thong da phuong tien</div>
                                    <div class="number">6</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#xlthsttt">
                                <div class="nav_link">
                                    <div class="findfriends"></div>
                                    <div class="link_text">Xu ly tin hieu so trong truyen thong</div>
                                    <div class="number">4</div>
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!--
                        <ul class="nav">
                            <li>
                                <a href="#" class="welcome">[&nbsp;[&nbsp;[&nbsp;[&nbsp;[&nbsp;[&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;]&nbsp;]&nbsp;]&nbsp;]&nbsp;]</a>
                            </li>
                            <li>
                                <a href="#" class="newsfeed">[&nbsp;:&nbsp;:&nbsp;[&nbsp;[&nbsp;[&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;]&nbsp;]&nbsp;:&nbsp;:&nbsp;]</a>
                            </li>
                            <li>
                                <a href="#" class="messages">[&nbsp;:&nbsp;:&nbsp;[&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;:&nbsp;:&nbsp;]</a>
                            </li>
                            <li>
                                <a href="#" class="events">[&nbsp;:&nbsp;:&nbsp;[&nbsp;[&nbsp;[&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;]&nbsp;]&nbsp;:&nbsp;:&nbsp;]</a>
                            </li>
                            <li>
                                <a href="#" class="findfriends">[&nbsp;[&nbsp;[&nbsp;[&nbsp;[&nbsp;[&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;]&nbsp;]&nbsp;]&nbsp;]&nbsp;]</a>
                            </li>
                        </ul>
-->
                </div>
                <div class="title">
                    <a class="title" href="#apps">Apps</a>
                </div>
                <div id="user_apps">
                    <ul class="nav">
                        <li>
                            <a href="#facebook">
                                <div class="nav_link">
                                    <div class="welcome"></div>
                                    <div class="link_text">Facebook</div>
                                    <div class="number">3</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#google">
                                <div class="nav_link">
                                    <div class="newsfeed"></div>
                                    <div class="link_text">Google Search</div>
                                    <div class="number">9+</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#gmail">
                                <div class="nav_link">
                                    <div class="messages"></div>
                                    <div class="link_text">Gmail</div>
                                    <div class="number">21</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#chrome">
                                <div class="nav_link">
                                    <div class="events"></div>
                                    <div class="link_text">Google Chrome</div>
                                    <div class="number">40</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#firefox">
                                <div class="nav_link">
                                    <div class="findfriends"></div>
                                    <div class="link_text">Firefox</div>
                                    <div class="number">12</div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="title">
                    <a href="#friends" class="title">Friends</a>
                </div>
                <div id="user_friends">
                    <ul class="nav">
                        <li>
                            <a href="#family">
                                <div class="nav_link">
                                    <div class="welcome"></div>
                                    <div class="link_text">Family</div>
                                    <div class="number">3</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#classmate">
                                <div class="nav_link">
                                    <div class="newsfeed"></div>
                                    <div class="link_text">Classmate</div>
                                    <div class="number">90</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#gmail">
                                <div class="nav_link">
                                    <div class="messages"></div>
                                    <div class="link_text">University of Information Technology</div>
                                    <div class="number">21</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#chrome">
                                <div class="nav_link">
                                    <div class="events"></div>
                                    <div class="link_text">Close friends</div>
                                    <div class="number">40</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#firefox">
                                <div class="nav_link">
                                    <div class="findfriends"></div>
                                    <div class="link_text">Old Friends</div>
                                    <div class="number">78</div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
                <div class="title">
                    <a href="#pages" class="title">Pages</a>
                </div>
                <div id="user_pages">
                    <ul class="nav">
                        <li>
                            <a href="#family">
                                <div class="nav_link">
                                    <div class="welcome"></div>
                                    <div class="link_text">Like page</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#classmate">
                                <div class="nav_link">
                                    <div class="newsfeed"></div>
                                    <div class="link_text">Pages Feed</div>
                                    <div class="number">10</div>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="#gmail">
                                <div class="nav_link">
                                    <div class="messages"></div>
                                    <div class="link_text">Create a page...</div>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

            <div id="content">

                <form   method="post" runat="server">

                    
		
                <div id="ps" class="content_box">
                    <div class="ps_header">
                        <ul class="ps_menu">
                            <li id="update_status">
                                <a href="#">
                                    <div class="ps_link">
                                        <div class="update_status"></div>
                                        <div class="ps_link_text">Update Status</div>
                                    </div>
                                </a>
                            </li>
                            <li style="line-height: 25px;color: #bbbbbb;">&nbsp;|&nbsp;</li>
                            <li id="add_media">
                                <a href="#">
                                    <div class="ps_link">
                                        <div class="add_media"></div>
                                        <div class="ps_link_text">Add Photos/Video</div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <textarea class="ps_form" placeholder="What's on your mind?" runat="server" id="post_text" name="post_text"></textarea>
                    <div class="content_box_footer">
                        <div class="ps_rftr">
                            <asp:Button id="post_status" type="submit" runat="server" Text="Post" OnClick="PostNewPost" />
                            <%--<button id="post_status" type="submit">Post</button>--%>
                        </div>
                    </div>
                </div>
               
                </form>

                <asp:Repeater runat="server" ID="repeater1"
                    onitemdatabound="Repeater1_ItemDataBound" >
                     
                    <ItemTemplate> 

                <div id="status_box" class="content_box">
                    <div class="content_box_wrapper">
                        <div class="content_box_header">
                            <div class="content_box_user_avatar">
                                <img src="AppImages/<%#Eval("UserID")%>.jpg" alt="Alternate Text" style="width:35px;height:45px;" />
                                
                            </div>
                            <div class="content_box_status_info">
                                <p>
                                    <a href="profile.aspx/?profile_id=<%:Session["Fname"]%>" ></a>
                                    <a class="content_box_username" href="profilePage.aspx/?profile_id=<%:Session["id"].ToString()%>"> <%#Eval("Fname")%> </a> with <a href="#guest" target="_blank" class="content_box_other_link">Guest</a>
                                </p>
                                <p class="content_box_other_infos">
                                    <a href="#" title="Wednesday, May 21, 2014 at 8:15am" target="_blank">3hrs</a>
                                </p>
                            </div>
                        </div>
                        <div class="content_box_status">
                            <p class="content_box_text" style="margin-top:5px;">
                                 <%#Eval("Content")%>
                                <%--Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.--%>
                            </p>
                            <p class="content_box_status_ftr">
                                 <form action="home.aspx" method="post">

                                            <input type="hidden" name="postIDLiked" value="<%#Eval("PostID")%>" />
                                             <button class="Linkbutton" type="submit" >Like</button>
                                 
                                    <a href="#" title="Leave a comment" target="_blank">Comment</a>
                                    &#183;
                                    <a href="#" title="Send this to friends or post it on your timeline." target="_blank">Share</a>
                                  </form>
                            </p>
                        </div>
                    </div>
                    
                    <div class="content_box_footer">
                        
                        <div class="content_box_footer_wrapper">

                            <div class="content_like_box">
                                <div class="like_box_image">
                                    
                                </div>
                                <div class="liked_user">
                                    <a class="content_box_other_link" href="#Guest" target="_blank">
                                         <%#Eval("tCount")%> 
                                    </a> likes this.
                                </div>
                            </div>

                            <div class="content_comment_box">

                                <asp:repeater id="repeater2" runat="server">
		                            <itemtemplate>
	                                         

                                <div class="comment_item">

                                    <div class="comment_user_avatar">
                                        <img src="AppImages/<%#Eval("UserID")%>.jpg" alt="Alternate Text" style="width:30px;height:40px;" />
                                    </div>

                                    <div class="comment_info" style="padding-top:10px;">
                                        
                                        <a href="#"><%#Eval("Fname")%> </a>
                                        <%#Eval("Content")%>

                                        <%--<input class="comment_input" type="text" placeholder="Write a comment">--%>
                                    </div>
                                </div>
                                          </itemtemplate>
                                </asp:repeater>



                                <div class="comment_item">
                                    <div class="comment_user_avatar">
                                        <img src="AppImages/<%:Session["id"]%>.jpg" alt="" style="cursor: pointer;">
                                    </div>
                                    <div class="comment_info">
                                        <form action="home.aspx" method="post">
                                            <input type="hidden" name="postID" value="<%#Eval("PostID")%>" />
                                            <input class="comment_input" type="text" name="CommentT" placeholder="Write a comment">
                                        </form>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                     </ItemTemplate>
                </asp:Repeater>

                

               <%-- <div id="status_box" class="content_box">
                    <div class="content_box_wrapper">
                        <div class="content_box_header">
                            <div class="content_box_user_avatar">
                                <img src="img/anonymous.gif" alt="">
                            </div>
                            <div class="content_box_status_info">
                                <p>
                                    <a class="content_box_username" href="#Anonymous">Anonymous</a> with <a href="#guest" target="_blank" class="content_box_other_link">Guest</a>
                                </p>
                                <p class="content_box_other_infos">
                                    <a href="#" title="Wednesday, May 21, 2014 at 8:15am" target="_blank">3hrs</a>
                                    &#183;
                                    <a href="#" target="_blank">Ho Chi Minh City</a>
                                    &#183;
                                    <a href="#" class="tooltips">&nbsp;&nbsp;&nbsp;
                                        <span>Share with: Anonymous's friends</span>
                                    </a>
                                </p>
                            </div>
                        </div>
                        <div class="content_box_status">
                            <p class="content_box_text">
                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
                            </p>
                            <p class="content_box_status_ftr">
                                <a href="#" title="Like this" target="_blank">Like</a>
                                &#183;
                                <a href="#" title="Leave a comment" target="_blank">Comment</a>
                                &#183;
                                <a href="#" title="Send this to friends or post it on your timeline." target="_blank">Share</a>
                            </p>
                        </div>
                    </div>
                    <div class="content_box_footer">
                        <div class="content_box_footer_wrapper">
                            <div class="content_like_box">
                                <div class="like_box_image">
                                    <img class="like_box_image" src="" alt="">
                                </div>
                                <div class="liked_user">
                                    <a class="content_box_other_link" href="#Guest" target="_blank">Guest</a> likes this.
                                </div>
                            </div>
                            <div class="content_comment_box">
                                <div class="comment_item">
                                    <div class="comment_user_avatar">
                                        <img src="./img/ad/uit.png" alt="" style="cursor: pointer;">
                                    </div>
                                    <div class="comment_info">
                                        <input class="comment_input" type="text" placeholder="Write a comment">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

            </div>
            <div id="rightBar">
               
                <div id="footer">
                    <a href="#" target="_blank">English (US)</a>
                    &#183;
                    <a href="https://www.facebook.com/privacy/explanation" target="_blank">Privacy</a>
                    &#183;
                    <a href="https://www.facebook.com/policies" target="_blank">Term</a>
                    &#183;
                    <a href="#" target="_blank">Cookies</a>
                    &#183;
                    <a href="#" target="_blank">More</a>
                    &#9662;
                    <br />Facebook &copy; 2014
                </div>
            </div>
        
</asp:Content>
