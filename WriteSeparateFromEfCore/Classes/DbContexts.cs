using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WriteSeparateFromEfCore.Data;

namespace WriteSeparateFromEfCore.Classes;
public static class DbContexts
{
    /// <summary>
    /// Test connection with exception handling
    /// </summary>
    /// <param name="context"><see cref="DbContext"/></param>
    /// <param name="ct">Provides a shorter time out from 30 seconds to in this case one second</param>
    /// <returns>true if database is accessible</returns>
    /// <remarks>
    /// Running asynchronous as synchronous.
    /// </remarks>
    public static bool CanConnectAsync(this DbContext context, CancellationToken ct)
    {
        try
        {
            return context.Database.CanConnectAsync(ct).Result;

        }
        catch
        {
            return false; 
        }
    }

    /// <summary>
    /// Enable sensitive logging for EF Core
    /// </summary>
    public static void SensitiveDataLoggingConnection(this IServiceCollection collection, WebApplicationBuilder builder)
    {

        collection.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextToFileLogger().Log));
    }

    /// <summary>
    /// Single line logging with sensitive data enabled for EF Core
    /// </summary>
    public static void SingleLineSensitiveDataLoggingConnection(this IServiceCollection collection, WebApplicationBuilder builder)
    {

        collection.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging().LogTo(
                    new DbContextToFileLogger().Log,
                    LogLevel.Debug,
                    DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine));

    }
    /// <summary>
    /// Production logging for EF Core
    /// </summary>
    /// <param name="collection"></param>
    public static void ProductionLoggingConnection(this IServiceCollection collection, WebApplicationBuilder builder)
    {
        
        collection.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .LogTo(
                    new DbContextToFileLogger().Log));

    }
}
