using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL
{
    public static class DbContextExtensions
    {
        public static MetadataWorkspace MetadataWorkspace(this DbContext context)
        {
            ObjectContext objectContext = 
                (context as IObjectContextAdapter).ObjectContext;

            return objectContext.MetadataWorkspace;
        }

        public static IEnumerable<EntityType> GetEntities(this DbContext context)
        {
            var entities = context.MetadataWorkspace()
                .GetItemCollection(DataSpace.OSpace)
                .GetItems<EntityType>()
                .ToList();

            return entities;
        }
    }
}
