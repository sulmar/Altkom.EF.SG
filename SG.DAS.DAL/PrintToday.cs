using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL
{
    public partial class DASContext
    {
        public string PrintToday()
        {
            return CallStoreProcedure<string>("PrintToday");
        }

        public int GetCount()
        {
            return CallStoreProcedure<int>("GetCount");
        }

        // wersja generyczna
        public TResult CallStoreProcedure<TResult>(string procedureName)
        {
            var query = this.Database.SqlQuery<TResult>(procedureName);

            var result = query.Single();

            return result;
        }
    }
}
