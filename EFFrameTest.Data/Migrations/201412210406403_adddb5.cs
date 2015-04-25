namespace EFFrameTest2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddb5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Age = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        Mobile = c.String(maxLength: 13),
                        Sex = c.Boolean(nullable: false),
                        Rating = c.String(),
                        remark = c.String(),
                        Grade = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Lodging",
                c => new
                    {
                        LodgingIdentify = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Owner = c.String(),
                        MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DestinationIdentify = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LodgingIdentify)
                .ForeignKey("dbo.Destination", t => t.DestinationIdentify, cascadeDelete: true)
                .Index(t => t.DestinationIdentify);
            
            CreateTable(
                "dbo.Destination",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Country = c.String(),
                        Description = c.String(),
                        Photo = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        Identified = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identified);
            
            CreateTable(
                "dbo.TripActivities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false),
                        TripIdenfied = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActivityId, t.TripIdenfied })
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripIdenfied, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.TripIdenfied);
            
            CreateTable(
                "dbo.Resort",
                c => new
                    {
                        LodgingIdentify = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Owner = c.String(),
                        MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DestinationIdentify = c.Int(nullable: false),
                        ResortIdentity = c.Int(nullable: false, identity: true),
                        Entertainment = c.String(),
                        Activities = c.String(),
                    })
                .PrimaryKey(t => t.ResortIdentity)
                .ForeignKey("dbo.Destination", t => t.DestinationIdentify, cascadeDelete: true)
                .Index(t => t.DestinationIdentify);

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resort", "DestinationIdentify", "dbo.Destination");
            DropForeignKey("dbo.TripActivities", "TripIdenfied", "dbo.Trip");
            DropForeignKey("dbo.TripActivities", "ActivityId", "dbo.Activity");
            DropForeignKey("dbo.Lodging", "DestinationIdentify", "dbo.Destination");
            DropIndex("dbo.Resort", new[] { "DestinationIdentify" });
            DropIndex("dbo.TripActivities", new[] { "TripIdenfied" });
            DropIndex("dbo.TripActivities", new[] { "ActivityId" });
            DropIndex("dbo.Lodging", new[] { "DestinationIdentify" });
            DropTable("dbo.Resort");
            DropTable("dbo.TripActivities");
            DropTable("dbo.Trip");
            DropTable("dbo.Activity");
            DropTable("dbo.Destination");
            DropTable("dbo.Lodging");
            DropTable("dbo.Contact");
        }
    }
}
