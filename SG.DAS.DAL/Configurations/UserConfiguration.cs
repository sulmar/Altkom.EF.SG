using SG.DAS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);
                

            this.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);


            

            this.Ignore(p => p.IsLogged);

            this.Map(m => 
                {
                    m.Properties(p=> new
                        {
                            p.UserId,
                            p.FirstName,
                            p.LastName,
                            p.Note,
                            p.Position,
                            p.Birthday,
                            p.Address
                        }
                    );
                    m.ToTable("Users");
                    
                })
                .Map(m => 
                {
                    m.Properties(p=>new 
                    {
                        p.UserId,
                        p.Photo
                    });
                    m.ToTable("UserPhotos");
                });


            
            // .Map<Course>(m => m.Requires("Type").HasValue("Course")) 
            //.Map<OnsiteCourse>(m => m.Requires("Type").HasValue("OnsiteCourse"));


        }
    }
}
