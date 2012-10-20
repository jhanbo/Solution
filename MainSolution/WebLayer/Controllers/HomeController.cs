using System.Collections;
using System.Web.Mvc;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Data.Domain;
using System.Collections.Generic;
using ITGateWorkDesk.Web.Mvc.Models;
using System.Linq;
using PagedList;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private string _message;
        public string Message
        {
            get { return _message ?? "Null"; }
            set { _message = value; }
        }

        private CorrespondenceService _corrService;
        public CorrespondenceService CorrespondenceService
        {
            get { return _corrService; }
            set { _corrService = value; }
        }

        private AssignmentService _assignmentService;
        public AssignmentService AssignmentService
        {
            get { return _assignmentService; }
            set { _assignmentService = value; }
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult LatestCorrespondences(int? page)
        {
            int pageNum = page ?? 1;
            var corrs = _corrService.GetAll().Select(CorrespondenceModelsHelper.CreateDetailsModelFromEntity);
            var paged = new PagedList<CorrespondenceDetailsModel>(corrs, pageNum, 10);

            

            return PartialView("LatestRelevantCorrespondeces", paged);
        }

        public ActionResult LatestAssignments(int? page)
        {
            int pageNum = page ?? 1;
            var referrals = _assignmentService.GetAll().Select(AssignmentModelsHelper.CreateViewModel);
            var pagedAssignments = new PagedList<AssignmentViewModel>(referrals, pageNum, 10);

            return PartialView("LatestRelevantReferrals", pagedAssignments);
        }

        public ActionResult LatestDecesions(int? page)
        {
            int pageNum = page ?? 1;
            var model = _corrService.GetDecisions(6, 1, true).Select(
                    CorrespondenceModelsHelper.CreateDetailsModelFromEntity);

            var paged = new PagedList<CorrespondenceDetailsModel>(model, pageNum, 10);

            return PartialView("LatestRelevantDecisions", paged);
        }
    }
}