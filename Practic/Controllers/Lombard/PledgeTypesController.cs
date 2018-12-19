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
    public class PledgeTypesController : Controller
    {
        private CarOrdersContext db = new CarOrdersContext();

        // GET: PledgeTypes
        public ActionResult Index()
        {
            return View(db.PledgeTypes.ToList());
        }

        // GET: PledgeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PledgeType pledgeType = db.PledgeTypes.Find(id);
            if (pledgeType == null)
            {
                return HttpNotFound();
            }
            return View(pledgeType);
        }

        // GET: PledgeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PledgeTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PledgeType pledgeType)
        {
            if (ModelState.IsValid)
            {
                db.PledgeTypes.Add(pledgeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pledgeType);
        }

        // GET: PledgeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PledgeType pledgeType = db.PledgeTypes.Find(id);
            if (pledgeType == null)
            {
                return HttpNotFound();
            }
            return View(pledgeType);
        }

        // POST: PledgeTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PledgeType pledgeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pledgeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pledgeType);
        }

        // GET: PledgeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PledgeType pledgeType = db.PledgeTypes.Find(id);
            if (pledgeType == null)
            {
                return HttpNotFound();
            }
            return View(pledgeType);
        }

        // POST: PledgeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PledgeType pledgeType = db.PledgeTypes.Find(id);
            db.PledgeTypes.Remove(pledgeType);
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
