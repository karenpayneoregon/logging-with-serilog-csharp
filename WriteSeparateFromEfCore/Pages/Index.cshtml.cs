using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WriteSeparateFromEfCore.Data;

namespace WriteSeparateFromEfCore.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Index OnGet");
    }
}
