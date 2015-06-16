using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

using System.Collections.Generic;


namespace myFacebook
{
    public partial class AccountDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
                Response.Redirect("login.aspx");
        }

        protected void UploadImages(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("in Upload cun");
            if (FileUpload1.HasFile)
            {
                System.Diagnostics.Debug.WriteLine("inside if");
                //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileName = Session["id"].ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AppImages/") + fileName + ".jpg");
                System.Diagnostics.Debug.WriteLine("successful");
                Response.Redirect("home.aspx");
            }
            else
            {
                errorShow.Text = "Picture Cant be uploaded";
            }
        }
    }
}