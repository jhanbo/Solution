using System.Web.Mvc;
using ITGateWorkDesk.Web.Mvc.Models;
using System;
using System.Web.Security;
using ITGateWorkDesk.Web.Mvc.Membership;
using System.Web;


namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        private MembershipProvider _membershipService;
        public MembershipProvider MembershipService
        {
           
            set { _membershipService = value; }
            get { return _membershipService; }
        }


        public ActionResult LogIn()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
               
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model, string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    if (MembershipService.ValidateUser(model.UserName, model.Password))
                    {
                        FormsService.SignIn(model.UserName, model.RememberMe);
                       ITGateWorkDesk.Data.Domain.User user = ((ITGMembershipProvider)_membershipService).getCurrentUser(model.UserName);
                        string userData=user.IditgUser+","+user.UserName+","+user.FirstName+","+user.MiddleName+","+user.LastName+","+user.GfName+","+user.Orgunit.Name+","+user.Phone+","+user.Mobile+","+user.Notes;
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                          model.UserName,
                          DateTime.Now,
                          DateTime.Now.AddDays(1),
                          model.RememberMe,
                          userData,
                          FormsAuthentication.FormsCookiePath);

                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        // Create the cookie.
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                        ///
                        if (!String.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", Resources.Resources.UserNameOrPasswordisWrong);
                    }
                }
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult LogOut()
        {
            FormsService.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }


        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (_membershipService.ChangePassword(User.Identity.Name, changePasswordModel.OldPassword, changePasswordModel.NewPassword))
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", Resources.Resources.IncorrectOldPassword);
            return View(changePasswordModel);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}