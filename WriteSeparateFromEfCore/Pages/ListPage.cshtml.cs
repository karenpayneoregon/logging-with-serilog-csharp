using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WriteSeparateFromEfCore.Classes;
using WriteSeparateFromEfCore.Extensions;
using WriteSeparateFromEfCore.Models;

namespace WriteSeparateFromEfCore.Pages;

public class ListPageModel : PageModel
{
    private readonly Data.Context _context;

    public ListPageModel(Data.Context context)
    {
        _context = context;
        CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));

        var success = context.CanConnectAsync(cancellationTokenSource.Token);
        if (success == false)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }

    [BindProperty]
    public IList<UserLogin> UserLogin { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.UserLogin != null)
        {
            UserLogin = await _context.UserLogin.ToListAsync();
        }
    }

    public IActionResult OnPostButton1(IFormCollection data)
    {
        Random rnd = new Random();
        int id = rnd.Next(1, Request.Form["item.id"].Select(x => Convert.ToInt32(x)).LastOrDefault());

        var user = _context.UserLogin.FirstOrDefault(x => x.Id == id);
        if (user is not null)
        {
            Log.Information("Updating user id: {ID} with current pin: {Pin}", id, user.Pin);
            user.Pin = StringHelpers.NextValue(user.Pin);
            Log.Information("New Pin: {Pin}", user.Pin);
            _context.SaveChanges();
        }
        else
        {
            Log.Information("Failed to find {ID}", id);
        }
        
        return RedirectToPage("/Index");
    }
}