using MultipleSubmitButtons2.Classes;
using Serilog;
using SeriLogLibrary;

namespace MultipleSubmitButtons2;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        /*
         * Setup SeriLog to use custom colors and log to a file.
         */
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.WriteTo.Console(theme: SeriLogCustomThemes.KarenConsoleTheme());
            configuration.WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", "Log.txt"),
                rollingInterval: RollingInterval.Day);
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        var app = builder.Build();

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

        WindowHelper.SetConsoleWindowTitle(app, "SeriLog colors");

        app.Run();
    }
}
