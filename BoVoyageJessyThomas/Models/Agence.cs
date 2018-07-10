using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Agence : BaseModel
    {
        [Required(ErrorMessage ="Le nom est obligatoire")]
        public string Nom { get; set; }



    }
}