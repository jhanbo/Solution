using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITGateWorkDesk.Data.Domain;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Web.Mvc.Models;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class CorrespondenceTypeController : Controller
    {
        private CorrespondenceTypeService _service;
        public CorrespondenceTypeService Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public ActionResult Index()
        {
            var types = _service.GetAll().Select(t => new CorrespondenceTypeModel
                                              {
                                                  ID = t.ID,
                                                  Code = t.CorrTypeCode,
                                                  Description = t.CorrTypeDesc
                                              });
            return View(types);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ID")]CorrespondenceTypeModel model)
        {
            if (ModelState.IsValid)
            {
                CorrespondenceType tp = new CorrespondenceType();
                tp.CorrTypeCode = model.Code;
                tp.CorrTypeDesc = model.Description;
                _service.Create(tp);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            CorrespondenceType tp = _service.GetByID(id);
            CorrespondenceTypeModel model = new CorrespondenceTypeModel
                                                {
                                                    ID = tp.ID,
                                                    Code = tp.CorrTypeCode,
                                                    Description = tp.CorrTypeDesc
                                                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CorrespondenceTypeModel model)
        {
            if (ModelState.IsValid)
            {
                CorrespondenceType tp = _service.GetByID(model.ID);
                tp.CorrTypeCode = model.Code;
                tp.CorrTypeDesc = model.Description;
                _service.Update(tp);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            CorrespondenceType tp = _service.GetByID(id);
            _service.Delete(tp);
            return RedirectToAction("Index");
        }
    }
}
