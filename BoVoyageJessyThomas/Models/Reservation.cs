using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Reservation : BaseModel
    {
        public int NumeroUnique { get; set; }

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixTotal { get; set; }

        
    }
}