namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimestampToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterStoredProcedure(
                "dbo.Task_Insert",
                p => new
                    {
                        TaskName = p.String(maxLength: 2000, unicode: false),
                        Deadline = p.DateTime(storeType: "date"),
                        Status = p.Int(),
                        Note = p.String(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        Supervisor_UserId = p.Int(),
                        System_AppSystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Tasks]([TaskName], [Deadline], [Status], [Note], [CreateDate], [Supervisor_UserId], [System_AppSystemId], [TaskType_TaskTypeId], [User_UserId])
                      VALUES (@TaskName, @Deadline, @Status, @Note, @CreateDate, @Supervisor_UserId, @System_AppSystemId, @TaskType_TaskTypeId, @User_UserId)
                      
                      DECLARE @TaskId int
                      SELECT @TaskId = [TaskId]
                      FROM [dbo].[Tasks]
                      WHERE @@ROWCOUNT > 0 AND [TaskId] = scope_identity()
                      
                      SELECT t0.[TaskId], t0.[Timestamp]
                      FROM [dbo].[Tasks] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TaskId] = @TaskId"
            );
            
            AlterStoredProcedure(
                "dbo.Task_Update",
                p => new
                    {
                        TaskId = p.Int(),
                        TaskName = p.String(maxLength: 2000, unicode: false),
                        Deadline = p.DateTime(storeType: "date"),
                        Status = p.Int(),
                        Note = p.String(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        Supervisor_UserId = p.Int(),
                        System_AppSystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Tasks]
                      SET [TaskName] = @TaskName, [Deadline] = @Deadline, [Status] = @Status, [Note] = @Note, [CreateDate] = @CreateDate, [Supervisor_UserId] = @Supervisor_UserId, [System_AppSystemId] = @System_AppSystemId, [TaskType_TaskTypeId] = @TaskType_TaskTypeId, [User_UserId] = @User_UserId
                      WHERE (([TaskId] = @TaskId) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Tasks] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TaskId] = @TaskId"
            );
            
            AlterStoredProcedure(
                "dbo.Task_Delete",
                p => new
                    {
                        TaskId = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        Supervisor_UserId = p.Int(),
                        System_AppSystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Tasks]
                      WHERE (((((([TaskId] = @TaskId) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL))) AND (([Supervisor_UserId] = @Supervisor_UserId) OR ([Supervisor_UserId] IS NULL AND @Supervisor_UserId IS NULL))) AND (([System_AppSystemId] = @System_AppSystemId) OR ([System_AppSystemId] IS NULL AND @System_AppSystemId IS NULL))) AND (([TaskType_TaskTypeId] = @TaskType_TaskTypeId) OR ([TaskType_TaskTypeId] IS NULL AND @TaskType_TaskTypeId IS NULL))) AND (([User_UserId] = @User_UserId) OR ([User_UserId] IS NULL AND @User_UserId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Timestamp");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
