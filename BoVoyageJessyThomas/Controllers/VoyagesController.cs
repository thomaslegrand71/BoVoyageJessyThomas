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
    [RoutePrefix("api/voyages")]
    public class VoyagesController : ApiController
    {    
        private ThomasEtJessyDbContext db = new ThomasEtJessyDbContext();

        // GET: api/Voyages
        public IQueryable<Voyage> GetVoyages()
        {    
            return db.Voyages.Include(x=>x.IDAgence).Include(x=>x.IDDestination).Where(x=>!x.Deleted);
        }

        [Route("{id:int}")]
        // GET: api/Voyages/5
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult GetVoyage(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            return Ok(voyage);
        }

        [Route("search")]
        [ResponseType(typeof(Voyage))]
        public IQueryable<Voyage> GetSearch(int? iddestination = null, int?idagence = null, DateTime?datealler=null, DateTime?dateretour=null, int?placesdisponibles= null, decimal?tariftoutcompris = null)
        {

            
            var query = db.Voyages.Include(x=>x.IDAgence).Include(x=>x.IDDestination).Where(x => !x.Deleted);
            if (iddestination!=null)
            {
                query = query.Where(x => x.IDDestination == iddestination);
            }
            if (idagence != null)
            {
                query = query.Where(x => x.IDAgence == idagence);
            }
            if (datealler != null)
            {
                query = query.Where(x => x.DateAller== datealler);
            }
            if (dateretour != null)
            {
                query = query.Where(x => x.DateRetour == dateretour);
            }
            if (placesdisponibles != null)
            {
                query = query.Where(x => x.PlacesDisponibles == placesdisponibles);
            }
            if (tariftoutcompris != null)
            {
                query = query.Where(x => x.TarifToutCompris == tariftoutcompris);
            }
            return query;
        }

        // PUT: api/Voyages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoyage(int id, Voyage voyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voyage.ID)
            {
                return BadRequest();
            }

            db.Entry(voyage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoyageExists(id))
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

        // POST: api/Voyages
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult PostVoyage(Voyage voyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voyages.Add(voyage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voyage.ID }, voyage);
        }

        // DELETE: api/Voyages/5
        [ResponseType(typeof(Voyage))]
        public IHttpActionResult DeleteVoyage(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            voyage.Deleted = true;
            voyage.DeletedAt = DateTime.Now;
            db.Entry(voyage).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(voyage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoyageExists(int id)
        {
            return db.Voyages.Count(e => e.ID == id) > 0;
        }
    }
}