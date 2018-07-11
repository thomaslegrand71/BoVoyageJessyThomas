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
   
    [RoutePrefix("api/participants")]
    public class ParticipantsController : ApiController
    {

        private ThomasEtJessyDbContext db = new ThomasEtJessyDbContext();
        /// <summary>
        /// Consulter les participants
        /// </summary>
        /// <returns></returns>
        // GET: api/Participants
        public IQueryable<Participant> GetParticipants()
        {
            return db.Participants;
        }
        /// <summary>
        /// Consulter les participants en fonction des identifiants
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        // GET: api/Participants/5
        [ResponseType(typeof(Participant))]
        public IHttpActionResult GetParticipant(int id)
        {
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }
        /// <summary>
        /// Consulter les participants en fonction de recherches différentes
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns></returns>
        [Route("search")]
        [ResponseType(typeof(Participant))]
        public IQueryable<Participant> GetSearch(string nom = "", string prenom = "")
        {
            var query = db.Participants.Where(x => !x.Deleted);
            if (!string.IsNullOrWhiteSpace(nom))
            {
                query = query.Where(x => x.Nom.Contains(nom));
            }
            if (!string.IsNullOrWhiteSpace(prenom))
            {
                query = query.Where(x => x.Prenom.Contains(prenom));
            }
            return query;
        }
        /// <summary>
        /// Modifier des participants en fonction du nom ou de l'identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="participant"></param>
        /// <returns></returns>
        // PUT: api/Participants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipant(int id, Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participant.ID)
            {
                return BadRequest();
            }

            db.Entry(participant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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
        /// Ajouter des nouveaux participants
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        // POST: api/Participants
        [ResponseType(typeof(Participant))]
        public IHttpActionResult PostParticipant(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participants.Add(participant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participant.ID }, participant);
        }
        /// <summary>
        /// Supprimer des participants en fonction de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Participants/5
        [ResponseType(typeof(Participant))]
        public IHttpActionResult DeleteParticipant(int id)
        {
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            participant.Deleted = true;
            participant.DeletedAt = DateTime.Now;
            db.Entry(participant).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(participant);
        }
        /// <summary>
        /// Libérer le controller du flux de la base de donnée
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

        private bool ParticipantExists(int id)
        {
            return db.Participants.Count(e => e.ID == id) > 0;
        }
    }
}