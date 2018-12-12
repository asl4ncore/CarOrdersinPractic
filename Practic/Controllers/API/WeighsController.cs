using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Practic.Infrastructure.Data;
using Practic.Models;

namespace Practic.Controllers.API
{
    public class WeighsController : ApiController
    {
        private CarOrdersContext db = new CarOrdersContext();

        // GET: api/Weighs
        public IQueryable<Weigh> GetWeighs()
        {
            return db.Weighs;
        }

        // GET: api/Weighs/5
        [ResponseType(typeof(Weigh))]
        public IHttpActionResult GetWeigh(int id)
        {
            Weigh weigh = db.Weighs.Find(id);
            if (weigh == null)
            {
                return NotFound();
            }

            return Ok(weigh);
        }

        // PUT: api/Weighs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWeigh(int id, Weigh weigh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weigh.Id)
            {
                return BadRequest();
            }

            db.Entry(weigh).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeighExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Weighs
        [ResponseType(typeof(Weigh))]
        public IHttpActionResult PostWeigh(Weigh weigh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Weighs.Add(weigh);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = weigh.Id }, weigh);
        }

        // DELETE: api/Weighs/5
        [ResponseType(typeof(Weigh))]
        public IHttpActionResult DeleteWeigh(int id)
        {
            Weigh weigh = db.Weighs.Find(id);
            if (weigh == null)
            {
                return NotFound();
            }

            db.Weighs.Remove(weigh);
            db.SaveChanges();

            return Ok(weigh);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeighExists(int id)
        {
            return db.Weighs.Count(e => e.Id == id) > 0;
        }
    }
}