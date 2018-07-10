using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Entity;
using BoVoyageJessyThomas.Models;

namespace BoVoyageJessyThomas.Data
{
    public class ThomasEtJessyDbContext :DbContext
    {
        public ThomasEtJessyDbContext():base ("thomasetjessy")
        {
        }
        public DbSet<Agence> Agences { get; set; }

        public DbSet<Assurance> Assurances { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Destination>Destinations { get;set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

       


    }
}