﻿using CustomLogEventFormatterDemo.Classes;
using Serilog;
using Serilog.Core;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using Spectre.Console;

namespace CustomLogEventFormatterDemo;

public static partial class Program
{
    private const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Logging;Integrated Security=True;Encrypt=False";
    private const string SchemaName = "dbo";
    private const string TableName = "LogEvents1";

    public static void Main()
    {
        ColumnOptions options = new ();

        options.Store.Remove(StandardColumn.Properties);
        // we do want JSON data
        options.Store.Add(StandardColumn.LogEvent);

        LoggingLevelSwitch levelSwitch = new ();
      

        // New MSSqlServerSinkOptions based interface
        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(ConnectionString,
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = TableName,
                    SchemaName = SchemaName,
                    AutoCreateSqlTable = true,
                    LevelSwitch = levelSwitch
                },
                appConfiguration: null,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose,
                formatProvider: null,
                columnOptions: options,
                columnOptionsSection: null)
            .CreateLogger();

        try
        {
            Log.Debug("Getting started");

            Log.Information("Hello {Name} from thread {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), Environment.CurrentManagedThreadId);

            Log.Warning("Bad lat long {@Position}", new { Lat = 25, Long = 134 });

            UseLevelSwitchToModifyLogLevelDuringRuntime(levelSwitch);

            Fail();
        }
        catch (DivideByZeroException e)
        {
            Log.Error(e, "Division by zero");
        }

        Log.CloseAndFlush();

        
        ExitPrompt();
        
    }

    private static void UseLevelSwitchToModifyLogLevelDuringRuntime(LoggingLevelSwitch levelSwitch)
    {
        levelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;

        Log.Information("This should not be logged");

        Log.Error("This should be logged");

        levelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;

        Log.Information("This should be logged again");
    }

    private static void Fail()
    {
        throw new DivideByZeroException();
    }

}