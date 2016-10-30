namespace SG.DAS.DbFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<System> Systems { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<System>()
                .Property(e => e.SystemName)
                .IsUnicode(false);

            modelBuilder.Entity<System>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.System)
                .HasForeignKey(e => e.System_SystemId);

            modelBuilder.Entity<System>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Systems)
                .Map(m => m.ToTable("UserSystems"));

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskType>()
                .Property(e => e.TaskTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<TaskType>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.TaskType)
                .HasForeignKey(e => e.TaskType_TaskTypeId);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Supervisor_UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.User_UserId);
        }
    }
}
