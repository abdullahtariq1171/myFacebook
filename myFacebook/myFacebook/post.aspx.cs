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
    public partial class post : System.Web.UI.Page
    {
        public int tempCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            else
            {
                int postID = Convert.ToInt32(Request.QueryString["thistPost"]);
                myDAL obj = new myDAL();
                repeater1.DataSource = obj.GetThisPost(postID);
                repeater1.DataBind();
            }
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
    }
}