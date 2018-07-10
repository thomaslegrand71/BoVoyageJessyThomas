﻿using System;
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
    [RoutePrefix("api/destinations")]
    public class DestinationsController : ApiController
    {
        private ThomasEtJessyDbContext db = new ThomasEtJessyDbContext();

        // GET: api/Destinations
        public IQueryable<Destination> GetDestinations()
        {
            return db.Destinations;
        }

        [Route("{id:int}")]
        // GET: api/Destinations/5
        [ResponseType(typeof(Destination))]
        public IHttpActionResult GetDestination(int id)
        {
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }
        [Route("search")]
        //Get : api/Destination/search
    
        [ResponseType(typeof(Destination))]
        public IQueryable<Destination> GetSearch(string continent="", string pays ="", string region="")
        {
            var query = db.Destinations.Where(x => !x.Deleted);
                if (!string.IsNullOrWhiteSpace(continent))
            {
                query = query.Where(x => x.Continent.Contains(continent));
            }
                if (!string.IsNullOrWhiteSpace(pays))
            {
                query = query.Where(x => x.Pays.Contains(pays));
            }
                if (!string.IsNullOrWhiteSpace(region))
            {
                query = query.Where(x => x.Region.Contains(region));
            }

            return query;
        }


        // PUT: api/Destinations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDestination(int id, Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != destination.ID)
            {
                return BadRequest();
            }

            db.Entry(destination).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationExists(id))
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

        // POST: api/Destinations
        [ResponseType(typeof(Destination))]
        public IHttpActionResult PostDestination(Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Destinations.Add(destination);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = destination.ID }, destination);
        }

        // DELETE: api/Destinations/5
        [ResponseType(typeof(Destination))]
        public IHttpActionResult DeleteDestination(int id)
        {
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return NotFound();
            }

            destination.Deleted = true;
            destination.DeletedAt = DateTime.Now;
            db.Entry(destination).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(destination);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinationExists(int id)
        {
            return db.Destinations.Count(e => e.ID == id) > 0;
        }
    }
}