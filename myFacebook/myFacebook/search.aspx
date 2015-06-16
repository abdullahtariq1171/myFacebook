<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="myFacebook.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="css/search//W3niizXhJLv.css" data-bootloader-hash="zn3VV" data-permanent="1" />
    <link type="text/css" rel="stylesheet" href="css/search//EFcS3arefhL.css" data-bootloader-hash="32I7e" data-permanent="1" />
    <link type="text/css" rel="stylesheet" href="css/search/RHvS3BqkcIC.css" data-bootloader-hash="zd9Ah" data-permanent="1" />
    <link type="text/css" rel="stylesheet" href="css/search/rYrjwSVFJVP.css" data-bootloader-hash="CwpqL" data-permanent="1" />
    <link type="text/css" rel="stylesheet" href="css/search/PEndfgynY-e.css" data-bootloader-hash="zd5+k" data-permanent="1" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="globalContainer" class="uiContextualLayerParent" style="margin-top:50px; margin-left:100px;">
        <div class="fb_content clearfix " id="content" role="main">
            <div class="clearfix">
                <div class="lfloat _ohe">
                    <div class="mtl _30d _5ewg _5n-u">
                                        <div class="phl">

       <asp:Repeater runat="server" ID="findList">
        <ItemTemplate>
            <div class="clearfix ruUserBox _3-z" id="u_0_1x" style="border-right-style: solid;border-right-width: 0px; "> 
                <a class="_8o _8t lfloat _ohe" href="#" tabindex="-1" aria-hidden="true">
                    <div class="uiScaledImageContainer ruProfilePicXLarge silhouette">
                        <img class="scaledImageFitWidth img" src="AppImages/<%#Eval("id")%>.jpg" alt="PIC NOT FOUND" itemprop="image" height="75" width="75">
                    </div>
                </a>
                <div class="clearfix _42ef">
                    <div class="fcg">
                        <div id="u_0_28" class="_6-_">

                           <%-- <a href="profile_page.aspx/?profile_id=<%#Eval("id")%>" ><%#Eval("Fname")%> <%#Eval("Lname")%></a>
                          --%>  
                            <form method="post" action="profile_page.aspx">
                                <fieldset>
                                    <input type="hidden" name="_id"  value="<%#Eval("id")%>"/>
                                    <input type="submit" class="searchButton" value="<%#Eval("Fname")%> <%#Eval("Lname")%>" />
                                </fieldset>
                            </form>

                        </div>
                            </div>
                         </div>
            </div>

            </ItemTemplate>
        </asp:Repeater>
</div></div></div></div></div></div>
</asp:Content>








