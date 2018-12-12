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
    public class RouteTypesController : Controller
    {
        private CarOrdersContext db = new CarOrdersContext();

        // GET: RouteTypes
        public ActionResult Index()
        {
            return View(db.RouteTypes.ToList());
        }

        // GET: RouteTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteType routeType = db.RouteTypes.Find(id);
            if (routeType == null)
            {
                return HttpNotFound();
            }
            return View(routeType);
        }

        // GET: RouteTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RouteTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AuditDate")] RouteType routeType)
        {
            if (ModelState.IsValid)
            {
                db.RouteTypes.Add(routeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routeType);
        }

        // GET: RouteTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteType routeType = db.RouteTypes.Find(id);
            if (routeType == null)
            {
                return HttpNotFound();
            }
            return View(routeType);
        }

        // POST: RouteTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AuditDate")] RouteType routeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routeType);
        }

        // GET: RouteTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteType routeType = db.RouteTypes.Find(id);
            if (routeType == null)
            {
                return HttpNotFound();
            }
            return View(routeType);
        }

        // POST: RouteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteType routeType = db.RouteTypes.Find(id);
            db.RouteTypes.Remove(routeType);
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
