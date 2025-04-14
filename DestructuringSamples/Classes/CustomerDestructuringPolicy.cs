using DestructuringSamples.Interfaces;
using Serilog.Core;
using Serilog.Events;

namespace DestructuringSamples.Classes;

/// <summary>
/// Implements a custom destructuring policy for handling objects of type <see cref="ICustomer"/>.
/// </summary>
/// <remarks>
/// This class is used to customize the way <see cref="ICustomer"/> objects are logged by Serilog.
/// It extracts specific properties such as <c>FirstName</c>, <c>LastName</c>, and <c>OfficePhoneNumber</c> for logging purposes.
/// </remarks>
public class CustomerDestructuringPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
    {
        if (value is ICustomer c)
        {
            result = propertyValueFactory.CreatePropertyValue(new { c.FirstName, c.LastName, c.OfficePhoneNumber });
            return true;
        }

        result = null;
        return false;
    }
}