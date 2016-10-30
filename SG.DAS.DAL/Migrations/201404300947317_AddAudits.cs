namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAudits : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        AuditId = c.Int(nullable: false, identity: true),
                        EntityName = c.String(nullable: false, maxLength: 2000, unicode: false),
                        PropertyName = c.String(nullable: false, maxLength: 2000, unicode: false),
                        AuditDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.AuditId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audits");
        }
    }
}
