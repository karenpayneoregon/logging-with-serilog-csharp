using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleSubmitButtons2.Classes;
using Serilog;

namespace MultipleSubmitButtons2.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }

    public IActionResult OnPostButton1(IFormCollection data)
    {
        Log.Information("Entering {P1}", nameof(OnPostButton1));
        return new RedirectToPageResult("Index");
    }


    public IActionResult OnPostButton2(IFormCollection data)
    {
        Log.Information("Entering {P1}", nameof(OnPostButton2));
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton3(IFormCollection data)
    {
        Log.Information("{TimeOfDay} {UserName} to working with {title} some number {number}", Howdy.TimeOfDay(), "Karen", "SeriLog",100);
        return new RedirectToPageResult("Index");
    }
}

