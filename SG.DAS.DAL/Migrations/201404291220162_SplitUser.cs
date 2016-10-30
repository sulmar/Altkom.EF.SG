namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPhotos",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPhotos", "UserId", "dbo.Users");
            DropIndex("dbo.UserPhotos", new[] { "UserId" });
            DropTable("dbo.UserPhotos");
        }
    }
}
