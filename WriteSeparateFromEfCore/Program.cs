using WriteSeparateFromEfCore.Classes;

namespace WriteSeparateFromEfCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddRazorPages();

        if (builder.Environment.IsDevelopment())
        {

            SetupLogging.Development();
            builder.SensitiveDataLoggingConnection();
        }
        else
        {
            SetupLogging.Production();
            builder.ProductionLoggingConnection();
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
