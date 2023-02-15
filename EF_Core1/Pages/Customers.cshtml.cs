using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF_Core1.Models;

namespace EF_Core1.Pages;

public class CustomersModel : PageModel
{
    private readonly Data.Context _context;

    public CustomersModel(Data.Context context)
    {
        _context = context;
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