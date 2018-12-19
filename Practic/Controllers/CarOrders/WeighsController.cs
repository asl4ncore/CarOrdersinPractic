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
using Practic.Unit;
using Practic.Infrastructure.Business;
using Newtonsoft.Json;

namespace Practic.Controllers
{
    public class WeighsController : Controller
    {
        UnitOfWork unit;
        private CarOrdersContext db = new CarOrdersContext();
        public WeighsController()
        {
            unit = new UnitOfWork();
        }
        // GET: Weighs
        public ActionResult Index()
        {
            var weighs = unit.WeighRepo.Get();
            return View(weighs);
        }
        public ActionResult New()
        {
           
            return View();
        }
        public ActionResult Vue()
        {
            var serverModel = JsonConvert.SerializeObject(new
            {
                Name = "Marco",
                Surname = "Muscat",
                Description = "Vue data loaded from razor!"
            });

            return View(new SampleModel()
            {
                Data = serverModel
            });
    }
        public class SampleModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Description { get; set; }
            public string Data { get; set; }
        }
        // GET: Weighs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weigh weigh = db.Weighs.Find(id);
            if (weigh == null)
            {
                return HttpNotFound();
            }
            return View(weigh);
        }

        // GET: Weighs/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id");
            return View();
        }
       
        // POST: Weighs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Weigh weigh)
        {

            if (ModelState.IsValid)
            {
                
                db.Weighs.Add(weigh);
                MeasureMath.SelectMeasure(weigh);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", weigh.OrderId);
            return View(weigh);
        }

        // GET: Weighs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weigh weigh = db.Weighs.Find(id);
            if (weigh == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", weigh.OrderId);
            return View(weigh);
        }

        // POST: Weighs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WeighFull,WeighPacking,WeighMaterial,WeighType,WeighDetermine,WeighContamination,OrderId,AuditDate")] Weigh weigh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weigh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", weigh.OrderId);
            return View(weigh);
        }

        // GET: Weighs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weigh weigh = db.Weighs.Find(id);
            if (weigh == null)
            {
                return HttpNotFound();
            }
            return View(weigh);
        }

        // POST: Weighs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weigh weigh = db.Weighs.Find(id);
            db.Weighs.Remove(weigh);
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
