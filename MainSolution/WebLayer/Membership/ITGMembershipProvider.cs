using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ITGateWorkDesk.Data.Services.Impl;
using System.Web.Configuration;
using System.Collections.Specialized;
using System.Configuration.Provider;
using ITGateWorkDesk.Data.Domain;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using ITGateWorkDesk.Data.DAO.Impl;

namespace ITGateWorkDesk.Web.Mvc.Membership
{
    public class ITGMembershipProvider : MembershipProvider
    {

        private UserService _userService;
        private Boolean _requiresUniqueEmail;
        public UserService UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }
        private OrgUnitService _orgUnitService;
        public OrgUnitService OrgUnitService
        {
            get { return _orgUnitService; }
            set { _orgUnitService = value; }
        }
        public ITGMembershipProvider() { }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            User user = _userService.GetUserByName(username);
            if (user.Pass == oldPassword)
            {
                user.Pass = newPassword;
                _userService.Update(user);
                return true;
            }
            return false;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }




        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {

            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);
            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (GetUserNameByEmail(email) != "")
            {
                status = MembershipCreateStatus.DuplicateEmail;

                return null;
            }

            if (GetUserNameByUserName(username) != "")
            {
                status = MembershipCreateStatus.DuplicateUserName;

                return null;
            }

            User user = new User {UserName = username, Pass = password, Email = email, FirstName = "", LastName = ""};

            int isadded = _userService.Create(user);

            status = isadded < 0 ? MembershipCreateStatus.UserRejected : MembershipCreateStatus.Success;
            return GetUser(username, false);

        }

        private string GetUserNameByUserName(string username)
        {
            User user = _userService.GetUserByName(username);
            return user != null ? user.UserName : "";
        }


        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {

            MembershipUserCollection userCollection = new MembershipUserCollection();
            IList<User> users = _userService.GetAll();
            foreach (User user in users)
            {
                MembershipUser memUser = GetMembershipUserFromUser(user);
                userCollection.Add(memUser);
            }
            totalRecords = users.Count;
            return userCollection;
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return GetMembershipUserByKeyOrUser(false, username, 0, userIsOnline);
        }

        private MembershipUser GetMembershipUserByKeyOrUser(bool isKeySupplied, string username, object providerUserKey, bool userIsOnline)
        {
            User user = null;
            MembershipUser memUser = null;
            user = _userService.GetUserByName(username);
            if (user != null)
            {
                memUser = GetMembershipUserFromUser(user);
            }
            return memUser;
        }

        private MembershipUser GetMembershipUserFromUser(User usr)
        {
            MembershipUser u =
                new MembershipUser("customMembership",
                                         usr.UserName,
                                         usr.IditgUser,
                                         usr.Email,
                                         string.Empty,//usr.PasswordQuestion,
                                         string.Empty,//usr.Comment,
                                        true,// usr.IsApproved,
                                        false,// usr.IsLockedOut,
                                        DateTime.Now,// usr.CreationDate,
                                        DateTime.Now,// usr.LastLoginDate,
                                         DateTime.Now,//usr.LastActivityDate,
                                        DateTime.Now,// usr.LastPasswordChangedDate,
                                      DateTime.Now);//   usr.LastLockedOutDate);
            return u;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }


        public ITGateWorkDesk.Data.Domain.User getCurrentUser(string userName){
            return _userService.GetUserByName(userName);
    }
        public override string GetUserNameByEmail(string email)
        {
            User user = _userService.GetUserNameByEMail(email);
            return user != null ? user.Email : "";
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {

            get { return _requiresUniqueEmail; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            User user = _userService.GetUserByName(username);
            return user != null && user.Pass.Equals(password);
        }
    }
}