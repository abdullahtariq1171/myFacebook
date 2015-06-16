using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using myFacebook.DAL;

namespace myFacebook
{
    public partial class notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (!string.IsNullOrEmpty(Request.Form["markAsRead"]))
            {
                myDAL obj = new myDAL();
                obj.MarkNotificationAsRead(Convert.ToInt32(Request.Form["markAsRead"]));
            }
            else
                if (!string.IsNullOrEmpty(Request.Form["AccReqID"]))
                {
                    int AccReqID = Convert.ToInt32(Request.Form["AccReqID"]);
                    int Nid = Convert.ToInt32(Request.Form["Nid"]);
                    myDAL obj = new myDAL();
                    obj.AcceptFriendRequest(Convert.ToInt32(Session["id"]), AccReqID);
                    obj.MarkNotificationAsRead(Nid);
                }
                else
                    if (!string.IsNullOrEmpty(Request.Form["RejReqID"]))
                    {
                        int RejReqID = Convert.ToInt32(Request.Form["RejReqID"]);
                        int Nid = Convert.ToInt32(Request.Form["Nid"]);
                        myDAL obj = new myDAL();
                        obj.MarkNotificationAsRead(Convert.ToInt32(Request.Form["RejReqID"]));
                    }

            LoadNotifations(Convert.ToInt32(Session["id"]));
        }
        protected void LoadNotifations(int id)
        {
            myDAL obj = new myDAL();
            likeRptr.DataSource = obj.GetPostLikeNotification(id);
            likeRptr.DataBind();
            commentRptr.DataSource = obj.GetPostCommentNotification(id);
            commentRptr.DataBind();
            reqRecRptr.DataSource = obj.GetReqReceivedNotification(id);
            reqRecRptr.DataBind();
        }
    }
}