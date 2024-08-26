using System;
using System.IO;
using System.Security.AccessControl;
using VirusGuard_Antivirus.Helpers;
using VirusGUARD_Final;
using VirusGUARD_Final.Helpers;

namespace VirusGuard_Antivirus
{
    internal static class Program
    {
        private static FileSystemWatcher _watcher;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Thread realTimeScanThread = new Thread(new ThreadStart(RealTimeScan));

            realTimeScanThread.Start();

            Application.Run(new Form1());
        }

        static void RealTimeScan()
        {
            var getDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            _watcher = new FileSystemWatcher(getDirectory);

            _watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;
            _watcher.Changed += OnChangeFiles;
            _watcher.Created += OnCreateFiles;
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
           
        }

        private static void OnChangeFiles (object sender, FileSystemEventArgs e)
        {
            List<ScannedFiles> listofFiles = new List<ScannedFiles>();
            var arrayofFiles = new string[]
            {
                e.FullPath
            };
            ScannerOfVirus.ScanDirectory(listofFiles, arrayofFiles);
            foreach (ScannedFiles file in listofFiles)
            {
                if (file.IsMalware)
                {
                    File.Delete(file.FilePath);
                }
            }

        }

        private static void OnCreateFiles(object sender, FileSystemEventArgs e)
        {
            List<ScannedFiles> listofFiles = new List<ScannedFiles>();
            var arrayofFiles = new string[]
            {
                e.FullPath
            };
            ScannerOfVirus.ScanDirectory(listofFiles, arrayofFiles);
            foreach (ScannedFiles file in listofFiles)
            {
                if (file.IsMalware)
                {
                    File.Delete(file.FilePath);
                }
            }
        }
    }
}