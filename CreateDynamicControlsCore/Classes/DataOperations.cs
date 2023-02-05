using System.Data;
using CreateDynamicControlsCore.Classes.Containers;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using Log = Serilog.Log;

namespace CreateDynamicControlsCore.Classes
{
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
                using var cn = new SqlConnection() { ConnectionString = ConnectionString() };
                var selectStatement = "SELECT CategoryID, CategoryName FROM dbo.Categories WHERE CategoryID <9;";

                using var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement };

                cn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Category() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                }
            }
            catch (Exception exception)
            {
                /*
                 * Standard to get all of the exception is to lose .Message
                 */
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
            var list = new List<Product>();

            using var cn = new SqlConnection() { ConnectionString = ConnectionString() };
            var selectStatement = "SELECT ProductID, ProductName FROM dbo.Products WHERE CategoryID = @Id ORDER BY ProductName";

            using var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement };
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = identifier;

            cn.Open();

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Product() { Id = reader.GetInt32(0), Name = reader.GetString(1) });
            }

            return list;
            
        }
    }
}
