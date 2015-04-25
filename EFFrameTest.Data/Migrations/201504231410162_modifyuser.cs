namespace EFFrameTest2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "NativePlace", c => c.String());
            AddColumn("dbo.User", "IDCard", c => c.String());
            AddColumn("dbo.User", "Mobile", c => c.String());
            AddColumn("dbo.User", "WeiXin", c => c.String());
            AddColumn("dbo.User", "Email", c => c.String());
            AddColumn("dbo.User", "Tel", c => c.String());
            AddColumn("dbo.User", "QQ", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "QQ");
            DropColumn("dbo.User", "Tel");
            DropColumn("dbo.User", "Email");
            DropColumn("dbo.User", "WeiXin");
            DropColumn("dbo.User", "Mobile");
            DropColumn("dbo.User", "IDCard");
            DropColumn("dbo.User", "NativePlace");
        }
    }
}
