namespace EFFrameTest2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201504142152 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Lodging", "DestinationIdentify", "dbo.Destination");
            //DropForeignKey("dbo.TripActivities", "ActivityId", "dbo.Activity");
            //DropForeignKey("dbo.TripActivities", "TripIdenfied", "dbo.Trip");
            //DropForeignKey("dbo.Resort", "DestinationIdentify", "dbo.Destination");
            //DropIndex("dbo.Lodging", new[] { "DestinationIdentify" });
           // DropIndex("dbo.TripActivities", new[] { "ActivityId" });
            //DropIndex("dbo.TripActivities", new[] { "TripIdenfied" });
           // DropIndex("dbo.Resort", new[] { "DestinationIdentify" });
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserReRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PermissionModule", "ParentId", c => c.Int(nullable: false));
            //DropTable("dbo.Contact");
            //DropTable("dbo.Lodging");
            //DropTable("dbo.Destination");
            //DropTable("dbo.Activity");
            //DropTable("dbo.Trip");
            //DropTable("dbo.TripActivities");
            //DropTable("dbo.Resort");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Resort",
            //    c => new
            //        {
            //            LodgingIdentify = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Owner = c.String(),
            //            MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            DestinationIdentify = c.Int(nullable: false),
            //            ResortIdentity = c.Int(nullable: false, identity: true),
            //            Entertainment = c.String(),
            //            Activities = c.String(),
            //        })
            //    .PrimaryKey(t => t.LodgingIdentify);
            
            //CreateTable(
            //    "dbo.TripActivities",
            //    c => new
            //        {
            //            ActivityId = c.Int(nullable: false),
            //            TripIdenfied = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ActivityId, t.TripIdenfied });
            
            //CreateTable(
            //    "dbo.Trip",
            //    c => new
            //        {
            //            Identified = c.Int(nullable: false, identity: true),
            //            StartDate = c.DateTime(nullable: false),
            //            EndDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Identified);
            
            //CreateTable(
            //    "dbo.Activity",
            //    c => new
            //        {
            //            ActivityId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.ActivityId);
            
            //CreateTable(
            //    "dbo.Destination",
            //    c => new
            //        {
            //            DestinationId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Country = c.String(),
            //            Description = c.String(),
            //            Photo = c.Binary(storeType: "image"),
            //        })
            //    .PrimaryKey(t => t.DestinationId);
            
            //CreateTable(
            //    "dbo.Lodging",
            //    c => new
            //        {
            //            LodgingIdentify = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Owner = c.String(),
            //            MilesFromNearestAirport = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            DestinationIdentify = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.LodgingIdentify);
            
            //CreateTable(
            //    "dbo.Contact",
            //    c => new
            //        {
            //            ContactId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 10),
            //            Age = c.Int(nullable: false),
            //            Address = c.String(maxLength: 100),
            //            Mobile = c.String(maxLength: 13),
            //            Sex = c.Boolean(nullable: false),
            //            Rating = c.String(),
            //            remark = c.String(),
            //            Grade = c.String(maxLength: 20),
            //        })
            //    .PrimaryKey(t => t.ContactId);
            
            DropColumn("dbo.PermissionModule", "ParentId");
            DropTable("dbo.UserReRole");
            DropTable("dbo.User");
            //CreateIndex("dbo.Resort", "DestinationIdentify");
            //CreateIndex("dbo.TripActivities", "TripIdenfied");
            //CreateIndex("dbo.TripActivities", "ActivityId");
            //CreateIndex("dbo.Lodging", "DestinationIdentify");
            //AddForeignKey("dbo.Resort", "DestinationIdentify", "dbo.Destination", "DestinationId", cascadeDelete: true);
            //AddForeignKey("dbo.TripActivities", "TripIdenfied", "dbo.Trip", "Identified", cascadeDelete: true);
            //AddForeignKey("dbo.TripActivities", "ActivityId", "dbo.Activity", "ActivityId", cascadeDelete: true);
            //AddForeignKey("dbo.Lodging", "DestinationIdentify", "dbo.Destination", "DestinationId", cascadeDelete: true);
        }
    }
}
