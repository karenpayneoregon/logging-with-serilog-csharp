using System.ComponentModel;

namespace CreateDynamicControlsCore.Classes.Controls
{
    /// <summary>
    /// Adds a property for storing category primary key
    /// </summary>
    public class DataButton : Button
    {
        [Category("Behavior"), Description("Identifier")]
        public int Identifier { get; set; }
        [Category("Behavior"), Description("Stash")]
        public string Stash { get; set; }
    }

}
