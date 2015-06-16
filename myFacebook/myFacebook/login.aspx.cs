using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myFacebook.DAL;
using System.Web.Services;
using System.Net.Mail;

namespace myFacebook
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!string.IsNullOrEmpty(Request.QueryString["logMeOut"]))
          {
              //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "LOGGED OUT" + "');", true);
              Session.Clear();
              Response.Redirect("login.aspx");
          }
          else if(!string.IsNullOrEmpty(Request.QueryString["loginFailed"]))
          {
              System.Text.StringBuilder sb = new System.Text.StringBuilder();
              sb.Append("<script type = 'text/javascript'>");
              sb.Append("window.onload=function(){");
              sb.Append("alert('");
              sb.Append("Incorrect Information");
              sb.Append("')};");
              sb.Append("</script>");
              ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
          }
          //else
          //{
          //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "You are not logged out now" + "');", true);
          //}
        }
        protected void RegisterUser(object sender, EventArgs e)
        {
            string message = string.Empty;
            string fName = String.Format("{0}", Request.Form["firstname"]);
            string lName = String.Format("{0}", Request.Form["lastname"]);
            string email = String.Format("{0}", Request.Form["reg_email__"]);
            string email_conf = String.Format("{0}", Request.Form["reg_email_confirmation__"]);

            string pass = String.Format("{0}", Request.Form["reg_passwd__"]);
            string bday_m = String.Format("{0}", Request.Form["birthday_month"]);
            string bday_d = String.Format("{0}", Request.Form["birthday_day"]);
            string bday_y = String.Format("{0}", Request.Form["birthday_year"]);
            string sex = String.Format("{0}", Request.Form["sex"]);


            //     ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + bday_d +" "+bday_m+ " "+bday_y+ "');", true);
            if (String.IsNullOrEmpty(fName))
                message = message + "\\nFirst Name";
            if (String.IsNullOrEmpty(lName))
                message = message + "\\nLast Name ";
            if (String.IsNullOrEmpty(email))
                message = message + "\\nEmail";
            if (String.IsNullOrEmpty(pass))
                message = message + "\\nPassword";
            if (bday_m == "0")
                message = message + "\\nBirthday Month";
            if (bday_d == "0")
                message = message + "\\nBirthDay Date";
            if (bday_y == "0")
                message = message + "\\nBirthDay Year";
            if (String.IsNullOrEmpty(sex))
                message = message + "\\nGender ";
            
            //now checking data
            if (String.IsNullOrEmpty(message)==false){
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "//nFollowing Information missing: " + message + "');", true);
                return ;
            }

            if (email != email_conf)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" +"Email Do not match"+ "');", true);
                return;
            }

            //commented just for testing purpose
            /*
            if (pass.Length > 25 || pass.Length < 8)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Password length shoud be 8-25" + "');", true);
                return;
            }
            */
            char _sex='M';
            if(sex=="1")
                _sex='F';

            myDAL obj = new myDAL();
            int status = obj.InsertNewUser(fName,lName,email,pass,bday_m+"/"+bday_d+"/"+bday_y,_sex);

            //int userId = 0;
            //string constr = ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("InsertNewUser"))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@fn", fName);
            //            cmd.Parameters.AddWithValue("@ln", lName);
            //            cmd.Parameters.AddWithValue("@gender", sex);
            //            cmd.Parameters.AddWithValue("@bd", "11/14/1994");
            //            cmd.Parameters.AddWithValue("@Password", pass);
            //            cmd.Parameters.AddWithValue("@Email", email);
            //            cmd.Parameters.AddWithValue("@cNo", "03437891710");
            //            cmd.Parameters.AddWithValue("@country", "Pakistan");
            //            cmd.Connection = con;
            //            con.Open();
            //            userId = Convert.ToInt32(cmd.ExecuteScalar());
            //            con.Close();
            //        }
            //    }

            if (status<0)
            {
                error.Text = "Email already used";
                message = "Entered Email address has already been used, Please use another." + status.ToString();
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "status<0" + "');", true);
            }
            else 
            {
                sendEmail(email);
                    
                Session["Fname"] = fName;
                Session["Lname"] = lName;
                Session["email"] = email;
                Session["id"] = status;
                message = "Registration successful.\\nUser Id: " + status.ToString();
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "status>=0" + "');", true);
                Response.Redirect("AccountDetail.aspx");
            }
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }

        private bool sendEmail(string email)
        {
            string body = "Welcome to myFacebook.com, Its my Database Project Testing email, i welcome you on my application ";
            //string email = "abdullahtariq52@gmail.com";
            bool retStatus=true;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                // mail.To.Add("xxx@gmail.com");
                mail.From = new MailAddress("myfacebook.com123@gmail.com");

                mail.Subject = "myFacebook.com";
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     ("myfacebook.com123@gmail.com", "myuniversity"); // ***use valid credentials***
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR");
                System.Diagnostics.Debug.WriteLine("ERROR");

                retStatus = false;
                //print("Exception in sendEmail:" + ex.Message);
            }
            return retStatus;
        }
    }
}



