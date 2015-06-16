using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myFacebook.DAL;

namespace myFacebook
{
    public partial class BlockedMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BlockdMsg.aspx");
            if (Session["id"] == null)
                Response.Redirect("home.aspx", true);
            else
                if (!string.IsNullOrEmpty(Request.QueryString["block_id"]))//new block request
                {
                    int id2 = Convert.ToInt32(Request.QueryString["block_id"]);
                    int id1 = Convert.ToInt32(Session["id"]);
                    myDAL obj = new myDAL();
                    obj.Block(id1, id2);
                }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}