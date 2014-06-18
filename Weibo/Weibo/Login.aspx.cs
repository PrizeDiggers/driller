using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetDimension.Weibo;
using NetDimension.Weibo.Entities;
using NetDimension.Weibo.Interface;
using Weibo.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Weibo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnlogin_OnClick(Object sender, EventArgs e)
        {
            User_Login(txtAccount.Text, txtPassword.Text);
            //var oauth = Function.GetAuth();
            //bool result = Function.ClientLogin(oauth, txtAccount.Text, txtPassword.Text);
            //if (result)
            //{
            //    Session["oauth"] = oauth;
            //    Response.Redirect("Default.aspx?accesstoken=" + oauth.AccessToken);
            //}
            //else
            //{
            //    lblMessage.Visible = true;
            //    lblMessage.Text = "Login Failed, try again!";
            //}
        }
        protected void User_Login(string AccessCode, string PassWord)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(dbcon.DataBaseConnection))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pr_User_Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AccessCode", AccessCode));
                    cmd.Parameters.Add(new SqlParameter("@PassWord", PassWord));
                    cmd.Parameters.Add(new SqlParameter("@IPAddress", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]));
                    cmd.Parameters.Add(new SqlParameter("@Session", HttpContext.Current.Session.SessionID.ToString()));
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["Valid"]) == 1)
                {
                    Session["UID"] = Convert.ToInt32(dt.Rows[0]["UID"]);
                    Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                    Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                    Session["AccessCode"] = dt.Rows[0]["AccessCode"].ToString();
                    Session["Password"] = dt.Rows[0]["PassWord"].ToString();
                    Session["Email"] = dt.Rows[0]["Email"].ToString();
                    Session["PositionID"] = Convert.ToInt32(dt.Rows[0]["PositionID"]);
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    lblMessage.Text = dt.Rows[0]["Msg"].ToString();
                }
            }

        }
    }
}