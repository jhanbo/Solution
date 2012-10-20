using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Web.Mvc.Models;
using ITGateWorkDesk.Data.Domain;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class OrgunitController : Controller
    {
        private OrgUnitService _service;
        public OrgUnitService Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public ActionResult Index()
        {
            var orgUnits = Service.GetAll().Select(o => o.CreateModel()).Where(o => o.Parent == null);
            return View(orgUnits);
        }

        public ActionResult Edit(int id)
        {
            var orgUnit = Service.GetByID(id);
            return View(orgUnit);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var orgUnit = Service.GetByID(id);
            TryUpdateModel(orgUnit, new String[] {"Name", "Code", "OrganizationType",
                "Phone", "Fax", "Email", "Notes",});
            if (ModelState.IsValid)
            {
                Service.Update(orgUnit);
                return RedirectToAction("Index");
            }
            return View(orgUnit);
        }

        public ActionResult Details(int id)
        {
            var orgUnit = Service.GetByID(id);
            return View(orgUnit);
        }

        public ActionResult Create()
        {
            ViewBag.Orgunits = _service.GetAll().Select(o => o.CreateModel());
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "IdOrgUnit")]
                                    OrganizationUnit orgUnit)
        {
            if (ModelState.IsValid)
            {
                Service.Create(orgUnit);
                return RedirectToAction("Index", new { msg = Resources.Resources.OrgUnitCreateSuccess });
            }
            return View();
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id)
        {
            var orgUnit = Service.GetByID(id);
            Service.Delete(orgUnit);
            return RedirectToAction("Index");
        }


    }
}
