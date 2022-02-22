using Serialize;
using System.Runtime.Serialization.Formatters.Binary;

Userprefs userData = new();
userData.WindowColor = "Yellow";
userData.FontSize = 50;

// BinaryFormatter сохраняет данные в двоичном формате.
// Чтобы получить доступ к BinaryFormatter, необходимо импортировать 
// пространство имен System.Runtime.Serialization.Formatters.Binary
BinaryFormatter binFormat = new();
// Сохранить объект в локальном файле.
using (Stream fStream = new FileStream("user.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
{
    binFormat.Serialize(fStream, userData);
}