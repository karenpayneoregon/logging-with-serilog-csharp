using CreateDynamicControlsCore.Classes.Containers;
using Dapper;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using Log = Serilog.Log;

namespace CreateDynamicControlsCore.Classes;

public class DataOperations
{
    /// <summary>
    /// Read all categories
    /// </summary>
    /// <returns>list of categories</returns>
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
    /// Read products by category identifier
    /// </summary>
    /// <param name="identifier">category identifier</param>
    /// <returns>list of products for category</returns>
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