using System.Configuration;
using System.Data;
using System.Data.SqlClient;

// string connectionString = "Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;";
string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
Console.WriteLine(connectionString);

SqlConnection connection = new SqlConnection(connectionString);
try
{
    // Открываем подключение
    await connection.OpenAsync();
    Console.WriteLine("Подключение открыто");
}
catch (SqlException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    // если подключение открыто
    if (connection.State == ConnectionState.Open)
    {
        // закрываем подключение
        await connection.CloseAsync();
        Console.WriteLine("Подключение закрыто...");
    }
}
Console.WriteLine("Программа завершила работу.");
Console.Read();
