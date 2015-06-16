using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using myFacebook.DAL;
using System.Data;

namespace myFacebook
{
    public partial class home : System.Web.UI.Page
    {
        public int tempCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["login_email"]))//log in attempt
            {
                myDAL obj = new myDAL();
                int status = obj.ValidateUser(Request.Form["login_email"], Request.Form["login_pass"]);
                if (status > 0)
                {
                    Session["email"] = Request.Form["login_email"];
                    Session["id"] = status;
                    DataSet ds = obj.GetThisUser(status);
                    DataRow row = ds.Tables[0].Rows[0];

                    string str = ds.Tables[0].Rows[0][1].ToString();
                    Session["Fname"] = ds.Tables[0].Rows[0][1].ToString();
                    Session["Lname"] = ds.Tables[0].Rows[0][2].ToString();

                    // System.Diagnostics.Debug.WriteLine(ds.Tables[0].Rows[0][2].ToString());

                    LoadMyPosts(status);
                }
                else
                {

                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Given Email Or Password Not corrent" + "');", true);
                    Response.Redirect("login.aspx?loginFailed=0");
                }
                return;
            }
            else
                if (!string.IsNullOrEmpty(Request.QueryString["HomeButtonClick"]))
                {
                    LoadMyPosts(Convert.ToInt32(Session["id"]));
                }
                else
                    if (string.IsNullOrEmpty(Session["email"] as string))
                    {
                        Response.Redirect("login.aspx");
                    }
                    else
                        if (!string.IsNullOrEmpty(Request.Form["postID"]))
                        {
                            int PostID = Convert.ToInt32(Request.Form["postID"]);
                            string comment = Request.Form["CommentT"].ToString();
                            System.Diagnostics.Debug.WriteLine(PostID + " : " + comment);
                            int MyID = Convert.ToInt32(Session["id"]);
                            myDAL obj = new myDAL();
                            obj.PostNewComment(PostID, MyID, comment);
                            LoadMyPosts(MyID);
                        }
                        else if (!string.IsNullOrEmpty(Request.Form["postIDLiked"]))
                        {
                            int PostID = Convert.ToInt32(Request.Form["postIDLiked"]);
                            System.Diagnostics.Debug.WriteLine(PostID + " this is liked ");
                            int MyID = Convert.ToInt32(Session["id"]);
                            myDAL obj = new myDAL();
                            obj.PostLiked(PostID, MyID);
                            LoadMyPosts(MyID);
                        }
                        else
                        {
                            int id = (int)Session["id"];
                            LoadMyPosts(id);
                        }
        }


        protected void LoadMyPosts(int id)
        {
            myDAL obj = new myDAL();
            DataSet ds = new DataSet();

            ds = obj.GetNewsFeed(id);

            //ds.Relations.Add(new DataRelation("nestThem", ds.Tables[0].Columns["PostID"], ds.Tables[1].Columns["parentMenuID"]));

            repeater1.DataSource = ds;
            repeater1.DataBind();
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int postID = Convert.ToInt32(drv["PostID"]);

                Repeater Repeater2 = (Repeater)e.Item.FindControl("repeater2");

                myDAL obj = new myDAL();

                Repeater2.DataSource = obj.GetPostComment(postID);
                //                Repeater2.DataSource = ProductData(categoryID);
                Repeater2.DataBind();
                tempCount = obj.PostLikeCount(postID);
                //System.Diagnostics.Debug.WriteLine("Post Likes: " + tempCount);
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int postID = Convert.ToInt32(drv["PostID"]);

                Repeater Repeater2 = (Repeater)e.Item.FindControl("repeater3");

                myDAL obj = new myDAL();

                Repeater2.DataSource = obj.GetPostComment(postID);
                //                Repeater2.DataSource = ProductData(categoryID);
                Repeater2.DataBind();

            }
        }

        protected void PostNewPost(object sender, EventArgs e)
        {
            string text = String.Format("{0}", Request.Form["post_text"]);
            text = post_text.InnerText;
            int id = ((int)Session["id"]);

            System.Diagnostics.Debug.WriteLine(id + " : " + text);

            myDAL obj = new myDAL();
            DataSet ds = obj.PostNewPost(id, text);
            repeater1.DataSource = obj.GetNewsFeed(id);
            repeater1.DataBind();
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" +text + "');", true);
        }
        protected void LogMeOut(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
            return;
        }

    }
}