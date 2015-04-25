namespace EFFrameTest2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20150411 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermissionRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionModule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Target = c.String(),
                        IsMenu = c.Int(nullable: false),
                        OrderVal = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        MaxLeavel = c.Int(nullable: false),
                        Attributes = c.String(),
                        OptCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionReRoleModule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        FuncCode = c.Int(nullable: false),
                        OptScope = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PermissionReRoleModule");
            DropTable("dbo.PermissionModule");
            DropTable("dbo.PermissionRole");
        }
    }
}
