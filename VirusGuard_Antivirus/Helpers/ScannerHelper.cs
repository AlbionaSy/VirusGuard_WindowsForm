using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VirusGUARD_Final.Helpers;

namespace VirusGuard_Antivirus.Helpers
{
    public static class ScannerHelper
    {
        public static string VirusSignature { get; set; } = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3";
        private static string CalculateSHA256Hash(string inputContent)
        {
            using (SHA256 sha256 = SHA256.Create()) 
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputContent)); 
                StringBuilder contentString = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    contentString.Append(data[i].ToString("x2")); //it formats as at least 2 uppercase hexadecimal chars
                }
                return contentString.ToString();
            }   
        }

        public static bool IsVirus(string hash)
        {
            string virusSignature = VirusSignature;

            return hash.Equals(virusSignature, StringComparison.OrdinalIgnoreCase);
        }

        public static void IsFileSuspicious(string filePath, List<ScanningType> listOfPotentialMalware)
        {
            try
            {
                //Signature hash
            
                string fileContent = File.ReadAllText(filePath);
                string hash = CalculateSHA256Hash(fileContent);
                var scannedFiles = new ScanningType()
                {
                    IsSuspicious = new List<CheckType>()
                };
                scannedFiles.FilePath = filePath;

                if (IsVirus(hash))
                {
                    var checkType = new CheckType()
                    {
                        isSuspicious = true,
                        MethodName = "Hash"
                    };
                    scannedFiles.IsSuspicious.Add(checkType);
                }

                //File size

                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > 1 * 1024 * 1024)  // Check if the file size is greater than 1 MB
                {
                    var checkType = new CheckType()
                    {
                        isSuspicious = true,
                        MethodName = "FileSize"
                    };
                    scannedFiles.IsSuspicious.Add(checkType);// File size exceeds threshold, consider suspicious
                }

                //Entropy

                double entropy = CalculateEntropy(filePath);
                if (entropy > 7.0) // this shows that if the entropy of the file is greater it means that is error or virus 
                {
                    var checkType = new CheckType()
                    {
                        isSuspicious = true,
                        MethodName = "Entropy"
                    };
                    scannedFiles.IsSuspicious.Add(checkType);
                }


                // Check the file extension
                string fileExtension = Path.GetExtension(filePath).ToLower();
                if (fileExtension == ".exe" || fileExtension == ".dll")
                {
                    var checkType = new CheckType()
                    {
                        isSuspicious = true,
                        MethodName = "FileExtention"
                    };
                    scannedFiles.IsSuspicious.Add(checkType); // Executable files may be suspicious
                }

                // Check for presence of suspicious keywords in file name
                string fileName = Path.GetFileName(filePath).ToLower();
                string[] suspiciousKeywords = { "malware", "virus", "trojan" };
                foreach (string keyword in suspiciousKeywords)
                {
                    if (fileName.Contains(keyword))
                    {
                        var checkType = new CheckType()
                        {
                            isSuspicious = true,
                            MethodName = "FileContent"
                        };
                        scannedFiles.IsSuspicious.Add(checkType); // File name contains suspicious keywords
                    }
                }

 

                listOfPotentialMalware.Add(scannedFiles); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error analyzing file: {ex.Message}");
              
            }
        }

        static double CalculateEntropy(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return 0.0;
            }

            byte[] data = File.ReadAllBytes(filePath);
            Dictionary<byte, int> byteCounts = new Dictionary<byte, int>();

            // Count occurrences of each byte in the file
            foreach (byte b in data)
            {
                if (byteCounts.ContainsKey(b))
                    byteCounts[b]++;
                else
                    byteCounts[b] = 1;
            }

            // Calculate entropy based on byte frequencies
            int totalBytes = data.Length;
            double entropy = 0.0;

            foreach (int count in byteCounts.Values)
            {
                double probability = (double)count / totalBytes;
                entropy -= probability * Math.Log2(probability);
            }

            return entropy;
        }

    }
}
