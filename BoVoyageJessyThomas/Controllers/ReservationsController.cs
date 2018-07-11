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
    [RoutePrefix("api/reservations")]
    public class ReservationsController : ApiController
    {
        private ThomasEtJessyDbContext db = new ThomasEtJessyDbContext();
        /// <summary>
        /// Consulter la liste des réservations
        /// </summary>
        /// <returns></returns>
        // GET: api/Reservations
        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations.Include(x=>x.Voyage).Include(x=>x.Client).Where(x=>!x.Deleted);
        }
        /// <summary>
        /// Consulter une réservation en fonction de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }
        /// <summary>
        /// Consulter une réservation en fonction de la fonction Search
        /// </summary>
        /// <param name="idVoyage"></param>
        /// <param name="idClient"></param>
        /// <returns></returns>
        [Route("search")]
        [ResponseType(typeof(Reservation))]
        public IQueryable<Reservation> GetSearch(int? idVoyage = null, int? idClient = null)
        {
            var query = db.Reservations.Include(x => x.Voyage).Include(x => x.Client).Where(x => !x.Deleted);
            if (idVoyage != null)
            {
                query = query.Where(x => x.IDVoyage == idVoyage);
            } 
            if (idClient != null)
            {
                query = query.Where(x => x.IDClient == idClient);
            }

            return query;
        }
        /// <summary>
        /// Modifier une réservation en fonction du nom ou de l'identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reservation"></param>
        /// <returns></returns>
        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.ID)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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
        /// <summary>
        /// Ajouter une réservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservations.Add(reservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reservation.ID }, reservation);
        }
        /// <summary>
        /// Supprimer une réservation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult DeleteReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservations.Remove(reservation);
            db.SaveChanges();

            return Ok(reservation);
        }
        /// <summary>
        /// Libère la connexion à la BDD
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(int id)
        {
            return db.Reservations.Count(e => e.ID == id) > 0;
        }
    }
}