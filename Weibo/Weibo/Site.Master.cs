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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Weibo
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["oauth"] == null)
                    Response.Redirect("Login.aspx");
                else
                {
                    var oauth = (OAuth)Session["oauth"];
                    var Sina = new NetDimension.Weibo.Client(oauth);
                    var uid = Sina.API.Entity.Account.GetUID();
                    string UserDetails = Sina.API.Entity.Users.Show(uid).ToString();
                    WebClient c = new WebClient();
                    JObject o = JObject.Parse(UserDetails);
                    lblName.Text = "Welcome back - " + o["screen_name"].ToString();
                }
            }
        }
    }
}
