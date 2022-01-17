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
    public class ProblemDescsController : Controller
    {
        private PHONEEntities db = new PHONEEntities();

        // GET: ProblemDescs
        public ActionResult Index()
        {
            return View(db.ProblemDescs.ToList());
        }

        // GET: ProblemDescs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDesc problemDesc = db.ProblemDescs.Find(id);
            if (problemDesc == null)
            {
                return HttpNotFound();
            }
            return View(problemDesc);
        }

        // GET: ProblemDescs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemDescs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Problem_ID,Problem_Name,Problem_BscCost")] ProblemDesc problemDesc)
        {
            if (ModelState.IsValid)
            {
                db.ProblemDescs.Add(problemDesc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problemDesc);
        }

        // GET: ProblemDescs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDesc problemDesc = db.ProblemDescs.Find(id);
            if (problemDesc == null)
            {
                return HttpNotFound();
            }
            return View(problemDesc);
        }

        // POST: ProblemDescs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Problem_ID,Problem_Name,Problem_BscCost")] ProblemDesc problemDesc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemDesc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(problemDesc);
        }

        // GET: ProblemDescs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemDesc problemDesc = db.ProblemDescs.Find(id);
            if (problemDesc == null)
            {
                return HttpNotFound();
            }
            return View(problemDesc);
        }

        // POST: ProblemDescs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemDesc problemDesc = db.ProblemDescs.Find(id);
            db.ProblemDescs.Remove(problemDesc);
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
