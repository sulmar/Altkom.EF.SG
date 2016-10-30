namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Position", c => c.String());
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Position");
        }
    }
}
