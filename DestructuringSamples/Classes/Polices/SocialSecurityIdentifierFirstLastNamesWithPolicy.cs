using DestructuringSamples.Interfaces;
using Serilog.Core;
using Serilog.Events;

namespace DestructuringSamples.Classes.Polices;

/// <summary>
/// Provides a custom destructuring policy for handling objects that implement the <see cref="ICustomer"/> interface.
/// This policy extracts and includes the customer's identifier, first name, last name, and social security number
/// when logging structured data.
/// </summary>
public class SocialSecurityIdentifierFirstLastNamesWithPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
    {
        if (value is ICustomer c)
        {
            result = propertyValueFactory.CreatePropertyValue(new { c.Id, c.FirstName, c.LastName, c.SocialSecurityNumber });
            return true;
        }

        result = null;
        return false;
    }
}