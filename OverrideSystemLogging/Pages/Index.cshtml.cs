
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace OverrideSystemLogging.Pages;

public class IndexModel : PageModel
{

    public IndexModel()
    {
    }

    public void OnGet()
    {
        Log.Information("This is a log message from the Index page.");
    }
}
