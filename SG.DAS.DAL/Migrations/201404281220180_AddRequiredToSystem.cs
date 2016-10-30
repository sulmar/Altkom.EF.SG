namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToSystem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Systems", "SystemName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Systems", "SystemName", c => c.String());
        }
    }
}
