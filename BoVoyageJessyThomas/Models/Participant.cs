﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Models
{
    public class Participant : Personne
    {
        public int NumeroUnique { get; set; }//doublon avec ID de BaseModel

        public float Reduction { get; set; }

    }
}