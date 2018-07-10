using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Reservation : BaseModel
    {
        public int NumeroUnique { get; set; }//Doublon avec ID BaseModel

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixTotal { get; set; }

        [ForeignKey("IdParticipant")]
        public int IdParticipant { get; set; }
        public IQueryable<Participant> Participants { get; set; }

        [ForeignKey("IdClient")]
        public int IdClient { get; set; }
        public Client Client { get; set; }

        [ForeignKey("IdVoyage")]
        public int IdVoyage { get; set; }
        public Voyage Voyage { get; set; }
    }
}