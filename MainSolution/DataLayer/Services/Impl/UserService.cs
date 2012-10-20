using System;
using ITGateWorkDesk.Data.DAO.Impl;
using ITGateWorkDesk.Data.Domain;
using ITGateWorkDesk.Data.Services.Base;
using System.Collections.Generic;

namespace ITGateWorkDesk.Data.Services.Impl
{
    public class UserService : ServiceBase<UserDao, User, Int32>
    {
        public User GetUserByName(string userName)
        {
            return Dao.GetUserByName(userName);
        }

        public int GetNumberOfUsersOnline(DateTime compareTime)
        {
            throw new NotImplementedException();
        }

        public User GetUserNameByEMail(string email)
        {
            return Dao.GetUserByEmail(email);
        }

        public IList<User> FindUsersByName(string usernameToMatch, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IList<User> FindUsersByEMail(string emailToMatch, int pageIndex, int pageSize, string _applicationName)
        {
            throw new NotImplementedException();
        }
    }
}
