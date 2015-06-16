using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myFacebook.DAL;   

namespace myFacebook
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Sessio: " + Session["id"]);


            if (Session["id"] == null) //no user loggged in
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void ChangeMyPassword(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(TextBox1.Text + " " + TextBox2.Text + " " + TextBox3.Text + " ");
            if (TextBox2.Text.ToString() == TextBox3.Text.ToString())
            {
                if (TextBox3.Text.Length >= 6)
                {
                    myDAL obj = new myDAL();
                    int status = obj.ChangePassword(Convert.ToInt32(Session["id"]), TextBox1.Text.ToString(), TextBox2.Text.ToString());
                    System.Diagnostics.Debug.WriteLine("status : " + status);
                    if (status == 0)
                    {

                        error.Text = "Successfully changed";
                    }
                    else if (status == -1)
                    {
                        error.Text = "Previous Passwore incorrect";
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("someting went wrog");
                    }
                }
                else
                {
                    error.Text = "New Password is short";
                }
            }
            else
            {

                error.Text = "Password Does not match";
            }
        }

    }
}