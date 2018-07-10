namespace BoVoyageJessyThomas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssuranceAnnulation = c.Boolean(nullable: false),
                        IDReservation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reservations", t => t.IDReservation, cascadeDelete: true)
                .Index(t => t.IDReservation);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumeroUnique = c.Int(nullable: false),
                        NumeroCarteBancaire = c.String(),
                        PrixTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDClient = c.Int(nullable: false),
                        IDVoyage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Personnes", t => t.IDClient, cascadeDelete: true)
                .ForeignKey("dbo.Voyages", t => t.IDVoyage, cascadeDelete: true)
                .Index(t => t.IDClient)
                .Index(t => t.IDVoyage);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Civilite = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        Telephone = c.String(),
                        DateDeNaissance = c.DateTime(nullable: false),
                        Email = c.String(),
                        NumeroUnique = c.Int(),
                        Reduction = c.Single(),
                        IDReservation = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reservations", t => t.IDReservation, cascadeDelete: true)
                .Index(t => t.IDReservation);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        TarifToutCompris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDDestination = c.Int(nullable: false),
                        IDAgence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Agences", t => t.IDAgence, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.IDDestination, cascadeDelete: true)
                .Index(t => t.IDDestination)
                .Index(t => t.IDAgence);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Continent = c.String(),
                        Pays = c.String(),
                        Region = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "IDReservation", "dbo.Reservations");
            DropForeignKey("dbo.Assurances", "IDReservation", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "IDVoyage", "dbo.Voyages");
            DropForeignKey("dbo.Voyages", "IDDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IDAgence", "dbo.Agences");
            DropForeignKey("dbo.Reservations", "IDClient", "dbo.Personnes");
            DropIndex("dbo.Voyages", new[] { "IDAgence" });
            DropIndex("dbo.Voyages", new[] { "IDDestination" });
            DropIndex("dbo.Personnes", new[] { "IDReservation" });
            DropIndex("dbo.Reservations", new[] { "IDVoyage" });
            DropIndex("dbo.Reservations", new[] { "IDClient" });
            DropIndex("dbo.Assurances", new[] { "IDReservation" });
            DropTable("dbo.Destinations");
            DropTable("dbo.Voyages");
            DropTable("dbo.Personnes");
            DropTable("dbo.Reservations");
            DropTable("dbo.Assurances");
            DropTable("dbo.Agences");
        }
    }
}
