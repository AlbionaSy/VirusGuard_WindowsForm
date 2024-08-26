using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using VirusGUARD_Final;
using VirusGUARD_Final.Helpers;

namespace VirusGuard_Antivirus.Helpers
{
    public static class ScannerOfVirus
    {

        public static void ScanDirectory(List<ScannedFiles> pathsWithErrors, string[] files)
        {
            var quanrantineFile = new QuarantineFile();
            List<ScanningType> scannedFiles = new List<ScanningType>();
            foreach (var filePath in files)
            {
                try
                {
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
                        var filePath = quanrantineFile.QuarantineTheFile(item.FilePath);
                        VirusHelper.Threats.Add(filePath);
                    }
                }

            }
        }

    }
}
