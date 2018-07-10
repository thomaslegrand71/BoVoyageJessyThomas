using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Assurance :BaseModel
    {
        
        public bool AssuranceAnnulation { get; set; }


        public int IDReservation { get; set; }

        [ForeignKey("IDReservation")]
        public Reservation Reservation { get; set; }

    }
}