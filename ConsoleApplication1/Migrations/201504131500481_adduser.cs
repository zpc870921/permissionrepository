namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Description = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.Lodgings",
                c => new
                    {
                        LodgingIdentify = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Owner = c.String(),
                        MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DestinationIdentify = c.Int(nullable: false),
                        ResortIdentity = c.Int(identity: true),
                        Entertainment = c.String(),
                        Activities = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LodgingIdentify)
                .ForeignKey("dbo.Destinations", t => t.DestinationIdentify, cascadeDelete: true)
                .Index(t => t.DestinationIdentify);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lodgings", "DestinationIdentify", "dbo.Destinations");
            DropIndex("dbo.Lodgings", new[] { "DestinationIdentify" });
            DropTable("dbo.Lodgings");
            DropTable("dbo.Destinations");
        }
    }
}
