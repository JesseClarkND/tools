using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElDorado.Utility
{
    public enum GenerationMode
    {
        Brute,
        File
    }

    public class SubDomainGenerator
    {

        private GenerationMode _generationMode;
        private ulong _genCount = 0;
        private int _maxLength = 3;
        private List<string> _domains = new List<string>();
        private string _dir = "";
        private readonly object _lockList = new object();
 
        public SubDomainGenerator(int startinglength=1)
        {
            _generationMode = GenerationMode.Brute;
            _genCount = (ulong)Math.Pow(10, startinglength-1);
            if (_genCount == 1)
                _genCount--;
        }

        public SubDomainGenerator(string fileLocation)
        {
            _generationMode = GenerationMode.File;
            _dir = fileLocation;

            if (!File.Exists(_dir))
                throw new Exception("File doesn't exist");

            //todo: findout if best method, maybe move items to a sqllite db and read from there
            var logFile = File.ReadAllLines(_dir);
            _domains = new List<string>(logFile);
        }

        public string Next()
        {
            if (_generationMode == GenerationMode.Brute)
            {
                string domain = BruteGenerator.GenerateString(_genCount++);
                if(domain.Length>_maxLength)
                    return "";
                return domain;
            }
            else
            {
                if (_domains.Count == 0)
                {
                    return "";
                }

                string returnString = "";
                lock (_lockList)
                {
                    if (_domains.Count <= (int)_genCount)
                        return "";

                    returnString = _domains[(int)_genCount++];
                }
                return returnString;
            }
        }
    }

    internal class BruteGenerator
    {
        //based on rolfl's code at https://codereview.stackexchange.com/users/31503/rolfl

        private static char[] _charArray = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_', '-' };

        public static string GenerateString(ulong count)
        {
            string stringGen = "";
            ulong baseLength = (ulong)_charArray.Length;

            do
            {
                stringGen = _charArray[count % baseLength] + stringGen;
                count /= baseLength;
            } while (count != 0);

            return stringGen;
        }
    }
}