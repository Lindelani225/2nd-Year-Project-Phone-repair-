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
    public class Operating_SyController : Controller
    {
        private PHONEEntities db = new PHONEEntities();

        // GET: Operating_Sy
        public ActionResult Index()
        {
            return View(db.Operating_Sy.ToList());
        }

        // GET: Operating_Sy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operating_Sy operating_Sy = db.Operating_Sy.Find(id);
            if (operating_Sy == null)
            {
                return HttpNotFound();
            }
            return View(operating_Sy);
        }

        // GET: Operating_Sy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operating_Sy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OS_Id,Device_os,OS_Rate")] Operating_Sy operating_Sy)
        {
            if (ModelState.IsValid)
            {
                db.Operating_Sy.Add(operating_Sy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operating_Sy);
        }

        // GET: Operating_Sy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operating_Sy operating_Sy = db.Operating_Sy.Find(id);
            if (operating_Sy == null)
            {
                return HttpNotFound();
            }
            return View(operating_Sy);
        }

        // POST: Operating_Sy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OS_Id,Device_os,OS_Rate")] Operating_Sy operating_Sy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operating_Sy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operating_Sy);
        }

        // GET: Operating_Sy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operating_Sy operating_Sy = db.Operating_Sy.Find(id);
            if (operating_Sy == null)
            {
                return HttpNotFound();
            }
            return View(operating_Sy);
        }

        // POST: Operating_Sy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operating_Sy operating_Sy = db.Operating_Sy.Find(id);
            db.Operating_Sy.Remove(operating_Sy);
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
