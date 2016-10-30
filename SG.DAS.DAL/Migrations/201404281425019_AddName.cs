namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false));
            AlterColumn("dbo.TaskTypes", "TaskTypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskTypes", "TaskTypeName", c => c.String());
            AlterColumn("dbo.Tasks", "TaskName", c => c.String());
        }
    }
}
