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
    public class OperationsController : Controller
    {
        private CarOrdersContext db = new CarOrdersContext();

        // GET: Operations
        public ActionResult Index()
        {
            var operations = db.Operations.Include(o => o.Client).Include(o => o.Pledge);
            return View(operations.ToList());
        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "SurName");
            ViewBag.PledgeId = new SelectList(db.Pledges, "Id", "Name");
            return View();
        }

        // POST: Operations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,PledgeId,PriceGram,PriceProducts,PriceRefund,CommissionPercentage,StorageDay,PaymentDay,OperationDay,OperatorName")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "SurName", operation.ClientId);
            ViewBag.PledgeId = new SelectList(db.Pledges, "Id", "Name", operation.PledgeId);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "SurName", operation.ClientId);
            ViewBag.PledgeId = new SelectList(db.Pledges, "Id", "Name", operation.PledgeId);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,PledgeId,PriceGram,PriceProducts,PriceRefund,CommissionPercentage,StorageDay,PaymentDay,OperationDay,OperatorName")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "SurName", operation.ClientId);
            ViewBag.PledgeId = new SelectList(db.Pledges, "Id", "Name", operation.PledgeId);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operation operation = db.Operations.Find(id);
            db.Operations.Remove(operation);
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
