using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusGuard_Antivirus.Helpers;
using VirusGUARD_Final.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VirusGUARD_Final
{
    public partial class Security : UserControl
    {
        QuarantineFile quarantineFile;
        public Security()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("FilePath", 150);
            listView1.Columns.Add("IsVirus", 100);
            quarantineFile = new QuarantineFile();

        }

        private void ScanDirectory(List<ScannedFiles> pathsWithErrors, string[] files)
        {

            int progresBar = (int)Math.Round(100.00 / files.Length);
            listView1.Visible = false;
            List<ScanningType> scannedFiles = new List<ScanningType>();
            foreach (var filePath in files)
            {
                try
                {
                    progresbarFullCheck.Value += progresBar;
                    ScannerHelper.IsFileSuspicious(filePath, scannedFiles);
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            foreach (var item in scannedFiles)
            {
                var isError = item.IsSuspicious.Where(x => x.isSuspicious);
                bool isEntropySuspicious = isError.Any(x => x.MethodName.ToLower() == "entropy");
                bool isFileSizeSuspicious = isError.Any(x => x.MethodName.ToLower() == "filesize");
                bool isFileContentSuspicious = isError.Any(x => x.MethodName.ToLower() == "filecontent");

                bool isMalware = false;
                if ((isEntropySuspicious && isError.Count() > 1) || (isFileSizeSuspicious && isFileContentSuspicious) || isError.Count() > 2)
                {
                    isMalware = true;
                }
                pathsWithErrors.Add(new ScannedFiles()
                {
                    IsMalware = isMalware,
                    FilePath = item.FilePath
                });
            }

        }

        private void Security_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal static void ScanDirectory(string fullPath, List<ScannedFiles> listofFiles)
        {
            throw new NotImplementedException();
        }

        private void QuickScan_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            listView1.Visible = false;
            listView1.Items.Clear();
            List<ScannedFiles> pathsWithErrors = new List<ScannedFiles>();
            progresbarFullCheck.Value = 0;
            progresbarFullCheck.Visible = true;
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] files = Directory.GetFiles(downloadsPath);
            ScanDirectory(pathsWithErrors, files);
            lblLoading.Visible = false;
            progresbarFullCheck.Visible = false;
            listView1.Visible = true;
            if (pathsWithErrors.Any())
            {
                foreach (var item in pathsWithErrors)
                {
                    if (item.IsMalware)
                    {
                        // Microsoft library DirectorySecurity that will remove the access of the file.
                        // what this means is that the file can not be executed by itself or any other sources
                        // only if the user of the computer wants it to run 
                        var directoryInfo = new DirectoryInfo(item.FilePath);
                        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                        // remove any inherited access 
                        directorySecurity.SetAccessRuleProtection(true, false);

                        FileSystemAccessRule accessRule = new FileSystemAccessRule("Everyone", FileSystemRights.Read, AccessControlType.Allow);
                        directorySecurity.AddAccessRule(accessRule);
                        directoryInfo.SetAccessControl(directorySecurity);

                        // quarantine the file that is affected
                        var filePath = quarantineFile.QuarantineTheFile(item.FilePath);
                        VirusHelper.Threats.Add(filePath);
                    }
                    ListViewItem listViewItem = new ListViewItem(item.FilePath);
                    listViewItem.SubItems.Add(item.IsMalware.ToString());
                    listView1.Items.Add(listViewItem);
                }
            }
            if (VirusHelper.Threats.Any())
            {
                ThreatFoundForm.Visible = true;
                ThreatFoundForm.BringToFront();
            }
        }

        private void FolderScan_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            listView1.Visible = false;
            listView1.Items.Clear();
            List<ScannedFiles> pathsWithErrors = new List<ScannedFiles>();
            folderBrowserDialog1.ShowDialog();
            progresbarFullCheck.Value = 0;
            progresbarFullCheck.Visible = true;
            var folderToScan = folderBrowserDialog1.SelectedPath;
            string[] files = Directory.GetFiles(folderToScan, "*.*", SearchOption.AllDirectories);
            ScanDirectory(pathsWithErrors, files);
            lblLoading.Visible = false;
            progresbarFullCheck.Visible = false;
            listView1.Visible = true;
            if (pathsWithErrors.Any())
            {
                foreach (var item in pathsWithErrors)
                {
                    if (item.IsMalware)
                    {
                        // Microsoft library DirectorySecurity that will remove the access of the file.
                        // what this means is that the file can not be executed by itself or any other sources
                        // only if the user of the computer wants it to run 
                        var directoryInfo = new DirectoryInfo(item.FilePath);
                        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                        // remove any inherited access 
                        directorySecurity.SetAccessRuleProtection(true, false);

                        FileSystemAccessRule accessRule = new FileSystemAccessRule("Everyone", FileSystemRights.Read, AccessControlType.Allow);
                        directorySecurity.AddAccessRule(accessRule);
                        directoryInfo.SetAccessControl(directorySecurity);
                        // quarantine the file that is affected
                        var filePath = quarantineFile.QuarantineTheFile(item.FilePath);

                        VirusHelper.Threats.Add(filePath);
                    }
                    ListViewItem listViewItem = new ListViewItem(item.FilePath);
                    listViewItem.SubItems.Add(item.IsMalware.ToString());
                    listView1.Items.Add(listViewItem);
                }
            }

            if (VirusHelper.Threats.Any())
            {
                ThreatFoundForm.Visible = true;
                ThreatFoundForm.BringToFront();
            }
        }

        private void FullScan_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            listView1.Visible = false;
            List<ScannedFiles> pathsWithErrors = new List<ScannedFiles>();
            progresbarFullCheck.Value = 0;
            listView1.Items.Clear();
            progresbarFullCheck.Visible = true;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string[] filePaths = { desktopPath, downloadsPath };

            foreach (var file in filePaths)
            {
                string[] files = Directory.GetFiles(file, "*.*", SearchOption.AllDirectories);
                ScanDirectory(pathsWithErrors, files);
            }

            lblLoading.Visible = false;
            progresbarFullCheck.Visible = false;
            listView1.Visible = true;
            if (pathsWithErrors.Any())
            {
                foreach (var item in pathsWithErrors)
                {
                    if (item.IsMalware)
                    {
                        // Microsoft library DirectorySecurity that will remove the access of the file.
                        // what this means is that the file can not be executed by itself or any other sources
                        // only if the user of the computer wants it to run 
                        var directoryInfo = new DirectoryInfo(item.FilePath);
                        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                        // remove any inherited access 
                        directorySecurity.SetAccessRuleProtection(true, false);

                        // re-asign the access of the file for everyonne, removing the execution.
                        FileSystemAccessRule accessRule = new FileSystemAccessRule("Everyone", FileSystemRights.Read, AccessControlType.Allow);
                        directorySecurity.AddAccessRule(accessRule);
                        directoryInfo.SetAccessControl(directorySecurity);
                        // quarantine the file that is affected
                        var filePath = quarantineFile.QuarantineTheFile(item.FilePath);
                        VirusHelper.Threats.Add(filePath);
                    }
                    ListViewItem listViewItem = new ListViewItem(item.FilePath);
                    listViewItem.SubItems.Add(item.IsMalware.ToString());
                    listView1.Items.Add(listViewItem);
                }
            }
            if (VirusHelper.Threats.Any())
            {
                ThreatFoundForm.Visible = true;
                ThreatFoundForm.BringToFront();
            }
        }
    }
}

    public class QuarantineFile
    {
        private string filePath = "C:\\Users\\Lenovo\\Desktop\\Quarantine";
        public QuarantineFile()
        {
            // this will asure to create the directory of filepath if it not exists.
            Directory.CreateDirectory(filePath);
        }

        public string QuarantineTheFile(string file)
        {
            FileInfo fi = new FileInfo(file);
            string quarantineFile = $"{Guid.NewGuid()}-{fi.Name}";
            var quarantinePathFile = Path.Combine(filePath, quarantineFile);

            // here we are moving the file that is infected to another directory when we can monitor
            File.Move(file, quarantinePathFile);
            return quarantinePathFile;
        }
    }

