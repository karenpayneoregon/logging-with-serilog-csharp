using CreateDynamicControlsCore.Classes.Controls;
using Serilog;

namespace CreateDynamicControlsCore.Classes;

public class Operations
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
    /// <param name="pControl">Control to place button</param>
    /// <param name="pTop">Top</param>
    /// <param name="pBaseHeightPadding">Padding between buttons</param>
    /// <param name="pLeft">Left position</param>
    /// <param name="pWidth">Width of button</param>
    /// <param name="pButtonClick">Click event for button</param>
    public static void Initialize(Control pControl, int pTop, int pBaseHeightPadding, int pLeft, int pWidth, EventHandler pButtonClick)
    {

        ParentControl = pControl;
        Top = pTop;
        HeightPadding = pBaseHeightPadding;
        Left = pLeft;
        Width = pWidth;
        EventHandler = pButtonClick;
        ButtonsList = new List<DataButton>();

        var methodName = $"{nameof(Operations)}.{nameof(Initialize)}";
        Log.Information("{Caller} Top: {Top} Left: {Left}", methodName, pTop, pLeft);
            
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

        var methodName = $"{nameof(Operations)}.{nameof(CreateCategoryButton)}";
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