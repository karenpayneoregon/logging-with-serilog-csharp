using CommandLineArguments.Classes;

namespace CommandLineArguments;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true) //this is not needed, but could be useful
            .AddCommandLine(args)
            .Build();

        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        
        /*
         * If the parameter log is not passed the value is false
         */
        Appsettings.Instance.UseSeriLog = config.GetValue<bool>("log");
        SetupLogging.Development(Appsettings.Instance.UseSeriLog);

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
