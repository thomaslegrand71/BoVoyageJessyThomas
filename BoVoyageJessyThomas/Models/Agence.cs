using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Agence : BaseModel
    {
        public string Nom { get; set; }

        [ForeignKey("IdVoyage")]
        public int IdVoyage { get; set; }
        public Voyage Voyage { get; set; }



    }
}