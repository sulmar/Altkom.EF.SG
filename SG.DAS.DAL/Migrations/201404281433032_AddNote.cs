namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Systems", "SystemName", c => c.String(nullable: false, maxLength: 2000, unicode: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false, maxLength: 2000, unicode: false));
            AlterColumn("dbo.TaskTypes", "TaskTypeName", c => c.String(nullable: false, maxLength: 2000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskTypes", "TaskTypeName", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Systems", "SystemName", c => c.String(nullable: false));
        }
    }
}
