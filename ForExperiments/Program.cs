using System.Configuration;
using System.Data.SqlClient;

// string connectionString = "Server=.\SQLEXPRESS;Database=MyExperiment;Trusted_Connection=True;";
string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
Console.WriteLine(connectionString);

try
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        await connection.OpenAsync();
        Console.WriteLine("Подключение открыто");
        // Вывод информации о подключении
        Console.WriteLine("Свойства подключения:");
        Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
        Console.WriteLine($"\tБаза данных: {connection.Database}");
        Console.WriteLine($"\tСервер: {connection.DataSource}");
        Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
        Console.WriteLine($"\tСостояние: {connection.State}");
        Console.WriteLine($"\tWorkstationld: {connection.WorkstationId}");
        Console.WriteLine($"\tConnection ID: {connection.ClientConnectionId}");
        // Добавление значений в таблицу
        string queryToAdd = "INSERT INTO dbo.students (ID, FirstName, LastName, PhoneNumber) VALUES (1, 'Mike', 'SBK', '1234')";
        SqlCommand command = new(queryToAdd, connection);
        int changeCols = await command.ExecuteNonQueryAsync();
        Console.WriteLine($"\tAdded values: {changeCols}");
        // Чтение значений из таблицы
        string queryToRead = "SELECT * FROM dbo.students";
        command = new(queryToRead, connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        if (reader.HasRows) // если есть данные
        {
            // выводим названия столбцов
            string columnName1 = reader.GetName(0);
            string columnName2 = reader.GetName(1);
            string columnName3 = reader.GetName(2);
            string columnName4 = reader.GetName(3);

            Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName3}\t{columnName4}");

            while (await reader.ReadAsync()) // построчно считываем данные
            {
                object id = reader.GetValue(0);
                object firstName = reader.GetValue(1);
                object lastName = reader.GetValue(2);
                object phoneNumber = reader.GetValue(3);

                Console.WriteLine($"{id} \t{firstName} \t\t{lastName} \t\t{phoneNumber}");
            }
        }

        await reader.CloseAsync();
    }
    Console.WriteLine("Подключение закрыто...");
    Console.WriteLine("Программа завершила работу.");
    Console.Read();
}
catch (SqlException ex)
{
    Console.WriteLine(ex.Message);
}
/*
Server =.\SQLEXPRESS01; Database = MyExperiment; Trusted_Connection = True;
Подключение открыто
Свойства подключения:
        Строка подключения: Server =.\SQLEXPRESS01; Database = MyExperiment; Trusted_Connection = True;
        База данных: master
        Сервер: .\SQLEXPRESS01
        Версия сервера: 15.00.2000
        Состояние: Open
        Workstationld: DESKTOP - JINR51J
        Connection ID: b6fb9de0-cb5a-4fb2-aad5-1c7619d8bfea
        Added values: 1
ID      FirstName       LastName        PhoneNumber
1       Mike            SBK             1234
Подключение закрыто...
Программа завершила работу.
*/