using EF_Core3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EF_Core3.Pages;

public class IndexModel(Context context) : PageModel
{
    public void OnGet()
    {
        var contactsList = context.Contacts.ToList();
            
        var customersList = context.Customers
            .Include(c => c.CountryIdentifierNavigation)
            .ToList();
            
        Log.Information("Retrieved {ContactsCount} " +
                        "contacts and {CustomersCount} " +
                        "customers from the database.", 
            contactsList.Count, 
            customersList.Count);
    }
}