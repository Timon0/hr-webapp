using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRSystem.Models;
using HRSystem.Data;

namespace HRSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new HRSystemEntities());

        // GET: Employees
        public ActionResult Index()
        {
            return View(unitOfWork.Employees.GetAll());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.FkDepartment = new SelectList(unitOfWork.Departments.GetAll(), "DepartmentId", "Name");
            ViewBag.FkBoss = new SelectList(unitOfWork.Employees.GetAll(), "EmployeeId", "Firstname");
            ViewBag.FkPlace = new SelectList(unitOfWork.Places.GetAll(), "PlaceId", "Place1");
            return View();
        }

        // POST: Employees/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Firstname,Lastname,Birthday,Salary,Address,FkDepartment,FkPlace,FkBoss")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Employees.Add(employee);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.FkDepartment = new SelectList(unitOfWork.Departments.GetAll(), "DepartmentId", "Name");
            ViewBag.FkBoss = new SelectList(unitOfWork.Employees.GetAll(), "EmployeeId", "Firstname");
            ViewBag.FkPlace = new SelectList(unitOfWork.Places.GetAll(), "PlaceId", "Place1");
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkDepartment = new SelectList(unitOfWork.Departments.GetAll(), "DepartmentId", "Name", employee.FkDepartment);
            ViewBag.FkBoss = new SelectList(unitOfWork.Employees.GetAll(), "EmployeeId", "Firstname", employee.FkBoss);
            ViewBag.FkPlace = new SelectList(unitOfWork.Places.GetAll(), "PlaceId", "Place1", employee.FkPlace);
            ViewBag.FkProjects = unitOfWork.Projects.GetAll();
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Firstname,Lastname,Birthday,Salary,Address,FkDepartment,FkPlace,FkBoss")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Employees.Update(employee);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.FkDepartment = new SelectList(unitOfWork.Departments.GetAll(), "DepartmentId", "Name", employee.FkDepartment);
            ViewBag.FkBoss = new SelectList(unitOfWork.Employees.GetAll(), "EmployeeId", "Firstname", employee.FkBoss);
            ViewBag.FkPlace = new SelectList(unitOfWork.Places.GetAll(), "PlaceId", "Place1", employee.FkPlace);
            ViewBag.FkProjects = unitOfWork.Projects.GetAll();
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitOfWork.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = unitOfWork.Employees.SingleOrDefault(e => e.EmployeeId == id);
            unitOfWork.Employees.Remove(employee);
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
