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
        /// <summary>
        /// Consulter la liste des Agences
        /// </summary>
        /// <returns></returns>
        // GET: api/Agences
        public IQueryable<Agence> GetAgences()
        {
            return db.Agences;
        }
        /// <summary>
        /// Consulter les agences en fonction de l'identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Consulter les agences en fonction du nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        [Route("{name}")]
        [ResponseType(typeof(Agence))]
        public IQueryable<Agence> Getagence(string nom)
        {
            return db.Agences.Where(x => !x.Deleted && x.Nom.Contains(nom));
        }

        /// <summary>
        /// Modifier une agence en fonction de son nom ou de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="agence"></param>
        /// <returns></returns>
        
        // PUT: api/Agences/5
        [Route("{id:int}")]
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
        /// <summary>
        /// Ajouter une agence
        /// </summary>
        /// <param name="agence"></param>
        /// <returns></returns>

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
        /// <summary>
        /// Supprimer une agence
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Agences/5
        [Route("{id:int}")]
        [ResponseType(typeof(Agence))]
        public IHttpActionResult DeleteAgence(int id)
        {
            Agence agence = db.Agences.Find(id);
            if (agence == null)
            {
                return NotFound();
            }

            agence.Deleted = true;
            agence.DeletedAt = DateTime.Now;
            db.Entry(agence).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(agence);
        }
        /// <summary>
        /// Libère la connexion à la base de donnée
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

        private bool AgenceExists(int id)
        {
            return db.Agences.Count(e => e.ID == id) > 0;
        }
    }
}