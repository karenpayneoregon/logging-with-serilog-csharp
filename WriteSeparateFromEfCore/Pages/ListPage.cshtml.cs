using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WriteSeparateFromEfCore.Classes;
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

    public IList<UserLogin> UserLogin { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Log.Information("Getting users");
        if (_context.UserLogin != null)
        {
            UserLogin = await _context.UserLogin.ToListAsync();
        }
    }
}