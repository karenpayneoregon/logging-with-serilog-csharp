using CreateDynamicControlsCore.Classes.Containers;
using Dapper;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using Log = Serilog.Log;

namespace CreateDynamicControlsCore.Classes;

public class DataOperations
{
    /// <summary>
    /// Retrieves a list of categories from the database.
    /// </summary>
    /// <remarks>
    /// This method connects to the database, executes a query to fetch all categories,
    /// and maps the results to a list of <see cref="Category"/> objects. 
    /// If an exception occurs during the operation, it is logged using Serilog.
    /// </remarks>
    /// <returns>A list of <see cref="Category"/> objects representing the categories.</returns>
    public static List<Category> ReadCategories()
    {
        var list = new List<Category>();

        try
        {
            using SqlConnection cn = new() { ConnectionString = ConnectionString() };
            var selectStatement = 
                """
                SELECT CategoryID as Id, CategoryName as Name
                FROM dbo.Categories
                """;
            list = cn.Query<Category>(selectStatement).ToList();
        }
        catch (Exception exception)
        {
            Log.Error(exception.Message);
        }

        return list;
            
    }
    /// <summary>
    /// Retrieves a list of products associated with a specific category identifier.
    /// </summary>
    /// <param name="identifier">The unique identifier of the category.</param>
    /// <returns>A list of <see cref="Product"/> objects representing the products in the specified category.</returns>
    /// <remarks>
    /// This method establishes a connection to the database, executes a query to fetch products
    /// belonging to the specified category, and maps the results to a list of <see cref="Product"/> objects.
    /// </remarks>
    public static List<Product> ReadProducts(int identifier)
    {
        using SqlConnection cn = new() { ConnectionString = ConnectionString() };

        var selectStatement = 
            """
            SELECT ProductID as Id, ProductName as Name
            FROM dbo.Products WHERE CategoryID = @Id
            ORDER BY ProductName
            """;

        return cn.Query<Product>(selectStatement, new { Id = identifier }).ToList();

    }
}