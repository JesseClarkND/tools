using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElDorado.Utility
{
    public class SubDomainGenerator
    {
        //based on rolfl's code at https://codereview.stackexchange.com/users/31503/rolfl
        private int _genCount = 0;
        private char[] _charArray = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_' };

        public string GenerateString()
        {
            string password = "";
            ulong baseLength = (ulong)_charArray.Length;

            // get the current value, increment the next.
            ulong current = (ulong)_genCount++;

            do
            {
                password = _charArray[current % baseLength] + password;
                current /= baseLength;
            } while (current != 0);

            return password;
        }
    }
}