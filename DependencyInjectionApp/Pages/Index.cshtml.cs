using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace DependencyInjectionApp.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
        Log.Information("Greetings");
        Log.Information("Greetings");
        Log.Information("Greetings");
        Log.Information("Greetings");
        Log.Information("Greetings");
    }
}
