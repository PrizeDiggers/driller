using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetDimension.Weibo;
using NetDimension.Weibo.Entities;
using NetDimension.Weibo.Interface;

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

    }
}