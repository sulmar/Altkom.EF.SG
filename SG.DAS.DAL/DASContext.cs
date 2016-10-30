using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SG.DAS.Model;
using SG.DAS.DAL.Configurations;
using SG.DAS.DAL.Conventions;


namespace SG.DAS.DAL
{
    public partial class DASContext : DbContext
    {
        public DASContext()
            : base("name=DAS")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<DASContext,
                SG.DAS.DAL.Migrations.Configuration>());

            this.Database.Log = System.Console.WriteLine;

            this.Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<User> Users { get; set; }

        public DbSet<AppSystem> Systems { get; set; }
        
        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Audit> Audits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SystemConfiguration());
            modelBuilder.Configurations.Add(new TaskTypeConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());

            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Conventions.Add(new NameConvention());
            modelBuilder.Conventions.Add(new NoteConvention());

       

            base.OnModelCreating(modelBuilder);
        }
        
    }


}
