using System;
using System.Data.SqlTypes;
using System.Threading;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace CombinedConfigDemo
{
    // This sample app reads connection string and column options from appsettings.json
    // while schema name, table name and autoCreateSqlTable are supplied programmatically
    // as parameters to the MSSqlServer() method.
    public static class Program
    {
        private const string _connectionStringName = "LogDatabase";
        private const string _schemaName = "dbo";
        private const string _tableName = "LogEvents";

        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var columnOptionsSection = configuration.GetSection("Serilog:ColumnOptions");
            var sinkOptionsSection = configuration.GetSection("Serilog:SinkOptions");


            // New SinkOptions based interface
            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: _connectionStringName,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = _tableName,
                        SchemaName = _schemaName,
                        AutoCreateSqlTable = true
                    },
                    sinkOptionsSection: sinkOptionsSection,
                    appConfiguration: configuration,
                    columnOptionsSection: columnOptionsSection)
                .CreateLogger();

            Log.Information("Hello {Name} from thread {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), Thread.CurrentThread.ManagedThreadId);

            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });
            Log.Error(new JsonException("Something is wrong"),"Json issue");

            Log.CloseAndFlush();

        }
    }
}
