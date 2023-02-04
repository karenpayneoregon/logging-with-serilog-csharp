using Spectre.Console;
using SqlServerSink.Models;

namespace SqlServerSink.Classes
{
    class MenuOperations
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();

                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
                if (menuItem.Id != -1)
                {
                    menuItem.Action();
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// Create main menu
        /// </summary>
        public static SelectionPrompt<MenuItem> SelectionPrompt()
        {
            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = new Style(Color.White, Color.Blue, Decoration.None)
            };

            menu.Title("[white on blue]Select a option[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new () { Id =  1, Text = "Create some log entries  ",  Action = LogOperations.CreateSomeLogs },
                new () { Id =  2, Text = "View Information entries ",  Action = LogOperations.ViewInformationEntries },
                new () { Id =  3, Text = "View Error entries       ",  Action = LogOperations.ViewErrorEntries },
                new () { Id =  4, Text = "View Warning entries     ",  Action = LogOperations.ViewWarningEntries },
                new () { Id = -1, Text = "Exit                     "},
            });

            return menu;

        }
    }
}
