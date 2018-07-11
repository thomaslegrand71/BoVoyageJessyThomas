namespace BoVoyageJessyThomas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agences", "CreatedAt", c => c.DateTime(nullable: false,defaultValueSql:"getdate()"));
            AddColumn("dbo.Agences", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Agences", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Assurances", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql:"getdate()"));
            AddColumn("dbo.Assurances", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Assurances", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Reservations", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Reservations", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reservations", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Clients", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Clients", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Voyages", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Voyages", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Voyages", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Destinations", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Destinations", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Participants", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql: "getdate()"));
            AddColumn("dbo.Participants", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Participants", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "DeletedAt");
            DropColumn("dbo.Participants", "Deleted");
            DropColumn("dbo.Participants", "CreatedAt");
            DropColumn("dbo.Destinations", "DeletedAt");
            DropColumn("dbo.Destinations", "Deleted");
            DropColumn("dbo.Destinations", "CreatedAt");
            DropColumn("dbo.Voyages", "DeletedAt");
            DropColumn("dbo.Voyages", "Deleted");
            DropColumn("dbo.Voyages", "CreatedAt");
            DropColumn("dbo.Clients", "DeletedAt");
            DropColumn("dbo.Clients", "Deleted");
            DropColumn("dbo.Clients", "CreatedAt");
            DropColumn("dbo.Reservations", "DeletedAt");
            DropColumn("dbo.Reservations", "Deleted");
            DropColumn("dbo.Reservations", "CreatedAt");
            DropColumn("dbo.Assurances", "DeletedAt");
            DropColumn("dbo.Assurances", "Deleted");
            DropColumn("dbo.Assurances", "CreatedAt");
            DropColumn("dbo.Agences", "DeletedAt");
            DropColumn("dbo.Agences", "Deleted");
            DropColumn("dbo.Agences", "CreatedAt");
        }
    }
}
