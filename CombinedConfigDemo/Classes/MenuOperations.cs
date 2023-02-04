using CombinedConfigDemo.Models;
using Spectre.Console;

namespace CombinedConfigDemo.Classes
{
    class MenuOperations
    {
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
