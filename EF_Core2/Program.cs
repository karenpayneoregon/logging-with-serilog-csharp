using System.Diagnostics;
using EF_Core2.Classes;
using EF_Core2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace EF_Core2;

public class Program
{
    public static void Main(string[] args)
    {
        // for SeriLog to write to the current folder, only for development
        Environment.CurrentDirectory = AppContext.BaseDirectory;
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.Sources.Clear();
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        builder.Configuration.AddCommandLine(args);

        // Configure Serilog
        //builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        //    loggerConfiguration
        //        .ReadFrom.Configuration(hostingContext.Configuration)
        //);
        
        // Add services to the container.
        builder.Services.AddRazorPages();
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextToFileLogger().Log,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            // Configure Serilog
            SetupLogging.Production();
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            // Configure Serilog
            SetupLogging.Development();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }

}
