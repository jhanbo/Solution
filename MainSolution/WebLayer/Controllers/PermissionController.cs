
using System.Web.Mvc;
using ITGateWorkDesk.Web.Mvc.Models;
using ITGateWorkDesk.Data.Services.Impl;
using ITGateWorkDesk.Data.Domain;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class PermissionController : Controller
    {
        //
        // GET: /Permission/

        private PermissionService _permissionService;


        public PermissionService PermissionService
        {
            get { return _permissionService; }
            set { _permissionService = value; }
        }
        private RoleService _roleService;

        public RoleService RoleService
        {
            get { return _roleService; }
            set { _roleService = value; }
        }

        public ActionResult Index()
        {

            return View(_permissionService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(CreatePermissionModel model)
        {
            if (ModelState.IsValid)
            {
                Permission permission = new Permission();
                permission.Name = model.Name;
                permission.Code = model.Code;
                permission.Description = model.Description;
                _permissionService.Create(permission);
                return RedirectToAction("index", "Permission");
            }
            else
                return View(model);
        }

        public ActionResult Edit()
        {
            if ((Url.RequestContext.RouteData.Values["id"] != null))
            {
                Permission SelectedPermission = _permissionService.GetByID(int.Parse(Url.RequestContext.RouteData.Values["id"].ToString()));
                EditPermissionModel editPermissionModel = new EditPermissionModel();
                editPermissionModel.PermissionID = SelectedPermission.IdPermission;
                editPermissionModel.Code = SelectedPermission.Code;
                editPermissionModel.Description = SelectedPermission.Description;
                editPermissionModel.Name = SelectedPermission.Name;
                return View(editPermissionModel);
            }
            else
                return RedirectToAction("index", "Permission");
        }

        [HttpPost]
        public ActionResult Edit(EditPermissionModel model)
        {
            Permission p = new Permission();
            if (ModelState.IsValid)
            {
                p.IdPermission = model.PermissionID;
                p.Name = model.Name;
                p.Code = model.Code;
                p.Description = model.Description;
                _permissionService.Update(p);
                return RedirectToAction("index", "Permission");
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult Delete()
        {
            if ((Url.RequestContext.RouteData.Values["id"] != null))
            {
                Permission p = _permissionService.GetByID(int.Parse(Url.RequestContext.RouteData.Values["id"].ToString()));
                _permissionService.Delete(p);
                return RedirectToAction("index", "Permission");
            }
            else
                return RedirectToAction("index", "Permission");


        }


    }
}
