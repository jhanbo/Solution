using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Web.Mvc.Models;
using ITGateWorkDesk.Data.Domain;
using System.IO;


namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentService _service;
        public AssignmentService Service
        {
            get { return _service; }
            set { _service = value; }
        }



        private OrgUnitService _orgunitService;
        public OrgUnitService OrgunitService
        {
            get { return _orgunitService; }
            set { _orgunitService = value; }
        }

        private UserService _userService;
        public UserService UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }

        private CorrespondenceService _correspondenceService;
        public CorrespondenceService CorrespondenceService
        {
            get { return _correspondenceService; }
            set { _correspondenceService = value; }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int corrID)
        {
            ViewBag.Orgunits = OrgunitService.GetAll().Select(o => o.CreateModel());
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int corrID, AssignmentModel model, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                model.User = 1;
                Assignment assignment = AssignmentModelsHelper.CreateEntityFromModel(model);
                assignment.Orgunit = OrgunitService.GetByID(model.Orgunit);
                assignment.Correspondence = CorrespondenceService.GetByID(corrID);
                if (model.AssignmentAttachments != null && model.AssignmentAttachments.Count > 0)
                {
                    List<AssignmentAttachment> attachments = UploadAttachements(model.AssignmentAttachments, assignment);
                    assignment.AssignmentAttachments = attachments;
                }
                int newId = _service.Create(assignment);
                return RedirectToAction("Index", new { msg = Resources.Resources.AssignmentCreateSuccess });
            }
            else
            {
                ViewBag.Orgunits = OrgunitService.GetAll().Select(o => o.CreateModel());
                return View(model);
            }
        }

        private List<AssignmentAttachment> UploadAttachements(IList<HttpPostedFileBase> files, Assignment assignment)
        {
            List<AssignmentAttachment> attachments = new List<AssignmentAttachment>();
            foreach (var file in files)
            {
                if (file == null) { continue; }
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    AssignmentAttachment attachment = new AssignmentAttachment();
                    attachment.Assignment = assignment;
                    attachment.CreatedDate = DateTime.Now;
                    FileStream fileStream = new FileStream(path, FileMode.Open);
                    attachment.DataFile = new byte[fileStream.Length];
                    fileStream.Write(attachment.DataFile, 0, (int)fileStream.Length);
                    attachment.Description = "";
                    attachment.Name = fileName;
                    attachments.Add(attachment);
                }
            }
            return attachments;

        }
    }
}
