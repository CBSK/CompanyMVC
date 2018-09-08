using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Services.IServices;
using Newtonsoft.Json;
using News.Common;

namespace NewsAPI.Controllers
{
    public class SecurityFeedsController : Controller
    {
        private readonly IServices_SecurityFeeds _securityfeedsServices;
        public SecurityFeedsController(IServices_SecurityFeeds securityfeedsServices)
        {
            if (System.Web.HttpContext.Current.Session["UserName"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Login/index");
            }
            _securityfeedsServices = securityfeedsServices;
        }
        // GET: SecurityFeeds
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GridTable(DTParameter model)
        {
            try
            {
                var datadetails = _securityfeedsServices.getPaginated(model);
                return Json(new { data = datadetails, model.recordsTotal, model.recordsFiltered });
                //return new JsonDateResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Delete(int key)
        {
            _securityfeedsServices.DeleteSecurityFeeds(key);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}