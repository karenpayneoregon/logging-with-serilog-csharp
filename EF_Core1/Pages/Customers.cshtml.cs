using EF_Core1.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF_Core1.Models;

namespace EF_Core1.Pages;

public class CustomersModel : PageModel
{
    private readonly Context _context;
    private readonly ILogger<IndexModel> _logger;
    public CustomersModel(ILogger<IndexModel> logger, Data.Context context)
    {
        _context = context;
        _logger = logger;
    }

    public IList<Customers> Customers { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Customers != null)
        {
            Customers = await _context.Customers
                .Include(c => c.Contact)
                .Include(c => c.ContactTypeIdentifierNavigation)
                .Include(c => c.CountryIdentifierNavigation).ToListAsync();
        }
    }
}