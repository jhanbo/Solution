using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITGateWorkDesk.Web.Mvc.Helpers;

namespace ITGateWorkDesk.Web.Mvc.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/

        public ActionResult Upload()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                int count = 0;
                foreach (var file in files)
                {
                    if (file == null) { continue; }
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                        file.SaveAs(path);
                        count++;
                    }
                }
                return new JsonResult
                {
                    Data = new
                    {
                        status = "valid",
                        message = "Upload Successful " + count
                    }
                };
            }
            catch(Exception ex)
            {
                return new JsonResult
                {
                    Data = new
                    {
                        status = "invalid",
                        message = ex.Message
                    }
                };
            }
            
        }

        public ActionResult AddFile(int currentNo)
        {
            if (Request.IsAjaxRequest())
            {
                currentNo++;
                ViewBag.CurrentFilesCount = currentNo;
                return PartialView("Upload", currentNo);
            }
            return PartialView("Upload", 1);
        }
    }
}
