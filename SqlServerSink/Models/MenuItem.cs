namespace SqlServerSink.Models;

public class MenuItem
{
    public int Id { get; set; }
    /// <summary>
    /// Menu text to display
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// Action to perform on selection
    /// </summary>
    public Action Action = null!;
    public override string ToString() => Text;
}