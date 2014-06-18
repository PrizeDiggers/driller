using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetDimension.Weibo;
using NetDimension.Weibo.Entities;
using NetDimension.Weibo.Interface;
using System.Data;
using Weibo.Utilities;
using System.Data.SqlClient;

namespace Weibo.Utilities
{
    public class Function
    {
        public static OAuth GetAuth()
        {
            return new NetDimension.Weibo.OAuth("4073989006", "95146e7e981fdc30e447b59d6bbee127", "http://www.melovehouse.net");
        }
        public static bool ClientLogin(OAuth oauth, string Account, string password)
        {
            return oauth.ClientLogin(Account, password);
        }

        public static Client GetSina(OAuth oauth)
        {
            return new NetDimension.Weibo.Client(oauth);
        }

        public static User GetUser(int UID)
        {
            User user = new User();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(dbcon.DataBaseConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usr WHERE UID = @UID", con))
                {

                    cmd.Parameters.Add(new SqlParameter("@UID", UID));
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            if (dt.Rows.Count > 0)
            {
                user.UID = UID;
                user.FirstName = dt.Rows[0]["FirstName"].ToString();
                user.LastName = dt.Rows[0]["LastName"].ToString();
                user.AccessCode = dt.Rows[0]["AccessCode"].ToString();
                user.PassWord = dt.Rows[0]["PassWord"].ToString();
                user.Email = dt.Rows[0]["Email"].ToString();
                user.PositionID = Convert.ToInt32(dt.Rows[0]["PositionID"]);
                user.StatusID = Convert.ToInt32(dt.Rows[0]["StatusID"]);
            }
            return user;
        }

    }
}