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
    /// Configures the application to use a database connection with sensitive data logging enabled.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> used to configure the application.</param>
    /// <remarks>
    /// This method sets up the database context to log sensitive data. 
    /// It is intended for use in development environments only and should not be used in production.
    /// </remarks>
    public static void SensitiveDataLoggingConnection(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextToFileLogger().Log));
    }

    /// <summary>
    /// Configures single-line logging with sensitive data enabled for Entity Framework Core.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> used to configure the application and services.</param>
    /// <remarks>
    /// This method sets up logging for EF Core by enabling sensitive data logging and configuring
    /// the logger to use single-line formatting with local time. It is intended for development
    /// environments where detailed logging is required.
    /// </remarks>
    public static void SingleLineSensitiveDataLoggingConnection(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging().LogTo(
                    new DbContextToFileLogger().Log,
                    LogLevel.Debug,
                    DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine));

    }

    /// <summary>
    /// Configures production logging for Entity Framework Core.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> used to configure the application and services.</param>
    /// <remarks>
    /// This method sets up logging for EF Core in a production environment by adding a DbContext pool
    /// and configuring it to log database operations using a custom logger.
    /// </remarks>
    public static void ProductionLoggingConnection(this WebApplicationBuilder builder)
    {
        
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .LogTo(
                    new DbContextToFileLogger().Log));

    }
}
