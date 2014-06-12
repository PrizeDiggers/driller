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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (result) //返回true授权成功
            //{
            //    var Sina = new NetDimension.Weibo.Client(oauth);
            //    var uid = Sina.API.Entity.Account.GetUID(); //调用API中获取UID的方法
            //    //var status = Sina.API.Entity.Statuses.Update(string.Format("@这条测试微博在{0}自动发出", DateTime.Now.ToString()));
            //    //var status = Sina.API.Entity.Users.Show(uid);
            //    lbltest.Text = uid.ToString();




        }
    }
}