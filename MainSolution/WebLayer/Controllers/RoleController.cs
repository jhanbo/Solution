using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITGateWorkDesk.Web.Mvc.Models;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Data.Domain;


namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/


        private RoleService _roleService;

        public RoleService RoleService
        {
            get { return _roleService; }
            set { _roleService = value; }
        }



        public ViewResult Index()
        {
            var Roles = (from role in _roleService.GetAll()
                         select role).OrderBy(r => r.Name);
            return View(Roles);
        }

        public ActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public ActionResult Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                Role r = new Role();
                r.Name = model.Name;
                r.Description = model.Description;
                _roleService.Create(r);
            }
            return View(model);

        }
    }


}