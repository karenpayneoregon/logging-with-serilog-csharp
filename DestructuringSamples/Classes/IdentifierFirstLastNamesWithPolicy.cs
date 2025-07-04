using DestructuringSamples.Interfaces;
using Serilog.Core;
using Serilog.Events;

namespace DestructuringSamples.Classes;

/// <summary>
/// Implements a custom destructuring policy for handling objects of type <see cref="ICustomer"/>.
/// </summary>
/// <remarks>
/// This class customizes the way <see cref="ICustomer"/> objects are logged by Serilog.
/// It extracts specific properties such as <c>Id</c>, <c>FirstName</c>, and <c>LastName</c> for logging purposes.
/// </remarks>
public class IdentifierFirstLastNamesWithPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
    {
        if (value is ICustomer c)
        {
            result = propertyValueFactory.CreatePropertyValue(new { c.Id, c.FirstName, c.LastName });
            return true;
        }

        result = null;
        return false;
    }
}