# About

Using Serilog demonstrates how to implement a custom destructuring policy. This allows you to control how certain objects are logged, which can be useful for sensitive information or simply to reduce log noise.

Here when logging a `Customer` object, we only want to log the `FirstName`, `LastName`, and `OfficePhoneNumber` properties. The rest of the properties are ignored.

## Model

```csharp
public class Customer : ICustomer
{
    public int Id { get; set; }
    public string WorkTitle { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string OfficeEmail { get; set; }
    public string OfficePhoneNumber { get; set; }
}
```

## Policy

```csharp
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
```


