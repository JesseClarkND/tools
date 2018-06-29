using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Utility
{
    public static class FileSaver
    {
        public static string FileName = "SocialiteFindings.txt";
        public static string Directory = @"C:\results\";
        private static bool _initialize = false;

        public static void WriteLinkFinding(string link)
        {
            if (!_initialize)
            {
                System.IO.Directory.Exists(Directory);
                _initialize = true;
            }
            // This text is added only once to the file.
            if (!File.Exists(Path.Combine(Directory, FileName)))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(Path.Combine(Directory, FileName)))
                {
                    sw.WriteLine(link);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(Path.Combine(Directory, FileName)))
                {
                    sw.WriteLine(link);
                }
            }
        }
    }
}