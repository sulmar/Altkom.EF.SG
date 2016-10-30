namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateDatToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CreateDate");
        }
    }
}
