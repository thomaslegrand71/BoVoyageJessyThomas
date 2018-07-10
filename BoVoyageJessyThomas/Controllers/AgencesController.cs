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
using BoVoyageJessyThomas.Data;
using BoVoyageJessyThomas.Models;

namespace BoVoyageJessyThomas.Controllers
{
    [RoutePrefix("api/agences")]
    public class AgencesController : ApiController
    {
       
        private ThomasEtJessyDbContext db = new ThomasEtJessyDbContext();

        // GET: api/Agences
        public IQueryable<Agence> GetAgences()
        {
            return db.Agences;
        }
        [Route("{id:int}")]
        // GET: api/Agences/5
        [ResponseType(typeof(Agence))]
        public IHttpActionResult GetAgence(int id)
        {
            Agence agence = db.Agences.Find(id);
            if (agence == null)
            {
                return NotFound();
            }

            return Ok(agence);
        }
        [Route("{name}")]
        [ResponseType(typeof(Agence))]
        public IQueryable<Agence> Getagence(string nom)
        {
            return db.Agences.Where(x => !x.Deleted && x.Nom.Contains(nom));
        }


        // PUT: api/Agences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgence(int id, Agence agence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agence.ID)
            {
                return BadRequest();
            }

            db.Entry(agence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenceExists(id))
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

        // POST: api/Agences
        [ResponseType(typeof(Agence))]
        public IHttpActionResult PostAgence(Agence agence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agences.Add(agence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agence.ID }, agence);
        }

        // DELETE: api/Agences/5
        [ResponseType(typeof(Agence))]
        public IHttpActionResult DeleteAgence(int id)
        {
            Agence agence = db.Agences.Find(id);
            if (agence == null)
            {
                return NotFound();
            }

            db.Agences.Remove(agence);
            db.SaveChanges();

            return Ok(agence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgenceExists(int id)
        {
            return db.Agences.Count(e => e.ID == id) > 0;
        }
    }
}