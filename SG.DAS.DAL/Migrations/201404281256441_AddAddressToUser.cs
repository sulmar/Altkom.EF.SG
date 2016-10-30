namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address_Street", c => c.String());
            AddColumn("dbo.Users", "Address_City", c => c.String());
            AddColumn("dbo.Users", "Address_Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Address_Country");
            DropColumn("dbo.Users", "Address_City");
            DropColumn("dbo.Users", "Address_Street");
        }
    }
}
