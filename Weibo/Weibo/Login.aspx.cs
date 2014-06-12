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

namespace Weibo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblMessage.Visible = false;
            }
        }
        protected void btnlogin_OnClick(Object sender, EventArgs e)
        {
            var oauth = Function.GetAuth();
            bool result = Function.ClientLogin(oauth, txtAccount.Text, txtPassword.Text);
            if (result)
            {
                Session["oauth"] = oauth;
                Response.Redirect("Default.aspx?accesstoken=" + oauth.AccessToken);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Login Failed, try again!";
            }
        }
    }
}