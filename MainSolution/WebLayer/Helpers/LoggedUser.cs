using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITGateWorkDesk.Web.Mvc.Membership;


namespace ITGateWorkDesk.Web.Mvc.Helpers
{
    public static class LoggedUserHelper 
    {
        public static UserData GetLogedUserData(this System.Web.Mvc.HtmlHelper helper)
        {
           return  LoggedUserDataUtil.getUserData();
        }

    
    }
}