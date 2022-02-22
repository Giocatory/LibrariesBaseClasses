using FilesInputOutput;

MyDirectoryInfo mdi = new("D:/localhost/Giocatory/LibrariesBaseClasses/FilesInputOutput");
mdi.Ls();
// D:\localhost\Giocatory\LibrariesBaseClasses\FilesInputOutput\bin\Debug\net6 .0\files
// D:\localhost\Giocatory\LibrariesBaseClasses\FilesInputOutput\bin\Debug\net6 .0\ref
mdi.PWD();
/*
Full Name: D:\localhost\Giocatory\LibrariesBaseClasses\FilesInputOutput\bin\Debug\net6.0
Name: net6.0
Parent: D:\localhost\Giocatory\LibrariesBaseClasses\FilesInputOutput\bin\Debug
Creation: 21.02.2022 11:42:20
Attributes: Directory
Root: D:\
*/
Console.WriteLine();
MyDriveInfo drive = new();
drive.ShowInfo();
/*
Name: C:\       DriveType: Fixed
Free space: 152 GB
Format: NTFS
Label:

Name: D:\       DriveType: Fixed
Free space: 390 GB
Format: NTFS
Label: hard_out_disk
*/

//  Create and write file
using (StreamWriter writer = File.CreateText("D:/localhost/Giocatory/LibrariesBaseClasses/FilesInputOutput/files/Test.txt"))
{
    writer.WriteLine("Hello");
    writer.WriteLine("Mikhail");
    writer.WriteLine("Like You!");
}
// Read file
using (StreamReader reader = File.OpenText("D:/localhost/Giocatory/LibrariesBaseClasses/FilesInputOutput/files/Test.txt"))
{
    string? line = null;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}
using (StreamReader reader = new("D:/localhost/Giocatory/LibrariesBaseClasses/FilesInputOutput/files/Test.txt"))
{
    string? line = null;
    while ((line = reader.ReadLine()) != null)
    {
        if (line.StartsWith("L"))
        {
            Console.WriteLine(line);
        }
    }
}