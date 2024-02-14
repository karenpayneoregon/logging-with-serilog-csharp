using static System.DateTime;
using Serilog;
using SeriLogThemesLibrary;

namespace DependencyInjectionApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                    "LogFiles", 
                    $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}"));



        // Add services to the container.
        builder.Services.AddRazorPages();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
