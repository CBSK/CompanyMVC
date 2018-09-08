using Company.Models.Models;
using Company.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyTBL companyTBL)
        {
            if (ModelState.IsValid)
            {
                _companyService.Add(companyTBL);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePartial(CompanyTBL companyTBL)
        {
            if (ModelState.IsValid)
            {
                _companyService.Add(companyTBL);
                return RedirectToAction("Index");
            }

            return PartialView("CreatePartial", companyTBL);
        }

        public PartialViewResult CreatePartial()
        {
            var data = new CompanyTBL();
            return PartialView("CreatePartial", data);
        }

        public ActionResult Delete(Guid? id)
        {
            var data = _companyService.GetCompany((Guid)id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(CompanyTBL companyTBL)
        {
            _companyService.DeleteCompany(companyTBL);
            return RedirectToAction("Index");
        }

        public PartialViewResult DeptDetailsView(Guid? id)
        {
            CompwiseDepts m = new CompwiseDepts();

            m.companyTBL = _companyService.GetCompany((Guid)id);
            m.depts = _companyService.GetDeptList(m.companyTBL.id);
            return PartialView("DeptDetailsView", m);
        }

        public ActionResult Details(Guid? id)
        {
            CompwiseDepts compwiseDepts = new CompwiseDepts();
            compwiseDepts.companyTBL = _companyService.GetCompany((Guid)id);
            compwiseDepts.depts = _companyService.GetDeptList((Guid)id);
            return View(compwiseDepts);
        }

        public ActionResult Edit(Guid? id)
        {
            var data = _companyService.GetCompany((Guid)id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyTBL companyTBL)
        {
            if (ModelState.IsValid)
            {
                _companyService.UpdateCompany(companyTBL);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: Company
        public ActionResult Index()
        {
            var data = _companyService.GetCompanylist();
            return View(data);
        }
    }
}