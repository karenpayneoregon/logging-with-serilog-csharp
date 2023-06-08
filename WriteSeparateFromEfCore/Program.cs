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
            builder.Services.SensitiveDataLoggingConnection(builder);
        }
        else
        {
            SetupLogging.Production();
            builder.Services.ProductionLoggingConnection(builder);
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
