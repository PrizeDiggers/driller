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
                    BindList();
            }
        }

        public string LoadUserInfo()
        {
            OAuth oauth = (OAuth)Session["oauth"];
            Client Sina = new NetDimension.Weibo.Client(oauth);
            var uid = Sina.API.Entity.Account.GetUID();
            string UserDetails = Sina.API.Entity.Users.Show(uid).ToString();
            //WebClient c = new WebClient();
            //JObject o = JObject.Parse(UserDetails);
            //lblName.Text = "Welcome back - " + o["screen_name"].ToString();
            return string.Format("{0}", UserDetails);
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string status = string.Empty;
            OAuth oauth = (OAuth)Session["oauth"];
            Client Sina = new NetDimension.Weibo.Client(oauth);
            if (txtStatusBody.Text.Length == 0)
            {
                status = "我很懒，所以我直接点了发布按钮。";
            }
            else
            {
                status = txtStatusBody.Text;
            }


            if (fileUpload.HasFile)
            {
                Sina.API.Entity.Statuses.Upload(status, fileUpload.FileBytes, 0, 0, null);
            }
            else
            {
                Sina.API.Entity.Statuses.Update(status, 0, 0, null);
            }

            Response.Redirect("Default.aspx");
        }

        public void BindList()
        {
            OAuth oauth = (OAuth)Session["oauth"];
            Client Sina = new NetDimension.Weibo.Client(oauth);
            IEnumerable<NetDimension.Weibo.Entities.user.Entity> json = Sina.API.Entity.Suggestions.HotUsers(HotUserCatagory.@default);

            List<NetDimension.Weibo.Entities.user.Entity> ds = new List<NetDimension.Weibo.Entities.user.Entity>();

            int count = 0;
            foreach (NetDimension.Weibo.Entities.user.Entity x in json)
            {
                ds.Add(x);
                if (++count == 3)
                    break;
            }

            rtpFamous.DataSource = ds;
            rtpFamous.DataBind();

        }
    }
}
