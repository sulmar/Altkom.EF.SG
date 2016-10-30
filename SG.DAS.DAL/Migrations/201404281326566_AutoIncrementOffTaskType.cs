namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoIncrementOffTaskType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "TaskType_TaskTypeId", "dbo.TaskTypes");
            DropPrimaryKey("dbo.TaskTypes");
            AlterColumn("dbo.TaskTypes", "TaskTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TaskTypes", "TaskTypeId");
            AddForeignKey("dbo.Tasks", "TaskType_TaskTypeId", "dbo.TaskTypes", "TaskTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskType_TaskTypeId", "dbo.TaskTypes");
            DropPrimaryKey("dbo.TaskTypes");
            AlterColumn("dbo.TaskTypes", "TaskTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TaskTypes", "TaskTypeId");
            AddForeignKey("dbo.Tasks", "TaskType_TaskTypeId", "dbo.TaskTypes", "TaskTypeId");
        }
    }
}
