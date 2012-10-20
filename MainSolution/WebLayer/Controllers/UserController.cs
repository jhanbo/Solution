using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITGateWorkDesk.Web.Mvc.Models;
using System.Web.Security;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Web.Mvc.Membership;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        private MembershipProvider _membershipProvider;
        private UserService _userService;
        private OrgUnitService _orgUnitService;

        public OrgUnitService OrgUnitService
        {
            get { return _orgUnitService; }
            set { _orgUnitService = value; }
        }

        public UserService UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }
      
        public MembershipProvider MembershipProvider
        {
            get { return _membershipProvider; }
            set { _membershipProvider = value; }
           
        }
       

        public ActionResult Index()
        {
           
            
            int x;
            return View(_membershipProvider.GetAllUsers(0,100,out x));
        }

        public ActionResult Create()
        {
            ViewBag.OrgUnits = _orgUnitService.GetAll().Select(OU => new SelectListItem { Value = OU.IdOrgUnit.ToString(), Text = OU.Name });
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            ViewBag.OrgUnits = _orgUnitService.GetAll().Select(OU => new SelectListItem { Value = OU.IdOrgUnit.ToString(), Text = OU.Name });
            if (ModelState.IsValid)
            {
             
             //   _membershipProvider = new Membership.ITGMembershipProvider();
                MembershipCreateStatus status;
                MembershipUser MemUser=_membershipProvider.CreateUser(model.UserName,model.Password,model.Email,string.Empty,string.Empty, true, null,out  status);
                if (MemUser != null)
                {
                    ITGateWorkDesk.Data.Domain.User user = _userService.GetByID((int)MemUser.ProviderUserKey);
                    if (user != null)
                    {
                        user.FirstName = model.FirstName;
                        user.LastName = model.LastName;
                        user.MiddleName = model.MiddleName;
                        user.GfName = model.GFname;
                        user.BirthDate = DateTime.ParseExact(model.BirthDate, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        user.JoinDate = DateTime.ParseExact(model.JoinDate, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        user.Phone = model.Phone;
                        user.Mobile = model.CellPhone;
                        user.Orgunit = _orgUnitService.GetByID(model.OrganizationUnitID);
                        user.Notes = model.Notes;
                        _userService.Update(user);

                    }

                }
                else
                {
                    if (status == MembershipCreateStatus.DuplicateEmail)
                    {
                        ModelState.AddModelError("", "Duplicate Email Please Choose Another Email");
                    }
                    else
                        if (status == MembershipCreateStatus.DuplicateUserName)
                        {
                            ModelState.AddModelError("", "Duplicate User Name Please Choose Another User Name");
                        }
                }
                return RedirectToAction("Index", "User"); ;
            }
            else return View(model);
        }


    }
}
