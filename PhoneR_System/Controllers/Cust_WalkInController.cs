using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneR_System.Models;

namespace PhoneR_System.Controllers
{
    public class Cust_WalkInController : Controller
    {
        private PHONEEntities db = new PHONEEntities();
        
        // GET: Cust_WalkIn
        public ActionResult Index()
        {
       
            var cust_WalkIn = db.Cust_WalkIn.Include(c => c.Color).Include(c => c.Device).Include(c => c.Operating_Sy).Include(c => c.ProblemDesc).Include(c => c.storage);
            return View(cust_WalkIn.ToList());
        }

        // GET: Cust_WalkIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_WalkIn cust_WalkIn = db.Cust_WalkIn.Find(id);
            if (cust_WalkIn == null)
            {
                return HttpNotFound();
            }
            return View(cust_WalkIn);
        }

        // GET: Cust_WalkIn/Create
        public ActionResult Create()
        {
            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name");
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name");
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os");
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name");
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name");
            return View();
        }

        // POST: Cust_WalkIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Walk_Id,Walkin_Date,Walkin_Time,Brand_ID,Problem_ID,Storg_ID,OS_Id,Col_ID,IMEI_Num,B_Price")] Cust_WalkIn cust_WalkIn)
        {

            if (ModelState.IsValid)
            {
                cust_WalkIn.B_Price = cust_WalkIn.CalcAppPrice();
                db.Cust_WalkIn.Add(cust_WalkIn);         
                db.SaveChanges();
                return RedirectToAction("Index", "ThankYouWalkIn");
            }

            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name", cust_WalkIn.Col_ID);
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name", cust_WalkIn.Brand_ID);
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os", cust_WalkIn.OS_Id);
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name", cust_WalkIn.Problem_ID);
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name", cust_WalkIn.Storg_ID);
            return View(cust_WalkIn);
        }

        // GET: Cust_WalkIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_WalkIn cust_WalkIn = db.Cust_WalkIn.Find(id);
            if (cust_WalkIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name", cust_WalkIn.Col_ID);
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name", cust_WalkIn.Brand_ID);
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os", cust_WalkIn.OS_Id);
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name", cust_WalkIn.Problem_ID);
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name", cust_WalkIn.Storg_ID);
            return View(cust_WalkIn);
        }

        // POST: Cust_WalkIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Walk_Id,Walkin_Date,Walkin_Time,Brand_ID,Problem_ID,Storg_ID,OS_Id,Col_ID,IMEI_Num,B_Price")] Cust_WalkIn cust_WalkIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust_WalkIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name", cust_WalkIn.Col_ID);
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name", cust_WalkIn.Brand_ID);
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os", cust_WalkIn.OS_Id);
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name", cust_WalkIn.Problem_ID);
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name", cust_WalkIn.Storg_ID);
            return View(cust_WalkIn);
        }

        // GET: Cust_WalkIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_WalkIn cust_WalkIn = db.Cust_WalkIn.Find(id);
            if (cust_WalkIn == null)
            {
                return HttpNotFound();
            }
            return View(cust_WalkIn);
        }

        // POST: Cust_WalkIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cust_WalkIn cust_WalkIn = db.Cust_WalkIn.Find(id);
            db.Cust_WalkIn.Remove(cust_WalkIn);
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
