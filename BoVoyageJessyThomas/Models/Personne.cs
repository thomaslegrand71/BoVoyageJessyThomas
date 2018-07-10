using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public abstract class Personne : BaseModel
    {
        public string Civilite { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string Telephone { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        public DateTime DateDeNaissance { get; set; }

        [NotMapped]
        public int Age { get; set; }
    }
}