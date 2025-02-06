using CreateDynamicControlsCore.Classes.Controls;
using Serilog;

namespace CreateDynamicControlsCore.Classes;

public static class ButtonOperations
{
    public static List<DataButton> ButtonsList { get; set; }
    public static int Top { get; set; }
    public static int Left { get; set; }
    public static int Width { get; set; }
    public static int HeightPadding { get; set; }
    public static string BaseName { get; set; } = "Button";
    public static EventHandler EventHandler { get; set; }
    public static Control ParentControl { get; set; }
    private static int _index = 1;

    /// <summary>
    /// Initializes the global properties required for creating and managing buttons dynamically.
    /// </summary>
    /// <param name="control">The parent control where the buttons will be placed.</param>
    /// <param name="top">The top position of the first button.</param>
    /// <param name="baseHeightPadding">The vertical padding between buttons.</param>
    /// <param name="left">The left position of the buttons.</param>
    /// <param name="width">The width of the buttons.</param>
    /// <param name="buttonClick">The event handler for the button click event.</param>
    public static void Initialize(this Control control, int top, int baseHeightPadding, int left, int width, EventHandler buttonClick)
    {

        ParentControl = control;
        Top = top;
        HeightPadding = baseHeightPadding;
        Left = left;
        Width = width;
        EventHandler = buttonClick;
        ButtonsList = new List<DataButton>();

        var methodName = $"{nameof(ButtonOperations)}.{nameof(Initialize)}";
        Log.Information("{Caller} Top: {Top} Left: {Left}", methodName, top, left);
            
    }

    /// <summary>
    /// Creates a new button for a specific category and adds it to the parent control.
    /// </summary>
    /// <param name="text">The text to display on the button.</param>
    /// <param name="categoryIdentifier">The unique identifier for the category associated with the button.</param>
    private static void CreateCategoryButton(string text, int categoryIdentifier)
    {

        var button = new DataButton()
        {
            Name = $"{BaseName}{_index}",
            Text = text,
            Width = Width,
            Height = 29,
            Location = new Point(Left, Top),
            Parent = ParentControl,
            Identifier = categoryIdentifier,
            Visible = true,
            ImageAlign = ContentAlignment.MiddleLeft,
            TextAlign = ContentAlignment.MiddleRight
        };

        button.Click += EventHandler;

        var methodName = $"{nameof(ButtonOperations)}.{nameof(CreateCategoryButton)}";
        Log.Information("{Caller} Name: {Name} CategoryId: {CategoryId} Location {Left},{Right}", 
            methodName, button.Name, categoryIdentifier, Left, Top);

        ButtonsList.Add(button);

        ParentControl.Controls.Add(button);
        Top += HeightPadding;
        _index += 1;

    }

    /// <summary>
    /// Dynamically builds buttons for each category retrieved from the data source.
    /// </summary>
    /// <remarks>
    /// This method reads categories using <see cref="DataOperations.ReadCategories"/> and creates a button
    /// for each category using the <c>CreateCategoryButton</c> method.
    /// </remarks>
    public static void BuildButtons()
    {
        foreach (var category in DataOperations.ReadCategories())
        {
            CreateCategoryButton(category.Name, category.Id);
        }
    }
}