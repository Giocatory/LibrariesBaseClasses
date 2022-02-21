namespace FilesInputOutput
{
    internal class MyDirectoryInfo
    {

        public MyDirectoryInfo(string path)
        {
            Path = path;
        }
        public static string Path { get; set; } = ".";

        // Привязать к текущему каталогу (DirectoryInfo df = new("."))
        // Bind to current directory (DirectoryInfo df = new("."))

        private readonly DirectoryInfo df = new(Path);

        public void Ls()
        {
            foreach (var file in df.GetDirectories())
            {
                Console.WriteLine(file);
            }
        }

        public void PWD()
        {
            Console.WriteLine();
            Console.WriteLine($"Full Name: {df.FullName}");
            Console.WriteLine($"Name: {df.Name}");
            Console.WriteLine($"Parent: {df.Parent}");
            Console.WriteLine($"Creation: {df.CreationTime}");
            Console.WriteLine($"Attributes: {df.Attributes}");
            Console.WriteLine($"Root: {df.Root}");
        }
    }
}