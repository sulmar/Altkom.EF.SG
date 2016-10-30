using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static void PrintToday()
    {
        SqlPipe p; 

        p = SqlContext.Pipe; 

        SqlDataRecord record = new SqlDataRecord(
			new SqlMetaData("col1", SqlDbType.NVarChar, 100));

        // Mark the begining of the result-set.
		SqlContext.Pipe.SendResultsStart(record);


        var result = Metoda();

        record.SetString(0, result);
			

			// Send the row back to the client.
			SqlContext.Pipe.SendResultsRow(record);

        // Mark the end of the result-set.
		SqlContext.Pipe.SendResultsEnd();


        // p.Send(System.DateTime.Today.ToString()); 
    }

    private static string Metoda()
    {
        return "row " + System.DateTime.Today.ToString();
    }
}

