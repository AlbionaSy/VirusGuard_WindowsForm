using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusGUARD_Final.Helpers
{
    public class ScannedFiles
    {
        public string FilePath { get; set; }
        public bool IsMalware { get; set; }
    }

    public class ScanningType
    {
        public string FilePath { get; set; }
        public List<CheckType> IsSuspicious { get; set; }
    }

    public class CheckType
    {
        public string MethodName { get; set; }
        public bool isSuspicious { get; set; }
    }
}
