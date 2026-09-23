using System.Diagnostics;
using EF_Core3.Classes;
using EF_Core3.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EF_Core3
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Serilog.Debugging.SelfLog.Enable(message =>
            //{
            //    Debug.WriteLine(message);
            //    Console.Error.WriteLine(message);
            //});
            
            var builder = WebApplication.CreateBuilder(args);

#if COMBINED_LOGS
            
            builder.Host.UseSerilog((context, services, configuration) =>
                configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext());


            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging());
            
#else

            SetupLogging.Other(builder);

            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log,
                        [DbLoggerCategory.Database.Command.Name],
                        LogLevel.Information));

#endif



            builder.Services.AddRazorPages();

            var app = builder.Build();

            //app.Logger.LogInformation("Serilog file logging test");

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
