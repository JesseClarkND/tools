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
        public static GenerationMode Mode;
        public static string FileLocation = "";
        public static List<string> Found = new List<string>();
    }
}