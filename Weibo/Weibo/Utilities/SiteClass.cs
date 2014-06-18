using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Weibo.Utilities
{

    public class dbcon
    {
        public const string DataBaseConnection = "Data Source=SQL5005.Smarterasp.net;Initial Catalog=DB_9ADD06_mylovehouse;User Id=DB_9ADD06_mylovehouse_admin;Password=19820825;";
    }
    public class User
    {
        public int UID;
        public string FirstName;
        public string LastName;
        public string AccessCode;
        public string PassWord;
        public string Email;
        public int PositionID;
        public int StatusID;
    }

}