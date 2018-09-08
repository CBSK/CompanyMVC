using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Company.Models.Models;
using Company.Repository;

namespace Company.Controllers
{
    public class DeptController : Controller
    {
        private OurdbContext db = new OurdbContext();

        // GET: Dept/Create
        public ActionResult Create(Guid? id)
        {
            DeptTBL t = new DeptTBL() { compId = (Guid)id };

            return View(t);
        }

        // POST: Dept/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,compId,deptDesc,deptName")] DeptTBL deptTBL)
        {
            if (ModelState.IsValid)
            {
                deptTBL.id = Guid.NewGuid();
                db.Dept.Add(deptTBL);
                db.SaveChanges();
                return RedirectToAction("Index", "Company");
            }

            return View(deptTBL);
        }

        // GET: Dept/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptTBL deptTBL = db.Dept.Find(id);
            if (deptTBL == null)
            {
                return HttpNotFound();
            }
            return View(deptTBL);
        }

        // POST: Dept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DeptTBL deptTBL = db.Dept.Find(id);
            db.Dept.Remove(deptTBL);
            db.SaveChanges();
            return RedirectToAction("Index", "Company");
        }

        // GET: Dept/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptTBL deptTBL = db.Dept.Find(id);
            if (deptTBL == null)
            {
                return HttpNotFound();
            }
            return View(deptTBL);
        }

        // GET: Dept/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptTBL deptTBL = db.Dept.Find(id);
            if (deptTBL == null)
            {
                return HttpNotFound();
            }
            return View(deptTBL);
        }

        // POST: Dept/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,compId,deptDesc,deptName")] DeptTBL deptTBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deptTBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            return View(deptTBL);
        }

        // GET: Dept
        public ActionResult Index()
        {
            return View(db.Dept.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}