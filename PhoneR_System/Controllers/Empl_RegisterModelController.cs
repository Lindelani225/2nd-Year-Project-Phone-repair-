using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneR_System.Models;

namespace PhoneR_System.Controllers
{
    public class Empl_RegisterModelController : Controller
    {
        private PHONEEntities db = new PHONEEntities();

        // GET: Empl_RegisterModel
        public ActionResult Index()
        {
            var empl_RegisterModel = db.Empl_RegisterModels.Include(e => e.Role);
            return View(empl_RegisterModel.ToList());
        }

        // GET: Empl_RegisterModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empl_RegisterModel empl_RegisterModel = db.Empl_RegisterModels.Find(id);
            if (empl_RegisterModel == null)
            {
                return HttpNotFound();
            }
            return View(empl_RegisterModel);
        }

        // GET: Empl_RegisterModel/Create
        public ActionResult Create()
        {
            ViewBag.Rol_ID = new SelectList(db.Roles, "Rol_ID", "Rol");
            return View();
        }

        // POST: Empl_RegisterModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "c_Reg_ID,Rol_ID,FtName,LastName,Phone,Email,Emp_Rate,Emp_Hours,Emp_Wage,Pass")] Empl_RegisterModel empl_RegisterModel)
        {
            if (ModelState.IsValid)
            {
               // empl_RegisterModel.Emp_Wage = empl_RegisterModel.CalcWages();
                db.Empl_RegisterModels.Add(empl_RegisterModel);
                db.SaveChanges();
                return View("Index");
            }

            ViewBag.Rol_ID = new SelectList(db.Roles, "Rol_ID", "Rol", empl_RegisterModel.Rol_ID);
            return View(empl_RegisterModel);
        }

        // GET: Empl_RegisterModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empl_RegisterModel empl_RegisterModel = db.Empl_RegisterModels.Find(id);
            if (empl_RegisterModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rol_ID = new SelectList(db.Roles, "Rol_ID", "Rol", empl_RegisterModel.Rol_ID);
            return View(empl_RegisterModel);
        }

        // POST: Empl_RegisterModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "c_Reg_ID,Rol_ID,FtName,LastName,Phone,Email,Emp_Rate,Emp_Hours,Emp_Wage,Pass")] Empl_RegisterModel empl_RegisterModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empl_RegisterModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rol_ID = new SelectList(db.Roles, "Rol_ID", "Rol", empl_RegisterModel.Rol_ID);
            return View(empl_RegisterModel);
        }

        // GET: Empl_RegisterModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empl_RegisterModel empl_RegisterModel = db.Empl_RegisterModels.Find(id);
            if (empl_RegisterModel == null)
            {
                return HttpNotFound();
            }
            return View(empl_RegisterModel);
        }

        // POST: Empl_RegisterModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empl_RegisterModel empl_RegisterModel = db.Empl_RegisterModels.Find(id);
            db.Empl_RegisterModels.Remove(empl_RegisterModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
