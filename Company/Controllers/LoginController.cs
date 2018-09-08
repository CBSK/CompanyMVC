using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models.Models;
using News.Repository.IRepository;
using News.Repository;

namespace NewsAPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session["UserName"] = null;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Users logondetails)
        {

            if (ModelState.IsValid)
            {
                using (APIdbContext s1e = new APIdbContext())
                {
                    var obj = s1e.Users.Where(a => a.UserEmail.Equals(logondetails.UserEmail) && a.UserPassword.Equals(logondetails.UserPassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "SecurityFeeds");
                    }
                }
            }
            return View(logondetails);
        }
    }
}