namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFirstNameUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
