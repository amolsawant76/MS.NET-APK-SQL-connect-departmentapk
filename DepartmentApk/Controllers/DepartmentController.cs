using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentApk.Models;

namespace DepartmentApk.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index(string search = "")
        {
            dpEntities db = new dpEntities();

            ViewBag.search = search;
            List<department> department = db.departments.Where(temp => temp.Name.Contains(search)).ToList();
            return View(department);
        }
        public ActionResult Details(int id)
        {
            dpEntities db = new dpEntities();
            department p = db.departments.Where(temp => temp.Id == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(department p)
        {
            dpEntities db = new dpEntities();
            db.departments.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        public ActionResult Edit(int id)
        {
            dpEntities db = new dpEntities();
            department existingProduct = db.departments.Where(temp => temp.Id == id).FirstOrDefault();

            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Edit(department p)
        {
            dpEntities db = new dpEntities();
            department existingProduct = db.departments.Where(temp => temp.Id == p.Id).FirstOrDefault();
            existingProduct.Name = p.Name;

            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        public ActionResult Delete(int id)
        {
            dpEntities db = new dpEntities();
            department existingDepartment = db.departments.Where(temp =>temp.Id == id).FirstOrDefault();
            return View(existingDepartment);
        }
        [HttpPost]
        public ActionResult Delete(int id, department p)
        {
            dpEntities db = new dpEntities();
            department existingDepartment = db.departments.Where(temp =>temp.Id == id).FirstOrDefault();
            db.departments.Remove(existingDepartment);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
    }
}