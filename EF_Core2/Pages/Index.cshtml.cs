using EF_Core2.Classes;
using EF_Core2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace EF_Core2.Pages;
public class IndexModel : PageModel
{
    private readonly Context _context;
    public IndexModel(Context context)
    {
        _context = context;
        SetupLogging.CreateLogger();
    }

    public void OnGet()
    {

        var customers = _context.Customers.ToList();

        Log.Information("Customer count {P1}", customers.Count);
    }
}
