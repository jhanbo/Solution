using System;
using System.Collections;
//using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ITGateWorkDesk.Data.Domain;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Web.Mvc.Helpers;
using ITGateWorkDesk.Web.Mvc.Membership;
using ITGateWorkDesk.Web.Mvc.Models;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class CorrespondenceController : Controller
    {
        #region Services
        private CorrespondenceService _service;
        public CorrespondenceService Service
        {
            get { return _service; }
            set { _service = value; }
        }

        private CorrespondenceStateService _correspondenceStateService;
        public CorrespondenceStateService CorrespondenceStateService
        {
            get { return _correspondenceStateService; }
            set { _correspondenceStateService = value; }
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

        private CorrespondenceAttachmentService _correspondenceAttachmentService;
        public CorrespondenceAttachmentService CorrespondenceAttachmentService
        {
            get { return _correspondenceAttachmentService; }
            set { _correspondenceAttachmentService = value; }
        }

        private CorrespondenceDraftService _draftService;
        public CorrespondenceDraftService DraftService
        {
            get { return _draftService; }
            set { _draftService = value; }
        }

        private MembershipProvider _membershipProvider;
        public MembershipProvider MembershipProvider
        {
            get { return _membershipProvider; }
            set { _membershipProvider = value; }
        }

        private User CurrentUser
        {
            get { return ((ITGMembershipProvider)_membershipProvider).getCurrentUser(User.Identity.Name); }
        }
        #endregion

        #region Index
        public ActionResult Index(string msg = "")
        {
            ViewBag.Message = msg ?? "";
            ViewBag.CountOfCorrs = _service.GetAll().Count;
            return View(new List<CorrespondenceModel>());
        }
        #endregion

        #region Create
        public ActionResult Create(int? external, int? incoming, int? draft, int? decision)
        {
            int draftID = draft ?? -1;
            int isDecesion = decision ?? 0;
            ViewBag.CorrTypes = _service.GetTypesList().Select(ct => new SelectListItem { Value = ct.ID.ToString(), Text = ct.CorrTypeDesc });
            ViewBag.Orgunits = OrgunitService.GetAll().Select(o => o.CreateModel()).Where(o => o.Parent == null);
            ViewBag.States = _correspondenceStateService.GetAll();

            if (draftID == -1)
            {
                return View();
            }
            CorrespondenceDraft draftEntity = _draftService.GetByID(draftID);
            CorrespondenceModel model = new CorrespondenceModel
                                            {
                                                AttachmentsCount = draftEntity.AttachementsCount,
                                                CorrespondenceType = draftEntity.CorrespondeceType==null?0:draftEntity.CorrespondeceType.ID,
                                                DeliveryMethod = draftEntity.DeliveryMethod,
                                                Devision = draftEntity.Devision,
                                                ID = draftEntity.CorrespondenceID,
                                                Orgunit = draftEntity.Orgunit == null ? 0 : draftEntity.Orgunit.IdOrgUnit,
                                                OrgunitLabel = draftEntity.Orgunit == null ? "" : draftEntity.Orgunit.Name,
                                                ParentID = draftEntity.Parent == null ? 0 : draftEntity.Parent.CorrespondenceId,
                                                PersonName = draftEntity.PersonName,
                                                RecordNo = draftEntity.RecordNo,
                                                Title = draftEntity.Title,
                                                RequireFollowup = draftEntity.RequireFollowup.Value == 1
                                            };
            if (draftEntity.Importance != null) model.Importance = draftEntity.Importance.Value;
            if (draftEntity.RecordDate != null) model.RecordDate = draftEntity.RecordDate.Value;
            if (draftEntity.IsInternal != null) model.IsInternal = draftEntity.IsInternal.Value == 1;
            if (draftEntity.IsSecret != null) model.IsSecret = draftEntity.IsSecret.Value == 1;
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [AcceptParameter(Name = "submitBtnName", Value = "Save")]
        public ActionResult Create(string submitBtnName, int? external, int? incoming, int? draft, int? decision, CorrespondenceModel model, FormCollection form)
        {
            int draftID = draft ?? -1;
            ValidateModel(model);
            int isDecesion = decision ?? 0;
            if (ModelState.IsValid)
            {
                Correspondence corr = CorrespondenceModelsHelper.CreateEntityFromModel(model);
                corr.IsDecision = isDecesion;
                _service.SetCorrespondenceType(corr, model.CorrespondenceType);
                corr.Orgunit = OrgunitService.GetByID(model.Orgunit);
                corr.User = CurrentUser;
                corr.State = _correspondenceStateService.GetByID(1);
                if (!String.IsNullOrWhiteSpace(model.Destinations))
                {
                    _service.SetDestinations(corr, model.Destinations.Split(',').Select(c => Convert.ToInt32(c)).ToList(), "TO");
                }
                if (!String.IsNullOrWhiteSpace(model.DestinationsCC))
                {
                    _service.SetDestinations(corr, model.DestinationsCC.Split(',').Select(c => Convert.ToInt32(c)).ToList(), "CC");
                }

                if (model.Attachments != null && model.Attachments.Count > 0)
                {
                    List<CorrespondenceAttachment> attachments = UploadAttachements(model.Attachments, corr);
                    corr.CorrAttachments = attachments;
                }
                _service.Create(corr);
                if (draftID != -1)
                {
                    _draftService.Delete(_draftService.GetByID(draftID));
                }
                return RedirectToAction("Index", new { msg = Resources.Resources.CorrespondenceCreateSuccess });
            }
            ViewBag.CorrTypes = _service.GetTypesList().Select(ct => new SelectListItem { Value = ct.ID.ToString(), Text = ct.CorrTypeDesc });
            ViewBag.Orgunits = OrgunitService.GetAll().Select(o => o.CreateModel());
            ViewBag.States = _correspondenceStateService.GetAll();
            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [AcceptParameter(Name = "submitBtnName", Value = "SaveAsDraft")]
        [ActionName("Create")]
        public ActionResult SaveAsDraft(CorrespondenceModel model)
        {
            CorrespondenceDraft draft = CorrespondenceModelsHelper.CreateDraftEntityFromModel(model);
            _draftService.Create(draft);
            return RedirectToAction("Index", new { msg = Resources.Resources.CorrespondenceCreateSuccess });
        }
        #endregion

        public void ValidateModel(CorrespondenceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Destinations))
            {
                ModelState.AddModelError("Destinations", Resources.Resources.CorrDestinationCannotBeEmpty);
            }
            else
            {
                if (model.Destinations.Contains(model.Orgunit.ToString()))
                {
                    ModelState.AddModelError("Destinations", Resources.Resources.DestIsSameAsOrigin);
                }

                if (!string.IsNullOrWhiteSpace(model.DestinationsCC))
                {
                    string[] tos = model.Destinations.Split(',');
                    string[] ccs = model.DestinationsCC.Split(',');
                    if (ccs.Any(tos.Contains))
                    {
                        ModelState.AddModelError("DestinationsCC",Resources.Resources.DestIsSameAsCC);
                    }
                }
            }

        }

        private List<CorrespondenceAttachment> UploadAttachements(List<HttpPostedFileBase> files,Correspondence entity)
        {
            List<CorrespondenceAttachment> attachments = new List<CorrespondenceAttachment>();
            foreach (var file in files)
            {
                if (file == null) { continue; }
                if (file.ContentLength > 0)
                {
                    
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    CorrespondenceAttachment atc = new CorrespondenceAttachment();
                    atc.Correspondence = entity;
                    atc.CreatedDate = DateTime.Now;
                    FileStream fs = new FileStream(path, FileMode.Open);

                    byte[] myData = new byte[fs.Length];
                    fs.Read(myData, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();

                    atc.DataFile = myData;
                    atc.Description = "";
                    atc.Name = fileName;
                    attachments.Add(atc);
                    //atc.DataFile=File
                }
            }
            return attachments;
        }
    
        public ActionResult Details(int? id)
        {
            int realID = id ?? -1;
            if (id == -1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Correspondence corr = _service.GetByID(realID);
                if (corr != null)
                {
                    CorrespondenceDetailsModel model = CorrespondenceModelsHelper.CreateDetailsModelFromEntity(corr,CurrentUser.Orgunit.IdOrgUnit);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index", new { msg = Resources.Resources.CorrIDDoesNotExists });
                }
            }
        }

        [HttpPost]
        public JsonResult Note(int CorrespondenceID, string Note)
        {
            try
            {
                _service.CreateNote(CorrespondenceID, Note, _userService.GetByID(1));
                return new JsonResult { Data = new { result = Resources.Resources.NoteSaveSuccess } };
            }
            catch
            {
                return new JsonResult { Data = new { result = Resources.Resources.NoteSaveError } };
            }
        }

        public JsonResult GetCorrespondencesCount()
        {
            int currentOrgUnit = CurrentUser.Orgunit.IdOrgUnit;
            int currUserId = CurrentUser.IditgUser;
            int internalIncome = _service.GetCountByType(true, true, currentOrgUnit, currUserId);
            int internalOutcome = _service.GetCountByType(true, false, currentOrgUnit, currUserId);
            int externalIncome = _service.GetCountByType(false, true, currentOrgUnit, currUserId);
            int externalOutcome = _service.GetCountByType(false, false, currentOrgUnit, currUserId);

            int incomeDecisions = _service.GetCountByType(true, true, currentOrgUnit, currUserId, true);
            int outcomeDecisions = _service.GetCountByType(true, false, currentOrgUnit, currUserId, true);

            JsonResult rsl = new JsonResult
                                 {
                                     Data =
                                         new
                                             {
                                                 internalIncome = internalIncome > 0 ? "<strong>" + internalIncome + "</strong>" : "" + internalIncome + "",
                                                 internalOutcome = internalOutcome > 0 ? "<strong>" + internalOutcome + "</strong>" : "" + internalOutcome + "",
                                                 externalIncome = externalIncome > 0 ? "<strong>" + externalIncome + "</strong>" : "" + externalIncome + "",
                                                 externalOutcome = externalOutcome > 0 ? "<strong>" + externalOutcome + "</strong>" : "" + externalOutcome + "",

                                                 incomeDecisions = incomeDecisions > 0 ? "<strong>" + incomeDecisions + "</strong>" : "" + incomeDecisions + "",
                                                 outcomeDecisions = outcomeDecisions > 0 ? "<strong>" + outcomeDecisions + "</strong>" : "" + outcomeDecisions + ""

                                             }
                                 };
            return rsl;
        }

        public ActionResult List(int external = 0, int incoming = 0)
        {
            CorrespondenceFilterModel model = new CorrespondenceFilterModel();
            var states =
                _correspondenceStateService.GetAll().Select(
                    c => new SelectListItem { Text = c.Description, Value = c.ID.ToString() }
                ).ToList();
            states.Insert(0, new SelectListItem {Text = Resources.Resources.State, Value = "-1"});
            ViewBag.StatesList = states;
            ViewBag.PageTitle = CreatePageTitle(external, incoming);
            return View(model);
        }

        private string CreatePageTitle(int external,int incoming)
        {
            if (external == 0)
            {
                return incoming == 0 ? Resources.Resources.InternalOutcome : Resources.Resources.InternalIncome;
            }
            return incoming == 0 ? Resources.Resources.ExternalOutcome : Resources.Resources.ExternalIncome;
        }

        [HttpPost]
        public ActionResult List(CorrespondenceFilterModel model, int external = 0, int incoming = 0)
        {
            if (model == null)
            {
                return RedirectToAction("List", new {external = external, incoming = incoming});
            }
            bool isInternal = external == 0;
            bool isIncoming = incoming > 0;
            int userId = CurrentUser.IditgUser;
            int orgunitId = CurrentUser.Orgunit.IdOrgUnit;

            var list = _service.GetByType(isInternal, isIncoming, orgunitId, userId);
            //            .Where(c => model.State != -1 && c.State.ID == model.State)
            //            .Where(c => !model.FromDate.HasValue || (c.CreatedDate != null && c.CreatedDate.Value.Date >= model.FromDate.Value))
            //            .Where(c => !model.ToDate.HasValue || (c.CreatedDate != null && c.CreatedDate.Value.Date >= model.ToDate.Value));

            var finalList = list;
            if (model.State != -1)
            {
                finalList = list.Where(c => c.State.ID == model.State);
            }
            if (model.FromDate.HasValue)
            {
                finalList =
                    finalList.Where(c => c.CreatedDate != null && c.CreatedDate.Value.Date >= model.FromDate.Value);
            }
            if (model.ToDate.HasValue)
            {
                finalList =
                    finalList.Where(c => c.CreatedDate != null && c.CreatedDate.Value.Date <= model.ToDate.Value.Date);
            }

            ViewBag.IsInternal = true;
            ViewBag.IsIncoming = true;
            ViewBag.CorrList = finalList.Select(c => CorrespondenceModelsHelper.CreateDetailsModelFromEntity(c, CurrentUser.Orgunit.IdOrgUnit));
            var states =
                 _correspondenceStateService.GetAll().Select(
                     c => new SelectListItem { Text = c.Description, Value = c.ID.ToString() }
                 ).ToList();
            states.Insert(0, new SelectListItem { Text = Resources.Resources.State, Value = "-1" });
            ViewBag.StatesList = states;
            ViewBag.PageTitle = CreatePageTitle(external, incoming);

            return View(model);
        }

        public FileResult Download(int id)
        {
            var file = _correspondenceAttachmentService.GetByID(id);
            var data = file.DataFile;
            string path = Server.MapPath("~/App_data/downloads/" + file.Name);
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(data, 0, data.Length);
            bw.Flush();
            bw.Close();
            const string contentType = "application";
            return File(path, contentType, file.Name);
        }

        [HttpPost]
        public ActionResult Confirm(CorrespondenceModel model)
        {
            return PartialView(model);
        }

        public ActionResult Drafts()
        {
            int userId = CurrentUser.IditgUser;
            var drafts = _draftService.GetAllByUserID(userId).Select(c=>new CorrespondenceDraftModel
                                                                            {
                                                                                ID = c.DraftID,
                                                                                CorrespondenceID = c.CorrespondenceID,
                                                                                CorrespondenceTitle = c.Title,
                                                                                DraftDate = c.DraftCreateDate
                                                                            });
            return View(drafts);
        }

        public ActionResult Decisions()
        {
            var states =
               _correspondenceStateService.GetAll().Select(
                   c => new SelectListItem { Text = c.Description, Value = c.ID.ToString() }
               ).ToList();
            states.Insert(0, new SelectListItem { Text = Resources.Resources.State, Value = "-1" });
            ViewBag.StatesList = states;

            return View();
        }
        [HttpPost]
        public ActionResult Decisions(CorrespondenceFilterModel model, int? incoming)
        {
            var states =
               _correspondenceStateService.GetAll().Select(
                   c => new SelectListItem { Text = c.Description, Value = c.ID.ToString() }
               ).ToList();
            states.Insert(0, new SelectListItem { Text = Resources.Resources.State, Value = "-1" });
            ViewBag.StatesList = states;

            bool isIncome = (incoming ?? 0) > 0;
            ViewBag.CorrList =
                _service.GetDecisions(CurrentUser.Orgunit.IdOrgUnit, CurrentUser.IditgUser, isIncome).Select(
                    CorrespondenceModelsHelper.CreateDetailsModelFromEntity);
            return View(model);
        }
    }
}