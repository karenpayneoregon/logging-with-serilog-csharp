using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace SqlServerSink.Classes;
internal class SetupLogging
{
    
    public static void Initialize()
    {

        const string connectionStringName = "LogDatabase";
        const string schemaName = "dbo";
        const string tableName = "LogEvents";

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var columnOptionsSection = configuration.GetSection("Serilog:ColumnOptions");
        var sinkOptionsSection = configuration.GetSection("Serilog:SinkOptions");


        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(
                connectionString: connectionStringName,
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = tableName,
                    SchemaName = schemaName,
                    AutoCreateSqlTable = true
                },
                sinkOptionsSection: sinkOptionsSection,
                appConfiguration: configuration,
                columnOptionsSection: columnOptionsSection)
            .CreateLogger();
    }
}
