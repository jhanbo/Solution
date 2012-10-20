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
    public class SystemController : Controller
    {
        private SystemSettingService _service;
        public SystemSettingService Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public ActionResult Index()
        {
            var list = _service.GetAll().Select(s => new SystemSettingsModel
                                                         {
                                                             ID = s.SystemSettingId,
                                                             Name = s.Name,
                                                             Value = s.Value
                                                         });
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Create(SystemSettingsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SystemSetting settings = new SystemSetting();
                    settings.Name = model.Name;
                    settings.Value = model.Value;
                    _service.Create(settings);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        
 
        public ActionResult Edit(int id)
        {
            var entity = _service.GetByID(id);
            var model = new SystemSettingsModel
                            {
                                ID = entity.SystemSettingId,
                                Name = entity.Name,
                                Value = entity.Value
                            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, SystemSettingsModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SystemSetting settings = _service.GetByID(id);
                    settings.Name = model.Name;
                    settings.Value = model.Value;
                    _service.Update(settings);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

 
        public ActionResult Delete(int id)
        {
            _service.Delete(_service.GetByID(id));
            return RedirectToAction("Index");
        }
    }
}
