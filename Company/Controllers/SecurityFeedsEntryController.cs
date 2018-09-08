using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models.Models;
using News.Services.IServices;
using System.Configuration;

namespace NewsAPI.Controllers
{
    public class SecurityFeedsEntryController : Controller
    {
        private readonly IServices_SecurityFeeds _securityfeedsServices;

        public SecurityFeedsEntryController(IServices_SecurityFeeds securityfeedsServices)
        {

            if (System.Web.HttpContext.Current.Session["UserName"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Login/index");
            }
            _securityfeedsServices = securityfeedsServices;
        }
        // GET: SecurityFeedsEntry
        public ActionResult Add(long SecurityFeedID = 0)
        {
            if (SecurityFeedID != 0)
            {
                var Newslist = _securityfeedsServices.GetSecurityFeedsListByID(SecurityFeedID) ?? new SecurityFeeds();

                var listitem = new SecurityFeeds
                {
                    SecurityFeedID = Newslist.SecurityFeedID,
                    ContentTitle = Newslist.ContentTitle,
                    ContentDescription = Newslist.ContentDescription,
                    ImagePath = Newslist.ImagePath,
                    Status = Newslist.Status,
                    ExpiryOn = Newslist.ExpiryOn,

                };
                return View(listitem);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult UploadFiles1()
        {
            string FileName = "";
            string fname = null;
            // string fname2 = null;
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";    
                //string filename = Path.GetFileName(Request.Files[i].FileName);    

                HttpPostedFileBase file = files[i];


                // Checking for Internet Explorer    
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                    //   fname2 = file.FileName;
                    FileName = file.FileName;
                }

                // Get the complete folder path and store the file inside it.    
                //   fname = Path.Combine(Server.MapPath("https://assets.pcmag.com/media/images/"), fname);
                fname = Path.Combine(HttpContext.Server.MapPath("~/media/images/"), fname);
                //fname = Path.Combine(Server.MapPath("~/media/images/"), fname);
                // fname2 = Path.Combine(Server.MapPath("~/media/images/"), fname2);
                file.SaveAs(fname);
                //  file.SaveAs(fname2);

            }
            return new JsonDateResult { Data = FileName, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult UploadFiles()
        {
            string FileName = "";
            string fname = null;
            var filecount = Request.Files.Count;
            if (filecount != 0)
            {
                var file = Request.Files[0];
                foreach (var item in Request.Files)
                {
                    var fName = file.FileName;
                    var path = HttpContext.Server.MapPath("/media/images/");
                    string actualPath = Path.Combine(path, fName);
                    file.SaveAs(actualPath);
                    FileName = file.FileName;
                }

            }
            return new JsonDateResult { Data = FileName, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
           
            //for (int i = 0; i < files.Count; i++)
            //{
            //    HttpPostedFileBase file = files[i];
            //        fname = file.FileName;
            //        FileName = file.FileName;

            //    fname = Path.Combine(HttpContext.Server.MapPath("~/media/images/"), fname);
            //    file.SaveAs(fname);
            //}
        }
        [HttpPost]
        public JsonResult SaveNews(SecurityFeeds DocObj)
        {
            var path = DocObj.ImagePath;
            var str = path.Substring(0, 4);
            DocObj.IsTop = false;
            if (str == "http")
            {
                DocObj.ImagePath = DocObj.ImagePath;
            }
            else
            {
                DocObj.ImagePath = !string.IsNullOrWhiteSpace(DocObj.ImagePath) ? ConfigurationManager.AppSettings["ApplicationPath"] + DocObj.ImagePath : DocObj.ImagePath;
            
            }
            
            if (DocObj.SecurityFeedID == 0)
            {
                DateTime now = DateTime.Now;
                DateTime modifiedDatetime = now.AddHours(15);

                DocObj.CreatedOn = modifiedDatetime;
            

            }
            DateTime updated = DateTime.Now;
            DateTime updatedDatetime = updated.AddHours(15);
            DocObj.UpdatedOn = updatedDatetime;
            _securityfeedsServices.SaveSecurityFeeds(DocObj);
            var data = _securityfeedsServices.GetSecurityFeedsListByID(DocObj.SecurityFeedID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSecurityFeedsByID(long SecurityFeedID)
        {
            try
            {
                var data = _securityfeedsServices.GetSecurityFeedsListByID(SecurityFeedID);
                return new JsonDateResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex) { throw ex; }


        }

        public ActionResult TopNews()
        {
            return View();
        }

        public JsonResult GetTopSecurityFeeds()
        {
            try
            {
                var d = _securityfeedsServices.GetTopSecurityFeeds().Where(w => w.ExpiryOn == null ? true : DateTime.Now.Date < (Convert.ToDateTime(w.ExpiryOn).Date)).ToList().Select(s => new { IsTop = s.IsTop ?? false, SecurityFeedID = s.SecurityFeedID, ContentTitle = s.ContentTitle, CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy hh:mm") }).ToList();
               
                return Json(new { result = d, msg = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "", msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SetTopeSecurityFeeds(TopFeedIds Ids)
        {
            try
            {
                _securityfeedsServices.SetTopSecurityFeeds(Ids.SelectedIds ?? new List<string>(), Ids.DeselectedIds ?? new List<string>());
                return Json(new { result = "", msg = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result = "", msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }


    public class TopFeedIds
    {
        public List<string> SelectedIds { get; set; }
        public List<string> DeselectedIds { get; set; }
    }



    public class JsonDateResult : JsonResult
    {
        // Summary:
        //     Enables processing of the result of an action method by a custom type that inherits
        //     from the System.Web.Mvc.ActionResult class.
        //
        // Parameters:
        //   context:
        //     The context within which the result is executed.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The context parameter is null.
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                var writer = new JsonTextWriter(response.Output) { Formatting = Formatting.Indented };
                var serializer = JsonSerializer.Create(new JsonSerializerSettings());
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }
}