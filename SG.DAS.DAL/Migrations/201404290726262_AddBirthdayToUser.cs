namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Birthday");
        }
    }
}
