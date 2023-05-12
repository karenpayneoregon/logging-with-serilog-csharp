using EF_Core2.Classes;
using EF_Core2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EF_Core2.Pages;
public class IndexModel : PageModel
{
    private readonly Context _context;
    public IndexModel(Context context)
    {
        _context = context;
        
    }

    public void OnGet()
    {
        int value = 5;
        var customers = _context
            .Customers
            .Where(customer => customer.CustomerIdentifier > value)
            .ToList();

        Log.Information("Customer count {P1}", customers.Count);
    }
}
