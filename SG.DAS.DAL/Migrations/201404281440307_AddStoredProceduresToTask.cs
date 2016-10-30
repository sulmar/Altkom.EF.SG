namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoredProceduresToTask : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Task_Insert",
                p => new
                    {
                        TaskName = p.String(maxLength: 2000, unicode: false),
                        Deadline = p.DateTime(storeType: "date"),
                        Status = p.Int(),
                        Note = p.String(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        Supervisor_UserId = p.Int(),
                        System_SystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Tasks]([TaskName], [Deadline], [Status], [Note], [CreateDate], [Supervisor_UserId], [System_SystemId], [TaskType_TaskTypeId], [User_UserId])
                      VALUES (@TaskName, @Deadline, @Status, @Note, @CreateDate, @Supervisor_UserId, @System_SystemId, @TaskType_TaskTypeId, @User_UserId)
                      
                      DECLARE @TaskId int
                      SELECT @TaskId = [TaskId]
                      FROM [dbo].[Tasks]
                      WHERE @@ROWCOUNT > 0 AND [TaskId] = scope_identity()
                      
                      SELECT t0.[TaskId]
                      FROM [dbo].[Tasks] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TaskId] = @TaskId"
            );
            
            CreateStoredProcedure(
                "dbo.Task_Update",
                p => new
                    {
                        TaskId = p.Int(),
                        TaskName = p.String(maxLength: 2000, unicode: false),
                        Deadline = p.DateTime(storeType: "date"),
                        Status = p.Int(),
                        Note = p.String(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        Supervisor_UserId = p.Int(),
                        System_SystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Tasks]
                      SET [TaskName] = @TaskName, [Deadline] = @Deadline, [Status] = @Status, [Note] = @Note, [CreateDate] = @CreateDate, [Supervisor_UserId] = @Supervisor_UserId, [System_SystemId] = @System_SystemId, [TaskType_TaskTypeId] = @TaskType_TaskTypeId, [User_UserId] = @User_UserId
                      WHERE ([TaskId] = @TaskId)"
            );
            
            CreateStoredProcedure(
                "dbo.Task_Delete",
                p => new
                    {
                        TaskId = p.Int(),
                        Supervisor_UserId = p.Int(),
                        System_SystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Tasks]
                      WHERE ((((([TaskId] = @TaskId) AND (([Supervisor_UserId] = @Supervisor_UserId) OR ([Supervisor_UserId] IS NULL AND @Supervisor_UserId IS NULL))) AND (([System_SystemId] = @System_SystemId) OR ([System_SystemId] IS NULL AND @System_SystemId IS NULL))) AND (([TaskType_TaskTypeId] = @TaskType_TaskTypeId) OR ([TaskType_TaskTypeId] IS NULL AND @TaskType_TaskTypeId IS NULL))) AND (([User_UserId] = @User_UserId) OR ([User_UserId] IS NULL AND @User_UserId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Task_Delete");
            DropStoredProcedure("dbo.Task_Update");
            DropStoredProcedure("dbo.Task_Insert");
        }
    }
}
