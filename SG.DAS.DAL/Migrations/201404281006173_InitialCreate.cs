namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Systems",
                c => new
                    {
                        SystemId = c.Int(nullable: false, identity: true),
                        SystemName = c.String(),
                    })
                .PrimaryKey(t => t.SystemId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Note = c.String(),
                        Supervisor_UserId = c.Int(),
                        System_SystemId = c.Int(),
                        TaskType_TaskTypeId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Users", t => t.Supervisor_UserId)
                .ForeignKey("dbo.Systems", t => t.System_SystemId)
                .ForeignKey("dbo.TaskTypes", t => t.TaskType_TaskTypeId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Supervisor_UserId)
                .Index(t => t.System_SystemId)
                .Index(t => t.TaskType_TaskTypeId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.TaskTypes",
                c => new
                    {
                        TaskTypeId = c.Int(nullable: false, identity: true),
                        TaskTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TaskTypeId);
            
            CreateTable(
                "dbo.UserSystems",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        System_SystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.System_SystemId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Systems", t => t.System_SystemId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.System_SystemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "TaskType_TaskTypeId", "dbo.TaskTypes");
            DropForeignKey("dbo.Tasks", "System_SystemId", "dbo.Systems");
            DropForeignKey("dbo.Tasks", "Supervisor_UserId", "dbo.Users");
            DropForeignKey("dbo.UserSystems", "System_SystemId", "dbo.Systems");
            DropForeignKey("dbo.UserSystems", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserSystems", new[] { "System_SystemId" });
            DropIndex("dbo.UserSystems", new[] { "User_UserId" });
            DropIndex("dbo.Tasks", new[] { "User_UserId" });
            DropIndex("dbo.Tasks", new[] { "TaskType_TaskTypeId" });
            DropIndex("dbo.Tasks", new[] { "System_SystemId" });
            DropIndex("dbo.Tasks", new[] { "Supervisor_UserId" });
            DropTable("dbo.UserSystems");
            DropTable("dbo.TaskTypes");
            DropTable("dbo.Tasks");
            DropTable("dbo.Users");
            DropTable("dbo.Systems");
        }
    }
}
