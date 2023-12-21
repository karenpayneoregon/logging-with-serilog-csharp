using System.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace SerilogConsole.Classes;
internal class DataOperations
{
    /// <summary>
    /// Just enough to ensure the connection is valid
    /// </summary>
    public static void Connect()
    {
        string statement = """
            SELECT TOP 3 db.name AS [Database Name]
            FROM sys.databases db
                LEFT JOIN sys.server_principals sp
                    ON db.owner_sid = sp.sid
            WHERE db.database_id > 5
            ORDER BY [Database Name];
            """;
        using var cn = new SqlConnection(ConnectionString());
        using var cmd = new SqlCommand(statement, cn);
        cn.Open();
        AnsiConsole.MarkupLine("[yellow]Connection open[/]");
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetString(0));
        }
        AnsiConsole.MarkupLine("[yellow]Done data operations[/]");
    }
}
