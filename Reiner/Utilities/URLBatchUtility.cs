using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reiner.Utilities
{
    public static class URLBatchUtility
    {
        public static List<string> LoadBatchs()
        {
            return Directory.EnumerateFiles(Settings.URLBatch, "*.txt").ToList();
        }

        public static IEnumerable<string> LoadBatchNames()
        {
            foreach (var file in LoadBatchs())
            {
                yield return Path.GetFileNameWithoutExtension(file);
            }
        }

        public static List<string> LoadURLsFromBatch(string batchName)
        {
            string[] contents = File.ReadAllLines(Path.Combine(Settings.URLBatch, batchName + ".txt"));
            return contents.ToList();
        }
    }
}