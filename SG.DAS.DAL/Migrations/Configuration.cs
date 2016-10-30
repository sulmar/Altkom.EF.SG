namespace SG.DAS.DAL.Migrations
{
    using SG.DAS.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SG.DAS.DAL.DASContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SG.DAS.DAL.DASContext";
        }

        protected override void Seed(SG.DAS.DAL.DASContext context)
        {       

            context.TaskTypes.AddOrUpdate(
                p => p.TaskTypeName,
                new TaskType { TaskTypeName = "Backup" },
                new TaskType { TaskTypeName = "Aktualizacja bazy wirusow "},
                new TaskType { TaskTypeName = "Oddanie urzadzenia do serwisu" },
                new TaskType { TaskTypeName = "Instalacja oprogramowania dodatkowego " }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
