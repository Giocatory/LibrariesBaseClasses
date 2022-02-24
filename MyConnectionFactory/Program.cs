using System.Configuration;
using System.Data;
using System.Data.SqlClient;

string? dataProviderString = ConfigurationManager.AppSettings["provider"];
DataProvider dataProvider = DataProvider.None;
if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
{
    dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
}
else
{
    Console.WriteLine("Sorry, no provider exists!");
    return;
}

IDbConnection myConnection = GetConnection(dataProvider);
Console.WriteLine($"Connection type: {myConnection.GetType().Name ?? "unrecognized type"}"); // SqlConnection

static IDbConnection GetConnection(DataProvider dataProvider)
{
    IDbConnection? connection;
    switch (dataProvider)
    {
        case DataProvider.SqlServer:
            connection = new SqlConnection();
            break;

        default:
            connection = null;
            break;
    }
    return connection;
}

internal enum DataProvider
{
    SqlServer,
    None
}