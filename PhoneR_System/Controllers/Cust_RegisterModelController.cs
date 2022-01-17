using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using PhoneR_System.Models;

namespace PhoneR_System.Controllers
{
    public class Cust_RegisterModelController : Controller
    {
        private PHONEEntities db = new PHONEEntities();

        // GET: Cust_RegisterModel
        public ActionResult Index()
        {
            var cust_RegisterModel = db.Cust_RegisterModel.Include(c => c.Role);
            return View(cust_RegisterModel.ToList());
        }

        // GET: Cust_RegisterModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_RegisterModel cust_RegisterModel = db.Cust_RegisterModel.Find(id);
            if (cust_RegisterModel == null)
            {
                return HttpNotFound();
            }
            return View(cust_RegisterModel);
        }

        // GET: Cust_RegisterModel/Create
        public ActionResult Create()
        {
          

            return View();
        }

        // POST: Cust_RegisterModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "c_Reg_ID,Rol_ID,FtName,LastName,Phone,Email,Pass")] Cust_RegisterModel cust_RegisterModel)
        {
            var cust = (from c in db.Roles
                        where c.Rol == "Customer"
                        select c.Rol_ID).Single();
                 cust_RegisterModel.Rol_ID = cust;
            if (ModelState.IsValid)
            {
                
                db.Cust_RegisterModel.Add(cust_RegisterModel);
                db.SaveChanges();
                return RedirectToAction("Index","LogIn");
            }

           
            return View(cust_RegisterModel);
        }

        // GET: Cust_RegisterModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_RegisterModel cust_RegisterModel = db.Cust_RegisterModel.Find(id);
            if (cust_RegisterModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rol_ID = new SelectList(db.Roles, "Rol_ID", "Rol", cust_RegisterModel.Rol_ID);
            return View(cust_RegisterModel);
        }

        // POST: Cust_RegisterModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "c_Reg_ID,Rol_ID,FtName,LastName,Phone,Email,Pass")] Cust_RegisterModel cust_RegisterModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust_RegisterModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rol_ID = new SelectList(db.Roles, "Rol_ID", "Rol", cust_RegisterModel.Rol_ID);
            return View(cust_RegisterModel);
        }

        // GET: Cust_RegisterModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_RegisterModel cust_RegisterModel = db.Cust_RegisterModel.Find(id);
            if (cust_RegisterModel == null)
            {
                return HttpNotFound();
            }
            return View(cust_RegisterModel);
        }

        // POST: Cust_RegisterModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cust_RegisterModel cust_RegisterModel = db.Cust_RegisterModel.Find(id);
            db.Cust_RegisterModel.Remove(cust_RegisterModel);
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
