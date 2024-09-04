using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleSubmitButtons2.Classes;
using Serilog;

namespace MultipleSubmitButtons2.Pages;
public class IndexModel : PageModel
{

    public IndexModel()
    {

    }

    public void OnGet()
    {
        
    }

    public IActionResult OnPostCustomers()
    {
        Log.Information("Entering {P1}", nameof(OnPostCustomers));
        BogusOperations.CustomersList(2, true);
        return new RedirectToPageResult("Index");
    }


    public IActionResult OnPostAge()
    {
        var birthDate = new DateOnly(1956, 9, 24);
        Log.Information("Birth: {Birth} Age: {Age}", birthDate,birthDate.GetAge());
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostHowdy()
    {
        Log.Information("{TimeOfDay} {UserName} to working with {title} some number {number}", Howdy.TimeOfDay(), "Karen", "SeriLog",100);
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostException()
    {
        Exception ex = new Exception("This is a test exception");
        Log.Error(ex, "This is a test exception");
        return new RedirectToPageResult("Index");
    }
    #region handlers 


    public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var postInfoName = context.HandlerMethod?.Name;

        if (postInfoName is not null)
        {
            Log.Information("Processing {@Caller}", postInfoName);
        }
        
        base.OnPageHandlerExecuting(context);
    }
    #endregion
}

