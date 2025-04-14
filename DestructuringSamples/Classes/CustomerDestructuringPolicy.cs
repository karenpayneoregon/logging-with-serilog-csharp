using DestructuringSamples.Models;
using Serilog.Core;
using Serilog.Events;

namespace DestructuringSamples.Classes;

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