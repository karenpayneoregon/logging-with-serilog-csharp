using CommandLineArguments.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#pragma warning disable CS8618

namespace CommandLineArguments.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public string Message { get; set; }
    
    public void OnGet()
    {
        Message = Appsettings.Instance.UseSeriLog ? "Is logging" : "Not logging";
    }
}
