using Bogus;
using Microsoft.EntityFrameworkCore;
using NorthWind2020ConsoleApp.Data;
using Serilog;


namespace WinFormsApp2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Move += OnTheMove!;
        Controls.OfType<Button>().Where(b => b.Tag.ToString() == "L").ToList().ForEach(x => x.Visible = false);
    }

    private void OnTheMove(object sender, EventArgs e)
    {
        MoveChildForm();
    }

    private void MoveChildForm()
    {
        var childForms = Application.OpenForms.Cast<Form>()
            .Where(form => form.Name == nameof(SideForm));

        if (childForms.Any())
        {
            foreach (var currentChildForm in childForms)
            {
                currentChildForm.Top = Top;
                currentChildForm.Left = currentChildForm.Tag!.ToString() == "Left" ? (Left - Width) + 120 : (Left + Width);
            }
        }
    }

    private void LogWindowButton_Click(object sender, EventArgs e)
    {
        var childForms = Application.OpenForms.Cast<Form>()
            .Where(form => form.Name == nameof(SideForm)).ToList();

        if (!childForms.Any())
        {
            var childForm1 = new SideForm() { Top = Top, Left = (Left + Width), Tag = "Right" };
            childForm1.Show();
            MoveChildForm();
        }
    }

    private void LogInformationButton_Click(object sender, EventArgs e)
    {
        var faker = new Faker();

        var s1 = faker.Random.Words(8);
        Log.Information(s1);
    }

    private void FIleMissingButton_Click(object sender, EventArgs e)
    {
        try
        {
            File.ReadAllText("appsettings.json");
        }
        catch (Exception exception)
        {
            Log.Error(exception,"Missing file");
        }
    }

    private async void LogEntityFrameworkCoreButton_Click(object sender, EventArgs e)
    {
        await using var context = new Context();
        var customers = await context.Customers.OrderByDescending(c => c.CompanyName).ToListAsync();
        foreach (var customer in customers)
        {
            Log.Information($"{customer.CustomerIdentifier,-4}{customer.CompanyName}");
        }
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        var buttons = Controls.OfType<Button>().Where(b => b.Tag.ToString() == "L").ToList();
        if (keyData == (Keys.F1))
        {
            
            foreach (var button in buttons)
            {
                button.Visible = false;
            }
            return true;
        }
        if (keyData == (Keys.F2))
        {
            foreach (var button in buttons)
            {
                button.Visible = true;
            }
            return true;
        }


        return base.ProcessCmdKey(ref msg, keyData);

    }
}
