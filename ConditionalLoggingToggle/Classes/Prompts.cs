namespace ConditionalLoggingToggle.Classes
{
    public class Prompts
    {
        public static List<string> QuestionOptions => new() { "Y", "N" };

        public static string Continue(string questionText, string color) =>
            AnsiConsole.Prompt(
                new TextPrompt<string>($"[{color}]{questionText}[/] {string.Join(",", QuestionOptions)}")
                    .PromptStyle("cyan")
                    .DefaultValue("y")
                    .ValidationErrorMessage($"[red]Valid responses[/] [white]{string.Join(",", QuestionOptions)}[/] [red]or press ENTER for default[/]")
                    .Validate(text => QuestionOptions.Contains(text, StringComparer.CurrentCultureIgnoreCase) switch
                    {
                        false => ValidationResult.Error("[red]Must be[/] [yellow]y[/] [red]or[/] [yellow]n[/]"),
                        _ => ValidationResult.Success()
                    }));

        /// <summary>
        /// Ask for yes, no response
        /// </summary>
        /// <param name="questionText">question</param>
        /// <param name="color">foreground color</param>
        /// <returns>true or false</returns>
        /// <remarks>
        /// There is also AnsiConsole.Confirm but provides no option to
        /// change text color for (y/n)
        /// </remarks>
        public static bool AskConfirmation(string questionText, string color = "white")
        {
            return Continue(questionText,color).ToUpper() == "Y"; 
        }

    }
}
