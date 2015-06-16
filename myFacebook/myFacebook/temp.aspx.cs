using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using myFacebook.DAL;
using System.Web.Services;
using System.IO;
using System.Reflection;
using System.Text;
using System.Net.Mail;


namespace myFacebook
{
    public partial class temp : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/AppImages/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new ListItem(fileName, "~/AppImages/" + fileName));
                }
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
             */ 
            /*
             * wroking exaple ofemail
           string body = "Welcome to myFacebook.com, its my Database Project Testing email :D affer heer";
            string email = "abdullahtariq52@gmail.com";
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
                System.Diagnostics.Debug.WriteLine("ERROR");
                //print("Exception in sendEmail:" + ex.Message);
            }
             * */
           
        }


        protected void ajaxCall(object sender , EventArgs e){
            Label1.Text = Text1.Value;
        }


        protected void UploadImages(object sender, EventArgs e)
        {
            /*
            System.Diagnostics.Debug.WriteLine("in Upload cun");
            if (FileUpload1.HasFile)
            {
                System.Diagnostics.Debug.WriteLine("inside if");
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AppImages/") + fileName);
                System.Diagnostics.Debug.WriteLine("successful");
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
             * */
        }

/*
        two forms in on page
        protected void loginSubmit_Click(object sender, ImageClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("login butn click");
            //Response.Redirect("somepage.aspx");
        }

        protected void Submit_Click(object sender, ImageClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("submit click");
            //Response.Redirect("somepage.aspx");
        }

*/
     
    }
}