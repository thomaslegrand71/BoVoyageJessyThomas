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
    [RoutePrefix("api/clients")]
    public class ClientsController : ApiController
    {
        private ThomasEtJessyDbContext db = new ThomasEtJessyDbContext();
        /// <summary>
        /// Consulter la liste de clients
        /// </summary>
        /// <returns></returns>
        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }
        /// <summary>
        /// Consulter un client en fonction de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        /// <summary>
        /// Consulter un client en fonction de la méthode Search
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <returns></returns>
        [Route("search")]
        [ResponseType(typeof(Client))]
        public IQueryable<Client> GetSearch(string nom = "", string prenom = "")
        {
            var query = db.Clients.Where(x => !x.Deleted);
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
        /// Modifier un client en fonction de l'identifiant ou de son nom
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        // PUT: api/Clients/5
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ID)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
      /// Ajouter un client 
      /// </summary>
      /// <param name="client"></param>
      /// <returns></returns>

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ID }, client);
        }
        /// <summary>
        /// Supprimer un client en fonction de son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE: api/Clients/5
        [Route("{id:int}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Deleted = true;
            client.DeletedAt = DateTime.Now;
            db.Entry(client).State = EntityState.Modified; 
            db.SaveChanges();

            return Ok(client);
        }
        /// <summary>
        /// Libère la connexion à la base de données
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

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ID == id) > 0;
        }
    }
}