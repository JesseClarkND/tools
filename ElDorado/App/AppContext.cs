using ElDorado.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElDorado.App
{
    public static class AppContext
    {
        public static bool SearchFindings = false;

        public static GenerationMode Mode;
        public static string FileLocation = "";
        public static List<string> Found = new List<string>();
        public static List<string> Scanned = new List<string>();
        public static Dictionary<string, List<int>> PortsFound = new Dictionary<string, List<int>>();
    }
}