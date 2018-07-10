using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Reservation : BaseModel
    {

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixTotal { get; set; }

        
        public int IDClient { get; set; }

        [ForeignKey("IDClient")]
        public Client Client { get; set; }

       
        public int IDVoyage { get; set; }

        [ForeignKey("IDVoyage")]
        public Voyage Voyage { get; set; }
    }
}