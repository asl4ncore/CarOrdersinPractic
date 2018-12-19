using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practic.Infrastructure.Data;
using Practic.Models;

namespace Practic.Controllers
{
    public class DeterminesController : Controller
    {
        private CarOrdersContext db = new CarOrdersContext();

        // GET: Determines
        public ActionResult Index()
        {
            return View(db.Determines.ToList());
        }

        // GET: Determines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Determine determine = db.Determines.Find(id);
            if (determine == null)
            {
                return HttpNotFound();
            }
            return View(determine);
        }

        // GET: Determines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Determines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AuditDate")] Determine determine)
        {
            if (ModelState.IsValid)
            {
                db.Determines.Add(determine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(determine);
        }

        // GET: Determines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Determine determine = db.Determines.Find(id);
            if (determine == null)
            {
                return HttpNotFound();
            }
            return View(determine);
        }

        // POST: Determines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AuditDate")] Determine determine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(determine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(determine);
        }

        // GET: Determines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Determine determine = db.Determines.Find(id);
            if (determine == null)
            {
                return HttpNotFound();
            }
            return View(determine);
        }

        // POST: Determines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Determine determine = db.Determines.Find(id);
            db.Determines.Remove(determine);
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
