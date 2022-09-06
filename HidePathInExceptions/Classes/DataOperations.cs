

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HidePathInExceptions.Classes
{
    public class DataOperations
    {


        /// <summary>
        /// Read data from SQL-Server
        /// </summary>
        /// <param name="delay">For slowing things done for this code sample, normally we don't slow things done</param>
        /// <param name="useGoodConnectionString">decide to use a good or bad connection string</param>
        /// <returns></returns>
        public static async IAsyncEnumerable<string> GetData(bool delay, bool useGoodConnectionString)
        {

            string goodConnectionString =
                "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2022;integrated security=True;Encrypt=False";

            string badConnectionString =
                "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2022;integrated security=True;";

            string connectionString = badConnectionString;
            if (useGoodConnectionString)
            {
                connectionString = goodConnectionString;
            }

 
            var statement = "SELECT P.ProductName FROM OrderDetails AS OD INNER JOIN Products AS P ON OD.ProductID = P.ProductID";
            await using var cn = new SqlConnection(connectionString);
            await using var cmd = new SqlCommand { Connection = cn, CommandText = statement };

            await cn.OpenAsync(new CancellationTokenSource(TimeSpan.FromSeconds(GlobalStuff.TimeOutSeconds)).Token);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {

                if (delay)
                {
                    await Task.Delay(GlobalStuff.TimeSpan);
                }

                yield return reader.GetString(0);
            }

        }
    }
}
