using Microsoft.EntityFrameworkCore;
using WriteSeparateFromEfCore.Classes;
using WriteSeparateFromEfCore.Data;

namespace WriteSeparateFromEfCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddRazorPages();

        IConfigurationRoot configuration = Configurations.GetConfigurationRoot();
        if (builder.Environment.IsDevelopment())
        {

            SetupLogging.Development();
            builder.Services.ProductionLoggingConnection();
        }

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
