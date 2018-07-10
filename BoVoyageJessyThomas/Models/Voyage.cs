using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Voyage : BaseModel
    {
        public DateTime DateAller { get; set; }

        public DateTime DateRetour { get; set; }

        public int PlacesDisponibles { get; set; }

        public decimal TarifToutCompris { get; set; }

      
        public int IDDestination { get; set; }

        [ForeignKey("IDDestination")]
        public Destination Destination { get; set; }


       
        public int IDAgence { get; set; }

        [ForeignKey("IDAgence")]
        public Agence Agence { get; set; }


    }
}