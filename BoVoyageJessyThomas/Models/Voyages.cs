using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Voyages : BaseModel
    {
        public DateTime DateAller { get; set; }

        public DateTime DateRetour { get; set; }

        public int PlacesDisponibles { get; set; }

        public decimal TarifToutCompris { get; set; }

    }
}