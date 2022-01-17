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
    public class Cust_RequestController : Controller
    {
        private PHONEEntities db = new PHONEEntities();

        // GET: Cust_Request
        public ActionResult Index()
        {
            if (Session["Role"] != null)
            {
                ViewBag.Role = Session["Role"];
            }
            var cust_Request = db.Cust_Request.Include(c => c.Color).Include(c => c.Device).Include(c => c.Operating_Sy).Include(c => c.ProblemDesc).Include(c => c.Province).Include(c => c.storage);
            return View(cust_Request.ToList());
        }

        // GET: Cust_Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Request cust_Request = db.Cust_Request.Find(id);
            if (cust_Request == null)
            {
                return HttpNotFound();
            }
            return View(cust_Request);
        }

        // GET: Cust_Request/Create
        public ActionResult Create()
        {
            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name");
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name");
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os");
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name");
            ViewBag.Prov_ID = new SelectList(db.Provinces, "Prov_ID", "Province1");
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name");
            return View();
        }

        // POST: Cust_Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustReq_Id,Home_Adress,Pick_Date,pick_Time,Brand_ID,Problem_ID,Storg_ID,OS_Id,Col_ID,IMEI_Num,Prov_ID,B_Price,P_Price,T_Price,Dev_Status")] Cust_Request cust_Request)
        {
          
            if (ModelState.IsValid)
            {
                cust_Request.B_Price = cust_Request.CalcBPrice();
                cust_Request.P_Price = cust_Request.CalcPickUpPrice();
                cust_Request.T_Price = cust_Request.CalcTotalPrice();
                db.Cust_Request.Add(cust_Request);
                db.SaveChanges();
                return RedirectToAction("Index","ThankYouRequest");
            }

            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name", cust_Request.Col_ID);
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name", cust_Request.Brand_ID);
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os", cust_Request.OS_Id);
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name", cust_Request.Problem_ID);
            ViewBag.Prov_ID = new SelectList(db.Provinces, "Prov_ID", "Province1", cust_Request.Prov_ID);
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name", cust_Request.Storg_ID);
            return View(cust_Request);
        }

        // GET: Cust_Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Request cust_Request = db.Cust_Request.Find(id);
            if (cust_Request == null)
            {
                return HttpNotFound();
            }
            if (Session["Role"] != null)
            {
                ViewBag.Role = Session["Role"];
            }
            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name", cust_Request.Col_ID);
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name", cust_Request.Brand_ID);
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os", cust_Request.OS_Id);
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name", cust_Request.Problem_ID);
            ViewBag.Prov_ID = new SelectList(db.Provinces, "Prov_ID", "Province1", cust_Request.Prov_ID);
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name", cust_Request.Storg_ID);
            return View(cust_Request);
        }

        // POST: Cust_Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustReq_Id,Home_Adress,Pick_Date,pick_Time,Brand_ID,Problem_ID,Storg_ID,OS_Id,Col_ID,IMEI_Num,Prov_ID,B_Price,P_Price,T_Price,Dev_Status")] Cust_Request cust_Request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust_Request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Col_ID = new SelectList(db.Colors, "Col_ID", "C_Name", cust_Request.Col_ID);
            ViewBag.Brand_ID = new SelectList(db.Devices, "Brand_ID", "Brand_Name", cust_Request.Brand_ID);
            ViewBag.OS_Id = new SelectList(db.Operating_Sy, "OS_Id", "Device_os", cust_Request.OS_Id);
            ViewBag.Problem_ID = new SelectList(db.ProblemDescs, "Problem_ID", "Problem_Name", cust_Request.Problem_ID);
            ViewBag.Prov_ID = new SelectList(db.Provinces, "Prov_ID", "Province1", cust_Request.Prov_ID);
            ViewBag.Storg_ID = new SelectList(db.storages, "Storg_ID", "Storg_Name", cust_Request.Storg_ID);
            return View(cust_Request);
        }

        // GET: Cust_Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Request cust_Request = db.Cust_Request.Find(id);
            if (cust_Request == null)
            {
                return HttpNotFound();
            }
            return View(cust_Request);
        }

        // POST: Cust_Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cust_Request cust_Request = db.Cust_Request.Find(id);
            db.Cust_Request.Remove(cust_Request);
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
