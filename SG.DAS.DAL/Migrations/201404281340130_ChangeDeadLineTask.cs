namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeadLineTask : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Deadline", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Deadline", c => c.DateTime(nullable: false));
        }
    }
}
