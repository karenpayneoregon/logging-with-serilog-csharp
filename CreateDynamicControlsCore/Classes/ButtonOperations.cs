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
    /// Initialize global properties
    /// </summary>
    /// <param name="control">Control to place button</param>
    /// <param name="top">Top</param>
    /// <param name="baseHeightPadding">Padding between buttons</param>
    /// <param name="left">Left position</param>
    /// <param name="width">Width of button</param>
    /// <param name="buttonClick">Click event for button</param>
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

    public static void BuildButtons()
    {
        foreach (var category in DataOperations.ReadCategories())
        {
            CreateCategoryButton(category.Name, category.Id);
        }
    }
}