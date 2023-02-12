using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SerilogCustomLogColors.Classes;

namespace SerilogCustomLogColors.Pages;

//[CustomFilter]
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
        Log.Information("Entering {method}", nameof(OnPostButton1));
        return new RedirectToPageResult("Index");
    }


    public IActionResult OnPostButton2(IFormCollection data)
    {
        Log.Information("Entering {method}", nameof(OnPostButton2));
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton3(IFormCollection data)
    {
        Log.Information("{TimeOfDay} {UserName} to working with {title} some number {number}", Howdy.TimeOfDay(), "Karen", "SeriLog", 100);
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton4(IFormCollection data)
    {
        Log.Information("Is {day} a weekend day? {IsWeekday} ",DateTime.Today.DayOfWeek,  DateTime.Now.IsWeekDay());
        return new RedirectToPageResult("Index");
    }
    #region handlers 
    public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        if (context.HandlerMethod!.MethodInfo.Name == nameof(OnGet))
        {
            // page
        }
        else if (context.HandlerMethod!.MethodInfo.Name == nameof(OnPostButton1))
        {
            
            Log.Information("Entering {P1} for {P2}",
                nameof(OnPageHandlerSelected), OnPostButton1);
        }
    }

    public override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        Log.Information("Entering {P1}", 
            nameof(OnPageHandlerExecutionAsync));

        return base.OnPageHandlerExecutionAsync(context, next);
    }

    public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (context.HandlerMethod!.MethodInfo.Name == nameof(OnPostButton4))
        {
            Log.Information("Redirecting to {p1}", "OtherPage");
            context.Result = new RedirectResult("OtherPage");
        }
        base.OnPageHandlerExecuting(context);
    }
    #endregion
}
