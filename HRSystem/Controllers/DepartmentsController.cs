using HRSystem.Data;
using HRSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new HRSystemEntities());

        // GET: Department
        public ActionResult Index()
        {
            
            return View(unitOfWork.Departments.GetAll());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = unitOfWork.Departments.SingleOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,Name,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Departments.Add(department);
                unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = unitOfWork.Departments.SingleOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,Name,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Departments.Update(department);
                unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = unitOfWork.Departments.SingleOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = unitOfWork.Departments.SingleOrDefault(d => d.DepartmentId == id);
            unitOfWork.Departments.Remove(department);
            unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
