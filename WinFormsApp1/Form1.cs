using Serilog;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void InformationButton_Click(object sender, EventArgs e)
    {
        Log.Information("Getting ready to do something.");
    }

    private void ExceptionButton_Click(object sender, EventArgs e)
    {
        try
        {
            File.ReadAllLines("SomeFile.txt");
        }
        catch (Exception exception)
        {
            Log.Error(exception, "Whatever");
        }
    }

    private void WarningButton_Click(object sender, EventArgs e)
    {
        Log.Warning("Some warning");
    }

    private void button1_Click(object sender, EventArgs e)
    {



        string lines = 
            """
            Karen,Payne
            Mike,Jones
            """;

        var results1 = lines.ReplaceLineEndings("\n");


        var results2 = lines.Replace("\r\n", "\n").Replace("\r", "\n");



    }
}
