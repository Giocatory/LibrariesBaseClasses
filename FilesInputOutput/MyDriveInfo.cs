namespace FilesInputOutput
{
    internal class MyDriveInfo
    {
        private DriveInfo[] driveInfo;
        public MyDriveInfo()
        {
            driveInfo = DriveInfo.GetDrives();
        }
        public void ShowInfo()
        {
            foreach (var drive in driveInfo)
            {
                Console.WriteLine($"Name: {drive.Name}\tDriveType: {drive.DriveType}");
                // Is the device wired?
                if (drive.IsReady)
                {
                    Console.WriteLine($"Free space: {drive.TotalFreeSpace / 1024 / 1024 / 1024} GB");
                    Console.WriteLine($"Format: {drive.DriveFormat}");
                    Console.WriteLine($"Label: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
    }
}
