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
        Log.Information("{TimeOfDay} {UserName} to working with {title}", Howdy.TimeOfDay(), "Karen", "SeriLog");
    }

    public IActionResult OnPostButton1(IFormCollection data)
    {
        Log.Information($"Entering {nameof(OnPostButton1)}");
        return Page();
    }


    public IActionResult OnPostButton2(IFormCollection data)
    {
        Log.Information($"Entering {nameof(OnPostButton2)}");
        return Page();
    }
}

