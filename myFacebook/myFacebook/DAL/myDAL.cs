using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace myFacebook.DAL
{
    public class myDAL
    {
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;

        public int ValidateUser(string email, string password)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                int temp;
                using (SqlCommand cmd = new SqlCommand("ValidateUser"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Password",password);
                    cmd.Connection = con;
                    con.Open();
                    object userId = cmd.ExecuteScalar();
                    temp = Convert.ToInt32(userId);
                    con.Close();
                }
                switch (temp)
                {
                    case -1:
                        result = -10; //no user found with this email + password
                        break;
                    default:
                        result = temp;
                        break;
                }
            }
            return result;
        }
        
        public int InsertNewUser(string fN, string lN, string email, string password, string bd, char sex)
        {
            int userId = 0, result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertNewUser"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fn", fN);
                        cmd.Parameters.AddWithValue("@ln", lN);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@bd", bd);
                        cmd.Parameters.AddWithValue("@gender", sex);
                        

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }

                switch (userId)
                {
                    case -1:
                        result = -1;//email already used
                        break;
                    default:
                        result = userId;
                        break;
                }
                return result;
            }
        }

        public DataSet Search(string text)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SearchQuery", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@text", SqlDbType.VarChar, 50).Value = text;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;   
        }
        
        public DataSet GetThisUserPosts(int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetUserPosts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = UserID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet GetNewsFeed(int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetNewsFeed1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = UserID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet GetThisPost(int pID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetThisPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@postID", SqlDbType.Int, 50).Value = pID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet GetPostComment(int PostID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetPostComments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PostID", SqlDbType.Int, 50).Value = PostID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        //insertnew post and return updated table
        public DataSet PostNewPost(int id , string Content)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("InsertNewPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = id;
                cmd.Parameters.Add("@text", SqlDbType.VarChar, 50).Value = Content;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public void PostNewComment(int Postid,int UserId, string Content)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("InserNewComment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PostID", SqlDbType.Int, 50).Value = Postid;
                cmd.Parameters.Add("@UserId", SqlDbType.Int, 50).Value = UserId;
                cmd.Parameters.Add("@text", SqlDbType.VarChar, 50).Value = Content;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet GetThisUser(int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetThisUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Userid", SqlDbType.Int, 50).Value = UserID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public int SendFriendRequest(int id1, int id2)
        {
            int userId = 0, result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SendFriendRequest"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId1", id1);
                        cmd.Parameters.AddWithValue("@UserId2", id2);

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }

                switch (userId)
                {
                    case -1:
                        result = -1;//email already used
                        break;
                    default:
                        result = userId;
                        break;
                }
                return result;
            }
        }

        public int AreFriends(int id1, int id2) //to check are two people friends ?
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("AreTheyFriends"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId1", id1);
                        cmd.Parameters.AddWithValue("@UserId2", id2);

                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }

        public DataSet GetFriendsOfThis(int UserID)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetFriendList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Userid", SqlDbType.Int, 50).Value = UserID;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;   
        }

        public int Block(int id1, int id2)
        {
            int  result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Block"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId1", id1);
                        cmd.Parameters.AddWithValue("@UserId2", id2);

                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }

        public int PostLiked(int PostID, int UserID)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("PostLike"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", UserID);
                        cmd.Parameters.AddWithValue("@PostId", PostID);

                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }

        public int PostLikeCount(int PostID)
        {
            int  result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("TOTAL_LIKES_OF_THIS_POST"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@POST_ID", PostID);
                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }
        
        public int AcceptFriendRequest(int id1,int id2)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("ConfirmFriendRequest"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId1", id1);
                        cmd.Parameters.AddWithValue("@UserId2", id2);
                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }

        public DataSet GetChat(int id1, int id2)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetChat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Userid1", SqlDbType.Int, 50).Value = id1;
                cmd.Parameters.Add("@Userid2", SqlDbType.Int, 50).Value = id2;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet SendChat(int id1, int id2 , string text)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("InsertChat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Userid1", SqlDbType.Int, 50).Value = id1;
                cmd.Parameters.Add("@Userid2", SqlDbType.Int, 50).Value = id2;
                cmd.Parameters.Add("@content", SqlDbType.VarChar, 50).Value = text;
                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public int ChangePassword(int userID , string prePass , string newPass)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("ChangePassword"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Userid", userID);
                        cmd.Parameters.AddWithValue("@PrePass", prePass);
                        cmd.Parameters.AddWithValue("@NewPass", newPass);
                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }

        public DataSet GetPostLikeNotification(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our application
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetPostLikeNotification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = id;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet GetPostCommentNotification(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our applFication
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetPostCommentNotification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = id;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public DataSet GetReqReceivedNotification(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            //Here we declare the parameter which we have to use in our applFication
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("GetFriendReceivedNotification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 50).Value = id;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    // Fill the DataSet using default values for DataTable names, etc
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public int MarkNotificationAsRead(int nId)
        {
            int  result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("MarkNotificationAsRead"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NotID", nId);

                        cmd.Connection = con;
                        con.Open();
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return result;
            }
        }

        public DataSet IsPostLiked(int pID , int uID)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from PostLikes where PostID=@pid AND @uID=UserID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }


    }
}