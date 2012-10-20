using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace ITGateWorkDesk.Web.Mvc.Membership
{
    public static class LoggedUserDataUtil
    {

        public static UserData getUserData()
        {
            FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = identity.Ticket;
            string userDataCockie = ticket.UserData;
            int version = ticket.Version;

            string[] userDatas = Regex.Split(userDataCockie, ",");
            UserData userData = new UserData();
            if (string.IsNullOrWhiteSpace(userDataCockie))
            {
                return userData;
            }
            userData.IditgUser = userDatas[0];
            userData.UserName = userDatas[1];
            userData.FirstName = userDatas[2];
            userData.MiddleName = userDatas[3];
            userData.LastName = userDatas[4];
            userData.GfName = userDatas[5];
            userData.OrgunitName = userDatas[6];
            userData.Phone = userDatas[7];
            userData.Mobile = userDatas[8];
            userData.Notes = userDatas[9];
            return userData;
 

        }
    }

    public class UserData
    {
       public  string IditgUser;
       public string UserName;
       public string FirstName;
       public string MiddleName;
       public string LastName;
       public string GfName;
       public string OrgunitName;
       public string Phone;
       public string Mobile;
       public string Notes;
    }
}