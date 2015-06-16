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
    public partial class chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("chat.aspx loaded");

            //Session["id"] = 16;
            if (Session["id"] == null)
            {
                System.Diagnostics.Debug.WriteLine("cond1");
                Response.Redirect("login.aspx", true);
                return;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["clickedID"]))
            {
                System.Diagnostics.Debug.WriteLine("cond2");
                FocusThisUser(Convert.ToInt32(Request.QueryString["clickedID"]));
                return;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("else");
                DataSet friendList;
                myDAL obj = new myDAL();
                int myID = Convert.ToInt32(Session["id"]);
                friendList = obj.GetFriendsOfThis(myID);

                FriendListRpr.DataSource = friendList;
                FriendListRpr.DataBind();

                DataTable dt = friendList.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //string str = ds.Tables[0].Rows[0][1].ToString();
                    int firstFriendID = int.Parse(dt.Rows[0][0].ToString());
                    Session["chatActiveID"] = firstFriendID;
                    if (firstFriendID != 0)
                    {
                        chatRtr.DataSource = obj.GetChat(myID, firstFriendID);
                        chatRtr.DataBind();

                        System.Diagnostics.Debug.WriteLine(myID + " " + firstFriendID);
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("open");
        }

        protected void FocusThis(object sender, EventArgs e)
        {
            string text = String.Format("{0}", Request.Form["actThisID"]);
            int id=Convert.ToInt32(text);
            System.Diagnostics.Debug.WriteLine("chat.aspx=>FocusTHis");
            Session["chatActiveID"] = id;
            myDAL obj = new myDAL();
            int myID = Convert.ToInt32(Session["id"]);
            chatRtr.DataSource = obj.GetChat(myID, id);
            chatRtr.DataBind();
            FriendListRpr.DataSource = obj.GetFriendsOfThis(myID);
            FriendListRpr.DataBind();
        }
        protected void FocusThisUser(int id)
        {
            System.Diagnostics.Debug.WriteLine("chat.aspx=>FocusThisUser");
            Session["chatActiveID"] = id;
            myDAL obj = new myDAL();
            int myID = Convert.ToInt32(Session["id"]);
           chatRtr.DataSource = obj.GetChat(myID, id);
            chatRtr.DataBind();
            FriendListRpr.DataSource = obj.GetFriendsOfThis(myID);
           FriendListRpr.DataBind();
        }
        protected void SendMessage(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("chat.aspx=>SendMessage");

            if (Session["chatActiveID"] != null)
            {
                string text = String.Format("{0}", Request.Form["chatText"]);
                int id1 = Convert.ToInt32(Session["id"]), id2 = Convert.ToInt32(Session["chatActiveID"]);
                myDAL obj = new myDAL();
                chatRtr.DataSource = obj.SendChat(id1, id2, text);
                  chatRtr.DataBind();
                System.Diagnostics.Debug.WriteLine("Send Message: " + text);
                //Response.Redirect("somepage.aspx");
            }
        }

        protected void loadMessage(object sender, EventArgs e)
        {
            myDAL obj = new myDAL();
            int myID = Convert.ToInt32(Session["id"]), id2 = Convert.ToInt32(Session["chatActiveID"]);
            chatRtr.DataSource = obj.GetChat(myID, id2);
            chatRtr.DataBind();
            System.Diagnostics.Debug.WriteLine("Load message");
            //Response.Redirect("somepage.aspx");
        }
    }
}