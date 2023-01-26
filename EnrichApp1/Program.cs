using Serilog;
using Serilog.Templates;

namespace EnrichApp1;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        LogToConsole();
        Console.ReadLine();
    }

    static Offer FillOffer() => new(54, 100808, "Book", 109, 3);

    static void LogToConsole()
    {
        var offer = FillOffer();

        Log.Logger = new LoggerConfiguration()
            .Enrich.WithProperty("offerId", offer.Id)
            .Enrich.WithProperty("productId", offer.ProductId)
            .Enrich.WithProperty("quantity", offer.Quantity)
            .WriteTo.Console(new ExpressionTemplate("{ {@t, @mt, @l: if @l = 'Information' then undefined() else @l, @x, ..@p} }\n"))
            .WriteTo.File(new ExpressionTemplate(
                    "{ {@t, @mt, @l: if @l = 'Information' then undefined() else @l, @x, ..@p} }\n"),
                "Logs\\log.txt",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Information about the Offer");
    }
}