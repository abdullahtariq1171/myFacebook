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
    public partial class FriendListofLoggedUser : System.Web.UI.Page
    {
        int thisUser = 1; ////by default value of thisUser=1 
        protected void Page_Load(object sender, EventArgs e)
        {
            //line commented due to tesing
            //if (!IsPostBack) authentecation
            {
                thisUser = Convert.ToInt32(Session["id"]);
                myDAL obj = new myDAL();
                DataSet ds = obj.GetFriendsOfThis(thisUser); 
                
                
                repeater1.DataSource = ds;
                repeater1.DataBind();
            }
        } 

        protected void PrintFriendList(object sender, EventArgs e)
        {
            //thisUser = Convert.ToInt32(Session["id"]);
            int searchID =Convert.ToInt32( String.Format("{0}", Request.Form["myID"]));
            myDAL obj = new myDAL();
            DataSet ds = obj.GetFriendsOfThis(searchID);
            repeater1.DataSource = ds;
            repeater1.DataBind();
        }
    }
}