using System;
using System.Linq;
using ITGateWorkDesk.Data.DAO.Base;
using ITGateWorkDesk.Data.Domain;
using NHibernate;

namespace ITGateWorkDesk.Data.DAO.Impl
{
    public class UserDao : DaoBase<User, Int32>
    {
        //public User GetUserByName(string userName)
        //{
        //    IQuery query= HibernateTemplate.SessionFactory.GetCurrentSession().CreateQuery("from itg_user where username=:user_name");
        //    query.SetString("user_name", userName);
        //    var list = query.List<User>();
        //    if (list.Count == 1)
        //    {
        //        return list[0] as User;
        //    }
        //    throw new Exception("Unknown user name");
        //}

        public User GetUserByName(string userName)
        {
            return GetAll().FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            //return query ?? null;
        }

        public User GetUserByEmail(string email)
        {
            return GetAll().FirstOrDefault(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
