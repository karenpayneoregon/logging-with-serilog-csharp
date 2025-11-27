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
    public IActionResult OnPostButton1()
    {
        Log.Information("Entering {method}", nameof(OnPostButton1));
        Console.WriteLine();
        return new RedirectToPageResult("Index");
    }


    public IActionResult OnPostButton2()
    {
        var list = Operations.GenerateStudents();
        for (int index = 0; index < list.Count; index++)
        {
            Log.Information("First: {P1} Last: {P2} Grade: {P3}", list[index].FirstName, list[index].LastName, list[index].Grade);
        }

        Console.WriteLine();
        
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton3()
    {
        Log.Information("{TimeOfDay} {UserName} to working with {title} some number {number}", Howdy.TimeOfDay(), "Karen", "SeriLog", 100);
        Console.WriteLine();
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton4()
    {
        Log.Information("Is {day} a weekend day? {IsWeekday} ",DateTime.Today.DayOfWeek,  DateTime.Now.IsWeekDay());
        Console.WriteLine();
        return new RedirectToPageResult("Index");
    }
    #region handlers 


    public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var test = context.HandlerMethod!.MethodInfo.Name;
        if (context.HandlerMethod!.MethodInfo.Name == nameof(OnPostButton4))
        {
            Log.Information("Redirecting to {p1}", "OtherPage");
            context.Result = new RedirectResult("OtherPage");
        }
        base.OnPageHandlerExecuting(context);
    }
    #endregion
}
