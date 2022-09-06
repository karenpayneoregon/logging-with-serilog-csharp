using ConsoleHelperLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicLogging1.Classes
{
    internal class Startup
    {
        [ModuleInitializer]
        public static void Init()
        {

            Console.Title = "Serilog log to console";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }   
    }
}
