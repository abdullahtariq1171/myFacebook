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
    public partial class profile_page : System.Web.UI.Page
    {
        protected int loadedID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {    //user not logged in
                //System.Diagnostics.Debug.WriteLine("ID = " + id + "Redirect to Home.aspx");
                Response.Redirect("home.aspx", true);
                return;
            }
            int id = Convert.ToInt32(Request.Form["_id"]);
            if (!string.IsNullOrEmpty(Request.QueryString["friend_req"]))//friend request
            {
                string a = Convert.ToString(Request.QueryString["friend_req"]);
                int id1 = Convert.ToInt32(a);
                int id2 = Convert.ToInt32(Session["id"]);
                SendFriendRequest(id1, id2);
                myDAL obj = new myDAL();
                int temp = obj.AreFriends(id2, id1);
                LoadProfile(Convert.ToInt32(Session["profile_id"]), temp, Convert.ToInt32(Session["id"]));
            }

            //else //load profile
            {
                System.Diagnostics.Debug.WriteLine("ID: " + id);

                myDAL obj = new myDAL();
                int myID = (int)Session["id"];
                //int myID = 16;
                Session["id"] = myID;
                int value = obj.AreFriends(id, myID);
                if (value == -2)
                    Response.Redirect("BlockedMsg.aspx");
                LoadProfile(id, value, myID);
            }
        }

        public void LoadProfile(int id, int value, int myId)
        {
            System.Diagnostics.Debug.WriteLine("status :" + value + "---- " + id + " " + myId);

            if (id == 0)
            {
                return;
            }
            

            loadedID = id;
            myDAL obj = new myDAL();
            DataSet ds = obj.GetThisUser(id);

            Session["profile_id"] = ds.Tables[0].Rows[0][0].ToString();

            loadedID = Convert.ToInt32(Session["profile_id"]);
            Session["profile_Fname"] = ds.Tables[0].Rows[0][1].ToString();
            Session["profile_Lname"] = ds.Tables[0].Rows[0][2].ToString();

            //load posts
            friendList.DataSource = obj.GetFriendsOfThis(id);
            friendList.DataBind();

            //            int id2 = Convert.ToInt32(Session["id"]);

            //int id2 = myId;
            //int value = obj.AreFriends(id, id2);

            postRptr.DataSource = obj.GetThisUserPosts(id);
            postRptr.DataBind();

            //System.Diagnostics.Debug.WriteLine("REsult: " + id + " " + id2 + " " + value);

            if (value == -1)//no firends
            {
                System.Diagnostics.Debug.WriteLine("first cond");
                friendReqForm.Visible = true;
                statusButtonDiv.Visible = false;
                //    panel1.Visible = true;
                //    panel2.Visible = false;

            }
            else if (value == 2)
            {
                //pending
                System.Diagnostics.Debug.WriteLine("2nd cond");
                friendReqForm.Visible = false;
                statusButtonDiv.Visible = true;
                //statusButton.Text = "Pending";
                //    panel1.Visible = false;
                //    panel2.Visible = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("WRONG LOGIC");
                friendReqForm.Visible = false;
                statusButtonDiv.Visible = false;
               
            }

            if(id==myId)//my own profile
            {
                friendReqForm.Visible = false;
                statusButtonDiv.Visible = false;
                blockButtonDiv.Visible = false;
            }


        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // tempCount++;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int postID = Convert.ToInt32(drv["PostID"]);
                Repeater Repeater2 = (Repeater)e.Item.FindControl("commentRptr");
                myDAL obj = new myDAL();
                Repeater2.DataSource = obj.GetPostComment(postID);
                Repeater2.DataBind();
            }
        }

        protected void SendFriendRequest(int id1, int id2)
        {
            myDAL obj = new myDAL();
            int status = obj.SendFriendRequest(id1, id2);
            friendReqForm.Visible = false;

            //statusButton.Text = "Pending";
            // statusButton.Visible = true;
            //            panel1.Visible = false;
            //            panel2.Visible = true;
        }

    }
}