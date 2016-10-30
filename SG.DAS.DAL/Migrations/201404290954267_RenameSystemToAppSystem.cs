namespace SG.DAS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameSystemToAppSystem : DbMigration
    {
        public override void Up()
        {            
            RenameTable(name: "dbo.UserSystems", newName: "UserAppSystems");
            RenameColumn(table: "dbo.UserAppSystems", name: "System_SystemId", newName: "AppSystem_AppSystemId");
            RenameColumn(table: "dbo.Tasks", name: "System_SystemId", newName: "System_AppSystemId");
            RenameIndex(table: "dbo.Tasks", name: "IX_System_SystemId", newName: "IX_System_AppSystemId");
            RenameIndex(table: "dbo.UserAppSystems", name: "IX_System_SystemId", newName: "IX_AppSystem_AppSystemId");
            CreateTable(
                "dbo.AppSystems",
                c => new
                    {
                        AppSystemId = c.Int(nullable: false, identity: true),
                        SystemName = c.String(nullable: false, maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.AppSystemId);
            
            // DropTable("dbo.Systems");
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
                      
                      SELECT t0.[TaskId]
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
                        Supervisor_UserId = p.Int(),
                        System_AppSystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Tasks]
                      SET [TaskName] = @TaskName, [Deadline] = @Deadline, [Status] = @Status, [Note] = @Note, [CreateDate] = @CreateDate, [Supervisor_UserId] = @Supervisor_UserId, [System_AppSystemId] = @System_AppSystemId, [TaskType_TaskTypeId] = @TaskType_TaskTypeId, [User_UserId] = @User_UserId
                      WHERE ([TaskId] = @TaskId)"
            );

            AlterStoredProcedure(
                "dbo.Task_Delete",
                p => new
                    {
                        TaskId = p.Int(),
                        Supervisor_UserId = p.Int(),
                        System_AppSystemId = p.Int(),
                        TaskType_TaskTypeId = p.Int(),
                        User_UserId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Tasks]
                      WHERE ((((([TaskId] = @TaskId) AND (([Supervisor_UserId] = @Supervisor_UserId) OR ([Supervisor_UserId] IS NULL AND @Supervisor_UserId IS NULL))) AND (([System_AppSystemId] = @System_AppSystemId) OR ([System_AppSystemId] IS NULL AND @System_AppSystemId IS NULL))) AND (([TaskType_TaskTypeId] = @TaskType_TaskTypeId) OR ([TaskType_TaskTypeId] IS NULL AND @TaskType_TaskTypeId IS NULL))) AND (([User_UserId] = @User_UserId) OR ([User_UserId] IS NULL AND @User_UserId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Systems",
                c => new
                    {
                        SystemId = c.Int(nullable: false, identity: true),
                        SystemName = c.String(nullable: false, maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.SystemId);
            
            DropTable("dbo.AppSystems");
            RenameIndex(table: "dbo.UserAppSystems", name: "IX_AppSystem_AppSystemId", newName: "IX_System_SystemId");
            RenameIndex(table: "dbo.Tasks", name: "IX_System_AppSystemId", newName: "IX_System_SystemId");
            RenameColumn(table: "dbo.Tasks", name: "System_AppSystemId", newName: "System_SystemId");
            RenameColumn(table: "dbo.UserAppSystems", name: "AppSystem_AppSystemId", newName: "System_SystemId");
            RenameTable(name: "dbo.UserAppSystems", newName: "UserSystems");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
