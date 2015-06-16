<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="myFacebook.post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Linkbutton {
            background:none!important;
            border:none; 
            padding:0!important;
            /*border is optional
            border-bottom:1px solid #444;*/ 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
                    <asp:Repeater runat="server" ID="repeater1"
                    onitemdatabound="Repeater1_ItemDataBound" >
                     
                    <ItemTemplate> 

                <div id="status_box" class="content_box">
                    <div class="content_box_wrapper">
                        <div class="content_box_header">
                            <div class="content_box_user_avatar">
                                <img src="AppImages/16.jpg" alt="Alternate Text" style="width:35px;height:45px;" />
                                
                            </div>
                            <div class="content_box_status_info">
                                <p>
                                    <a href="profile.aspx/?profile_id=<%:Session["id"]%>" ></a>
                                    <a class="content_box_username" href="#"> <%#Eval("Fname")%> </a> with <a href="#guest" target="_blank" class="content_box_other_link">Guest</a>
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
                                    <img class="like_box_image" src="" alt="">
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

        </div>
</asp:Content>
