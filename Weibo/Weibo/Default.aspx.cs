using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Weibo.Utilities;
using System.Data.SqlClient;


namespace Weibo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] != null)
            {
                User User = Function.GetUser(Convert.ToInt32(Session["UID"]));

                if (User == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}