namespace EFFrameTest2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchildnodes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PermissionModule", "ChildNodes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PermissionModule", "ChildNodes");
        }
    }
}
