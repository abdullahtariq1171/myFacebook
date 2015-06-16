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
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                Response.Redirect("login.aspx" , true);
                return;
            }

            string abc = HttpUtility.HtmlEncode(Request.Form["q"]);

            this.SearchThis(abc);
        }
        protected void SearchThis(string textSearch)
        {
            myDAL obj = new myDAL();
            DataSet ds = obj.Search(textSearch);
            int Tcount = ds.Tables.Count;
            if (Tcount > 0)
            {
                int tRow = ds.Tables[0].Rows.Count;
                findList.DataSource = ds;
                findList.DataBind();
            }
        }

        protected void Search(object sender, EventArgs e)
        {
            //  string ac=imm.Value;
            // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ac + "');", true);
            // return;
            string textSearch = "abdullah";
            //  ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + textSearch + "');", true);

            myDAL obj = new myDAL();
            DataSet ds = obj.Search(textSearch);
            string ans = ds.Tables[0].Columns["Fname"].ToString();
            int tRow = ds.Tables[0].Rows.Count;
            /*
            for(int i=0 ; i <tRow ; i++)
            {
                searchResult.
                string ans1 = ds.Tables[0].Rows[0]["Fname"].ToString();
            }
            */
            string ans1 = ds.Tables[0].Rows[0]["Fname"].ToString();
            findList.DataSource = ds;
            findList.DataBind();
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + ans + " "+ans1  + "');", true);
        }

    }
}