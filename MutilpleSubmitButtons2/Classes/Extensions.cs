namespace MultipleSubmitButtons2.Classes;

public static class Extensions
{
    public static int GetAge(this DateOnly dateOfBirth)
    {
        var today = DateTime.Today;

        var value1 = (today.Year * 100 + today.Month) * 100 + today.Day;
        var value2 = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (value1 - value2) / 10000;
    }
}
