namespace BoVoyageJessyThomas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationsController : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agences", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "NumeroCarteBancaire", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Prenom", c => c.String(nullable: false));
            AlterColumn("dbo.Participants", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Participants", "Prenom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "Prenom", c => c.String());
            AlterColumn("dbo.Participants", "Nom", c => c.String());
            AlterColumn("dbo.Clients", "Prenom", c => c.String());
            AlterColumn("dbo.Clients", "Nom", c => c.String());
            AlterColumn("dbo.Reservations", "NumeroCarteBancaire", c => c.String());
            AlterColumn("dbo.Agences", "Nom", c => c.String());
        }
    }
}
