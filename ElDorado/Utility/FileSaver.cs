using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElDorado.Utility
{
    public static class FileSaver
    {
        public static string FileName = "EldoradoFindings.txt";
        public static string Directory = @"C:\results\";
        private static bool _initialize = false;

        public static void WritePortFindings(string domain, string portList)
        {
            string[] fileContents = File.ReadAllLines(Path.Combine(Directory, FileName));

            for (int i = 0; i < fileContents.Length; ++i)
            {
                if (fileContents[i] == domain)
                {
                    fileContents[i] += " - " + portList;
                    break;
                }
            }

            // And writing it all back out:

            File.WriteAllLines(Path.Combine(Directory, FileName), fileContents);
        }

        public static void WriteSubdomainFinding(string domain)
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
                    sw.WriteLine(domain);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(Path.Combine(Directory, FileName)))
                {
                    sw.WriteLine(domain);
                }
            }
        }
    }
}