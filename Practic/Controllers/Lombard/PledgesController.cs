using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practic.Infrastructure.Data;
using Practic.Models.Models.Lombard;

namespace Practic.Controllers.Lombard
{
    public class PledgesController : Controller
    {
        private CarOrdersContext db = new CarOrdersContext();

        // GET: Pledges
        public ActionResult Index()
        {
            var pledges = db.Pledges.Include(p => p.PledgeType);
            return View(pledges.ToList());
        }

        // GET: Pledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pledge pledge = db.Pledges.Find(id);
            if (pledge == null)
            {
                return HttpNotFound();
            }
            return View(pledge);
        }

        // GET: Pledges/Create
        public ActionResult Create()
        {
            ViewBag.PledgeTypeId = new SelectList(db.PledgeTypes, "Id", "Name");
            return View();
        }

        // POST: Pledges/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sampling,NetWeight,TotalWeight,PledgeTypeId")] Pledge pledge)
        {
            if (ModelState.IsValid)
            {
                db.Pledges.Add(pledge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PledgeTypeId = new SelectList(db.PledgeTypes, "Id", "Name", pledge.PledgeTypeId);
            return View(pledge);
        }

        // GET: Pledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pledge pledge = db.Pledges.Find(id);
            if (pledge == null)
            {
                return HttpNotFound();
            }
            ViewBag.PledgeTypeId = new SelectList(db.PledgeTypes, "Id", "Name", pledge.PledgeTypeId);
            return View(pledge);
        }

        // POST: Pledges/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sampling,NetWeight,TotalWeight,PledgeTypeId")] Pledge pledge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pledge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PledgeTypeId = new SelectList(db.PledgeTypes, "Id", "Name", pledge.PledgeTypeId);
            return View(pledge);
        }

        // GET: Pledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pledge pledge = db.Pledges.Find(id);
            if (pledge == null)
            {
                return HttpNotFound();
            }
            return View(pledge);
        }

        // POST: Pledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pledge pledge = db.Pledges.Find(id);
            db.Pledges.Remove(pledge);
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
