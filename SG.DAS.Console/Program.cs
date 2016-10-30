using SG.DAS.DAL;
using SG.DAS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SG.DAS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentationTest();

            SimpleUpdateTest();
            

            //GetUsersAsync()
            //    .Wait();

            //AddManyUsers()
            //    .Wait();

            // GetUsersTest();

            TransactionTest2();

            TransactionTest();

            // AddTask();

            UpdateTest();

            LikeTest();

            CallSp();

            CheckDatabaseTest();

            GetUsers();

            // InitDatabase();
        }

        private static void DocumentationTest()
        {
            using(var context = new DASContext())
            {
                var entities = context.GetEntities();

                entities
                    .ToList()
                    .ForEach(x =>
                    {
                        System.Console.WriteLine("{0}", x.Name);

                        
                        x.Properties
                            .ToList()
                            .ForEach(
                            p => System.Console.WriteLine("{0} - {1}", p.Name, p.TypeName));
                       
                        System.Console.WriteLine("klucze:");

                        x.KeyProperties
                            .ToList()
                            .ForEach(k => System.Console.WriteLine(k.Name));

                    });
            }
        }

        private static void SimpleUpdateTest()
        {
            using(var context = new DASContext())
            {
                var user = context.Users.First();


                user.FirstName = "Marcin 10";

                context.SaveChanges();
            }
        }

        private static async System.Threading.Tasks.Task GetUsersAsync()
        {
            using (var context = new DASContext())
            {
                var users = await context.Users
                        .Where(x => x.UserId > 10)
                        .ToListAsync();

                users.ForEach(user => 
                    System.Console.WriteLine(user.FirstName));

            }
        }

        private static async System.Threading.Tasks.Task AddManyUsers()
        {
            using(var context = new DASContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

               for(int i=0;i<10000;i++)
               {
                   var user = new User 
                   { 
                       FirstName = String.Format("User {0}", i),
                       LastName = String.Format("User {0}", i),                        
                   };

                   context.Users.Add(user);
               }


               await context.SaveChangesAsync();

               System.Console.WriteLine("zapisano!");
               

            }
        }

        private static void TransactionTest2()
        {
            using (var context = new DASContext())
            {
                //using (var transaction = context.Database.BeginTransaction())
                //{
                    try
                    {
                        var user = new User
                        {
                            FirstName = "Lukasz",
                            LastName = "Grudzinski",
                            Note = "Test",
                        };

                        context.Users.Add(user);

                        context.SaveChanges();

                       // transaction.Commit();
                    }

                    catch (Exception e)
                    {
                     //   transaction.Rollback();
                    }
                //}
            }
        }

        private static void GetUsersTest()
        {
            using (var context = new DASContext())
            {
                var q = context.Users
                    .Select(x => x.UserId)
                    .ToList();
                
            }
        }

        private static void TransactionTest()
        {
            using (var context = new DASContext())
            {              
                var user = new User
                {
                    FirstName = "Wojtek",
                    LastName = "Szubartowski",
                    Note = "Test",                    
                };

                context.Users.Add(user);

                using (TransactionScope scope = new TransactionScope())
                {
                    context.SaveChanges();

                    // wl/wyl walidacja po stronie EF
                    // context.Configuration.ValidateOnSaveEnabled = false;

                    var task = new SG.DAS.Model.Task
                    {
                        TaskName = "Obiad",
                        Note = "Test",
                        User = user,
                        Supervisor = user,
                        CreateDate = DateTime.Now,
                        Deadline = DateTime.Now.AddDays(1),
                        Status = SG.DAS.Model.TaskStatus.ToDo,

                    };

                    context.Tasks.Add(task);

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException e)
                    {

                    }

                    scope.Complete();
                }

            }

        }

        private static void AddTask()
        {
            using(var context = new DASContext())
            {
                var task = new Model.Task 
                { 
                    TaskName = "Task",
                    CreateDate = DateTime.Now,
                    Note = "Test",
                    Deadline = DateTime.Now.AddDays(10),
                    
                };

                context.Tasks.Add(task);

                context.SaveChanges();
            }

        }

        private static void UpdateTest()
        {
            using(var context2 = new DASContext())
            using(var context = new DASContext())
            {
                
                var task = context.Tasks.First();
                    
                task.TaskName = "Task 2";

                var task2 = context2.Tasks.First();
                
                task2.TaskName = "Task 3";

                try
                {
                    context.SaveChanges();


                    context2.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    System.Console.WriteLine("Ktos w miedzyczasie zmodyfikowal rekord");
                    // wygrywa server (ServerWins)
                    // e.Entries.Single().Reload();

                    // Update original values from the database 
                    var entry = e.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues()); 
                }
            }
        }

        private static void LikeTest()
        {
            using(var context = new DASContext())
            {
                

                var q = context.Users
                    .Where(u => u.FirstName.Contains("arcin"))
                    .ToList();


            }
        }

        private static void CallSp()
        {
            using(var context = new DASContext())
            {
                System.Diagnostics.Debug.WriteLine(context.PrintToday());
            }
        }

        private static void CheckDatabaseTest()
        {
            using (var context = new DASContext())
            {
                if (context.Database.Exists())
                {
                    if (!context.Database.CompatibleWithModel(false))
                    {
                        System.Diagnostics.Debug.WriteLine("Baza danych nieaktualna!");
                    }
                    
                }
            }
        }

        private static void GetUsers()
        {
            using(var context = new DASContext())
            {
                var users = context.Users
                    .ToList();

                // context.Database.ExecuteSqlCommand()
                // recznie wywolanie procedury skladowanej
                var tasks = context.Tasks.SqlQuery("exec dbo.PobierzZadania");

                foreach (var user in users)
                {
                    System.Diagnostics.Debug.WriteLine(user.FirstName);
                }

               // users.ForEach(user => System.Diagnostics.Debug.WriteLine(user.FirstName));
            }
        }

        private static void InitDatabase()
        {
            User user1 = new User
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            User user2 = new User
            {
                FirstName = "Celina",
                LastName = "Tomaszewska"
            };


            using (DASContext context = new DASContext())
            {
                context.Users.Add(user1);
                context.Users.Add(user2);


                context.SaveChanges();
            }

            
        }
    }
}
