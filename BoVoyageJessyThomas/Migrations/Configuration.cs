using BoVoyageJessyThomas.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BoVoyageJessyThomas.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ThomasEtJessyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }
    }
}